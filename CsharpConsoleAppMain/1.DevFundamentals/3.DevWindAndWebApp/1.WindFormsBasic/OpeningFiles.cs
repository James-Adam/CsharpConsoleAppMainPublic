using System.IO;

namespace CsharpConsoleAppMain.DevFundamentals.DevWindAndWebApp;

public partial class OpeningFiles : Form
{
    public OpeningFiles()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK) //test to see if open is complete
        {
            string file = openFileDialog1.FileName;
            try
            {
                string text = File.ReadAllText(file);
                int size = text.Length;

                textBox1.Text = text + " Completed size: " + size + " bytes";
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}