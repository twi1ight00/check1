using System.Data.Entity.Edm;

namespace System.Data.Entity.ModelConfiguration.Configuration.Types;

internal class ComplexTypeConfiguration : StructuralTypeConfiguration
{
	internal ComplexTypeConfiguration(Type structuralType)
		: base(structuralType)
	{
	}

	private ComplexTypeConfiguration(ComplexTypeConfiguration source)
		: base(source)
	{
	}

	internal virtual ComplexTypeConfiguration Clone()
	{
		return new ComplexTypeConfiguration(this);
	}

	internal virtual void Configure(EdmComplexType complexType)
	{
		Configure(complexType.Name, complexType.DeclaredProperties, complexType.Annotations);
	}
}
