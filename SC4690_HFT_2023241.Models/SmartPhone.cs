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
    public class SmartPhone
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhoneID { get; set; }

        
        [StringLength(20)]
        public string PhoneName { get; set; }

        [Required]
        [ForeignKey(nameof(Owner))]
        public int OwnerID { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        [StringLength(20)]
        public string Colour { get; set; }

        [JsonIgnore]
        public virtual Owner MyUser { get; set; }

        public SmartPhone()
        {
            
        }

        public SmartPhone(string dataline)
        {
            string[] datas = dataline.Split('*');
            PhoneID = int.Parse(datas[0]);
            PhoneName = datas[1];
            Price = int.Parse(datas[2]);
            Size = int.Parse(datas[3]);
            Colour = datas[4];
            OwnerID = int.Parse(datas[5]);

        }
    }
}
