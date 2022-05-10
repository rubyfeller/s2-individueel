using DAL.Functions;
using LOGIC;
using LOGIC.DeviceLogic;
using LOGIC.Interfaces;
using LOGIC.Services;
using LOGIC.TicketLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace TicketSystemWeb
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
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddScoped<IDeviceDal, DeviceData>();
            services.AddScoped<ITicketDal, TicketData>();
            services.AddScoped<ICommentDal, CommentData>();
            services.AddScoped<ITicketDeviceCollectionDal, TicketDeviceCollectionData>();
            services.AddScoped<IEmployeeDal, AccountData>();
            services.AddScoped<ITicketLogic, TicketLogic>();
            services.AddScoped<IDeviceLogic, DeviceLogic>();
            services.AddScoped<ICommentLogic, CommentLogic>();
            services.AddScoped<ITicketDeviceCollectionLogic, TicketDeviceCollectionLogic>();
            services.AddScoped<IEmployeeLogic, EmployeeLogic>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

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
