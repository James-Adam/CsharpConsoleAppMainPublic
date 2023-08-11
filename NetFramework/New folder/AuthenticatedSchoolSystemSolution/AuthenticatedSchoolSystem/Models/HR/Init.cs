using System.Data.Entity;

namespace AuthenticatedSchoolSystem.Models.HR
{
    public class Init : DropCreateDatabaseIfModelChanges<MyHREntities>
    {
        //protected override void Seed(MyHREntities context)
        //{
        //    //base.Seed(context);
        //    var employees = new List<Employee>
        //    {
        //        new Employee{ FirstName= "FName1", LastName= "LName1", Attending = true, HotelRoomRequired= true, Notes="I'm the groom! :)"},
        //        new Employee{ FirstName= "FName2", LastName= "LName2", Attending = true, HotelRoomRequired= true, Notes="I'm the bride! :)"}

        // }; employees.ForEach(i => context.Employees.Add(i)); context.SaveChanges();

        // var actionLog = new List<ActionLog> { new ActionLog{ FirstName= "FName1", LastName=
        // "LName1", Attending = true, HotelRoomRequired= true, Notes="I'm the groom! :)"}, new
        // ActionLog{ FirstName= "FName2", LastName= "LName2", Attending = true, HotelRoomRequired=
        // true, Notes="I'm the bride! :)"}

        //    };
        //    actionLog.ForEach(i => context.ActionLog.Add(i));
        //    context.SaveChanges();
        //}
    }
}