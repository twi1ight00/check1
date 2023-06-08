using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper.Impl;
using AutoMapper.Internal;

namespace AutoMapper.QueryableExtensions;

public static class Extensions
{
	private static readonly IDictionaryFactory DictionaryFactory = PlatformAdapter.Resolve<IDictionaryFactory>();

	private static readonly AutoMapper.Internal.IDictionary<TypePair, LambdaExpression> _expressionCache = DictionaryFactory.CreateDictionary<TypePair, LambdaExpression>();

	/// <summary>
	/// Create an expression tree representing a mapping from the <typeparamref name="TSource" /> type to <typeparamref name="TDestination" /> type
	/// Includes flattening and expressions inside MapFrom member configuration
	/// </summary>
	/// <typeparam name="TSource">Source Type</typeparam>
	/// <typeparam name="TDestination">Destination Type</typeparam>
	/// <param name="mappingEngine">Mapping engine instance</param>
	/// <returns>Expression tree mapping source to destination type</returns>
	public static Expression<Func<TSource, TDestination>> CreateMapExpression<TSource, TDestination>(this IMappingEngine mappingEngine)
	{
		return (Expression<Func<TSource, TDestination>>)_expressionCache.GetOrAdd(new TypePair(typeof(TSource), typeof(TDestination)), (TypePair tp) => CreateMapExpression(mappingEngine, tp.SourceType, tp.DestinationType));
	}

	/// <summary>
	/// Extention method to project from a queryable using the static <see cref="P:AutoMapper.Mapper.Engine" /> property
	/// Due to generic parameter inference, you need to call Project().To to execute the map
	/// </summary>
	/// <remarks>Projections are only calculated once and cached</remarks>
	/// <typeparam name="TSource">Source type</typeparam>
	/// <param name="source">Queryable source</param>
	/// <returns>Expression to project into</returns>
	public static IProjectionExpression Project<TSource>(this IQueryable<TSource> source)
	{
		return source.Project(Mapper.Engine);
	}

	/// <summary>
	/// Extention method to project from a queryable using the provided mapping engine
	/// Due to generic parameter inference, you need to call Project().To to execute the map
	/// </summary>
	/// <remarks>Projections are only calculated once and cached</remarks>
	/// <typeparam name="TSource">Source type</typeparam>
	/// <param name="source">Queryable source</param>
	/// <param name="mappingEngine">Mapping engine instance</param>
	/// <returns>Expression to project into</returns>
	public static IProjectionExpression Project<TSource>(this IQueryable<TSource> source, IMappingEngine mappingEngine)
	{
		return new ProjectionExpression<TSource>(source, mappingEngine);
	}

	private static LambdaExpression CreateMapExpression(IMappingEngine mappingEngine, Type typeIn, Type typeOut)
	{
		ParameterExpression parameterExpression = Expression.Parameter(typeIn, "dto");
		Expression body = CreateMapExpression(mappingEngine, typeIn, typeOut, parameterExpression);
		return Expression.Lambda(body, parameterExpression);
	}

	private static Expression CreateMapExpression(IMappingEngine mappingEngine, Type typeIn, Type typeOut, Expression instanceParameter)
	{
		TypeMap typeMap = mappingEngine.ConfigurationProvider.FindTypeMapFor(typeIn, typeOut);
		if (typeMap == null)
		{
			string message = string.Format("Missing map from {0} to {1}. Create using Mapper.CreateMap<{0}, {1}>.", new object[2] { typeIn.Name, typeOut.Name });
			throw new InvalidOperationException(message);
		}
		List<MemberBinding> list = CreateMemberBindings(mappingEngine, typeIn, typeMap, instanceParameter);
		return Expression.MemberInit(Expression.New(typeOut), list.ToArray());
	}

	private static List<MemberBinding> CreateMemberBindings(IMappingEngine mappingEngine, Type typeIn, TypeMap typeMap, Expression instanceParameter)
	{
		List<MemberBinding> list = new List<MemberBinding>();
		foreach (PropertyMap item2 in from pm in typeMap.GetPropertyMaps()
			where pm.CanResolveValue()
			select pm)
		{
			ExpressionResolutionResult expressionResolutionResult = item2.ResolveExpression(typeIn, instanceParameter);
			MemberInfo memberInfo = item2.DestinationProperty.MemberInfo;
			MemberAssignment item;
			if (item2.DestinationPropertyType.IsAssignableFrom(expressionResolutionResult.Type))
			{
				item = Expression.Bind(memberInfo, expressionResolutionResult.ResolutionExpression);
			}
			else if (item2.DestinationPropertyType.GetInterfaces().Any((Type t) => t.Name == "IEnumerable") && (object)item2.DestinationPropertyType != typeof(string))
			{
				Type destinationListTypeFor = GetDestinationListTypeFor(item2);
				Type type = null;
				type = expressionResolutionResult.Type.GetGenericArguments().First();
				LambdaExpression lambdaExpression = CreateMapExpression(mappingEngine, type, destinationListTypeFor);
				MethodCallExpression methodCallExpression = Expression.Call(typeof(Enumerable), "Select", new Type[2] { type, destinationListTypeFor }, expressionResolutionResult.ResolutionExpression, lambdaExpression);
				if (typeof(IList<>).MakeGenericType(destinationListTypeFor).IsAssignableFrom(item2.DestinationPropertyType))
				{
					MethodCallExpression toListCallExpression = GetToListCallExpression(item2, destinationListTypeFor, methodCallExpression);
					item = Expression.Bind(memberInfo, toListCallExpression);
				}
				else
				{
					item = Expression.Bind(memberInfo, methodCallExpression);
				}
			}
			else
			{
				if ((object)expressionResolutionResult.Type == item2.DestinationPropertyType || (object)item2.DestinationPropertyType.BaseType == typeof(ValueType) || (object)item2.DestinationPropertyType.BaseType == typeof(Enum))
				{
					throw new AutoMapperMappingException(string.Concat("Unable to create a map expression from ", expressionResolutionResult.Type, " to ", item2.DestinationPropertyType));
				}
				Expression expression = CreateMapExpression(mappingEngine, expressionResolutionResult.Type, item2.DestinationPropertyType, expressionResolutionResult.ResolutionExpression);
				item = Expression.Bind(memberInfo, expression);
			}
			list.Add(item);
		}
		return list;
	}

	private static Type GetDestinationListTypeFor(PropertyMap propertyMap)
	{
		if (propertyMap.DestinationPropertyType.IsArray)
		{
			return propertyMap.DestinationPropertyType.GetElementType();
		}
		return propertyMap.DestinationPropertyType.GetGenericArguments().First();
	}

	private static MethodCallExpression GetToListCallExpression(PropertyMap propertyMap, Type destinationListType, MethodCallExpression selectExpression)
	{
		return Expression.Call(typeof(Enumerable), propertyMap.DestinationPropertyType.IsArray ? "ToArray" : "ToList", new Type[1] { destinationListType }, selectExpression);
	}
}
