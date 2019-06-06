using System;
using System.Collections.Generic;

namespace Organizer_Data.Models
{
    public partial class DocumentFolder
    {
        public DocumentFolder()
        {
            DocumentDocument = new HashSet<DocumentDocument>();
            InverseParent = new HashSet<DocumentFolder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ColorCode { get; set; }
        public int? ParentId { get; set; }
        public string ParentIds { get; set; }
        public string ChildIds { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int Status { get; set; }

        public virtual DocumentFolder Parent { get; set; }
        public virtual ICollection<DocumentDocument> DocumentDocument { get; set; }
        public virtual ICollection<DocumentFolder> InverseParent { get; set; }
    }
}
