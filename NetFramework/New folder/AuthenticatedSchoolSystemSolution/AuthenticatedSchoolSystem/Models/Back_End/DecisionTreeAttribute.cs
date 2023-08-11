using Microsoft.WindowsAzure.MediaServices.Client;

namespace AuthenticatedSchoolSystem.Models.Back_End
{
    public class DecisionTreeAttribute : BaseEntity, ILocalizedEntity
    {
        public int DecisionTreeId { get; set; }
        public string Name { get; set; }
        public string IsRequired { get; set; }

        public int StepControlTypeId { get; set; }
        public int DisplayOrder { get; set; }
        public int ProductId { get; set; }
        public bool Critical { get; set; }
        public string Statement { get; set; }
        public bool IsDriveQuestion { get; set; }
        public int DependancyLineRule { get; internal set; }

        public string IsOnSiteQuestion { get; internal set; }
        //public StepControlType stepControlType
        //{
        //    get
        //    {
        //        return (StepControlType)this.StepControlTypeId;
        //    }
        //    set
        //    {
        //    }
        //}
    }

    internal interface ILocalizedEntity
    {
    }
}