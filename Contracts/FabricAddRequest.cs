using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricManagerApiNetCore.Contracts
{
    public class FabricAddRequest
    {
        /// <summary>
        /// Gets or Sets Fabric SKU.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or Sets Fabric Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Product category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or Sets Price of the fabric.
        /// </summary>
        public decimal Price { get; set; }
    }
}
