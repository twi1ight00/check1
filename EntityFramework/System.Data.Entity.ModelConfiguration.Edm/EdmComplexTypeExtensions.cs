using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Edm;

internal static class EdmComplexTypeExtensions
{
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmProperty AddComplexProperty(this EdmComplexType complexType, string name, EdmComplexType targetComplexType)
	{
		EdmProperty edmProperty = new EdmProperty();
		edmProperty.Name = name;
		EdmProperty edmProperty2 = edmProperty.AsComplex(targetComplexType);
		complexType.DeclaredProperties.Add(edmProperty2);
		return edmProperty2;
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static object GetConfiguration(this EdmComplexType complexType)
	{
		return complexType.Annotations.GetConfiguration();
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static void SetConfiguration(this EdmComplexType complexType, object configuration)
	{
		complexType.Annotations.SetConfiguration(configuration);
	}

	public static Type GetClrType(this EdmComplexType complexType)
	{
		return complexType.Annotations.GetClrType();
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static void SetClrType(this EdmComplexType complexType, Type type)
	{
		complexType.Annotations.SetClrType(type);
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmProperty AddPrimitiveProperty(this EdmComplexType complexType, string name)
	{
		EdmProperty edmProperty = new EdmProperty().AsPrimitive();
		edmProperty.Name = name;
		complexType.DeclaredProperties.Add(edmProperty);
		return edmProperty;
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmProperty GetPrimitiveProperty(this EdmComplexType complexType, string name)
	{
		return complexType.Properties.SingleOrDefault((EdmProperty p) => p.Name == name);
	}
}
