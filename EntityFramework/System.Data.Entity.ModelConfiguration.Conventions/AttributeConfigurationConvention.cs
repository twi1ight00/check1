using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Base class for conventions that process CLR attributes found in the model.
/// </summary>
/// <typeparam name="TMemberInfo">The type of member to look for.</typeparam>
/// <typeparam name="TConfiguration">The type of the configuration to look for.</typeparam>
/// <typeparam name="TAttribute">The type of the attribute to look for.</typeparam>
internal abstract class AttributeConfigurationConvention<TMemberInfo, TConfiguration, TAttribute> : IConfigurationConvention<TMemberInfo, TConfiguration>, IConvention where TMemberInfo : MemberInfo where TConfiguration : ConfigurationBase where TAttribute : Attribute
{
	private readonly AttributeProvider _attributeProvider;

	protected AttributeConfigurationConvention()
		: this(new AttributeProvider())
	{
	}

	private AttributeConfigurationConvention(AttributeProvider attributeProvider)
	{
		_attributeProvider = attributeProvider;
	}

	internal abstract void Apply(TMemberInfo memberInfo, TConfiguration configuration, TAttribute attribute);

	void IConfigurationConvention<TMemberInfo, TConfiguration>.Apply(TMemberInfo memberInfo, Func<TConfiguration> configuration)
	{
		foreach (TAttribute item in _attributeProvider.GetAttributes(memberInfo).OfType<TAttribute>())
		{
			Apply(memberInfo, configuration(), item);
		}
	}
}
