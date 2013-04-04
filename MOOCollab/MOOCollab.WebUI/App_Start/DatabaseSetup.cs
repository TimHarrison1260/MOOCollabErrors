using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MOOCollab.DataAccess.MOOCollabContext;
using MOOCollab.WebUI.Filters;

namespace MOOCollab.WebUI.App_Start
{
    public class DatabaseSetup
    {
        public static bool Databasedropped;

        public static void DropDatabase(bool dropDb)
        {
            if (dropDb)
            {
                Database.SetInitializer(new MOOCollab2Config());
                //flag database as dropped
                Databasedropped = true;
            }
            else
            {   //If database is dropped
                WebSecuritySetup.SetupConnection();
                InitializeSimpleMembershipAttribute.IsInitialized = true;
            }
        }
    }
}