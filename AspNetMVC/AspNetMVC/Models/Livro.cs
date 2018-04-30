using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMVC.Models
{
    public class Livro
    {
        [Required(ErrorMessage = "Código é obrigatório")]
        public int ID { get; set; }

        [Required(ErrorMessage = "O Título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Autor é obrigatório")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O Ano é obrigatório")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "O Ano deve possuir 4 números!")]
        public int AnoPublicacao { get; set; }


        public List<Livro> GetLivros()
        {
            return new List<Livro>
            {
                new Livro {
                    ID =1,
                    Titulo = "DDD",
                    Autor="Eric Evans",
                    AnoPublicacao=2003
                },
                new Livro {
                    ID =2,
                    Titulo = "Agile",
                    Autor="Robert C. Martins",
                    AnoPublicacao=2008
                }
                ,
                new Livro {
                    ID =3,
                    Titulo = "Clean Code",
                     Autor="Robert C. Martins",
                    AnoPublicacao=2008
                }
            };

        }




    }
}