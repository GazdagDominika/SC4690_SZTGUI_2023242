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
    public class TabletRepository : Repository<Tablet>, IRepository<Tablet>
    {
        public TabletRepository(SmartDevicesDbContext ctx) : base(ctx)
        { }

        public override Tablet Read(int id)
        {
            return ctx.Tablets.FirstOrDefault(p => p.TabletID == id);
        }

        public override void Update(Tablet item)
        {
            var old = Read(item.TabletID);

            foreach (var property in typeof(Tablet).GetProperties())
            {
                if (property.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                    property.SetValue(old, property.GetValue(item));
            }

            ctx.SaveChanges();
        }
    }
}
