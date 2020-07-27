using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MileVendas.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Grupo { get; set; }
        public string SubGrupo { get; set; }
        public int Peso { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Comissao { get; set; }
        public int Quantidade { get; set; }
    }
}