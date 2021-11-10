using System;
using System.Collections.Generic;
using System.Reflection;

namespace Task_03_11
{
    public class Base
    {
        public Dictionary<string, string> ParseAttributes()
        {


            Dictionary<string, string> _dict = new Dictionary<string, string>();

            var properties = typeof(Person).GetProperties();
            foreach (var property in properties)
            {
                string propertyName = property.Name;
                PropertyInfo propertyInfo = typeof(Person).GetProperty(property.Name);
                PersonDescriptionAttribute PersonDescriptionAttribute = (PersonDescriptionAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(PersonDescriptionAttribute));
                if (PersonDescriptionAttribute != null)
                {
                    string atributeName = PersonDescriptionAttribute.Description;
                    _dict.Add(propertyName, atributeName);

                }

            }
            return _dict;
        }
       
    }
}
