using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq;

/// <summary>
///   Represents a JSON object.
/// </summary>
/// <example>
///   <code lang="cs" source="..\Src\Newtonsoft.Json.Tests\Documentation\LinqToJsonTests.cs" region="LinqToJsonCreateParse" title="Parsing a JSON Object from Text" />
/// </example>
public class JObject : JContainer, IDictionary<string, JToken>, ICollection<KeyValuePair<string, JToken>>, IEnumerable<KeyValuePair<string, JToken>>, IEnumerable, INotifyPropertyChanged, ICustomTypeDescriptor, INotifyPropertyChanging
{
	private class JObjectDynamicProxy : DynamicProxy<JObject>
	{
		public override bool TryGetMember(JObject instance, GetMemberBinder binder, out object result)
		{
			result = instance[binder.Name];
			return true;
		}

		public override bool TrySetMember(JObject instance, SetMemberBinder binder, object value)
		{
			JToken jToken = value as JToken;
			if (jToken == null)
			{
				jToken = new JValue(value);
			}
			instance[binder.Name] = jToken;
			return true;
		}

		public override IEnumerable<string> GetDynamicMemberNames(JObject instance)
		{
			return from p in instance.Properties()
				select p.Name;
		}
	}

	private readonly JPropertyKeyedCollection _properties = new JPropertyKeyedCollection();

	/// <summary>
	///   Gets the container's children tokens.
	/// </summary>
	/// <value>The container's children tokens.</value>
	protected override IList<JToken> ChildrenTokens => _properties;

