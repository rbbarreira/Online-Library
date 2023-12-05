using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercicio1
{
    internal class Utilizadores : Livros
    {
        public int AccessLevel { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }        
        
        public static bool login = false;
        public static bool validar = false;
        public static string? lerResultados;
        public static int Nivel = 0;
        public static int menuSelecao = 0;

        public Utilizadores() { }        

        public Utilizadores(int nivel, string username, string password) 
        {        
            
            this.UserName = username;
            this.Password = password;
            nivel = 2;
        }        

        public static void Login()
        {
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\t1. Login ");
                Console.WriteLine("\t2. Registar ");
                Console.WriteLine("              ");
                Console.WriteLine("\t3. Exit");
                Console.WriteLine();

                lerResultados = Console.ReadLine();

                if (lerResultados != null)
                    validar = int.TryParse(lerResultados, out menuSelecao) && menuSelecao > 0 && menuSelecao < 4;

                if (validar == false)
                {
                    Console.WriteLine($"\nEscolheu a opção: {lerResultados} - Inválido");
                    Console.WriteLine("Prima qualquer tecla para continuar!");
                    Console.ReadLine();
                }

                else
                    validar = true;
            }
            while (validar == false);            
        }

        public static void Menu2()
        {
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("*************************************************");
                Console.WriteLine("**                                             **");
                Console.WriteLine("**            BIBLIOTECA ONLINE                **");
                Console.WriteLine("**                                             **");
                Console.WriteLine("*************************************************");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("\t     Administrador ");
                Console.WriteLine(" ");
                Console.WriteLine("\t1. Criar Colaboradores");
                Console.WriteLine("\t2. Listar Colaboradores");
                Console.WriteLine(" ");
                Console.WriteLine("\t     Colaborador ");
                Console.WriteLine(" ");
                Console.WriteLine("\t3. Criar Leitores ");
                Console.WriteLine("\t4. Listar Leitores ");
                Console.WriteLine("\t5. Apagar Leitores");
                Console.WriteLine(" ");
                Console.WriteLine("\t6. Adicionar Livros");
                Console.WriteLine("\t7. Listar Livros");
                Console.WriteLine("\t8. Remover Livros");
                Console.WriteLine("\t9. Atribuir Livro a Leitor");
                Console.WriteLine("\t10. Ver Livros atribuidos");
                Console.WriteLine(" ");
                Console.WriteLine("\t11. Logout");
                Console.WriteLine();

                lerResultados = Console.ReadLine();

                if (lerResultados != null)
                    validar = int.TryParse(lerResultados, out menuSelecao) && menuSelecao > 0 && menuSelecao < 12;

                if (validar == false)
                {
                    Console.WriteLine($"\nEscolheu a opção: {lerResultados} - Inválido");
                    Console.WriteLine("Prima qualquer tecla para continuar!");
                    Console.ReadLine();
                }

                else
                    validar = true;
            }
            while (validar == false);
        }

        public static void NaoAutorizado()
        {
            Console.WriteLine($"Acesso não autorizado.");
            Console.WriteLine("Prima qualquer tecla para continuar.");
            Console.ReadLine();
            Console.Clear();
        }

        public static void CriarColaborador(List<Utilizadores> lst)
        {
            do
            {
                Console.WriteLine("Criar Perfil");
                Console.Write("Nome de Utilizador: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                Utilizadores u = new Utilizadores();
                u.AccessLevel = 2;
                u.UserName = username;
                u.Password = password;

                if (username == "" || password == "")
                {
                    Console.WriteLine($"\nUm dos dados é Inválido");
                    Console.WriteLine("Prima qualquer tecla para continuar!");
                    Console.ReadLine();
                    validar = false;
                }
                else
                {
                    lst.Add(u);
                    Console.WriteLine($"Novo Colaborador adicionado.");
                    Console.WriteLine("Prima qualquer tecla para continuar.");
                    Console.ReadLine();
                    validar = true;
                }

            } while (validar == false);            
        }        

        public static void CriarLeitor(List<Utilizadores> lst1)
        {
            do
            {
                Console.WriteLine("Criar Perfil");
                Console.Write("Nome de Utilizador: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                Utilizadores u = new Utilizadores();
                u.AccessLevel = 3;
                u.UserName = username;
                u.Password = password;

                if (username == "" || password == "")
                {
                    Console.WriteLine($"\nUm dos dados é Inválido");
                    Console.WriteLine("Prima qualquer tecla para continuar!");
                    Console.ReadLine();
                    validar = false;
                }
                else
                {
                    lst1.Add(u);
                    Console.WriteLine($"\nNovo Leitor adicionado.");
                    Console.WriteLine("Prima qualquer tecla para continuar.");
                    Console.ReadLine();
                    validar = true;
                }          

            } while (validar == false);                
        }

        public static void ListarColaborador(List<Utilizadores> lst)
        {
            Console.WriteLine("Lista de Colaboradores: ");
            foreach (Utilizadores u in lst)
            {
                Console.WriteLine("Level: {0} Nome: {1} Password: {2}", u.AccessLevel, u.UserName, u.Password);
            }
            Console.WriteLine("\nPrima qualquer tecla para continuar.");
            Console.ReadLine();           
        }

        public static void ListarLeitor(List<Utilizadores> lst1)
        {
            Console.WriteLine("Lista de Leitores: ");
            foreach (Utilizadores u in lst1)
            {
                Console.WriteLine("Level: {0} Nome: {1} Password: {2}", u.AccessLevel, u.UserName, u.Password);
            }
            Console.WriteLine("\nPrima qualquer tecla para continuar.");
            Console.ReadLine();            
        }

        public static void ApagarLeitor(List<Utilizadores> lst1)
        {
            Console.WriteLine("Nomes: ");
            foreach (Utilizadores u in lst1)
            {
                Console.WriteLine($"Nome: {u.UserName}");
            }

            Console.Write("Indique o Username a remover: ");
            string username = Console.ReadLine();
            int pos = -1;
            for (int i = 0; i < lst1.Count; i++)
                if (lst1[i].UserName == username)
                    pos = i;
            if (pos != -1)
                lst1.RemoveAt(pos);           
        }

        public static void AtribuirLivros(List<Livros> lst, List<Utilizadores> lst1, List<string> LivrosEntregues)
        {
            Console.WriteLine("Lista de Leitores: ");
            foreach (Utilizadores u in lst1)
            {
                Console.WriteLine("Level: {0} Nome: {1} Password: {2}", u.AccessLevel, u.UserName, u.Password);
            }
            
            Console.WriteLine();

            Console.WriteLine("Lista de Livros: ");
            foreach (Livros l in lst)
            {
                Console.WriteLine($"Id: {l.IdSeq} Nome do Livro: {l.NomeLivro}");
            }

            Console.WriteLine();       
            
            Console.Write("Indique o Nome do Leitor: ");
            string username = Console.ReadLine();            
            for (int i = 0; i < lst1.Count; i++)
                if (lst1[i].UserName == username)
                {                    
                    LivrosEntregues.Add(lst1[i].UserName);
                }
            
            Console.Write("Indique o ID do Livro: ");
            int id = Convert.ToInt32(Console.ReadLine());            
            for (int i = 0; i < lst.Count; i++)
                if (lst[i].IdSeq == id)
                {
                    LivrosEntregues.Add(lst[i].NomeLivro);  
                }
            
            Console.Write("Data de Entrega (no formato dd/mm/yyyy): ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());
            LivrosEntregues.Add(data.AddDays(15).Date.ToString());
            
            Console.WriteLine();

            Console.WriteLine("Lista de Livros Entregues: ");
            foreach (string i in LivrosEntregues)
            {
                Console.WriteLine($"  {i} ");
            }

            Console.WriteLine();
            Console.WriteLine("\nPrima qualquer tecla para continuar.");
            Console.ReadLine();
        }

        public static void VerLivrosAtribuidos(List<string> LivrosEntregues)
        {
            Console.WriteLine("Lista de Livros Entregues: ");
            foreach (string i in LivrosEntregues)
            {
                Console.WriteLine($"  {i} ");
            }

            Console.WriteLine();
            Console.WriteLine("\nPrima qualquer tecla para continuar.");
            Console.ReadLine();
        }
    }
}


