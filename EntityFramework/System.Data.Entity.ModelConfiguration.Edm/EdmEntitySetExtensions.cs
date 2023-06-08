using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Common;

namespace System.Data.Entity.ModelConfiguration.Edm;

internal static class EdmEntitySetExtensions
{
	public static object GetConfiguration(this EdmEntitySet entitySet)
	{
		return entitySet.Annotations.GetConfiguration();
	}

	public static void SetConfiguration(this EdmEntitySet entitySet, object configuration)
	{
		entitySet.Annotations.SetConfiguration(configuration);
	}
}
