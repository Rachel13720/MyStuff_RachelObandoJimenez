using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyStuff_RachelObandoJimenez.Views;

namespace MyStuff_RachelObandoJimenez
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new IngresoPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
