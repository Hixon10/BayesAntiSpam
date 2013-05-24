using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BayesAntiSpam;

namespace Gui
{
    public partial class Form1 : Form
    {
        private TextHelper textHelper = new TextHelper(1, 1);
        private Shingles shingles = new Shingles();
        private BayesFilter bayesFilter = new BayesFilter();
        private SortedDictionary<string, double> spamShingles = null;
        private SortedDictionary<string, double> hamShingles = null;
        private SortedDictionary<string, double> probabilities = null;

        public Form1()
        {
            InitializeComponent();
//            spamShingles = shingles.GetSpamShingles();
//            hamShingles = shingles.GetHamShingles();
            probabilities = shingles.GetProbabilities();
        }

        private void buttonOpenHamText_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Text";
                dlg.Filter = "Text document (.txt)|*.txt";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    textBoxHam.Text = dlg.FileName;
                 
                    String hamText = File.ReadAllText(dlg.FileName);

                    var hamShingles2 = textHelper.GetShingles(hamText);
                    
                    shingles.AddHamShignles(hamShingles2);
                    
                    hamShingles = shingles.GetHamShingles();

                    if (spamShingles != null)
                    {
                        probabilities = bayesFilter.CalculateProbabilities(spamShingles, hamShingles);
                    }

                    MessageBox.Show("Добавлено " + hamShingles2.Count + " шинглов!");
                }
            }
        }

        private void buttonOpenSpamText_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Text";
                dlg.Filter = "Text document (.txt)|*.txt";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    textBoxSpam.Text = dlg.FileName;

                    String spamText = File.ReadAllText(dlg.FileName);

                    var spamShingles2 = textHelper.GetShingles(spamText);

                    shingles.AddSpamShignles(spamShingles2);

                    spamShingles = shingles.GetSpamShingles();

                    if (hamShingles != null)
                    {
                        probabilities = bayesFilter.CalculateProbabilities(spamShingles, hamShingles);
                    }

                    MessageBox.Show("Добавлено " + spamShingles2.Count + " шинглов!");
                }
            }
        }

        private void buttonClearHamShingles_Click(object sender, EventArgs e)
        {
            shingles.ClearHamShingles();
            hamShingles = null;

            shingles.ClearProbabilities();
            probabilities = null;

            MessageBox.Show("Шинглы удалены!");
        }

        private void buttonClearSpamShingles_Click(object sender, EventArgs e)
        {
            shingles.ClearSpamShingles();
            spamShingles = null;

            shingles.ClearProbabilities();
            probabilities = null;

            MessageBox.Show("Шинглы удалены!");
        }

        private Boolean Validation()
        {
            Boolean isValid = true;
            
            if (probabilities == null)
            {
                isValid = false;
            }
            else
            {
                if (probabilities.Count == 0)
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        private void buttonCheckText_Click(object sender, EventArgs e)
        {
            Boolean isValid = Validation();

            if (!isValid)
            {
                if (hamShingles != null && spamShingles != null)
                {
                    probabilities = bayesFilter.CalculateProbabilities(spamShingles, hamShingles);
                }

                if (!isValid)
                {
                    MessageBox.Show("Фильтр не обучен!");
                    return;
                }
            }

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Text";
                dlg.Filter = "Text document (.txt)|*.txt";

                if (dlg.ShowDialog() == DialogResult.OK)
                { 
                    textBoxTextForChecking.Text = dlg.FileName;

                    String textForChecking = File.ReadAllText(dlg.FileName);

                    var textForCheckingShingles = textHelper.GetShingles(textForChecking);

                    double probability = bayesFilter.Test(textForCheckingShingles, probabilities);

                    if (probability < 0.01)
                    {
                        probability = 0;
                    }

                    labelSpamProbability.Text = "The probability of spam: " + (probability * 100) + "%";
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (probabilities != null)
            {
                shingles.ClearProbabilities();
                shingles.AddProbabilities(probabilities);
            }
        }

    }
}
