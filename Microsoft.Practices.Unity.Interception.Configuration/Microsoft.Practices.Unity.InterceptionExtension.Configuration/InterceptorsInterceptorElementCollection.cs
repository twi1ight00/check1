using System.Configuration;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Microsoft.Practices.Unity.InterceptionExtension.Configuration;

/// <summary>
/// A collection of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.Configuration.InterceptorsInterceptorElement" /> objects
/// as stored in configuration.
/// </summary>
[ConfigurationCollection(typeof(InterceptorsInterceptorElement), AddItemName = "interceptor")]
public class InterceptorsInterceptorElementCollection : DeserializableConfigurationElementCollection<InterceptorsInterceptorElement>
{
	/// <summary>
	/// Gets the element key for a specified configuration element when overridden in a derived class.
	/// </summary>
	/// <returns>
	/// An <see cref="T:System.Object" /> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement" />.
	/// </returns>
	/// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement" /> to return the key for. 
	///                 </param>
	protected override object GetElementKey(ConfigurationElement element)
	{
		return ((InterceptorsInterceptorElement)element).TypeName;
	}
}
