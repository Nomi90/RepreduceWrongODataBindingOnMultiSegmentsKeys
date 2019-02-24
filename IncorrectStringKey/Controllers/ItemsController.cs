using IncorrectStringKey.Dto;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IncorrectStringKey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        IEnumerable<Item> _items = new Item[] {
                new Item() { Id="00000001",CompanyId="Company1",Description="description"},
                new Item() { Id="00000002",CompanyId="Company2",Description="description"},
                new Item() { Id="00000003",CompanyId="Company3",Description="description"},
                new Item() { Id="00000004",CompanyId="Company4",Description="description"},
            };
        // GET api/values
        [HttpGet]
        public IQueryable<Item> Get()
        {
            return _items.AsQueryable();
        }
        // GET /items(CompanyId='Company1',Id='00000001')
        public ActionResult<Item> Get([FromODataUri]string keyCompanyId, [FromODataUri]string keyId)
        {
            // The keyId is "1" not "00000001" as expectable
            Item item = _items.FirstOrDefault(itm => itm.Id == keyId && itm.CompanyId == keyCompanyId);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }  



    }
}
