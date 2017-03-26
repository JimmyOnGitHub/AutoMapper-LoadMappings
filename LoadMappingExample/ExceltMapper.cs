using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LinqToExcel;

namespace LoadMappingExample
{
    public class ExcelMapper
    {
        public List<CustomMap> Mappings { get; set; }

        public ExcelMapper(string filePath, string workSheet)
        {
            if(!File.Exists(filePath))
                throw new FileNotFoundException($"Could not find file {filePath}");

	        try
	        {
				var excel = new ExcelQueryFactory(filePath.FromTemp());
				Mappings = (from m in excel.Worksheet<CustomMap>(workSheet)
							select m).ToList();
			}
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
		        throw new Exception($"Couln't open Excel file {filePath}");
	        }

        }


    }
}