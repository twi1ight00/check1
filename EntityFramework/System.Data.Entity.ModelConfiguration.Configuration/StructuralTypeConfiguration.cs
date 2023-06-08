using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace System.Data.Entity.ModelConfiguration.Configuration;

/// <summary>
///     Allows configuration to be performed for a type in a model.
/// </summary>
/// <typeparam name="TStructuralType">The type to be configured.</typeparam>
public abstract class StructuralTypeConfiguration<TStructuralType> where TStructuralType : class
{
	internal abstract StructuralTypeConfiguration Configuration { get; }

	/// <summary>
	///     Configures a <see cref="T:System.struct" /> property that is defined on this type.
	/// </summary>
	/// <typeparam name="T">The type of the property being configured.</typeparam>
	/// <param name="propertyExpression">
	///     A lambda expression representing the property to be configured.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to configure the property.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public PrimitivePropertyConfiguration Property<T>(Expression<Func<TStructuralType, T>> propertyExpression) where T : struct
	{
		return new PrimitivePropertyConfiguration(Property<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration>(propertyExpression));
	}

	/// <summary>
	///     Configures a <see cref="T:System.struct?" /> property that is defined on this type.
	/// </summary>
	/// <typeparam name="T">The type of the property being configured.</typeparam>
	/// <param name="propertyExpression">
	///     A lambda expression representing the property to be configured.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to configure the property.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public PrimitivePropertyConfiguration Property<T>(Expression<Func<TStructuralType, T?>> propertyExpression) where T : struct
	{
		return new PrimitivePropertyConfiguration(Property<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration>(propertyExpression));
	}

	/// <summary>
	///     Configures a <see cref="T:System.string" /> property that is defined on this type.
	/// </summary>
	/// <param name="propertyExpression">
	///     A lambda expression representing the property to be configured.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to configure the property.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public StringPropertyConfiguration Property(Expression<Func<TStructuralType, string>> propertyExpression)
	{
		return new StringPropertyConfiguration(Property<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.StringPropertyConfiguration>(propertyExpression));
	}

	/// <summary>
	///     Configures a <see cref="T:System.byte[]" /> property that is defined on this type.
	/// </summary>
	/// <param name="propertyExpression">
	///     A lambda expression representing the property to be configured.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to configure the property.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public BinaryPropertyConfiguration Property(Expression<Func<TStructuralType, byte[]>> propertyExpression)
	{
		return new BinaryPropertyConfiguration(Property<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.BinaryPropertyConfiguration>(propertyExpression));
	}

	/// <summary>
	///     Configures a <see cref="T:System.decimal" /> property that is defined on this type.
	/// </summary>
	/// <param name="propertyExpression">
	///     A lambda expression representing the property to be configured.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to configure the property.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public DecimalPropertyConfiguration Property(Expression<Func<TStructuralType, decimal>> propertyExpression)
	{
		return new DecimalPropertyConfiguration(Property<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.DecimalPropertyConfiguration>(propertyExpression));
	}

	/// <summary>
	///     Configures a <see cref="T:System.decimal?" /> property that is defined on this type.
	/// </summary>
	/// <param name="propertyExpression">
	///     A lambda expression representing the property to be configured.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to configure the property.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public DecimalPropertyConfiguration Property(Expression<Func<TStructuralType, decimal?>> propertyExpression)
	{
		return new DecimalPropertyConfiguration(Property<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.DecimalPropertyConfiguration>(propertyExpression));
	}

	/// <summary>
	///     Configures a <see cref="T:System.DateTime" /> property that is defined on this type.
	/// </summary>
	/// <param name="propertyExpression">
	///     A lambda expression representing the property to be configured.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to configure the property.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public DateTimePropertyConfiguration Property(Expression<Func<TStructuralType, DateTime>> propertyExpression)
	{
		return new DateTimePropertyConfiguration(Property<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.DateTimePropertyConfiguration>(propertyExpression));
	}

	/// <summary>
	///     Configures a <see cref="T:System.DateTime?" /> property that is defined on this type.
	/// </summary>
	/// <param name="propertyExpression">
	///     A lambda expression representing the property to be configured.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to configure the property.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public DateTimePropertyConfiguration Property(Expression<Func<TStructuralType, DateTime?>> propertyExpression)
	{
		return new DateTimePropertyConfiguration(Property<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.DateTimePropertyConfiguration>(propertyExpression));
	}

	/// <summary>
	///     Configures a <see cref="T:System.DateTimeOffset" /> property that is defined on this type.
	/// </summary>
	/// <param name="propertyExpression">
	///     A lambda expression representing the property to be configured.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to configure the property.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public DateTimePropertyConfiguration Property(Expression<Func<TStructuralType, DateTimeOffset>> propertyExpression)
	{
		return new DateTimePropertyConfiguration(Property<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.DateTimePropertyConfiguration>(propertyExpression));
	}

	/// <summary>
	///     Configures a <see cref="T:System.DateTimeOffset?" /> property that is defined on this type.
	/// </summary>
	/// <param name="propertyExpression">
	///     A lambda expression representing the property to be configured.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to configure the property.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public DateTimePropertyConfiguration Property(Expression<Func<TStructuralType, DateTimeOffset?>> propertyExpression)
	{
		return new DateTimePropertyConfiguration(Property<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.DateTimePropertyConfiguration>(propertyExpression));
	}

	/// <summary>
	///     Configures a <see cref="T:System.TimeSpan" /> property that is defined on this type.
	/// </summary>
	/// <param name="propertyExpression">
	///     A lambda expression representing the property to be configured.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to configure the property.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public DateTimePropertyConfiguration Property(Expression<Func<TStructuralType, TimeSpan>> propertyExpression)
	{
		return new DateTimePropertyConfiguration(Property<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.DateTimePropertyConfiguration>(propertyExpression));
	}

	/// <summary>
	///     Configures a <see cref="T:System.TimeSpan?" /> property that is defined on this type.
	/// </summary>
	/// <param name="propertyExpression">
	///     A lambda expression representing the property to be configured.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to configure the property.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public DateTimePropertyConfiguration Property(Expression<Func<TStructuralType, TimeSpan?>> propertyExpression)
	{
		return new DateTimePropertyConfiguration(Property<System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.DateTimePropertyConfiguration>(propertyExpression));
	}

	/// <summary>
	///     Excludes a property from the model so that it will not be mapped to the database.
	/// </summary>
	/// <typeparam name="TProperty">The type of the property to be ignored.</typeparam>
	/// <param name="propertyExpression">
	///     A lambda expression representing the property to be configured.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public void Ignore<TProperty>(Expression<Func<TStructuralType, TProperty>> propertyExpression)
	{
		RuntimeFailureMethods.Requires(propertyExpression != null, null, "propertyExpression != null");
		Configuration.Ignore(propertyExpression.GetSimplePropertyAccess().Single());
	}

	internal abstract TPrimitivePropertyConfiguration Property<TPrimitivePropertyConfiguration>(LambdaExpression lambdaExpression) where TPrimitivePropertyConfiguration : System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration, new();

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string ToString()
	{
		return base.ToString();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}
}
