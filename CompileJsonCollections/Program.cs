using CSGencodes.Core.Models;
using System.Text.Json;

namespace CompileJsonCollections
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string directory_to_copy = args.Length > 0 ? args[0] : string.Empty;
            //// Load all stickers
            await CompileJsonAsync<Sticker>("data/stickers", $"{directory_to_copy}stickers.json");
            await CompileJsonAsync<Weapon>("data/collections", $"{directory_to_copy}collections.json");
            await CompileJsonAsync<Weapon>("data/knives", $"{directory_to_copy}knives.json");

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
    }
}