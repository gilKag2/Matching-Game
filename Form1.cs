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
    public partial class UserProfile : Form
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (DataOk())
            {
                this.Hide();
                MatchingGame mg = new MatchingGame(First_Name_TB.Text);
                mg.ShowDialog();
            }
        }

        private bool DataOk()
        {
            bool res = true;
            if (First_Name_TB.Text == null || First_Name_TB.Text.Length == 0)
            {
                First_Name_Msg.Text = "First name is required!";
                First_Name_Msg.ForeColor = Color.Red;
                res = false;
            }
            if (Last_Name_TB.Text == null || Last_Name_TB.Text.Length == 0)
            {
                Last_Name_Msg.Text = "Last name is required!";
                Last_Name_Msg.ForeColor = Color.Red;
                res = false;
            }
            if (Email_TB.Text == null || Email_TB.Text.Length == 0)
            {
                Email_Msg.Text = "First name is required!";
                Email_Msg.ForeColor = Color.Red;
                res = false;
            }
            return res;
        }

        private void Init()
        {
            Salutation_CB.SelectedIndex = 0;
            First_Name_TB.Text = null;
            Last_Name_TB.Text = null;
            First_Name_Msg.Text = null;
            Last_Name_Msg.Text = null;
            Email_TB.Text = null;
            Email_Msg.Text = null;
            First_Name_Msg.ForeColor = Color.Black;
            Last_Name_Msg.ForeColor = Color.Black;
            Email_Msg.ForeColor = Color.Black;
        }
        private void UserProfile_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            Init();
        }

    }
}
