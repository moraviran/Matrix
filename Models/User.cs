using System;
using System.Collections.Generic;

namespace MatrixUsersManagement.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Created { get; set; }

        public ICollection<ContactDetails> ContactMethods { get; set; }//navigation property - one to many user.friend - all the friendships himself

    }
}
