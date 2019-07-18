using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricManagerApiNetCore.Contracts;
using FabricManagerApiNetCore.Models;
using FabricManagerApiNetCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FabricManagerApiNetCore.Controllers
{
    /// <summary>
    /// Fabrics Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FabricsController : ControllerBase
    {
        private readonly IFabricService fabricService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FabricsController"/> class.
        /// </summary>
        /// <param name="fabricService">Fabric Service.</param>
        public FabricsController(IFabricService fabricService)
        {
            this.fabricService = fabricService;
        }

        /// <summary>
        /// Get List of Fabrics.
        /// GET: api/Fabrics
        /// </summary>
        /// <returns>List of Fabrics.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rs = await this.fabricService.GetListOfFabrics();

            return this.Ok(rs);
        }

        /// <summary>
        /// Get a single Fabric by ID.
        /// GET: api/Fabrics/5
        /// </summary>
        /// <param name="id">Fabric Id.</param>
        /// <returns>A Single Fabric.</returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var rs = await this.fabricService.GetFabric(id);

            if (rs ==  null)
            {
                return this.NotFound();
            }

            return this.Ok(rs);
        }

        /// <summary>
        /// Add New fabric.
        /// POST: api/Fabrics
        /// </summary>
        /// <param name="fabric">Fabric Model.</param>
        /// <returns>Added Fabric.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FabricAddRequest fabric)
        {
            var rs = await this.fabricService.AddFabric(fabric);

            return this.CreatedAtAction(nameof(Get), new { id = rs }, rs);
        }

        /// <summary>
        /// Update Fabric.
        /// PUT: api/Fabrics/
        /// </summary>
        /// <param name="fabric">Fabric Model.</param>
        /// <returns>Updated Fabric.</returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Fabric fabric)
        {
            var rs = await this.fabricService.UpdateFabric(fabric);

            return this.Ok(rs);
        }

        /// <summary>
        /// Delete Fabric by Id.
        /// DELETE: api/Fabrics/5
        /// </summary>
        /// <param name="id">Fabric Id.</param>
        /// <returns>True/False</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await this.fabricService.DeleteFabric(id);

            if (rs == false)
            {
                return this.NotFound();
            }

            return this.Accepted(rs);
        }

        /// <summary>
        /// Update Fabric.
        /// PATCH: api/Fabrics/5
        /// </summary>
        /// <param name="fabric">Fabric Model.</param>
        /// <returns>Updated Fabric.</returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Fabric> patchDoc)
        {
            var fabric = new Fabric();

            fabric = await this.fabricService.GetFabric(id);

            if (fabric == null)
            {
                return this.NotFound();
            }

            patchDoc.ApplyTo(fabric);

            await this.fabricService.UpdateFabric(fabric);

            return new ObjectResult(fabric);
        }

        /// <summary>
        /// Search Fabrics.
        /// POST: api/fabrics/search/"keyword"
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns>List of Fabrics that matches key word.</returns>
        [Route("search/{keyWord}")]
        [HttpPost]
        public async Task<IActionResult> Search(string keyWord)
        {
            var rs = await this.fabricService.SearchFabric(keyWord);

            return Ok(rs);
        }
    }
}
