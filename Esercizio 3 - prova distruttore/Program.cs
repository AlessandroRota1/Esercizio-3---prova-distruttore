using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_3___prova_distruttore
{
    internal class Program
    {
        static void Main()
        {
            using (Esempio esempio = new Esempio("Hello", 42))
            {
                Console.WriteLine("Stringa: {0}, Numero: {1}", esempio.GetStringa(), esempio.GetNumero());
            } 
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Fine del programma.");
        }
    }

    class Esempio : IDisposable
    {
        private string stringa;
        private int numero;

        public Esempio(string inputStringa, int inputNumero)
        {
            stringa = inputStringa;
            numero = inputNumero;
            Console.WriteLine("Oggetto creato. Stringa: {0}, Numero: {1}", stringa, numero);
        }
        public string GetStringa()
        {
            return stringa;
        }
        public int GetNumero()
        {
            return numero;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Esempio()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Console.WriteLine("Risorse gestite rilasciate.");
            }
            Console.WriteLine("Risorse non gestite rilasciate.");
        }
    }
}

