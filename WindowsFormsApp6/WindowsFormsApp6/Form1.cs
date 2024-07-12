using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadMap();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LoadMap()
        {
            string apiKey = "AIzaSyBxbmsffMgblAR26tM26UbkO3o-vodxfvo"; //  API キーをここに入力
            string url = $"https://www.google.com/maps/embed/v1/view?key={apiKey}&center=35.681236,139.767125&zoom=10";
            webBrowser.Navigate(url);
        }
    }
}
