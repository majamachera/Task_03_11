using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Task_03_11
{
    public class UserView
    {

        private static List<ISerializePlugin> _plugins = null;
        private static List<ISerializePlugin> ReadExtensions()
        {
            var pluginsList = new List<ISerializePlugin>();
            var files = Directory.GetFiles("plugins", "*.dll");
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), file));
                var pluginTypes = assembly.GetTypes().Where(t => typeof(ISerializePlugin).IsAssignableFrom(t) && !t.IsInterface).ToArray();
                foreach (var item in pluginTypes)
                {
                    var pluginInstance = Activator.CreateInstance(item) as ISerializePlugin;
                    pluginsList.Add(pluginInstance);
                }
            }
            return pluginsList;
        }
        public  void View()
        {

            _plugins = ReadExtensions();

            Console.WriteLine("If you want create form press 0 if you want to watch last one press 1");
            string i = Console.ReadLine();
            switch (i)
            {
                case "0":
                    CreateForm create = new CreateForm(_plugins);
                    create.SerializeThisForm();

                    break;
                case "1":
                    DeserializeLastForm des = new DeserializeLastForm(_plugins);
                    des.SelectOption();
                    break;
                default:
                    Console.WriteLine("Wrong Key, press 0 or 1");
                    View();
                    break;
            }
        }
    }
}
