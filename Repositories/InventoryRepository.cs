using FabricManagerApiNetCore.Contracts;
using FabricManagerApiNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricManagerApiNetCore.Repositories
{
    /// <summary>
    /// Inventory Repository Class.
    /// </summary>
    public class InventoryRepository: IInventoryRepository
    {
        private const int  MIN_LEVEL = 20;
        private readonly DbJsonContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryRepository"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public InventoryRepository(DbJsonContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get inventory levels for fabrics.
        /// </summary>
        /// <returns>list of Fabrics to be reorder.</returns>
        public async Task<List<Fabric>> InventoryLevels()
        {
            var rs = await this.context.ReadFabricsDb();

            var listOfFabrics = rs.Fabrics
                .Where(fab => fab.Inventory < MIN_LEVEL)
                .ToList();

            return listOfFabrics;
        }

        /// <summary>
        /// Process PO and change inventory levels.
        /// </summary>
        /// <returns>True/False when processed.</returns>
        public async Task<bool> PurchaseOrder(Po po)
        {
            var rs = await this.context.ReadFabricsDb();

            rs.Fabrics.Where(u => u.Id == po.Id).Select(x => { x.Inventory += po.Qty; return rs.Fabrics; }).ToList();

            await this.context.WriteFabricsDb(rs);

            return true;
        }

        /// <summary>
        /// Process a SO and change inventory levels.
        /// </summary>
        /// <returns>True/False when processed.</returns>
        public async Task<bool> SalesOrder(So so)
        {
            var rs = await this.context.ReadFabricsDb();

            rs.Fabrics.Where(u => u.Id == so.Id).Select(x => { x.Inventory -= so.Qty; return rs.Fabrics; }).ToList();

            await this.context.WriteFabricsDb(rs);

            return true;
        }
    }
}
