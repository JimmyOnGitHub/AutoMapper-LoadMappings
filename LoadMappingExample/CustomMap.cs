using System;

namespace LoadMappingExample
{
    public class CustomMap: ICustomMappable
    {
        public string Source { get; set; }
        public string Destination { get; set; }
		public string Value { get; set; }
		public string Ignore { get; set; }

		public bool IgnoreMapping()
		{
			return this.Ignore?.ToLower() == "y";
		}
	}
}