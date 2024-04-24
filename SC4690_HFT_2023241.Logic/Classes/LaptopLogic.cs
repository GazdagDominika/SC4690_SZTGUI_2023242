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
    public class LaptopLogic: ILaptopLogic
    {
        IRepository<Laptop> repository_;

        public LaptopLogic(IRepository<Laptop> repo)
        {
            this.repository_ = repo;
        }

        public void Create(Laptop item)
        {
            if (item.LaptopID<= 0)
            {
                throw new ArgumentException("This laptop should have an ID which greater than 0!");
            }
            else if (item.Price < 0)
            {
                throw new ArgumentException("This laptop must have a price!");
            }
            else if (item.LaptopName == "" || item.LaptopName == null)
            {
                throw new ArgumentException("This laptop must have a name! ");

            }
            else if (item.DisplaySize <= 0)
            {
                throw new ArgumentException("This laptop must have a display size!");
            }
            else if (item.Colour == "" || item.Colour == null)
            {
                throw new ArgumentException("This laptop must have a colour! ");

            }
            this.repository_.Create(item);
        }

        public void Delete(int id)
        {
            this.repository_.Delete(id);
        }

        public Laptop Read(int id)
        {
            if (repository_.Read(id) != null)
            {
                return this.repository_.Read(id);
            }
            throw new ArgumentException("This laptop doesn't exist with this ID!");
        }

        public IQueryable<Laptop> ReadAll()
        {
            return this.repository_.ReadAll();
        }

        public void Update(Laptop item)
        {
            if (repository_.Read(item.LaptopID) != null)
            {
                this.repository_.Update(item);
            }
            else
            {
                throw new ArgumentException("This laptop doesn't exist with this ID!");
            }
        }
    }
}
