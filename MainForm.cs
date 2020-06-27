using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputSimulate
{
    public partial class MainForm : Form
    {
        private readonly MouseHook _mouseHook = new MouseHook();
        private readonly HookData _data = new HookData();

        public MainForm()
        {
            InitializeComponent();
            _mouseHook.MouseClickEvent += (sender, args) => { };
            _mouseHook.MouseDownEvent += MouseHook_MouseClickEvent;
            _mouseHook.MouseUpEvent += (sender, args) => { };
            _mouseHook.MouseMoveEvent += (sender, args) => { };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            BindingBox.Items.Clear();
            BindingBox.Items.Add(MouseButtons.Middle);
            BindingBox.Items.Add(MouseButtons.XButton1);
            BindingBox.Items.Add(MouseButtons.XButton2);
            BindingBox.SelectedItem = MouseButtons.Middle;
            RefreshButton_Click(this, e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            StopButton_Click(this, e);
            base.OnFormClosed(e);
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ApplicationBox.Items.Clear();
            foreach (var process in Process.GetProcesses())
            {
                if (process.GetMainWindowHandle() == IntPtr.Zero)
                    continue;
                if (process.Id == Process.GetCurrentProcess().Id)
                    continue;
                ApplicationBox.Items.Add(process.ProcessName + " | " + process.Id);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var item = ApplicationBox.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(item))
                return;
            if (BoardScriptBox.Lines.Length <= 0)
                return;

            ApplicationBox.Enabled = false;
            BoardScriptBox.Enabled = false;
            MouseScriptBox.Enabled = false;
            ShiftBox.Enabled = false;
            EnableMouseScriptBox.Enabled = false;
            RefreshButton.Enabled = false;
            StartButton.Enabled = false;
            BindingBox.Enabled = false;
            LoadButton.Enabled = false;
            SaveButton.Enabled = false;
            StopButton.Enabled = true;
            LogBox.Clear();

            var split = item.LastIndexOf("|", StringComparison.Ordinal);
            _data.ProcessId = int.Parse(item.Substring(split + 1).Trim());
            _data.ProcessName = item.Substring(0, split).Trim();
            _data.BoardScript = BoardScriptBox.Lines;
            _data.MouseScript = EnableMouseScriptBox.Checked ? MouseScriptBox.Lines : null;
            _data.ShiftControlled = EnableMouseScriptBox.Checked && ShiftBox.Checked;
            _data.Binding = (MouseButtons)BindingBox.SelectedItem;
            _data.Enabled = false;
            _data.StartWorkerThread(WorkerStart);
            _mouseHook.SetHook();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (StartButton.Enabled)
                return;
            _mouseHook.UnHook();
            _data.StopWorkerThread();

            ApplicationBox.Enabled = true;
            BoardScriptBox.Enabled = true;
            EnableMouseScriptBox.Enabled = true;
            MouseScriptBox.Enabled = EnableMouseScriptBox.Checked;
            ShiftBox.Enabled = EnableMouseScriptBox.Checked;
            RefreshButton.Enabled = true;
            StartButton.Enabled = true;
            StopButton.Enabled = true;
            BindingBox.Enabled = true;
            LoadButton.Enabled = true;
            SaveButton.Enabled = true;
        }

        delegate void LogCallback(string text);
        private void Log(string text)
        {
            if (InvokeRequired)
            {
                var callback = new LogCallback(Log);
                Invoke(callback, text);
                return;
            }
            LogBox.SuspendLayout();
            if (LogBox.Lines.Length >= 100)
                LogBox.Lines = LogBox.Lines.Skip(1).ToArray();
            LogBox.AppendText($"[{DateTime.Now:T}] {text}" + Environment.NewLine);
            LogBox.ResumeLayout();
        }

        [DllImport("user32.dll ", CharSet = CharSet.Auto, ExactSpelling = true)]
        static extern IntPtr GetForegroundWindow();

        [Flags]
        enum MouseFlag : uint
        {
            //Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            //MiddleDown = 0x0020,
            //MiddleUp = 0x0040,
            //XDown = 0x0080,
            //XUp = 0x0100,
            //Wheel = 0x0800,
            //VirtualDesk = 0x4000,
            //Absolute = 0x8000
        }

        enum MouseKey
        {
            Left,
            Right
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseFlag flags, int dx, int dy, uint data, UIntPtr extra);
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private void MouseHook_MouseClickEvent(object sender, MouseEventArgs e)
        {
            var process = _data.GetProcess();
            if (process == null || process.GetMainWindowHandle() == IntPtr.Zero)
                return;
            if (GetForegroundWindow() != process.GetMainWindowHandle())
                return;
            if (e.Button != _data.Binding)
                return;
            if (_data.WorkerThread == null)
                return;
            var message = _data.HandleTriggerEvent();
            Log(message);
        }

        private void WorkerStart()
        {
            var task1 = Task.Factory.StartNew(StartBoardSimulateTask, TaskCreationOptions.LongRunning);
            var task2 = Task.Factory.StartNew(StartMouseSimulateTask, TaskCreationOptions.LongRunning);
            Task.WaitAll(task1, task2);
        }

        private void StartMouseSimulateTask()
        {
            if (_data.MouseScript == null || _data.MouseScript.Length <= 0)
                return;
            for (int current = 0; current < _data.MouseScript.Length;
                current = current == _data.MouseScript.Length - 1 ? 0 : (current + 1))
            {
                _data.CheckIfTriggerEnabled();
                if (_data.WorkerThread == null)
                    return;
                var line = _data.MouseScript[current].Trim();
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                if (line.StartsWith(";")) // 注释
                    continue;
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    var sleep = int.Parse(line.Substring(1, line.Length - 2).Trim());
                    Thread.Sleep(sleep);
                }
                else
                {
                    var pressed = false;
                    try
                    {
                        if (_data.GetProcess() == null)
                            throw new Exception("找不到进程");
                        var mouse = (MouseKey) Enum.Parse(typeof(MouseKey), line, true);
                        if (_data.ShiftControlled)
                        {
                            keybd_event(0x10, 0x45, 0x1, UIntPtr.Zero); // SHIFT + KEYEVENTF_EXTENDEDKEY
                            Log("按住 SHIFT 键");
                            pressed = true;
                        }
                        if (mouse == MouseKey.Left)
                        {
                            mouse_event(MouseFlag.LeftDown, Cursor.Position.X, Cursor.Position.Y, 0, UIntPtr.Zero);
                            Thread.Sleep(100);
                            mouse_event(MouseFlag.LeftUp, Cursor.Position.X, Cursor.Position.Y, 0, UIntPtr.Zero);
                            Log("鼠标: " + line);
                        }
                        else if (mouse == MouseKey.Right)
                        {
                            mouse_event(MouseFlag.RightDown, Cursor.Position.X, Cursor.Position.Y, 0, UIntPtr.Zero);
                            Thread.Sleep(100);
                            mouse_event(MouseFlag.RightUp, Cursor.Position.X, Cursor.Position.Y, 0, UIntPtr.Zero);
                            Log("鼠标: " + line);
                        }
                    }
                    catch (Exception)
                    {
                        Log("无法发送鼠标: " + line);
                    }
                    finally
                    {
                        if (_data.ShiftControlled && pressed)
                        {
                            keybd_event(0x10, 0x45, 0x1 | 0x2, UIntPtr.Zero); // SHIFT + KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP
                            Log("释放 SHIFT 键");
                        }
                    }
                }
            }
        }

        private void StartBoardSimulateTask()
        {
            for (int current = 0; current < _data.BoardScript.Length;
                current = current == _data.BoardScript.Length - 1 ? 0 : (current + 1))
            {
                _data.CheckIfTriggerEnabled();
                if (_data.WorkerThread == null)
                    return;
                var line = _data.BoardScript[current].Trim();
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                if (line.StartsWith(";")) // 注释
                    continue;
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    var sleep = int.Parse(line.Substring(1, line.Length - 2).Trim());
                    Thread.Sleep(sleep);
                }
                else
                {
                    try
                    {
                        if (_data.GetProcess() == null)
                            throw new Exception("找不到进程");
                        SendKeys.SendWait(line);
                        Log("键盘: " + line);
                    }
                    catch (Exception)
                    {
                        Log("无法发送键盘: " + line);
                    }
                }
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.AddExtension = true;
            dialog.AutoUpgradeEnabled = true;
            dialog.CheckPathExists = true;
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            dialog.DefaultExt = ".txt";
            dialog.RestoreDirectory = true;
            dialog.ShowHelp = false;
            dialog.SupportMultiDottedExtensions = false;
            dialog.Title = @"打开脚本文件";
            dialog.Filter = @"文本文件（*.txt）|*.txt|所有文件（*.*）|*.*";
            dialog.FilterIndex = 0;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;
            var lines = File.ReadAllLines(dialog.FileName);
            var seperate = lines.ToList().IndexOf(SeperateLine);
            BoardScriptBox.Lines = seperate == -1 ? lines :
                (seperate == 0 ? new string[0] : lines.Take(seperate).ToArray());
            MouseScriptBox.Lines = seperate == -1 || seperate == lines.Length - 1 ? new string[0] : 
                lines.Skip(seperate + 1).ToArray();
        }

        private const string SeperateLine = "----万恶的分割线----";

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.CheckFileExists = false;
            dialog.AddExtension = true;
            dialog.AutoUpgradeEnabled = true;
            dialog.CheckPathExists = true;
            dialog.OverwritePrompt = true;
            dialog.DefaultExt = ".txt";
            dialog.RestoreDirectory = true;
            dialog.ShowHelp = false;
            dialog.SupportMultiDottedExtensions = false;
            dialog.Title = @"保存脚本文件";
            dialog.Filter = @"文本文件（*.txt）|*.txt|所有文件（*.*）|*.*";
            dialog.FilterIndex = 0;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;
            File.WriteAllLines(dialog.FileName, BoardScriptBox.Lines);
            File.AppendAllLines(dialog.FileName, new []{SeperateLine});
            File.AppendAllLines(dialog.FileName, MouseScriptBox.Lines);
        }

        private void EnableMouseScriptBox_CheckedChanged(object sender, EventArgs e)
        {
            MouseScriptBox.Enabled = EnableMouseScriptBox.Checked;
            ShiftBox.Enabled = EnableMouseScriptBox.Checked;
        }
    }
}
