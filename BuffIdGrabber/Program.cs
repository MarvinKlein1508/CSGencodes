using BuffIdGrabber.Models;
using CSGO_GEN.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace BuffIdGrabber
{
    internal class Program
    {
        // This value changes when the project is being cloned from github
        private const string USER_SECRET_ID = "5554d5e3-8a68-4d44-a7ae-ad6aab189b32";
        static HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder();

            BuildConfig(builder);



            var config = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            // Add login token here
            client.DefaultRequestHeaders.Add("Cookie", config["BuffToken"]);

            var files = Directory.GetFiles("data/stickers");

            string[] alreadyDone = new string[]
                {
                    "10YearBirthday.json",
                    "2021Community.json",
                    "antwerp2022.json",
                    "Atlanta2017.json",
                    "berlin2019.json",
                    "Bestiary.json",
                    "boston2018.json",
                    "Brokenfang.json",
                    "Chicken.json",
                    "Cluj-Napoja2015.json",
                    "cologne2014.json",
                    "cologne2015.json",
                    "Cologne2016.json",
                    "Community2018.json",
                    "CommunityHalloween2014.json",
                    "CommunitySeries1.json",
                    "CommunitySeries2.json",
                    "CommunitySeries3.json",
                    "CommunitySeries4.json",
                    "CommunitySeries5.json",
                    "CS20.json",
                    "dreamhack2014.json",
                    "Enfu.json",
                    "FeralPredators.json",
                    "HalfLife.json",
                    "Halo.json",
                    "katowice2014.json",
                    "katowice2015.json",
                    "katowice2019.json",
                    "krakow2017.json",
                    "london2018.json"
                };

            foreach (var file in files)
            {
                string debug_filename = Path.GetFileName(file);

                if (alreadyDone.Contains(debug_filename))
                {
                    continue;
                }

                string json = await File.ReadAllTextAsync(file);
                List<Sticker> stickers = JsonSerializer.Deserialize<List<Sticker>>(json)!;

                // Buff API examples
                //https://buff.163.com/api/market/goods?game=csgo
                //https://buff.163.com/api/market/goods?game=csgo&page_num=1&search=GAMBIT GAMING
                //https://buff.163.com/api/market/goods?game=csgo&page_size=80&page_num=1
                foreach (var sticker in stickers)
                {
                    // We don't need to ask for the same data twice
                    if (sticker.BuffGoodsId is not null && sticker.BuffStickerId is not null)
                    {
                        continue;
                    }


                    List<BuffDetails> items = new();
                    // Grab all details from buff 
                    var url = $"https://buff.163.com/api/market/goods?game=csgo&page_size=80&page_num=1&search=Sticker | {sticker.name}";

                    BuffObject? buff_object = await client.GetFromJsonAsync<BuffObject>(url);

                    // manually slow down API access to not get timed out by buff
                    await Task.Delay(2000);
                    bool sticker_data_found = false;
                    if (buff_object is not null)
                    {
                        if (buff_object.data is null || !buff_object.data.items.Any())
                        {
                            Log.Logger.Error("Could not find buffId. File: {filename}; Sticker: {sticker_name}", file, sticker.name);
                            await Task.Delay(2000);
                            continue;
                        }

                        // Check if we have a sticker
                        Regex regex = new Regex("(?<=\\\"sticker_v2\", \\\"id\\\": )\\d+");
                        foreach (BuffItem item in buff_object.data.items)
                        {

                            var sanitizedName = item.market_hash_name.Replace("Sticker | ", string.Empty);
                            if (sticker.name == sanitizedName)
                            {
                                Console.WriteLine($"Name: {item.market_hash_name}; ID: {item.id}");
                                await Task.Delay(2000);
                                url = $"https://buff.163.com/goods/{item.id}";
                                string page_html = await client.GetStringAsync(url);

                                var result = regex.Match(page_html);

                                if (result.Success && int.TryParse(result.Value, out int searchId))
                                {
                                    sticker_data_found = true;
                                    BuffDetails details = new BuffDetails(item.id, item.market_hash_name, searchId);
                                    sticker.BuffGoodsId = details.Id;
                                    sticker.BuffStickerId = details.SearchId;
                                    continue;
                                }
                            }
                        }
                    }


                    if (!sticker_data_found)
                    {
                        sticker.BuffGoodsId = null;
                        sticker.BuffStickerId = null;
                        Log.Logger.Error("Could not find buffId. File: {filename}; Sticker: {sticker_name}", file, sticker.name);
                        continue;
                    }
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

        private static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets(USER_SECRET_ID)
                .AddEnvironmentVariables();
        }
    }

}