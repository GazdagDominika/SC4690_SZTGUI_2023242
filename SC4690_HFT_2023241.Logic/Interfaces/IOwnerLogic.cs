using SC4690_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC4690_HFT_2023241.Logic.Interfaces
{
    public interface IOwnerLogic
    {
        void Create(Owner item);
        void Delete(int id);
        Owner Read(int id);
        IQueryable<Owner> ReadAll();
        void Update(Owner item);

        int LaptopCount(int id);
        int PhoneSumPrice(int id);
        bool RosegoldTablet(int id);
        bool HugePhone(int id);
        double AllDevicePrice(int id);
        bool AppleUser(int id);

        public IEnumerable<object> YoungRitchOwners();

    }
}
