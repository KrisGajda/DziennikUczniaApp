using System;
using System.Collections.Generic;

namespace DziennikUczniaApp
{
    public abstract class Person
    {
        private string name;
        private string surname;
        public Person(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public string Name
        {
            get 
            {
                return this.name;
            }
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
            }
        }
        public string Surname 
        {
            get 
            {
                return this.surname;
            }
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                {
                    this.surname = value;
                }
            }
        }
    }
}