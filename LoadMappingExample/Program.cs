using System;
using System.IO;
using AutoMapper;
using System.Linq;

/*
 * By: Jimmy
 * Email:  jimmy.hadfield@gmail.com
 * Requires Microsoft Access Database Engine 2010 Redistributable 
 * https://www.microsoft.com/en-au/download/details.aspx?id=13255
 */
namespace LoadMappingExample
{
	class Program
    {
        static void Main(string[] args)
        {
	        var filePath = $@"{Directory.GetCurrentDirectory()}\Resources\MappingsDemo.xlsx";
			Console.WriteLine("------------------Instructions----------------------");
			Console.WriteLine("Source = Source object propery name");
			Console.WriteLine("Destination = Destination object property name");
			Console.WriteLine("Value = Overide destination object property with a value (takes precedence over source property if set)");
			Console.WriteLine("Ignore = Will not try and map any value to the desitination property");

			Console.WriteLine();

			Console.WriteLine($"Loading {filePath} for custom mappings");
	        

			while (true)
	        {
		        try
		        {
					var exceltMapper = new ExcelMapper(filePath: filePath, workSheet: "ItemMappings");

					var localItem = new LocalItem { Code = "ABC", Name = "ABC Item", Description = "This is the ABC item" };

					Console.WriteLine($"------------------{DateTime.Now}----------------------");
					Console.WriteLine($"Mapping {localItem.GetType()} to {typeof(RemoteItem)}");

					Mapper.Initialize(cfg =>
						cfg.CreateMap<LocalItem, RemoteItem>()
						.LoadedtMappings(exceltMapper.Mappings.ToList<ICustomMappable>())
					);
					var remoteItem = Mapper.Map<RemoteItem>(localItem);

					Console.WriteLine($"From: {localItem}");
					Console.WriteLine($"To: {remoteItem}");
				}
		        catch (Exception e)
		        {
			        Console.WriteLine(e.Message);
		        }
				
				Console.ReadLine();
			}

        }

        
    }
}
