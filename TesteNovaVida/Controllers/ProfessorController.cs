using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ModelFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNovaVida.Controllers
{
    public class ProfessorController : MasterController
    {        
        private readonly ProfessorBLL oBLL;
        public ProfessorController(IConfiguration configuration)
        {
            this._configuration = configuration;
            ConfigurarAplicacao();
            this.oBLL = new ProfessorBLL(_connectionString);
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }
        public IActionResult Cadastrar()
        {            
            return View(new Professor());
        }
        [HttpPost]
        public IActionResult Cadastrar(Professor professor)
        {
            if (ModelState.IsValid)
            {
                var validacao = oBLL.Cadastrar(professor);
                if (validacao.Sucesso)
                {
                    MostraSucesso("Cadastro realizado com sucesso");
                    return RedirectToAction("Cadastrar");
                }
                MostraErro(validacao.Mensagem);
            }
            return View(professor);
        }
    }
}
