using System;
using System.Collections.Generic;

namespace Organizer_Data.Models
{
    public partial class DocumentDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Type { get; set; }
        public int? ContentId { get; set; }
        public int? FolderId { get; set; }
        public string FileName { get; set; }
        public bool IsImage { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int Status { get; set; }

        public virtual DocumentContent Content { get; set; }
        public virtual DocumentFolder Folder { get; set; }
    }
}
