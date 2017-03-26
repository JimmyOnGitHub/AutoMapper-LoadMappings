namespace LoadMappingExample
{
	public interface ICustomMappable
    {
        string Source { get; set; }
        string Destination { get; set; }
		string Value { get; set; }
		string Ignore { get; set; }
		bool IgnoreMapping();
	}
}