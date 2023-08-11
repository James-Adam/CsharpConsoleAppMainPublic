using System.ComponentModel;
using System.IO;

namespace CsharpConsoleAppMain.DevFundamentals.DevWindAndWebApp;

public partial class SavingFiles : Form
{
    public SavingFiles()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        _ = saveFileDialog1.ShowDialog();
    }

    private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
        string textToSave = richTextBox1.Text;
        string name = saveFileDialog1.FileName;
        File.WriteAllText(textToSave, name);
    }
}