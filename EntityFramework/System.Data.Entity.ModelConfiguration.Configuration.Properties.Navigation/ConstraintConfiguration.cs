using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Configuration.Types;

namespace System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;

internal abstract class ConstraintConfiguration
{
	internal virtual bool IsFullySpecified => true;

	internal abstract ConstraintConfiguration Clone();

	internal abstract void Configure(EdmAssociationType associationType, EdmAssociationEnd dependentEnd, EntityTypeConfiguration entityTypeConfiguration);
}
