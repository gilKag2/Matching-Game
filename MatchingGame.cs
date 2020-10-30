using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Game
{
    public partial class MatchingGame : Form
    {
        Label first, second = null;

        Random r = new Random();
        List<string> icons = new List<string>()
        {"a", "a", "b", "b", "c", "c","d","d","e","e","f","f","g", "g", "h", "h",};

        private void AssignIcons()
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                Label l = c as Label;
                int ran = r.Next(icons.Count);
                l.Text = icons[ran];
                l.ForeColor = l.BackColor; // hide image
                icons.RemoveAt(ran);
            }
        }

        public MatchingGame(string name)
        {
            InitializeComponent();
            User_Name.Text = name;
            AssignIcons();
            progressBar1.Value = 80;
            Time_Left.Text = "80";
        }


        private void Label_Click(object sender, EventArgs e)
        {
            // if the timer is running, ignore more clicks.
            if (timer1.Enabled)
                return;

            Label l = sender as Label;

            // click on exposed image, ignore.
            if (l.ForeColor == Color.Black)
            {
                return;
            }

            if (first == null)
            {
                // show the image.
                l.ForeColor = Color.Black;
                first = l;
                return;
            }

            // if we are here then this is second label.
            l.ForeColor = Color.Black;
            second = l;

            CheckForWin();

            if (first.Text == second.Text)
            {
                first = second = null;
                return;
            } else
            {
                timer1.Start();
            }
        }

        private void CheckForWin()
        {
            foreach (Control c in tableLayoutPanel1.Controls)
                if (c.ForeColor == c.BackColor) return;

            MessageBox.Show("Way to go. You matched them all.", "Congrats");
            timer2.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value > 0)
            {
                progressBar1.Value--;
                Time_Left.Text = progressBar1.Value.ToString();
            } else
            {
                MessageBox.Show("Sorry, times out", "Time Out");
            }
        }

        // hide the images if the matching is wrong.
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            first.ForeColor = first.BackColor;
            first = null;
            second.ForeColor = second.BackColor;
            second = null;
        }

    }
}
