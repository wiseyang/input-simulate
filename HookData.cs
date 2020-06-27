using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace InputSimulate
{
    public class HookData
    {
        private readonly ManualResetEvent _trigger = new ManualResetEvent(false);

        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public MouseButtons Binding { get; set; }
        public string[] BoardScript { get; set; }
        public string[] MouseScript { get; set; }
        public bool ShiftControlled { get; set; }
        public bool Enabled { get; set; }
        public Thread WorkerThread { get; private set; }

        public void StartWorkerThread(ThreadStart workerStart)
        {
            WorkerThread = new Thread(workerStart);
            _trigger.Reset();
            WorkerThread.Start();
        }

        public void StopWorkerThread()
        {
            _trigger.Set();
            WorkerThread = null;
        }

        public string HandleTriggerEvent()
        {
            if (Enabled)
            {
                Enabled = false;
                _trigger.Reset();
                return "停止执行脚本";
            }
            Enabled = true;
            _trigger.Set();
            return "开始执行脚本";
        }

        public void CheckIfTriggerEnabled()
        {
            _trigger.WaitOne();
        }

        public Process GetProcess()
        {
            //if (InvokeRequired)
            //{
            //    return new GetFocusedProcessCallback(GetFocusedProcess).Invoke();
            //}
            //var item = ApplicationBox.SelectedItem?.ToString();
            //if (string.IsNullOrWhiteSpace(item))
            //    return null;
            //var split = item.LastIndexOf("|", StringComparison.Ordinal);
            //var id = int.Parse(item.Substring(split + 1).Trim());
            try
            {
                var process = Process.GetProcessById(ProcessId);
                if (process.ProcessName != ProcessName)
                    return null;
                return process;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public static class Extension
    {
        public static IntPtr GetMainWindowHandle(this Process process)
        {
            try
            {
                return process.MainWindowHandle;
            }
            catch (Exception)
            {
                return IntPtr.Zero;
            }
        }

    }
}