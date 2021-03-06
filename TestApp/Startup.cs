using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services;
using Services.mapping;
using Swashbuckle.AspNetCore.Swagger;

namespace TestApp
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
     
      services.AddTransient<ISessionFactoryHelper, NHibernateHelper>();
      services.AddTransient<IUserRepository, UserRepository>();
      services.AddTransient<IRoleRepository, RoleRepository>();
      services.AddControllers();
      services.AddAutoMapper(x =>
      {
        x.AddProfile(new EntityToModel());
        x.AddProfile(new ModelToEntity());
      });
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contacts API", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        
      }
      else
      {
        app.UseHsts();
      }
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts API V1");
      });
      app.UseHttpsRedirection();
      app.UseRouting();
      app.UseEndpoints(endpoints => {
        endpoints.MapDefaultControllerRoute();
        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
      });
      app.UseDefaultFiles();
      app.UseStaticFiles();
    }
  }
}
