using AuthenticatedSchoolSystem.Models.Back_End;

namespace AuthenticatedSchoolSystem.Back_End.Services
{
    public interface IEventPublisher
    {
        void EntityDeleted(ItemMaster itemMaster);

        void EntityDeleted(DecisionTreeAttribute decisionTreeAttribute);

        void EntityInserted(ItemMaster itemMaster);

        void EntityUpdated(ItemMaster itemMaster);
    }
}