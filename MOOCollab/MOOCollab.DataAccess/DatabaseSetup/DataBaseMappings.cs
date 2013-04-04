using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOOCollab.Domain;

namespace MOOCollab.DataAccess.DatabaseSetup
{
    public class DataBaseMappings
    {
        public static void ApplyMappings(DbModelBuilder modelBuilder)
        {
            //------------Table per type mappings-----------------------//
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Instructor>().ToTable("Instructors");


            //--------------------Complex type mappings--------------------//


            //Allows multiple foreign key constraints to reference the same Primary key(StudentId)
            modelBuilder.Entity<Group>()
                        .HasRequired(g => g.Owner)
                        .WithMany(s => s.GroupsOwned)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>().HasMany(g => g.Members).WithMany(s => s.Groups);


            //-------------------------Following / Following----------------------------------// 
            modelBuilder.Entity<User>().HasMany(u => u.Followers).WithMany(u => u.Following);

            //---------------------------Achievment-> Courses---------------------------------//
            modelBuilder.Entity<Course>()
                        .HasMany(c => c.Achievments)
                        .WithRequired(a => a.Course)
                        .WillCascadeOnDelete(false);

            
            //modelBuilder.Entity<UserMessage>().HasRequired(m => m.Sender)
            //            .WithMany(u => u.MessagesSent);

            //modelBuilder.Entity<GroupMessage>().HasRequired(m => m.Group)
            //            .WithMany(g => g.GroupMessages);

            modelBuilder.Entity<CourseMessage>().HasRequired(m => m.Course)
                        .WithMany(c => c.CourseMessages)
                        .WillCascadeOnDelete(false);

        }
    }
}
