
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Train_D.Converters;
using Train_D.Data;
using Train_D.Helper;
using Train_D.Models;
using Train_D.Services;
using Train_D.Services.Contract;

namespace Train_D
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateConveter());
                options.JsonSerializerOptions.Converters.Add(new TimeConveter());
            });

            // allow cors origin
            string CorsPolicy = "AllowAll";
            builder.Services.AddCors(option =>
            {
                option.AddPolicy(CorsPolicy, builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();

                });
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Add  AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add Stripe Infrastructure
            builder.Services.AddStripeInfrastructure(builder.Configuration);

            //add mailsetting
            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

            // make reset token vaild for only 10 hours
            builder.Services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));


            //Add JWT
            builder.Services.Configure<JWT>(builder.Configuration.GetSection(nameof(JWT)));


            //Add Identity 
            builder.Services.AddIdentity<User, IdentityRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();



            //Add ConntectionString 
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Azure"))
            );



            //Add Services
            builder.Services.AddScoped<IAuth, Auth>();
            builder.Services.AddScoped<IStationsServices, StationsServices>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<ITripService, TripService>();
            builder.Services.AddScoped<ITicketService, TicketService>();


            //Add Authantications
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = true;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"])),
                    ClockSkew = TimeSpan.FromMinutes(1) // is a time for activate token 
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            //Cors Policy
            app.UseCors(CorsPolicy);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
