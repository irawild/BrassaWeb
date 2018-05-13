using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BrassaWeb.Data;
using BrassaWeb.Models;
using BrassaWeb.Services;
using BrassaWeb.Data.Repositories;
using DataRepository.Data;
using Newtonsoft.Json;

namespace BrassaWeb
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDataRepositoryContext, ApplicationDbContext>();

            services.AddScoped<IRepository<Degustador>, RDegustador>();
            services.AddScoped<IRepository<Estado>, REstado>();
            services.AddScoped<IRepository<Cidade>, RCidade>();
            services.AddScoped<IRepository<EstoqueReceita>, REstoque>();
            services.AddScoped<IRepository<Receita>, RReceita>();
            services.AddScoped<IRepository<Brasseiro>, RBrasseiro>();
            services.AddScoped<IRepository<Venda>, RVenda>();
            services.AddScoped<IRepository<ItemVenda>, RItemVenda>();
            services.AddScoped<IRepository<Recipiente>, RRecipiente>();
            services.AddScoped<IRepository<EstoqueRecipiente>, REstoqueRecipiente>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication().AddFacebook(fbOptions =>
            {
                fbOptions.AppId = "196496837628891";
                fbOptions.AppSecret = "675f37fa812de7a3eb55f0144f32f4b5";
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc().AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //var options = new RewriteOptions().AddRedirectToHttps(301, 50625);

            //app.UseRewriter(options);

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
