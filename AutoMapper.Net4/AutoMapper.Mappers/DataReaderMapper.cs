using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using AutoMapper.Internal;

namespace AutoMapper.Mappers;

public class DataReaderMapper : IObjectMapper
{
	private delegate object Build(IDataRecord dataRecord);

	private delegate object CreateEnumerableAdapter(IEnumerable items);

	private class BuilderKey
	{
		private readonly List<string> _dataRecordNames;

		private readonly Type _destinationType;

		public BuilderKey(Type destinationType, IDataRecord record)
		{
			_destinationType = destinationType;
			_dataRecordNames = new List<string>(record.FieldCount);
			for (int i = 0; i < record.FieldCount; i++)
			{
				_dataRecordNames.Add(record.GetName(i));
			}
		}

		public override int GetHashCode()
		{
			int num = _destinationType.GetHashCode();
			foreach (string dataRecordName in _dataRecordNames)
			{
				num = num * 37 + dataRecordName.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is BuilderKey builderKey))
			{
				return false;
			}
			if (_dataRecordNames.Count != builderKey._dataRecordNames.Count)
			{
				return false;
			}
			for (int i = 0; i < _dataRecordNames.Count; i++)
			{
				if (_dataRecordNames[i] != builderKey._dataRecordNames[i])
				{
					return false;
				}
			}
			return true;
		}
	}

	private class EnumerableAdapter<Item> : IEnumerable<Item>, IEnumerable
	{
		private IEnumerable<Item> _items;

		public EnumerableAdapter(IEnumerable items)
		{
			_items = items.Cast<Item>();
		}

		public IEnumerator<Item> GetEnumerator()
		{
			return _items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	private static ConcurrentDictionary<BuilderKey, Build> _builderCache;

	private static ConcurrentDictionary<Type, CreateEnumerableAdapter> _enumerableAdapterCache;

	private static readonly MethodInfo getValueMethod;

	private static readonly MethodInfo isDBNullMethod;

	static DataReaderMapper()
	{
		_builderCache = new ConcurrentDictionary<BuilderKey, Build>();
		_enumerableAdapterCache = new ConcurrentDictionary<Type, CreateEnumerableAdapter>();
		getValueMethod = typeof(IDataRecord).GetMethod("get_Item", new Type[1] { typeof(int) });
		isDBNullMethod = typeof(IDataRecord).GetMethod("IsDBNull", new Type[1] { typeof(int) });
		FeatureDetector.IsIDataRecordType = (Type t) => typeof(IDataRecord).IsAssignableFrom(t);
	}

	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		if (IsDataReader(context))
		{
			bool dataReaderMapperYieldReturnEnabled = ((IConfiguration)mapper.ConfigurationProvider).DataReaderMapperYieldReturnEnabled;
			Type elementType = TypeHelper.GetElementType(context.DestinationType);
			IEnumerable enumerable = MapDataReaderToEnumerable(context, mapper, elementType, dataReaderMapperYieldReturnEnabled);
			if (dataReaderMapperYieldReturnEnabled)
			{
				CreateEnumerableAdapter delegateToCreateEnumerableAdapter = GetDelegateToCreateEnumerableAdapter(elementType);
				return delegateToCreateEnumerableAdapter(enumerable);
			}
			return enumerable;
		}
		if (IsDataRecord(context))
		{
			IDataRecord dataRecord = context.SourceValue as IDataRecord;
			Build build = CreateBuilder(context.DestinationType, dataRecord);
			object result = build(dataRecord);
			MapPropertyValues(context, mapper, result);
			return result;
		}
		return null;
	}

	private static IEnumerable MapDataReaderToEnumerable(ResolutionContext context, IMappingEngineRunner mapper, Type destinationElementType, bool useYieldReturn)
	{
		IDataReader dataReader = (IDataReader)context.SourceValue;
		ResolutionContext resolveUsingContext = context;
		if (context.TypeMap == null)
		{
			IConfigurationProvider configurationProvider = mapper.ConfigurationProvider;
			TypeMap typeMap = configurationProvider.FindTypeMapFor(context.SourceValue, context.DestinationValue, context.SourceType, destinationElementType);
			resolveUsingContext = new ResolutionContext(typeMap, context.SourceValue, context.SourceType, destinationElementType, new MappingOperationOptions());
		}
		Build buildFrom = CreateBuilder(destinationElementType, dataReader);
		if (useYieldReturn)
		{
			return LoadDataReaderViaYieldReturn(dataReader, mapper, buildFrom, resolveUsingContext);
		}
		return LoadDataReaderViaList(dataReader, mapper, buildFrom, resolveUsingContext, destinationElementType);
	}

	private static IEnumerable LoadDataReaderViaList(IDataReader dataReader, IMappingEngineRunner mapper, Build buildFrom, ResolutionContext resolveUsingContext, Type elementType)
	{
		IList list = ObjectCreator.CreateList(elementType);
		while (dataReader.Read())
		{
			object obj = buildFrom(dataReader);
			MapPropertyValues(resolveUsingContext, mapper, obj);
			list.Add(obj);
		}
		return list;
	}

	private static IEnumerable LoadDataReaderViaYieldReturn(IDataReader dataReader, IMappingEngineRunner mapper, Build buildFrom, ResolutionContext resolveUsingContext)
	{
		while (dataReader.Read())
		{
			object result = buildFrom(dataReader);
			MapPropertyValues(resolveUsingContext, mapper, result);
			yield return result;
		}
	}

	public bool IsMatch(ResolutionContext context)
	{
		if (!IsDataReader(context))
		{
			return IsDataRecord(context);
		}
		return true;
	}

	private static bool IsDataReader(ResolutionContext context)
	{
		if (typeof(IDataReader).IsAssignableFrom(context.SourceType))
		{
			return context.DestinationType.IsEnumerableType();
		}
		return false;
	}

	private static bool IsDataRecord(ResolutionContext context)
	{
		return typeof(IDataRecord).IsAssignableFrom(context.SourceType);
	}

	private static Build CreateBuilder(Type destinationType, IDataRecord dataRecord)
	{
		BuilderKey key = new BuilderKey(destinationType, dataRecord);
		if (_builderCache.TryGetValue(key, out var value))
		{
			return value;
		}
		DynamicMethod dynamicMethod = new DynamicMethod("DynamicCreate", destinationType, new Type[1] { typeof(IDataRecord) }, destinationType, skipVisibility: true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		LocalBuilder local = iLGenerator.DeclareLocal(destinationType);
		iLGenerator.Emit(OpCodes.Newobj, destinationType.GetConstructor(Type.EmptyTypes));
		iLGenerator.Emit(OpCodes.Stloc, local);
		for (int i = 0; i < dataRecord.FieldCount; i++)
		{
			PropertyInfo property = destinationType.GetProperty(dataRecord.GetName(i), BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
			Label label = iLGenerator.DefineLabel();
			if (!(property != null) || !(property.GetSetMethod(nonPublic: true) != null))
			{
				continue;
			}
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldc_I4, i);
			iLGenerator.Emit(OpCodes.Callvirt, isDBNullMethod);
			iLGenerator.Emit(OpCodes.Brtrue, label);
			iLGenerator.Emit(OpCodes.Ldloc, local);
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldc_I4, i);
			iLGenerator.Emit(OpCodes.Callvirt, getValueMethod);
			if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
			{
				Type type = property.PropertyType.GetGenericTypeDefinition().GetGenericArguments()[0];
				if (!type.IsEnum)
				{
					iLGenerator.Emit(OpCodes.Unbox_Any, property.PropertyType);
				}
				else
				{
					iLGenerator.Emit(OpCodes.Unbox_Any, type);
					iLGenerator.Emit(OpCodes.Newobj, property.PropertyType);
				}
			}
			else
			{
				iLGenerator.Emit(OpCodes.Unbox_Any, dataRecord.GetFieldType(i));
			}
			iLGenerator.Emit(OpCodes.Callvirt, property.GetSetMethod(nonPublic: true));
			iLGenerator.MarkLabel(label);
		}
		iLGenerator.Emit(OpCodes.Ldloc, local);
		iLGenerator.Emit(OpCodes.Ret);
		value = (Build)dynamicMethod.CreateDelegate(typeof(Build));
		_builderCache[key] = value;
		return value;
	}

	private static void MapPropertyValues(ResolutionContext context, IMappingEngineRunner mapper, object result)
	{
		if (context.TypeMap == null)
		{
			throw new AutoMapperMappingException(context, "Missing type map configuration or unsupported mapping.");
		}
		foreach (PropertyMap propertyMap in context.TypeMap.GetPropertyMaps())
		{
			MapPropertyValue(context, mapper, result, propertyMap);
		}
	}

	private static void MapPropertyValue(ResolutionContext context, IMappingEngineRunner mapper, object mappedObject, PropertyMap propertyMap)
	{
		if (!propertyMap.CanResolveValue())
		{
			return;
		}
		ResolutionResult resolutionResult = propertyMap.ResolveValue(context);
		ResolutionContext context2 = context.CreateMemberContext(null, resolutionResult.Value, null, resolutionResult.Type, propertyMap);
		if (!propertyMap.ShouldAssignValue(context2))
		{
			return;
		}
		try
		{
			object value = mapper.Map(context2);
			if (propertyMap.CanBeSet)
			{
				propertyMap.DestinationProperty.SetValue(mappedObject, value);
			}
		}
		catch (AutoMapperMappingException)
		{
			throw;
		}
		catch (Exception inner)
		{
			throw new AutoMapperMappingException(context2, inner);
		}
	}

	private static CreateEnumerableAdapter GetDelegateToCreateEnumerableAdapter(Type elementType)
	{
		if (_enumerableAdapterCache.TryGetValue(elementType, out var value))
		{
			return value;
		}
		Type type = typeof(EnumerableAdapter<>).MakeGenericType(elementType);
		ConstructorInfo constructor = type.GetConstructor(new Type[1] { typeof(IEnumerable) });
		ParameterExpression parameterExpression = Expression.Parameter(typeof(IEnumerable), "items");
		NewExpression body = Expression.New(constructor, parameterExpression);
		value = (CreateEnumerableAdapter)Expression.Lambda(typeof(CreateEnumerableAdapter), body, parameterExpression).Compile();
		_enumerableAdapterCache[elementType] = value;
		return value;
	}
}
