using SC4690_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC4690_HFT_2023241.Logic.Interfaces
{
    public interface ILaptopLogic
    {
        void Create(Laptop item);
        void Delete(int id);
        Laptop Read(int id);
        IQueryable<Laptop> ReadAll();
        void Update(Laptop item);
    }
}
