using FabricManagerApiNetCore.Contracts;
using FabricManagerApiNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricManagerApiNetCore.Repositories
{
    /// <summary>
    /// Fabric Repository Interfacce.
    /// </summary>
    public interface IFabricRepository
    {
        /// <summary>
        /// Get a Fabric by Id.
        /// </summary>
        /// <param name="id">Fabric Id.</param>
        /// <returns>Singel Fabric.</returns>
        Task<Fabric> GetFabric(int id);

        /// <summary>
        /// Get List of Fabrics.
        /// </summary>
        /// <returns>List of Fabrics.</returns>
        Task<ListOfFabrics> GetListOfFabrics();

        /// <summary>
        /// Add a New Fabric.
        /// </summary>
        /// <param name="fabric">Fabric object to add.</param>
        /// <returns>New Fabric Added.</returns>
        Task<int> AddFabric(FabricAddRequest fabric);

        /// <summary>
        /// Update Fabric.
        /// </summary>
        /// <param name="fabric">Fabric object to update.</param>
        /// <returns>Updated Fabric.</returns>
        Task<int> UpdateFabric(Fabric fabric);

        /// <summary>
        /// Delete Fabric by Id.
        /// </summary>
        /// <param name="id">Fabric Id.</param>
        /// <returns>True/False.</returns>
        Task<bool> DeleteFabric(int id);

        /// <summary>
        /// Search Fabric by key word.
        /// </summary>
        /// <param name="keyWord">Key Word.</param>
        /// <returns>List of Fabrics</returns>
        Task<IEnumerable<Fabric>> SearchFabric(string keyWord);
    }
}
