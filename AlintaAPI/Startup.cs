using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Alinta.Data.Models;
using Alinta.Data.Repository.v1;
using Alinta.Domain.Command.v1;
using Alinta.Domain.Query.v1;
using Alinta.Domain.ViewModel.v1;
using Alinta.DomainLogic.Handlers.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoWrapper;
using AlintaAPI.Models;

namespace AlintaAPI
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

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Customer API",
                    Description = "Customer API",
                    Version = "V1"
                });

                var fileName = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(filePath);
            });

            services.AddMediatR(typeof(GetCustomerListQuery).Assembly);


            services.AddSingleton<IDataRepository<Customer>, CustomerRepository>();
            
            services.AddSingleton<IRequestHandler<AddCustomerCommand, bool>, AddCustomerCommandHandler>();
            services.AddSingleton<IRequestHandler<DeleteCustomerCommand, bool>, DeleteCustomerCommandHandler>();
            services.AddSingleton<IRequestHandler<UpdateCustomerCommand, bool>, UpdateCustomerCommandHandler>();

            services.AddSingleton<IRequestHandler<GetCustomerByIdQuery, CustomerDetail>, GetCustomerByIdHandler>();
            services.AddSingleton<IRequestHandler<GetCustomerListQuery, IEnumerable<CustomerDetail>>, GetCustomerListQueryHandler>();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());


            app.UseApiResponseAndExceptionWrapper<MapResponseObject>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}