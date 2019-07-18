using FabricManagerApiNetCore.Contracts;
using FabricManagerApiNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricManagerApiNetCore.Repositories
{
    /// <summary>
    /// Inventory Repository Interface.
    /// </summary>
    public interface IInventoryRepository
    {
        /// <summary>
        /// Get inventory levels for fabrics.
        /// </summary>
        /// <returns>list of Fabrics to be reorder.</returns>
        Task<List<Fabric>> InventoryLevels();

        /// <summary>
        /// Process PO and change inventory levels.
        /// </summary>
        /// <param name="po">Purchase Order</param>
        /// <returns>True/False when processed.</returns>
        Task<bool> PurchaseOrder(Po po);

        /// <summary>
        /// Process a SO and change inventory levels.
        /// </summary>
        /// <returns>True/False when processed.</returns>
        Task<bool> SalesOrder(So so);
    }
}
