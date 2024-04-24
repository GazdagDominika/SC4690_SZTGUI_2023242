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
    public class OwnerLogic : IOwnerLogic
    {

        IRepository<Owner> repository_;

        public OwnerLogic(IRepository<Owner> repo)
        {
            this.repository_ = repo;
        }

        public void Create(Owner item)
        {
            if (item.OwnerID <= 0)
            {
                throw new ArgumentException("The owner should have an ID which greater than 0!");
            }
            else if (item.Age < 0 || item.Age > 100 )
            {
                throw new ArgumentException("The owner can't be younger than 0 or older than 100!");
            }
            else if (item.Salary < 0)
            {
                throw new ArgumentException("The owner must have a small amount of money! ");
            }
            else if(item.Name == "" || item.Name == null)
            {
                throw new ArgumentException("The owner must have a name! ");

            }

            this.repository_.Create(item);
        }

        public void Delete(int id)
        {
            this.repository_.Delete(id);   
        }

        public Owner Read(int id)
        {
            if (repository_.Read(id) != null)
            {
                return this.repository_.Read(id);
            }
            throw new ArgumentException("The owner doesn't exist with this ID!");
        }

        public IQueryable<Owner> ReadAll()
        {
            return this.repository_.ReadAll();
        }

        public void Update(Owner item)
        {
            if (repository_.Read(item.OwnerID) != null)
            {
                this.repository_.Update(item);
            }
            else
            {
                throw new ArgumentException("The owner doesn't exist with this ID!");
            }
        }

        //NON-CRUD methods
        public int LaptopCount(int id)
        {
            if (repository_.Read(id) != null)
            {
                return this.repository_.Read(id).Laptops.Count();
            }
            throw new ArgumentException("User with this ID doesn't exist!");
        }


        public int PhoneSumPrice(int id)
        {
            if (repository_.Read(id) != null)
            {
                return this.repository_.Read(id).SmartPhones.Sum(p => p.Price);
            }
            throw new ArgumentException("User with this ID doesn't exist!");
        }

        public bool RosegoldTablet(int id)
        {
            if (repository_.Read(id) != null)
            {
                var tablets = this.repository_.Read(id).Tablets;
                if (tablets.Count != 0)
                {
                    foreach (var tablet in tablets)
                    {
                        if (tablet.Colour == "rosegold")
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            throw new ArgumentException("User with this ID doesn't exist!");

        }

        public bool HugePhone(int id)
        {
            if (repository_.Read(id) != null)
            {
                var phones = this.repository_.Read(id).SmartPhones;
                if (phones.Count != 0)
                {
                    foreach (var phone in phones)
                    {
                        if (phone.Size >= 6)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            throw new ArgumentException("User with this ID doesn't exist!");

        }

        public double AllDevicePrice(int id)
        {
            if (repository_.Read(id) != null)
            {
                var tablets = this.repository_.Read(id).Tablets;
                var phones = this.repository_.Read(id).SmartPhones;
                var laptops = this.repository_.Read(id).Laptops;

                double tabletsPrice = tablets.Sum(p => p.Price);
                double phonesPrice = phones.Sum(p => p.Price);
                double laptopsPrice = laptops.Sum(p => p.Price);

                return tabletsPrice + laptopsPrice + phonesPrice;
            }
            throw new ArgumentException("User with this ID doesn't exist!");
        }


        public bool AppleUser(int id)
        {
            if (repository_.Read(id) != null)
            {
                var tablets = this.repository_.Read(id).Tablets;
                var phones = this.repository_.Read(id).SmartPhones;
                var laptops = this.repository_.Read(id).Laptops;

                bool appleTablet = false;
                bool appleLaptop = false;
                bool applePhone = false;

                foreach ( var tablet in tablets )
                {
                    if (tablet.TabletName.Contains("Apple"))
                    {
                        appleTablet = true;
                    }
                    else
                    {
                        appleTablet = false;

                    }


                }

                foreach ( var phone in phones )
                {
                    if (phone.PhoneName.Contains("Iphone"))
                    {
                        applePhone = true;
                    }
                    else
                    {
                        applePhone = false;

                    }

                }

                foreach (var laptop in laptops)
                {
                    if (laptop.LaptopName.Contains("Mac"))
                    {
                        appleLaptop = true;
                    }
                    else
                    {
                        appleLaptop = false;

                    }

                }

                if (appleLaptop || applePhone || appleTablet == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            throw new ArgumentException("User with this ID doesn't exist!");
        }

        public IEnumerable<object> YoungRitchOwners()
        {
            var youngowners = repository_.ReadAll().Where(x => x.Age < 25 && x.Salary > 300000);
            return youngowners;
        }
    }
}
