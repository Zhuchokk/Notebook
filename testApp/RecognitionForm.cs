using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace testApp
{
    public partial class RecognitionForm : Form
    {
        SpeechRecognitionEngine recognizer;
        Settings settings;
        public RecognitionForm(Settings s)
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

                textBox1.ForeColor = theme.child_form_text;
                textBox1.BackColor = theme.child_form_entry_back;

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

                textBox1.ForeColor = theme.child_form_text;
                textBox1.BackColor = theme.child_form_entry_back;

                button1.ForeColor = theme.child_form_but_text;
                button1.BackColor = theme.child_form_but_back;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Tag.ToString() == "0")
            {
                
                string lang = "";
                if (comboBox1.SelectedItem.ToString() == "English")
                {
                    lang = "en";
                }
                else
                {
                    lang = "ru-RU";
                }
                try
                {
                    
                    recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo(lang));
                    
                    recognizer.LoadGrammar(new DictationGrammar());

                    recognizer.SpeechRecognized +=
                          new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

                    recognizer.SetInputToDefaultAudioDevice();
                    recognizer.RecognizeAsync(RecognizeMode.Multiple);
                    button1.Tag = "1";
                    button1.Text = "Stop";
                }
                catch
                {
                    MessageBox.Show("Error!Maybe you don't have a "+ lang + " pocket in your PC", "Notebook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

                
            }
            else
            {
                button1.Tag = "0";
                button1.Text = "Start";
                recognizer.RecognizeAsyncStop();
                
            }
            

               

            
        }
        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            textBox1.Text = e.Result.Text;
            GC.Collect();
        }
    }
}