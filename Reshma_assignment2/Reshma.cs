using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reshma_assignment2
{
    public partial class Reshma : Form
    {
        public Reshma()
        {
            InitializeComponent();
        }
        //REFERENCE: http://nlpdotnet.com/SampleCode/ListWordsByFrequency.aspx

        private static char[] delimiters_no_digits = new char[] {
            '{', '}', '(', ')', '[', ']', '>', '<','-', '_', '=', '+',
      '{', '}', '(', ')', '[', ']', '>', '<','-', '_', '=', '+',
            '|', '\\', ':', ';', ' ', ',', '.', '/', '?', '~', '!',
            '@', '#', '$', '%', '^', '&', '*', ' ', '\r', '\n', '\t',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        private string[] Tokenize(string text)
        {
            string[] tokens = text.Split(delimiters_no_digits, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];

                // Change token only when it starts and/or ends with "'" and  
                // it has at least 2 characters. 

                if (token.Length > 1)
                {
                    if (token.StartsWith("'") && token.EndsWith("'"))
                        tokens[i] = token.Substring(1, token.Length - 2); // remove the starting and ending "'" 

                    else if (token.StartsWith("'"))
                        tokens[i] = token.Substring(1); // remove the starting "'" 

                    else if (token.EndsWith("'"))
                        tokens[i] = token.Substring(0, token.Length - 1); // remove the last "'" 
                }
            }

            return tokens;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            Modal authorForm = new Modal();
            authorForm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Text = textBox1.Text;
            
        }
        private Dictionary<string, int> ToStrIntDict(string[] words)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (string word in words)
            {
                // if the word is in the dictionary, increment its freq. 
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                // if not, add it to the dictionary and set its freq = 1 
                else
                {
                    dict.Add(word, 1);
                }
            }

            return dict;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                string[] words = Tokenize(textBox1.Text);

                if (words.Length > 0)
                {
                    Dictionary<string, int> dict = ToStrIntDict(words);
                    // SortOrder sortOrder = textBox1.Checked ? SortOrder.Ascending;
                    //dict = Reshma_assignment2( dict, sortOrder );
                    StringBuilder resultSb = new StringBuilder(dict.Count * 9);
                    foreach (KeyValuePair<string, int> entry in dict)
                        resultSb.AppendLine(string.Format("{0} [{1}]", entry.Key, entry.Value));
                    textBox2.Text = resultSb.ToString();

                }
            }
        }

       
    }
}
