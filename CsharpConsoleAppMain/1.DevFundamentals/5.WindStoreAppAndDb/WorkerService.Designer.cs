namespace CsharpConsoleAppMain.DevFundamentals.WindStoreAppAndDb
{
    partial class WorkerService
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(85, 7);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(605, 23);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "Start-Process -FilePath \"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Vis" +
    "ual Studio 2022\\Visual Studio Tools\\VC\\x86_x64 Cross Tools Command Prompt for VS" +
    " 2022.lnk\" -Verb RunAs";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(696, 6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(69, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "&Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Command:";
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txtOutput.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOutput.ForeColor = System.Drawing.Color.White;
            this.txtOutput.Location = new System.Drawing.Point(85, 36);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(680, 402);
            this.txtOutput.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 36);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(76, 402);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "CMD RUN IN POWER SHELL:  Start-Process -FilePath \"powershell\" -Verb RunAs THEN RU" +
    "N: 1) cd C:\\inetpub\\wwwroot\\WorkerService";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // WorkerService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtInput);
            this.Name = "WorkerService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PowerShell";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private TextBox txtInput;
        private Button btnRun;
        private Label label1;
        private TextBox txtOutput;
        private TextBox textBox1;
    }
}