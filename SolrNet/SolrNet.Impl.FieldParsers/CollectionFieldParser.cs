using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using SolrNet.Utils;

namespace SolrNet.Impl.FieldParsers;

/// <summary>
/// Parses 1-dimensional fields
/// </summary>
public class CollectionFieldParser : ISolrFieldParser
{
	private readonly ISolrFieldParser valueParser;

	public CollectionFieldParser(ISolrFieldParser valueParser)
	{
		this.valueParser = valueParser;
	}

	public bool CanHandleSolrType(string solrType)
	{
		return solrType == "arr";
	}

	public bool CanHandleType(Type t)
	{
		return t != typeof(string) && typeof(IEnumerable).IsAssignableFrom(t) && !typeof(IDictionary).IsAssignableFrom(t) && !TypeHelper.IsGenericAssignableFrom(typeof(IDictionary<, >), t);
	}

	public object Parse(XElement field, Type t)
	{
		Type[] genericTypes = t.GetGenericArguments();
		if (genericTypes.Length == 1)
		{
			return GetGenericCollectionProperty(field, genericTypes);
		}
		if (t.IsArray)
		{
			return GetArrayProperty(field, t);
		}
		if (t.IsInterface)
		{
			return GetNonGenericCollectionProperty(field);
		}
		return null;
	}

	public IList GetNonGenericCollectionProperty(XElement field)
	{
		ArrayList i = new ArrayList();
		foreach (XElement arrayValueNode in field.Elements())
		{
			i.Add(valueParser.Parse(arrayValueNode, typeof(object)));
		}
		return i;
	}

	public Array GetArrayProperty(XElement field, Type t)
	{
		Array arr = (Array)Activator.CreateInstance(t, field.Elements().Count());
		Type arrType = Type.GetType(t.ToString().Replace("[]", ""));
		int i = 0;
		foreach (XElement arrayValueNode in field.Elements())
		{
			arr.SetValue(valueParser.Parse(arrayValueNode, arrType), i);
			i++;
		}
		return arr;
	}

	public IList GetGenericCollectionProperty(XElement field, Type[] genericTypes)
	{
		Type gt = genericTypes[0];
		IList i = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(gt));
		foreach (XElement arrayValueNode in field.Elements())
		{
			i.Add(valueParser.Parse(arrayValueNode, gt));
		}
		return i;
	}
}
