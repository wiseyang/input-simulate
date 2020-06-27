namespace InputSimulate
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ApplicationBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BoardScriptBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.BindingBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MouseScriptBox = new System.Windows.Forms.TextBox();
            this.ShiftBox = new System.Windows.Forms.CheckBox();
            this.EnableMouseScriptBox = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(610, 11);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(87, 33);
            this.RefreshButton.TabIndex = 0;
            this.RefreshButton.Text = "刷新";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ApplicationBox
            // 
            this.ApplicationBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ApplicationBox.FormattingEnabled = true;
            this.ApplicationBox.Location = new System.Drawing.Point(80, 16);
            this.ApplicationBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ApplicationBox.Name = "ApplicationBox";
            this.ApplicationBox.Size = new System.Drawing.Size(508, 25);
            this.ApplicationBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "应用程序: ";
            // 
            // BoardScriptBox
            // 
            this.BoardScriptBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoardScriptBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BoardScriptBox.Location = new System.Drawing.Point(0, 0);
            this.BoardScriptBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BoardScriptBox.Multiline = true;
            this.BoardScriptBox.Name = "BoardScriptBox";
            this.BoardScriptBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BoardScriptBox.Size = new System.Drawing.Size(297, 264);
            this.BoardScriptBox.TabIndex = 5;
            this.BoardScriptBox.Text = "; 直接把按键放在一行\r\n; 参见 SendKeys 类说明\r\nas\r\n; 间隔时间, 单位是毫秒\r\n[500]\r\ndf\r\n[500]\r\n; 脚本循环执行";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(610, 174);
            this.StartButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(87, 33);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "开始";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(610, 250);
            this.StopButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(87, 33);
            this.StopButton.TabIndex = 0;
            this.StopButton.Text = "结束";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "日志: ";
            // 
            // LogBox
            // 
            this.LogBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogBox.Location = new System.Drawing.Point(380, 55);
            this.LogBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(208, 334);
            this.LogBox.TabIndex = 5;
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(80, 356);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(87, 33);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "读取";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(221, 356);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(87, 33);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "保存";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BindingBox
            // 
            this.BindingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BindingBox.FormattingEnabled = true;
            this.BindingBox.Location = new System.Drawing.Point(610, 125);
            this.BindingBox.Name = "BindingBox";
            this.BindingBox.Size = new System.Drawing.Size(87, 25);
            this.BindingBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(613, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "绑定鼠标按键";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(24, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(305, 294);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.BoardScriptBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(297, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "键盘脚本";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.MouseScriptBox);
            this.tabPage2.Controls.Add(this.ShiftBox);
            this.tabPage2.Controls.Add(this.EnableMouseScriptBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(297, 264);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "鼠标脚本";
            // 
            // MouseScriptBox
            // 
            this.MouseScriptBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MouseScriptBox.Enabled = false;
            this.MouseScriptBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MouseScriptBox.Location = new System.Drawing.Point(0, 0);
            this.MouseScriptBox.Multiline = true;
            this.MouseScriptBox.Name = "MouseScriptBox";
            this.MouseScriptBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MouseScriptBox.Size = new System.Drawing.Size(297, 202);
            this.MouseScriptBox.TabIndex = 2;
            this.MouseScriptBox.Text = "; 仅支持模拟鼠标左右键\r\nLeft\r\n[5000]\r\n;Right\r\n;[5000]";
            // 
            // ShiftBox
            // 
            this.ShiftBox.AutoSize = true;
            this.ShiftBox.Checked = true;
            this.ShiftBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShiftBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ShiftBox.Enabled = false;
            this.ShiftBox.Location = new System.Drawing.Point(0, 202);
            this.ShiftBox.Name = "ShiftBox";
            this.ShiftBox.Padding = new System.Windows.Forms.Padding(5);
            this.ShiftBox.Size = new System.Drawing.Size(297, 31);
            this.ShiftBox.TabIndex = 3;
            this.ShiftBox.Text = "同时按住 Shift 键";
            this.ShiftBox.UseVisualStyleBackColor = true;
            // 
            // EnableMouseScriptBox
            // 
            this.EnableMouseScriptBox.AutoSize = true;
            this.EnableMouseScriptBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EnableMouseScriptBox.Location = new System.Drawing.Point(0, 233);
            this.EnableMouseScriptBox.Name = "EnableMouseScriptBox";
            this.EnableMouseScriptBox.Padding = new System.Windows.Forms.Padding(5);
            this.EnableMouseScriptBox.Size = new System.Drawing.Size(297, 31);
            this.EnableMouseScriptBox.TabIndex = 1;
            this.EnableMouseScriptBox.Text = "启动鼠标脚本功能";
            this.EnableMouseScriptBox.UseVisualStyleBackColor = true;
            this.EnableMouseScriptBox.CheckedChanged += new System.EventHandler(this.EnableMouseScriptBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 402);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BindingBox);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ApplicationBox);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.RefreshButton);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "模拟按键";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ComboBox ApplicationBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BoardScriptBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ComboBox BindingBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox EnableMouseScriptBox;
        private System.Windows.Forms.TextBox MouseScriptBox;
        private System.Windows.Forms.CheckBox ShiftBox;
    }
}

