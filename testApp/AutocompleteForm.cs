using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace testApp
{
    
    public partial class AutocompleteForm : Form
    {
        public Settings settings;
        AutocompleteMenuNS.AutocompleteMenu autocomplete;
        public AutocompleteForm(ref Settings s, ref AutocompleteMenuNS.AutocompleteMenu menuNS)
        {

            InitializeComponent();
            settings = s;
            autocomplete = menuNS;
            checkBox2.Checked = settings.autocomplete_enabled;
            checkBox1.Checked = settings.auto_popup;
            numericUpDown1.Value = settings.appear_interval;
            numericUpDown2.Value = settings.minlen_fragment;
            comboBox1.SelectedItem = settings.dictionary;
            comboBox1.Text = settings.dictionary;


            if(settings.theme.ToLower() == "black")
            {
                BlackTheme theme = new BlackTheme();

                this.BackColor = theme.child_form_back;
                this.ForeColor = theme.child_form_text;
                groupBox1.ForeColor = theme.child_form_text;


                numericUpDown1.BackColor = theme.child_form_entry_back;
                numericUpDown1.ForeColor = theme.child_form_text;
                numericUpDown1.BorderColor = theme.child_form_but_text;
                numericUpDown1.ButtonHighlightColor =theme.child_form_but_text;

                numericUpDown2.BackColor = theme.child_form_entry_back;
                numericUpDown2.ForeColor = theme.child_form_text;
                numericUpDown2.BorderColor = theme.child_form_but_text;
                numericUpDown2.ButtonHighlightColor = theme.child_form_but_text;

                comboBox1.BackColor = theme.child_form_entry_back;
                comboBox1.ForeColor = theme.child_form_text;
                comboBox1.BorderColor = theme.child_form_but_text;
                comboBox1.ButtonColor = theme.child_form_but_back;
                
            }
            else
            {
                WhiteTheme theme = new WhiteTheme();

                this.BackColor = theme.child_form_back;
                this.ForeColor = theme.child_form_text;
                groupBox1.ForeColor = theme.child_form_text;


                numericUpDown1.BackColor = theme.child_form_entry_back;
                numericUpDown1.ForeColor = theme.child_form_text;
                numericUpDown1.BorderColor = theme.child_form_but_text;
                numericUpDown1.ButtonHighlightColor = theme.child_form_but_back;
                
                numericUpDown2.BackColor = theme.child_form_entry_back;
                numericUpDown2.ForeColor = theme.child_form_text;
                numericUpDown2.BorderColor = theme.child_form_but_text;
                numericUpDown2.ButtonHighlightColor = theme.child_form_but_back;

                comboBox1.BackColor = theme.child_form_entry_back;
                comboBox1.ForeColor = theme.child_form_text;
                comboBox1.BorderColor = theme.child_form_but_text;
                comboBox1.ButtonColor = theme.child_form_but_back;
            }
        }
        public string[] split(string text)
        {
            string[] words = { };
            string word = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    Array.Resize(ref words, words.Length + 1);
                    word = word.Replace("\r", String.Empty);
                    words[words.Length - 1] = word;
                    word = "";
                }
                else
                {
                    word += text[i];
                }
            }
            return words;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            settings.autocomplete_enabled = checkBox2.Checked;
            autocomplete.Enabled = checkBox2.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            settings.auto_popup = checkBox1.Checked;
            autocomplete.AutoPopup = checkBox1.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            settings.appear_interval = Convert.ToInt32(numericUpDown1.Value);
            autocomplete.AppearInterval = Convert.ToInt32( numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            settings.minlen_fragment = Convert.ToInt32(numericUpDown2.Value);
            autocomplete.MinFragmentLength = Convert.ToInt32(numericUpDown2.Value);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.dictionary = comboBox1.SelectedItem.ToString();
            if(comboBox1.SelectedItem.ToString() == "User-All") {
                autocomplete.Items = split(File.ReadAllText(Application.StartupPath + @"\dictionaries\" + "user-russian.txt", System.Text.Encoding.Default) + "\n" + File.ReadAllText(Application.StartupPath + @"\dictionaries\" + "user-english.txt", System.Text.Encoding.Default));
            }
            else
            {
                autocomplete.Items = split(File.ReadAllText(Application.StartupPath + @"\dictionaries\" + comboBox1.SelectedItem.ToString() + ".txt", System.Text.Encoding.Default));
            }
            
        }

        private void checkBox1_Paint(object sender, PaintEventArgs e)
        {
            Color back;
            SolidBrush fore;
            CheckBox box = (CheckBox)sender;
            if(settings.theme.ToLower() == "black")
            {
                BlackTheme theme = new BlackTheme();
                back = theme.child_form_entry_back;
                fore = new SolidBrush( theme.child_form_text);
            }
            else
            {
                WhiteTheme theme = new WhiteTheme();
                back = theme.child_form_entry_back;
                fore = new SolidBrush( theme.child_form_text);
            }

            Point pt = new Point(e.ClipRectangle.Left, e.ClipRectangle.Top);
            Rectangle rect = new Rectangle(pt, new Size(13, 13));
            Rectangle fRect = ClientRectangle;
            Pen pen = new Pen(back);

            e.Graphics.FillRectangle(new SolidBrush(pen.Color), fRect);
            if (box.Checked)
            {
                using (Font wing = new Font("Wingdings", 10.5f))
                    e.Graphics.DrawString("ü", wing, fore, rect);
            }
            
            e.Graphics.DrawRectangle(pen, rect);
        }
    }

}
