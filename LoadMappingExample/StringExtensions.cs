using System.IO;

namespace LoadMappingExample
{
	public static class StringExtensions
	{
		public static string FromTemp(this string filePath)
		{
			if(!File.Exists(filePath))
				throw new FileNotFoundException($"Couldn't find file {filePath}");

			var tempFilePath = $"{Path.GetTempFileName()}.{Path.GetExtension(filePath)}";
			File.Copy(filePath, tempFilePath);
			return tempFilePath;

		}
	}
}