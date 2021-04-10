using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextToSpeech
{
    public partial class FindReplace : Form
    {
        Form1 Frm1;

        public void loadLang(ResourceManager rm)
        {
            label1.Text = rm.GetString("Keyword");
            label2.Text = rm.GetString("Keyword");
            label3.Text = rm.GetString("ReplaceWith");
            button1.Text = rm.GetString("Find");
            button2.Text = rm.GetString("Replace");
            Match.Text = rm.GetString("MatchC");
            this.Text = rm.GetString("Find") + " " + rm.GetString("Replace");
            tabPage1.Text = rm.GetString("Find");
            tabPage2.Text = rm.GetString("Replace");
        }

        public FindReplace(Form1 F)
        {
            InitializeComponent();
            Frm1 = F;
        }

        private bool isShown = false;
        public void TrueShow()
        {
            if (!isShown)
            {
                this.Show();
                isShown = true;
            }
        }
        public void TrueHide()
        {
            if (isShown)
            {
                this.Hide();
                isShown = false;
            }
        }

        public void switchToTab(int num)
        {
            tabControl1.SelectedIndex = num;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            Frm1.replace(Keyword.Text, With.Text, Match.Checked);
            this.TrueHide();
        }
        public static void Find(RichTextBox rtb, String word)
        {
            if (word.Trim() == "")
            {
                return;
            }
            int s_start = rtb.SelectionStart, startIndex = 0, index;
            while ((index = rtb.Text.IndexOf(word, startIndex)) != -1)
            {
                rtb.Select(index, word.Length);
                startIndex = index + word.Length;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Find(Frm1.inputArea, findKeyword.Text);
            this.TrueHide();
        }

        private void FindReplace_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                TrueHide();
            }
        }
    }
}
