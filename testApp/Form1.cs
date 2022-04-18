﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testApp
{
    public partial class FindForm : Form
    {
        public int last_index = -1;
        public bool changed = false;
        public RichTextBox richTextBox;
        public Active activate;


        public FindForm(ref RichTextBox richText, Active active)
        {
            InitializeComponent();
            richTextBox = richText;
            activate = active;
        }
        public int find(string main, string to_find, bool match, int vector, bool wrap)
        {
            bool flag = false;
            if (match)
            {
                main = main.ToLower();
                to_find = to_find.ToLower();
            }
            if(vector > 0)
            {
                if(last_index + 1 + to_find.Length > main.Length && wrap) { last_index = -1; }
                for(int i=last_index + 1; i <= main.Length - to_find.Length; i++)
                {
                    if(main[i] == to_find[0])
                    {
                        flag = true;
                        for(int j=0; j < to_find.Length; j++)
                        {
                            if(main[i + j] != to_find[j]) { flag = false; break; }
                        }
                        if (flag)
                        {
                            last_index = i;
                            return i;
                        }
                    }
                }
                // переходим сюда, если не нашли вариантов
                if(last_index == -1) { 
                    return -1; 
                }
                else
                {
                    if (wrap)
                    {
                        last_index = -1;
                        return find(main, to_find, match, vector, wrap);
                    } else
                    {
                        return -1;
                    }
                    
                }
                
            } else if(vector < 0)
            {
                if (last_index - to_find.Length < 0 && wrap) { last_index = main.Length; }
                for(int i=last_index - 1; i >= to_find.Length - 1; i--)
                {
                    if(main[i] == to_find[to_find.Length - 1])
                    {
                        flag = true;
                        for(int j=0; j < to_find.Length; j++)
                        {
                            if(main[i - j] != to_find[to_find.Length - 1 - j]) { flag = false; break; }
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

        private void button1_Click(object sender, EventArgs e)
        {
            string text_to_find = textBox1.Text;
            bool match = checkBox1.Checked;
            bool wrap = checkBox2.Checked;
            int vector;
            int index;
            if (radioButton1.Checked) { vector = 1; } else { vector = -1; }

            if (!changed)
            {
                index = find(richTextBox.Text, text_to_find, match, vector, wrap);
                if(index == -1)
                {
                    MessageBox.Show("Cannot find '" + text_to_find + "'", "Notebook", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if(vector > 0) { last_index = -1; } else { last_index = richTextBox.Text.Length; }
                index = find(richTextBox.Text, text_to_find, match, vector, wrap);
                if(index == -1)
                {
                    MessageBox.Show("Cannot find '" + text_to_find + "'", "Notebook", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    richTextBox.Select(index, text_to_find.Length);
                    richTextBox.ScrollToCaret();
                    activate();
                }
                
            }
            

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

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            changed = true;
        }
    }
}