using SC4690_HFT_2023241.Models;
using SC4690_HFT_2023241.Repository.Databases;
using SC4690_HFT_2023241.Repository.GenericRepository;
using SC4690_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC4690_HFT_2023241.Repository.ModelRepositories
{
    public class LaptopRepository : Repository<Laptop>, IRepository<Laptop>
    {
        public LaptopRepository(SmartDevicesDbContext ctx) : base(ctx)
        { }

        public override Laptop Read(int id)
        {
            return ctx.Laptops.FirstOrDefault(p => p.LaptopID == id);
        }

        public override void Update(Laptop item)
        {
            var old = Read(item.LaptopID);

            foreach (var property in typeof(Laptop).GetProperties())
            {
                if (property.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                    property.SetValue(old, property.GetValue(item));
            }

            ctx.SaveChanges();
        }
    }
}
