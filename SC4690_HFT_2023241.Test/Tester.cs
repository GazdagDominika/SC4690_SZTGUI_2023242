using SC4690_HFT_2023241.Logic.Classes;
using SC4690_HFT_2023241.Models;
using SC4690_HFT_2023241.Repository.Interfaces;
using System.Linq;
using System;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;





namespace SC4690_HFT_2023241.Test
{
    [TestFixture]
    public class Tester 
    {
        OwnerLogic ologic;
        LaptopLogic llogic;
        SmartPhoneLogic slogic;
        TabletLogic tlogic;

        Mock<IRepository<Owner>> mockOwnerRepository;
        Mock<IRepository<Laptop>> mockLaptopRepository;
        Mock<IRepository<SmartPhone>> mockPhoneRepository;
        Mock<IRepository<Tablet>> mockTabletRepository;



        [SetUp]
        public void Init()
        {
            var laptop1 = new Laptop()
            { LaptopID = 1, LaptopName = "HPpro10", Price = 190000, DisplaySize = 15, Colour = "grey", OwnerID = 1};

            var phone1 = new SmartPhone()
            { PhoneID = 1, PhoneName = "LG300", Price = 120000, Size = 5, Colour = "black", OwnerID = 1 };

            var owner1 = new Owner()
            { OwnerID = 1, Name = "Hosszú Katinka", Age = 35, PhoneNumber = "06307895521", Salary = 500000 };

            owner1.Laptops.Add(laptop1);
            owner1.SmartPhones.Add(phone1);


            var laptop2 = new Laptop()
            { LaptopID = 2, LaptopName= "Acer Chromebook", Price = 260000, DisplaySize = 16, Colour = "white", OwnerID = 2 };

            var phone2 = new SmartPhone()
            { PhoneID = 2, PhoneName = "OPPOf5", Price = 170000, Size = 6, Colour = "pink" , OwnerID = 2 };

            var tablet1 = new Tablet()
            { TabletID = 1, TabletName = "Google Pixel", Price=190000, Size = 11, Colour = "gold", OwnerID= 2 };

            var owner2 = new Owner()
            { OwnerID = 2, Name = "Szénási Sanyó", Age = 39, PhoneNumber = "06703548576",Salary = 650000 };

            owner2.Laptops.Add(laptop2 );
            owner2.SmartPhones.Add(phone2);
            owner2.Tablets.Add(tablet1);


            var laptop3 = new Laptop()
            { LaptopID = 3, LaptopName = "HP Spectre", Price = 250000, DisplaySize = 17, Colour = "silver", OwnerID = 3 };

            var phone3 = new SmartPhone()
            { PhoneID = 3, PhoneName = "Motorola Razr", Price = 220000, Size = 7, Colour = "green", OwnerID = 3 };

            var phone4 = new SmartPhone()
            { PhoneID = 4, PhoneName = "VIVO S1", Price = 210000, Size = 6, Colour = "white", OwnerID = 3 };

            var tablet2 = new Tablet()
            { TabletID = 2, TabletName = "Lenovo Yoga", Price=300000, Size = 14, Colour = "rosegold", OwnerID=3 };

            var owner3 = new Owner()
            { OwnerID = 3, Name = "Kiss Dani", Age = 26, PhoneNumber = "06203546754", Salary = 460000 };

            owner3.Laptops.Add(laptop3);
            owner3.SmartPhones.Add(phone3);
            owner3.SmartPhones.Add(phone4);
            owner3.Tablets.Add(tablet2);

            

           var phone5 = new SmartPhone()
           { PhoneID = 5, PhoneName = "Nokia 8.1" , Price = 270000, Size = 7, Colour = "black", OwnerID = 4 };

            var tablet3 = new Tablet()
            { TabletID = 3, TabletName = "Xiaomi Redmi Pad 6", Price = 180000, Size = 13, Colour = "gold", OwnerID = 4 };

            var tablet4 = new Tablet()
            { TabletID = 4, TabletName = "HONOR Pad X8", Price = 310000, Size = 14, Colour = "black", OwnerID = 4 };

            var owner4 = new Owner()
            { OwnerID = 4, Name = "Egres Kata", Age = 24, PhoneNumber = "06308932176", Salary = 410000 };

            owner4.SmartPhones.Add(phone5);
            owner4.Tablets.Add(tablet3 );
            owner4.Tablets.Add(tablet4 );


            mockOwnerRepository = new Mock<IRepository<Owner>>();
            mockOwnerRepository.Setup(t => t.ReadAll()).Returns(new List<Owner>()
            { owner1, owner2, owner3, owner4 }.AsQueryable());
            mockOwnerRepository.Setup(t => t.Read(It.IsInRange(1, 4, Moq.Range.Inclusive))).Returns<int>((id) =>
            {
                if (id == 1)
                {
                    return owner1;
                }
                else if (id == 2)
                {
                    return owner2;
                }
                else if (id == 3)
                {
                    return owner3;
                }
                else
                {
                    return owner4;
                }
            });

            mockLaptopRepository = new Mock<IRepository<Laptop>>();

            mockPhoneRepository = new Mock<IRepository<SmartPhone>>();

            mockTabletRepository = new Mock<IRepository<Tablet>>();

             ologic = new OwnerLogic(mockOwnerRepository.Object);

             llogic= new LaptopLogic(mockLaptopRepository.Object);

             slogic = new SmartPhoneLogic(mockPhoneRepository.Object);

             tlogic = new TabletLogic(mockTabletRepository.Object);



        }

