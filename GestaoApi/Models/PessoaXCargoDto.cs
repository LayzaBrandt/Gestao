using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApi.Models
{
    public class PessoaXCargoDto
    {
        public long Id { get; set; }
        public long IdCargo { get; set; }
        public string? DescricaoCargo { get; set; }

        public Cargo? Cargo { get; set; }
    }
}