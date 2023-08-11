using Microsoft.WindowsAzure.MediaServices.Client;
using System;

namespace AuthenticatedSchoolSystem.Models.Back_End
{
    public class ItemMaster : BaseEntity
    {
        public virtual string ItemNumber { get; set; }
        public virtual int ItemType { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual string Description { get; set; }
        public virtual string Category { get; set; }
        public virtual string Level1 { get; set; }
        public virtual string Level2 { get; set; }
        public virtual string UOM { get; set; }
        public virtual string SLId { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime ModifiedOn { get; set; }
        public virtual bool Active { get; set; }
    }
}