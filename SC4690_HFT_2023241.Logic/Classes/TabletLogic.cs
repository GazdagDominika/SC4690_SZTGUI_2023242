using SC4690_HFT_2023241.Logic.Interfaces;
using SC4690_HFT_2023241.Models;
using SC4690_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC4690_HFT_2023241.Logic.Classes
{
    public class TabletLogic: ITabletLogic
    {
        IRepository<Tablet> repository_;

        public TabletLogic(IRepository<Tablet> repo)
        {
            this.repository_ = repo;
        }

        public void Create(Tablet item)
        {
            if (item.TabletID <= 0)
            {
                throw new ArgumentException("This tablet should have an ID which greater than 0!");
            }
            else if (item.Price < 0)
            {
                throw new ArgumentException("This tablet must have a price!");
            }
            else if (item.TabletName == "" || item.TabletName == null)
            {
                throw new ArgumentException("This tablet must have a name! ");

            }
            else if (item.Size <= 0)
            {
                throw new ArgumentException("This tablet must have a display size!");
            }
            else if (item.Colour == "" || item.Colour == null)
            {
                throw new ArgumentException("This tablet must have a colour! ");

            }



            this.repository_.Create(item);
        }

        public void Delete(int id)
        {
            this.repository_.Delete(id);
        }

        public Tablet Read(int id)
        {
            if (repository_.Read(id) != null)
            {
                return this.repository_.Read(id);
            }
            throw new ArgumentException("This PC doesn't exist with this ID!");
        }

        public IQueryable<Tablet> ReadAll()
        {
            return this.repository_.ReadAll();
        }

        public void Update(Tablet item)
        {
            if (repository_.Read(item.TabletID) != null)
            {
                this.repository_.Update(item);
            }
            else
            {
                throw new ArgumentException("This tablet doesn't exist with this ID!");
            }
        }

        public IEnumerable<object> TabletsSize()
        {

            var datas = repository_.ReadAll();

            var tablets = from x in datas
                          group x by x.Size into g
                          select new
                          {
                              Size = g.Key,
                              AVGprice = g.Average(x => x.Price),
                              Count = g.Count()
                          };

            return tablets;

        }

       

    }
   
}
