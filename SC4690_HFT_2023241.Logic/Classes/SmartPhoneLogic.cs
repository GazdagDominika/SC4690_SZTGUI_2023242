using SC4690_HFT_2023241.Logic.Interfaces;
using SC4690_HFT_2023241.Models;
using SC4690_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC4690_HFT_2023241.Logic.Classes
{
    public class SmartPhoneLogic: ISmartPhoneLogic
    {
        IRepository<SmartPhone> repository_;

        public SmartPhoneLogic(IRepository<SmartPhone> repo)
        {
            this.repository_ = repo;
        }

        public void Create(SmartPhone item)
        {
            if (item.PhoneID <= 0)
            {
                throw new ArgumentException("This phone should have an ID which greater than 0!");
            }
            else if (item.Price < 0)
            {
                throw new ArgumentException("This phone must have a price!");
            }
            else if (item.PhoneName == "" || item.PhoneName == null)
            {
                throw new ArgumentException("This phone must have a name! ");

            }
            else if (item.Size <= 0)
            {
                throw new ArgumentException("This phone must have a size!");
            }
            else if (item.Colour == "" || item.Colour == null)
            {
                throw new ArgumentException("This phone must have a colour! ");

            }



            this.repository_.Create(item);
        }

        public void Delete(int id)
        {
            this.repository_.Delete(id);
        }

        public SmartPhone Read(int id)
        {
            if (repository_.Read(id) != null)
            {
                return this.repository_.Read(id);
            }
            throw new ArgumentException("This phone doesn't exist with this ID!");
        }

        public IQueryable<SmartPhone> ReadAll()
        {
            return this.repository_.ReadAll();
        }

        public void Update(SmartPhone item)
        {
            if (repository_.Read(item.PhoneID) != null)
            {
                this.repository_.Update(item);
            }
            else
            {
                throw new ArgumentException("This phone doesn't exist with this ID!");
            }
        }

        public IEnumerable<object> GoldSmartPhones()
        {
            var phones = repository_.ReadAll();

            var goldenSmartPhones = from x in phones
                                    where x.Colour == "gold"
                                    select new
                                    {
                                        PhoneName = x.PhoneName,
                                        Price = x.Price,
                                        Colour = x.Colour
                                    };

            return goldenSmartPhones;
        }
    }
}
