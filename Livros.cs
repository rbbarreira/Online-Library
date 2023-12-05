using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    public class Livros
    {
        public static int IdLivro = 5;
        public string NomeLivro { get; set; }
        public int IdSeq;

        public string Leitor { get; set; }
        public string Livro { get; set; }
        public string DataEntrega { get; set; }

        public static bool validar = false;

        public Livros() { }

        public Livros(string nomeLivro)
        {            
            this.NomeLivro = nomeLivro;  
            this.IdSeq = IdLivro;
            IdLivro++;
        }        

        public Livros(string leitor, string livro, string dataEntrega)
        {
            this.Leitor = leitor;
            this.Livro = livro;
            this.DataEntrega = dataEntrega;
        }

        public static void AdicionarLivros(List<Livros> lst)
        {
            do
            {
                Console.WriteLine("Adicionar Livros");               
                Console.Write("\nNome do Livro: ");
                string nomeLivro = Console.ReadLine();
                Livros l = new Livros();
                l.NomeLivro = nomeLivro;
                l.IdSeq = IdLivro;               

                if (nomeLivro == "")
                {
                    Console.WriteLine($"\nIntroduza um valor");
                    Console.WriteLine("Prima qualquer tecla para continuar!");
                    Console.ReadLine();
                    validar = false;
                }
                else
                {
                    lst.Add(l);
                    Console.WriteLine($"Novo Livro adicionado.");
                    Console.WriteLine("Prima qualquer tecla para continuar.");
                    Console.ReadLine();
                    validar = true;
                }

            } while (validar == false);

            IdLivro++;
        }

        public static void ListarLivros(List<Livros> lst)
        {
            Console.WriteLine("Lista de Livros: ");
            foreach (Livros l in lst)
            {
                Console.WriteLine($"Id: {l.IdSeq} Nome do Livro: {l.NomeLivro}");
            }
            Console.WriteLine("\nPrima qualquer tecla para continuar.");
            Console.ReadLine();
        }

        public static void ApagarLivros(List<Livros> lst)
        {
            Console.WriteLine("Livros: ");
            foreach (Livros l in lst)
            {
                Console.WriteLine($"Id: {l.IdSeq} Nome do Livro: {l.NomeLivro}");
            }

            Console.Write("Indique o ID a remover: ");
            int id = Convert.ToInt32(Console.ReadLine());
            int pos = -1;
            for (int i = 0; i < lst.Count; i++)
                if (lst[i].IdSeq == id)
                    pos = i;
            if (pos != -1)
                lst.RemoveAt(pos);
        }
    }
}
