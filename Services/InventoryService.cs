using FabricManagerApiNetCore.Contracts;
using FabricManagerApiNetCore.Models;
using FabricManagerApiNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricManagerApiNetCore.Services
{
    /// <summary>
    /// Inventory Service Class.
    /// </summary>
    public class InventoryService: IInventoryService
    {
        private readonly IInventoryRepository inventoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// </summary>
        /// <param name="inventoryRepository">Inventory Repository.</param>
        public InventoryService(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        /// <summary>
        /// Get inventory levels for fabrics.
        /// </summary>
        /// <returns>list of Fabrics to be reorder.</returns>
        public async Task<List<Fabric>> InventoryLevels()
        {
            return await this.inventoryRepository.InventoryLevels();
        }

        /// <summary>
        /// Process PO and change inventory levels.
        /// </summary>
        /// <returns>True/False when processed.</returns>
        public async Task<bool> PurchaseOrder(Po po)
        {
            return await this.inventoryRepository.PurchaseOrder(po);
        }

        /// <summary>
        /// Process a SO and change inventory levels.
        /// </summary>
        /// <returns>True/False when processed.</returns>
        public async Task<bool> SalesOrder(So so)
        {
            return await this.inventoryRepository.SalesOrder(so);
        }
    }
}
