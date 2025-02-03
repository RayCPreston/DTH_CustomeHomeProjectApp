using System.Text.Json;
using DTH.App.Delegates;
using DTH.App.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DTH.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login"; // Redirect to login if unauthorized
                    options.AccessDeniedPath = "/Account/Login";
                });
            services.AddAuthorization();
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<BasicAuthHandler>();
            services.AddLogging();
            services.AddControllersWithViews();
            services.AddHttpClient("user-client", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7129/dth/users/v1.0/");
            })
                .AddHttpMessageHandler<BasicAuthHandler>();
            services.AddHttpClient("homeproject-client", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7129/dth/homeprojects/v1.0/");
            })
                .AddHttpMessageHandler<BasicAuthHandler>();
            services.AddScoped<HomeProjectClientRequestService>();
            services.AddScoped<HomeProjectsRestService>();
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
            services.AddSingleton(jsonOptions);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/HomeProject/Error");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/HomeProject/Error");
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
