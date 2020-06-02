using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model;


namespace Repository
{
    public static class PersonRepository
    {
        public static List<Person> peopleList = new List<Person>();
        public static void AddNewPerson(Person person) 
        {
            peopleList.Add(person);
        }
        public static List<Person> GetPersonByName(string name) 
        {
            List<Person> peopleFound = new List<Person>();

            foreach (Person person in peopleList)
            {
                if (person.Fullname.Contains(name, StringComparison.InvariantCultureIgnoreCase)) 
                {
                    peopleFound.Add(person);
                }
            }
            return peopleFound;
        }

        public static int GetTimeForBirthday(Person person) {
            return person.DaysForBirthday();
        } 
    }
}
