using MyStuff_RachelObandoJimenez.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MyStuff_RachelObandoJimenez.ViewModels
{
    public class SupplierViewModel : BaseViewModel
    {
        public Supplier supplier;

        public SupplierViewModel()
        {
            supplier = new Supplier();
        }

        public ObservableCollection<Supplier> AllItems()
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                return supplier.GetUserSupplier();
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

        public async Task<bool> AgregarSupplier(string name)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                supplier.SupplierName = name;
                supplier.UserId = ObjetosGlobales.user.UserId;
                return await supplier.AgregarSupplier();
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
        public async Task<bool> ModificarSupplier(int id, string name)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                supplier.SupplierId = id;
                supplier.SupplierName = name;
                supplier.UserId = ObjetosGlobales.user.UserId;
                return await supplier.ModificarSupplier();
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

        public async Task<bool> EliminarSupplier(int id)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                supplier.SupplierId = id;
                return await supplier.EliminarSupplier();
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
