﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace testApp
{
    public partial class SynthesizerForm : Form
    {
        public SpeechSynthesizer synth;
        public SynthesizerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                synth = new SpeechSynthesizer();
                synth.Volume = (int)numericUpDown1.Value;
                synth.SetOutputToDefaultAudioDevice();
                synth.Speak(richTextBox1.Text);
            }
            catch
            {
                MessageBox.Show("Error!Maybe you don't have a synthesizer pockets in your PC", "Notebook", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GC.Collect();
            button1.Enabled = true;
        }
    }
}