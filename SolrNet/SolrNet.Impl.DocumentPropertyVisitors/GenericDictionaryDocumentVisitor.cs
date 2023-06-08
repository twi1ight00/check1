using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using SolrNet.Utils;

namespace SolrNet.Impl.DocumentPropertyVisitors;

/// <summary>
/// Document visitor that handles generic dictionary properties
/// </summary>
public class GenericDictionaryDocumentVisitor : ISolrDocumentPropertyVisitor
{
	private readonly IReadOnlyMappingManager mapper;

	private readonly ISolrFieldParser parser;

	private readonly Converter<Type, bool> memoCanHandleType;

	private readonly Func<Type, string, SolrFieldModel> memoGetThisField;

	/// <summary>
	/// Document visitor that handles generic dictionary properties
	/// </summary>
	/// <param name="mapper"></param>
	/// <param name="parser"></param>
	public GenericDictionaryDocumentVisitor(IReadOnlyMappingManager mapper, ISolrFieldParser parser)
	{
		this.mapper = mapper;
		this.parser = parser;
		memoCanHandleType = Memoizer.Memoize<Type, bool>(CanHandleType);
		memoGetThisField = Memoizer.Memoize2<Type, string, SolrFieldModel>(GetThisField);
	}

	/// <summary>
	/// True if this visitor can handle this Type
	/// </summary>
	/// <param name="t"></param>
	/// <returns></returns>
	public bool CanHandleType(Type t)
	{
		return TypeHelper.IsGenericAssignableFrom(typeof(IDictionary<, >), t);
	}

	/// <summary>
	/// Creates a new <see cref="T:System.Collections.Generic.Dictionary`2" />
	/// </summary>
	/// <param name="typeArgs">Key and Value type parameters</param>
	/// <returns></returns>
	private static object NewDictionary(Type[] typeArgs)
	{
		Type genericType = typeof(Dictionary<, >).MakeGenericType(typeArgs);
		return Activator.CreateInstance(genericType);
	}

	/// <summary>
	/// Sets a key/value in a generic dictionary
	/// </summary>
	/// <param name="dict"><see cref="T:System.Collections.Generic.Dictionary`2" /> instance</param>
	/// <param name="key">Key value</param>
	/// <param name="value">Value value</param>
	private static void SetKV(object dict, object key, object value)
	{
		dict.GetType().GetMethod("set_Item").Invoke(dict, new object[2] { key, value });
	}

	private static object ConvertTo(string s, Type t)
	{
		TypeConverter converter = TypeDescriptor.GetConverter(t);
		return converter.ConvertFrom(s);
	}

	public SolrFieldModel GetThisField(Type t, string fieldName)
	{
		ICollection<SolrFieldModel> allFields = mapper.GetFields(t).Values;
		IEnumerable<SolrFieldModel> fieldsICanHandle = allFields.Where((SolrFieldModel f) => memoCanHandleType(f.Property.PropertyType));
		IEnumerable<SolrFieldModel> matchingFields = fieldsICanHandle.Where((SolrFieldModel f) => f.FieldName == "*" || fieldName.StartsWith(f.FieldName));
		return matchingFields.FirstOrDefault((SolrFieldModel f) => !allFields.Any((SolrFieldModel x) => x.FieldName == fieldName && !object.Equals(x, f)));
	}

	private static string GetKeyToUse(string k, string fieldName)
	{
		if (fieldName == "*")
		{
			return k;
		}
		return k.Substring(fieldName.Length);
	}

	public void Visit(object doc, string fieldName, XElement field)
	{
		SolrFieldModel thisField = memoGetThisField(doc.GetType(), fieldName);
		if (thisField != null)
		{
			string thisFieldName = thisField.FieldName;
			Type[] typeArgs = thisField.Property.PropertyType.GetGenericArguments();
			Type keyType = typeArgs[0];
			Type valueType = typeArgs[1];
			object dict = thisField.Property.GetValue(doc, null) ?? NewDictionary(typeArgs);
			string key = GetKeyToUse(field.Attribute("name").Value, thisFieldName);
			object value = parser.Parse(field, valueType);
			SetKV(dict, ConvertTo(key, keyType), value);
			thisField.Property.SetValue(doc, dict, null);
		}
	}
}
