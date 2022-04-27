using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testApp
{
    public partial class SwitchForm : Form
    {
        RichTextBox box;
        Active active;
        Settings settings;
        Dictionary<Char, Char> layout = new Dictionary<Char, Char>()
        {
            {'q', 'й'},
            {'w', 'ц'},
            {'e', 'у'},
            {'r', 'к'},
            {'t', 'е'},
            {'y', 'н'},
            {'u', 'г'},
            {'i', 'ш'},
            {'o', 'щ'},
            {'p', 'з'},
            {'[', 'х'},
            {'{', 'Х'},
            {']', 'ъ'},
            {'}', 'Ъ'},
            {'a', 'ф'},
            {'s', 'ы'},
            {'d', 'в'},
            {'f', 'а'},
            {'g', 'п'},
            {'h', 'р'},
            {'j', 'о'},
            {'k', 'л'},
            {'l', 'д'},
            {';', 'ж'},
            {':', 'Ж'},
            {'\'', 'э'},
            {'"', 'Э'},
            {'z', 'я'},
            {'x', 'ч'},
            {'c', 'с'},
            {'v', 'м'},
            {'b', 'и'},
            {'n', 'т'},
            {'m', 'ь' },
            {',', 'б'},
            {'<', 'Б'},
            {'>', 'Ю'},
            {'.', 'ю'}
        };
        Dictionary<Char, Char> reverse_layout = new Dictionary<Char, Char>() {
            {'й', 'q'},
            {'ц', 'w'},
            {'у', 'e'},
            {'к', 'r'},
            {'е', 't'},
            {'н', 'y'},
            {'г', 'u'},
            {'ш', 'i'},
            {'щ', 'o'},
            {'з', 'p'},
            {'х', '['},
            {'Х', '{'},
            {'ъ', ']'},
            {'Ъ', '}'},
            {'ф', 'a'},
            {'ы', 's'},
            {'в', 'd'},
            {'а', 'f'},
            {'п', 'g'},
            {'р', 'h'},
            {'о', 'j'},
            {'л', 'k'},
            {'д', 'l'},
            {'ж', ';'},
            {'Ж', ':'},
            {'э', '\''},
            {'Э', '"'},
            {'я', 'z'},
            {'ч', 'x'},
            {'с', 'c'},
            {'м', 'v'},
            {'и', 'b'},
            {'т', 'n'},
            {'ь', 'm'},
            {'б', ','},
            {'Б', '<'},
            {'Ю', '>'},
            {'ю', '.'},
        };

        public SwitchForm(ref RichTextBox textBox, Active a, Settings s)
        {
            InitializeComponent();
            box = textBox;
            active = a;
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
                button1.BackColor = theme.child_form_but_back;

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
                button1.BackColor = theme.child_form_but_back;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = box.SelectedText;
            string new_text = "";
            if(comboBox1.SelectedItem.ToString() == "Qwerty")
            {
                for(int i=0; i < text.Length; i++)
                {
                    if (Char.IsLetter(text[i]))
                    {
                        if (Char.IsLower(text[i]))
                        {
                            new_text += layout[text[i]];
                        }
                        else
                        {
                            new_text += Char.ToUpper(layout[Char.ToLower(text[i])]);
                        }
                    }
                    else
                    {
                        try { new_text += layout[text[i]]; } catch { new_text += text[i]; }
                        
                    }
                }
            }
            else
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (Char.IsLetter(text[i]))
                    {
                        if (Char.IsLower(text[i]))
                        {
                            new_text +=  reverse_layout[text[i]];
                        }
                        else
                        {
                            new_text += Char.ToUpper(reverse_layout[Char.ToLower( text[i])]);
                        }
                    }
                    else
                    {
                        try { new_text += reverse_layout[text[i]]; } catch { new_text += text[i]; }
                    }
                }
            }
            box.SelectedText = new_text;
            active();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Qwerty")
            {
                comboBox2.SelectedItem = "Йцукен";
            }
            else
            {
                comboBox2.SelectedItem = "Qwerty";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Qwerty")
            {
                comboBox1.SelectedItem = "Йцукен";
            }
            else
            {
                comboBox1.SelectedItem = "Qwerty";
            }
        }
    }
}
