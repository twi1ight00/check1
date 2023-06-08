using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Common;

namespace System.Data.Entity.ModelConfiguration.Edm;

internal static class EdmAssociationTypeExtensions
{
	private const string IsIndependentAnnotation = "IsIndependent";

	private const string IsPrincipalConfiguredAnnotation = "IsPrincipalConfigured";

	public static EdmAssociationType Initialize(this EdmAssociationType associationType)
	{
		associationType.SourceEnd = new EdmAssociationEnd();
		associationType.TargetEnd = new EdmAssociationEnd();
		return associationType;
	}

	public static void MarkIndependent(this EdmAssociationType associationType)
	{
		associationType.Annotations.SetAnnotation("IsIndependent", true);
	}

	public static bool IsIndependent(this EdmAssociationType associationType)
	{
		object annotation = associationType.Annotations.GetAnnotation("IsIndependent");
		if (annotation == null)
		{
			return false;
		}
		return (bool)annotation;
	}

	public static void MarkPrincipalConfigured(this EdmAssociationType associationType)
	{
		associationType.Annotations.SetAnnotation("IsPrincipalConfigured", true);
	}

	public static bool IsPrincipalConfigured(this EdmAssociationType associationType)
	{
		object annotation = associationType.Annotations.GetAnnotation("IsPrincipalConfigured");
		if (annotation == null)
		{
			return false;
		}
		return (bool)annotation;
	}

	public static EdmAssociationEnd GetOtherEnd(this EdmAssociationType associationType, EdmAssociationEnd associationEnd)
	{
		if (associationEnd != associationType.SourceEnd)
		{
			return associationType.SourceEnd;
		}
		return associationType.TargetEnd;
	}

	public static object GetConfiguration(this EdmAssociationType associationType)
	{
		return associationType.Annotations.GetConfiguration();
	}

	public static void SetConfiguration(this EdmAssociationType associationType, object configuration)
	{
		associationType.Annotations.SetConfiguration(configuration);
	}

	public static bool HasDeleteAction(this EdmAssociationType associationType)
	{
		if (!associationType.SourceEnd.DeleteAction.HasValue)
		{
			return associationType.TargetEnd.DeleteAction.HasValue;
		}
		return true;
	}

	public static bool IsRequiredToMany(this EdmAssociationType associationType)
	{
		if (associationType.SourceEnd.IsRequired())
		{
			return associationType.TargetEnd.IsMany();
		}
		return false;
	}

	public static bool IsManyToRequired(this EdmAssociationType associationType)
	{
		if (associationType.SourceEnd.IsMany())
		{
			return associationType.TargetEnd.IsRequired();
		}
		return false;
	}

	public static bool IsManyToMany(this EdmAssociationType associationType)
	{
		if (associationType.SourceEnd.IsMany())
		{
			return associationType.TargetEnd.IsMany();
		}
		return false;
	}

	public static bool IsOneToOne(this EdmAssociationType associationType)
	{
		if (!associationType.SourceEnd.IsMany())
		{
			return !associationType.TargetEnd.IsMany();
		}
		return false;
	}

	public static bool IsSelfReferencing(this EdmAssociationType associationType)
	{
		EdmAssociationEnd sourceEnd = associationType.SourceEnd;
		EdmAssociationEnd targetEnd = associationType.TargetEnd;
		return sourceEnd.EntityType.GetRootType() == targetEnd.EntityType.GetRootType();
	}

	public static bool IsRequiredToNonRequired(this EdmAssociationType associationType)
	{
		if (!associationType.SourceEnd.IsRequired() || associationType.TargetEnd.IsRequired())
		{
			if (associationType.TargetEnd.IsRequired())
			{
				return !associationType.SourceEnd.IsRequired();
			}
			return false;
		}
		return true;
	}

	/// <summary>
	///     Attempt to determine the principal and dependent ends of this association.
	///
	///     The following table illustrates the solution space.
	///
	///     Source | Target || Prin  | Dep   |
	///     -------|--------||-------|-------|
	///     1      | 1      || -     | -     | 
	///     1      | 0..1   || Sr    | Ta    |
	///     1      | *      || Sr    | Ta    |
	///     0..1   | 1      || Ta    | Sr    |
	///     0..1   | 0..1   || -     | -     |
	///     0..1   | *      || Sr    | Ta    |
	///     *      | 1      || Ta    | Sr    |
	///     *      | 0..1   || Ta    | Sr    |
	///     *      | *      || -     | -     |
	/// </summary>
	public static bool TryGuessPrincipalAndDependentEnds(this EdmAssociationType associationType, out EdmAssociationEnd principalEnd, out EdmAssociationEnd dependentEnd)
	{
		principalEnd = (dependentEnd = null);
		EdmAssociationEnd sourceEnd = associationType.SourceEnd;
		EdmAssociationEnd targetEnd = associationType.TargetEnd;
		if (sourceEnd.EndKind != targetEnd.EndKind)
		{
			principalEnd = ((sourceEnd.IsRequired() || (sourceEnd.IsOptional() && targetEnd.IsMany())) ? sourceEnd : targetEnd);
			dependentEnd = ((principalEnd == sourceEnd) ? targetEnd : sourceEnd);
		}
		return principalEnd != null;
	}
}
