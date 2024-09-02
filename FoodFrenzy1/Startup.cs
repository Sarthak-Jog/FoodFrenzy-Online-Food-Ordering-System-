﻿using FoodFrenzy1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using FoodFrenzy1.Data;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using FoodFrenzy1.Handlers;
using Microsoft.AspNetCore.Authentication;

namespace FoodFrenzy1
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

            services.AddDbContext<FoodFrenzy1Context>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<FoodFrenzy1Context>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            });

            services.AddControllersWithViews();
                services.AddRazorPages();

            services.AddDbContext<FoodFrenzy1Context>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("FoodFrenzy1Context")));



    /*        services.AddAuthentication("CustomScheme")
            .AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>("CustomScheme", null);*/

            


            


            /*services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireRole("Admin"));

                options.AddPolicy("AtLeast21", policy =>
                    policy.Requirements.Add(new MinimumAgeRequirement(21)));
            });*/






            /*services.AddTransient<IEmailSender, EmailSender>();*/
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                services.AddScoped<Cart>(sp => Cart.GetCart(sp));

                services.AddDistributedMemoryCache();

                services.AddSession(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                    //options.IdleTimeout = TimeSpan.FromSeconds(10);
                });
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
            {
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


            SeedData.Initialize(serviceProvider).Wait();

            /* app.UseAuthentication();
             app.UseAuthorization();*/

            app.UseSession();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=FoodMenu}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });
            }
        }
    }


