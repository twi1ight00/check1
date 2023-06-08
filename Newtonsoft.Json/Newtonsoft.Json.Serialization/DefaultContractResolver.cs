using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization;

/// <summary>
///   Used by <see cref="T:Newtonsoft.Json.JsonSerializer" /> to resolves a <see cref="T:Newtonsoft.Json.Serialization.JsonContract" /> for a given <see cref="T:System.Type" />.
/// </summary>
public class DefaultContractResolver : IContractResolver
{
	internal class EnumerableDictionaryWrapper<TEnumeratorKey, TEnumeratorValue> : IEnumerable<KeyValuePair<object, object>>, IEnumerable
	{
		private readonly IEnumerable<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> _e;

		public EnumerableDictionaryWrapper(IEnumerable<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> e)
		{
			ValidationUtils.ArgumentNotNull(e, "e");
			_e = e;
		}

		public IEnumerator<KeyValuePair<object, object>> GetEnumerator()
		{
			foreach (KeyValuePair<TEnumeratorKey, TEnumeratorValue> item in _e)
			{
				yield return new KeyValuePair<object, object>(item.Key, item.Value);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	private static readonly IContractResolver _instance = new DefaultContractResolver(shareCache: true);

	private static readonly JsonConverter[] BuiltInConverters = new JsonConverter[10]
	{
		new EntityKeyMemberConverter(),
		new ExpandoObjectConverter(),
		new XmlNodeConverter(),
		new BinaryConverter(),
		new DataSetConverter(),
		new DataTableConverter(),
		new DiscriminatedUnionConverter(),
		new KeyValuePairConverter(),
		new BsonObjectIdConverter(),
		new RegexConverter()
	};

	private static readonly object TypeContractCacheLock = new object();

	private static readonly DefaultContractResolverState _sharedState = new DefaultContractResolverState();

	private readonly DefaultContractResolverState _instanceState = new DefaultContractResolverState();

	private readonly bool _sharedCache;

	internal static IContractResolver Instance => _instance;

	/// <summary>
	///   Gets a value indicating whether members are being get and set using dynamic code generation.
	///   This value is determined by the runtime permissions available.
	/// </summary>
	/// <value>
	///   <c>true</c> if using dynamic code generation; otherwise, <c>false</c>.
	/// </value>
	public bool DynamicCodeGeneration => JsonTypeReflector.DynamicCodeGeneration;

	/// <summary>
	///   Gets or sets the default members search flags.
	/// </summary>
	/// <value>The default members search flags.</value>
	[Obsolete("DefaultMembersSearchFlags is obsolete. To modify the members serialized inherit from DefaultContractResolver and override the GetSerializableMembers method instead.")]
	public BindingFlags DefaultMembersSearchFlags { get; set; }

	/// <summary>
	///   Gets or sets a value indicating whether compiler generated members should be serialized.
	/// </summary>
	/// <value>
	///   <c>true</c> if serialized compiler generated members; otherwise, <c>false</c>.
	/// </value>
	public bool SerializeCompilerGeneratedMembers { get; set; }

	/// <summary>
	///   Gets or sets a value indicating whether to ignore the <see cref="T:System.Runtime.Serialization.ISerializable" /> interface when serializing and deserializing types.
	/// </summary>
	/// <value>
	///   <c>true</c> if the <see cref="T:System.Runtime.Serialization.ISerializable" /> interface will be ignored when serializing and deserializing types; otherwise, <c>false</c>.
	/// </value>
	public bool IgnoreSerializableInterface { get; set; }

	/// <summary>
	///   Gets or sets a value indicating whether to ignore the <see cref="T:System.SerializableAttribute" /> attribute when serializing and deserializing types.
	/// </summary>
	/// <value>
	///   <c>true</c> if the <see cref="T:System.SerializableAttribute" /> attribute will be ignored when serializing and deserializing types; otherwise, <c>false</c>.
	/// </value>
	public bool IgnoreSerializableAttribute { get; set; }

	/// <summary>
	///   Gets or sets the naming strategy used to resolve how property names and dictionary keys are serialized.
	/// </summary>
	/// <value>The naming strategy used to resolve how property names and dictionary keys are serialized.</value>
	public NamingStrategy NamingStrategy { get; set; }

	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.Serialization.DefaultContractResolver" /> class.
	/// </summary>
	public DefaultContractResolver()
	{
		IgnoreSerializableAttribute = true;
		DefaultMembersSearchFlags = BindingFlags.Instance | BindingFlags.Public;
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.Serialization.DefaultContractResolver" /> class.
	/// </summary>
	/// <param name="shareCache">
	///   If set to <c>true</c> the <see cref="T:Newtonsoft.Json.Serialization.DefaultContractResolver" /> will use a cached shared with other resolvers of the same type.
	///   Sharing the cache will significantly improve performance with multiple resolver instances because expensive reflection will only
	///   happen once. This setting can cause unexpected behavior if different instances of the resolver are suppose to produce different
	///   results. When set to false it is highly recommended to reuse <see cref="T:Newtonsoft.Json.Serialization.DefaultContractResolver" /> instances with the <see cref="T:Newtonsoft.Json.JsonSerializer" />.
	/// </param>
	[Obsolete("DefaultContractResolver(bool) is obsolete. Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance.")]
	public DefaultContractResolver(bool shareCache)
		: this()
	{
		_sharedCache = shareCache;
	}

	internal DefaultContractResolverState GetState()
	{
		if (_sharedCache)
		{
			return _sharedState;
		}
		return _instanceState;
	}

	/// <summary>
	///   Resolves the contract for a given type.
	/// </summary>
	/// <param name="type">The type to resolve a contract for.</param>
	/// <returns>The contract for a given type.</returns>
	public virtual JsonContract ResolveContract(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		DefaultContractResolverState state = GetState();
		ResolverContractKey key = new ResolverContractKey(GetType(), type);
		Dictionary<ResolverContractKey, JsonContract> contractCache = state.ContractCache;
		if (contractCache == null || !contractCache.TryGetValue(key, out var value))
		{
			value = CreateContract(type);
			lock (TypeContractCacheLock)
			{
				contractCache = state.ContractCache;
				Dictionary<ResolverContractKey, JsonContract> dictionary = ((contractCache != null) ? new Dictionary<ResolverContractKey, JsonContract>(contractCache) : new Dictionary<ResolverContractKey, JsonContract>());
				dictionary[key] = value;
				state.ContractCache = dictionary;
			}
		}
		return value;
	}

	/// <summary>
	///   Gets the serializable members for the type.
	/// </summary>
	/// <param name="objectType">The type to get serializable members for.</param>
	/// <returns>The serializable members for the type.</returns>
	protected virtual List<MemberInfo> GetSerializableMembers(Type objectType)
	{
		bool ignoreSerializableAttribute = IgnoreSerializableAttribute;
		MemberSerialization objectMemberSerialization = JsonTypeReflector.GetObjectMemberSerialization(objectType, ignoreSerializableAttribute);
		List<MemberInfo> list = (from m in ReflectionUtils.GetFieldsAndProperties(objectType, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
			where !ReflectionUtils.IsIndexedProperty(m)
			select m).ToList();
		List<MemberInfo> list2 = new List<MemberInfo>();
		if (objectMemberSerialization != MemberSerialization.Fields)
		{
			DataContractAttribute dataContractAttribute = JsonTypeReflector.GetDataContractAttribute(objectType);
			List<MemberInfo> list3 = (from m in ReflectionUtils.GetFieldsAndProperties(objectType, DefaultMembersSearchFlags)
				where !ReflectionUtils.IsIndexedProperty(m)
				select m).ToList();
			foreach (MemberInfo item in list)
			{
				if (SerializeCompilerGeneratedMembers || !item.IsDefined(typeof(CompilerGeneratedAttribute), inherit: true))
				{
					if (list3.Contains(item))
					{
						list2.Add(item);
					}
					else if (JsonTypeReflector.GetAttribute<JsonPropertyAttribute>(item) != null)
					{
						list2.Add(item);
					}
					else if (JsonTypeReflector.GetAttribute<JsonRequiredAttribute>(item) != null)
					{
						list2.Add(item);
					}
					else if (dataContractAttribute != null && JsonTypeReflector.GetAttribute<DataMemberAttribute>(item) != null)
					{
						list2.Add(item);
					}
					else if (objectMemberSerialization == MemberSerialization.Fields && item.MemberType() == MemberTypes.Field)
					{
						list2.Add(item);
					}
				}
			}
			if (objectType.AssignableToTypeName("System.Data.Objects.DataClasses.EntityObject", out var _))
			{
				list2 = list2.Where(ShouldSerializeEntityMember).ToList();
			}
		}
		else
		{
			foreach (MemberInfo item2 in list)
			{
				FieldInfo fieldInfo = item2 as FieldInfo;
				if (fieldInfo != null && !fieldInfo.IsStatic)
				{
					list2.Add(item2);
				}
			}
		}
		return list2;
	}

	private bool ShouldSerializeEntityMember(MemberInfo memberInfo)
	{
		PropertyInfo propertyInfo = memberInfo as PropertyInfo;
		if (propertyInfo != null && propertyInfo.PropertyType.IsGenericType() && propertyInfo.PropertyType.GetGenericTypeDefinition().FullName == "System.Data.Objects.DataClasses.EntityReference`1")
		{
			return false;
		}
		return true;
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonObjectContract" /> for the given type.
	/// </summary>
	/// <param name="objectType">Type of the object.</param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Serialization.JsonObjectContract" /> for the given type.
	/// </returns>
	protected virtual JsonObjectContract CreateObjectContract(Type objectType)
	{
		JsonObjectContract jsonObjectContract = new JsonObjectContract(objectType);
		InitializeContract(jsonObjectContract);
		bool ignoreSerializableAttribute = IgnoreSerializableAttribute;
		jsonObjectContract.MemberSerialization = JsonTypeReflector.GetObjectMemberSerialization(jsonObjectContract.NonNullableUnderlyingType, ignoreSerializableAttribute);
		jsonObjectContract.Properties.AddRange(CreateProperties(jsonObjectContract.NonNullableUnderlyingType, jsonObjectContract.MemberSerialization));
		JsonObjectAttribute cachedAttribute = JsonTypeReflector.GetCachedAttribute<JsonObjectAttribute>(jsonObjectContract.NonNullableUnderlyingType);
		if (cachedAttribute != null)
		{
			jsonObjectContract.ItemRequired = cachedAttribute._itemRequired;
		}
		if (jsonObjectContract.IsInstantiable)
		{
			ConstructorInfo attributeConstructor = GetAttributeConstructor(jsonObjectContract.NonNullableUnderlyingType);
			if (attributeConstructor != null)
			{
				jsonObjectContract.OverrideConstructor = attributeConstructor;
				jsonObjectContract.CreatorParameters.AddRange(CreateConstructorParameters(attributeConstructor, jsonObjectContract.Properties));
			}
			else if (jsonObjectContract.MemberSerialization == MemberSerialization.Fields)
			{
				if (JsonTypeReflector.FullyTrusted)
				{
					jsonObjectContract.DefaultCreator = jsonObjectContract.GetUninitializedObject;
				}
			}
			else if (jsonObjectContract.DefaultCreator == null || jsonObjectContract.DefaultCreatorNonPublic)
			{
				ConstructorInfo parameterizedConstructor = GetParameterizedConstructor(jsonObjectContract.NonNullableUnderlyingType);
				if (parameterizedConstructor != null)
				{
					jsonObjectContract.ParametrizedConstructor = parameterizedConstructor;
					jsonObjectContract.CreatorParameters.AddRange(CreateConstructorParameters(parameterizedConstructor, jsonObjectContract.Properties));
				}
			}
		}
		MemberInfo extensionDataMemberForType = GetExtensionDataMemberForType(jsonObjectContract.NonNullableUnderlyingType);
		if (extensionDataMemberForType != null)
		{
			SetExtensionDataDelegates(jsonObjectContract, extensionDataMemberForType);
		}
		return jsonObjectContract;
	}

	private MemberInfo GetExtensionDataMemberForType(Type type)
	{
		return GetClassHierarchyForType(type).SelectMany(delegate(Type baseType)
		{
			List<MemberInfo> list = new List<MemberInfo>();
			CollectionUtils.AddRange(list, baseType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			CollectionUtils.AddRange(list, baseType.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			return list;
		}).LastOrDefault(delegate(MemberInfo m)
		{
			MemberTypes memberTypes = m.MemberType();
			if (memberTypes != MemberTypes.Property && memberTypes != MemberTypes.Field)
			{
				return false;
			}
			if (!m.IsDefined(typeof(JsonExtensionDataAttribute), inherit: false))
			{
				return false;
			}
			if (!ReflectionUtils.CanReadMemberValue(m, nonPublic: true))
			{
				throw new JsonException("Invalid extension data attribute on '{0}'. Member '{1}' must have a getter.".FormatWith(CultureInfo.InvariantCulture, GetClrTypeFullName(m.DeclaringType), m.Name));
			}
			if (ReflectionUtils.ImplementsGenericDefinition(ReflectionUtils.GetMemberUnderlyingType(m), typeof(IDictionary<, >), out var implementingType))
			{
				Type obj = implementingType.GetGenericArguments()[0];
				Type type2 = implementingType.GetGenericArguments()[1];
				if (obj.IsAssignableFrom(typeof(string)) && type2.IsAssignableFrom(typeof(JToken)))
				{
					return true;
				}
			}
			throw new JsonException("Invalid extension data attribute on '{0}'. Member '{1}' type must implement IDictionary<string, JToken>.".FormatWith(CultureInfo.InvariantCulture, GetClrTypeFullName(m.DeclaringType), m.Name));
		});
	}

	private static void SetExtensionDataDelegates(JsonObjectContract contract, MemberInfo member)
	{
		JsonExtensionDataAttribute attribute = ReflectionUtils.GetAttribute<JsonExtensionDataAttribute>(member);
		if (attribute == null)
		{
			return;
		}
		Type memberUnderlyingType = ReflectionUtils.GetMemberUnderlyingType(member);
		ReflectionUtils.ImplementsGenericDefinition(memberUnderlyingType, typeof(IDictionary<, >), out var implementingType);
		Type type = implementingType.GetGenericArguments()[0];
		Type type2 = implementingType.GetGenericArguments()[1];
		Type type3 = ((!ReflectionUtils.IsGenericDefinition(memberUnderlyingType, typeof(IDictionary<, >))) ? memberUnderlyingType : typeof(Dictionary<, >).MakeGenericType(type, type2));
		Func<object, object> getExtensionDataDictionary = JsonTypeReflector.ReflectionDelegateFactory.CreateGet<object>(member);
		if (attribute.ReadData)
		{
			Action<object, object> setExtensionDataDictionary = (ReflectionUtils.CanSetMemberValue(member, nonPublic: true, canSetReadOnly: false) ? JsonTypeReflector.ReflectionDelegateFactory.CreateSet<object>(member) : null);
			Func<object> createExtensionDataDictionary = JsonTypeReflector.ReflectionDelegateFactory.CreateDefaultConstructor<object>(type3);
			MethodInfo method = memberUnderlyingType.GetMethod("Add", new Type[2] { type, type2 });
			MethodCall<object, object> setExtensionDataDictionaryValue = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>(method);
			ExtensionDataSetter extensionDataSetter = delegate(object o, string key, object value)
			{
				object obj2 = getExtensionDataDictionary(o);
				if (obj2 == null)
				{
					if (setExtensionDataDictionary == null)
					{
						throw new JsonSerializationException("Cannot set value onto extension data member '{0}'. The extension data collection is null and it cannot be set.".FormatWith(CultureInfo.InvariantCulture, member.Name));
					}
					obj2 = createExtensionDataDictionary();
					setExtensionDataDictionary(o, obj2);
				}
				setExtensionDataDictionaryValue(obj2, key, value);
			};
			contract.ExtensionDataSetter = extensionDataSetter;
		}
		if (attribute.WriteData)
		{
			ConstructorInfo method2 = typeof(EnumerableDictionaryWrapper<, >).MakeGenericType(type, type2).GetConstructors().First();
			ObjectConstructor<object> createEnumerableWrapper = JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor(method2);
			ExtensionDataGetter extensionDataGetter = delegate(object o)
			{
				object obj = getExtensionDataDictionary(o);
				return (obj == null) ? null : ((IEnumerable<KeyValuePair<object, object>>)createEnumerableWrapper(obj));
			};
			contract.ExtensionDataGetter = extensionDataGetter;
		}
		contract.ExtensionDataValueType = type2;
	}

	private ConstructorInfo GetAttributeConstructor(Type objectType)
	{
		IList<ConstructorInfo> list = (from c in objectType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
			where c.IsDefined(typeof(JsonConstructorAttribute), inherit: true)
			select c).ToList();
		if (list.Count > 1)
		{
			throw new JsonException("Multiple constructors with the JsonConstructorAttribute.");
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		if (objectType == typeof(Version))
		{
			return objectType.GetConstructor(new Type[4]
			{
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int)
			});
		}
		return null;
	}

	private ConstructorInfo GetParameterizedConstructor(Type objectType)
	{
		IList<ConstructorInfo> list = objectType.GetConstructors(BindingFlags.Instance | BindingFlags.Public).ToList();
		if (list.Count == 1)
		{
			return list[0];
		}
		return null;
	}

	/// <summary>
	///   Creates the constructor parameters.
	/// </summary>
	/// <param name="constructor">The constructor to create properties for.</param>
	/// <param name="memberProperties">The type's member properties.</param>
	/// <returns>
	///   Properties for the given <see cref="T:System.Reflection.ConstructorInfo" />.
	/// </returns>
	protected virtual IList<JsonProperty> CreateConstructorParameters(ConstructorInfo constructor, JsonPropertyCollection memberProperties)
	{
		ParameterInfo[] parameters = constructor.GetParameters();
		JsonPropertyCollection jsonPropertyCollection = new JsonPropertyCollection(constructor.DeclaringType);
		ParameterInfo[] array = parameters;
		foreach (ParameterInfo parameterInfo in array)
		{
			JsonProperty jsonProperty = ((parameterInfo.Name != null) ? memberProperties.GetClosestMatchProperty(parameterInfo.Name) : null);
			if (jsonProperty != null && jsonProperty.PropertyType != parameterInfo.ParameterType)
			{
				jsonProperty = null;
			}
			if (jsonProperty != null || parameterInfo.Name != null)
			{
				JsonProperty jsonProperty2 = CreatePropertyFromConstructorParameter(jsonProperty, parameterInfo);
				if (jsonProperty2 != null)
				{
					jsonPropertyCollection.AddProperty(jsonProperty2);
				}
			}
		}
		return jsonPropertyCollection;
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.ParameterInfo" />.
	/// </summary>
	/// <param name="matchingMemberProperty">The matching member property.</param>
	/// <param name="parameterInfo">The constructor parameter.</param>
	/// <returns>
	///   A created <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.ParameterInfo" />.
	/// </returns>
	protected virtual JsonProperty CreatePropertyFromConstructorParameter(JsonProperty matchingMemberProperty, ParameterInfo parameterInfo)
	{
		JsonProperty jsonProperty = new JsonProperty();
		jsonProperty.PropertyType = parameterInfo.ParameterType;
		jsonProperty.AttributeProvider = new ReflectionAttributeProvider(parameterInfo);
		SetPropertySettingsFromAttributes(jsonProperty, parameterInfo, parameterInfo.Name, parameterInfo.Member.DeclaringType, MemberSerialization.OptOut, out var _);
		jsonProperty.Readable = false;
		jsonProperty.Writable = true;
		if (matchingMemberProperty != null)
		{
			jsonProperty.PropertyName = ((jsonProperty.PropertyName != parameterInfo.Name) ? jsonProperty.PropertyName : matchingMemberProperty.PropertyName);
			jsonProperty.Converter = jsonProperty.Converter ?? matchingMemberProperty.Converter;
			jsonProperty.MemberConverter = jsonProperty.MemberConverter ?? matchingMemberProperty.MemberConverter;
			if (!jsonProperty._hasExplicitDefaultValue && matchingMemberProperty._hasExplicitDefaultValue)
			{
				jsonProperty.DefaultValue = matchingMemberProperty.DefaultValue;
			}
			jsonProperty._required = jsonProperty._required ?? matchingMemberProperty._required;
			jsonProperty.IsReference = jsonProperty.IsReference ?? matchingMemberProperty.IsReference;
			jsonProperty.NullValueHandling = jsonProperty.NullValueHandling ?? matchingMemberProperty.NullValueHandling;
			jsonProperty.DefaultValueHandling = jsonProperty.DefaultValueHandling ?? matchingMemberProperty.DefaultValueHandling;
			jsonProperty.ReferenceLoopHandling = jsonProperty.ReferenceLoopHandling ?? matchingMemberProperty.ReferenceLoopHandling;
			jsonProperty.ObjectCreationHandling = jsonProperty.ObjectCreationHandling ?? matchingMemberProperty.ObjectCreationHandling;
			jsonProperty.TypeNameHandling = jsonProperty.TypeNameHandling ?? matchingMemberProperty.TypeNameHandling;
		}
		return jsonProperty;
	}

	/// <summary>
	///   Resolves the default <see cref="T:Newtonsoft.Json.JsonConverter" /> for the contract.
	/// </summary>
	/// <param name="objectType">Type of the object.</param>
	/// <returns>
	///   The contract's default <see cref="T:Newtonsoft.Json.JsonConverter" />.
	/// </returns>
	protected virtual JsonConverter ResolveContractConverter(Type objectType)
	{
		return JsonTypeReflector.GetJsonConverter(objectType);
	}

	private Func<object> GetDefaultCreator(Type createdType)
	{
		return JsonTypeReflector.ReflectionDelegateFactory.CreateDefaultConstructor<object>(createdType);
	}

	private void InitializeContract(JsonContract contract)
	{
		JsonContainerAttribute cachedAttribute = JsonTypeReflector.GetCachedAttribute<JsonContainerAttribute>(contract.NonNullableUnderlyingType);
		if (cachedAttribute != null)
		{
			contract.IsReference = cachedAttribute._isReference;
		}
		else
		{
			DataContractAttribute dataContractAttribute = JsonTypeReflector.GetDataContractAttribute(contract.NonNullableUnderlyingType);
			if (dataContractAttribute != null && dataContractAttribute.IsReference)
			{
				contract.IsReference = true;
			}
		}
		contract.Converter = ResolveContractConverter(contract.NonNullableUnderlyingType);
		contract.InternalConverter = JsonSerializer.GetMatchingConverter(BuiltInConverters, contract.NonNullableUnderlyingType);
		if (contract.IsInstantiable && (ReflectionUtils.HasDefaultConstructor(contract.CreatedType, nonPublic: true) || contract.CreatedType.IsValueType()))
		{
			contract.DefaultCreator = GetDefaultCreator(contract.CreatedType);
			contract.DefaultCreatorNonPublic = !contract.CreatedType.IsValueType() && ReflectionUtils.GetDefaultConstructor(contract.CreatedType) == null;
		}
		ResolveCallbackMethods(contract, contract.NonNullableUnderlyingType);
	}

	private void ResolveCallbackMethods(JsonContract contract, Type t)
	{
		GetCallbackMethodsForType(t, out var onSerializing, out var onSerialized, out var onDeserializing, out var onDeserialized, out var onError);
		if (onSerializing != null)
		{
			contract.OnSerializingCallbacks.AddRange(onSerializing);
		}
		if (onSerialized != null)
		{
			contract.OnSerializedCallbacks.AddRange(onSerialized);
		}
		if (onDeserializing != null)
		{
			contract.OnDeserializingCallbacks.AddRange(onDeserializing);
		}
		if (onDeserialized != null)
		{
			contract.OnDeserializedCallbacks.AddRange(onDeserialized);
		}
		if (onError != null)
		{
			contract.OnErrorCallbacks.AddRange(onError);
		}
	}

	private void GetCallbackMethodsForType(Type type, out List<SerializationCallback> onSerializing, out List<SerializationCallback> onSerialized, out List<SerializationCallback> onDeserializing, out List<SerializationCallback> onDeserialized, out List<SerializationErrorCallback> onError)
	{
		onSerializing = null;
		onSerialized = null;
		onDeserializing = null;
		onDeserialized = null;
		onError = null;
		foreach (Type item in GetClassHierarchyForType(type))
		{
			MethodInfo currentCallback = null;
			MethodInfo currentCallback2 = null;
			MethodInfo currentCallback3 = null;
			MethodInfo currentCallback4 = null;
			MethodInfo currentCallback5 = null;
			bool flag = ShouldSkipSerializing(item);
			bool flag2 = ShouldSkipDeserialized(item);
			MethodInfo[] methods = item.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (MethodInfo methodInfo in methods)
			{
				if (!methodInfo.ContainsGenericParameters)
				{
					Type prevAttributeType = null;
					ParameterInfo[] parameters = methodInfo.GetParameters();
					if (!flag && IsValidCallback(methodInfo, parameters, typeof(OnSerializingAttribute), currentCallback, ref prevAttributeType))
					{
						onSerializing = onSerializing ?? new List<SerializationCallback>();
						onSerializing.Add(JsonContract.CreateSerializationCallback(methodInfo));
						currentCallback = methodInfo;
					}
					if (IsValidCallback(methodInfo, parameters, typeof(OnSerializedAttribute), currentCallback2, ref prevAttributeType))
					{
						onSerialized = onSerialized ?? new List<SerializationCallback>();
						onSerialized.Add(JsonContract.CreateSerializationCallback(methodInfo));
						currentCallback2 = methodInfo;
					}
					if (IsValidCallback(methodInfo, parameters, typeof(OnDeserializingAttribute), currentCallback3, ref prevAttributeType))
					{
						onDeserializing = onDeserializing ?? new List<SerializationCallback>();
						onDeserializing.Add(JsonContract.CreateSerializationCallback(methodInfo));
						currentCallback3 = methodInfo;
					}
					if (!flag2 && IsValidCallback(methodInfo, parameters, typeof(OnDeserializedAttribute), currentCallback4, ref prevAttributeType))
					{
						onDeserialized = onDeserialized ?? new List<SerializationCallback>();
						onDeserialized.Add(JsonContract.CreateSerializationCallback(methodInfo));
						currentCallback4 = methodInfo;
					}
					if (IsValidCallback(methodInfo, parameters, typeof(OnErrorAttribute), currentCallback5, ref prevAttributeType))
					{
						onError = onError ?? new List<SerializationErrorCallback>();
						onError.Add(JsonContract.CreateSerializationErrorCallback(methodInfo));
						currentCallback5 = methodInfo;
					}
				}
			}
		}
	}

	private static bool ShouldSkipDeserialized(Type t)
	{
		if (t.IsGenericType() && t.GetGenericTypeDefinition() == typeof(ConcurrentDictionary<, >))
		{
			return true;
		}
		if (t.Name == "FSharpSet`1" || t.Name == "FSharpMap`2")
		{
			return true;
		}
		return false;
	}

	private static bool ShouldSkipSerializing(Type t)
	{
		if (t.Name == "FSharpSet`1" || t.Name == "FSharpMap`2")
		{
			return true;
		}
		return false;
	}

	private List<Type> GetClassHierarchyForType(Type type)
	{
		List<Type> list = new List<Type>();
		Type type2 = type;
		while (type2 != null && type2 != typeof(object))
		{
			list.Add(type2);
			type2 = type2.BaseType();
		}
		list.Reverse();
		return list;
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonDictionaryContract" /> for the given type.
	/// </summary>
	/// <param name="objectType">Type of the object.</param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Serialization.JsonDictionaryContract" /> for the given type.
	/// </returns>
	protected virtual JsonDictionaryContract CreateDictionaryContract(Type objectType)
	{
		JsonDictionaryContract jsonDictionaryContract = new JsonDictionaryContract(objectType);
		InitializeContract(jsonDictionaryContract);
		JsonContainerAttribute attribute = JsonTypeReflector.GetAttribute<JsonContainerAttribute>(objectType);
		if (attribute?.NamingStrategyType != null)
		{
			NamingStrategy namingStrategy = JsonTypeReflector.GetContainerNamingStrategy(attribute);
			jsonDictionaryContract.DictionaryKeyResolver = (string s) => namingStrategy.GetDictionaryKey(s);
		}
		else
		{
			jsonDictionaryContract.DictionaryKeyResolver = ResolveDictionaryKey;
		}
		ConstructorInfo attributeConstructor = GetAttributeConstructor(jsonDictionaryContract.NonNullableUnderlyingType);
		if (attributeConstructor != null)
		{
			ParameterInfo[] parameters = attributeConstructor.GetParameters();
			Type type = ((jsonDictionaryContract.DictionaryKeyType != null && jsonDictionaryContract.DictionaryValueType != null) ? typeof(IEnumerable<>).MakeGenericType(typeof(KeyValuePair<, >).MakeGenericType(jsonDictionaryContract.DictionaryKeyType, jsonDictionaryContract.DictionaryValueType)) : typeof(IDictionary));
			if (parameters.Length == 0)
			{
				jsonDictionaryContract.HasParameterizedCreator = false;
			}
			else
			{
				if (parameters.Length != 1 || !type.IsAssignableFrom(parameters[0].ParameterType))
				{
					throw new JsonException("Constructor for '{0}' must have no parameters or a single parameter that implements '{1}'.".FormatWith(CultureInfo.InvariantCulture, jsonDictionaryContract.UnderlyingType, type));
				}
				jsonDictionaryContract.HasParameterizedCreator = true;
			}
			jsonDictionaryContract.OverrideCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor(attributeConstructor);
		}
		return jsonDictionaryContract;
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonArrayContract" /> for the given type.
	/// </summary>
	/// <param name="objectType">Type of the object.</param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Serialization.JsonArrayContract" /> for the given type.
	/// </returns>
	protected virtual JsonArrayContract CreateArrayContract(Type objectType)
	{
		JsonArrayContract jsonArrayContract = new JsonArrayContract(objectType);
		InitializeContract(jsonArrayContract);
		ConstructorInfo attributeConstructor = GetAttributeConstructor(jsonArrayContract.NonNullableUnderlyingType);
		if (attributeConstructor != null)
		{
			ParameterInfo[] parameters = attributeConstructor.GetParameters();
			Type type = ((jsonArrayContract.CollectionItemType != null) ? typeof(IEnumerable<>).MakeGenericType(jsonArrayContract.CollectionItemType) : typeof(IEnumerable));
			if (parameters.Length == 0)
			{
				jsonArrayContract.HasParameterizedCreator = false;
			}
			else
			{
				if (parameters.Length != 1 || !type.IsAssignableFrom(parameters[0].ParameterType))
				{
					throw new JsonException("Constructor for '{0}' must have no parameters or a single parameter that implements '{1}'.".FormatWith(CultureInfo.InvariantCulture, jsonArrayContract.UnderlyingType, type));
				}
				jsonArrayContract.HasParameterizedCreator = true;
			}
			jsonArrayContract.OverrideCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor(attributeConstructor);
		}
		return jsonArrayContract;
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonPrimitiveContract" /> for the given type.
	/// </summary>
	/// <param name="objectType">Type of the object.</param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Serialization.JsonPrimitiveContract" /> for the given type.
	/// </returns>
	protected virtual JsonPrimitiveContract CreatePrimitiveContract(Type objectType)
	{
		JsonPrimitiveContract jsonPrimitiveContract = new JsonPrimitiveContract(objectType);
		InitializeContract(jsonPrimitiveContract);
		return jsonPrimitiveContract;
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonLinqContract" /> for the given type.
	/// </summary>
	/// <param name="objectType">Type of the object.</param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Serialization.JsonLinqContract" /> for the given type.
	/// </returns>
	protected virtual JsonLinqContract CreateLinqContract(Type objectType)
	{
		JsonLinqContract jsonLinqContract = new JsonLinqContract(objectType);
		InitializeContract(jsonLinqContract);
		return jsonLinqContract;
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonISerializableContract" /> for the given type.
	/// </summary>
	/// <param name="objectType">Type of the object.</param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Serialization.JsonISerializableContract" /> for the given type.
	/// </returns>
	protected virtual JsonISerializableContract CreateISerializableContract(Type objectType)
	{
		JsonISerializableContract jsonISerializableContract = new JsonISerializableContract(objectType);
		InitializeContract(jsonISerializableContract);
		ConstructorInfo constructor = jsonISerializableContract.NonNullableUnderlyingType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[2]
		{
			typeof(SerializationInfo),
			typeof(StreamingContext)
		}, null);
		if (constructor != null)
		{
			ObjectConstructor<object> iSerializableCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor(constructor);
			jsonISerializableContract.ISerializableCreator = iSerializableCreator;
		}
		return jsonISerializableContract;
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonDynamicContract" /> for the given type.
	/// </summary>
	/// <param name="objectType">Type of the object.</param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Serialization.JsonDynamicContract" /> for the given type.
	/// </returns>
	protected virtual JsonDynamicContract CreateDynamicContract(Type objectType)
	{
		JsonDynamicContract jsonDynamicContract = new JsonDynamicContract(objectType);
		InitializeContract(jsonDynamicContract);
		JsonContainerAttribute attribute = JsonTypeReflector.GetAttribute<JsonContainerAttribute>(objectType);
		if (attribute?.NamingStrategyType != null)
		{
			NamingStrategy namingStrategy = JsonTypeReflector.GetContainerNamingStrategy(attribute);
			jsonDynamicContract.PropertyNameResolver = (string s) => namingStrategy.GetDictionaryKey(s);
		}
		else
		{
			jsonDynamicContract.PropertyNameResolver = ResolveDictionaryKey;
		}
		jsonDynamicContract.Properties.AddRange(CreateProperties(objectType, MemberSerialization.OptOut));
		return jsonDynamicContract;
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonStringContract" /> for the given type.
	/// </summary>
	/// <param name="objectType">Type of the object.</param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Serialization.JsonStringContract" /> for the given type.
	/// </returns>
	protected virtual JsonStringContract CreateStringContract(Type objectType)
	{
		JsonStringContract jsonStringContract = new JsonStringContract(objectType);
		InitializeContract(jsonStringContract);
		return jsonStringContract;
	}

	/// <summary>
	///   Determines which contract type is created for the given type.
	/// </summary>
	/// <param name="objectType">Type of the object.</param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Serialization.JsonContract" /> for the given type.
	/// </returns>
	protected virtual JsonContract CreateContract(Type objectType)
	{
		if (IsJsonPrimitiveType(objectType))
		{
			return CreatePrimitiveContract(objectType);
		}
		Type type = ReflectionUtils.EnsureNotNullableType(objectType);
		JsonContainerAttribute cachedAttribute = JsonTypeReflector.GetCachedAttribute<JsonContainerAttribute>(type);
		if (cachedAttribute is JsonObjectAttribute)
		{
			return CreateObjectContract(objectType);
		}
		if (cachedAttribute is JsonArrayAttribute)
		{
			return CreateArrayContract(objectType);
		}
		if (cachedAttribute is JsonDictionaryAttribute)
		{
			return CreateDictionaryContract(objectType);
		}
		if (type == typeof(JToken) || type.IsSubclassOf(typeof(JToken)))
		{
			return CreateLinqContract(objectType);
		}
		if (CollectionUtils.IsDictionaryType(type))
		{
			return CreateDictionaryContract(objectType);
		}
		if (typeof(IEnumerable).IsAssignableFrom(type))
		{
			return CreateArrayContract(objectType);
		}
		if (CanConvertToString(type))
		{
			return CreateStringContract(objectType);
		}
		if (!IgnoreSerializableInterface && typeof(ISerializable).IsAssignableFrom(type))
		{
			return CreateISerializableContract(objectType);
		}
		if (typeof(IDynamicMetaObjectProvider).IsAssignableFrom(type))
		{
			return CreateDynamicContract(objectType);
		}
		if (IsIConvertible(type))
		{
			return CreatePrimitiveContract(type);
		}
		return CreateObjectContract(objectType);
	}

	internal static bool IsJsonPrimitiveType(Type t)
	{
		PrimitiveTypeCode typeCode = ConvertUtils.GetTypeCode(t);
		if (typeCode != 0)
		{
			return typeCode != PrimitiveTypeCode.Object;
		}
		return false;
	}

	internal static bool IsIConvertible(Type t)
	{
		if (typeof(IConvertible).IsAssignableFrom(t) || (ReflectionUtils.IsNullableType(t) && typeof(IConvertible).IsAssignableFrom(Nullable.GetUnderlyingType(t))))
		{
			return !typeof(JToken).IsAssignableFrom(t);
		}
		return false;
	}

	internal static bool CanConvertToString(Type type)
	{
		TypeConverter converter = ConvertUtils.GetConverter(type);
		if (converter != null && !(converter is ComponentConverter) && !(converter is ReferenceConverter) && converter.GetType() != typeof(TypeConverter) && converter.CanConvertTo(typeof(string)))
		{
			return true;
		}
		if (type == typeof(Type) || type.IsSubclassOf(typeof(Type)))
		{
			return true;
		}
		return false;
	}

	private static bool IsValidCallback(MethodInfo method, ParameterInfo[] parameters, Type attributeType, MethodInfo currentCallback, ref Type prevAttributeType)
	{
		if (!method.IsDefined(attributeType, inherit: false))
		{
			return false;
		}
		if (currentCallback != null)
		{
			throw new JsonException("Invalid attribute. Both '{0}' and '{1}' in type '{2}' have '{3}'.".FormatWith(CultureInfo.InvariantCulture, method, currentCallback, GetClrTypeFullName(method.DeclaringType), attributeType));
		}
		if (prevAttributeType != null)
		{
			throw new JsonException("Invalid Callback. Method '{3}' in type '{2}' has both '{0}' and '{1}'.".FormatWith(CultureInfo.InvariantCulture, prevAttributeType, attributeType, GetClrTypeFullName(method.DeclaringType), method));
		}
		if (method.IsVirtual)
		{
			throw new JsonException("Virtual Method '{0}' of type '{1}' cannot be marked with '{2}' attribute.".FormatWith(CultureInfo.InvariantCulture, method, GetClrTypeFullName(method.DeclaringType), attributeType));
		}
		if (method.ReturnType != typeof(void))
		{
			throw new JsonException("Serialization Callback '{1}' in type '{0}' must return void.".FormatWith(CultureInfo.InvariantCulture, GetClrTypeFullName(method.DeclaringType), method));
		}
		if (attributeType == typeof(OnErrorAttribute))
		{
			if (parameters == null || parameters.Length != 2 || parameters[0].ParameterType != typeof(StreamingContext) || parameters[1].ParameterType != typeof(ErrorContext))
			{
				throw new JsonException("Serialization Error Callback '{1}' in type '{0}' must have two parameters of type '{2}' and '{3}'.".FormatWith(CultureInfo.InvariantCulture, GetClrTypeFullName(method.DeclaringType), method, typeof(StreamingContext), typeof(ErrorContext)));
			}
		}
		else if (parameters == null || parameters.Length != 1 || parameters[0].ParameterType != typeof(StreamingContext))
		{
			throw new JsonException("Serialization Callback '{1}' in type '{0}' must have a single parameter of type '{2}'.".FormatWith(CultureInfo.InvariantCulture, GetClrTypeFullName(method.DeclaringType), method, typeof(StreamingContext)));
		}
		prevAttributeType = attributeType;
		return true;
	}

	internal static string GetClrTypeFullName(Type type)
	{
		if (type.IsGenericTypeDefinition() || !type.ContainsGenericParameters())
		{
			return type.FullName;
		}
		return string.Format(CultureInfo.InvariantCulture, "{0}.{1}", new object[2] { type.Namespace, type.Name });
	}

	/// <summary>
	///   Creates properties for the given <see cref="T:Newtonsoft.Json.Serialization.JsonContract" />.
	/// </summary>
	/// <param name="type">The type to create properties for.</param>
	/// /// <param name="memberSerialization">The member serialization mode for the type.</param>
	/// <returns>
	///   Properties for the given <see cref="T:Newtonsoft.Json.Serialization.JsonContract" />.
	/// </returns>
	protected virtual IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
	{
		List<MemberInfo> obj = GetSerializableMembers(type) ?? throw new JsonSerializationException("Null collection of seralizable members returned.");
		JsonPropertyCollection jsonPropertyCollection = new JsonPropertyCollection(type);
		foreach (MemberInfo item in obj)
		{
			JsonProperty jsonProperty = CreateProperty(item, memberSerialization);
			if (jsonProperty != null)
			{
				DefaultContractResolverState state = GetState();
				lock (state.NameTable)
				{
					jsonProperty.PropertyName = state.NameTable.Add(jsonProperty.PropertyName);
				}
				jsonPropertyCollection.AddProperty(jsonProperty);
			}
		}
		return jsonPropertyCollection.OrderBy((JsonProperty p) => p.Order ?? (-1)).ToList();
	}

	/// <summary>
	///   Creates the <see cref="T:Newtonsoft.Json.Serialization.IValueProvider" /> used by the serializer to get and set values from a member.
	/// </summary>
	/// <param name="member">The member.</param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Serialization.IValueProvider" /> used by the serializer to get and set values from a member.
	/// </returns>
	protected virtual IValueProvider CreateMemberValueProvider(MemberInfo member)
	{
		if (DynamicCodeGeneration)
		{
			return new DynamicValueProvider(member);
		}
		return new ReflectionValueProvider(member);
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.MemberInfo" />.
	/// </summary>
	/// <param name="memberSerialization">
	///   The member's parent <see cref="T:Newtonsoft.Json.MemberSerialization" />.
	/// </param>
	/// <param name="member">
	///   The member to create a <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for.
	/// </param>
	/// <returns>
	///   A created <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.MemberInfo" />.
	/// </returns>
	protected virtual JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
	{
		JsonProperty jsonProperty = new JsonProperty();
		jsonProperty.PropertyType = ReflectionUtils.GetMemberUnderlyingType(member);
		jsonProperty.DeclaringType = member.DeclaringType;
		jsonProperty.ValueProvider = CreateMemberValueProvider(member);
		jsonProperty.AttributeProvider = new ReflectionAttributeProvider(member);
		SetPropertySettingsFromAttributes(jsonProperty, member, member.Name, member.DeclaringType, memberSerialization, out var allowNonPublicAccess);
		if (memberSerialization != MemberSerialization.Fields)
		{
			jsonProperty.Readable = ReflectionUtils.CanReadMemberValue(member, allowNonPublicAccess);
			jsonProperty.Writable = ReflectionUtils.CanSetMemberValue(member, allowNonPublicAccess, jsonProperty.HasMemberAttribute);
		}
		else
		{
			jsonProperty.Readable = true;
			jsonProperty.Writable = true;
		}
		jsonProperty.ShouldSerialize = CreateShouldSerializeTest(member);
		SetIsSpecifiedActions(jsonProperty, member, allowNonPublicAccess);
		return jsonProperty;
	}

	private void SetPropertySettingsFromAttributes(JsonProperty property, object attributeProvider, string name, Type declaringType, MemberSerialization memberSerialization, out bool allowNonPublicAccess)
	{
		DataContractAttribute dataContractAttribute = JsonTypeReflector.GetDataContractAttribute(declaringType);
		MemberInfo memberInfo = attributeProvider as MemberInfo;
		DataMemberAttribute dataMemberAttribute = ((dataContractAttribute == null || !(memberInfo != null)) ? null : JsonTypeReflector.GetDataMemberAttribute(memberInfo));
		JsonPropertyAttribute attribute = JsonTypeReflector.GetAttribute<JsonPropertyAttribute>(attributeProvider);
		JsonRequiredAttribute attribute2 = JsonTypeReflector.GetAttribute<JsonRequiredAttribute>(attributeProvider);
		string text;
		bool hasSpecifiedName;
		if (attribute != null && attribute.PropertyName != null)
		{
			text = attribute.PropertyName;
			hasSpecifiedName = true;
		}
		else if (dataMemberAttribute != null && dataMemberAttribute.Name != null)
		{
			text = dataMemberAttribute.Name;
			hasSpecifiedName = true;
		}
		else
		{
			text = name;
			hasSpecifiedName = false;
		}
		JsonContainerAttribute attribute3 = JsonTypeReflector.GetAttribute<JsonContainerAttribute>(declaringType);
		NamingStrategy namingStrategy = ((attribute?.NamingStrategyType != null) ? JsonTypeReflector.CreateNamingStrategyInstance(attribute.NamingStrategyType, attribute.NamingStrategyParameters) : ((!(attribute3?.NamingStrategyType != null)) ? NamingStrategy : JsonTypeReflector.GetContainerNamingStrategy(attribute3)));
		if (namingStrategy != null)
		{
			property.PropertyName = namingStrategy.GetPropertyName(text, hasSpecifiedName);
		}
		else
		{
			property.PropertyName = ResolvePropertyName(text);
		}
		property.UnderlyingName = name;
		bool flag = false;
		if (attribute != null)
		{
			property._required = attribute._required;
			property.Order = attribute._order;
			property.DefaultValueHandling = attribute._defaultValueHandling;
			flag = true;
		}
		else if (dataMemberAttribute != null)
		{
			property._required = (dataMemberAttribute.IsRequired ? Required.AllowNull : Required.Default);
			property.Order = ((dataMemberAttribute.Order != -1) ? new int?(dataMemberAttribute.Order) : null);
			property.DefaultValueHandling = ((!dataMemberAttribute.EmitDefaultValue) ? new DefaultValueHandling?(DefaultValueHandling.Ignore) : null);
			flag = true;
		}
		if (attribute2 != null)
		{
			property._required = Required.Always;
			flag = true;
		}
		property.HasMemberAttribute = flag;
		bool flag2 = JsonTypeReflector.GetAttribute<JsonIgnoreAttribute>(attributeProvider) != null || JsonTypeReflector.GetAttribute<JsonExtensionDataAttribute>(attributeProvider) != null || JsonTypeReflector.GetAttribute<NonSerializedAttribute>(attributeProvider) != null;
		if (memberSerialization != MemberSerialization.OptIn)
		{
			bool flag3 = false;
			flag3 = JsonTypeReflector.GetAttribute<IgnoreDataMemberAttribute>(attributeProvider) != null;
			property.Ignored = flag2 || flag3;
		}
		else
		{
			property.Ignored = flag2 || !flag;
		}
		property.Converter = JsonTypeReflector.GetJsonConverter(attributeProvider);
		property.MemberConverter = JsonTypeReflector.GetJsonConverter(attributeProvider);
		DefaultValueAttribute attribute4 = JsonTypeReflector.GetAttribute<DefaultValueAttribute>(attributeProvider);
		if (attribute4 != null)
		{
			property.DefaultValue = attribute4.Value;
		}
		property.NullValueHandling = attribute?._nullValueHandling;
		property.ReferenceLoopHandling = attribute?._referenceLoopHandling;
		property.ObjectCreationHandling = attribute?._objectCreationHandling;
		property.TypeNameHandling = attribute?._typeNameHandling;
		property.IsReference = attribute?._isReference;
		property.ItemIsReference = attribute?._itemIsReference;
		property.ItemConverter = ((attribute != null && attribute.ItemConverterType != null) ? JsonTypeReflector.CreateJsonConverterInstance(attribute.ItemConverterType, attribute.ItemConverterParameters) : null);
		property.ItemReferenceLoopHandling = attribute?._itemReferenceLoopHandling;
		property.ItemTypeNameHandling = attribute?._itemTypeNameHandling;
		allowNonPublicAccess = false;
		if ((DefaultMembersSearchFlags & BindingFlags.NonPublic) == BindingFlags.NonPublic)
		{
			allowNonPublicAccess = true;
		}
		if (flag)
		{
			allowNonPublicAccess = true;
		}
		if (memberSerialization == MemberSerialization.Fields)
		{
			allowNonPublicAccess = true;
		}
	}

	private Predicate<object> CreateShouldSerializeTest(MemberInfo member)
	{
		MethodInfo method = member.DeclaringType.GetMethod("ShouldSerialize" + member.Name, ReflectionUtils.EmptyTypes);
		if (method == null || method.ReturnType != typeof(bool))
		{
			return null;
		}
		MethodCall<object, object> shouldSerializeCall = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>(method);
		return (object o) => (bool)shouldSerializeCall(o);
	}

	private void SetIsSpecifiedActions(JsonProperty property, MemberInfo member, bool allowNonPublicAccess)
	{
		MemberInfo memberInfo = member.DeclaringType.GetProperty(member.Name + "Specified");
		if (memberInfo == null)
		{
			memberInfo = member.DeclaringType.GetField(member.Name + "Specified");
		}
		if (!(memberInfo == null) && !(ReflectionUtils.GetMemberUnderlyingType(memberInfo) != typeof(bool)))
		{
			Func<object, object> specifiedPropertyGet = JsonTypeReflector.ReflectionDelegateFactory.CreateGet<object>(memberInfo);
			property.GetIsSpecified = (object o) => (bool)specifiedPropertyGet(o);
			if (ReflectionUtils.CanSetMemberValue(memberInfo, allowNonPublicAccess, canSetReadOnly: false))
			{
				property.SetIsSpecified = JsonTypeReflector.ReflectionDelegateFactory.CreateSet<object>(memberInfo);
			}
		}
	}

	/// <summary>
	///   Resolves the name of the property.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <returns>Resolved name of the property.</returns>
	protected virtual string ResolvePropertyName(string propertyName)
	{
		if (NamingStrategy != null)
		{
			return NamingStrategy.GetPropertyName(propertyName, hasSpecifiedName: false);
		}
		return propertyName;
	}

	/// <summary>
	///   Resolves the key of the dictionary. By default <see cref="M:Newtonsoft.Json.Serialization.DefaultContractResolver.ResolvePropertyName(System.String)" /> is used to resolve dictionary keys.
	/// </summary>
	/// <param name="dictionaryKey">Key of the dictionary.</param>
	/// <returns>Resolved key of the dictionary.</returns>
	protected virtual string ResolveDictionaryKey(string dictionaryKey)
	{
		if (NamingStrategy != null)
		{
			return NamingStrategy.GetDictionaryKey(dictionaryKey);
		}
		return ResolvePropertyName(dictionaryKey);
	}

	/// <summary>
	///   Gets the resolved name of the property.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <returns>Name of the property.</returns>
	public string GetResolvedPropertyName(string propertyName)
	{
		return ResolvePropertyName(propertyName);
	}
}
