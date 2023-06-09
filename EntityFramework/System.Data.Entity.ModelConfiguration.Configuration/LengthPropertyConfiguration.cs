using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;

namespace System.Data.Entity.ModelConfiguration.Configuration;

/// <summary>
///     Used to configure a property with length facets for an entity type or complex type. 
///     This configuration functionality is available via the Code First Fluent API, see <see cref="T:System.Data.Entity.DbModelBuilder" />.
/// </summary>
public abstract class LengthPropertyConfiguration : PrimitivePropertyConfiguration
{
	internal new System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.LengthPropertyConfiguration Configuration => (System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.LengthPropertyConfiguration)base.Configuration;

	internal LengthPropertyConfiguration(System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.LengthPropertyConfiguration configuration)
		: base(configuration)
	{
	}

	/// <summary>
	///     Configures the property to allow the maximum length supported by the database provider.
	/// </summary>
	/// <returns>The same LengthPropertyConfiguration instance so that multiple calls can be chained.</returns>
	public LengthPropertyConfiguration IsMaxLength()
	{
		Configuration.IsMaxLength = true;
		Configuration.MaxLength = null;
		return this;
	}

	/// <summary>
	///     Configures the property to have the specified maximum length.
	/// </summary>
	/// <param name="value">
	///     The maximum length for the property.
	///     Setting 'null' will remove any maximum length restriction from the property and a default length will be used for the database column.
	/// </param>
	/// <returns>The same LengthPropertyConfiguration instance so that multiple calls can be chained.</returns>
	public LengthPropertyConfiguration HasMaxLength(int? value)
	{
		Configuration.MaxLength = value;
		Configuration.IsMaxLength = null;
		Configuration.IsFixedLength = Configuration.IsFixedLength ?? false;
		return this;
	}

	/// <summary>
	///     Configures the property to be fixed length.
	///     Use HasMaxLength to set the length that the property is fixed to.
	/// </summary>
	/// <returns>The same LengthPropertyConfiguration instance so that multiple calls can be chained.</returns>
	public LengthPropertyConfiguration IsFixedLength()
	{
		Configuration.IsFixedLength = true;
		return this;
	}

	/// <summary>
	///     Configures the property to be variable length.
	///     Properties are variable length by default.
	/// </summary>
	/// <returns>The same LengthPropertyConfiguration instance so that multiple calls can be chained.</returns>
	public LengthPropertyConfiguration IsVariableLength()
	{
		Configuration.IsFixedLength = false;
		return this;
	}

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
