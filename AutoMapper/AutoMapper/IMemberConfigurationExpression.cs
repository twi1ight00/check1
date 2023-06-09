using System;
using System.Linq.Expressions;

namespace AutoMapper;

/// <summary>
/// Configuration options for an individual member
/// </summary>
public interface IMemberConfigurationExpression
{
	/// <summary>
	/// Map from a specific source member
	/// </summary>
	/// <param name="sourceMember">Source member to map from</param>
	void MapFrom(string sourceMember);

	/// <summary>
	/// Resolve destination member using a custom value resolver instance
	/// </summary>
	/// <param name="valueResolver">Value resolver to use</param>
	/// <returns>Value resolver configuration options</returns>
	IResolutionExpression ResolveUsing(IValueResolver valueResolver);

	/// <summary>
	/// Resolve destination member using a custom value resolver
	/// </summary>
	/// <param name="valueResolverType">Value resolver of type <see cref="T:AutoMapper.IValueResolver" /></param>
	/// <returns>Value resolver configuration options</returns>
	IResolverConfigurationExpression ResolveUsing(Type valueResolverType);

	/// <summary>
	/// Resolve destination member using a custom value resolver
	/// </summary>
	/// <typeparam name="TValueResolver">Value resolver of type <see cref="T:AutoMapper.IValueResolver" /></typeparam>
	/// <returns>Value resolver configuration options</returns>
	IResolverConfigurationExpression ResolveUsing<TValueResolver>();

	/// <summary>
	/// Ignore this member for configuration validation and skip during mapping
	/// </summary>
	void Ignore();
}
/// <summary>
/// Member configuration options
/// </summary>
/// <typeparam name="TSource">Source type for this member</typeparam>
public interface IMemberConfigurationExpression<TSource>
{
	[Obsolete("Formatters should not be used.")]
	void SkipFormatter<TValueFormatter>() where TValueFormatter : IValueFormatter;

	[Obsolete("Formatters should not be used.")]
	IFormatterCtorExpression<TValueFormatter> AddFormatter<TValueFormatter>() where TValueFormatter : IValueFormatter;

	[Obsolete("Formatters should not be used.")]
	IFormatterCtorExpression AddFormatter(Type valueFormatterType);

	[Obsolete("Formatters should not be used.")]
	void AddFormatter(IValueFormatter formatter);

	/// <summary>
	/// Substitute a custom value when the source member resolves as null
	/// </summary>
	/// <param name="nullSubstitute">Value to use</param>
	void NullSubstitute(object nullSubstitute);

	/// <summary>
	/// Resolve destination member using a custom value resolver
	/// </summary>
	/// <typeparam name="TValueResolver">Value resolver type</typeparam>
	/// <returns>Value resolver configuration options</returns>
	IResolverConfigurationExpression<TSource, TValueResolver> ResolveUsing<TValueResolver>() where TValueResolver : IValueResolver;

	/// <summary>
	/// Resolve destination member using a custom value resolver. Used when the value resolver is not known at compile-time
	/// </summary>
	/// <param name="valueResolverType">Value resolver type</param>
	/// <returns>Value resolver configuration options</returns>
	IResolverConfigurationExpression<TSource> ResolveUsing(Type valueResolverType);

	/// <summary>
	/// Resolve destination member using a custom value resolver instance
	/// </summary>
	/// <param name="valueResolver">Value resolver instance to use</param>
	/// <returns>Resolution expression</returns>
	IResolutionExpression<TSource> ResolveUsing(IValueResolver valueResolver);

	/// <summary>
	/// Resolve destination member using a custom value resolver callback. Used instead of MapFrom when not simply redirecting a source member
	/// This method cannot be used in conjunction with LINQ query projection
	/// </summary>
	/// <param name="resolver">Callback function to resolve against source type</param>
	void ResolveUsing(Func<TSource, object> resolver);

	/// <summary>
	/// Specify the source member to map from. Can only reference a member on the <typeparamref name="TSource" /> type
	/// This method can be used in mapping to LINQ query projections, while ResolveUsing cannot.
	/// Any null reference exceptions in this expression will be ignored (similar to flattening behavior)
	/// </summary>
	/// <typeparam name="TMember">Member type of the source member to use</typeparam>
	/// <param name="sourceMember">Expression referencing the source member to map against</param>
	void MapFrom<TMember>(Expression<Func<TSource, TMember>> sourceMember);

	/// <summary>
	/// Ignore this member for configuration validation and skip during mapping
	/// </summary>
	void Ignore();

	/// <summary>
	/// Supply a custom mapping order instead of what the .NET runtime returns
	/// </summary>
	/// <param name="mappingOrder">Mapping order value</param>
	void SetMappingOrder(int mappingOrder);

	/// <summary>
	/// Use the destination value instead of mapping from the source value or creating a new instance
	/// </summary>
	void UseDestinationValue();

	/// <summary>
	/// Do not use the destination value instead of mapping from the source value or creating a new instance
	/// </summary>        
	void DoNotUseDestinationValue();

	/// <summary>
	/// Use a custom value
	/// </summary>
	/// <typeparam name="TValue">Value type</typeparam>
	/// <param name="value">Value to use</param>
	void UseValue<TValue>(TValue value);

	/// <summary>
	/// Use a custom value
	/// </summary>
	/// <param name="value">Value to use</param>
	void UseValue(object value);

	/// <summary>
	/// Conditionally map this member
	/// </summary>
	/// <param name="condition">Condition to evaluate using the source object</param>
	void Condition(Func<TSource, bool> condition);

	/// <summary>
	/// Conditionally map this member
	/// </summary>
	/// <param name="condition">Condition to evaluate using the current resolution context</param>
	void Condition(Func<ResolutionContext, bool> condition);
}
