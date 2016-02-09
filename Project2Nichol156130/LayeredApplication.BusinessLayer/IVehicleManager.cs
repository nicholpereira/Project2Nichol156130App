using LayeredApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredApplication.BusinessLayer
{
    public interface IVehicleManager
    {
        Vehicle Add(Vehicle entity);
        bool Update(Vehicle entity);
        bool Remove(Vehicle entity);

        Vehicle Get(int id);
        List<Vehicle> Find(Func<Vehicle, bool> predicate);
        List<Vehicle> GetAll();
    }
}
