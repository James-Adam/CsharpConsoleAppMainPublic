namespace CsharpConsoleAppMain.DevFundamentals.ProgramTechniques;

public partial class WindFormApp : Form
{
    public WindFormApp()
    {
        InitializeComponent();
        //textBox1.Text = "Welcome to my app!";
    }

    public static void WindForm()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new WindFormApp());
    }

    private void InitializeComponent()
    {
        textBox1 = new TextBox();
        button1 = new Button();
        textBox2 = new TextBox();
        SuspendLayout();
        // textBox1
        textBox1.Location = new Point(13, 13);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(387, 101);
        textBox1.TabIndex = 0;
        // button1
        button1.Location = new Point(13, 131);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 1;
        button1.Text = "GO";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // textBox2
        textBox2.Location = new Point(13, 175);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(387, 20);
        textBox2.TabIndex = 2;
        // WindFormApp
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(412, 325);
        Controls.Add(textBox2);
        Controls.Add(button1);
        Controls.Add(textBox1);
        Name = "WindFormApp";
        Text = "Windows Forms Application";
        ResumeLayout(false);
        PerformLayout();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string input = textBox1.Text;
        textBox2.Text = input;
    }

    //private void textBox1_TextChanged(object sender, EventArgs e)
    //{
    //    string input = textBox1.Text;
    //    textBox2.Text = input;
    //}
}