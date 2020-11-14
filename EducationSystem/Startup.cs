using Domain.Repository.IRepository;
using Domain.Service.IService;
using EF.EducationSystem.Repository;
using EF.EducationSystem.Repository.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EducationSystemService.Service;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace EducationSystem
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
            services.AddDbContext<EducationSystemContext>((options) => options.UseSqlServer(Configuration.GetConnectionString("Default")));


            #region identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<EducationSystemContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

           // Adding Jwt Bearer  
           .AddJwtBearer(options =>
           {
               options.SaveToken = true;
               options.RequireHttpsMetadata = false;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidAudience = Configuration["JWT:ValidAudience"],
                   ValidIssuer = Configuration["JWT:ValidIssuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
               };
           });

            #endregion

            services.AddControllers();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
                opt.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
                opt.OperationFilter<AuthenticationRequirementsOperationFilter>();
            });


            //Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICoursePartRepository, CoursePartRepository>();
            services.AddScoped<ICoursePartArticleRepository, CoursePartArticleRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ILinkRepository, LinkRepository>();

            //Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICoursePartService, CoursePartService>();
            services.AddScoped<ICoursePartArticleService, CoursePartArticleService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ILinkService, LinkService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });



            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class AuthenticationRequirementsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Security == null)
                operation.Security = new List<OpenApiSecurityRequirement>();


            var scheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" } };
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [scheme] = new List<string>()
            });
        }
    }
    
}
