using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricManagerApiNetCore.Models
{
    /// <summary>
    /// Fabric Class Model.
    /// </summary>
    public class Fabric
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
        /// Gets or Sets Fabric Description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or Sets Price of the fabric.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or Sets Active flag for fabric.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or Sets Product category.
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Gets or Sets Fabric imgUrl (auto generated on creation).
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// Gets or Sets Amount of fabric currently available.
        /// </summary>
        public int Inventory { get; set; }
    }
}
