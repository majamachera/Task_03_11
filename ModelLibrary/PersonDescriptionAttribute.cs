using System;

namespace Task_03_11
{
    public class PersonDescriptionAttribute: Attribute
    {
        private string descript;
        public string Description { get { return descript; } }

        public PersonDescriptionAttribute(string description)
        {
            this.descript = description;
        }
        
    }
}
