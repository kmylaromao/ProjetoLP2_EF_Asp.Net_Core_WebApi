using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Petshop.Repository;
using Swashbuckle.AspNetCore.Swagger;

namespace PetShopV2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        
        
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "SISPetShop", Version = "v1" });
            });

            services.AddScoped<IAnimalRepository>(factory => {
                    return new AnimalRepository(Configuration.GetConnectionString("MySqlDbConnection"));
            });
        
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Configurações do Swagger no pipiline de execução da aplicação.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API .Net Core e VS Code");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
