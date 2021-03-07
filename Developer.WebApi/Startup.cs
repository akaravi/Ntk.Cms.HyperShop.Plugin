using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Developer.WebApi.Providers;

namespace Developer.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public string ContentRootPath { get; }

        readonly string MyAllowSpecificOrigins = "AllowSpecificOrigin";
        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();




            ContentRootPath = env.ContentRootPath;





        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          

   


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ntk Micro Service HyperShop", Version = "v1" });
            });
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(
            //        MyAllowSpecificOrigins,
            //        builder =>
            //        {
            //            builder.AllowAnyOrigin().WithMethods(
            //                HttpMethod.Get.Method,
            //                HttpMethod.Put.Method,
            //                HttpMethod.Post.Method,
            //                HttpMethod.Delete.Method).AllowAnyHeader().WithExposedHeaders("CustomHeader");
            //        });
            //});

            services.AddControllers().AddMvcOptions(options => options.ModelBinderProviders.Insert(1, new FilterModelBinderProvider()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Developer API V1");
                c.RoutePrefix = "help";
            });

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();
            // Make sure you call this before calling app.UseMvc()
            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
