namespace Gui
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelSpamProbability = new System.Windows.Forms.Label();
            this.buttonCheckText = new System.Windows.Forms.Button();
            this.labelTextForChacking = new System.Windows.Forms.Label();
            this.textBoxTextForChecking = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonClearHamShingles = new System.Windows.Forms.Button();
            this.buttonOpenHamText = new System.Windows.Forms.Button();
            this.labelHam = new System.Windows.Forms.Label();
            this.textBoxHam = new System.Windows.Forms.TextBox();
            this.buttonClearSpamShingles = new System.Windows.Forms.Button();
            this.buttonOpenSpamText = new System.Windows.Forms.Button();
            this.textBoxSpam = new System.Windows.Forms.TextBox();
            this.labelSpam = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 266);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelSpamProbability);
            this.tabPage1.Controls.Add(this.buttonCheckText);
            this.tabPage1.Controls.Add(this.labelTextForChacking);
            this.tabPage1.Controls.Add(this.textBoxTextForChecking);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 240);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Проверить на спам";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelSpamProbability
            // 
            this.labelSpamProbability.AutoSize = true;
            this.labelSpamProbability.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpamProbability.Location = new System.Drawing.Point(15, 61);
            this.labelSpamProbability.Name = "labelSpamProbability";
            this.labelSpamProbability.Size = new System.Drawing.Size(215, 24);
            this.labelSpamProbability.TabIndex = 3;
            this.labelSpamProbability.Text = "The probability of spam: ";
            // 
            // buttonCheckText
            // 
            this.buttonCheckText.Location = new System.Drawing.Point(190, 15);
            this.buttonCheckText.Name = "buttonCheckText";
            this.buttonCheckText.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckText.TabIndex = 2;
            this.buttonCheckText.Text = "Check";
            this.buttonCheckText.UseVisualStyleBackColor = true;
            this.buttonCheckText.Click += new System.EventHandler(this.buttonCheckText_Click);
            // 
            // labelTextForChacking
            // 
            this.labelTextForChacking.AutoSize = true;
            this.labelTextForChacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTextForChacking.Location = new System.Drawing.Point(15, 17);
            this.labelTextForChacking.Name = "labelTextForChacking";
            this.labelTextForChacking.Size = new System.Drawing.Size(57, 24);
            this.labelTextForChacking.TabIndex = 1;
            this.labelTextForChacking.Text = "Text: ";
            // 
            // textBoxTextForChecking
            // 
            this.textBoxTextForChecking.Location = new System.Drawing.Point(77, 18);
            this.textBoxTextForChecking.Name = "textBoxTextForChecking";
            this.textBoxTextForChecking.Size = new System.Drawing.Size(100, 20);
            this.textBoxTextForChecking.TabIndex = 0;
            this.textBoxTextForChecking.Click += new System.EventHandler(this.buttonCheckText_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(576, 240);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Обучить";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonClearHamShingles);
            this.splitContainer1.Panel1.Controls.Add(this.buttonOpenHamText);
            this.splitContainer1.Panel1.Controls.Add(this.labelHam);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxHam);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonClearSpamShingles);
            this.splitContainer1.Panel2.Controls.Add(this.buttonOpenSpamText);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxSpam);
            this.splitContainer1.Panel2.Controls.Add(this.labelSpam);
            this.splitContainer1.Size = new System.Drawing.Size(570, 234);
            this.splitContainer1.SplitterDistance = 285;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonClearHamShingles
            // 
            this.buttonClearHamShingles.Location = new System.Drawing.Point(186, 51);
            this.buttonClearHamShingles.Name = "buttonClearHamShingles";
            this.buttonClearHamShingles.Size = new System.Drawing.Size(75, 43);
            this.buttonClearHamShingles.TabIndex = 3;
            this.buttonClearHamShingles.Text = "Clean Progress";
            this.buttonClearHamShingles.UseVisualStyleBackColor = true;
            this.buttonClearHamShingles.Click += new System.EventHandler(this.buttonClearHamShingles_Click);
            // 
            // buttonOpenHamText
            // 
            this.buttonOpenHamText.Location = new System.Drawing.Point(186, 10);
            this.buttonOpenHamText.Name = "buttonOpenHamText";
            this.buttonOpenHamText.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenHamText.TabIndex = 2;
            this.buttonOpenHamText.Text = "Train";
            this.buttonOpenHamText.UseVisualStyleBackColor = true;
            this.buttonOpenHamText.Click += new System.EventHandler(this.buttonOpenHamText_Click);
            // 
            // labelHam
            // 
            this.labelHam.AutoSize = true;
            this.labelHam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHam.Location = new System.Drawing.Point(13, 10);
            this.labelHam.Name = "labelHam";
            this.labelHam.Size = new System.Drawing.Size(55, 24);
            this.labelHam.TabIndex = 1;
            this.labelHam.Text = "Ham:";
            // 
            // textBoxHam
            // 
            this.textBoxHam.Location = new System.Drawing.Point(74, 12);
            this.textBoxHam.Name = "textBoxHam";
            this.textBoxHam.Size = new System.Drawing.Size(100, 20);
            this.textBoxHam.TabIndex = 0;
            this.textBoxHam.Click += new System.EventHandler(this.buttonOpenHamText_Click);
            // 
            // buttonClearSpamShingles
            // 
            this.buttonClearSpamShingles.Location = new System.Drawing.Point(190, 51);
            this.buttonClearSpamShingles.Name = "buttonClearSpamShingles";
            this.buttonClearSpamShingles.Size = new System.Drawing.Size(75, 43);
            this.buttonClearSpamShingles.TabIndex = 7;
            this.buttonClearSpamShingles.Text = "Clean Progress";
            this.buttonClearSpamShingles.UseVisualStyleBackColor = true;
            this.buttonClearSpamShingles.Click += new System.EventHandler(this.buttonClearSpamShingles_Click);
            // 
            // buttonOpenSpamText
            // 
            this.buttonOpenSpamText.Location = new System.Drawing.Point(190, 11);
            this.buttonOpenSpamText.Name = "buttonOpenSpamText";
            this.buttonOpenSpamText.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenSpamText.TabIndex = 6;
            this.buttonOpenSpamText.Text = "Train";
            this.buttonOpenSpamText.UseVisualStyleBackColor = true;
            this.buttonOpenSpamText.Click += new System.EventHandler(this.buttonOpenSpamText_Click);
            // 
            // textBoxSpam
            // 
            this.textBoxSpam.Location = new System.Drawing.Point(84, 14);
            this.textBoxSpam.Name = "textBoxSpam";
            this.textBoxSpam.Size = new System.Drawing.Size(100, 20);
            this.textBoxSpam.TabIndex = 4;
            this.textBoxSpam.Click += new System.EventHandler(this.buttonOpenSpamText_Click);
            // 
            // labelSpam
            // 
            this.labelSpam.AutoSize = true;
            this.labelSpam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpam.Location = new System.Drawing.Point(14, 12);
            this.labelSpam.Name = "labelSpam";
            this.labelSpam.Size = new System.Drawing.Size(64, 24);
            this.labelSpam.TabIndex = 2;
            this.labelSpam.Text = "Spam:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 290);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "AntiSpam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonOpenHamText;
        private System.Windows.Forms.Label labelHam;
        private System.Windows.Forms.TextBox textBoxHam;
        private System.Windows.Forms.Label labelSpam;
        private System.Windows.Forms.Button buttonClearHamShingles;
        private System.Windows.Forms.Button buttonClearSpamShingles;
        private System.Windows.Forms.Button buttonOpenSpamText;
        private System.Windows.Forms.TextBox textBoxSpam;
        private System.Windows.Forms.Label labelSpamProbability;
        private System.Windows.Forms.Button buttonCheckText;
        private System.Windows.Forms.Label labelTextForChacking;
        private System.Windows.Forms.TextBox textBoxTextForChecking;
    }
}

