using MileVendas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MileVendas.Context
{
    public class MVContext: DbContext
    {
        public MVContext() : base("dbconf")
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoCapa> PedidoCapas { get; set; }
    }
}