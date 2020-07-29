using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MileVendas.Models
{
    [Table("Testes")]
    public class Teste
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}