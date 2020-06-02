using System;
using Repository;
using Model;
using Responses;
using System.Collections.Generic;

namespace Service
{
    public class PersonService
    {
        public static string AddNewPerson(string firstname, string lastname, DateTime birthday) 
        {
            try
            {
                if (firstname == "" | lastname == "")
                    throw new Exception("Por favor, forneça ambos os campos os nome e sobrenome.");

                Person person = new Person(firstname, lastname, birthday);

                PersonRepository.AddNewPerson(person);

                return "Pessoa adicionada com sucesso!";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public static GetByNameResponse GetPersonByName(string name) 
        {
            try
            {
                if(name == "")
                    throw new Exception("Por favor, forneça o nome da pessoa que deseja procurar");

                List<Person> people = PersonRepository.GetPersonByName(name);

                if(people.Count == 0)
                    throw new Exception("Pessoa não encontrada!");

                return new GetByNameResponse { Status = true, People = people, Message = "Busca realizada com sucesso!"};
            }

            catch (Exception exception)
            {
                return new GetByNameResponse { Status = false, Message = exception.Message };
            }
        }

        public static int GetTimeForBirthday(Person person) {
            return PersonRepository.GetTimeForBirthday(person);
        }
    }
}
