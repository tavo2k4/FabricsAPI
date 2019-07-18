using FabricManagerApiNetCore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FabricManagerApiNetCore.Repositories
{
    /// <summary>
    /// DB Json File Rea/Write.
    /// </summary>
    public class DbJsonContext
    {
        /// <summary>
        /// Read Json DB file.
        /// </summary>
        /// <returns>Json DB as ListOfFabrics obeject.</returns>
        public async Task<ListOfFabrics> ReadFabricsDb()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Resources/db.json");

            var fabricsObject = JObject.Parse(await File.ReadAllTextAsync(path));

            return fabricsObject.ToObject<ListOfFabrics>();
        }

        /// <summary>
        /// Write Json DB file for Data Persistance.
        /// </summary>
        /// <param name="fabrics"></param>
        /// <returns></returns>
        public async Task WriteFabricsDb(ListOfFabrics fabrics)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Resources/db.json");

            try
            {
                using (StreamWriter file = File.CreateText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, fabrics);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
