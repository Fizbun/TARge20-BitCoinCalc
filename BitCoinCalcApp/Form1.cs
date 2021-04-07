using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitCoinCalcApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Bitcoin_Load(object sender, EventArgs e)
        {

        }

        private void currencyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGetRates_Click(object sender, EventArgs e)
        {
            if(currencyCombo.SelectedValue.ToString() == "EUR")
            {
                resultLabel.Visible = true;
                resultTextBox.Visible = true;
                BitCoinRates bitcoin = GetRates();
                float result = Int32.Parse(amountOfCoinBox.Text) * bitcoin.bpi.EUR.rate_float;
                resultTextBox.Text = $"{result.ToString()} {bitcoin.bpi.EUR.code}";


            }

            if (currencyCombo.SelectedValue.ToString() == "USD")
            {
                resultLabel.Visible = true;
                resultTextBox.Visible = true;
                BitCoinRates bitcoin = GetRates();
                float result = Int32.Parse(amountOfCoinBox.Text) * bitcoin.bpi.USD.rate_float;
                resultTextBox.Text = $"{result.ToString()}{bitcoin.bpi.USD.code}";
            }

            //if (currencyCombo.SelectedValue == null)
            //{
            //    throw new Exception();
            //}

            //if (currencyCombo.SelectedItem.ToString() == null)
            //{
            //    Console.WriteLine("Midagi on valesti");
            //}
            // 
            // Ma proovisin bugfixe teha et see iga vale liigutuse peale ei saaks errori minna aga ma pole veel piisavalt teadlik. - Samuel






        }

        public static BitCoinRates GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();


            BitCoinRates bitcoin; 
            using(var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<BitCoinRates>(response);
            }

            return bitcoin; 

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
