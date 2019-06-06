using System;
using System.Collections.Generic;
using System.Linq;

using Organizer_Data.DAL;
using Organizer_Data.Models;

namespace Organizer_Data.DAL.Folder
{
    public class FolderModel: _Entity
    {
        public string ColorCode { get; set; }

        public int? ParentId { get; set; }

        public string ParentIds { get; set; }

        public string ChildIds { get; set; }

        public List<FolderModel> Children { get; set; }


        public FolderModel()
        {

        }

        public FolderModel(DocumentFolder folder, bool isHierarchical = false) : base(folder)
        {
            ColorCode = folder.ColorCode;
            ParentId = folder.ParentId;
            ParentIds = folder.ParentIds;
            ChildIds = folder.ChildIds;

            if (isHierarchical)
                Children = folder.InverseParent
                                .Where(w => w.Status == 1)
                                .Select(s => new FolderModel(s, isHierarchical))
                                .ToList();
        }
    }
}
