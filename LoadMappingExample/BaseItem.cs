using System.Linq;

namespace LoadMappingExample
{
	public abstract class BaseItem
	{
		public override string ToString()
		{
			var properties = GetType().GetProperties();
			return properties.Aggregate("", (current, properpty) => current + $"{properpty.Name} = {properpty.GetValue(this)}, ").Trim().TrimEnd(',');

		}
	}
}