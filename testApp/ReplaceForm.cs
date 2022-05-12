using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testApp
{
    public partial class ReplaceForm : Form
    {
        public int last_index = -1;
        public bool changed = false;
        public RichTextBox richTextBox;
        public Active activate;
        Settings settings;

        public ReplaceForm(ref RichTextBox richText, Active active, Settings s)
        {
            InitializeComponent();
            richTextBox = richText;
            activate = active;
            settings = s;

            if (settings.theme.ToLower() == "black")
            {
                BlackTheme theme = new BlackTheme();

                this.BackColor = theme.child_form_back;
                this.ForeColor = theme.child_form_text;
                groupBox1.ForeColor = theme.child_form_text;

                button1.ForeColor = theme.child_form_but_text;
                button1.BackColor = theme.child_form_but_back;

                button2.ForeColor = theme.child_form_but_text;
                button2.BackColor = theme.child_form_but_back;

                button3.ForeColor = theme.child_form_but_text;
                button3.BackColor = theme.child_form_but_back;

                button4.ForeColor = theme.child_form_but_text;
                button4.BackColor = theme.child_form_but_back;

                textBox1.ForeColor = theme.child_form_text;
                textBox1.BackColor = theme.child_form_entry_back;

                textBox2.ForeColor = theme.child_form_text;
                textBox2.BackColor = theme.child_form_entry_back;

                radioButton1.ForeColor = theme.child_form_text;
                radioButton1.BackColor = theme.child_form_back;

                radioButton2.ForeColor = theme.child_form_text;
                radioButton2.BackColor = theme.child_form_back;
            }
            else
            {
                WhiteTheme theme = new WhiteTheme();

                this.BackColor = theme.child_form_back;
                this.ForeColor = theme.child_form_text;
                groupBox1.ForeColor = theme.child_form_text;

                button1.ForeColor = theme.child_form_but_text;
                button1.BackColor = theme.child_form_but_back;

                button2.ForeColor = theme.child_form_but_text;
                button2.BackColor = theme.child_form_but_back;

                button3.ForeColor = theme.child_form_but_text;
                button3.BackColor = theme.child_form_but_back;

                button4.ForeColor = theme.child_form_but_text;
                button4.BackColor = theme.child_form_but_back;

                textBox1.ForeColor = theme.child_form_text;
                textBox1.BackColor = theme.child_form_entry_back;

                textBox2.ForeColor = theme.child_form_text;
                textBox2.BackColor = theme.child_form_entry_back;

                radioButton1.ForeColor = theme.child_form_text;
                radioButton1.BackColor = theme.child_form_back;

                radioButton2.ForeColor = theme.child_form_text;
                radioButton2.BackColor = theme.child_form_back;


            }
        }

        public int find(string main, string to_find, bool match, int vector, bool wrap)
        {
            bool flag = false;
            if (match)
            {
                main = main.ToLower();
                to_find = to_find.ToLower();
            }
            if (vector > 0)
            {
                if (last_index + 1 + to_find.Length > main.Length && wrap) { last_index = -1; }
                for (int i = last_index + 1; i <= main.Length - to_find.Length; i++)
                {
                    if (main[i] == to_find[0])
                    {
                        flag = true;
                        for (int j = 0; j < to_find.Length; j++)
                        {
                            if (main[i + j] != to_find[j]) { flag = false; break; }
                        }
                        if (flag)
                        {
                            last_index = i;
                            return i;
                        }
                    }
                }
                // переходим сюда, если не нашли вариантов
                if (last_index == -1)
                {
                    return -1;
                }
                else
                {
                    if (wrap)
                    {
                        last_index = -1;
                        return find(main, to_find, match, vector, wrap);
                    }
                    else
                    {
                        return -1;
                    }

                }

            }
            else if (vector < 0)
            {
                if (last_index - to_find.Length < 0 && wrap) { last_index = main.Length; }
                for (int i = last_index - 1; i >= to_find.Length - 1; i--)
                {
                    if (main[i] == to_find[to_find.Length - 1])
                    {
                        flag = true;
                        for (int j = 0; j < to_find.Length; j++)
                        {
                            if (main[i - j] != to_find[to_find.Length - 1 - j]) { flag = false; break; }
                        }
                        if (flag)
                        {
                            last_index = i - to_find.Length + 1;
                            return i - to_find.Length + 1;
                        }
                    }

                }
                if (last_index == main.Length)
                {
                    return -1;
                }
                else
                {
                    if (wrap)
                    {
                        last_index = main.Length;
                        return find(main, to_find, match, vector, wrap);
                    }
                    else
                    {
                        return -1;
                    }

                }


            }
            return -1;

        }
        public int replace_all(string main, string to_find, string to_replace, bool match)
        {
            bool flag = false;
            int response = 0;

            if (match)
            {
                main = main.ToLower();
                to_find = to_find.ToLower();
            }
            
            for (int i = 0; i <= main.Length - to_find.Length; i++)
            {

                if (main[i] == to_find[0])
                {
                    flag = true;
                    for (int j = 0; j < to_find.Length; j++)
                    {
                        if (main[i + j] != to_find[j]) { flag = false; break; }
                    }
                    if (flag)
                    {
                        response += 1;
                        main = main.Substring(0, i) + to_replace + main.Substring(i + to_find.Length);
                    }
                }
            }
            if(response> 0)
            {
                richTextBox.Text = main;
            }
            return response;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length == 0) { return; }
            string text_to_replace = textBox1.Text;
            string text_to_find = textBox2.Text;
            bool match = checkBox1.Checked;
            int response = replace_all(richTextBox.Text, text_to_find, text_to_replace, match);

            if (response > 1)
            {
                MessageBox.Show(Strings.replaced1 + " " + response + " " + Strings.many_replaced2 +" '" + text_to_find + "'", "Notebook", MessageBoxButtons.OK, MessageBoxIcon.Information);
                activate();
            }
            else if (response == 1)
            {
                MessageBox.Show(Strings.replaced1 + " " + response + " " + Strings.one_replaced2 + " '" + text_to_find + "'", "Notebook", MessageBoxButtons.OK, MessageBoxIcon.Information);
                activate();
            }
            else
            {
                MessageBox.Show(Strings.Cannot_find + " '" + text_to_find + "'", "Notebook", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length == 0) { return; }
            string text_to_replace = textBox1.Text;
            string text_to_find = textBox2.Text;
            if(richTextBox.SelectedText == text_to_find)
            {
                richTextBox.SelectedText = text_to_replace;
            }
            else
            {
                MessageBox.Show(Strings.Cannot_find_selected + " '" + text_to_find + "'", "Notebook", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length == 0) { return; }
            string text_to_find = textBox2.Text;
            bool match = checkBox1.Checked;
            bool wrap = checkBox2.Checked;
            int vector;
            int index;
            if (radioButton1.Checked) { vector = 1; } else { vector = -1; }

            if (!changed)
            {
                index = find(richTextBox.Text, text_to_find, match, vector, wrap);
                if (index == -1)
                {
                    MessageBox.Show(Strings.Cannot_find + " '" + text_to_find + "'", "Notebook", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    richTextBox.Select(index, text_to_find.Length);
                    richTextBox.ScrollToCaret();
                    activate();
                }


            }
            else
            {
                changed = false;
                if (vector > 0) { last_index = -1; } else { last_index = richTextBox.Text.Length; }
                index = find(richTextBox.Text, text_to_find, match, vector, wrap);
                if (index == -1)
                {
                    MessageBox.Show(Strings.Cannot_find +" '" + text_to_find + "'", "Notebook", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    richTextBox.Select(index, text_to_find.Length);
                    richTextBox.ScrollToCaret();
                    activate();
                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void checkBox1_Paint(object sender, PaintEventArgs e)
        {
            Color back;
            SolidBrush fore;
            CheckBox box = (CheckBox)sender;
            if (settings.theme.ToLower() == "black")
            {
                BlackTheme theme = new BlackTheme();
                back = theme.child_form_entry_back;
                fore = new SolidBrush(theme.child_form_text);
            }
            else
            {
                WhiteTheme theme = new WhiteTheme();
                back = theme.child_form_entry_back;
                fore = new SolidBrush(theme.child_form_text);
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
