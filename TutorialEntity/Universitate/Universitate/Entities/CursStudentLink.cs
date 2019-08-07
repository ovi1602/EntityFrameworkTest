using System;
using System.Collections.Generic;
using System.Text;

namespace Universitate.Entities
{
    public class CursStudentLink
    {
        public Curs curs { get; set; }
        public int cursId { get; set; }
        public Student student { get; set; }
        public int studentId { get; set; }
    }
}
