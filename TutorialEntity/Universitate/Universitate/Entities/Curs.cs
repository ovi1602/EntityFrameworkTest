using System.Collections;
using System.Collections.Generic;

namespace Universitate.Entities
{
    public class Curs
    {
        public int Id { get; set; }

        public string Nume { get; set; }

        public Profesor Profesor { get; set; }

        public Facultate Facultate { get; set; }

        public ICollection<CursStudentLink> CursStudentLink { get; set; }


    }
}