using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricManagerApiNetCore.Contracts;
using FabricManagerApiNetCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FabricManagerApiNetCore.Controllers
{
    /// <summary>
    /// Inventory Controller Class.
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService inventoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryController"/> class.
        /// </summary>
        /// <param name="inventoryService">Inventory Service.</param>
        public InventoryController(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }

        /// <summary>
        /// Get low Inventory levels.
        /// </summary>
        /// <returns>List of fabrics to reorder</returns>
        [Route("lowinventory")]
        [HttpGet]
        public async Task<IActionResult> GetLowInventory()
        {
            var rs = await this.inventoryService.InventoryLevels();

            if(rs == null)
            {
                return NotFound();
            }

            return Ok(rs);
        }

        /// <summary>
        /// Process a PO to be posted to Inventoy.
        /// </summary>
        /// <returns></returns>
        [Route("purchase")]
        [HttpPost]
        public async Task<IActionResult> Po([FromBody] Po po)
        {
            var rs = await this.inventoryService.PurchaseOrder(po);

            return Ok(rs);
        }

        /// <summary>
        /// Process a SO and remove Inventory.
        /// </summary>
        /// <param name="so"></param>
        /// <returns></returns>
        [Route("salesorder")]
        [HttpPost]
        public async Task<IActionResult> So([FromBody] So so)
        {
            var rs = await this.inventoryService.SalesOrder(so);

            return Ok(rs);
        }
    }
}