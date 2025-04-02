using CSGencodes.Core.Models;
using System.Text.Json;

internal class Program
{
    public const string ImagePath = @"C:\Users\Marvin\Desktop\panorama\images\econ\default_generated";
    private static async Task Main(string[] args)
    {

        var files = Directory.GetFiles("data/collections");

        foreach (var file in files)
        {
            string filename = Path.GetFileName(file);
            string filename_without_extension = Path.GetFileNameWithoutExtension(file);
            if (filename != "limited_edition_item.json"
                && filename != "the_ascent_collection.json"
                && filename != "the_boreal_collection.json"
                && filename != "the_fever_collection.json"
                && filename != "the_radiant_collection.json"
                && filename != "the_train_2025_collection.json"
            )
            {
                continue;
            }

            string json = await File.ReadAllTextAsync(file);

            List<Weapon> weapons = JsonSerializer.Deserialize<List<Weapon>>(json)!;


            if (!Directory.Exists(filename_without_extension))
            {
                Directory.CreateDirectory(filename_without_extension);
            }

            foreach (Weapon weapon in weapons)
            {
                string image_filename = Path.GetFileName(weapon.Image)!;

                string sourceFile = Path.Combine(ImagePath, image_filename);
                string destinationFileName = Path.Combine(filename_without_extension, image_filename);

                if (File.Exists(sourceFile))
                {
                    File.Copy(sourceFile, destinationFileName, true);
                }
                else
                {
                    
                    Console.WriteLine($"Collection: {filename_without_extension} File: {sourceFile}");
                }
            }


            Console.WriteLine(filename);
        }
    }
}