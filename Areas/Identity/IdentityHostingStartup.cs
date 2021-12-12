using System;
using EnsatGestion.Areas.Identity.Data;
using EnsatGestion.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EnsatGestion.Areas.Identity.IdentityHostingStartup))]
namespace EnsatGestion.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EnsatGestionContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EnsatGestionContextConnection")));

                services.AddDefaultIdentity<EnsatGestionUser>(options => {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.SignIn.RequireConfirmedAccount = false;
                })
                    .AddEntityFrameworkStores<EnsatGestionContext>();
            });
        }
    }
}