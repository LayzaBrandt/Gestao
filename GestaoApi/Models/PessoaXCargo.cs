using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoApi.Models
{
    public class PessoaXCargo
    {
        public long Id { get; set; }

        public long IdPessoa { get; set; }
        
         [JsonIgnore]
        public Pessoa? Pessoa { get; set; }

        public long IdCargo { get; set; }

         //[JsonIgnore]
        public Cargo? Cargo { get; set; }
    }
}