	/// <summary>
	///   Gets the node type for this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <value>The type.</value>
	public override JTokenType Type => JTokenType.Object;

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
			if (!(key is string propertyName))
			{
				throw new ArgumentException("Accessed JObject values with invalid key value: {0}. Object property name expected.".FormatWith(CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(key)));
			}
			return this[propertyName];
		}
		set
		{
			ValidationUtils.ArgumentNotNull(key, "key");
			if (!(key is string propertyName))
			{
				throw new ArgumentException("Set JObject values with invalid key value: {0}. Object property name expected.".FormatWith(CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(key)));
			}
			this[propertyName] = value;
		}
	}

	/// <summary>
	///   Gets or sets the <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the specified property name.
	/// </summary>
	/// <value></value>
	public JToken this[string propertyName]
	{
		get
		{
			ValidationUtils.ArgumentNotNull(propertyName, "propertyName");
			return Property(propertyName)?.Value;
		}
		set
		{
			JProperty jProperty = Property(propertyName);
			if (jProperty != null)
			{
				jProperty.Value = value;
				return;
			}
			OnPropertyChanging(propertyName);
			Add(new JProperty(propertyName, value));
			OnPropertyChanged(propertyName);
		}
	}

	ICollection<string> IDictionary<string, JToken>.Keys => _properties.Keys;

	ICollection<JToken> IDictionary<string, JToken>.Values
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	bool ICollection<KeyValuePair<string, JToken>>.IsReadOnly => false;

	/// <summary>
	///   Occurs when a property value changes.
	/// </summary>
	public event PropertyChangedEventHandler PropertyChanged;

	/// <summary>
	///   Occurs when a property value is changing.
	/// </summary>
	public event PropertyChangingEventHandler PropertyChanging;

	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JObject" /> class.
	/// </summary>
	public JObject()
	{
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JObject" /> class from another <see cref="T:Newtonsoft.Json.Linq.JObject" /> object.
	/// </summary>
	/// <param name="other">
	///   A <see cref="T:Newtonsoft.Json.Linq.JObject" /> object to copy from.
	/// </param>
	public JObject(JObject other)
		: base(other)
	{
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JObject" /> class with the specified content.
	/// </summary>
	/// <param name="content">The contents of the object.</param>
	public JObject(params object[] content)
		: this((object)content)
	{
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JObject" /> class with the specified content.
	/// </summary>
	/// <param name="content">The contents of the object.</param>
	public JObject(object content)
	{
		Add(content);
	}

	internal override bool DeepEquals(JToken node)
	{
		if (!(node is JObject jObject))
		{
			return false;
		}
		return _properties.Compare(jObject._properties);
	}

	internal override int IndexOfItem(JToken item)
	{
		return _properties.IndexOfReference(item);
	}

	internal override void InsertItem(int index, JToken item, bool skipParentCheck)
	{
		if (item == null || item.Type != JTokenType.Comment)
		{
			base.InsertItem(index, item, skipParentCheck);
		}
	}

	internal override void ValidateToken(JToken o, JToken existing)
	{
		ValidationUtils.ArgumentNotNull(o, "o");
		if (o.Type != JTokenType.Property)
		{
			throw new ArgumentException("Can not add {0} to {1}.".FormatWith(CultureInfo.InvariantCulture, o.GetType(), GetType()));
		}
		JProperty jProperty = (JProperty)o;
		if (existing != null)
		{
			JProperty jProperty2 = (JProperty)existing;
			if (jProperty.Name == jProperty2.Name)
			{
				return;
			}
		}
		if (_properties.TryGetValue(jProperty.Name, out existing))
		{
			throw new ArgumentException("Can not add property {0} to {1}. Property with the same name already exists on object.".FormatWith(CultureInfo.InvariantCulture, jProperty.Name, GetType()));
		}
	}

	internal override void MergeItem(object content, JsonMergeSettings settings)
	{
		if (!(content is JObject jObject))
		{
			return;
		}
		foreach (KeyValuePair<string, JToken> item in jObject)
		{
			JProperty jProperty = Property(item.Key);
			if (jProperty == null)
			{
				Add(item.Key, item.Value);
			}
			else
			{
				if (item.Value == null)
				{
					continue;
				}
				if (!(jProperty.Value is JContainer jContainer))
				{
					if (item.Value.Type != JTokenType.Null || (settings != null && settings.MergeNullValueHandling == MergeNullValueHandling.Merge))
					{
						jProperty.Value = item.Value;
					}
				}
				else if (jContainer.Type != item.Value.Type)
				{
					jProperty.Value = item.Value;
				}
				else
				{
					jContainer.Merge(item.Value, settings);
				}
			}
		}
	}

	internal void InternalPropertyChanged(JProperty childProperty)
	{
		OnPropertyChanged(childProperty.Name);
		if (_listChanged != null)
		{
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, IndexOfItem(childProperty)));
		}
		if (_collectionChanged != null)
		{
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, childProperty, childProperty, IndexOfItem(childProperty)));
		}
	}

	internal void InternalPropertyChanging(JProperty childProperty)
	{
		OnPropertyChanging(childProperty.Name);
	}

	internal override JToken CloneToken()
	{
		return new JObject(this);
	}

	/// <summary>
	///   Gets an <see cref="T:System.Collections.Generic.IEnumerable`1" /> of this object's properties.
	/// </summary>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of this object's properties.
	/// </returns>
	public IEnumerable<JProperty> Properties()
	{
		return _properties.Cast<JProperty>();
	}

	/// <summary>
	///   Gets a <see cref="T:Newtonsoft.Json.Linq.JProperty" /> the specified name.
	/// </summary>
	/// <param name="name">The property name.</param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JProperty" /> with the specified name or null.
	/// </returns>
	public JProperty Property(string name)
	{
		if (name == null)
		{
			return null;
		}
		_properties.TryGetValue(name, out var value);
		return (JProperty)value;
	}

	/// <summary>
	///   Gets an <see cref="T:Newtonsoft.Json.Linq.JEnumerable`1" /> of this object's property values.
	/// </summary>
	/// <returns>
	///   An <see cref="T:Newtonsoft.Json.Linq.JEnumerable`1" /> of this object's property values.
	/// </returns>
	public JEnumerable<JToken> PropertyValues()
	{
		return new JEnumerable<JToken>(from p in Properties()
			select p.Value);
	}

	/// <summary>
	///   Loads an <see cref="T:Newtonsoft.Json.Linq.JObject" /> from a <see cref="T:Newtonsoft.Json.JsonReader" />.
	/// </summary>
	/// <param name="reader">
	///   A <see cref="T:Newtonsoft.Json.JsonReader" /> that will be read for the content of the <see cref="T:Newtonsoft.Json.Linq.JObject" />.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JObject" /> that contains the JSON that was read from the specified <see cref="T:Newtonsoft.Json.JsonReader" />.
	/// </returns>
	public new static JObject Load(JsonReader reader)
	{
		return Load(reader, null);
	}

	/// <summary>
	///   Loads an <see cref="T:Newtonsoft.Json.Linq.JObject" /> from a <see cref="T:Newtonsoft.Json.JsonReader" />.
	/// </summary>
	/// <param name="reader">
	///   A <see cref="T:Newtonsoft.Json.JsonReader" /> that will be read for the content of the <see cref="T:Newtonsoft.Json.Linq.JObject" />.
	/// </param>
	/// <param name="settings">
	///   The <see cref="T:Newtonsoft.Json.Linq.JsonLoadSettings" /> used to load the JSON.
	///   If this is null, default load settings will be used.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JObject" /> that contains the JSON that was read from the specified <see cref="T:Newtonsoft.Json.JsonReader" />.
	/// </returns>
	public new static JObject Load(JsonReader reader, JsonLoadSettings settings)
	{
		ValidationUtils.ArgumentNotNull(reader, "reader");
		if (reader.TokenType == JsonToken.None && !reader.Read())
		{
			throw JsonReaderException.Create(reader, "Error reading JObject from JsonReader.");
		}
		reader.MoveToContent();
		if (reader.TokenType != JsonToken.StartObject)
		{
			throw JsonReaderException.Create(reader, "Error reading JObject from JsonReader. Current JsonReader item is not an object: {0}".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
		}
		JObject jObject = new JObject();
		jObject.SetLineInfo(reader as IJsonLineInfo, settings);
		jObject.ReadTokenFrom(reader, settings);
		return jObject;
	}

	/// <summary>
	///   Load a <see cref="T:Newtonsoft.Json.Linq.JObject" /> from a string that contains JSON.
	/// </summary>
	/// <param name="json">
	///   A <see cref="T:System.String" /> that contains JSON.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JObject" /> populated from the string that contains JSON.
	/// </returns>
	/// <example>
	///   <code lang="cs" source="..\Src\Newtonsoft.Json.Tests\Documentation\LinqToJsonTests.cs" region="LinqToJsonCreateParse" title="Parsing a JSON Object from Text" />
	/// </example>
	public new static JObject Parse(string json)
	{
		return Parse(json, null);
	}

	/// <summary>
	///   Load a <see cref="T:Newtonsoft.Json.Linq.JObject" /> from a string that contains JSON.
	/// </summary>
	/// <param name="json">
	///   A <see cref="T:System.String" /> that contains JSON.
	/// </param>
	/// <param name="settings">
	///   The <see cref="T:Newtonsoft.Json.Linq.JsonLoadSettings" /> used to load the JSON.
	///   If this is null, default load settings will be used.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JObject" /> populated from the string that contains JSON.
	/// </returns>
	/// <example>
	///   <code lang="cs" source="..\Src\Newtonsoft.Json.Tests\Documentation\LinqToJsonTests.cs" region="LinqToJsonCreateParse" title="Parsing a JSON Object from Text" />
	/// </example>
	public new static JObject Parse(string json, JsonLoadSettings settings)
	{
		using JsonReader jsonReader = new JsonTextReader(new StringReader(json));
		JObject result = Load(jsonReader, settings);
		if (jsonReader.Read() && jsonReader.TokenType != JsonToken.Comment)
		{
			throw JsonReaderException.Create(jsonReader, "Additional text found in JSON string after parsing content.");
		}
		return result;
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Linq.JObject" /> from an object.
	/// </summary>
	/// <param name="o">
	///   The object that will be used to create <see cref="T:Newtonsoft.Json.Linq.JObject" />.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JObject" /> with the values of the specified object
	/// </returns>
	public new static JObject FromObject(object o)
	{
		return FromObject(o, JsonSerializer.CreateDefault());
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Linq.JObject" /> from an object.
	/// </summary>
	/// <param name="o">
	///   The object that will be used to create <see cref="T:Newtonsoft.Json.Linq.JObject" />.
	/// </param>
	/// <param name="jsonSerializer">
	///   The <see cref="T:Newtonsoft.Json.JsonSerializer" /> that will be used to read the object.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JObject" /> with the values of the specified object
	/// </returns>
	public new static JObject FromObject(object o, JsonSerializer jsonSerializer)
	{
		JToken jToken = JToken.FromObjectInternal(o, jsonSerializer);
		if (jToken != null && jToken.Type != JTokenType.Object)
		{
			throw new ArgumentException("Object serialized to {0}. JObject instance expected.".FormatWith(CultureInfo.InvariantCulture, jToken.Type));
		}
		return (JObject)jToken;
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
		writer.WriteStartObject();
		for (int i = 0; i < _properties.Count; i++)
		{
			_properties[i].WriteTo(writer, converters);
		}
		writer.WriteEndObject();
	}

	/// <summary>
	///   Gets the <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the specified property name.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the specified property name.
	/// </returns>
	public JToken GetValue(string propertyName)
	{
		return GetValue(propertyName, StringComparison.Ordinal);
	}

	/// <summary>
	///   Gets the <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the specified property name.
	///   The exact property name will be searched for first and if no matching property is found then
	///   the <see cref="T:System.StringComparison" /> will be used to match a property.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <param name="comparison">One of the enumeration values that specifies how the strings will be compared.</param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the specified property name.
	/// </returns>
	public JToken GetValue(string propertyName, StringComparison comparison)
	{
		if (propertyName == null)
		{
			return null;
		}
		JProperty jProperty = Property(propertyName);
		if (jProperty != null)
		{
			return jProperty.Value;
		}
		if (comparison != StringComparison.Ordinal)
		{
			foreach (JProperty property in _properties)
			{
				if (string.Equals(property.Name, propertyName, comparison))
				{
					return property.Value;
				}
			}
		}
		return null;
	}

	/// <summary>
	///   Tries to get the <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the specified property name.
	///   The exact property name will be searched for first and if no matching property is found then
	///   the <see cref="T:System.StringComparison" /> will be used to match a property.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <param name="value">The value.</param>
	/// <param name="comparison">One of the enumeration values that specifies how the strings will be compared.</param>
	/// <returns>
	///   <c>true</c> if a value was successfully retrieved; otherwise, <c>false</c>.
	/// </returns>
	public bool TryGetValue(string propertyName, StringComparison comparison, out JToken value)
	{
		value = GetValue(propertyName, comparison);
		return value != null;
	}

	/// <summary>
	///   Adds the specified property name.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <param name="value">The value.</param>
	public void Add(string propertyName, JToken value)
	{
		Add(new JProperty(propertyName, value));
	}

	bool IDictionary<string, JToken>.ContainsKey(string key)
	{
		return _properties.Contains(key);
	}

	/// <summary>
	///   Removes the property with the specified name.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <returns>
	///   <c>true</c> if item was successfully removed; otherwise, <c>false</c>.
	/// </returns>
	public bool Remove(string propertyName)
	{
		JProperty jProperty = Property(propertyName);
		if (jProperty == null)
		{
			return false;
		}
		jProperty.Remove();
		return true;
	}

	/// <summary>
	///   Tries the get value.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <param name="value">The value.</param>
	/// <returns>
	///   <c>true</c> if a value was successfully retrieved; otherwise, <c>false</c>.
	/// </returns>
	public bool TryGetValue(string propertyName, out JToken value)
	{
		JProperty jProperty = Property(propertyName);
		if (jProperty == null)
		{
			value = null;
			return false;
		}
		value = jProperty.Value;
		return true;
	}

	void ICollection<KeyValuePair<string, JToken>>.Add(KeyValuePair<string, JToken> item)
	{
		Add(new JProperty(item.Key, item.Value));
	}

	void ICollection<KeyValuePair<string, JToken>>.Clear()
	{
		RemoveAll();
	}

	bool ICollection<KeyValuePair<string, JToken>>.Contains(KeyValuePair<string, JToken> item)
	{
		JProperty jProperty = Property(item.Key);
		if (jProperty == null)
		{
			return false;
		}
		return jProperty.Value == item.Value;
	}

	void ICollection<KeyValuePair<string, JToken>>.CopyTo(KeyValuePair<string, JToken>[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (arrayIndex < 0)
		{
			throw new ArgumentOutOfRangeException("arrayIndex", "arrayIndex is less than 0.");
		}
		if (arrayIndex >= array.Length && arrayIndex != 0)
		{
			throw new ArgumentException("arrayIndex is equal to or greater than the length of array.");
		}
		if (base.Count > array.Length - arrayIndex)
		{
			throw new ArgumentException("The number of elements in the source JObject is greater than the available space from arrayIndex to the end of the destination array.");
		}
		int num = 0;
		foreach (JProperty property in _properties)
		{
			array[arrayIndex + num] = new KeyValuePair<string, JToken>(property.Name, property.Value);
			num++;
		}
	}

	bool ICollection<KeyValuePair<string, JToken>>.Remove(KeyValuePair<string, JToken> item)
	{
		if (!((ICollection<KeyValuePair<string, JToken>>)this).Contains(item))
		{
			return false;
		}
		((IDictionary<string, JToken>)this).Remove(item.Key);
		return true;
	}

	internal override int GetDeepHashCode()
	{
		return ContentsHashCode();
	}

	/// <summary>
	///   Returns an enumerator that iterates through the collection.
	/// </summary>
	/// <returns>
	///   A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
	/// </returns>
	public IEnumerator<KeyValuePair<string, JToken>> GetEnumerator()
	{
		foreach (JProperty property in _properties)
		{
			yield return new KeyValuePair<string, JToken>(property.Name, property.Value);
		}
	}

	/// <summary>
	///   Raises the <see cref="E:Newtonsoft.Json.Linq.JObject.PropertyChanged" /> event with the provided arguments.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	/// <summary>
	///   Raises the <see cref="E:Newtonsoft.Json.Linq.JObject.PropertyChanging" /> event with the provided arguments.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	protected virtual void OnPropertyChanging(string propertyName)
	{
		if (this.PropertyChanging != null)
		{
			this.PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
		}
	}

	/// <summary>
	///   Returns the properties for this instance of a component.
	/// </summary>
	/// <returns>
	///   A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> that represents the properties for this component instance.
	/// </returns>
	PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
	{
		return ((ICustomTypeDescriptor)this).GetProperties((Attribute[])null);
	}

	/// <summary>
	///   Returns the properties for this instance of a component using the attribute array as a filter.
	/// </summary>
	/// <param name="attributes">
	///   An array of type <see cref="T:System.Attribute" /> that is used as a filter.
	/// </param>
	/// <returns>
	///   A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> that represents the filtered properties for this component instance.
	/// </returns>
	PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
	{
		PropertyDescriptorCollection propertyDescriptorCollection = new PropertyDescriptorCollection(null);
		using IEnumerator<KeyValuePair<string, JToken>> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			propertyDescriptorCollection.Add(new JPropertyDescriptor(enumerator.Current.Key));
		}
		return propertyDescriptorCollection;
	}

	/// <summary>
	///   Returns a collection of custom attributes for this instance of a component.
	/// </summary>
	/// <returns>
	///   An <see cref="T:System.ComponentModel.AttributeCollection" /> containing the attributes for this object.
	/// </returns>
	AttributeCollection ICustomTypeDescriptor.GetAttributes()
	{
		return AttributeCollection.Empty;
	}

	/// <summary>
	///   Returns the class name of this instance of a component.
	/// </summary>
	/// <returns>
	///   The class name of the object, or null if the class does not have a name.
	/// </returns>
	string ICustomTypeDescriptor.GetClassName()
	{
		return null;
	}

	/// <summary>
	///   Returns the name of this instance of a component.
	/// </summary>
	/// <returns>
	///   The name of the object, or null if the object does not have a name.
	/// </returns>
	string ICustomTypeDescriptor.GetComponentName()
	{
		return null;
	}

	/// <summary>
	///   Returns a type converter for this instance of a component.
	/// </summary>
	/// <returns>
	///   A <see cref="T:System.ComponentModel.TypeConverter" /> that is the converter for this object, or null if there is no <see cref="T:System.ComponentModel.TypeConverter" /> for this object.
	/// </returns>
	TypeConverter ICustomTypeDescriptor.GetConverter()
	{
		return new TypeConverter();
	}

	/// <summary>
	///   Returns the default event for this instance of a component.
	/// </summary>
	/// <returns>
	///   An <see cref="T:System.ComponentModel.EventDescriptor" /> that represents the default event for this object, or null if this object does not have events.
	/// </returns>
	EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
	{
		return null;
	}

	/// <summary>
	///   Returns the default property for this instance of a component.
	/// </summary>
	/// <returns>
	///   A <see cref="T:System.ComponentModel.PropertyDescriptor" /> that represents the default property for this object, or null if this object does not have properties.
	/// </returns>
	PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
	{
		return null;
	}

	/// <summary>
	///   Returns an editor of the specified type for this instance of a component.
	/// </summary>
	/// <param name="editorBaseType">
	///   A <see cref="T:System.Type" /> that represents the editor for this object.
	/// </param>
	/// <returns>
	///   An <see cref="T:System.Object" /> of the specified type that is the editor for this object, or null if the editor cannot be found.
	/// </returns>
	object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
	{
		return null;
	}

	/// <summary>
	///   Returns the events for this instance of a component using the specified attribute array as a filter.
	/// </summary>
	/// <param name="attributes">
	///   An array of type <see cref="T:System.Attribute" /> that is used as a filter.
	/// </param>
	/// <returns>
	///   An <see cref="T:System.ComponentModel.EventDescriptorCollection" /> that represents the filtered events for this component instance.
	/// </returns>
	EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
	{
		return EventDescriptorCollection.Empty;
	}

	/// <summary>
	///   Returns the events for this instance of a component.
	/// </summary>
	/// <returns>
	///   An <see cref="T:System.ComponentModel.EventDescriptorCollection" /> that represents the events for this component instance.
	/// </returns>
	EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
	{
		return EventDescriptorCollection.Empty;
	}

	/// <summary>
	///   Returns an object that contains the property described by the specified property descriptor.
	/// </summary>
	/// <param name="pd">
	///   A <see cref="T:System.ComponentModel.PropertyDescriptor" /> that represents the property whose owner is to be found.
	/// </param>
	/// <returns>
	///   An <see cref="T:System.Object" /> that represents the owner of the specified property.
	/// </returns>
	object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
	{
		return null;
	}

	/// <summary>
	///   Returns the <see cref="T:System.Dynamic.DynamicMetaObject" /> responsible for binding operations performed on this object.
	/// </summary>
	/// <param name="parameter">The expression tree representation of the runtime value.</param>
	/// <returns>
	///   The <see cref="T:System.Dynamic.DynamicMetaObject" /> to bind this object.
	/// </returns>
	protected override DynamicMetaObject GetMetaObject(Expression parameter)
	{
		return new DynamicProxyMetaObject<JObject>(parameter, this, new JObjectDynamicProxy(), dontFallbackFirst: true);
	}
}
