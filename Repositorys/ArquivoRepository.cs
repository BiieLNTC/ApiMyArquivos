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
                //_db.Database.BeginTransaction();

                //_db.Arquivos.Add(arquivo);
                //await _db.SaveChangesAsync();

                //await _db.Database.CommitTransactionAsync();

                if (GlobalVar.ListArquivo.Any(a => a.Titulo == arquivo.Titulo && a.Id != arquivo.Id))
                {
                    arquivo.MensagemRetorno = "Esse título já foi utilizado para outro cadastro.";
                    return arquivo;
                }

                arquivo.Id = (GlobalVar.ListArquivo.Count() + 1);

                GlobalVar.ListArquivo.Add(arquivo);

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
                //_db.Database.BeginTransaction();

                if (_db.Arquivos.Any(a => a.Titulo == arquivo.Titulo && a.Id != arquivo.Id))
                {
                    arquivo.MensagemRetorno = "Esse título já foi utilizado para outro cadastro.";
                    return arquivo;
                }

                //_db.Arquivos.Update(arquivo);
                //await _db.SaveChangesAsync();

                //await _db.Database.CommitTransactionAsync();

                if (GlobalVar.ListArquivo.Any(a => a.Titulo == arquivo.Titulo && a.Id != arquivo.Id) && GlobalVar.ListArquivo.Count > 0)
                {
                    arquivo.MensagemRetorno = "Esse título já foi utilizado para outro cadastro.";
                    return arquivo;
                }

                var obj = GlobalVar.ListArquivo.Where(w => w.Id == arquivo.Id).FirstOrDefault();
                GlobalVar.ListArquivo.Remove(obj);
                GlobalVar.ListArquivo.Add(arquivo);
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
                //_db.Database.BeginTransaction();
                //var result = _db.Arquivos.Where(w => w.Id == arquivoId).ExecuteDelete();
                //await _db.SaveChangesAsync();

                //await _db.Database.CommitTransactionAsync();

                //return result == 1;
                var obj = GlobalVar.ListArquivo.Where(w => w.Id == arquivoId).FirstOrDefault();
                GlobalVar.ListArquivo.Remove(obj);

                return true;
            }
            catch (Exception ex)
            {
                await _db.Database.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<Arquivo> ObterArquivoPorId(int arquivoId)
        {
            //var arquivo = await _db.Arquivos.Where(w => w.Id == arquivoId).Select(s => s).FirstOrDefaultAsync();

            //var arquivo = new Arquivo()
            //{
            //    Id = 1,
            //    Titulo = "Teste Boy",
            //    Descricao = "Apenas um testezinho",
            //    DataCriacao = DateTime.Now,
            //    NomeArquivo = "ahsim.txt"
            //};

            return GlobalVar.ListArquivo.Where(w => w.Id == arquivoId).FirstOrDefault();
        }

        public async Task<List<Arquivo>> ObterTodosArquivos()
        {
            //var listArquivos = await _db.Arquivos.ToListAsync();

            var listArquivos = new List<Arquivo>()
            {
                new Arquivo()
                {
                     Id = 1,
                     Titulo = "Teste Boy",
                     Descricao = "Apenas um testezinho",
                     DataCriacao = DateTime.Now,
                     NomeArquivo = "ahsim.txt",
                }
            };

            return GlobalVar.ListArquivo.ToList();
        }
    }
}
