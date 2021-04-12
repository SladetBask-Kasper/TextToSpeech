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
using System.IO;
using System.Resources;
using System.Reflection;
using System.Net;
using System.Text.RegularExpressions;

namespace TextToSpeech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SpeechSynthesizer synthesizer;
        private FontDialog fontDialog1;
        private bool isOnTop = false;
        private string path = "";
        public FindReplace wFind;
        public static ResourceManager rm;

        private string getTxt()
        {
            string rv = "";
            if (inputArea.SelectedText.Length > 0)
                rv = inputArea.SelectedText;
            else
                rv = inputArea.Text;
            return rv;
        }

        private void bSpeak_Click(object sender, EventArgs e)
        {
            if (langs.SelectedIndex < 0)
            {
                MessageBox.Show("You need to select a language...", "No language", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            synthesizer.SpeakAsyncCancelAll();
            synthesizer.SelectVoice(langs.SelectedItem.ToString());
            synthesizer.Rate = speedSlider.Value;

            string toSpeak = getTxt();
            if (toSpeak.Length <= 0)
            {
                MessageBox.Show("You need write some text...", "No text", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            synthesizer.SpeakAsync(toSpeak);
        }

        protected void addLangs()
        {
            foreach (var voice in synthesizer.GetInstalledVoices())
            {
                var info = voice.VoiceInfo;
                langs.Items.Add(info.Name);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wFind = new FindReplace(this);
            this.loadLang(Properties.Settings.Default.Lang);
            inputArea.Text = Properties.Settings.Default.LastText;

            synthesizer = new SpeechSynthesizer();
            synthesizer.SetOutputToDefaultAudioDevice();
            synthesizer.Volume = 100;
            addLangs();
        }

        private void speedSlider_Scroll(object sender, EventArgs e) => speedLabel.Text = speedSlider.Value.ToString();

        private void cancelSpeechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            synthesizer.SpeakAsyncCancelAll();
        }
        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isOnTop = !isOnTop;
            this.TopMost = isOnTop;
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var info = new System.Diagnostics.ProcessStartInfo(Application.ExecutablePath);
            System.Diagnostics.Process.Start(info);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e){this.Opacity = 0.1;}
        private void toolStripMenuItem2_Click(object sender, EventArgs e){this.Opacity = 1.0;}
        private void toolStripMenuItem3_Click(object sender, EventArgs e){this.Opacity = 0.9;}
        private void toolStripMenuItem4_Click(object sender, EventArgs e){this.Opacity = 0.8;}
        private void toolStripMenuItem5_Click(object sender, EventArgs e){this.Opacity = 0.7;}
        private void toolStripMenuItem6_Click(object sender, EventArgs e){this.Opacity = 0.6;}
        private void toolStripMenuItem7_Click(object sender, EventArgs e){this.Opacity = 0.5;}
        private void toolStripMenuItem8_Click(object sender, EventArgs e){this.Opacity = 0.4;}
        private void toolStripMenuItem9_Click(object sender, EventArgs e){this.Opacity = 0.3;}
        private void toolStripMenuItem10_Click(object sender, EventArgs e){this.Opacity = 0.2;}


        private void saveInputArea(bool reUse)
        {
            if (inputArea.Text.ElementAt(inputArea.Text.Length - 1) != '\n')
                inputArea.Text += "\n";
            if (reUse == true)
            {
                if (path.Length > 0)
                {
                    inputArea.SaveFile(path, RichTextBoxStreamType.UnicodePlainText);
                }
                else
                {
                    saveInputArea(false);
                }
            }
            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.Title = "Save a Text File";
                var res = saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "" && res == DialogResult.OK)
                {
                    FileStream fs = (FileStream)saveFileDialog1.OpenFile();
                    path = fs.Name;
                    fs.Close();

                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            inputArea.SaveFile(path, RichTextBoxStreamType.UnicodePlainText);
                            break;
                    }
                }
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e) => saveInputArea(true);
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) => saveInputArea(false);

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                }
            }
            inputArea.LoadFile(path, RichTextBoxStreamType.UnicodePlainText);
        }
        public void loadLang(string lang)
        {
            rm = new ResourceManager("TextToSpeech.langs."+lang+"_local", Assembly.GetExecutingAssembly());

            bSpeak.Text = rm.GetString("Speak_txt");
            this.Text = rm.GetString("Form1_txt");
            speedLabelText.Text = rm.GetString("SpeedLabel_txt") + ":";
            cancelSpeechToolStripMenuItem.Text = rm.GetString("CancelSpeech");
            alwaysOnTopToolStripMenuItem.Text = rm.GetString("OnTop_txt");
            newFileToolStripMenuItem.Text = rm.GetString("NewFile");
            saveFileToolStripMenuItem.Text = rm.GetString("SaveFile");
            saveAsToolStripMenuItem.Text = rm.GetString("SaveAs");
            openFileToolStripMenuItem.Text = rm.GetString("OpenFile");
            transparencyToolStripMenuItem.Text = rm.GetString("Trans");
            settingsToolStripMenuItem.Text = rm.GetString("Settings");
            arkivToolStripMenuItem.Text = rm.GetString("File");
            fontToolStripMenuItem.Text = rm.GetString("Edit");
            fontToolStripMenuItem1.Text = rm.GetString("Font");
            findToolStripMenuItem.Text = rm.GetString("Find");
            replaceToolStripMenuItem.Text = rm.GetString("Replace");
            languageToolStripMenuItem.Text = rm.GetString("Lang");
            refreshLangListToolStripMenuItem.Text = rm.GetString("refreshLang"); // Was originally with big R
            wFind.loadLang(rm);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LastText = inputArea.Text;
            Properties.Settings.Default.Save();
        }

        private void swedishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "swe";
            this.loadLang(Properties.Settings.Default.Lang);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "eng";
            this.loadLang(Properties.Settings.Default.Lang);
        }

        private void 中国ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "man";
            this.loadLang(Properties.Settings.Default.Lang);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "ire";
            this.loadLang(Properties.Settings.Default.Lang);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "ivr";
            this.loadLang(Properties.Settings.Default.Lang);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "ger";
            this.loadLang(Properties.Settings.Default.Lang);
        }

        private void tiếngViệtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "vie";
            this.loadLang(Properties.Settings.Default.Lang);
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "arb";
            this.loadLang(Properties.Settings.Default.Lang);
        }

        private void suomalainenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "suo";
            this.loadLang(Properties.Settings.Default.Lang);
        }

        private void հայերենToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "arm";
            this.loadLang(Properties.Settings.Default.Lang);
        }

        private void српскиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "ser";
            this.loadLang(Properties.Settings.Default.Lang);
        }
        private void českýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "cze";
            this.loadLang(Properties.Settings.Default.Lang);
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fontDialog1 = new FontDialog();
            fontDialog1.ShowColor = false;
            fontDialog1.ShowApply = false;
            fontDialog1.ShowEffects = false;
            fontDialog1.ShowHelp = false;
            fontDialog1.Font = inputArea.Font;
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                inputArea.Font = fontDialog1.Font;
            }
        }
        public void replace(string key, string with, bool matchCase)
        {
            if (matchCase)
                inputArea.Text = inputArea.Text.Replace(key, with);
            else
                inputArea.Text = Regex.Replace(inputArea.Text, key.ToLower(), with, RegexOptions.IgnoreCase);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wFind.switchToTab(0);
            wFind.TrueShow();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wFind.switchToTab(1);
            wFind.TrueShow();
        }

        private void inputArea_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                saveInputArea(true);
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                wFind.switchToTab(0);
                wFind.TrueShow();
            }
        }

        private void refreshLangListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            langs.Items.Clear();
            addLangs();
        }

        
    }
}
