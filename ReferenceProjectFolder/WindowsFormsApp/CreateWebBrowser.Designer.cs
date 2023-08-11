namespace WindowsFormsApp
{
    partial class CreateWebBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateWebBrowser));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.backButton1 = new System.Windows.Forms.ToolStripButton();
            this.forwardButton2 = new System.Windows.Forms.ToolStripButton();
            this.homeButton3 = new System.Windows.Forms.ToolStripButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gobutton1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 24);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(605, 432);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("https://www.google.com", System.UriKind.Absolute);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(605, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backButton1,
            this.forwardButton2,
            this.homeButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(605, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // backButton1
            // 
            this.backButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backButton1.Image = ((System.Drawing.Image)(resources.GetObject("backButton1.Image")));
            this.backButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(23, 22);
            this.backButton1.Text = "toolStripButton1";
            this.backButton1.ToolTipText = "Back";
            this.backButton1.Click += new System.EventHandler(this.backButton1_Click);
            // 
            // forwardButton2
            // 
            this.forwardButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.forwardButton2.Image = ((System.Drawing.Image)(resources.GetObject("forwardButton2.Image")));
            this.forwardButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forwardButton2.Name = "forwardButton2";
            this.forwardButton2.Size = new System.Drawing.Size(23, 22);
            this.forwardButton2.Text = "Forward";
            this.forwardButton2.Click += new System.EventHandler(this.forwardButton2_Click);
            // 
            // homeButton3
            // 
            this.homeButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.homeButton3.Image = ((System.Drawing.Image)(resources.GetObject("homeButton3.Image")));
            this.homeButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.homeButton3.Name = "homeButton3";
            this.homeButton3.Size = new System.Drawing.Size(23, 22);
            this.homeButton3.Text = "Home";
            this.homeButton3.Click += new System.EventHandler(this.homeButton3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(336, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Address:";
            // 
            // gobutton1
            // 
            this.gobutton1.Location = new System.Drawing.Point(495, 25);
            this.gobutton1.Name = "gobutton1";
            this.gobutton1.Size = new System.Drawing.Size(45, 23);
            this.gobutton1.TabIndex = 5;
            this.gobutton1.Text = "GO";
            this.gobutton1.UseVisualStyleBackColor = true;
            this.gobutton1.Click += new System.EventHandler(this.gobutton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 456);
            this.Controls.Add(this.gobutton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Web Browser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton backButton1;
        private System.Windows.Forms.ToolStripButton forwardButton2;
        private System.Windows.Forms.ToolStripButton homeButton3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button gobutton1;
    }
}

