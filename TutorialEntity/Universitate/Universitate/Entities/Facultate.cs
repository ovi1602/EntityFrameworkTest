using System;
using System.Collections.Generic;
using System.Text;

namespace Universitate.Entities
{
    public class Facultate
    {

        public int Id { get; set; }
        public string Nume { get; set; }
        public ICollection<Student> Studenti { get; set; }

        public ICollection<Curs> Cursuri { get; set; }

        public Facultate() { Studenti = new List<Student>(); Cursuri = new List<Curs>();}

    }
}
