using System.Web;
using System.Web.Mvc;

namespace MOOCollab.WebUI.ExtensionAndHelpers
{
    public static class Helpers
    {
        /// <summary>
        /// Helper method for testing. Checks if the User object exists
        /// if not the method returns a string.
        /// </summary>
        /// <param name="context">current controller "this"</param>
        /// <returns>string ="Default"</returns>
        public static string GetCurrentUserName(Controller context)
        {
            string currentUser = "Default";
            if (context.User != null)
            {
                currentUser = context.User.Identity.Name;
            }

            return currentUser;
        }
    }
}