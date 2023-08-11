namespace CsharpConsoleAppMain.DevFundamentals.ProgramTechniques;

public partial class WindFormApp2 : Form
{
    public WindFormApp2()
    {
        InitializeComponent();
        //textBox1.Text = "Welcome to my app!"

        _ = MessageBox.Show("Welcome to my app!");

        const int x = 5;
        try
        {
            int y = x / int.Parse("0");
        }
        catch (Exception ex)
        {
            _ = MessageBox.Show(ex.Message);
        }

        _ = MessageBox.Show("Welcome to my app!", "Important");
    }

    public static void WindForm2()
    {
        Application.EnableVisualStyles();
        //Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new WindFormApp2());
    }

    private void InitializeComponent()
    {
        // WindFormApp
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(412, 325);

        Name = "WindFormApp2";
        Text = "Windows Forms Application2";
        ResumeLayout(false);
        PerformLayout();
    }

    //private void textBox1_TextChanged(object sender, EventArgs e)
    //{
    //    string input = textBox1.Text;
    //    textBox2.Text = input;
    //}
}