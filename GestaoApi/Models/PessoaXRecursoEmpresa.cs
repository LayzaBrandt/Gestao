using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApi.Models
{
    public class PessoaXRecursoEmpresa
    {
        public long Id { get; set; }

        public RecursoEmpresa? IdRecurso {get; set;}

         public long IdPessoa {get; set;}
        public Pessoa? Pessoa {get; set;}
    }
}