using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization;

/// <summary>
///   Contract details for a <see cref="T:System.Type" /> used by the <see cref="T:Newtonsoft.Json.JsonSerializer" />.
/// </summary>
public class JsonDictionaryContract : JsonContainerContract
{
	private readonly Type _genericCollectionDefinitionType;

	private Type _genericWrapperType;

	private ObjectConstructor<object> _genericWrapperCreator;

	private Func<object> _genericTemporaryDictionaryCreator;

	private readonly ConstructorInfo _parameterizedConstructor;

	private ObjectConstructor<object> _overrideCreator;

	private ObjectConstructor<object> _parameterizedCreator;

	/// <summary>
	///   Gets or sets the property name resolver.
	/// </summary>
	/// <value>The property name resolver.</value>
	[Obsolete("PropertyNameResolver is obsolete. Use DictionaryKeyResolver instead.")]
	public Func<string, string> PropertyNameResolver
	{
		get
		{
			return DictionaryKeyResolver;
		}
		set
		{
			DictionaryKeyResolver = value;
		}
	}

	/// <summary>
	///   Gets or sets the dictionary key resolver.
	/// </summary>
	/// <value>The dictionary key resolver.</value>
	public Func<string, string> DictionaryKeyResolver { get; set; }

	/// <summary>
	///   Gets the <see cref="T:System.Type" /> of the dictionary keys.
	/// </summary>
	/// <value>
	///   The <see cref="T:System.Type" /> of the dictionary keys.
	/// </value>
	public Type DictionaryKeyType { get; private set; }

	/// <summary>
	///   Gets the <see cref="T:System.Type" /> of the dictionary values.
	/// </summary>
	/// <value>
	///   The <see cref="T:System.Type" /> of the dictionary values.
	/// </value>
	public Type DictionaryValueType { get; private set; }

	internal JsonContract KeyContract { get; set; }

	internal bool ShouldCreateWrapper { get; private set; }

	internal ObjectConstructor<object> ParameterizedCreator
	{
		get
		{
			if (_parameterizedCreator == null)
			{
				_parameterizedCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor(_parameterizedConstructor);
			}
			return _parameterizedCreator;
		}
	}

	/// <summary>
	///   Gets or sets the function used to create the object. When set this function will override <see cref="P:Newtonsoft.Json.Serialization.JsonContract.DefaultCreator" />.
	/// </summary>
	/// <value>The function used to create the object.</value>
	public ObjectConstructor<object> OverrideCreator
	{
		get
		{
			return _overrideCreator;
		}
		set
		{
			_overrideCreator = value;
		}
	}

	/// <summary>
	///   Gets a value indicating whether the creator has a parameter with the dictionary values.
	/// </summary>
	/// <value>
	///   <c>true</c> if the creator has a parameter with the dictionary values; otherwise, <c>false</c>.
	/// </value>
	public bool HasParameterizedCreator { get; set; }

	internal bool HasParameterizedCreatorInternal
	{
		get
		{
			if (!HasParameterizedCreator && _parameterizedCreator == null)
			{
				return _parameterizedConstructor != null;
			}
			return true;
		}
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.Serialization.JsonDictionaryContract" /> class.
	/// </summary>
	/// <param name="underlyingType">The underlying type for the contract.</param>
	public JsonDictionaryContract(Type underlyingType)
		: base(underlyingType)
	{
		ContractType = JsonContractType.Dictionary;
		Type keyType;
		Type valueType;
		if (ReflectionUtils.ImplementsGenericDefinition(underlyingType, typeof(IDictionary<, >), out _genericCollectionDefinitionType))
		{
			keyType = _genericCollectionDefinitionType.GetGenericArguments()[0];
			valueType = _genericCollectionDefinitionType.GetGenericArguments()[1];
			if (ReflectionUtils.IsGenericDefinition(base.UnderlyingType, typeof(IDictionary<, >)))
			{
				base.CreatedType = typeof(Dictionary<, >).MakeGenericType(keyType, valueType);
			}
		}
		else
		{
			ReflectionUtils.GetDictionaryKeyValueTypes(base.UnderlyingType, out keyType, out valueType);
			if (base.UnderlyingType == typeof(IDictionary))
			{
				base.CreatedType = typeof(Dictionary<object, object>);
			}
		}
		if (keyType != null && valueType != null)
		{
			_parameterizedConstructor = CollectionUtils.ResolveEnumerableCollectionConstructor(base.CreatedType, typeof(KeyValuePair<, >).MakeGenericType(keyType, valueType), typeof(IDictionary<, >).MakeGenericType(keyType, valueType));
			if (!HasParameterizedCreatorInternal && underlyingType.Name == "FSharpMap`2")
			{
				FSharpUtils.EnsureInitialized(underlyingType.Assembly());
				_parameterizedCreator = FSharpUtils.CreateMap(keyType, valueType);
			}
		}
		ShouldCreateWrapper = !typeof(IDictionary).IsAssignableFrom(base.CreatedType);
		DictionaryKeyType = keyType;
		DictionaryValueType = valueType;
	}

	internal IWrappedDictionary CreateWrapper(object dictionary)
	{
		if (_genericWrapperCreator == null)
		{
			_genericWrapperType = typeof(DictionaryWrapper<, >).MakeGenericType(DictionaryKeyType, DictionaryValueType);
			ConstructorInfo constructor = _genericWrapperType.GetConstructor(new Type[1] { _genericCollectionDefinitionType });
			_genericWrapperCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor(constructor);
		}
		return (IWrappedDictionary)_genericWrapperCreator(dictionary);
	}

	internal IDictionary CreateTemporaryDictionary()
	{
		if (_genericTemporaryDictionaryCreator == null)
		{
			Type type = typeof(Dictionary<, >).MakeGenericType(DictionaryKeyType ?? typeof(object), DictionaryValueType ?? typeof(object));
			_genericTemporaryDictionaryCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateDefaultConstructor<object>(type);
		}
		return (IDictionary)_genericTemporaryDictionaryCreator();
	}
}
