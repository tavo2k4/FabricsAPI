using FabricManagerApiNetCore.Contracts;
using FabricManagerApiNetCore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FabricManagerApiNetCore.Repositories
{
    /// <summary>
    /// Fabric Repository Class.
    /// </summary>
    public class FabricRepository: IFabricRepository
    {
        private readonly DbJsonContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryRepository"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public FabricRepository(DbJsonContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get a Fabric by Id.
        /// </summary>
        /// <param name="Id">Fabric Id.</param>
        /// <returns>Singel Fabric.</returns>
        public async Task<Fabric> GetFabric(int id)
        {
            var rs = await this.context.ReadFabricsDb();

            var fabric = rs.Fabrics
                .Where(fab => fab.Id == id)
                .SingleOrDefault();

            return fabric;
        }

        /// <summary>
        /// Get List of Fabrics.
        /// </summary>
        /// <returns>List of Fabrics.</returns>
        public async Task<ListOfFabrics> GetListOfFabrics()
        {
            return await this.context.ReadFabricsDb();
        }

        /// <summary>
        /// Add a New Fabric.
        /// </summary>
        /// <param name="fabric">Fabric object to add.</param>
        /// <returns>New Fabric Added.</returns>
        public async Task<int> AddFabric(FabricAddRequest fabric)
        {
            var rs = await this.context.ReadFabricsDb();

            var id = rs.Fabrics.Max(fab => fab.Id) + 1;

            var newFabric = new Fabric
            {
                Id = id,
                Sku = fabric.Sku,
                Description = fabric.Description,
                Price = 100.50M,
                Active = true,
                Category = fabric.Category,
                ImgUrl = $"https://jhilburn.com/imageserver.ashx?w=100&h=100&s={fabric.Sku}&n=swatch.jpg",
                Inventory = 0
            };

            rs.Fabrics.Add(newFabric);

            await this.context.WriteFabricsDb(rs);

            return id;
        }

        /// <summary>
        /// Update Fabric.
        /// </summary>
        /// <param name="fabric">Fabric object to update.</param>
        /// <returns>Updated Fabric.</returns>
        public async Task<int> UpdateFabric(Fabric fabric)
        {
            var rs = await this.context.ReadFabricsDb();

            var fab = rs.Fabrics.FirstOrDefault(f => f.Id == fabric.Id);

            rs.Fabrics[rs.Fabrics.IndexOf(fab)] = fabric;

            await this.context.WriteFabricsDb(rs);

            return fabric.Id;
        }

        /// <summary>
        /// Delete Fabric by Id.
        /// </summary>
        /// <param name="id">Fabric Id.</param>
        /// <returns>True/False.</returns>
        public async Task<bool> DeleteFabric(int id)
        {
            var rs = await this.context.ReadFabricsDb();

            var fabric = rs.Fabrics.RemoveAll(fab => fab.Id == id);

            if (fabric == 0)
            {
                return false;
            }

            await this.context.WriteFabricsDb(rs);

            return true;
        }

        /// <summary>
        /// Search Fabric by key word.
        /// </summary>
        /// <param name="keyWord">Key Word.</param>
        /// <returns>List of Fabrics</returns>
        public async Task<IEnumerable<Fabric>> SearchFabric(string keyWord)
        {
            var rs = await this.context.ReadFabricsDb();

            var searchList = rs.Fabrics
                .Where(x => x.Description.ToUpper().Contains(keyWord.ToUpper()) || x.Category.ToUpper().Contains(keyWord.ToUpper()));

            return searchList;
        }
    }
}
