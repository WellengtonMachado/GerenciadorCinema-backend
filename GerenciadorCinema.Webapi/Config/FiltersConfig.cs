using Microsoft.Extensions.DependencyInjection;
using GerenciadorCinema.Webapi.Filters;

namespace GerenciadorCinema.Webapi.Config
{
    public static class FiltersConfig
    {
        public static void ConfigurarFiltros(this IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.Filters.Add(new ValidarViewModelActionFilter());
            })
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter());


                    opt.JsonSerializerOptions.Converters.Add(new ByteArrayConverter());


                    //opt.JsonSerializerOptions.Converters.Add(new IntToStringConverter());
                    
                });


        }
    }  
}
