using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using IronOcr;

namespace testApp
{
    public partial class ImageForm : Form
    {
        public Settings settings;
        public ImageForm(Settings s)
        {
            InitializeComponent();
            settings = s;

            if (settings.theme.ToLower() == "black")
            {
                BlackTheme theme = new BlackTheme();

                this.BackColor = theme.child_form_back;
                this.ForeColor = theme.child_form_text;
                groupBox1.ForeColor = theme.child_form_text;

                comboBox1.BackColor = theme.child_form_entry_back;
                comboBox1.ForeColor = theme.child_form_text;
                comboBox1.BorderColor = theme.child_form_but_text;
                comboBox1.ButtonColor = theme.child_form_but_back;

                richTextBox1.ForeColor = theme.richbox_text;
                richTextBox1.BackColor = theme.richbox_back;

                textBox1.ForeColor = theme.child_form_text;
                textBox1.BackColor = theme.child_form_entry_back;

                button1.ForeColor = theme.child_form_but_text;
                button1.BackColor = theme.child_form_but_back;

                button2.ForeColor = theme.child_form_but_text;
                button2.BackColor = theme.child_form_but_back;

            }
            else
            {
                WhiteTheme theme = new WhiteTheme();

                this.BackColor = theme.child_form_back;
                this.ForeColor = theme.child_form_text;
                groupBox1.ForeColor = theme.child_form_text;

                comboBox1.BackColor = theme.child_form_entry_back;
                comboBox1.ForeColor = theme.child_form_text;
                comboBox1.BorderColor = theme.child_form_but_text;
                comboBox1.ButtonColor = theme.child_form_but_back;

                richTextBox1.ForeColor = theme.richbox_text;
                richTextBox1.BackColor = theme.richbox_back;

                textBox1.ForeColor = theme.child_form_text;
                textBox1.BackColor = theme.child_form_entry_back;

                button1.ForeColor = theme.child_form_but_text;
                button1.BackColor = theme.child_form_but_back;

                button2.ForeColor = theme.child_form_but_text;
                button2.BackColor = theme.child_form_but_back;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox1.Text))
            {
                MessageBox.Show(Strings.File_exist, "Notebook", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            button2.Text = "Processing...";
            button2.Enabled = false;
            var Ocr = new IronTesseract(); // nothing to configure
            if(comboBox1.SelectedItem.ToString() == "English")
            {
                Ocr.Language = OcrLanguage.English;
            }
            else
            {
                Ocr.Language = OcrLanguage.Russian;
            }
            
            Ocr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;

            using (var Input = new OcrInput())
            {
                Input.AddImage(textBox1.Text);
                OcrResult Result = Ocr.Read(Input);
                richTextBox1.Text = Result.Text;
            }
            button2.Enabled = true;
            button2.Text = "Convert Text To Image";
        }
    }
}
