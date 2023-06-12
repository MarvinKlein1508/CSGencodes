using CSGO_GEN.Core.Models;
using System.IO;
using System.Text.Json;

namespace CompileJsonCollections
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //await MergeBuffIds();
            string directory_to_copy = args.Length > 0 ? args[0] : string.Empty;
            //// Load all stickers
            await CompileJsonAsync<Sticker>("data/stickers", $"{directory_to_copy}stickers.json");
            await CompileJsonAsync<Weapon>("data/collections", $"{directory_to_copy}collections.json");

            // Load all collections

            Environment.Exit(0);
        }

        private static async Task CompileJsonAsync<T>(string directory, string compiledFileName) where T : IGenable
        {
            Console.WriteLine($"Start compiling: {directory} to {compiledFileName}");
            List<T> item_list = new List<T>();

            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directory));
            Console.WriteLine($"{files.Length} files found to compile!");
            foreach (var file in files)
            {
                Console.WriteLine($"Compile: {file}");
                string json = await File.ReadAllTextAsync(file);
                var items = JsonSerializer.Deserialize<List<T>>(json);

                if (items is not null)
                {
                    item_list.AddRange(items);
                }
            }
            Console.WriteLine($"Sort items...");
            var item_list_sorted = item_list.OrderBy(x => x.gen_id).ToArray();

            string json_items = JsonSerializer.Serialize(item_list_sorted, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            Console.WriteLine($"Generate file {compiledFileName}...");
            await File.WriteAllTextAsync(compiledFileName, json_items);
            Console.WriteLine($"{compiledFileName} has been compiled successfully!");
        }


        private static async Task MergeBuffIds()
        {

            string json = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data/buff/buff_sticker_data.json"));

            List<BuffDetails> buffDetails = JsonSerializer.Deserialize<List<BuffDetails>>(json)!;

            var buff_list_sorted = buffDetails.OrderBy(x => x.Id).ToArray();
            json = JsonSerializer.Serialize(buff_list_sorted, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            await File.WriteAllTextAsync("buff_sticker_data.json", json);

            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data/stickers"));

            int notFoundAmount = 0;
            foreach (var file in files)
            {

                json = await File.ReadAllTextAsync(file);
                var stickers = JsonSerializer.Deserialize<List<Sticker>>(json)!;

                foreach (var sticker in stickers)
                {
                    // Search buff details
                    var details = buffDetails.FirstOrDefault(x => x.Name.Contains(sticker.name));

                    if (details is not null)
                    {
                        sticker.BuffGoodsId = details.Id;
                        sticker.BuffStickerId = details.SearchId;
                    }
                    else
                    {
                        sticker.BuffGoodsId = null;
                        sticker.BuffStickerId = null;
                        Console.WriteLine($"No data found. Sticker: {sticker.name}");
                        notFoundAmount++;
                    }
                }

                var sticker_list_sorted = stickers.OrderBy(x => x.gen_id).ToArray();



                json = JsonSerializer.Serialize(sticker_list_sorted, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });

                await File.WriteAllTextAsync(Path.GetFileName(file), json);

            }
            Console.WriteLine($"Not found: {notFoundAmount}");
        }
    }
}