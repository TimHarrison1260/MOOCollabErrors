using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Security;
using WebMatrix.WebData;

namespace MOOCollab.WebUI.App_Start
{
    public class WebSecuritySetup
    {
        public static void SetupConnection()
        {
            WebSecurity.InitializeDatabaseConnection("MOOCollab2Context", "Users", "Id", "UserName", autoCreateTables: true);

            
           
                //set up reference to role provider by casting ASP.Net Roles Proviver object
                var roles = (SimpleRoleProvider) Roles.Provider;

                //setup reference to membership provider by casting ASP.Net Roles Proviver object
                var membership = (SimpleMembershipProvider) Membership.Provider;

                //set up roles passing in reference to roles provider
                //This method must be the fist called setup method
                SetUpRoles(roles);

                //set up superuser passing in references to role and membership provider
                SetUpSuperUser(membership, roles);

                //set up instructors passing in references to role and membership provider
                SetUpInstructors(membership, roles);

                SetUpStudents(membership, roles);
            

        }

        #region Role and Superuser setup

        /// <summary>
        /// Check to see if required roles exist if not create them
        /// </summary>
        /// <param name="roleProvider">instance of the simpleroleprovider</param>
        private static void SetUpRoles(SimpleRoleProvider roleProvider)
        {
            if (!roleProvider.RoleExists("Admin"))
            {
                roleProvider.CreateRole("Admin");
            }

            if (!roleProvider.RoleExists("Instructor"))
            {
                roleProvider.CreateRole("Instructor");
            }

            if (!roleProvider.RoleExists("Student"))
            {
                roleProvider.CreateRole("Student");
            }

        }

        /// <summary>
        /// Checks if account and role of super user needs to be setup
        /// </summary>
        /// <param name="membershipProvider">instance of the simplemembership provider</param>
        /// <param name="roleProvider">instance of the simpleroleprovider</param>
        private static void SetUpSuperUser(SimpleMembershipProvider membershipProvider, SimpleRoleProvider roleProvider)
        {
            if (membershipProvider.GetUser("admin", false) == null)
            {
                membershipProvider.CreateUserAndAccount("admin", "password");
            }


            IList rolesforuser = roleProvider.GetRolesForUser("admin");

            if (!rolesforuser.Contains("Admin"))
            {
                roleProvider.AddUsersToRoles(new[] {"admin"}, new[] {"Admin"});
            }
        }


        #endregion

        /// <summary>
        /// Iterates through a list of students, sets up the default password then
        /// assigns the student to the relevant role
        /// </summary>
        /// <param name="membership">instance of the simplemembership provider</param>
        /// <param name="roleProvider">instance of the simpleroleprovider</param>
        private static void SetUpStudents(SimpleMembershipProvider membership, SimpleRoleProvider roleProvider)
        {
            new List<string> {"Andrew", "Tim", "Bartoz", "Narelle", "Robert"}
                .ForEach(u =>
                    
                        SetUpUserInRole(membership,roleProvider,"Student",u)
                    );
        }

        /// <summary>
        /// Iterates through a list of Instructors, sets up the default password then
        /// assigns the instructor to the relevant role
        /// </summary>
        /// <param name="membership">instance of the simplemembership provider</param>
        /// <param name="roles">instance of the simpleroleprovider</param>
        private static void SetUpInstructors(SimpleMembershipProvider membership, SimpleRoleProvider roles)
        {
            new List<string> {"JPaterson", "BMacDonald"}
                .ForEach(u =>

                        SetUpUserInRole(membership, roles, "Instructor", u)
                    );
        }

        /// <summary>
        /// Sets up the account of the provided username in the role provided
        /// </summary>
        /// <param name="membership">instance of the simple membership provider</param>
        /// <param name="roleProvider">instance of the simple roleprovider</param>
        /// <param name="role">Role type to be assigned</param>
        /// <param name="userName">Username</param>
        private static void SetUpUserInRole(SimpleMembershipProvider membership,SimpleRoleProvider roleProvider,string role,string userName)
        {
            var user = membership.GetUser(userName, false);
            
            // test if user exists and if the membership details also exist.  If not the date returned is 01/01/0001
            if (user != null && membership.GetCreateDate(userName) == default(DateTime))
            {
                membership.CreateAccount(userName, "password");
       
            }

            IList rolesforuser = roleProvider.GetRolesForUser(userName);

            if (!rolesforuser.Contains(role))
            {
                roleProvider.AddUsersToRoles(new[] { userName }, new[] { role });
            }
        }

    }
}