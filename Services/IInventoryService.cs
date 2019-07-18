using FabricManagerApiNetCore.Contracts;
using FabricManagerApiNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricManagerApiNetCore.Services
{
    /// <summary>
    /// Inventory Service Interface.
    /// </summary>
    public interface IInventoryService
    {
        /// <summary>
        /// Get inventory levels for fabrics.
        /// </summary>
        /// <returns>list of Fabrics to be reorder.</returns>
        Task<List<Fabric>> InventoryLevels();

        /// <summary>
        /// Process PO and change inventory levels.
        /// </summary>
        /// <returns>True/False when processed.</returns>
        Task<bool> PurchaseOrder(Po po);

        /// <summary>
        /// Process a SO and change inventory levels.
        /// </summary>
        /// <returns>True/False when processed.</returns>
        Task<bool> SalesOrder(So so);
    }
}
