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
    /// Fabric Service Class
    /// </summary>
    public class FabricsService: IFabricService
    {
        private readonly IFabricRepository fabricRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FabricsService"/> class.
        /// </summary>
        /// <param name="fabricService">Fabric Service.</param>
        public FabricsService(IFabricRepository fabricRepository)
        {
            this.fabricRepository = fabricRepository;
        }

        /// <summary>
        /// Get a Fabric by Id.
        /// </summary>
        /// <param name="Id">Fabric Id.</param>
        /// <returns>Singel Fabric.</returns>
        public async Task<Fabric> GetFabric(int id)
        {
            return await this.fabricRepository.GetFabric(id);
        }

        /// <summary>
        /// Get List of Fabrics.
        /// </summary>
        /// <returns>List of Fabrics.</returns>
        public async Task<ListOfFabrics> GetListOfFabrics()
        {
            return await this.fabricRepository.GetListOfFabrics();
        }

        /// <summary>
        /// Add a New Fabric.
        /// </summary>
        /// <param name="fabric">Fabric object to add.</param>
        /// <returns>New Fabric Added.</returns>
        public async Task<int> AddFabric(FabricAddRequest fabric)
        {
            return await this.fabricRepository.AddFabric(fabric);
        }

        /// <summary>
        /// Update Fabric.
        /// </summary>
        /// <param name="fabric">Fabric object to update.</param>
        /// <returns>Updated Fabric.</returns>
        public async Task<int> UpdateFabric(Fabric fabric)
        {
            return await this.fabricRepository.UpdateFabric(fabric);
        }

        /// <summary>
        /// Delete Fabric by Id.
        /// </summary>
        /// <param name="Id">Fabric Id.</param>
        /// <returns>True/False.</returns>
        public async Task<bool> DeleteFabric(int id)
        {
            return await this.fabricRepository.DeleteFabric(id);
        }

        /// <summary>
        /// Search Fabric by key word.
        /// </summary>
        /// <param name="keyWord">Key Word.</param>
        /// <returns>List of Fabrics</returns>
        public async Task<IEnumerable<Fabric>> SearchFabric(string keyWord)
        {
            return await this.fabricRepository.SearchFabric(keyWord);
        }
    }
}
