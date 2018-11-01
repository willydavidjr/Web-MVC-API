using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI1.Models
{
    public class Person
    {
        public Person()
        {

        }

        public Person(int ID)
        {
            this.ID = ID;    
        }

        public Person(int ID, string strName)
        {
            this.ID = ID;
            this.Name = strName;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

    }
}