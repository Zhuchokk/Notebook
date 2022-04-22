using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testApp
{
    public partial class TranslationForm : Form
    {
        bool first = true;
        public TranslationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!first)
            {
                richTextBox1.Text = richTextBox2.Text;
            }
            var tmp = comboBox1.SelectedItem;
            comboBox1.SelectedItem = comboBox2.SelectedItem;
            comboBox2.SelectedItem = tmp;
            
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
            
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (!first) { return; }
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            first = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(richTextBox1.Text.Length == 0) { return; }
            richTextBox2.Text = "Translating...";
            richTextBox2.Update();
            string from_lan = "en";
            string to_lan = "ru";

            switch (comboBox1.SelectedItem.ToString())
            {
                case "English":
                    from_lan = "en";
                    break;
                case "Russian":
                    from_lan = "ru";
                    break;
                case "Spanish":
                    from_lan = "es";
                    break;
                case "Deutsch":
                    from_lan = "de";
                    break;
            }
            switch (comboBox2.SelectedItem.ToString())
            {
                case "English":
                    to_lan = "en";
                    break;
                case "Russian":
                    to_lan = "ru";
                    break;
                case "Spanish":
                    to_lan = "es";
                    break;
                case "Deutsch":
                    to_lan = "de";
                    break;
            }

            Process process = new Process();
            process.StartInfo.FileName = "translate.exe";
            process.StartInfo.Arguments = from_lan + " " + to_lan + " " + richTextBox1.Text; // Note the /c command (*)
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();
            richTextBox2.Text = result;
            timer1.Stop();

        }

        public void combobox_changed(object sender, EventArgs e)
        {
            if (!first)
            {
                richTextBox1.Update();
                comboBox2.Update();
                comboBox1.Update();
                timer1_Tick(sender, e);
            }
            
        }
    }
}
