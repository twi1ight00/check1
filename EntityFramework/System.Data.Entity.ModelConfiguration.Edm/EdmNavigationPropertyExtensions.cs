using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Common;

namespace System.Data.Entity.ModelConfiguration.Edm;

internal static class EdmNavigationPropertyExtensions
{
	public static object GetConfiguration(this EdmNavigationProperty navigationProperty)
	{
		return navigationProperty.Annotations.GetConfiguration();
	}

	public static void SetConfiguration(this EdmNavigationProperty navigationProperty, object configuration)
	{
		navigationProperty.Annotations.SetConfiguration(configuration);
	}
}
