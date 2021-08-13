using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyStuff_RachelObandoJimenez.Models;
using MyStuff_RachelObandoJimenez.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStuff_RachelObandoJimenez.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarBrandPage : ContentPage
    {
        BrandViewModel brand;
        public AgregarBrandPage()
        {
            InitializeComponent();
            brand = new BrandViewModel();
        }

        private async void BtnRegistar_Clicked(object sender, EventArgs e)
        {
            if (await brand.AgregarBrand(TxtEmail.Text))
            {
                await DisplayAlert("Ok", "Se añadió", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Ok", "No se añadió", "OK");
            }
        }
    }
    
}