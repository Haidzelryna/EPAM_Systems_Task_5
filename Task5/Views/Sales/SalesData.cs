//using DevExtreme.MVC.Demos.Models.DataGrid;
//using System;
//using System.Collections.Generic;

//namespace Task5.View.Sales
//{
//    public partial class ContactData
//    {
//        public static readonly IEnumerable<Contact> DataGridSales = new[] {
//            new Contact {
//                ID = 1,
//                FirstName = "John",
//                LastName = "Heart",
//                Phone = "(213) 555-9392",
//                Prefix = "Mr.",
//                Position = "CEO",
//                BirthDate = DateTime.Parse("1964/03/16"),
//                HireDate = DateTime.Parse("1995/01/15"),
//                Notes = "John has been in the Audio/Video industry since 1990. He has led DevAv as its CEO since 2003.\r\n\r\nWhen not working hard as the CEO, John loves to golf and bowl. He once bowled a perfect game of 300.",
//                Email = "jheart@dx-email.com",
//                Address = "351 S Hill St.",
//                City = "Los Angeles",
//                Tasks = new[] {
//                    new EmployeeTask {
//                        ID = 5,
//                        Subject = "Choose between PPO and HMO Health Plan",
//                        StartDate = DateTime.Parse("2013/02/15"),
//                        DueDate = DateTime.Parse("2013/04/15"),
//                        Status = "In Progress",
//                        Priority = Priority.High,
//                        Completion = 75
//                    },
//                    new EmployeeTask {
//                        ID = 6,
//                        Subject = "Google AdWords Strategy",
//                        StartDate = DateTime.Parse("2013/02/16"),
//                        DueDate = DateTime.Parse("2013/02/28"),
//                        Status = "Completed",
//                        Priority = Priority.High,
//                        Completion = 100
//                    },
//                    new EmployeeTask {
//                        ID = 7,
//                        Subject = "New Brochures",
//                        StartDate = DateTime.Parse("2013/02/17"),
//                        DueDate = DateTime.Parse("2013/02/24"),
//                        Status = "Completed",
//                        Priority = Priority.Normal,
//                        Completion = 100
//                    },
//                    new EmployeeTask {
//                        ID = 22,
//                        Subject = "Update NDA Agreement",
//                        StartDate = DateTime.Parse("2013/03/14"),
//                        DueDate = DateTime.Parse("2013/03/16"),
//                        Status = "Completed",
//                        Priority = Priority.High,
//                        Completion = 100
//                    },
//                    new EmployeeTask {
//                        ID = 52,
//                        Subject = "Review Product Recall Report by Engineering Team",
//                        StartDate = DateTime.Parse("2013/05/17"),
//                        DueDate = DateTime.Parse("2013/05/20"),
//                        Status = "Completed",
//                        Priority = Priority.High,
//                        Completion = 100
//                    }
//                },
//                State = "California",
//                StateID = 5,
//                HomePhone = "(213) 555-9208",
//                Skype = "jheartDXskype",
//                Picture = "../../Content/Images/employees/01.png"
//            },
//            new Employee {
//                ID = 2,
//                FirstName = "Olivia",
//                LastName = "Peyton",
//                Phone = "(310) 555-2728",
//                Prefix = "Mrs.",
//                Position = "Sales Assistant",
//                BirthDate = DateTime.Parse("1981/06/03"),
//                HireDate = DateTime.Parse("2012/05/14"),
//                Notes = "Olivia loves to sell. She has been selling DevAV products since 2012. \r\n\r\nOlivia was homecoming queen in high school. She is expecting her first child in 6 months. Good Luck Olivia.",
//                Email = "oliviap@dx-email.com",
//                Address = "807 W Paseo Del Mar",
//                City = "Los Angeles",
//                Tasks = new[] {
//                    new EmployeeTask {
//                        ID = 3,
//                        Subject = "Update Personnel Files",
//                        StartDate = DateTime.Parse("2013/02/03"),
//                        DueDate = DateTime.Parse("2013/02/28"),
//                        Status = "Completed",
//                        Priority = Priority.High,
//                        Completion = 100
//                    },
//                    new EmployeeTask {
//                        ID = 4,
//                        Subject = "Review Health Insurance Options Under the Affordable Care Act",
//                        StartDate = DateTime.Parse("2013/02/12"),
//                        DueDate = DateTime.Parse("2013/04/25"),
//                        Status = "In Progress",
//                        Priority = Priority.High,
//                        Completion = 50
//                    },
//                    new EmployeeTask {
//                        ID = 21,
//                        Subject = "Non-Compete Agreements",
//                        StartDate = DateTime.Parse("2013/03/12"),
//                        DueDate = DateTime.Parse("2013/03/14"),
//                        Status = "Completed",
//                        Priority = Priority.Low,
//                        Completion = 100
//                    },
//                    new EmployeeTask {
//                        ID = 50,
//                        Subject = "Give Final Approval for Refunds",
//                        StartDate = DateTime.Parse("2013/05/05"),
//                        DueDate = DateTime.Parse("2013/05/15"),
//                        Status = "Completed",
//                        Priority = Priority.Normal,
//                        Completion = 100
//                    }
//                },
//                State = "California",
//                StateID = 5,
//                HomePhone = "(310) 555-4547",
//                Skype = "oliviapDXskype",
//                Picture = "../../Content/Images/employees/09.png"
//            },
//            new Employee {
//                ID = 3,
//                FirstName = "Robert",
//                LastName = "Reagan",
//                Phone = "(818) 555-2387",
//                Prefix = "Mr.",
//                Position = "CMO",
//                BirthDate = DateTime.Parse("1974/09/07"),
//                HireDate = DateTime.Parse("2002/11/08"),
//                Notes = "Robert was recently voted the CMO of the year by CMO Magazine. He is a proud member of the DevAV Management Team.\r\n\r\nRobert is a championship BBQ chef, so when you get the chance ask him for his secret recipe.",
//                Address = "4 Westmoreland Pl.",
//                City = "Bentonville",
//                Tasks = new[] {
//                    new EmployeeTask {
//                        ID = 16,
//                        Subject = "Deliver R&D Plans for 2013",
//                        StartDate = DateTime.Parse("2013/03/01"),
//                        DueDate = DateTime.Parse("2013/03/10"),
//                        Status = "Completed",
//                        Priority = Priority.High,
//                        Completion = 100
//                    },
//                    new EmployeeTask {
//                        ID = 74,
//                        Subject = "Decide on Mobile Devices to Use in the Field",
//                        StartDate = DateTime.Parse("2013/07/30"),
//                        DueDate = DateTime.Parse("2013/08/02"),
//                        Status = "Completed",
//                        Priority = Priority.High,
//                        Completion = 100
//                    },
//                    new EmployeeTask {
//                        ID = 78,
//                        Subject = "Try New Touch-Enabled WinForms Apps",
//                        StartDate = DateTime.Parse("2013/08/11"),
//                        DueDate = DateTime.Parse("2013/08/15"),
//                        Status = "Completed",
//                        Priority = Priority.Normal,
//                        Completion = 100
//                    },
//                    new EmployeeTask {
//                        ID = 117,
//                        Subject = "Approval on Converting to New HDMI Specification",
//                        StartDate = DateTime.Parse("2014/01/11"),
//                        DueDate = DateTime.Parse("2014/01/31"),
//                        Status = "Deferred",
//                        Priority = Priority.Normal,
//                        Completion = 75
//                    }
//                },
//                Email = "robertr@dx-email.com",
//                State = "Arkansas",
//                StateID = 4,
//                HomePhone = "(818) 555-2438",
//                Skype = "robertrDXskype",
//                Picture = "../../Content/Images/employees/03.png"
//            },
//            new Employee {
//                ID = 4,
//                FirstName = "Greta",
//                LastName = "Sims",
//                Phone = "(818) 555-6546",
//                Prefix = "Ms.",
//                Position = "HR Manager",
//                BirthDate = DateTime.Parse("1977/11/22"),
//                HireDate = DateTime.Parse("1998/04/23"),
//                Notes = "Greta has been DevAV's HR Manager since 2003. She joined DevAV from Sonee Corp.\r\n\r\nGreta is currently training for the NYC marathon. Her best marathon time is 4 hours. Go Greta.",
//                Email = "gretas@dx-email.com",
//                Address = "1700 S Grandview Dr.",
//                City = "Atlanta",
//                Tasks = new[] {
//                    new EmployeeTask {
//                        ID = 20,
//                        Subject = "Approve Hiring of John Jeffers",
//                        StartDate = DateTime.Parse("2013/03/02"),
//                        DueDate = DateTime.Parse("2013/03/12"),
//                        Status = "Completed",
//                        Priority = Priority.Normal,
//                        Completion = 100
//                    },
//                    new EmployeeTask {
//                        ID = 23,
//                        Subject = "Update Employee Files with New NDA",
//                        StartDate = DateTime.Parse("2013/03/16"),
//                        DueDate = DateTime.Parse("2013/03/26"),
//                        Status = "Need Assistance",
//                        Priority = Priority.Normal,
//                        Completion = 90
//                    },
//                    new EmployeeTask {
//                        ID = 40,
//                        Subject = "Provide New Health Insurance Docs",
//                        StartDate = DateTime.Parse("2013/03/28"),
//                        DueDate = DateTime.Parse("2013/04/07"),
//                        Status = "Completed",
//                        Priority = Priority.Normal,
//                        Completion = 100
//                    }
//                },
//                State = "Georgia",
//                StateID = 11,
//                HomePhone = "(818) 555-0976",
//                Skype = "gretasDXskype",
//                Picture = "../../Content/Images/employees/04.png"
//            },
//            new Employee {
//                ID = 5,
//                FirstName = "Brett",
//                LastName = "Wade",
//                Phone = "(626) 555-0358",
//                Prefix = "Mr.",
//                Position = "IT Manager",
//                BirthDate = DateTime.Parse("1968/12/01"),
//                HireDate = DateTime.Parse("2009/03/06"),
//                Notes = "Brett came to DevAv from Microsoft and has led our IT department since 2012.\r\n\r\nWhen he is not working hard for DevAV, he coaches Little League (he was a high school pitcher).",
//                Email = "brettw@dx-email.com",
//                Address = "1120 Old Mill Rd.",
//                City = "Boise",
//                Tasks = new[] {
//                    new EmployeeTask {
//                        ID = 2,
//                        Subject = "Prepare 3013 Marketing Plan",
//                        StartDate = DateTime.Parse("2013/01/01"),
//                        DueDate = DateTime.Parse("2013/01/31"),
//                        Status = "Completed",
//                        Priority = Priority.High,
//                        Completion = 100
//                    },
//                    new EmployeeTask {
//                        ID = 11,
//                        Subject = "Rollout of New Website and Marketing Brochures",
//                        StartDate = DateTime.Parse("2013/02/20"),
//                        DueDate = DateTime.Parse("2013/02/28"),
//                        Status = "Completed",
//                        Priority = Priority.High,
//                        Completion = 100
//                    },
//                    new EmployeeTask {
//                        ID = 15,
//                        Subject = "Review 2012 Sales Report and Approve 2013 Plans",
//                        StartDate = DateTime.Parse("2013/02/23"),
//                        DueDate = DateTime.Parse("2013/02/28"),
//                        Status = "Completed",
//                        Priority = Priority.Normal,
//                        Completion = 100
//                    },
//                    new EmployeeTask {
//                        ID = 81,
//                        Subject = "Review Site Up-Time Report",
//                        StartDate = DateTime.Parse("2013/08/24"),
//                        DueDate = DateTime.Parse("2013/08/30"),
//                        Status = "Completed",
//                        Priority = Priority.Urgent,
//                        Completion = 100
//                    }
//                },
//                State = "Idaho",
//                StateID = 13,
//                HomePhone = "(626) 555-5985",
//                Skype = "brettwDXskype",
//                Picture = "../../Content/Images/employees/05.png"
//            }
//        };
//    }
//}