using DremovExam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DremovExam
{
    public partial class MainPage : ContentPage
    {
        string url = "http://numbersapi.com/";
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new Number();
        }

        async void ToNumberPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NumberPage());
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            var number = (Number)BindingContext;
            if (!string.IsNullOrWhiteSpace(number.Text))
            {
                using (WebClient webClient = new WebClient())
                {
                    await App.Database.SaveNumberAsync(number);

                    string fact = webClient.DownloadString(url + number.ID);
                    number.Fact = fact;
                }

                await App.Database.SaveNumberAsync(number);
            }

            BindingContext = new Number();

            lSuccess.Text = "Успешно добавлено: под номером " + number.ID;
        }
    }
}
