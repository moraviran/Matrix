
using MatrixUsersManagement.Models;
using System;
using System.Linq;

namespace MatrixUsersManagement.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ManagementContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{FirstName="Carson",LastName="Alexander",Created=DateTime.Parse("2005-09-01")},
                new User{FirstName="Meredith",LastName="Alonso",Created=DateTime.Parse("2002-09-01")},
                new User{FirstName="Arturo",LastName="Anand",Created=DateTime.Parse("2003-09-01")},
                new User{FirstName="Gytis",LastName="Barzdukas",Created=DateTime.Parse("2002-09-01")},
                new User{FirstName="Yan",LastName="Li",Created=DateTime.Parse("2002-09-01")},
                new User{FirstName="Peggy",LastName="Justice",Created=DateTime.Parse("2001-09-01")},
                new User{FirstName="Laura",LastName="Norman",Created=DateTime.Parse("2003-09-01")},
                new User{FirstName="Nino",LastName="Olivetto",Created=DateTime.Parse("2005-09-01")}
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
            

            var contactdetails = new ContactDetails[]
            {
                new ContactDetails{OwnerUserID=1,method=Method.mail, details="hello@world.com"},
                new ContactDetails{OwnerUserID=1,method=Method.mail, details="012-3456789"},
                new ContactDetails{OwnerUserID=1,method=Method.mail, details="04-7777777"},
                new ContactDetails{OwnerUserID=1,method=Method.mail, details="02-7777777"},
                new ContactDetails{OwnerUserID=2,method=Method.mail, details="דיזינגוף תל אביב"},
                new ContactDetails{OwnerUserID=2,method=Method.mail, details="hello@world.com"},
                new ContactDetails{OwnerUserID=3,method=Method.mail, details="012-3456789"},
                new ContactDetails{OwnerUserID=4,method=Method.mail, details="012-3456789"},
                new ContactDetails{OwnerUserID=5,method=Method.mail, details="דיזינגוף תל אביב"},
            };
            foreach (ContactDetails e in contactdetails)
            {
                context.ContactDetails.Add(e);
            }
            context.SaveChanges();
        }
    }
}