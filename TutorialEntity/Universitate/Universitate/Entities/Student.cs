using System.Collections.Generic;

namespace Universitate.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string Nume { get; set; }

        public Facultate Facultate { get; set; }

        public ICollection<CursStudentLink> CursStudentLink { get; set; }

    }
}