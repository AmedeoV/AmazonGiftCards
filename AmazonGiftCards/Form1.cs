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
            MessageBox.Show("Please first login with Gmail, Twitter or Facebook.", "Amazon Gift Cards",
   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //Random random = new Random();
            //const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            //var firstSet = new string(Enumerable.Repeat(chars, 4)
            //  .Select(s => s[random.Next(s.Length)]).ToArray());
            //var secondSet = new string(Enumerable.Repeat(chars, 6)
            //  .Select(s => s[random.Next(s.Length)]).ToArray());
            //var thirdSet = new string(Enumerable.Repeat(chars, 4)
            //  .Select(s => s[random.Next(s.Length)]).ToArray());


            //label1.Text = $"{firstSet}-{secondSet}-{thirdSet}";
            //label1.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gmail_btn(object sender, EventArgs e)
        {
            Form2 myForm = new Form2(this.label3.Text);
            this.Hide();
            myForm.ShowDialog();
            Form1 myForm1 = new Form1();
            this.Hide();
            myForm1.ShowDialog();
            this.Close();
        }

        private void twitterButton_Click(object sender, EventArgs e)
        {
            Form2 myForm = new Form2(this.label4.Text);
            this.Hide();
            myForm.ShowDialog();
            Form1 myForm1 = new Form1();
            this.Hide();
            myForm1.ShowDialog();
            this.Close();
        }

        private void facebookButton_Click(object sender, EventArgs e)
        {
            Form2 myForm = new Form2(this.label5.Text);
            this.Hide();
            myForm.ShowDialog();
            Form1 myForm1 = new Form1();
            this.Hide();
            myForm1.ShowDialog();
            this.Close();
        }
    }

}
