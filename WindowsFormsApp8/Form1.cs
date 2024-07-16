using System;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        private const string AzureMapsApiKey = "AIzaSyBxbmsffMgblAR26tM26UbkO3o-vodxfvo";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("\"C:\\Users\\yoshi\\source\\repos\\WindowsFormsApp8\\WindowsFormsApp8\\HTMLPage1.html\"");
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string address = txtAddress.Text;
            if (!string.IsNullOrEmpty(address))
            {
                var location = await GetCoordinatesAsync(address);
                if (location != null)
                {
                    AddPinToMap(location.Item1, location.Item2);
                    SavePinInformation(address, location.Item1, location.Item2);
                }
                else
                {
                    MessageBox.Show("住所の検索に失敗しました。");
                }
            }
        }
        private async Task<Tuple<double, double>> GetCoordinatesAsync(string address)
        {
            string url = $"https://atlas.microsoft.com/search/address/json?api-version=1.0&subscription-key={AzureMapsApiKey}&query={Uri.EscapeDataString(address)}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(content);
                    var position = json["results"]?[0]?["position"];
                    if (position != null)
                    {
                        double latitude = (double)position["lat"];
                        double longitude = (double)position["lon"];
                        return Tuple.Create(latitude, longitude);
                    }
                }
            }
            return null;
        }

        private void AddPinToMap(double latitude, double longitude)
        {
            string script = $"addPin({latitude}, {longitude});";
            webBrowser1.Document.InvokeScript("eval", new object[] { script });
        }

        private void SavePinInformation(string address, double latitude, double longitude)
        {
            string filePath = "pins.txt";
            string pinInfo = $"{address},{latitude},{longitude}{Environment.NewLine}";
            File.AppendAllText(filePath, pinInfo);
        }


    }
}

