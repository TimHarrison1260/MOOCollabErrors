using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MOOCollab.DataAccess.DatabaseSetup;
using MOOCollab.Domain;

namespace MOOCollab.DataAccess.TestContext
{
    /// <summary>
    /// Seeds test db with the same seed data that the live site is currently using.
    /// //Todo migrations comment
    /// </summary>
    public class TestDbConfig : DropCreateDatabaseAlways<TestDb>
    {
        protected override void Seed(TestDb context)
        {
            base.Seed(context);
           
            //Seed test data that both Production and test Db work off
            DataBaseData.Seed(context);

            context.SaveChanges();


        }
    }
}
