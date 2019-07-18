using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricManagerApiNetCore.Contracts
{
    /// <summary>
    /// PO class.
    /// </summary>
    public class Po
    {
        /// <summary>
        /// Gets or Sets Unique identifier for fabric.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Fabric SKU.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or Sets Quantity to be added to inventory.
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// Gets or Sets New Price of the fabric.
        /// </summary>
        public decimal NewPrice { get; set; }

    }
}
