using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Microsoft.Practices.Unity.Configuration;

/// <summary>
/// A configuration element representing a single container type registration.
/// </summary>
public class RegisterElement : ContainerConfiguringElement
{
	private const string InjectionMembersPropertyName = "";

	private const string LifetimePropertyName = "lifetime";

	private const string MapToPropertyName = "mapTo";

	private const string NamePropertyName = "name";

	private const string TypePropertyName = "type";

	/// <summary>
	/// The type that is registered.
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

	/// <summary>
	/// Name registered under.
	/// </summary>
	[ConfigurationProperty("name", DefaultValue = "", IsRequired = false, IsKey = true)]
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

	/// <summary>
	/// Type that is mapped to.
	/// </summary>
	[ConfigurationProperty("mapTo", DefaultValue = "", IsRequired = false)]
	public string MapToName
	{
		get
		{
			return (string)base["mapTo"];
		}
		set
		{
			base["mapTo"] = value;
		}
	}

	/// <summary>
	/// Lifetime manager to register for this registration.
	/// </summary>
	[ConfigurationProperty("lifetime", IsRequired = false)]
	public LifetimeElement Lifetime
	{
		get
		{
			return (LifetimeElement)base["lifetime"];
		}
		set
		{
			base["lifetime"] = value;
		}
	}

	/// <summary>
	/// Any injection members (constructor, properties, etc.) that are specified for
	/// this registration.
	/// </summary>
	[ConfigurationProperty("", IsDefaultCollection = true)]
	public InjectionMemberElementCollection InjectionMembers => (InjectionMemberElementCollection)base[""];

	/// <summary>
	/// Apply the registrations from this element to the given container.
	/// </summary>
	/// <param name="container">Container to configure.</param>
	protected override void ConfigureContainer(IUnityContainer container)
	{
		Type registeringType = GetRegisteringType();
		Type mappedType = GetMappedType();
		LifetimeManager lifetimeManager = Lifetime.CreateLifetimeManager();
		IEnumerable<InjectionMember> source = InjectionMembers.SelectMany((InjectionMemberElement m) => m.GetInjectionMembers(container, registeringType, mappedType, Name));
		container.RegisterType(registeringType, mappedType, Name, lifetimeManager, source.ToArray());
	}

	/// <summary>
	/// Write the contents of this element to the given <see cref="T:System.Xml.XmlWriter" />.
	/// </summary>
	/// <remarks>The caller of this method has already written the start element tag before
	/// calling this method, so deriving classes only need to write the element content, not
	/// the start or end tags.</remarks>
	/// <param name="writer">Writer to send XML content to.</param>
	public override void SerializeContent(XmlWriter writer)
	{
		writer.WriteAttributeString("type", TypeName);
		writer.WriteAttributeIfNotEmpty("mapTo", MapToName).WriteAttributeIfNotEmpty("name", Name);
		if (!string.IsNullOrEmpty(Lifetime.TypeName))
		{
			writer.WriteElement("lifetime", Lifetime.SerializeContent);
		}
		SerializeInjectionMembers(writer);
	}

	private Type GetRegisteringType()
	{
		if (!string.IsNullOrEmpty(MapToName))
		{
			return TypeResolver.ResolveType(TypeName);
		}
		return null;
	}

	private Type GetMappedType()
	{
		if (string.IsNullOrEmpty(MapToName))
		{
			return TypeResolver.ResolveType(TypeName);
		}
		return TypeResolver.ResolveType(MapToName);
	}

	private void SerializeInjectionMembers(XmlWriter writer)
	{
		foreach (InjectionMemberElement injectionMember in InjectionMembers)
		{
			writer.WriteElement(injectionMember.ElementName, injectionMember.SerializeContent);
		}
	}
}
