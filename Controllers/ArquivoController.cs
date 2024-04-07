using ApiMyArquivos.Core.Models;
using ApiMyArquivos.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace ApiMyArquivos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArquivoController : ControllerBase
    {
        private readonly ArquivoRepository _repo;

        public ArquivoController(ArquivoRepository repo)
        {
            _repo = repo;
        }

        [HttpPost(ArquivoAPI.Cadastrar)]
        public async Task<IActionResult> Cadastrar([FromBody] Arquivo arquivo)
        {
            var result = await _repo.Cadastrar(arquivo);
            return Ok(result);
        }

        [HttpPut(ArquivoAPI.Atualizar)]
        public async Task<IActionResult> Atualizar([FromBody] Arquivo arquivo)
        {
            var result = await _repo.Atualizar(arquivo);
            return Ok(result);
        }
        
        [HttpDelete(ArquivoAPI.Exluir + "/{arquivoId}")]
        public async Task<IActionResult> Excluir([FromRoute] int arquivoId)
        {
            var result = await _repo.Excluir(arquivoId);
            return Ok(result);
        }

        [HttpGet(ArquivoAPI.ObterArquivoPorId + "/{arquivoId}")]
        public async Task<IActionResult> ObterArquivoPorId([FromRoute] int arquivoId)
        {
            var result = await _repo.ObterArquivoPorId(arquivoId);
            return Ok(result);
        }

        [HttpGet(ArquivoAPI.ObterTodosArquivos)]
        public async Task<IActionResult> ObterTodosArquivos()
        {
            var result = await _repo.ObterTodosArquivos();
            return Ok(result);
        }
    }
}
