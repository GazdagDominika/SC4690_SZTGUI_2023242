using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SC4690_HFT_2023241.Endpoint.Services;
using SC4690_HFT_2023241.Logic.Interfaces;
using SC4690_HFT_2023241.Models;
using System.Collections.Generic;


namespace SC4690_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        IOwnerLogic logic;
        IHubContext<SignalRHub> hub;

        public OwnerController(IOwnerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
            
        }



        [HttpGet]
        public IEnumerable<Owner> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Owner Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Owner value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("OwnerCreated", value);

        }

        [HttpPut]
        public void Update( [FromBody] Owner value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("OwnerUpdated", value);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ownerToDelete = this.logic.Read(id);

            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("OwnerDeleted", ownerToDelete);
        }
    }
}
