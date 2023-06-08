using System.Collections.Specialized;

namespace AutoMapper.Mappers;

public class NameValueCollectionMapper : IObjectMapper
{
	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		if (!IsMatch(context) || context.SourceValue == null)
		{
			return null;
		}
		NameValueCollection nameValueCollection = new NameValueCollection();
		NameValueCollection nameValueCollection2 = context.SourceValue as NameValueCollection;
		string[] allKeys = nameValueCollection2.AllKeys;
		foreach (string name in allKeys)
		{
			nameValueCollection.Add(name, nameValueCollection2[name]);
		}
		return nameValueCollection;
	}

	public bool IsMatch(ResolutionContext context)
	{
		if (context.SourceType == typeof(NameValueCollection))
		{
			return context.DestinationType == typeof(NameValueCollection);
		}
		return false;
	}
}
