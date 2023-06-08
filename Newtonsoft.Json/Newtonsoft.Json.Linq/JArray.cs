using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq;

/// <summary>
///   Represents a JSON array.
/// </summary>
/// <example>
///   <code lang="cs" source="..\Src\Newtonsoft.Json.Tests\Documentation\LinqToJsonTests.cs" region="LinqToJsonCreateParseArray" title="Parsing a JSON Array from Text" />
/// </example>
public class JArray : JContainer, IList<JToken>, ICollection<JToken>, IEnumerable<JToken>, IEnumerable
{
	private readonly List<JToken> _values = new List<JToken>();

	/// <summary>
	///   Gets the container's children tokens.
	/// </summary>
	/// <value>The container's children tokens.</value>
	protected override IList<JToken> ChildrenTokens => _values;

	/// <summary>
	///   Gets the node type for this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <value>The type.</value>
	public override JTokenType Type => JTokenType.Array;

	/// <summary>
	///   Gets the <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the specified key.
	/// </summary>
	/// <value>
	///   The <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the specified key.
	/// </value>
	public override JToken this[object key]
	{
		get
		{
			ValidationUtils.ArgumentNotNull(key, "key");
			if (!(key is int))
			{
				throw new ArgumentException("Accessed JArray values with invalid key value: {0}. Int32 array index expected.".FormatWith(CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(key)));
			}
			return GetItem((int)key);
		}
		set
		{
			ValidationUtils.ArgumentNotNull(key, "key");
			if (!(key is int))
			{
				throw new ArgumentException("Set JArray values with invalid key value: {0}. Int32 array index expected.".FormatWith(CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(key)));
			}
			SetItem((int)key, value);
		}
	}

	/// <summary>
	///   Gets or sets the <see cref="T:Newtonsoft.Json.Linq.JToken" /> at the specified index.
	/// </summary>
	/// <value></value>
	public JToken this[int index]
	{
		get
		{
			return GetItem(index);
		}
		set
		{
			SetItem(index, value);
		}
	}

