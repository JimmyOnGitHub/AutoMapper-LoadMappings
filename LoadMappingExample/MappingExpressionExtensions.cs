using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Configuration;
using Remotion.Data.Linq;

namespace LoadMappingExample
{

	public static class MappingExpressionExtensions
	{
		public static List<IMappingExpression<TSource, TDestination>> LoadedtMappings<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression, List<ICustomMappable> mappings)
		{

			var loadedMappings = new List<IMappingExpression<TSource, TDestination>>();
			var sourceProperties = typeof(TSource).GetProperties();
			var destinationProperties = typeof(TDestination).GetProperties();

			foreach (var map in mappings)
			{
				var sourceMap = map.Source;
				var destinationMap = map.Destination;

				PropertyInfo destinationProperty;
				try
				{
					destinationProperty = destinationProperties.First(p => p.Name == destinationMap);
				}
				catch (InvalidOperationException e)
				{
					throw new Exception($"Destination Property ({destinationMap}) doesn't exist... {e}");
				}


				PropertyInfo sourceProperty = null;
				if (string.IsNullOrEmpty(map.Value))
					try
					{
						sourceProperty = sourceProperties.First(p => p.Name == sourceMap);

					}
					catch (InvalidOperationException e)
					{
						throw new Exception($"Source Property ({sourceMap}) doesn't exist... {e}");
					}


				if (map.IgnoreMapping())
					expression.ForMember(destinationProperty.Name,
						opt => opt.Ignore());
				else if (sourceProperty == null)
					expression.ForMember(destinationProperty.Name,
						opt => opt.UseValue(map.Value));
				else
					expression.ForMember(destinationProperty.Name,
						opt => opt.MapFrom(sourceProperty.Name));

				loadedMappings.Add(expression);
			}

			return loadedMappings;
		}
	}
}