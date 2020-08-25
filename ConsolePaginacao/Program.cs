using PaginacaoEntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsolePaginacao
{
    class Program
    {
        public static List<Usuario> UsuariosDB { get; set; } = new List<Usuario>
            {
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Jorge"
                },
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Luiz"
                },
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Marcos"
                },
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Manuel"
                },
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Edson"
                },
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Willian"
                },
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Afif"
                },
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Ricardo"
                },
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Adriano"
                },
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Rodrigo"
                }
            };
        static void Main(string[] args)
        {

            int currentPage = 1;
            do
            {

                var pagedResult = PagedLoad(currentPage, 100);
                Apresentar("#### Usuários ####");
                foreach (var item in pagedResult.Results)
                {
                    Apresentar("############################################################################");
                    Apresentar($"# Usuário ID = {item.Id} | Name = {item.Nome} #");
                }
                Apresentar($"({currentPage}) {pagedResult.FirstRowOnPage} | {pagedResult.LastRowOnPage} ({pagedResult.PageSize})");
                if (currentPage > 1)
                {
                    Apresentar("(A)nterior | (P)róximo - (S)air");
                }
                else
                {
                    Apresentar("(P)róximo - (S)air");
                }

                currentPage += OquePressionei(Console.ReadKey().KeyChar.ToString());
            } while (!Console.ReadLine().Equals("S"));
        }

        private static PagedResult<Usuario> PagedLoad(int currentPage, int pageSize)
        {
            return UsuariosDB.AsQueryable().GetPaged(currentPage, pageSize);
        }

        private static int OquePressionei(string keyChar)
        {
            return Regex.Match(keyChar, @"[A-Z]").Success ? 1 : -1;
        }

        private static void Apresentar(string v)
        {
            Console.WriteLine(v);
        }
    }

    internal class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
