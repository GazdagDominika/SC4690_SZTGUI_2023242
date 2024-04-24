using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC4690_HFT_2023241.Models
{
    public class Owner
    {
        [Required]
        [Range(0,100)]
        public int Age { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerID { get; set; }

        [Required]
        [Range(0,1000000)]
        public int Salary { get; set; }

        public virtual ICollection<Laptop> Laptops { get;}

        public virtual ICollection<Tablet> Tablets { get;}

        public virtual ICollection<SmartPhone> SmartPhones { get;}


        public Owner()
        {
            Laptops = new HashSet<Laptop>();
            Tablets = new HashSet<Tablet>();
            SmartPhones = new HashSet<SmartPhone>();
        }

        public Owner(string dataline)
        {
            string[] pieces = dataline.Split("*");
            OwnerID = int.Parse(pieces[0]);
            Name = pieces[1];
            Age = int.Parse(pieces[2]);
            PhoneNumber = pieces[3];
            Salary = int.Parse(pieces[4]);
            SmartPhones = new HashSet<SmartPhone>();
            Tablets = new HashSet<Tablet>();
            Laptops = new HashSet<Laptop>();

        }
    }
}
