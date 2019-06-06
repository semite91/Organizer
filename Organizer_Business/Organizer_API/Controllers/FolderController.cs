using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

using Organizer_Data.Models;
using Organizer_Data.DAL;
using Organizer_Data.DAL.Folder;

namespace Organizer_API.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<FolderModel>> Get()
        //{
        //    return null;
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<FolderModel> Get(int id)
        {
            using (var helper = new FolderHelper())
            {
                return helper.GetChilds(id);
            }
        }

        [HttpGet]
        public IEnumerable<FolderModel> GetListByLevel(int level)
         {
            using (var helper = new FolderHelper())
            {
                return helper.GetListByLevel(level);
            }
        }

        [HttpGet]
        public IEnumerable<FolderModel> GetTree()
        {
            using (var helper = new FolderHelper())
            {
                return helper.GetTree();
            }
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
