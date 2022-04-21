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
        public TranslationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tmp = comboBox1.SelectedItem;
            comboBox1.SelectedItem = comboBox2.SelectedItem;
            comboBox2.SelectedItem = tmp;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            richTextBox2.Text = "Translating...";
            /*AQAAAABdMRHcAATuwUtWrGGmgkhVrrjXV - OYHio*/
            string text = richTextBox1.Text;
            string from_lan;
            string to_lan;
            Process process = Process.Start(fileName: )
            
            /*switch(comboBox1.SelectedItem.ToString()){
                case "English":
                    from_lan = LanguageCodes.English;
                    break;
                case "Russian":
                    from_lan = LanguageCodes.Russian;
                    break;
                case "Spanish":
                    from_lan = LanguageCodes.Spanish;
                    break;
                case "Chinese":
                    from_lan = LanguageCodes.ChineseSimplified;
                    break;
            }
            switch (comboBox2.SelectedItem.ToString())
            {
                case "English":
                    to_lan = LanguageCodes.English;
                    break;
                case "Russian":
                    to_lan = LanguageCodes.Russian;
                    break;
                case "Spanish":
                    to_lan = LanguageCodes.Spanish;
                    break;
                case "Chinese":
                    to_lan = LanguageCodes.ChineseSimplified;
                    break;
            }*/

            /*var response = client.TranslateText(text, to_lan, from_lan);
            richTextBox2.Text = response.TranslatedText;*/
        }
    }
}
