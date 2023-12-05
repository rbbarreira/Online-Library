using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Exercicio1
{
    class Program : Utilizadores
    {  
        static void Main(string[] args)
        {
            List<Utilizadores> Perfil = new List<Utilizadores>();
            Utilizadores perfil1 = new()
            {
                AccessLevel = 1,
                UserName = "p",
                Password = "p"
            };
            Perfil.Add(perfil1);
            Utilizadores perfil2 = new()
            {
                AccessLevel = 2,
                UserName = "Ana",
                Password = "111"
            };
            Perfil.Add(perfil2);
            Utilizadores perfil3 = new()
            {
                AccessLevel = 2,
                UserName = "Rui",
                Password = "222"
            };
            Perfil.Add(perfil3);

            List<Utilizadores> Leitor = new List<Utilizadores>();
            Utilizadores leitor1 = new()
            {
                AccessLevel = 3,
                UserName = "Ze",
                Password = "333"
            };
            Leitor.Add(leitor1);
            Utilizadores leitor2 = new()
            {
                AccessLevel = 3,
                UserName = "To",
                Password = "444"
            };
            Leitor.Add(leitor2);

            List<Livros> Livros = new List<Livros>();
            Livros livros1 = new()
            {
                IdSeq = 1,
                NomeLivro = "Monte Carlo"
            };
            Livros.Add(livros1);
            Livros livros2 = new()
            {
                IdSeq = 2,
                NomeLivro = "A Princesa"
            };
            Livros.Add(livros2);
            Livros livros3 = new()
            {
                IdSeq = 3,
                NomeLivro = "Anjos e Demónios"
            };
            Livros.Add(livros3);
            Livros livros4 = new()
            {
                IdSeq = 4,
                NomeLivro = "História D´Arte"
            };
            Livros.Add(livros4);

            List<string> LivrosEntregues = new List<string>();

        Menu1:
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

            switch (menuSelecao)
            {
                case 1:   
                    Console.Clear();
                    do
                    {
                        validar = false;
                        Console.WriteLine("\nLOGIN");
                        Console.Write("\nUsername: ");
                        string username = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();

                        foreach (Utilizadores perfil in Perfil)
                        {
                            if (username == perfil.UserName)                            
                                if (password == perfil.Password)
                                {
                                    lerResultados = "true";
                                    Nivel = perfil.AccessLevel;
                                } 
                        }

                        foreach (Utilizadores leitor in Leitor)
                        {
                            if (username == leitor.UserName)                            
                                if (password == leitor.Password)
                                {
                                    lerResultados = "true";
                                    Nivel = leitor.AccessLevel;
                                }
                        }

                        if(lerResultados == "true")
                        {
                            Console.WriteLine("\nLogin com sucesso");
                            Console.WriteLine("Prima qualquer tecla para continuar.");
                            Console.ReadLine();
                            validar = true;
                        }
                        else                        
                            Console.WriteLine("\nUtilizador ou Password inválido(a)");
                        

                    } while (validar == false);
                    break;
                case 2:
                    Console.WriteLine("\nRegisto de novo utilizador");
                    Console.WriteLine("Prima qualquer tecla para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    CriarLeitor(Leitor);
                    goto Menu1;               
                case 3:                    
                    Console.WriteLine($"Selecionou a opção Exit. \nPrograma vai encerrar!");
                    Console.WriteLine("Prima qualquer tecla para continuar.");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
            }

            Menu2:
            Menu2();

            switch (menuSelecao)
            {
                case 1:                    
                    Console.Clear();
                    if (Nivel < 2)                    
                        CriarColaborador(Perfil);                    
                    else                    
                        NaoAutorizado();                    
                    goto Menu2;                    
                case 2:                    
                    Console.Clear();
                    if (Nivel < 2)                    
                        ListarColaborador(Perfil);                    
                    else                    
                        NaoAutorizado();                    
                    goto Menu2;
                case 3:                    
                    Console.Clear();
                    if (Nivel < 3)                    
                        CriarLeitor(Leitor);                    
                    else                    
                        NaoAutorizado();                    
                    goto Menu2;
                case 4:                    
                    Console.Clear();
                    if (Nivel < 3)                    
                        ListarLeitor(Leitor);                    
                    else                    
                        NaoAutorizado();                    
                    goto Menu2;
                case 5:                    
                    Console.Clear();
                    if (Nivel < 3)                    
                        ApagarLeitor(Leitor);                    
                    else                    
                        NaoAutorizado();                    
                    goto Menu2;
                case 6:
                    Console.Clear();
                    if (Nivel < 3)
                        AdicionarLivros(Livros);
                    else
                        NaoAutorizado();
                    goto Menu2;
                case 7:
                    Console.Clear();
                    if (Nivel < 3)
                        ListarLivros(Livros);
                    else
                        NaoAutorizado();
                    goto Menu2;
                case 8:
                    Console.Clear();
                    if (Nivel < 3)
                        ApagarLivros(Livros);
                    else
                        NaoAutorizado();
                    goto Menu2;
                case 9:
                    Console.Clear();
                    if (Nivel < 3)
                        AtribuirLivros(Livros, Leitor, LivrosEntregues);
                    else
                        NaoAutorizado();
                    goto Menu2;
                case 10:
                    Console.Clear();
                    if (Nivel < 3)
                        VerLivrosAtribuidos(LivrosEntregues);
                    else
                        NaoAutorizado();
                    goto Menu2;
                case 11:
                    Console.WriteLine($"Logout com sucesso!");
                    Console.WriteLine("Prima qualquer tecla para continuar.");
                    Console.ReadLine();
                    goto Menu1;

            } while (menuSelecao != 11);
        }
    }
}
