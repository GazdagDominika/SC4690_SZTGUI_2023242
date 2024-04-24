using System;
using SC4690_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;


namespace SC4690_HFT_2023241.Repository.Databases
{
    public class SmartDevicesDbContext : DbContext
    {
        public DbSet<Owner> Users { get; set; }

        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<SmartPhone> SmartPhones { get; set; }
        public DbSet<Tablet> Tablets { get; set; }


        public SmartDevicesDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("SmartDevices");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Laptop>()
                .HasOne(p => p.MyUser)
                .WithMany(p => p.Laptops)
                .HasForeignKey(p => p.OwnerID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SmartPhone>()
                .HasOne(p => p.MyUser)
                .WithMany(p => p.SmartPhones)
                .HasForeignKey(p => p.OwnerID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tablet>()
                .HasOne(p => p.MyUser)
                .WithMany(p => p.Tablets)
                .HasForeignKey(p => p.OwnerID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Laptop>().HasData(new Laptop[]
            {
                new Laptop("1*LenovoIdeapad*310000*17*black*1"),
                new Laptop("2*Dell*240000*15*white*1"),
                new Laptop("3*AsusThinkpad*290000*16*rosegold*2"),
                new Laptop("4*MacBookAir*350000*14*white*3"),
                new Laptop("5*Toshiba*210000*15*grey*4")
            });

            modelBuilder.Entity<SmartPhone>().HasData(new SmartPhone[]
            {
                new SmartPhone("1*XiaomiRedmi10*140000*6*blue*1"),
                new SmartPhone("2*SamsungGalaxy20*420000*7*gold*2"),
                new SmartPhone("3*Iphone7*200000*5*white*3"),
                new SmartPhone("4*Huaweip50pro*230000*6*black*3"),
                new SmartPhone("5*LGshit*120000*4*black*5")
            });

            modelBuilder.Entity<Tablet>().HasData(new Tablet[]
            {
                new Tablet("1*AppleIpadAir*350000*14*gold*1"),
                new Tablet("2*AmazonFire*200000*10*white*2"),
                new Tablet("3*MicrosoftSurface*280000*12*black*3"),
                new Tablet("4*AliexpressShit*100000*10*white*4"),
                new Tablet("5*OnePlusPad*230000*12*rosegold*5")
            });

            modelBuilder.Entity<Owner>().HasData(new Owner[]
            {
                new Owner("1*Hal Koni*22*06702215544*250000"),
                new Owner("2*Double Domi*21*06205387966*460000"),
                new Owner("3*Zsizsikesabuza*20*06208759876*300000"),
                new Owner("4*Tolnai Gergo*25*06301234321*180000"),
                new Owner("5*Gazdag Imre*41*06205675432*100000")
            });
        }

    }
}
