
namespace TextToSpeech
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bSpeak = new System.Windows.Forms.Button();
            this.inputArea = new System.Windows.Forms.RichTextBox();
            this.langs = new System.Windows.Forms.ListBox();
            this.speedSlider = new System.Windows.Forms.TrackBar();
            this.speedLabel = new System.Windows.Forms.Label();
            this.speedLabelText = new System.Windows.Forms.Label();
            this.onTop = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // bSpeak
            // 
            this.bSpeak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSpeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSpeak.Location = new System.Drawing.Point(662, 396);
            this.bSpeak.Name = "bSpeak";
            this.bSpeak.Size = new System.Drawing.Size(126, 77);
            this.bSpeak.TabIndex = 0;
            this.bSpeak.Text = "Speak";
            this.bSpeak.UseVisualStyleBackColor = true;
            this.bSpeak.Click += new System.EventHandler(this.bSpeak_Click);
            // 
            // inputArea
            // 
            this.inputArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputArea.Location = new System.Drawing.Point(1, 0);
            this.inputArea.Name = "inputArea";
            this.inputArea.Size = new System.Drawing.Size(799, 376);
            this.inputArea.TabIndex = 1;
            this.inputArea.Text = "";
            // 
            // langs
            // 
            this.langs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.langs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.langs.FormattingEnabled = true;
            this.langs.ItemHeight = 20;
            this.langs.Location = new System.Drawing.Point(12, 396);
            this.langs.Name = "langs";
            this.langs.Size = new System.Drawing.Size(203, 84);
            this.langs.TabIndex = 2;
            // 
            // speedSlider
            // 
            this.speedSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedSlider.Location = new System.Drawing.Point(221, 414);
            this.speedSlider.Maximum = 5;
            this.speedSlider.Minimum = -5;
            this.speedSlider.Name = "speedSlider";
            this.speedSlider.Size = new System.Drawing.Size(435, 45);
            this.speedSlider.TabIndex = 3;
            this.speedSlider.Scroll += new System.EventHandler(this.speedSlider_Scroll);
            // 
            // speedLabel
            // 
            this.speedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(269, 398);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(13, 13);
            this.speedLabel.TabIndex = 4;
            this.speedLabel.Text = "0";
            // 
            // speedLabelText
            // 
            this.speedLabelText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.speedLabelText.AutoSize = true;
            this.speedLabelText.Location = new System.Drawing.Point(222, 398);
            this.speedLabelText.Name = "speedLabelText";
            this.speedLabelText.Size = new System.Drawing.Size(38, 13);
            this.speedLabelText.TabIndex = 5;
            this.speedLabelText.Text = "Speed";
            // 
            // onTop
            // 
            this.onTop.AutoSize = true;
            this.onTop.Location = new System.Drawing.Point(225, 455);
            this.onTop.Name = "onTop";
            this.onTop.Size = new System.Drawing.Size(80, 17);
            this.onTop.TabIndex = 6;
            this.onTop.Text = "checkBox1";
            this.onTop.UseVisualStyleBackColor = true;
            this.onTop.CheckedChanged += new System.EventHandler(this.onTop_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.onTop);
            this.Controls.Add(this.speedLabelText);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.speedSlider);
            this.Controls.Add(this.langs);
            this.Controls.Add(this.inputArea);
            this.Controls.Add(this.bSpeak);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSpeak;
        private System.Windows.Forms.RichTextBox inputArea;
        private System.Windows.Forms.ListBox langs;
        private System.Windows.Forms.TrackBar speedSlider;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label speedLabelText;
        private System.Windows.Forms.CheckBox onTop;
    }
}

