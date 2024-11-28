using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApi.Models
{
    public class Produto
    {
         public long Id { get; set; }

         public EstadoDoProduto? IdEstadoDoProduto {get;set;}

         public string? Descricao {get;set;}
    }
}