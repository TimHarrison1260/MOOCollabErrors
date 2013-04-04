using System.Data.Entity;
using MOOCollab.DataAccess.DatabaseSetup;

namespace MOOCollab.DataAccess.MOOCollabContext
{
    /// <summary>
    /// Initialization for production base context
    /// </summary>
    public class MOOCollab2Config : DropCreateDatabaseAlways<MOOCollab2Context>
    {
        protected override void Seed(MOOCollab2Context context)
        {
            base.Seed(context);
           
            //Call to common seed data used by both live and testDb integration
            DataBaseData.Seed(context);

            context.SaveChanges();

        }
    }
}
