using CSGencodes.Core.Models.Buff163;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace JsonModelCreator;

internal class Program
{
    static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder();

        BuildConfig(builder);



        var config = builder.Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(config)
            .CreateLogger();

        await GenerateStickers(config);
        //await GenerateWeapons(config);
    }

    private static async Task GenerateStickers(IConfigurationRoot config)
    {
        var files = Directory.GetFiles("data/stickers");

        Regex onlyChars = new Regex("[^A-Za-z0-9]+");

        foreach (var file in files)
        {
            string debug_filename = Path.GetFileName(file);
            string json = await File.ReadAllTextAsync(file);
            Console.WriteLine(file);
            List<CSGencodes.Core.Models.Sticker> stickers = JsonSerializer.Deserialize<List<CSGencodes.Core.Models.Sticker>>(json)!;

            // Manipulate sticker object with new properties
            foreach (var sticker in stickers)
            {
                // Skinport ID
                sticker.SkinportSearchId = SkinportIdFinder.GetSkinportId(sticker);
            }

            // Compile new list into output directory
            string output_directory = config["OutputDirectory"]!;
            string json_output = JsonSerializer.Serialize(stickers, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            if (!Directory.Exists(output_directory))
            {
                Directory.CreateDirectory(output_directory);
            }

            string filename = Path.Combine(output_directory, Path.GetFileName(file));
            await File.WriteAllTextAsync(filename, json_output);
        }
    }

    private static async Task GenerateWeapons(IConfigurationRoot config)
    {
        var files = Directory.GetFiles("data/collections");

        Regex onlyChars = new Regex("[^A-Za-z0-9]+");

        foreach (var file in files)
        {
            string debug_filename = Path.GetFileName(file);



            string json = await File.ReadAllTextAsync(file);
            var weapons = JsonSerializer.Deserialize<List<CSGencodes.Core.Models.Weapon>>(json)!;

            foreach (var weapon in weapons)
            {
                //string collection = Regex.Replace(weapon.collection, "[^A-Za-z0-9]+", "");

                //string name = weapon.name
                //    .Replace("|", "-")
                //    ;






                //name = Regex.Replace(name, "[^A-Za-z0-9\\-]+", "");



                //// "/assets/img/items/stickers/Stockholm2021/MovistarRiders.png"
                //weapon.Image = $"/assets/img/items/weapons/{collection}/{name}.png";

                weapon.Image = weapon.Image?.ToLower() ?? null;
            }

            // Compile new list into output directory
            string output_directory = config["OutputDirectory"]!;
            string json_output = JsonSerializer.Serialize(weapons, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            if (!Directory.Exists(output_directory))
            {
                Directory.CreateDirectory(output_directory);
            }

            string filename = Path.Combine(output_directory, Path.GetFileName(file));
            await File.WriteAllTextAsync(filename, json_output);
        }
    }

    private static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
    }
}