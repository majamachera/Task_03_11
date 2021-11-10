
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static ModelLibrary.EnumClass;
using static Task_03_11.Person;

namespace Task_03_11
{
    public class CreateForm : Base
    {
        private List<ISerializePlugin> pluginsList = new List<ISerializePlugin>();
        public CreateForm(List<ISerializePlugin> pluginsList)
        {
            this.pluginsList = pluginsList;
        }

        public int SelectOption()
        {
            Console.WriteLine("Select which format you prefer");
            int i = 1;
            foreach (var item in pluginsList)
            {

                Console.WriteLine($"{i}   {item.Name}");
                Console.WriteLine(item.Description);
                i++;
            }
            Console.WriteLine("Select which format you prefer");
            int number = Convert.ToInt32(Console.ReadLine());
            int num;
            if (number <= pluginsList.Count)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Wrong number");
                return SelectOption();

            }
        }
        public void SerializeThisForm()
        {

            Person person = NewPerson();
            int number = SelectOption() - 1;
            pluginsList[number].Serialize(person);


        }

        private Person NewPerson()
        {
            Person person = new Person();
            Dictionary<string, string> dictionaryOfQuestions = ParseAttributes();

            foreach (var (key, value) in dictionaryOfQuestions)
            {
                switch (key)
                {
                    case "Name":
                        Console.WriteLine(value);
                        string name = Console.ReadLine();
                        while (!Regex.Match(name, "[a-zA-Z]").Success)
                        {
                            Console.WriteLine("Invalid name, please retry");
                            name = Console.ReadLine();
                        }
                        person.Name = name;
                        break;
                    case "Surname":
                        Console.WriteLine(value);
                        string surname = Console.ReadLine();
                        while (!Regex.Match(surname, "[a-zA-Z]").Success)
                        {
                            Console.WriteLine("Invalid surname, please retry");
                            surname = Console.ReadLine();
                        }
                        person.Surname = surname;
                            break;
                    case "DateOfBirth":
                        Console.WriteLine(value);
                        Console.WriteLine("Date must be of the form: [dd/MM/yyyy]");
                        string DateOfBirth = Console.ReadLine();
                        DateTime dt;
                        while (!DateTime.TryParseExact(DateOfBirth, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                        {
                            Console.WriteLine("Invalid date, please retry");
                            DateOfBirth = Console.ReadLine();
                        }
                        person.DateOfBirth = DateOfBirth;
                        break;
                    case "SelectedSex":
                        Console.WriteLine(value);
                        Console.WriteLine("If female press [1] if male press [0]");
                        int gender = Convert.ToInt32(Console.ReadLine());
                        while (gender != 0 && gender != 1)
                        {
                            Console.WriteLine("Invalid gender, please retry");
                            gender = Convert.ToInt32(Console.ReadLine());
                        }

                        person.SelectedSex = (Sex)gender;
                       
                        break;
                    case "IsMarried":
                        Console.WriteLine(value);
                        Console.WriteLine("If yes press [t] if no press [f]");
                        string marital = Console.ReadLine();
                        while (marital == "f" && marital == "t")
                        {
                          Console.WriteLine("Invalid marital status, please retry");
                          marital = Console.ReadLine();
                          
                        }
                        if (marital.ToLower() == "t")
                            person.IsMarried = true;
                        else if (marital.ToLower() == "f")
                            person.IsMarried = false;

                        break;
                    default:
                        break;

                }
            }
            return person;
        }
    }
}
