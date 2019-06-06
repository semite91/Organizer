using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Organizer_Data.DAL;
using Organizer_Data.DAL.Document;

using Microsoft.AspNetCore.Cors;

namespace Organizer_API.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        [HttpGet("{id}")]
        public DocumentModel Get(int id)
        {
            using (var helper = new DocumentHelper())
            {
                return helper.GetDocumentById(id);
            }
        }

        [HttpGet]
        public IEnumerable<DocumentModel> GetDocumentsByFolderId(int folderId)
        {
            using (var helper = new DocumentHelper())
            {
                return helper.GetDocumentsByFolderId(folderId);
            }
        }
    }
}