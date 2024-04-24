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
    public class OwnerRepository : Repository<Owner>, IRepository<Owner>
    {
        public OwnerRepository(SmartDevicesDbContext ctx) : base(ctx)
        { }

        public override Owner Read(int id)
        {
            return ctx.Users.FirstOrDefault(p => p.OwnerID == id);
        }

        public override void Update(Owner item)
        {
            var old = Read(item.OwnerID);

            foreach (var property in typeof(Owner).GetProperties())
            {
                if (property.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                    property.SetValue(old, property.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
