using System.ComponentModel;
using System.IO;

namespace CsharpConsoleAppMain.DevFundamentals.DevWindAndWebApp;

public partial class CreateToolbar : Form
{
    public CreateToolbar()
    {
        InitializeComponent();
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
        //NewDoc newDoc = new NewDoc();
        //newDoc.MdiParent = this;
        //newDoc.Show();
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _ = saveFileDialog1.ShowDialog();
    }

    private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
        //string textToSave = richTextBox2.Text;
        //string name = saveFileDialog1.FileName;
        //File.WriteAllText(textToSave, name);
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK) //test to see if open is complete
        {
            _ = openFileDialog1.FileName;
            try
            {
                //string text = File.ReadAllText(file);
                //size = text.Length;

                //textBox1.Text = text + " Completed size: " + size + " bytes";
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private void tileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Method intentionally left empty.
    }

    private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.Cascade);
    }

    private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.TileVertical);
    }
}