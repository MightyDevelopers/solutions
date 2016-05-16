using System;

namespace SolutionsAI.Data
{
    public class User
    {
        public int Id { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
