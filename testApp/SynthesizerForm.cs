using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Media;

namespace testApp
{
    public partial class SynthesizerForm : Form
    {
        public SpeechSynthesizer synth;
        public Settings settings;
        public SynthesizerForm(Settings s)
        {
            InitializeComponent();
            using (synth = new SpeechSynthesizer()){
                foreach (var v in synth.GetInstalledVoices().Select(v => v.VoiceInfo))
                {
                    comboBox1.Items.Add(v.Name);
                }
            }
            comboBox1.SelectedIndex = 0;
            

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

                numericUpDown1.BackColor = theme.child_form_entry_back;
                numericUpDown1.ForeColor = theme.child_form_text;
                numericUpDown1.BorderColor = theme.child_form_but_text;
                numericUpDown1.ButtonHighlightColor = theme.child_form_but_back;

                richTextBox1.ForeColor = theme.richbox_text;
                richTextBox1.BackColor = theme.richbox_back;

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

                numericUpDown1.BackColor = theme.child_form_entry_back;
                numericUpDown1.ForeColor = theme.child_form_text;
                numericUpDown1.BorderColor = theme.child_form_but_text;
                numericUpDown1.ButtonHighlightColor = theme.child_form_but_back;

                richTextBox1.ForeColor = theme.richbox_text;
                richTextBox1.BackColor = theme.richbox_back;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            try
            {
                synth = new SpeechSynthesizer();
                synth.SelectVoice(comboBox1.Text);
                synth.Volume = (int)numericUpDown1.Value;
                synth.SetOutputToDefaultAudioDevice();
                synth.SpeakAsync(richTextBox1.Text);
                
            }
            catch
            {
                MessageBox.Show(Strings.Synth_err, "Notebook", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GC.Collect();
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            saveFileDialog1.ShowDialog();
            if(saveFileDialog1.FileName != "")
            {
                try
                {
                    synth = new SpeechSynthesizer();
                    synth.SelectVoice(comboBox1.Text);
                    synth.Volume = (int)numericUpDown1.Value;
                    synth.SetOutputToDefaultAudioDevice();
                    string path = saveFileDialog1.FileName;
                    synth.SetOutputToWaveFile(path);
                    synth.SpeakAsync(richTextBox1.Text);

                }
                catch
                {
                    MessageBox.Show(Strings.Synth_err, "Notebook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                GC.Collect();
            }

            button2.Enabled = true;
        }
    }
}
