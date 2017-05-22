using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrixUsersManagement.Models
{

    public enum Method
    {
        phone, mail, address
    }

    public class ContactDetails
    {
        public int ContactDetailsID { get; set; } // primary key

        public int OwnerUserID { get; set; } // foriegn key
        public Method method { get; set; } 
        public string details { get; set; }
        
        public User Owner { get; set; } // navigation property
        


    }
}
