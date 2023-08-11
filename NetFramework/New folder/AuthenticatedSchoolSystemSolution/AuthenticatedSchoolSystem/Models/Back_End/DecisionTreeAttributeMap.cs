using System.Data.Entity.ModelConfiguration;

namespace AuthenticatedSchoolSystem.Models.Back_End
{
    public class DecisionTreeAttributeMap : EntityTypeConfiguration<DecisionTreeAttribute>
    {
        public DecisionTreeAttributeMap()
        {
            _ = ToTable("DecisionTreeAttribute");
            _ = HasKey(ca => ca.DecisionTreeId);
            _ = Property(ca => ca.Name).IsRequired().HasMaxLength(400);
            _ = Property(ca => ca.Statement).IsOptional();
            _ = Ignore(ca => ca.StepControlTypeId);
            _ = Property(ca => ca.IsDriveQuestion).IsRequired();
            _ = Property(ca => ca.IsOnSiteQuestion).IsRequired();
        }
    }
}