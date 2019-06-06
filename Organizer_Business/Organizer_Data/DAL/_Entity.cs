using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Organizer_Data.DAL
{
    public class _Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime CreateDate { get; set; }

        public int CreateUserID { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? DeleteUserId { get; set; }

        public int Status { get; set; }
        

        public _Entity()
        {

        }

        public _Entity(dynamic entity) 
        {
            Id = entity.Id;
            Name = entity.Name;
            Code = entity.Code;
            CreateUserID = entity.CreateUserId;
            CreateDate = entity.CreateDate;
            UpdateUserId = entity.UpdateUserId;
            UpdateDate = entity.UpdateDate;
            DeleteUserId = entity.DeleteUserId;
            DeleteDate = entity.DeleteDate;
            Status = entity.Status;
        }

    }
}
