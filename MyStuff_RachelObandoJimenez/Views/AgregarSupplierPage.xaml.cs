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
    public partial class AgregarSupplierPage : ContentPage
    {
        SupplierViewModel supplier;
        public AgregarSupplierPage()
        {
            InitializeComponent();
            supplier = new SupplierViewModel();
        }

        private async void BtnRegistar_Clicked(object sender, EventArgs e)
        {
            if (await supplier.AgregarSupplier(TxtSupplier.Text))
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