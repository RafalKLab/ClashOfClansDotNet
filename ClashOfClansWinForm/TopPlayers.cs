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
    public partial class TopPlayers : Form
    {
        public TopPlayers()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            For main = new For();
            main.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlayerList.Items.Clear();
            //32000138
            //32000001
            string str1 = textBox1.Text;
            string str2 = textBox2.Text;
            
            if ((str1.Length > 0) & (str2.Length > 0))
            {
                var Param1Parse = int.TryParse(str1, out int param1);
                var Param2Parse = int.TryParse(str2, out int param2);
                if ((Param1Parse == true) & (Param2Parse == true))
                {
                    var provider = new DataProvider();
                    var repository = new Repository(provider);
                    var TopList = provider.GetRankingsForLocation(param1, param2);
                    if(TopList != null)
                    {
                        label5.Text = repository.GetLocationNameByTag(textBox1.Text);
                        foreach (var ranking in TopList)
                        {
                            var item = new ListViewItem(new[] { ranking.rank.ToString(), ranking.name, ranking.trophies.ToString(), ranking.tag });
                            PlayerList.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data not found!");
                    }  
                }
                else
                {
                    MessageBox.Show("Parameters have to be numeric values!");
                }
            }
            else
            {
                MessageBox.Show("You need to provide country id and player count!");
            }
        }

        private void TopPlayers_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
