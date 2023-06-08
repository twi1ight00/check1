namespace System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;

/// <summary>
///     Indicates what parts of a configuration are overridable.
/// </summary>
[Flags]
internal enum OverridableConfigurationParts
{
	/// <summary>
	///     Nothing in the configuration is overridable.
	/// </summary>
	None = 0,
	/// <summary>
	///     The configuration values related to C-Space are overridable.
	/// </summary>
	OverridableInCSpace = 1,
	/// <summary>
	///     The configuration values only related to S-Space are overridable.
	/// </summary>
	OverridableInSSpace = 2
}
