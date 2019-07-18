using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricManagerApiNetCore.Contracts
{
    /// <summary>
    /// Sales Order Class.
    /// </summary>
    public class So
    {
        /// <summary>
        /// Gets or Sets Unique identifier for fabric.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Quantity to be removed from inventory.
        /// </summary>
        public int Qty { get; set; }
    }
}
