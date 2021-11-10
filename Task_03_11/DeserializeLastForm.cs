using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_03_11
{

    public class DeserializeLastForm : Base
    {
        private string path = "";
        private FileInfo file;

        private List<ISerializePlugin> pluginsList = new List<ISerializePlugin>();
        public DeserializeLastForm(List<ISerializePlugin> pluginsList)
        {
            this.pluginsList = pluginsList;
        }
        public void FindFile()
        {
            var dirInfo = new DirectoryInfo($"C:/forms/");
            file = dirInfo.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
            path = file.ToString();

        }
        public void SelectOption()
        {
            FindFile();
            string fileName = file.Name;
            string[] subs = fileName.Split('.');

            foreach (var item in pluginsList)
            {
                if (subs[1] == (item.Name).ToLower())
                {
                    Deserialization(item);
                }
               
            }
        }


        public void Deserialization(ISerializePlugin plugin)
        {
            Person person = plugin.Deserialize(path);

            Type type = typeof(Person);
            Dictionary<string, string> dictionaryOfQuestions = ParseAttributes();

            foreach (var (key, value) in dictionaryOfQuestions)
            {
                switch (key)
                {
                    case "Name":
                        Console.WriteLine(value);
                        Console.WriteLine(person.Name);
                        break;
                    case "Surname":
                        Console.WriteLine(value);
                        Console.WriteLine(person.Surname);
                        break;
                    case "DateOfBirth":
                        Console.WriteLine(value);
                        Console.WriteLine(person.DateOfBirth);
                        break;
                    case "SelectedSex":
                        Console.WriteLine(value);
                        Console.WriteLine(person.SelectedSex);
                        break;
                    case "IsMarried":
                        Console.WriteLine(value);
                        Console.WriteLine(person.IsMarried);
                        break;
                    default:
                        break;
                }

            }

        }

    }
}
