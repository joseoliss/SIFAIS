using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SIFAIS.Datos;
using SIFAIS.Datos.Donaciones;
using SIFAIS.Datos.TipoDonacion;
using SIFAIS.Datos.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using SIFAIS.Datos.TipoDonante;
using SIFAIS.Datos.Donante;
using SIFAIS.Datos.DocumentacionSIFAIS;
using SIFAIS.Datos.Mensajero;
using SIFAIS.Datos.Espacio;
using SIFAIS.Datos.ResponsableDonacion;
using SIFAIS.Datos.Sede;
using SIFAIS.Datos.Usuario;
using SIFAIS.Datos.RolUsuario;

namespace SIFAIS
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
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringsSIFAIS")));

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();


            //autenticación
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Login/Index/";
                });


            //injectando las dependencias
            services.AddSingleton<ILoginBLL, LoginBLL>();
            services.AddSingleton<ITipoDonacionBLL, TipoDonacionBLL>();
            services.AddSingleton<ITipoDonanteBLL, TipoDonanteBLL>();
            services.AddSingleton<IDonanteBLL, DonanteBLL>();
            services.AddSingleton<IDocumentacionSIFAISBLL, DocumentacionSIFAISBLL>();
            services.AddSingleton<IMensajeroBLL, MensajeroBLL>();
            services.AddSingleton<IEspacioBLL, EspacioBLL>();
            services.AddSingleton<IResponsableDonacionBLL, ResponsableDonacionBLL>();
            services.AddSingleton<IDonacionesBLL, DonacionesBLL>();
            services.AddSingleton<ISedeBLL, SedeBLL>();
            services.AddSingleton<IUsuarioBLL, UsuarioBLL>();
            services.AddSingleton<IRolUsuarioBLL, RolUsuarioBLL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}");
            });
        }
    }
}
