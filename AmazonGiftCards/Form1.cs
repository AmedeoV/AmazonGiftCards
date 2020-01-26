using System;
using System.Linq;
using System.Windows.Forms;

namespace AmazonGiftCards
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) { label1.Text = "Hi"; label1.Refresh(); }

        private void insertText_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var firstSet = new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            var secondSet = new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            var thirdSet = new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[random.Next(s.Length)]).ToArray());


            label1.Text = $"{firstSet}-{secondSet}-{thirdSet}";
            label1.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
