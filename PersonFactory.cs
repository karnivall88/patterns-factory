using System;
using System.Collections.Generic;

namespace Patterns.Factory
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
       
        
    }
    public class PersonFactory

            {
        private List<Person> persons = new List<Person>();

        internal List<Person> Persons { get => persons; set => persons = value; }

        public void CreatePerson(string name)
            {
                
                persons.Add(new Person(persons.Count,name));
            }
        }
    
    
}