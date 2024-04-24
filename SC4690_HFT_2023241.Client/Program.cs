using System;
using SC4690_HFT_2023241.Models;
using System.Linq;
using ConsoleTools;
using System.Collections.Generic;
using System.Numerics;
using SC4690_HFT_2023241.Client.Classes;

namespace SC4690_HFT_2023241.Client
{
    internal class Program
    {

        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Owner")
            {
                Console.Write("Enter owner id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter owner name: ");
                string name = Console.ReadLine();
                Console.Write("Enter owner age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Enter owner phone number: ");
                string pnumber = (Console.ReadLine());
                Console.Write("Enter owner salary: ");
                int salary = int.Parse(Console.ReadLine());
                rest.Post(new Owner {  OwnerID = id,Name = name, Age = age, PhoneNumber = pnumber,Salary = salary }, "Owner");
            }
            else if(entity == "Laptop")
            {
                Console.Write("Enter laptop id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter laptop name: ");
                string name = Console.ReadLine();
                Console.Write("Enter laptop price ");
                int price = int.Parse(Console.ReadLine());
                Console.Write("Enter laptop displaysize: ");
                int dsize = int.Parse(Console.ReadLine());
                Console.Write("Enter laptop colour: ");
                string colour = Console.ReadLine();
                rest.Post(new Laptop { LaptopID = id,LaptopName = name, Price = price, DisplaySize = dsize, Colour = colour }, "laptop");
            }
            else if (entity == "SmartPhone")
            {
                Console.Write("Enter phone id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter phone name: ");
                string name = Console.ReadLine();
                Console.Write("Enter phone price ");
                int price = int.Parse(Console.ReadLine());
                Console.Write("Enter phone size: ");
                int size = int.Parse(Console.ReadLine());
                Console.Write("Enter phone colour: ");
                string colour = Console.ReadLine();
                rest.Post(new SmartPhone { PhoneID = id,PhoneName = name, Price = price, Size = size, Colour = colour }, "phone");
            }
            else
            {
                Console.Write("Enter tablet id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter tablet name: ");
                string name = Console.ReadLine();
                Console.Write("Enter tablet price ");
                int price = int.Parse(Console.ReadLine());
                Console.Write("Enter tablet size: ");
                int size = int.Parse(Console.ReadLine());
                Console.Write("Enter tablet colour: ");
                string colour = Console.ReadLine();
                rest.Post(new Tablet { TabletID = id,TabletName = name, Price = price, Size = size, Colour = colour }, "tablet");
            }
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Owner")
            {
                List<Owner> owners = rest.Get<Owner>("Owner");

                foreach (var owner in owners)
                {
                    Console.WriteLine( owner.OwnerID +": "+ owner.Name + "--" +owner.Age + "--" + owner.Salary+"Ft");
                }
                Console.ReadLine();
            }
            else if (entity == "Laptop")
            {
                List<Laptop> laptops = rest.Get<Laptop>("Laptop");

                foreach (var laptop in laptops)
                {
                    Console.WriteLine(laptop.LaptopID + ":" + laptop.LaptopName + "--" + laptop.Price + "Ft--" + laptop.DisplaySize + "inch--" + laptop.Colour);
                }
                Console.ReadLine();
            }
            else if (entity == "SmartPhone")
            {
                List<SmartPhone> phones = rest.Get<SmartPhone>("SmartPhone");

                foreach (var phone in phones)
                {
                    Console.WriteLine(phone.PhoneID + ":"+ phone.PhoneName+"--"+phone.Price+"Ft--"+phone.Size+"inch--"+phone.Colour);
                }
                Console.ReadLine();
            }
            else if (entity == "Tablet")
            {
                List<Tablet> tablets = rest.Get<Tablet>("Tablet");

                foreach (var tablet in tablets)
                {
                    Console.WriteLine(tablet.TabletID+ ": "+ tablet.TabletName+"--"+tablet.Price+"Ft--"+tablet.Size+"inch--"+tablet.Colour);
                }
                Console.ReadLine();
            }

        }
        static void Update(string entity)
        {
            if (entity == "Owner")
            {
                Console.Write("Enter owner's id to update: ");

                int id = int.Parse(Console.ReadLine());

                Owner owner = rest.Get<Owner>(id, "Owner");
                Console.Write($"New name: [old:{owner.Name}]: ");
                string name = Console.ReadLine();
                owner.Name = name;
                Console.Write($"New age: [old:{owner.Age}]: ");
                owner.Age = Convert.ToInt32(Console.ReadLine());

                Console.Write($"New phone number: [old:{owner.PhoneNumber}]: ");
                owner.PhoneNumber = Console.ReadLine();

                Console.Write($"New salary: [old:{owner.Salary}]: ");
                owner.Salary = Convert.ToInt32(Console.ReadLine());

                rest.Put(owner,"Owner");
            }
            else if (entity == "Laptop")
            {
                Console.Write("Enter laptop's id to update: ");

                int id = int.Parse(Console.ReadLine());

                Laptop laptop = rest.Get<Laptop>(id, "Laptop");
                Console.Write($"New name: [old:{laptop.LaptopName}]: ");

                string name = Console.ReadLine();
                laptop.LaptopName = name;

                Console.Write($"New ownerID: [old:{laptop.OwnerID}]: ");
                laptop.OwnerID = Convert.ToInt32(Console.ReadLine());

                Console.Write($"New price: [old:{laptop.Price}]: ");
                laptop.Price = Convert.ToInt32(Console.ReadLine());

                Console.Write($"New display size: [old:{laptop.DisplaySize}]: ");
                laptop.DisplaySize = Convert.ToInt32(Console.ReadLine());

                Console.Write($"New color: [old:{laptop.Colour}]: ");
                laptop.Colour = Console.ReadLine();
                rest.Put(laptop, "Laptop");
            }
            else if (entity == "SmartPhone")
            {
                Console.Write("Enter phone's id to update: ");

                int id = int.Parse(Console.ReadLine());

                SmartPhone phone = rest.Get<SmartPhone>(id, "SmartPhone");
                Console.Write($"New name: [old:{phone.PhoneName}]:");
                string name = Console.ReadLine();
                phone.PhoneName = name;

                Console.Write($"New ownerID: [old:{phone.OwnerID}]: ");
                phone.OwnerID = Convert.ToInt32(Console.ReadLine());

                Console.Write($"New price: [old:{phone.Price}]");
                phone.Price = Convert.ToInt32(Console.ReadLine());

                Console.Write($"New size: [old:{phone.Size}]: ");
                phone.Size = Convert.ToInt32(Console.ReadLine());

                Console.Write($"New color: [old:{phone.Colour}]: ");
                phone.Colour = Console.ReadLine();

                rest.Put(phone, "SmartPhone");
            }
            else
            {
                Console.Write("Enter tablet's id to update: ");

                int id = int.Parse(Console.ReadLine());

                Tablet tablet = rest.Get<Tablet>(id, "Tablet");
                Console.Write($"New name: [old:{tablet.TabletName}]:");

                string name = Console.ReadLine();
                tablet.TabletName = name;

                Console.Write($"New ownerID: [old:{tablet.OwnerID}]: ");
                tablet.OwnerID = Convert.ToInt32(Console.ReadLine());

                Console.Write($"New price: [old:{tablet.Price}]: ");
                tablet.Price = Convert.ToInt32(Console.ReadLine());

                Console.Write($"New size: [old:{tablet.Size}]: ");
                tablet.Size = Convert.ToInt32(Console.ReadLine());

                Console.Write($"New color: [old:{tablet.Colour}]: ");
                tablet.Colour = Console.ReadLine();

                rest.Put(tablet, "Tablet");
            }
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            if (entity == "Owner")
            {
                Console.Write("Enter owner's id to delete: ");

                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Owner");
            }
            else if (entity == "Laptop")
            {
                Console.Write("Enter laptop's id to delete: ");

                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Laptop");
            }
            else if (entity == "SmartPhone")
            {
                Console.Write("Enter phone's id to delete: ");

                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "SmartPhone");
            }
            else
            {
                Console.Write("Enter tablet's id to delete: ");

                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Tablet");
            }
            Console.ReadLine();
        }

        static void LPcount()
        {
            Console.Write("Owner' id: ");
            int id = int.Parse(Console.ReadLine());
            var lpcount = rest.Get<int>(id, "DeviceStat/LaptopCount");
            Console.WriteLine("Laptops count: "+lpcount);
            Console.ReadLine();
        }

        static void PSprice()
        {
            Console.Write("Owner' id: ");
            int id = int.Parse(Console.ReadLine());
            var psprice = rest.Get<int>(id, "DeviceStat/PhoneSumPrice");
            Console.WriteLine("Phones price: "+psprice);
            Console.ReadLine();
        }

        static void RGtablet()
        {
            Console.Write("Owner' id: ");
            int id = int.Parse(Console.ReadLine());
            var rgtablet = rest.Get<bool>(id, "DeviceStat/RosegoldTablet");
            Console.WriteLine("Has rosegold tablet: " + rgtablet);
            Console.ReadLine();
        }

        static void HugePhone()
        {
            Console.Write("Owner' id: ");
            int id = int.Parse(Console.ReadLine());
            var hugephone = rest.Get<bool>(id, "DeviceStat/HugePhone");
            Console.WriteLine("Has huge phone: "+hugephone);
            Console.ReadLine();
        }

        static void ADprice()
        {
            Console.Write("Owner' id: ");
            int id = int.Parse(Console.ReadLine());
            var adprice = rest.Get<double>(id, "DeviceStat/AllDevicePrice");
            Console.WriteLine("All devices price: "+adprice);
            Console.ReadLine();
        }

        static void AppleU()
        {
            Console.Write("Owner' id: ");
            int id = int.Parse(Console.ReadLine());
            var appleu = rest.Get<bool>(id, "DeviceStat/AppleUser");
            Console.WriteLine("Apple user: " + appleu);
            Console.ReadLine();
        }

        static void YoungRitchOwners()
        {
            var owners = rest.GetSingle<List<Owner>>("DeviceStat/YoungRitchOwners");

            foreach (var owner in owners)
            {
                Console.WriteLine($"YoungRitchOwners: {owner.Name},\t {owner.Age},\t {owner.Salary}");
            }

            Console.ReadLine();
        }

        static void GoldSmartPhones()
        {
            var phones = rest.GetSingle<List<GoldPhoneClass>>("DeviceStat/GoldSmartPhones");

            foreach (var phone in phones)
            {
                Console.WriteLine($"GoldSmartPhones: {phone.PhoneName},\t {phone.Price},\t {phone.Colour}");
            }
            Console.ReadLine();
        }

        static void TabletsSize()
        {
            var tablets = rest.GetSingle<List<TabletSizeClass>>("DeviceStat/TabletsSize");

            foreach (var tablet in tablets)
            {
                Console.WriteLine($"TabletsSize: {tablet.Size},\t {tablet.AVGprice},\t {tablet.Count}");
            }

            Console.ReadLine();

        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:25418/", "laptop");
            
            
            var ownerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Owner"))
                .Add("Create", () => Create("Owner"))
                .Add("Delete", () => Delete("Owner"))
                .Add("Update", () => Update("Owner"))
                .Add("LaptopCount", () => LPcount())
                .Add("PhoneSumPrice", () => PSprice())
                .Add("RosegoldTablet", () => RGtablet())
                .Add("HugePhone", () => HugePhone())
                .Add("AllDevicePrice", () => ADprice())
                .Add("AppleUser", () => AppleU())
                .Add("YoungRitchOwners", () => YoungRitchOwners())
                .Add("Exit", ConsoleMenu.Close);

            var laptopSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Laptop"))
                .Add("Create", () => Create("Laptop"))
                .Add("Delete", () => Delete("Laptop"))
                .Add("Update", () => Update("Laptop"))
                .Add("Exit", ConsoleMenu.Close);

            var smartphoneSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("SmartPhone"))
                .Add("Create", () => Create("SmartPhone"))
                .Add("Delete", () => Delete("SmartPhone"))
                .Add("Update", () => Update("SmartPhone"))
                .Add("GoldSmartPhones", () => GoldSmartPhones())
                .Add("Exit", ConsoleMenu.Close);

            var tabletSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Tablet"))
                .Add("Create", () => Create("Tablet"))
                .Add("Delete", () => Delete("Tablet"))
                .Add("Update", () => Update("Tablet"))
                .Add("TabletsSize", () => TabletsSize())
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Owners", () => ownerSubMenu.Show())
                .Add("Laptops", () => laptopSubMenu.Show())
                .Add("SmartPhone", () => smartphoneSubMenu.Show())
                .Add("Tablets", () => tabletSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            
            menu.Show();


            

        }
    }
}
