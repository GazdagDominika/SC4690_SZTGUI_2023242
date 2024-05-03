using Microsoft.AspNetCore.Mvc;
using SC4690_HFT_2023241.Logic.Interfaces;
using SC4690_HFT_2023241.Models;
using System.Collections.Generic;
using static SC4690_HFT_2023241.Logic.Classes.TabletLogic;


namespace SC4690_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DeviceStatController : ControllerBase
    {
        IOwnerLogic logic;
        ISmartPhoneLogic phoneLogic;
        ITabletLogic tabletLogic;

        public DeviceStatController(IOwnerLogic logic, ISmartPhoneLogic phoneLogic, ITabletLogic tabletLogic)
        {
            this.logic = logic;
            this.phoneLogic = phoneLogic;
            this.tabletLogic = tabletLogic;
        }


        [HttpGet("{id}")]
        public int LaptopCount(int id)
        {
            return logic.LaptopCount(id);
        }

        [HttpGet("{id}")]
        public int PhoneSumPrice(int id)
        {
            return logic.PhoneSumPrice(id);
        }

        [HttpGet("{id}")]
        public bool RosegoldTablet(int id)
        {
            return logic.RosegoldTablet(id);
        }

        [HttpGet("{id}")]
        public bool HugePhone(int id)
        {
            return logic.HugePhone(id);
        }

        [HttpGet("{id}")]
        public double AllDevicePrice(int id)
        {
            return logic.AllDevicePrice(id);
        }

        [HttpGet("{id}")]
        public bool AppleUser(int id)
        {
            return logic.AppleUser(id);
        }

        [HttpGet]
        public IEnumerable<object> YoungRitchOwners()
        {
            return logic.YoungRitchOwners();
        }

        [HttpGet]
        public IEnumerable<object> GoldSmartPhones()
        {
            return phoneLogic.GoldSmartPhones();
        }

        [HttpGet]
        public IEnumerable<object> TabletsSize()
        {
            return tabletLogic.TabletsSize();
        }
    }
}
