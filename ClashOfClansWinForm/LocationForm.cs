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
    public partial class LocationForm : Form
    {
        public LocationForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LocationForm_Load(object sender, EventArgs e)
        {
            var provider = new DataProvider();
            var repository = new Repository(provider);
            var locationList = provider.GetLocations();
            foreach (var location in locationList)
            {
                var item = new ListViewItem(new[] {location.name, location.id });
                LocationList.Items.Add(item);
            } 
        }

        private void CategoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LocationList.Items.Clear();
            var provider = new DataProvider();
            var repository = new Repository(provider);
            var locationList = repository.SortLocationByParameter(0);
            foreach (var location in locationList)
            {
                var item = new ListViewItem(new[] { location.name, location.id });
                LocationList.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LocationList.Items.Clear();
            var provider = new DataProvider();
            var repository = new Repository(provider);
            var locationList = repository.SortLocationByParameter(1);
            foreach (var location in locationList)
            {
                var item = new ListViewItem(new[] { location.name, location.id });
                LocationList.Items.Add(item);
            }
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
