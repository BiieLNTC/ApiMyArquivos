using ApiMyArquivos.Repositorys;

namespace ApiMyArquivos.Core.Config
{
    public class ConfigRepository
    {
        public static void ConfigurarRepositorys(IServiceCollection services)
        {
            services.AddScoped<ArquivoRepository>();
        }
    }
}
