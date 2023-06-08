using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity.InterceptionExtension.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Maps types involving generic parameter types from reflected types into equivalent versions involving generated types.
/// </summary>
public class GenericParameterMapper
{
	private static readonly GenericParameterMapper defaultMapper = new GenericParameterMapper(Type.EmptyTypes, Type.EmptyTypes, null);

	private static readonly KeyValuePair<Type, Type>[] emptyMappings = new KeyValuePair<Type, Type>[0];

	private readonly IDictionary<Type, Type> mappedTypesCache = new Dictionary<Type, Type>();

	private readonly ICollection<KeyValuePair<Type, Type>> localMappings;

	private readonly GenericParameterMapper parent;

	/// <summary>
	/// Gets the default mapper.
	/// </summary>
	public static GenericParameterMapper DefaultMapper => defaultMapper;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.GenericParameterMapper" /> class.
	/// </summary>
	/// <param name="type">A constructed generic type, open or closed.</param>
	/// <param name="parent">The parent mapper, or <see langword="null" />.</param>
	public GenericParameterMapper(Type type, GenericParameterMapper parent)
	{
		if (type.IsGenericType)
		{
			if (type.IsGenericTypeDefinition)
			{
				throw new ArgumentException(Resources.ExceptionCannotMapGenericTypeDefinition, "type");
			}
			this.parent = parent;
			localMappings = CreateMappings(type.GetGenericTypeDefinition().GetGenericArguments(), type.GetGenericArguments());
		}
		else
		{
			localMappings = emptyMappings;
			this.parent = null;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.GenericParameterMapper" /> class.
	/// </summary>
	/// <param name="reflectedParameters">The reflected generic parameters.</param>
	/// <param name="generatedParameters">The generated generic parameters.</param>
	public GenericParameterMapper(Type[] reflectedParameters, Type[] generatedParameters)
		: this(reflectedParameters, generatedParameters, null)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.GenericParameterMapper" /> class.
	/// </summary>
	/// <param name="reflectedParameters">The reflected generic parameters.</param>
	/// <param name="generatedParameters">The generated generic parameters.</param>
	/// <param name="parent">The parent mapper, or <see langword="null" />.</param>
	public GenericParameterMapper(Type[] reflectedParameters, Type[] generatedParameters, GenericParameterMapper parent)
	{
		this.parent = parent;
		localMappings = CreateMappings(reflectedParameters, generatedParameters);
	}

	private static ICollection<KeyValuePair<Type, Type>> CreateMappings(Type[] reflectedParameters, Type[] generatedParameters)
	{
		Guard.ArgumentNotNull(reflectedParameters, "reflectedParameters");
		Guard.ArgumentNotNull(generatedParameters, "generatedParameters");
		if (reflectedParameters.Length != generatedParameters.Length)
		{
			throw new ArgumentException(Resources.ExceptionMappedParametersDoNotMatch, "reflectedParameters");
		}
		List<KeyValuePair<Type, Type>> list = new List<KeyValuePair<Type, Type>>();
		for (int i = 0; i < reflectedParameters.Length; i++)
		{
			list.Add(new KeyValuePair<Type, Type>(reflectedParameters[i], generatedParameters[i]));
		}
		return list;
	}

	/// <summary>
	/// Maps a type to an equivalent type involving generated types.
	/// </summary>
	/// <param name="typeToMap">The type to map.</param>
	public Type Map(Type typeToMap)
	{
		if (!mappedTypesCache.TryGetValue(typeToMap, out var value))
		{
			value = DoMap(typeToMap);
			mappedTypesCache[typeToMap] = value;
		}
		return value;
	}

	private Type DoMap(Type typeToMap)
	{
		if (!typeToMap.IsGenericParameter)
		{
			if (typeToMap.IsArray)
			{
				Type type = Map(typeToMap.GetElementType());
				return (typeToMap.GetArrayRank() == 1) ? type.MakeArrayType() : type.MakeArrayType(typeToMap.GetArrayRank());
			}
			if (typeToMap.IsGenericType)
			{
				Type[] typeArguments = (from gp in typeToMap.GetGenericArguments()
					select Map(gp)).ToArray();
				return typeToMap.GetGenericTypeDefinition().MakeGenericType(typeArguments);
			}
			return typeToMap;
		}
		Type type2 = (from kvp in localMappings
			where kvp.Key == typeToMap
			select kvp.Value).FirstOrDefault() ?? typeToMap;
		if (parent != null)
		{
			type2 = parent.Map(type2);
		}
		return type2;
	}

	/// <summary>
	/// Gets the formal parameters.
	/// </summary>
	/// <returns></returns>
	public Type[] GetReflectedParameters()
	{
		return localMappings.Select((KeyValuePair<Type, Type> kvp) => kvp.Key).ToArray();
	}

	/// <summary>
	/// Gets the actual parameters.
	/// </summary>
	/// <returns></returns>
	public Type[] GetGeneratedParameters()
	{
		return localMappings.Select((KeyValuePair<Type, Type> kvp) => kvp.Value).ToArray();
	}
}
