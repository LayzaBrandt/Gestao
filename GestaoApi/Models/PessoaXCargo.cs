using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoApi.Models
{
    public class PessoaXCargo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long IdPessoa { get; set; }
        
         [JsonIgnore]
        public Pessoa? Pessoa { get; set; }

        public long IdCargo { get; set; }

         [JsonIgnore]
        public Cargo? Cargo { get; set; }
    }
}