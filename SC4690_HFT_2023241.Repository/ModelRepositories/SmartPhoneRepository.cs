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
    public class SmartPhoneRepository : Repository<SmartPhone>, IRepository<SmartPhone>
    {
        public SmartPhoneRepository(SmartDevicesDbContext ctx) : base(ctx)
        { }

        public override SmartPhone Read(int id)
        {
            return ctx.SmartPhones.FirstOrDefault(p => p.PhoneID == id);
        }

        public override void Update(SmartPhone item)
        {
            var old = Read(item.PhoneID);

            foreach (var prop in typeof(SmartPhone).GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                    prop.SetValue(old, prop.GetValue(item));
            }

            ctx.SaveChanges();
        }
    }
}
