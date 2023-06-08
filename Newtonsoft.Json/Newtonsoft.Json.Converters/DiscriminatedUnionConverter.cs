using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Converters;

/// <summary>
///   Converts a F# discriminated union type to and from JSON.
/// </summary>
public class DiscriminatedUnionConverter : JsonConverter
{
	internal class Union
	{
		public List<UnionCase> Cases;

		public FSharpFunction TagReader { get; set; }
	}

	internal class UnionCase
	{
		public int Tag;

		public string Name;

		public PropertyInfo[] Fields;

		public FSharpFunction FieldReader;

		public FSharpFunction Constructor;
	}

	private const string CasePropertyName = "Case";

	private const string FieldsPropertyName = "Fields";

	private static readonly ThreadSafeStore<Type, Union> UnionCache = new ThreadSafeStore<Type, Union>(CreateUnion);

	private static readonly ThreadSafeStore<Type, Type> UnionTypeLookupCache = new ThreadSafeStore<Type, Type>(CreateUnionTypeLookup);

	private static Type CreateUnionTypeLookup(Type t)
	{
		object arg = ((object[])FSharpUtils.GetUnionCases(null, t, null)).First();
		return (Type)FSharpUtils.GetUnionCaseInfoDeclaringType(arg);
	}

	private static Union CreateUnion(Type t)
	{
		Union union = new Union();
		union.TagReader = (FSharpFunction)FSharpUtils.PreComputeUnionTagReader(null, t, null);
		union.Cases = new List<UnionCase>();
		object[] array = (object[])FSharpUtils.GetUnionCases(null, t, null);
		foreach (object obj in array)
		{
			UnionCase unionCase = new UnionCase();
			unionCase.Tag = (int)FSharpUtils.GetUnionCaseInfoTag(obj);
			unionCase.Name = (string)FSharpUtils.GetUnionCaseInfoName(obj);
			unionCase.Fields = (PropertyInfo[])FSharpUtils.GetUnionCaseInfoFields(obj);
			unionCase.FieldReader = (FSharpFunction)FSharpUtils.PreComputeUnionReader(null, obj, null);
			unionCase.Constructor = (FSharpFunction)FSharpUtils.PreComputeUnionConstructor(null, obj, null);
			union.Cases.Add(unionCase);
		}
		return union;
	}

	/// <summary>
	///   Writes the JSON representation of the object.
	/// </summary>
	/// <param name="writer">
	///   The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.
	/// </param>
	/// <param name="value">The value.</param>
	/// <param name="serializer">The calling serializer.</param>
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		DefaultContractResolver defaultContractResolver = serializer.ContractResolver as DefaultContractResolver;
		Type key = UnionTypeLookupCache.Get(value.GetType());
		Union union = UnionCache.Get(key);
		int tag = (int)union.TagReader.Invoke(value);
		UnionCase unionCase = union.Cases.Single((UnionCase c) => c.Tag == tag);
		writer.WriteStartObject();
		writer.WritePropertyName((defaultContractResolver != null) ? defaultContractResolver.GetResolvedPropertyName("Case") : "Case");
		writer.WriteValue(unionCase.Name);
		if (unionCase.Fields != null && unionCase.Fields.Length != 0)
		{
			object[] obj = (object[])unionCase.FieldReader.Invoke(value);
			writer.WritePropertyName((defaultContractResolver != null) ? defaultContractResolver.GetResolvedPropertyName("Fields") : "Fields");
			writer.WriteStartArray();
			object[] array = obj;
			foreach (object value2 in array)
			{
				serializer.Serialize(writer, value2);
			}
			writer.WriteEndArray();
		}
		writer.WriteEndObject();
	}

	/// <summary>
	///   Reads the JSON representation of the object.
	/// </summary>
	/// <param name="reader">
	///   The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.
	/// </param>
	/// <param name="objectType">Type of the object.</param>
	/// <param name="existingValue">The existing value of object being read.</param>
	/// <param name="serializer">The calling serializer.</param>
	/// <returns>The object value.</returns>
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (reader.TokenType == JsonToken.Null)
		{
			return null;
		}
		UnionCase unionCase = null;
		string caseName = null;
		JArray jArray = null;
		reader.ReadAndAssert();
		while (reader.TokenType == JsonToken.PropertyName)
		{
			string text = reader.Value.ToString();
			if (string.Equals(text, "Case", StringComparison.OrdinalIgnoreCase))
			{
				reader.ReadAndAssert();
				Union union = UnionCache.Get(objectType);
				caseName = reader.Value.ToString();
				unionCase = union.Cases.SingleOrDefault((UnionCase c) => c.Name == caseName);
				if (unionCase == null)
				{
					throw JsonSerializationException.Create(reader, "No union type found with the name '{0}'.".FormatWith(CultureInfo.InvariantCulture, caseName));
				}
			}
			else
			{
				if (!string.Equals(text, "Fields", StringComparison.OrdinalIgnoreCase))
				{
					throw JsonSerializationException.Create(reader, "Unexpected property '{0}' found when reading union.".FormatWith(CultureInfo.InvariantCulture, text));
				}
				reader.ReadAndAssert();
				if (reader.TokenType != JsonToken.StartArray)
				{
					throw JsonSerializationException.Create(reader, "Union fields must been an array.");
				}
				jArray = (JArray)JToken.ReadFrom(reader);
			}
			reader.ReadAndAssert();
		}
		if (unionCase == null)
		{
			throw JsonSerializationException.Create(reader, "No '{0}' property with union name found.".FormatWith(CultureInfo.InvariantCulture, "Case"));
		}
		object[] array = new object[unionCase.Fields.Length];
		if (unionCase.Fields.Length != 0 && jArray == null)
		{
			throw JsonSerializationException.Create(reader, "No '{0}' property with union fields found.".FormatWith(CultureInfo.InvariantCulture, "Fields"));
		}
		if (jArray != null)
		{
			if (unionCase.Fields.Length != jArray.Count)
			{
				throw JsonSerializationException.Create(reader, "The number of field values does not match the number of properties defined by union '{0}'.".FormatWith(CultureInfo.InvariantCulture, caseName));
			}
			for (int i = 0; i < jArray.Count; i++)
			{
				JToken jToken = jArray[i];
				PropertyInfo propertyInfo = unionCase.Fields[i];
				array[i] = jToken.ToObject(propertyInfo.PropertyType, serializer);
			}
		}
		object[] args = new object[1] { array };
		return unionCase.Constructor.Invoke(args);
	}

	/// <summary>
	///   Determines whether this instance can convert the specified object type.
	/// </summary>
	/// <param name="objectType">Type of the object.</param>
	/// <returns>
	///   <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
	/// </returns>
	public override bool CanConvert(Type objectType)
	{
		if (typeof(IEnumerable).IsAssignableFrom(objectType))
		{
			return false;
		}
		object[] customAttributes = objectType.GetCustomAttributes(inherit: true);
		bool flag = false;
		object[] array = customAttributes;
		for (int i = 0; i < array.Length; i++)
		{
			Type type = array[i].GetType();
			if (type.FullName == "Microsoft.FSharp.Core.CompilationMappingAttribute")
			{
				FSharpUtils.EnsureInitialized(type.Assembly());
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return false;
		}
		return (bool)FSharpUtils.IsUnion(null, objectType, null);
	}
}
