using MyStuff_RachelObandoJimenez.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MyStuff_RachelObandoJimenez.ViewModels
{
    public class ItemCategoryViewModel : BaseViewModel
    {
        public ItemCategory category;

        public ItemCategoryViewModel()
        {
            category = new ItemCategory();
        }

        public ObservableCollection<ItemCategory> AllItems()
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                return category.GetUserItemCategory();
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

        public async Task<bool> AgregarCategory(string itemcategory)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                category.Category = itemcategory;
                category.UserId = ObjetosGlobales.user.UserId;
                return await category.AgregarCategory();
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
        public async Task<bool> ModificarCategory(int id, string itemcategory)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                category.ItemCategoryId = id;
                category.Category = itemcategory;
                category.UserId = ObjetosGlobales.user.UserId;
                return await category.ModificarCategory();
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

        public async Task<bool> EliminarCategory(int id)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                category.ItemCategoryId = id;
                return await category.EliminarCategory();
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
