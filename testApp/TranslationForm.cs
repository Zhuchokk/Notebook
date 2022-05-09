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
        Settings settings;
        public TranslationForm(Settings s)
        {
            InitializeComponent();
            settings = s;
            if (settings.theme.ToLower() == "black")
            {
                BlackTheme theme = new BlackTheme();

                this.BackColor = theme.child_form_back;
                this.ForeColor = theme.child_form_text;

                comboBox1.BackColor = theme.child_form_entry_back;
                comboBox1.ForeColor = theme.child_form_text;
                comboBox1.BorderColor = theme.child_form_but_text;
                comboBox1.ButtonColor = theme.child_form_but_back;

                comboBox2.BackColor = theme.child_form_entry_back;
                comboBox2.ForeColor = theme.child_form_text;
                comboBox2.BorderColor = theme.child_form_but_text;
                comboBox2.ButtonColor = theme.child_form_but_back;

                button1.ForeColor = theme.child_form_but_text;
                button1.BackColor = theme.child_form_back;

                richTextBox1.ForeColor = theme.richbox_text;
                richTextBox1.BackColor = theme.richbox_back;

                richTextBox2.ForeColor = Color.FromArgb(theme.richbox_text.R - 60, theme.richbox_text.G - 60, theme.richbox_text.B - 60);
                richTextBox2.BackColor = Color.FromArgb(theme.richbox_back.R + 10, theme.richbox_back.G + 10, theme.richbox_back.B + 10);

            }
            else
            {
                WhiteTheme theme = new WhiteTheme();

                this.BackColor = theme.child_form_back;
                this.ForeColor = theme.child_form_text;

                comboBox1.BackColor = theme.child_form_entry_back;
                comboBox1.ForeColor = theme.child_form_text;
                comboBox1.BorderColor = theme.child_form_but_text;
                comboBox1.ButtonColor = theme.child_form_but_back;

                comboBox2.BackColor = theme.child_form_entry_back;
                comboBox2.ForeColor = theme.child_form_text;
                comboBox2.BorderColor = theme.child_form_but_text;
                comboBox2.ButtonColor = theme.child_form_but_back;

                button1.ForeColor = theme.child_form_but_text;
                button1.BackColor = theme.child_form_back;

                richTextBox2.ForeColor = Color.FromArgb(theme.richbox_text.R + 60, theme.richbox_text.G + 60, theme.richbox_text.B + 60);
                richTextBox2.BackColor = Color.FromArgb(theme.richbox_back.R - 10, theme.richbox_back.G - 10, theme.richbox_back.B - 10);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!first)
            {
                richTextBox1.Text = richTextBox2.Text;
            }
            var tmp = comboBox1.Text;
            comboBox1.Text = comboBox2.Text;
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

            switch (comboBox1.Text)
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
            switch (comboBox2.Text)
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
