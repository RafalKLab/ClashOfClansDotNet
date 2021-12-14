using ClashOfClansApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashOfClansWinForm
{
    public partial class PlayerForm : Form
    {
        public PlayerForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var provider = new DataProvider();
            var cachingProvider = new CachingProvider(provider);

            var player = cachingProvider.GetPlayerDataByTag(textBox1.Text);
            if(player.name != null)
            {
                label4.Text = player.name;
                label5.Text = player.tag;
                label7.Text = player.townHallLevel.ToString();
                label9.Text = player.townHallWeaponLevel.ToString();
                label11.Text = player.expLevel.ToString();
                label13.Text = player.trophies.ToString();
                label15.Text = player.bestTrophies.ToString();
                label17.Text = player.warStars.ToString();
                label19.Text = player.attackWins.ToString();
                label21.Text = player.defenseWins.ToString();
                label23.Text = player.role;
                label25.Text = player.warPreference;
                label27.Text = player.donations.ToString();
                label29.Text = player.donationsReceived.ToString();
                label31.Text = player.builderHallLevel.ToString();


            } else
            {
                MessageBox.Show("There is nor players with tag: #" + textBox1.Text);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            For main = new For();
            main.ShowDialog();
            this.Close();
        }
    }
}
