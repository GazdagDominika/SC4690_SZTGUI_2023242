using SC4690_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SC4690_HFT_2023241.Logic.Classes.TabletLogic;

namespace SC4690_HFT_2023241.Logic.Interfaces
{
    public interface ITabletLogic
    {
        void Create(Tablet item);
        void Delete(int id);
        Tablet Read(int id);
        IQueryable<Tablet> ReadAll();
        void Update(Tablet item);
        public IEnumerable<object> TabletsSize();
    }
}
