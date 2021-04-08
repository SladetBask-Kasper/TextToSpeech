using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace TextToSpeech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public SpeechSynthesizer synthesizer;

        private void bSpeak_Click(object sender, EventArgs e)
        {
            if (langs.SelectedIndex < 0)
            {
                return;
            }
            synthesizer.SpeakAsyncCancelAll();
            synthesizer.SelectVoice(langs.SelectedItem.ToString());
            //synthesizer.SelectVoice("Microsoft Asaf Desktop");
            synthesizer.Rate = speedSlider.Value;

            string toSpeak = "";
            if (inputArea.SelectedText.Length > 0)
                toSpeak = inputArea.SelectedText;
            else
                toSpeak = inputArea.Text;
            synthesizer.SpeakAsync(toSpeak);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bSpeak.Text = Properties.Resources.ENG_bSpeak_txt;
            this.Text = Properties.Resources.ENG_form1_txt;
            speedLabelText.Text = Properties.Resources.ENG_speedLabel_txt + ":" ;

            //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer = new SpeechSynthesizer();
            synthesizer.SetOutputToDefaultAudioDevice();
            synthesizer.Volume = 100;
            foreach (var voice in synthesizer.GetInstalledVoices())
            {
                var info = voice.VoiceInfo;
                langs.Items.Add(info.Name);
                //inputArea.Text += info.Name + "\n";
            }
        }

        private void speedSlider_Scroll(object sender, EventArgs e)
        {
            speedLabel.Text = speedSlider.Value.ToString();
        }
    }
}
