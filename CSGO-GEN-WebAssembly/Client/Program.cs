using CSGO_GEN.Core.Models;
using CSGO_GEN.Core.Services;
using CSGO_GEN_WebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;

namespace CSGO_GEN_WebAssembly
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            using var client = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            
            // Read all weapon data
            var weapons = await client.GetFromJsonAsync<IList<Weapon>>("/data/collections.json").ConfigureAwait(false);
            if (weapons is not null)
            {
                WeaponService._weapons.AddRange(weapons);
            }


            // Read all sticker data

            var stickers = await client.GetFromJsonAsync<IList<Sticker>>("/data/stickers.json").ConfigureAwait(false);
            if (stickers is not null)
            {
                StickerService._stickers.AddRange(stickers);
            }
            
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<WeaponService>();
            builder.Services.AddScoped<StickerService>();


            await builder.Build().RunAsync();
        }
    }
}