using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoalTestBTS.Models;
using SQLitePCL;

namespace SoalTestBTS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly ShoppingContext _context;

        public ShoppingController(ShoppingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Shopping> GetShoppedItem()
        {
            return _context.GetShoppedItem();
        }

        [HttpPost]
        public Shopping PostSoppedItem(Shopping shopppedItem)
        {
            return _context.StoreShoppedItem(shopppedItem.Name, shopppedItem.CreatedDate);
        }
    }
}
