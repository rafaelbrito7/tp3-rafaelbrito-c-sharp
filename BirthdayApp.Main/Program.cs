using System;
using Utils;
using Service;
using System.Collections.Generic;

namespace BirthdayApp.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            MainMenu();
            Console.WriteLine("FIM");
        }

        public static void MainMenu() 
        {   
            Console.WriteLine("Gerenciamento de Aniversários");
            Console.WriteLine("1 - Pesquisar pessoas");
            Console.WriteLine("2 - Adicionar nova pessoa");
            Console.WriteLine("3 - Sair");
            var optionSelected = int.Parse(ReadString("Escolha uma opção: "));
            
            switch(optionSelected) 
            {
                case 1: 
                FindPerson();
                break;

                case 2: 
                NewPerson();
                break;

                case 3:
                break;
            }
        }
        
        static void FindPerson()
        {
            string name = ReadString("Digite o nome da pessoa que você deseja pesquisar: ");
            int option = 0;
            var people = PersonService.GetPersonByName(name);

            if (people.Status == false) {
                Console.WriteLine(people.Message);

                MainMenu();
            };

            int contador = 1;
                foreach (var person in people.People)
                {
                    Console.WriteLine($"{contador} - {person.Fullname}");
                    contador++;
                }
                option = int.Parse(ReadString("Escolha qual pessoa você deseja saber o aniversário: "));


                while(option < 1 | option > people.People.Count) {
                    Console.WriteLine("Opção inválida");
                    option = int.Parse(ReadString("Escolha qual pessoa você deseja saber o aniversário: "));
                }

                var chosenPerson = people.People[option - 1];

                Console.Clear();

                var chosenPersonsBirthday = chosenPerson.DaysForBirthday();


                if(chosenPersonsBirthday == 0) {
                    Console.WriteLine($"É aniversário de {chosenPerson.Fullname}! Deseje Parabéns!\n");
                } else {
                    Console.WriteLine($"{chosenPerson.ToString()}  | Dias restantes para o aniversário: {PersonService.GetTimeForBirthday(chosenPerson)}\n");
                }

                MainMenu();
        }

        static void NewPerson() 
        {
            int option = 2;
            string firstName = "";
            string lastName = "";
            string birthday = "";

            while(option == 2) 
            {
                firstName = ReadString("Digite o primeiro nome da pessoa que deseja adicionar: ");
                lastName = ReadString("Digite o sobrenome da pessoa que deseja adicionar: ");
                birthday = ReadString("Digite a data de aniversário no formato dd/MM/yyyy: ");

                while(ApplicationUtils.checkDate(birthday) == false)
                {
                    Console.WriteLine("Data inválida.");
                    birthday = ReadString("Digite a data de aniversário no formato dd/MM/yyyy: ");
                }

                Console.WriteLine("Os dados abaixo estão corretos?");
                Console.WriteLine($"Nome: {firstName} {lastName}");
                Console.WriteLine($"Data do aniversário: {birthday}" );
                option = int.Parse(ReadString("1 - Sim  /  2 - Não: "));

                Console.Clear();
            }
            
            DateTime birthdayConverted = Convert.ToDateTime(birthday);
                
            var newPerson = PersonService.AddNewPerson(firstName, lastName, birthdayConverted);

            Console.WriteLine($"{newPerson}\n");
             
            MainMenu();
        }

        static string ReadString(string msg) 
        {
            Console.Write(msg);
            return Console.ReadLine();
        }
    }
}
