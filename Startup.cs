using decebaleduard.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace decebaleduard
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }
        // Această metodă este apelată de runtime. Se utiliziaza această metodă pentru a adăuga servicii la container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<decebaleduardContext>(options => options.UseSqlServer(Configuration.GetConnectionString("decebaleduardContext")));
        }

        //Această metodă este apelată de runtime. Se utiliziaza această metodă pentru a configura conducta de solicitare HTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //Valoarea implicită HSTS este de 30 de zile. Daca dorim să schimbam acest lucru pentru scenariile de producție, vedem https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
           
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
