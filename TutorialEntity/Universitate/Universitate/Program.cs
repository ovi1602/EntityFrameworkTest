
using System;
using Universitate.Context;
using Universitate.Entities;

namespace Universitate
{
    class Program
    {
        static void Main(string[] args)
        {
            var univContext = new UniversitateContext();
            AdaugaFacultate(univContext, "Automematica si dankulatoare");
        }

        private static void AdaugaFacultate(UniversitateContext univContext, string name)
        {
            var Facultate = new Facultate();
            Facultate.Nume = name;
            univContext.Facultati.Add(Facultate);
            univContext.SaveChanges();
        }
    }
}
