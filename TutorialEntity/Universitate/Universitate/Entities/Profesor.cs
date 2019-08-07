using System.Collections.Generic;

namespace Universitate.Entities
{
    public class Profesor
    {
        public int Id { get; set; }

        public string Nume { get; set; }

        public ICollection<Curs> Cursuri { get; set; }


    }
}