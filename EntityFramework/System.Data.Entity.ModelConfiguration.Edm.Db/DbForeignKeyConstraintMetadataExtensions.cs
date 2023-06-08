using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Common;

namespace System.Data.Entity.ModelConfiguration.Edm.Db;

internal static class DbForeignKeyConstraintMetadataExtensions
{
	private const string IsTypeConstraint = "IsTypeConstraint";

	private const string IsSplitConstraint = "IsSplitConstraint";

	private const string AssociationType = "AssociationType";

	public static bool GetIsTypeConstraint(this DbForeignKeyConstraintMetadata fk)
	{
		object annotation = fk.Annotations.GetAnnotation("IsTypeConstraint");
		if (annotation != null)
		{
			return (bool)annotation;
		}
		return false;
	}

	public static void SetIsTypeConstraint(this DbForeignKeyConstraintMetadata fk)
	{
		fk.Annotations.SetAnnotation("IsTypeConstraint", true);
	}

	public static void SetIsSplitConstraint(this DbForeignKeyConstraintMetadata fk)
	{
		fk.Annotations.SetAnnotation("IsSplitConstraint", true);
	}

	public static EdmAssociationType GetAssociationType(this DbForeignKeyConstraintMetadata fk)
	{
		return fk.Annotations.GetAnnotation("AssociationType") as EdmAssociationType;
	}

	public static void SetAssociationType(this DbForeignKeyConstraintMetadata fk, EdmAssociationType associationType)
	{
		fk.Annotations.SetAnnotation("AssociationType", associationType);
	}
}
