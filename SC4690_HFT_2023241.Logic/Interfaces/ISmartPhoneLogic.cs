using SC4690_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC4690_HFT_2023241.Logic.Interfaces
{
    public interface ISmartPhoneLogic
    {
        void Create(SmartPhone item);
        void Delete(int id);
        SmartPhone Read(int id);
        IQueryable<SmartPhone> ReadAll();
        void Update(SmartPhone item);
        public IEnumerable<object> GoldSmartPhones();
    }
}
