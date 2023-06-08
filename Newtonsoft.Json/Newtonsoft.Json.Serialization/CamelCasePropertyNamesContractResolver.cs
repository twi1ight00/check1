namespace Newtonsoft.Json.Serialization;

/// <summary>
///   Resolves member mappings for a type, camel casing property names.
/// </summary>
public class CamelCasePropertyNamesContractResolver : DefaultContractResolver
{
	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver" /> class.
	/// </summary>
	public CamelCasePropertyNamesContractResolver()
		: base(shareCache: true)
	{
		base.NamingStrategy = new CamelCaseNamingStrategy
		{
			ProcessDictionaryKeys = true,
			OverrideSpecifiedNames = true
		};
	}
}
