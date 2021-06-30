using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNovaVida.Controllers
{
    public class MasterController : Controller
    {
        public IConfiguration _configuration;
        public string _connectionString;        

        public void ConfigurarAplicacao()
        {
            this._connectionString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }
        public void MostraErro(string Mensagem)
        {
            TempData["MostraErro"] = Mensagem;
        }
        public void MostraSucesso(string Mensagem)
        {
            TempData["MostraSucesso"] = Mensagem;            
        }
        public void MostraInfo(string Mensagem)
        {
            TempData["MostraInfo"] = Mensagem;            
        }

    }
}
