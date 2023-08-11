using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class CreateWebBrowser : Form
    {
        public CreateWebBrowser()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com");
        }

        private void backButton1_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                _ = webBrowser1.GoBack();
            }
        }

        private void forwardButton2_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                _ = webBrowser1.GoForward();
            }
        }

        private void homeButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.bing.com");
        }

        private void gobutton1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
        }
    }
}