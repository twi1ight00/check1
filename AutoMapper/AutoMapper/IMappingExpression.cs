using System;
using System.Linq.Expressions;

namespace AutoMapper;

/// <summary>
/// Mapping configuration options for non-generic maps
/// </summary>
public interface IMappingExpression
{
	/// <summary>
	/// Skip normal member mapping and convert using a <see cref="T:AutoMapper.ITypeConverter`2" /> instantiated during mapping
	/// </summary>
	/// <typeparam name="TTypeConverter">Type converter type</typeparam>
	void ConvertUsing<TTypeConverter>();

	/// <summary>
	/// Skip normal member mapping and convert using a <see cref="T:AutoMapper.ITypeConverter`2" /> instantiated during mapping
	/// Use this method if you need to specify the converter type at runtime
	/// </summary>
	/// <param name="typeConverterType">Type converter type</param>
	void ConvertUsing(Type typeConverterType);

	/// <summary>
	/// Override the destination type mapping for looking up configuration and instantiation
	/// </summary>
	/// <param name="typeOverride"></param>
	void As(Type typeOverride);

	/// <summary>
	/// Assign a profile to the current type map
	/// </summary>
	/// <param name="profileName">Profile name</param>
	/// <returns>Itself</returns>
	IMappingExpression WithProfile(string profileName);

	/// <summary>
	/// Customize individual members
	/// </summary>
	/// <param name="name">Name of the member</param>
	/// <param name="memberOptions">Callback for configuring member</param>
	/// <returns>Itself</returns>
	IMappingExpression ForMember(string name, Action<IMemberConfigurationExpression> memberOptions);

	/// <summary>
	/// Customize configuration for an individual source member
	/// </summary>
	/// <param name="sourceMemberName">Source member name</param>
	/// <param name="memberOptions">Callback for member configuration options</param>
	/// <returns>Itself</returns>
	IMappingExpression ForSourceMember(string sourceMemberName, Action<ISourceMemberConfigurationExpression> memberOptions);
}
/// <summary>
/// Mapping configuration options
/// </summary>
/// <typeparam name="TSource">Source type</typeparam>
/// <typeparam name="TDestination">Destination type</typeparam>
public interface IMappingExpression<TSource, TDestination>
{
	/// <summary>
	/// Customize configuration for individual member
	/// </summary>
	/// <param name="destinationMember">Expression to the top-level destination member. This must be a member on the <typeparamref name="TDestination" />TDestination</param> type
	/// <param name="memberOptions">Callback for member options</param>
	/// <returns>Itself</returns>
	IMappingExpression<TSource, TDestination> ForMember(Expression<Func<TDestination, object>> destinationMember, Action<IMemberConfigurationExpression<TSource>> memberOptions);

	/// <summary>
	/// Customize configuration for individual member. Used when the name isn't known at compile-time
	/// </summary>
	/// <param name="name">Destination member name</param>
	/// <param name="memberOptions">Callback for member options</param>
	/// <returns></returns>
	IMappingExpression<TSource, TDestination> ForMember(string name, Action<IMemberConfigurationExpression<TSource>> memberOptions);

	/// <summary>
	/// Customize configuration for all members
	/// </summary>
	/// <param name="memberOptions">Callback for member options</param>
	void ForAllMembers(Action<IMemberConfigurationExpression<TSource>> memberOptions);

	/// <summary>
	/// Include this configuration in derived types' maps
	/// </summary>
	/// <typeparam name="TOtherSource">Derived source type</typeparam>
	/// <typeparam name="TOtherDestination">Derived destination type</typeparam>
	/// <returns></returns>
	IMappingExpression<TSource, TDestination> Include<TOtherSource, TOtherDestination>() where TOtherSource : TSource where TOtherDestination : TDestination;

	/// <summary>
	/// Assign a profile to the current type map
	/// </summary>
	/// <param name="profileName">Name of the profile</param>
	/// <returns>Itself</returns>
	IMappingExpression<TSource, TDestination> WithProfile(string profileName);

	/// <summary>
	/// Skip member mapping and use a custom function to convert to the destination type
	/// </summary>
	/// <param name="mappingFunction">Callback to convert from source type to destination type</param>
	void ConvertUsing(Func<TSource, TDestination> mappingFunction);

