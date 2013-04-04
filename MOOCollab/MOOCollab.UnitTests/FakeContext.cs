using System.Collections.Generic;
using System.Linq;
using MOOCollab.Domain;

namespace MOOCollab.UnitTests
{
    public class FakeContext
    {
        public static IQueryable<Instructor> Instructors { get; set; }
        public static IQueryable<Student> Students { get; set; }
        public static IQueryable<Course> Courses { get; set; }
        public static IQueryable<Group> Groups { get; set; }
        public static IQueryable<GroupMessage> GroupMessages { get; set; }
        public static IQueryable<CourseMessage> CourseMessages { get; set; }
        public static IQueryable<UserMessage> UserMessages { get; set; }
        public static IQueryable<Achievment> Achievments { get; set; }
        public static IQueryable<User> Users { get; set; }
        public static IQueryable<Student> GoodStudents { get; set; }
        public static IQueryable<Student> StupidStudents { get; set; }
        public static IQueryable<Student> Drivers { get; set; }

        /// <summary>
        /// Testdata there are no keys available
        /// </summary>
        static FakeContext()
        {
            #region instructors

            //----------------------------------------instructors---------------------------------------------------//
            var intructors = new List<Instructor>
                {
                    new Instructor {UserName = "JPaterson", Courses = new List<Course>() {}, MessagesSent = new List<UserMessage>(),Following = new List<User>{},Followers = new List<User>{}},
                    new Instructor {UserName = "BMacDonald", Courses = new List<Course>() {},MessagesSent = new List<UserMessage>(),Following = new List<User>{},Followers = new List<User>{}}
                };

            //give instructors variables
            var jim = intructors[0];
            var brian = intructors[1];


            #endregion


            #region Courses

            //---------------------------------------Courses------------------------------------------------------//

            var courses = new List<Course>
                {
                    new Course
                        {
                            Title = ".Net Database Technologies",
                            Status = true,
                            Resume = "Patterns relating to the EntityFramework and Friends",
                            CourseMessages = new List<CourseMessage>{},
                            Owner = jim,
                            Achievments = new List<Achievment>(),
                            Students = new List<Student>(),
                            Groups = new List<Group>()
                        },
                    new Course
                        {
                            Title = "Asp.Net MVC4",
                            Status = true,
                            Resume = "Learn about the Latest version of Microsoft's flagship web development platform",
                            CourseMessages = new List<CourseMessage>{},
                            Owner = jim,
                            Achievments = new List<Achievment>(),
                            Students = new List<Student>(),
                            Groups = new List<Group>()

                        },
                    new Course
                        {
                            Title = "Foudations of Windows store app development",
                            Status = false,
                            Resume = "Learn about Xaml and databinding",
                            CourseMessages = new List<CourseMessage>{},
                            Owner = brian,
                            Achievments = new List<Achievment>(),
                            Students = new List<Student>(),
                            Groups = new List<Group>()
                        },
                    new Course
                        {
                            Title = "Programming in C#", 
                            Status = true,
                            Resume = "Learn how to program in C#",
                            CourseMessages = new List<CourseMessage>{},
                            Owner = brian,
                            Achievments = new List<Achievment>(),
                            Students = new List<Student>(),
                            Groups = new List<Group>()
                        },
                    new Course
                        {
                            Title = "Programming for beginners",
                            Status = true,
                            Resume = "For thoses who shouldn't give up the day job",
                            CourseMessages = new List<CourseMessage>{},
                            Owner = brian,
                            Achievments = new List<Achievment>(),
                            Students = new List<Student>(),
                            Groups = new List<Group>()
                        },
                    new Course
                        {
                            Title = "HTML5 and Javascript",
                            Status = true,
                            Resume = "Developing Apps in Javascript for all platforms",
                            CourseMessages = new List<CourseMessage>{},
                            Owner = jim,
                            Achievments = new List<Achievment>(),
                            Students = new List<Student>(),
                            Groups = new List<Group>()
                        }
                };



            //assign courses to local variables
            var dotNetDbTechnologies = courses[0];
            var aspNetMvc4 = courses[1];
            var foundationsofWindowsStore = courses[2];
            var programmingCsharp = courses[3];
            var programmingForBeginners = courses[4];
            var htmlAndJavascript = courses[5];


            #endregion


            #region Students

            //----------------------------------------Students----------------------------------------------------//
            var goodStudents = new List<Student>
                {
                    new Student
                        {
                            UserName = "Andrew",
                            CoursesTaken = new List<Course> (courses),
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        },
                    new Student
                        {
                            UserName = "Tim",
                            CoursesTaken = new List<Course> (courses),
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        },
                    new Student
                        {
                            UserName = "Robert",
                            CoursesTaken = new List<Course> (courses),
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        },
                    new Student
                        {
                            UserName = "Narelle",
                            CoursesTaken = new List<Course> (courses),
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        },
                    new Student
                        {
                            UserName = "Bartoz",
                            CoursesTaken = new List<Course> (courses),
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        }
                };



            var stupidStudents = new List<Student>
                {
                    new Student
                        {
                            UserName = "Curly",
                            CoursesTaken = new List<Course> {courses[3], courses[2],programmingForBeginners,htmlAndJavascript},
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        },
                    new Student
                        {
                            UserName = "Mo",
                            CoursesTaken = new List<Course> {courses[3], courses[2],programmingForBeginners,htmlAndJavascript},
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        },
                    new Student
                        {
                            UserName = "Stu",
                            CoursesTaken = new List<Course> {courses[3], courses[2],programmingForBeginners,htmlAndJavascript},
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        }
                };

            var drivers = new List<Student>
                {
                    new Student
                        {
                            UserName = "Sebastien",
                            CoursesTaken = new List<Course> {courses[3], courses[4],htmlAndJavascript},
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        },
                    new Student
                        {
                            UserName = "Fernanndo",
                            CoursesTaken = new List<Course> {courses[3], courses[4],htmlAndJavascript},
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        },
                    new Student
                        {
                            UserName = "Nico",
                            CoursesTaken = new List<Course> {courses[3], courses[4],htmlAndJavascript},
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        },
                    new Student
                        {
                            UserName = "Jenson",
                            CoursesTaken = new List<Course> {courses[3], courses[4],htmlAndJavascript},
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        },
                    new Student
                        {
                            UserName = "Lewis",
                            CoursesTaken = new List<Course> {courses[3], courses[4],htmlAndJavascript},
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        },
                    new Student
                        {
                            UserName = "Kimi",
                            CoursesTaken = new List<Course> {courses[3], courses[4],htmlAndJavascript},
                            Groups = new List<Group> {},
                            Achievments = new List<Achievment> {},
                            MessagesSent = new List<UserMessage>{},
                            Following = new List<User>{},
                            Followers = new List<User>{}
                        }
                };

            //assign students to local variables
            var andrew = goodStudents[0];
            var tim = goodStudents[1];
            var robert = goodStudents[2];
            var narelle = goodStudents[3];
            var bartoz = goodStudents[4];
            var curly = stupidStudents[0];
            var mo = stupidStudents[1];
            var stu = stupidStudents[2];
            var sebastien = drivers[0];
            var fernando = drivers[1];
            var nico = drivers[2];
            var jenson = drivers[3];
            var lewis = drivers[4];
            var kimi = drivers[5];


            //put all students together
            var allstudents = new List<Student>();
            allstudents.AddRange(goodStudents);
            allstudents.AddRange(stupidStudents);
            allstudents.AddRange(drivers);

            #endregion


            #region Groups

            //------------------------------Groups-------------------------------------------------------//
            var groups = new List<Group>
                {
                   new Group
                    {
                        Title = "MOOCollab",
                        Status = true,
                        GroupSize = 5,
                        Owner = robert,
                        Course = dotNetDbTechnologies,
                        Members = new List<Student>(goodStudents),
                        GroupMessages = new List<GroupMessage>{}
                    },
                    new Group
                    {
                        Title = "The three stooges",
                        Status = false,
                        GroupSize = 5,
                        Owner = andrew,
                        Course = foundationsofWindowsStore,
                        Members = new List<Student>(stupidStudents){andrew},
                        GroupMessages = new List<GroupMessage> { }
                    },
                    new Group
                    {
                        Title = "Programmers in need",
                        Status = true,
                        GroupSize = 10,
                        Owner = narelle,
                        Course = programmingForBeginners,
                        Members = new List<Student>(drivers){narelle},
                        GroupMessages = new List<GroupMessage> { }
                    },
                    new Group
                        {
                            Title = "MVC4 Client side development",
                            Status = true,
                            GroupSize = 3,
                            Owner = bartoz,
                            Course = aspNetMvc4,
                            Members = new List<Student>{narelle,andrew,bartoz},
                            GroupMessages = new List<GroupMessage>{}
                        },
                    new Group
                        {
                            Title = "ClientSideDesign",
                            Status = true,
                            GroupSize = 8,
                            Owner = bartoz,
                            Course = htmlAndJavascript,
                            Members = new List<Student>(drivers){bartoz},
                            GroupMessages = new List<GroupMessage>{}
                        },
                    new Group
                        {
                         Title   = "DbSkills",
                         Status = true,
                         GroupSize = 5,
                         Owner = tim,
                         Course = programmingForBeginners,
                         Members = new List<Student>(stupidStudents){tim},
                         GroupMessages = new List<GroupMessage>{}
                        },
                    new Group
                        {
                            Title = "We love linq",
                            Status = false,
                            GroupSize = 5,
                            Owner = narelle,
                            Course = programmingCsharp,
                            Members = new List<Student>(goodStudents){},
                            GroupMessages = new List<GroupMessage>{}
                        },                 
                    new Group
                        {
                            Title = "Reshaper skills",
                            Status = true,
                            GroupSize = 12,
                            Owner = tim,
                            Course = programmingCsharp,
                            Members = new List<Student>(goodStudents){nico,fernando,curly,stu},
                            GroupMessages = new List<GroupMessage>{}
                        },
                    new Group
                        {
                            Title = "We love Spa's",
                            Status = true,
                            GroupSize = 12,
                            Owner = andrew,
                            Course = htmlAndJavascript,
                            Members = new List<Student>(drivers){andrew,narelle,robert},
                            GroupMessages = new List<GroupMessage>{}
                        },
                    new Group
                        {
                            Title = "Understanding semantic markup",
                            Status = false,
                            GroupSize = 6,
                            Owner = bartoz,
                            Course = htmlAndJavascript,
                            Members = new List<Student>(stupidStudents){bartoz,tim,robert},
                            GroupMessages = new List<GroupMessage>{}
                        },
                    new Group
                        {
                            Title = "CSS3 for beginners",
                            Status = true,
                            GroupSize = 9,
                            Owner = robert,
                            Course = htmlAndJavascript,
                            Members = new List<Student>(drivers){robert,curly},
                            GroupMessages = new List<GroupMessage>{}
                        }
                            
                };
            //give groups referencable names 
            var groupMooCollab = groups[0];
            var groupStooges = groups[1];
            var groupProgrammersInNeed = groups[2];
            var groupMvc4ClientSide = groups[3];
            var groupClientSideDesign = groups[4];
            var dbSkills = groups[5];
            var weLoveLinq = groups[6];
            var reSharperSkills = groups[7];
            var weLoveSpas = groups[8];
            var understandingSemanticMarkup = groups[9];
            var css3ForBeginners = groups[10];

            //add groups to students
            allstudents.ForEach(s => groups.ForEach(g =>
            {
                if (g.Members.Contains(s))
                {
                    s.Groups.Add(g);
                }
            }));           

            //add groups to courses
            groups.ForEach(g => courses.ForEach(c =>
                {
                    if (g.Course == c)
                    {
                        c.Groups.Add(g);
                    }
                }));

            #endregion


            #region Achievments

            //--------------------------Achievments-----------------------------------------//
            var achievments = new List<Achievment>
                {
                    new Achievment
                        {
                            AwardType = AwardType.CourseCompleted,
                            Description = "Foundations course completed",
                            Student = goodStudents[0],
                            Course = courses[0],
                            Comments = ""
                        },
                    new Achievment
                        {
                            AwardType = AwardType.OutstandingContribution,
                            Description = "Very helpful contribution to course",
                            Student = goodStudents[1],
                            Course = courses[1],
                            Comments = ""
                        },
                    new Achievment
                        {
                            AwardType = AwardType.OutstandingContribution,
                            Description = "For outstanding support of fellow students",
                            Student = goodStudents[2],
                            Course = courses[2],
                            Comments = ""
                        }
                };
            //add achievments to courses
            achievments.ForEach(a=> courses.ForEach(c =>
                {
                    if (a.Course == c)
                    {
                        c.Achievments.Add(a);
                    }
                }));

            #endregion

            #region Messages

            //instructors message followers.
            intructors.ForEach(i =>
            {
                var message = new UserMessage
                {
                    Content = "Hi this is " + i.UserName + " calling",
                    Sender = i,
                    Title = i.UserName + "'s messages followers"
                };
                i.MessagesSent.Add(message);
            });

            //Students message followers
            allstudents.ForEach(s =>
            {
                var message = new UserMessage
                {
                    Content = s.UserName + "  says thanks for following me",
                    Sender = s,
                    Title = "Thank you from " + s.UserName
                };
                s.MessagesSent.Add(message);
            });

            //Course owner message course
            courses.ForEach(c =>
            {
                var message = new CourseMessage
                {
                    Title = "Welcome to " + c.Title,
                    Sender = c.Owner,
                    Content = "Hi, \n Thanks for taking this course \n " + c.Owner.UserName,
                    Course = c
                };
                c.CourseMessages.Add(message);
            });

            groups.ForEach(g =>
            {//send message from group owner
                var message = new GroupMessage
                {
                    Title = "Welcome to " + g.Title + " the best group on in the world",
                    Sender = g.Owner,
                    Content = "Hi All \n We are going to make this the best group on the system \n " + g.Owner.UserName,
                    Group = g
                };
                g.GroupMessages.Add(message);

                //cast group members to List
                var groupmembers = g.Members as List<Student>;
                //Check for null
                if (groupmembers != null)
                    groupmembers.ForEach(gm =>
                    {//If the  current member is not also the owner...
                        if (gm != g.Owner)
                        {//add the following message
                            var memberMessage = new GroupMessage
                            {
                                Title = "Dear fellow " + g.Title + " members",
                                Sender = gm,
                                Content = "Hi guys \n Am looking forward to working with you. " + g.Title + " is going to be the best group ever \n" + gm.UserName,
                                Group = g
                            };
                            
                            g.GroupMessages.Add(memberMessage);
                        }

                    });
            });
            //------------------------------Messages------------------------------------------//

            #endregion

            #region Stalking

            //Have all students follow Jim
            allstudents.ForEach(s => s.Following.Add(jim));
            allstudents.ForEach(s => jim.Followers.Add(s));

            #endregion

           
            //add achievments to students
            allstudents.ForEach(s=> achievments.ForEach(a =>
                {
                    if (a.Student == s)
                    {
                        s.Achievments.Add(a);
                    }
                }));

            Instructors = intructors.AsQueryable();
            Courses = courses.AsQueryable();
            Groups = groups.AsQueryable();          
            Achievments = achievments.AsQueryable();          
            GoodStudents = goodStudents.AsQueryable();
            StupidStudents = stupidStudents.AsQueryable();
            Drivers = drivers.AsQueryable();
            Students = allstudents.AsQueryable();
            //Extract messages
            GroupMessages = groups.SelectMany(g=>g.GroupMessages).ToList().AsQueryable();
            CourseMessages = courses.SelectMany(c=>c.CourseMessages).ToList().AsQueryable();

            //combine instructors and students
            var studentsToUsers = allstudents as IEnumerable<User>;
            var instructorsToUsers = intructors as IEnumerable<User>;

            var allusers = new List<User>(studentsToUsers);

            allusers.AddRange(instructorsToUsers);

            Users = allusers.AsQueryable();
            //Extract user messages
            UserMessages = allusers.ToList().SelectMany(u => u.MessagesSent).ToList().AsQueryable();
        } 
    }
}