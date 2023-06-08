using System;
using System.Configuration;
using System.Xml;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension.Configuration;

/// <summary>
/// Base class for the default and key elements that can occur
/// inside the &lt;interceptor&gt; element.
/// </summary>
public abstract class InterceptorRegistrationElement : DeserializableConfigurationElement
{
	private const string TypeNamePropertyName = "type";

	/// <summary>
	/// Type name that this interceptor will be registered for.
	/// </summary>
	[ConfigurationProperty("type", IsRequired = true, IsKey = true)]
	public string TypeName
	{
		get
		{
			return (string)base["type"];
		}
		set
		{
			base["type"] = value;
		}
	}

	internal abstract string Key { get; }

	internal abstract string ElementName { get; }

	/// <summary>
	/// Return the type object that is resolved from the <see cref="P:Microsoft.Practices.Unity.InterceptionExtension.Configuration.InterceptorRegistrationElement.TypeName" /> property.
	/// </summary>
	/// <returns>The type object.</returns>
	protected Type ResolvedType => TypeResolver.ResolveType(TypeName);

	/// <summary>
	/// Write the contents of this element to the given <see cref="T:System.Xml.XmlWriter" />.
	/// </summary>
	/// <remarks>The caller of this method has already written the start element tag before
	/// calling this method, so deriving classes only need to write the element content, not
	/// the start or end tags.</remarks>
	/// <param name="writer">Writer to send XML content to.</param>
	public override void SerializeContent(XmlWriter writer)
	{
		Guard.ArgumentNotNull(writer, "writer");
		writer.WriteAttributeString("type", TypeName);
	}

	/// <summary>
	/// Actually register the interceptor against this type.
	/// </summary>
	/// <param name="container">Container to configure.</param>
	/// <param name="interceptor">interceptor to register.</param>
	internal abstract void RegisterInterceptor(IUnityContainer container, IInterceptor interceptor);
}
