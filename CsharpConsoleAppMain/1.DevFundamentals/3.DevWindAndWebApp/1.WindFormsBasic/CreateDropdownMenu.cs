using System.ComponentModel;
using System.IO;

namespace CsharpConsoleAppMain.DevFundamentals.DevWindAndWebApp;

public partial class CreateDropdownMenu : Form
{
    public CreateDropdownMenu()
    {
        InitializeComponent();
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
        NewDoc newDoc = new();
        newDoc.Show();
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _ = saveFileDialog1.ShowDialog();
    }

    private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
        string textToSave = textBox1.Text;
        string name = saveFileDialog1.FileName;
        File.WriteAllText(textToSave, name);
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
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