        [Test]
        public void LaptopCountTest()
        {
            var laptopctest = ologic.LaptopCount(1);
            Assert.AreEqual(laptopctest, 1);
        }

        [Test]
        public void PhoneSumPriceTest()
        {
            var psumpricetest = ologic.PhoneSumPrice(3);
            Assert.That(psumpricetest, Is.EqualTo(430000));
        }

        [Test]
        public void RosegoldTabletTest()
        {
            var rosegoldtablettest = ologic.RosegoldTablet(3);
            Assert.That(rosegoldtablettest, Is.EqualTo(true));
        }

        [Test]
        public void HugePhoneTest()
        {
            var hugephonetest = ologic.HugePhone(1);
            Assert.That(hugephonetest, Is.EqualTo(false));
        }

        [Test]
        public void AllDevicePriceTest()
        {
            var devicespricetest = ologic.AllDevicePrice(2);
            Assert.That(devicespricetest, Is.EqualTo(620000));
        }

        [Test]
        public void AppleUserTest()
        {
            var appleusertest = ologic.AppleUser(4);
            Assert.That(appleusertest, Is.EqualTo(false));
        }

        [Test]

        public void RightLaptopCreateTest()
        {
            Laptop laptop = new Laptop()
            { LaptopID = 4, LaptopName = "Lenovo Legion 7", Price = 340000, DisplaySize = 17, Colour = "black", OwnerID = 3};

            try
            {
                llogic.Create(laptop);
            }
            catch
            {

            }
            mockLaptopRepository.Verify(p => p.Create(laptop), Times.Once);
        }

        [Test]
        public void WrongPricePhoneCreateTest()
        {
            SmartPhone smartphone = new SmartPhone()
            { PhoneID = 6, PhoneName = "ChinaPhone", Price = -500, Size = 5, Colour = "white", OwnerID = 2 };

            try
            {
                slogic.Create(smartphone);
            }
            catch
            {

            }
            mockPhoneRepository.Verify(p =>p.Create(smartphone), Times.Never);
        }

        [Test]
        public void WrongNameOwnerCreateTest()
        {
            Owner owner = new Owner()
            { OwnerID = 5, Name = "", Age = 23, Salary = 230000 };

            try
            {
                ologic.Create(owner);
            }
            catch
            {

            }
            mockOwnerRepository.Verify(p => p.Create(owner), Times.Never);
        }

        [Test]
        public void RightTabletCreateTest()
        {
            Tablet tablet = new Tablet()
            { TabletID = 5, TabletName = "Alldocube Iplay", Price = 30000, Size = 9, Colour = "white", OwnerID = 1};

            try
            {
                tlogic.Create(tablet);
            }
            catch
            {

            }

            mockTabletRepository.Verify(p => p.Create(tablet), Times.Once);
        }


        [Test]
        public void WrongAgeOwnerCreateTest()
        {
            Owner owner = new Owner()
            { OwnerID = 6, Name = "Kovács András", Age = 110, PhoneNumber= "06701119876" , Salary = 400000 };

            try
            {
                ologic.Create(owner);
            }
            catch
            {

            }
            mockOwnerRepository.Verify(p => p.Create(owner),Times.Never);
        }

        [Test]
        public void RightPhoneCreateTest()
        {
            SmartPhone smartPhone = new SmartPhone()
            { PhoneID = 7, PhoneName = "ZTE XS", Price = 70000, Size = 5, Colour = "grey", OwnerID = 2 };

            try
            {
                slogic.Create(smartPhone);
            }
            catch
            {

            }
            mockPhoneRepository.Verify(p => p.Create(smartPhone), Times.Once);
        }


    }
}
