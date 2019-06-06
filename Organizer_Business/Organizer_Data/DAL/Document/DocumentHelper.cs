using System;
using System.Collections.Generic;
using System.Linq;

using Organizer_Data.Models;
using Organizer_Data.DAL.Document;
using Microsoft.EntityFrameworkCore;

namespace Organizer_Data.DAL
{
    public class DocumentHelper : IDisposable
    {
        private OrganizerContext db = new OrganizerContext();

        #region CUD

        #endregion 

        #region Single
        public DocumentModel GetDocumentById(int id)
        {
            var item = db.DocumentDocument.FirstOrDefault(w => w.Id == id);
            if (item != null)
                return new DocumentModel(item);

            return null;
        }
        #endregion

        #region Plural
        public IEnumerable<DocumentModel> GetDocumentsByFolderId(int folderId)
        {
            var list = db.DocumentDocument.Where(w => w.FolderId == folderId).ToList().Select(s => new DocumentModel(s)).AsEnumerable();

            return list;
        }
        #endregion

        #region Helper
        public void Dispose()
        {
            db.Dispose();
        }
        #endregion

    }
}