	/// <summary>
	/// Skip member mapping and use a custom type converter instance to convert to the destination type
	/// </summary>
	/// <param name="converter">Type converter instance</param>
	void ConvertUsing(ITypeConverter<TSource, TDestination> converter);

	/// <summary>
	/// Skip member mapping and use a custom type converter instance to convert to the destination type
	/// </summary>
	/// <typeparam name="TTypeConverter">Type converter type</typeparam>
	void ConvertUsing<TTypeConverter>() where TTypeConverter : ITypeConverter<TSource, TDestination>;

	/// <summary>
	/// Execute a custom function to the source and/or destination types before member mapping
	/// </summary>
	/// <param name="beforeFunction">Callback for the source/destination types</param>
	/// <returns>Itself</returns>
	IMappingExpression<TSource, TDestination> BeforeMap(Action<TSource, TDestination> beforeFunction);

	/// <summary>
	/// Execute a custom mapping action before member mapping
	/// </summary>
	/// <typeparam name="TMappingAction">Mapping action type instantiated during mapping</typeparam>
	/// <returns>Itself</returns>
	IMappingExpression<TSource, TDestination> BeforeMap<TMappingAction>() where TMappingAction : IMappingAction<TSource, TDestination>;

	/// <summary>
	/// Execute a custom function to the source and/or destination types after member mapping
	/// </summary>
	/// <param name="afterFunction">Callback for the source/destination types</param>
	/// <returns>Itself</returns>
	IMappingExpression<TSource, TDestination> AfterMap(Action<TSource, TDestination> afterFunction);

	/// <summary>
	/// Execute a custom mapping action after member mapping
	/// </summary>
	/// <typeparam name="TMappingAction">Mapping action type instantiated during mapping</typeparam>
	/// <returns>Itself</returns>
	IMappingExpression<TSource, TDestination> AfterMap<TMappingAction>() where TMappingAction : IMappingAction<TSource, TDestination>;

	/// <summary>
	/// Supply a custom instantiation function for the destination type
	/// </summary>
	/// <param name="ctor">Callback to create the destination type given the source object</param>
	/// <returns>Itself</returns>
	IMappingExpression<TSource, TDestination> ConstructUsing(Func<TSource, TDestination> ctor);

	/// <summary>
	/// Supply a custom instantiation function for the destination type, based on the entire resolution context
	/// </summary>
	/// <param name="ctor">Callback to create the destination type given the current resolution context</param>
	/// <returns>Itself</returns>
	IMappingExpression<TSource, TDestination> ConstructUsing(Func<ResolutionContext, TDestination> ctor);

	/// <summary>
	/// Override the destination type mapping for looking up configuration and instantiation
	/// </summary>
	/// <typeparam name="T">Destination type to use</typeparam>
	void As<T>();

	/// <summary>
	/// For self-referential types, limit recurse depth
	/// </summary>
	/// <param name="depth">Number of levels to limit to</param>
	/// <returns>Itself</returns>
	IMappingExpression<TSource, TDestination> MaxDepth(int depth);

	/// <summary>
	/// Construct the destination object using the service locator
	/// </summary>
	/// <returns>Itself</returns>
	IMappingExpression<TSource, TDestination> ConstructUsingServiceLocator();

	/// <summary>
	/// Create a type mapping from the destination to the source type, using the <typeparamref name="TDestination" /> members as validation
	/// </summary>
	/// <returns>Itself</returns>
	IMappingExpression<TDestination, TSource> ReverseMap();

	/// <summary>
	/// Customize configuration for an individual source member
	/// </summary>
	/// <param name="sourceMember">Expression to source member. Must be a member of the <typeparamref name="TSource" /> type</param>
	/// <param name="memberOptions">Callback for member configuration options</param>
	/// <returns>Itself</returns>
	IMappingExpression<TSource, TDestination> ForSourceMember(Expression<Func<TSource, object>> sourceMember, Action<ISourceMemberConfigurationExpression<TSource>> memberOptions);

	/// <summary>
	/// Customize configuration for an individual source member. Member name not known until runtime
	/// </summary>
	/// <param name="sourceMemberName">Expression to source member. Must be a member of the <typeparamref name="TSource" /> type</param>
	/// <param name="memberOptions">Callback for member configuration options</param>
	/// <returns>Itself</returns>
	IMappingExpression<TSource, TDestination> ForSourceMember(string sourceMemberName, Action<ISourceMemberConfigurationExpression<TSource>> memberOptions);
}
