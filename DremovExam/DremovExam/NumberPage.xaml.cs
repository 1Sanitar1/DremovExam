using DremovExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DremovExam
{
    public partial class NumberPage : ContentPage
    {
        public NumberPage()
        {
            InitializeComponent();

            BindingContext = new Number();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.Database.GetNumbersAsync();
        }
    }
}