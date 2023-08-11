namespace CsharpConsoleAppMain.DevFundamentals.ProgramTechniques;

public partial class WindFormApp1 : Form
{
    public WindFormApp1()
    {
        InitializeComponent();
        //textBox1.Text = "Welcome to my app!";
    }

    public static void WindForm1()
    {
        Application.EnableVisualStyles();
        //Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new WindFormApp1());
        Start();
    }

    public static void Start()
    {
        _ = MessageBox.Show("Start");
        Application.Run(new WindFormApp1());
    }

    private void InitializeComponent()
    {
        monthCalendar1 = new MonthCalendar();
        label1 = new Label();
        textBox1 = new TextBox();
        button1 = new Button();
        SuspendLayout();
        // monthCalendar1
        monthCalendar1.Location = new Point(18, 31);
        monthCalendar1.Name = "monthCalendar1";
        monthCalendar1.TabIndex = 0;
        monthCalendar1.DateChanged += monthCalendar1_DateChanged;
        // label1
        label1.AutoSize = true;
        label1.Location = new Point(15, 9);
        label1.Name = "label1";
        label1.Size = new Size(138, 13);
        label1.TabIndex = 1;
        label1.Text = "Please Select a date range:";
        // textBox1
        textBox1.Location = new Point(18, 199);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(227, 41);
        textBox1.TabIndex = 2;
        // button1
        button1.Location = new Point(18, 247);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 3;
        button1.Text = "GO";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // WindFormApp1
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(263, 276);
        Controls.Add(button1);
        Controls.Add(textBox1);
        Controls.Add(label1);
        Controls.Add(monthCalendar1);
        Name = "WindFormApp1";
        Text = "Windows Forms Application1";
        ResumeLayout(false);
        PerformLayout();
    }

    private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
    {
        // Method intentionally left empty.
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string dateString = monthCalendar1.SelectionRange.ToString();
        textBox1.Text = dateString;
    }

    //private void textBox1_TextChanged(object sender, EventArgs e)
    //{
    //    string input = textBox1.Text;
    //    textBox2.Text = input;
    //}
}