using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // available for the lifetime of the http request
            services.AddDbContext<StoreContext>(x => x.UseSqlite(
                _config.GetConnectionString("DefaultConnection")
            ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*
                if the request is coming to http://localhost:5000
                it will do the redirection to https.

                For example:

                if we navigate to http://localhost:5000 and we go
                to network tab in developer tools, we will see 
                two requests

                1) http://localhost:5000/weatherforecast returned:
                    + status code 307 (temporary redirect)
                    + location where it should be redirected in (Reponse Headers: Location)
                   ok, I'm going to that https address, and I'll take resources from there

                2) https://localhost:5001/weatherforecast (200 OK)
            */
            app.UseHttpsRedirection();

            /*
                responsible for enabling the routing 
                functionality in controllers
            */
            app.UseRouting();

            app.UseAuthorization();

            /*
                when the app starts, it's goint to map
                all the endpoints so that are API servers
                know where to send the request to
            */
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
