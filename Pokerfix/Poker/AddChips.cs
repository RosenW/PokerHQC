using System;
using System.Drawing;
using System.Windows.Forms;

namespace Poker
{
    public partial class AddChips : Form
    {
        public int chips = 0;
        //TODO: Throw an Exceptions instead message Boxes ?

        public AddChips()
        {
            FontFamily fontFamily = new FontFamily("Arial");
            InitializeComponent();
            ControlBox = false;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            int parsedValue;

            if (int.Parse(textBox1.Text) > 100000000)
            {
                MessageBox.Show("The maximium chips you can add is 100000000");
                return;
            }

            if (!int.TryParse(textBox1.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                return;
            }
            else if (int.TryParse(textBox1.Text, out parsedValue) && int.Parse(textBox1.Text) <= 100000000)
            {
                chips = int.Parse(textBox1.Text);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Are you sure?";
            string title = "Quit";
            var result = MessageBox.Show(message,title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.No:
                    break;
                case DialogResult.Yes:
                    Application.Exit();
                    break;
            }
        }
    }
}
