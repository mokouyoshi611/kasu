using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Web.WebView2.WinForms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        private WebView2 webView;
        public Form1()
        {
            InitializeComponent();
            InitializeWebView();


        }

        private async void InitializeWebView()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(webView);
            await webView.EnsureCoreWebView2Async(null);
            LoadMap();
        }
        private void LoadMap()
        {
            string apiKey = "AIzaSyAT9iMmQ8m6me_fr_vjc2hk-UFk4BNlXIY"; // ここにAPIキーを入れてください
            string url = $@"
            <html>
                <body>
                    <iframe 
                        width='100%' 
                        height='100%' 
                        frameborder='0' 
                        style='border:0' 
                        src='https://www.google.com/maps/embed/v1/view?key={apiKey}&center=35.6895,139.6917&zoom=10' 
                        allowfullscreen>
                    </iframe>
                </body>
            </html>";
            webView.NavigateToString(url);
        }

    }
}
       

    

