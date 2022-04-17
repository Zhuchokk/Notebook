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
    }
}
