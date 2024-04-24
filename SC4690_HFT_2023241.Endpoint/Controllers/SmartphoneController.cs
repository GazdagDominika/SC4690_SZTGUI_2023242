using Microsoft.AspNetCore.Mvc;
using SC4690_HFT_2023241.Logic.Interfaces;
using SC4690_HFT_2023241.Models;
using System.Collections.Generic;


namespace SC4690_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SmartphoneController : ControllerBase
    {

        ISmartPhoneLogic logic;

        public SmartphoneController(ISmartPhoneLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<SmartPhone> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public SmartPhone Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] SmartPhone value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] SmartPhone value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
