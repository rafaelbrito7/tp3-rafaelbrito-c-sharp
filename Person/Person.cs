using System;

namespace Model
{
    public class Person
    {
        public string Firstname {get; set;}
        public string Lastname {get; set;}
        public string Fullname {get; set;}
        public DateTime Birthday {get; set;}
        public Person(string firstname, string lastname, DateTime birthday)
        {
            Firstname = firstname;
            Lastname = lastname;
            Birthday = birthday;
            Fullname = $"{firstname} {lastname}";
        }

        public override string ToString() 
        {
            return $"{this.Fullname} - {this.Birthday}";
        }

        public int DaysForBirthday() 
        {
            DateTime birthday = new DateTime(DateTime.Now.Year, Birthday.Month, Birthday.Day);

            DateTime today = DateTime.Today;
            DateTime next = birthday.AddYears(today.Year - birthday.Year);

            if (next < today)
                next = next.AddYears(1);

            return (next - today).Days;
        }
    }
}