	/// <summary>
	///   Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
	/// </summary>
	/// <returns>
	///   true if the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only; otherwise, false.
	/// </returns>
	public bool IsReadOnly => false;

	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JArray" /> class.
	/// </summary>
	public JArray()
	{
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JArray" /> class from another <see cref="T:Newtonsoft.Json.Linq.JArray" /> object.
	/// </summary>
	/// <param name="other">
	///   A <see cref="T:Newtonsoft.Json.Linq.JArray" /> object to copy from.
	/// </param>
	public JArray(JArray other)
		: base(other)
	{
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JArray" /> class with the specified content.
	/// </summary>
	/// <param name="content">The contents of the array.</param>
	public JArray(params object[] content)
		: this((object)content)
	{
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JArray" /> class with the specified content.
	/// </summary>
	/// <param name="content">The contents of the array.</param>
	public JArray(object content)
	{
		Add(content);
	}

	internal override bool DeepEquals(JToken node)
	{
		if (node is JArray container)
		{
			return ContentsEqual(container);
		}
		return false;
	}

	internal override JToken CloneToken()
	{
		return new JArray(this);
	}

	/// <summary>
	///   Loads an <see cref="T:Newtonsoft.Json.Linq.JArray" /> from a <see cref="T:Newtonsoft.Json.JsonReader" />.
	/// </summary>
	/// <param name="reader">
	///   A <see cref="T:Newtonsoft.Json.JsonReader" /> that will be read for the content of the <see cref="T:Newtonsoft.Json.Linq.JArray" />.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JArray" /> that contains the JSON that was read from the specified <see cref="T:Newtonsoft.Json.JsonReader" />.
	/// </returns>
	public new static JArray Load(JsonReader reader)
	{
		return Load(reader, null);
	}

	/// <summary>
	///   Loads an <see cref="T:Newtonsoft.Json.Linq.JArray" /> from a <see cref="T:Newtonsoft.Json.JsonReader" />.
	/// </summary>
	/// <param name="reader">
	///   A <see cref="T:Newtonsoft.Json.JsonReader" /> that will be read for the content of the <see cref="T:Newtonsoft.Json.Linq.JArray" />.
	/// </param>
	/// <param name="settings">
	///   The <see cref="T:Newtonsoft.Json.Linq.JsonLoadSettings" /> used to load the JSON.
	///   If this is null, default load settings will be used.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JArray" /> that contains the JSON that was read from the specified <see cref="T:Newtonsoft.Json.JsonReader" />.
	/// </returns>
	public new static JArray Load(JsonReader reader, JsonLoadSettings settings)
	{
		if (reader.TokenType == JsonToken.None && !reader.Read())
		{
			throw JsonReaderException.Create(reader, "Error reading JArray from JsonReader.");
		}
		reader.MoveToContent();
		if (reader.TokenType != JsonToken.StartArray)
		{
			throw JsonReaderException.Create(reader, "Error reading JArray from JsonReader. Current JsonReader item is not an array: {0}".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
		}
		JArray jArray = new JArray();
		jArray.SetLineInfo(reader as IJsonLineInfo, settings);
		jArray.ReadTokenFrom(reader, settings);
		return jArray;
	}

	/// <summary>
	///   Load a <see cref="T:Newtonsoft.Json.Linq.JArray" /> from a string that contains JSON.
	/// </summary>
	/// <param name="json">
	///   A <see cref="T:System.String" /> that contains JSON.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JArray" /> populated from the string that contains JSON.
	/// </returns>
	/// <example>
	///   <code lang="cs" source="..\Src\Newtonsoft.Json.Tests\Documentation\LinqToJsonTests.cs" region="LinqToJsonCreateParseArray" title="Parsing a JSON Array from Text" />
	/// </example>
	public new static JArray Parse(string json)
	{
		return Parse(json, null);
	}

	/// <summary>
	///   Load a <see cref="T:Newtonsoft.Json.Linq.JArray" /> from a string that contains JSON.
	/// </summary>
	/// <param name="json">
	///   A <see cref="T:System.String" /> that contains JSON.
	/// </param>
	/// <param name="settings">
	///   The <see cref="T:Newtonsoft.Json.Linq.JsonLoadSettings" /> used to load the JSON.
	///   If this is null, default load settings will be used.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JArray" /> populated from the string that contains JSON.
	/// </returns>
	/// <example>
	///   <code lang="cs" source="..\Src\Newtonsoft.Json.Tests\Documentation\LinqToJsonTests.cs" region="LinqToJsonCreateParseArray" title="Parsing a JSON Array from Text" />
	/// </example>
	public new static JArray Parse(string json, JsonLoadSettings settings)
	{
		using JsonReader jsonReader = new JsonTextReader(new StringReader(json));
		JArray result = Load(jsonReader, settings);
		if (jsonReader.Read() && jsonReader.TokenType != JsonToken.Comment)
		{
			throw JsonReaderException.Create(jsonReader, "Additional text found in JSON string after parsing content.");
		}
		return result;
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Linq.JArray" /> from an object.
	/// </summary>
	/// <param name="o">
	///   The object that will be used to create <see cref="T:Newtonsoft.Json.Linq.JArray" />.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JArray" /> with the values of the specified object
	/// </returns>
	public new static JArray FromObject(object o)
	{
		return FromObject(o, JsonSerializer.CreateDefault());
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Linq.JArray" /> from an object.
	/// </summary>
	/// <param name="o">
	///   The object that will be used to create <see cref="T:Newtonsoft.Json.Linq.JArray" />.
	/// </param>
	/// <param name="jsonSerializer">
	///   The <see cref="T:Newtonsoft.Json.JsonSerializer" /> that will be used to read the object.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JArray" /> with the values of the specified object
	/// </returns>
	public new static JArray FromObject(object o, JsonSerializer jsonSerializer)
	{
		JToken jToken = JToken.FromObjectInternal(o, jsonSerializer);
		if (jToken.Type != JTokenType.Array)
		{
			throw new ArgumentException("Object serialized to {0}. JArray instance expected.".FormatWith(CultureInfo.InvariantCulture, jToken.Type));
		}
		return (JArray)jToken;
	}

	/// <summary>
	///   Writes this token to a <see cref="T:Newtonsoft.Json.JsonWriter" />.
	/// </summary>
	/// <param name="writer">
	///   A <see cref="T:Newtonsoft.Json.JsonWriter" /> into which this method will write.
	/// </param>
	/// <param name="converters">
	///   A collection of <see cref="T:Newtonsoft.Json.JsonConverter" /> which will be used when writing the token.
	/// </param>
	public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
	{
		writer.WriteStartArray();
		for (int i = 0; i < _values.Count; i++)
		{
			_values[i].WriteTo(writer, converters);
		}
		writer.WriteEndArray();
	}

	internal override int IndexOfItem(JToken item)
	{
		return _values.IndexOfReference(item);
	}

	internal override void MergeItem(object content, JsonMergeSettings settings)
	{
		IEnumerable enumerable = ((IsMultiContent(content) || content is JArray) ? ((IEnumerable)content) : null);
		if (enumerable != null)
		{
			JContainer.MergeEnumerableContent(this, enumerable, settings);
		}
	}

	/// <summary>
	///   Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1" />.
	/// </summary>
	/// <param name="item">
	///   The object to locate in the <see cref="T:System.Collections.Generic.IList`1" />.
	/// </param>
	/// <returns>
	///   The index of <paramref name="item" /> if found in the list; otherwise, -1.
	/// </returns>
	public int IndexOf(JToken item)
	{
		return IndexOfItem(item);
	}

	/// <summary>
	///   Inserts an item to the <see cref="T:System.Collections.Generic.IList`1" /> at the specified index.
	/// </summary>
	/// <param name="index">
	///   The zero-based index at which <paramref name="item" /> should be inserted.
	/// </param>
	/// <param name="item">
	///   The object to insert into the <see cref="T:System.Collections.Generic.IList`1" />.
	/// </param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1" />.
	/// </exception>
	/// <exception cref="T:System.NotSupportedException">
	///   The <see cref="T:System.Collections.Generic.IList`1" /> is read-only.
	/// </exception>
	public void Insert(int index, JToken item)
	{
		InsertItem(index, item, skipParentCheck: false);
	}

	/// <summary>
	///   Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.
	/// </summary>
	/// <param name="index">The zero-based index of the item to remove.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1" />.
	/// </exception>
	/// <exception cref="T:System.NotSupportedException">
	///   The <see cref="T:System.Collections.Generic.IList`1" /> is read-only.
	/// </exception>
	public void RemoveAt(int index)
	{
		RemoveItemAt(index);
	}

	/// <summary>
	///   Returns an enumerator that iterates through the collection.
	/// </summary>
	/// <returns>
	///   A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
	/// </returns>
	public IEnumerator<JToken> GetEnumerator()
	{
		return Children().GetEnumerator();
	}

	/// <summary>
	///   Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
	/// </summary>
	/// <param name="item">
	///   The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.
	/// </param>
	/// <exception cref="T:System.NotSupportedException">
	///   The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
	/// </exception>
	public void Add(JToken item)
	{
		Add((object)item);
	}

	/// <summary>
	///   Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
	/// </summary>
	/// <exception cref="T:System.NotSupportedException">
	///   The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
	/// </exception>
	public void Clear()
	{
		ClearItems();
	}

	/// <summary>
	///   Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
	/// </summary>
	/// <param name="item">
	///   The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.
	/// </param>
	/// <returns>
	///   true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.
	/// </returns>
	public bool Contains(JToken item)
	{
		return ContainsItem(item);
	}

	/// <summary>
	///   Copies to.
	/// </summary>
	/// <param name="array">The array.</param>
	/// <param name="arrayIndex">Index of the array.</param>
	public void CopyTo(JToken[] array, int arrayIndex)
	{
		CopyItemsTo(array, arrayIndex);
	}

	/// <summary>
	///   Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
	/// </summary>
	/// <param name="item">
	///   The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.
	/// </param>
	/// <returns>
	///   true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
	/// </returns>
	/// <exception cref="T:System.NotSupportedException">
	///   The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
	/// </exception>
	public bool Remove(JToken item)
	{
		return RemoveItem(item);
	}

	internal override int GetDeepHashCode()
	{
		return ContentsHashCode();
	}
}
