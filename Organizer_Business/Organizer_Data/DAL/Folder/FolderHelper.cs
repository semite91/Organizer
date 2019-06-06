using System;
using System.Collections.Generic;
using System.Linq;

using Organizer_Data.Models;
using Organizer_Data.DAL.Folder;
using Microsoft.EntityFrameworkCore;

namespace Organizer_Data.DAL
{
    public class FolderHelper : IDisposable
    {
        private OrganizerContext db = new OrganizerContext();

        public IEnumerable<FolderModel> GetChilds(int id)
        {
            var list = db.DocumentFolder.Where(w => w.Status == 1 && w.ParentId == id).ToList().Select(s => new FolderModel(s)).AsEnumerable();

            return list;
        }

        public IEnumerable<FolderModel> GetListByLevel(int level)
        {
            var list = db.DocumentFolder
                            .Where(w => w.Status == 1 && (w.ParentIds == null ? (level == 0) : w.ParentIds.Trim().Split(',', StringSplitOptions.None).Length == level))
                            .Select(s => new FolderModel(s, false))
                            .AsEnumerable();

            return list;
        }

        public IEnumerable<FolderModel> GetTree()
        {
            var list = db.DocumentFolder
                                .ToList()
                                .Where(w => w.Status == 1 && w.ParentId == null)
                                .Select(s => new FolderModel(s, true))
                                .AsEnumerable();

            return list;
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
