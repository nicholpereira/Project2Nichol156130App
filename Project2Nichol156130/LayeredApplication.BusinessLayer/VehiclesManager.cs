using LayeredApplication.DataLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredApplication.BusinessLayer
{
    public class VehiclesManager : IVehicleManager
    {
        public VehiclesManager()
        {
        }

        public Model.Vehicle Add(Model.Vehicle entity)
        {
            return RepositoryProvider.Instance.Add(entity);
        }

        public bool Update(Model.Vehicle entity)
        {
            return RepositoryProvider.Instance.Update(entity);
        }

        public bool Remove(Model.Vehicle entity)
        {
            return RepositoryProvider.Instance.Remove(entity);
        }

        public Model.Vehicle Get(int id)
        {
            return RepositoryProvider.Instance.Get(id);
        }

        public List<Model.Vehicle> Find(Func<Model.Vehicle, bool> predicate)
        {
            return RepositoryProvider.Instance.Find(predicate);
        }

        public List<Model.Vehicle> GetAll()
        {
            return RepositoryProvider.Instance.GetAll();
        }
    }
}
