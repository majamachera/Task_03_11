using System;
using System.ComponentModel.DataAnnotations;
using static ModelLibrary.EnumClass;

namespace Task_03_11
{
    public class Person
    {
        public Person()
        {
            UniqueId = Guid.NewGuid();
        }

        [PersonDescription("What is your name? ")]
        public string Name { get; set; }
        [PersonDescription("What is your surname? ")]
        public string Surname { get; set; }
        [PersonDescription("When were you born? ")]

        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public string DateOfBirth { get; set; }
        
        [PersonDescription("What is your gender? ")]
        public Sex SelectedSex { get; set; }
        [PersonDescription("Are you married? ")]
        public bool IsMarried  { get; set; }
        public Guid UniqueId {get; set; }
       

    }
}

