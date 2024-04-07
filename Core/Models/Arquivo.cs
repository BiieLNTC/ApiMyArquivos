using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMyArquivos.Core.Models
{
    public class Arquivo
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string NomeArquivo { get; set; }
        public byte[] Conteudo { get; set; }
        public DateTime? DataCriacao { get; set; }
        [NotMapped]
        public string MensagemRetorno { get; set; }
    }

    public class ArquivoAPI
    {
        public const string Cadastrar = "Cadastrar";
        public const string Atualizar = "Atualizar";
        public const string Exluir = "Excluir";
        public const string ObterArquivoPorId = "ObterArquivoPorId";
        public const string ObterTodosArquivos = "ObterTodosArquivos";
    }
}
