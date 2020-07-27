using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using MileVendas.Models;
using MileVendas.WSCorreios;

namespace MileVendas.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CorreiosController : ApiController
    {
        // GET: api/Correios
        [ResponseType(typeof(CorreioResultado))]
        public IHttpActionResult GetPrecoPrazo(string tipoEntrega, string cepOrigem, string cepDestino, string peso, int altura, int largura, int comprimento)
        {
            CorreioResultado correioResultado;
            using (var correios = new CalcPrecoPrazoWSSoapClient())
            {
                //var resposta = correios.CalcPrecoPrazo(String.Empty, String.Empty, "04014", "69895000", "68682000", "3", 1, 30, 30, 30, 0, "N", 0, "N");
                int formato = 1;//caixa
                int diametro = 0;
                string maoPropria = "N";
                decimal valorDeclarado = 0;
                string avisoRecebimento = "N";

                var resposta = correios.CalcPrecoPrazo(String.Empty, String.Empty, tipoEntrega, cepOrigem, cepDestino, peso, formato, comprimento, altura, largura, diametro, maoPropria, valorDeclarado, avisoRecebimento);

                correioResultado = new CorreioResultado();

                correioResultado.codigoField = resposta.Servicos[0].Codigo.ToString();
                correioResultado.valorField = resposta.Servicos[0].ValorSemAdicionais;
            }

            if(correioResultado == null)
            {
                return NotFound();
            }

            return Ok(correioResultado);
        }
    }
}
