using System.Configuration;
using System.Xml;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Microsoft.Practices.Unity.InterceptionExtension.Configuration;

/// <summary>
/// The &lt;key&gt; element that occurs inside an &lt;interceptor&gt; element
/// </summary>
public class KeyElement : InterceptorRegistrationElement
{
	private const string NamePropertyName = "name";

	/// <summary>
	/// Name registration should be under. To register under the default, leave blank.
	/// </summary>
	[ConfigurationProperty("name", IsRequired = false)]
	public string Name
	{
		get
		{
			return (string)base["name"];
		}
		set
		{
			base["name"] = value;
		}
	}

	internal override string Key => "key:" + base.TypeName + ":" + Name;

	internal override string ElementName => "key";

	/// <summary>
	/// Write the contents of this element to the given <see cref="T:System.Xml.XmlWriter" />.
	/// </summary>
	/// <remarks>The caller of this method has already written the start element tag before
	/// calling this method, so deriving classes only need to write the element content, not
	/// the start or end tags.</remarks>
	/// <param name="writer">Writer to send XML content to.</param>
	public override void SerializeContent(XmlWriter writer)
	{
		base.SerializeContent(writer);
		writer.WriteAttributeIfNotEmpty("name", Name);
	}

	/// <summary>
	/// Actually register the interceptor against this type.
	/// </summary>
	/// <param name="container">Container to configure.</param>
	/// <param name="interceptor">interceptor to register.</param>
	internal override void RegisterInterceptor(IUnityContainer container, IInterceptor interceptor)
	{
		if (interceptor is ITypeInterceptor interceptor2)
		{
			container.Configure<Interception>().SetInterceptorFor(base.ResolvedType, Name, interceptor2);
		}
		else
		{
			container.Configure<Interception>().SetInterceptorFor(base.ResolvedType, Name, (IInstanceInterceptor)interceptor);
		}
	}
}
