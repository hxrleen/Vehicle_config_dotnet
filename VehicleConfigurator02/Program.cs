
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Vehicle_Conf.Models;
using vehicle_conf_dotnet.Models;
using Vehicle_Configuration.DbRepos;
using Vehicle_Configuration.Models;
using VehicleConfiguration02;
using VehicleConfiguration02.Models;
using VehicleConfigurator02.DbRepos;
using VehicleConfigurator02.Models;
using WebApp11.Repository;

namespace VehicleConfigurator
{

        public class Program
        {
            public static void Main(string[] args)
            {

                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.AddControllers();

              
                builder.Services.AddScoped<VehicleConfigurator02.Models.IModel, ModelImpl>();
                builder.Services.AddScoped<ISegmentService, SegmentServiceImpl>();
                builder.Services.AddScoped<IManufacturerService, ManufacturerServiceImpl>();
                builder.Services.AddScoped<IComponentService, ComponentServiceImpl>();
                builder.Services.AddTransient<IContactRepository, SQLContactRepository>();
                builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
                builder.Services.AddTransient<IUserRepository, UserRepositoryImpl>();
                builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
                builder.Services.AddTransient<IEmailService, EmailServiceImpl>();
                builder.Services.AddScoped<IVehicleDetailRepository, VehicleDetailRepository>();



            builder.Services.AddDbContext<ScottDbContext>(options =>
                    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("MyAllowSpecificOrigins",
                                      builder =>
                                      {
                                          builder.WithOrigins("*")
                                                 .AllowAnyHeader()
                                                 .AllowAnyMethod();
                                      });
                });

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();

               app.UseCors("MyAllowSpecificOrigins");
                

                app.Run();
            }
        }
    }

