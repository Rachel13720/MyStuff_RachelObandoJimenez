using MyStuff_RachelObandoJimenez.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MyStuff_RachelObandoJimenez.ViewModels
{
    public class BrandViewModel : BaseViewModel
    {
        public Brand brand;
        public BrandViewModel()
        {
            brand = new Brand();
        }
        public ObservableCollection<Brand> AllItems()
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                return brand.GetUserBrands();
            }
            catch
            {
                return null;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> AgregarBrand(string name)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                brand.BrandName = name;
                brand.UserId = ObjetosGlobales.user.UserId;
                return await brand.AgregarBrand();
            }
            catch
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<bool> ModificarBrand(int id, string name)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                brand.BrandId = id;
                brand.BrandName = name;
                brand.UserId = ObjetosGlobales.user.UserId;
                return await brand.ModificarBrand();
            }
            catch
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> EliminarBrand(int id)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                brand.BrandId = id;
                return await brand.EliminarBrand();
            }
            catch
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
