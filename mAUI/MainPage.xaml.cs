using mAUI.Models;
using Newtonsoft.Json;
using System.Net;

namespace mAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var client = new WebClient();
            Supplies.ItemsSource = JsonConvert.DeserializeObject<List<Supplier>>(client.DownloadString("https://localhost:44338/api/Suppliers"));
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {

        }

        private void btnDel_Clicked(object sender, EventArgs e)
        {

        }
    }
}
