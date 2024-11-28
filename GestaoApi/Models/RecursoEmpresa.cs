using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApi.Models
{
    public class RecursoEmpresa
    {
         public long Id { get; set; }

         public Produto? IdProduto {get;set;}

         public DateTime DataRetirada {get;set;} 
         
         public DateTime? DataDevolucao {get;set;} 

    }
}