using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SC4690_HFT_2023241.Models
{
    public class Tablet
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TabletID { get; set; }

        [StringLength(20)]
        public string TabletName { get; set; }

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


        public Tablet()
        {
            
        }

        public Tablet(string dataline)
        {
            string[] datas = dataline.Split('*');
            TabletID = int.Parse(datas[0]);
            TabletName = datas[1];
            Price = int.Parse(datas[2]);
            Size = int.Parse(datas[3]);
            Colour = datas[4];
            OwnerID = int.Parse(datas[5]);
        }
    }
}
