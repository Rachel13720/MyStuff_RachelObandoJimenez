using MyStuff_RachelObandoJimenez.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MyStuff_RachelObandoJimenez.ViewModels
{
    public class ItemLocalizationViewModel : BaseViewModel
    {
        public ItemLocalization localization;

        public ItemLocalizationViewModel()
        {
            localization = new ItemLocalization();
        }

        public ObservableCollection<ItemLocalization> AllItems()
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                return localization.GetUserItemLocalization();
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

        public async Task<bool> AgregarLocalization(string itemlocalization)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                localization.Localization = itemlocalization;
                localization.UserId = ObjetosGlobales.user.UserId;
                return await localization.AgregarLocalization();
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
        public async Task<bool> ModificarLocalization(int id, string itemlocalization)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                localization.ItemLocalizationId = id;
                localization.Localization = itemlocalization;
                localization.UserId = ObjetosGlobales.user.UserId;
                return await localization.ModificarLocalization();
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

        public async Task<bool> EliminarLocalization(int id)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                localization.ItemLocalizationId = id;
                return await localization.EliminarLocalization();
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
