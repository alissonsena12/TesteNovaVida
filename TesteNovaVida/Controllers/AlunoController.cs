using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using ModelFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteNovaVida.Util;

namespace TesteNovaVida.Controllers
{
    public class AlunoController : MasterController
    {
        private readonly AlunoBLL oBLL;
        private readonly ProfessorBLL pBLL;
        public AlunoController(IConfiguration configuration)
        {
            this._configuration = configuration;
            ConfigurarAplicacao();
            this.oBLL = new AlunoBLL(_connectionString);
            this.pBLL = new ProfessorBLL(_connectionString);
        }
        public IActionResult Index(int? idProfessor = null)
        {
            var alunos = idProfessor == null ?
                oBLL.SelecionarTodos() :
                oBLL.SelecionarPorProfessor(idProfessor.Value);

            if (idProfessor != null)
            {
                ViewBag.Professor = pBLL.SelecionarProfessor(idProfessor.Value);
            }
            return View(alunos);
        }
        public void CarregaViewBagsCadastrar()
        {
            ViewBag.Professores = pBLL.SelecionarTodos()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Nome
                }).ToList();
        }
        public IActionResult Cadastrar(int? idProfessor = null)
        {            
            var aluno = new Aluno();
            if (idProfessor != null)
            {
                aluno.Professor = pBLL.SelecionarProfessor(idProfessor.Value);
            }
            CarregaViewBagsCadastrar();
            return View(aluno);
        }
        [HttpPost]
        public IActionResult Cadastrar(Aluno aluno)
        {
            CarregaViewBagsCadastrar();
            var permiteLote = PermiteLote(aluno);
            if (!permiteLote.Sucesso)
            {
                MostraInfo(permiteLote.Mensagem);
                return View(aluno);
            }
            var validacao = oBLL.Cadastrar(aluno);
            if (validacao.Sucesso)
            {
                MostraSucesso("Cadastro realizado com sucesso");
                if(aluno.Anexo != null)
                {
                    var data = DateTime.Now.AddSeconds(RetornaTempoPermiteLote());
                    HttpContext.Session.SetObject<DateTime>($"PROFESSOR_{aluno.Professor.Id}", data);
                }
                return RedirectToAction("Cadastrar");
            }
            MostraErro(validacao.Mensagem);
            return View(aluno);
        }
        [HttpPost]        
        public JsonResult Excluir(int idAluno)
        {
            var retorno = oBLL.ExcluirAluno(idAluno);
            return Json(retorno);            
        }
        public RetornaValidacao PermiteLote(Aluno aluno)
        {
            var retorno = new RetornaValidacao();
            retorno.Sucesso = true;
            if(aluno.Anexo != null)
            {
                var dataLote = HttpContext.Session.GetObject<DateTime>($"PROFESSOR_{aluno.Professor.Id}");
                if(dataLote > DateTime.Now && dataLote != DateTime.MinValue)
                {
                    retorno.Sucesso = false;
                    retorno.Mensagem = $"Você realizou um cadastro de lote com este professor a pouco tempo, você poderá fazer novamente outro lote em {dataLote.ToString()}";
                }
            }
            return retorno;
        }
        public int RetornaTempoPermiteLote()
        {
            return int.Parse(_configuration.GetValue<string>("TimeOutImportacao"));
        }
    }
}
