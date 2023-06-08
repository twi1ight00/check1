using System;
using System.Globalization;
using Microsoft.Practices.Unity.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuildKeyMappingPolicy" /> that can map
/// generic types.
/// </summary>
public class GenericTypeBuildKeyMappingPolicy : IBuildKeyMappingPolicy, IBuilderPolicy
{
	private readonly NamedTypeBuildKey destinationKey;

	private Type DestinationType => destinationKey.Type;

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.ObjectBuilder2.GenericTypeBuildKeyMappingPolicy" /> instance
	/// that will map generic types.
	/// </summary>
	/// <param name="destinationKey">Build key to map to. This must be or contain an open generic type.</param>
	public GenericTypeBuildKeyMappingPolicy(NamedTypeBuildKey destinationKey)
	{
		Guard.ArgumentNotNull(destinationKey, "destinationKey");
		if (!destinationKey.Type.IsGenericTypeDefinition)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.MustHaveOpenGenericType, destinationKey.Type.Name));
		}
		this.destinationKey = destinationKey;
	}

	/// <summary>
	/// Maps the build key.
	/// </summary>
	/// <param name="buildKey">The build key to map.</param>
	/// <param name="context">Current build context. Used for contextual information
	/// if writing a more sophisticated mapping.</param>
	/// <returns>The new build key.</returns>
	public NamedTypeBuildKey Map(NamedTypeBuildKey buildKey, IBuilderContext context)
	{
		Guard.ArgumentNotNull(buildKey, "buildKey");
		Type type = buildKey.Type;
		GuardSameNumberOfGenericArguments(type);
		Type[] genericArguments = type.GetGenericArguments();
		Type type2 = destinationKey.Type.MakeGenericType(genericArguments);
		return new NamedTypeBuildKey(type2, destinationKey.Name);
	}

	private void GuardSameNumberOfGenericArguments(Type sourceType)
	{
		if (sourceType.GetGenericArguments().Length != DestinationType.GetGenericArguments().Length)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.MustHaveSameNumberOfGenericArguments, sourceType.Name, DestinationType.Name), "sourceType");
		}
	}
}
