using mAUI.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace mAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var client = new WebClient();
            Supplies.ItemsSource = JsonConvert.DeserializeObject<List<Supplier>>(client.DownloadString("https://localhost:44338/api/Suppliers"));
            Stores.ItemsSource = JsonConvert.DeserializeObject<List<Store>>(client.DownloadString("https://localhost:44338/api/Stores"));
            Owners.ItemsSource = JsonConvert.DeserializeObject<List<Owner>>(client.DownloadString("https://localhost:44338/api/Owners"));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Supplies.ItemsSource = PlayerService.Get<List<Supplier>>();
        }

        private async void btnAdd_Edit_Clicked(object sender, EventArgs e)
        {
            Data.supl = null;
            await Navigation.PushAsync(new Add());
        }

        private async void Edit_Click(object sender, EventArgs e)
        {
            Data.supl = (Supplier)Supplies.SelectedItem;
            await Navigation.PushAsync(new Add());
        }

        private void btnDel_Clicked(object sender, EventArgs e)
        {
            var selectedSupl = (Supplier)Supplies.SelectedItem;
            if (selectedSupl != null)
            {
                PlayerService.Delete(selectedSupl, selectedSupl.SupplierId);
            }
            Supplies.ItemsSource = PlayerService.Get<List<Supplier>>();
        }
    }
    public static class Data
    {
        public static Supplier supl;
    }

    public class PlayerService
    {
        const string Url = "https://localhost:44338/api/Suppliers";
        public static T Get<T>()
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            var response = webClient.DownloadString(Url);
            return JsonConvert.DeserializeObject<T>(response);
        }
        public static string Post<T>(T editObject)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string data = JsonConvert.SerializeObject(editObject);
            return webClient.UploadString(Url, "POST", data);
        }
        public static string Put<T>(T editObject, int id)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string data = JsonConvert.SerializeObject(editObject);
            return webClient.UploadString(Url + "\\" + id.ToString(), "PUT", data);
        }
        public static string Delete<T>(T editObject, int id)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string data = JsonConvert.SerializeObject(editObject);
            string result = webClient.UploadString(Url + "\\" + id.ToString(), "DELETE", data);
            return result;
        }
    }
}