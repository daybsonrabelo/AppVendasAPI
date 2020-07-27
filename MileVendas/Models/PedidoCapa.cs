using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MileVendas.Models
{
    [Table("PedidosCapa")]
    public class PedidoCapa
    {
        [Key]
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string CepOrigem { get; set; }
        public string CepDestino { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal PesoTotal { get; set; }
        public decimal ComissaoTotal { get; set; }
        public DateTime DataPedido { get; set; }
        public int Status { get; set; }
    }
}