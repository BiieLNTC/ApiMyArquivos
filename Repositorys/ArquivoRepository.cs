using ApiMyArquivos.Core.Models;
using ApiMyArquivos.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Identity.Client;

namespace ApiMyArquivos.Repositorys
{
    public class ArquivoRepository
    {
        private DatabaseAPI _db;

        public ArquivoRepository(DatabaseAPI database)
        {
            _db = database;
        }

        public async Task<Arquivo> Cadastrar(Arquivo arquivo)
        {
            try
            {
                _db.Database.BeginTransaction();

                var listArquivos = await _db.Arquivos.ToListAsync();

                if (_db.Arquivos.Any() && _db.Arquivos.Any(a => a.Titulo == arquivo.Titulo && a.Id != arquivo.Id))
                {
                    arquivo.MensagemRetorno = "Esse título já foi utilizado para outro cadastro.";
                    return arquivo;
                }

                arquivo.DataCriacao = DateTime.Now;

                _db.Arquivos.Add(arquivo);
                await _db.SaveChangesAsync();

                await _db.Database.CommitTransactionAsync();

                return arquivo;
            }
            catch (Exception ex)
            {
                await _db.Database.RollbackTransactionAsync();
                return null;
            }
        }

        public async Task<Arquivo> Atualizar(Arquivo arquivo)
        {
            try
            {
                _db.Database.BeginTransaction();

                if (_db.Arquivos.Any() && _db.Arquivos.Any(a => a.Titulo == arquivo.Titulo && a.Id != arquivo.Id))
                {
                    arquivo.MensagemRetorno = "Esse título já foi utilizado para outro cadastro.";
                    return arquivo;
                }

                _db.Arquivos.Update(arquivo);

                await _db.SaveChangesAsync();
                await _db.Database.CommitTransactionAsync();

                return arquivo;
            }
            catch (Exception ex)
            {
                await _db.Database.RollbackTransactionAsync();
                return null;
            }
        }

        public async Task<bool> Excluir(int arquivoId)
        {
            try
            {
                _db.Database.BeginTransaction();
                var result = _db.Arquivos.Where(w => w.Id == arquivoId).ExecuteDelete();
                await _db.SaveChangesAsync();

                await _db.Database.CommitTransactionAsync();

                return result == 1;
            }
            catch (Exception ex)
            {
                await _db.Database.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<Arquivo> ObterArquivoPorId(int arquivoId)
        {
            return await _db.Arquivos.Where(w => w.Id == arquivoId).Select(s => s).FirstOrDefaultAsync();
        }

        public async Task<List<Arquivo>> ObterTodosArquivos()
        {
            return await _db.Arquivos.ToListAsync();
        }
    }
}
