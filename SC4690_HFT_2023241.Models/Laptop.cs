using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SC4690_HFT_2023241.Models
{
    public class Laptop
    {
        [StringLength(20)]
        public string LaptopName { get; set; }

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  LaptopID{ get; set; }

        [Required]
        [ForeignKey(nameof(Owner))]
        public int OwnerID { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int DisplaySize { get; set; }

        [Required]
        [StringLength(20)]
        public string Colour { get; set; }

        [JsonIgnore]
        public virtual Owner MyUser { get; set; }

        public Laptop()
        {
            
        }

        public Laptop(string dataline)
        {
            string[] datas = dataline.Split('*');
            LaptopID = int.Parse(datas[0]);
            LaptopName = datas[1];
            Price = int.Parse(datas[2]);
            DisplaySize = int.Parse(datas[3]);
            Colour = datas[4];
            OwnerID = int.Parse(datas[5]);
        }
    }
}
