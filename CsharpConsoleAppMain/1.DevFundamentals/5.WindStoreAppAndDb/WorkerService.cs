using CsharpConsoleAppMain.DevFundamentals.DevWindAndWebApp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace CsharpConsoleAppMain.DevFundamentals.WindStoreAppAndDb;

public partial class WorkerService : Form
{
    public WorkerService()
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
        string textToSave = txtInput.Text;
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

                txtInput.Text = text + " Completed size: " + size + " bytes";
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    [STAThread]
    public string RunScript(string script)
    {
        Runspace runspace = RunspaceFactory.CreateRunspace();
        runspace.Open();
        Pipeline pipeline = runspace.CreatePipeline();
        pipeline.Commands.AddScript(script);
        pipeline.Commands.Add("Out-String");

        Collection<PSObject> results = pipeline.Invoke();
        runspace.Close();
        StringBuilder stringBuilder = new();
        foreach (PSObject pSObject in results)
        {
            _ = stringBuilder.AppendLine(pSObject.ToString());
        }

        return stringBuilder.ToString();
    }

    private void btnRun_Click(object sender, EventArgs e)
    {
        txtOutput.Clear();
        txtOutput.Text = RunScript(txtInput.Text);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        // Method intentionally left empty.
    }
}