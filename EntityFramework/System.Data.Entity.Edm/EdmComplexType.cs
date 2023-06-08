using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;
using System.Linq;

namespace System.Data.Entity.Edm;

/// <summary>
///     Allows the construction and modification of a complex type in an Entity Data Model (EDM) <see cref="T:System.Data.Entity.Edm.EdmNamespace" /> .
/// </summary>
internal class EdmComplexType : EdmStructuralType
{
	private readonly BackingList<EdmProperty> declaredPropertiesList = new BackingList<EdmProperty>();

	private EdmComplexType baseComplexType;

	private bool isAbstract;

	public override EdmStructuralTypeMemberCollection Members => new EdmStructuralTypeMemberCollection(() => Properties, () => declaredPropertiesList);

	/// <summary>
	///     Gets or sets the optional <see cref="T:System.Data.Entity.Edm.EdmComplexType" /> that indicates the base complex type of the complex type.
	/// </summary>
	public new virtual EdmComplexType BaseType
	{
		get
		{
			return baseComplexType;
		}
		set
		{
			base.BaseType = value;
			baseComplexType = value;
		}
	}

	/// <summary>
	///     Gets or sets a value indicating whether the complex type is abstract.
	/// </summary>
	public new virtual bool IsAbstract
	{
		get
		{
			return isAbstract;
		}
		set
		{
			base.IsAbstract = value;
			isAbstract = value;
		}
	}

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.EdmProperty" /> instances that describe the (scalar or complex) properties of the complex type.
	/// </summary>
	public virtual IList<EdmProperty> DeclaredProperties
	{
		get
		{
			return declaredPropertiesList.EnsureValue();
		}
		set
		{
			declaredPropertiesList.SetValue(value);
		}
	}

	internal bool HasDeclaredProperties => declaredPropertiesList.HasValue;

	public IEnumerable<EdmProperty> Properties
	{
		get
		{
			foreach (EdmComplexType declaringType in this.ToHierarchy().Reverse())
			{
				foreach (EdmProperty declaredProperties in declaringType.declaredPropertiesList)
				{
					yield return declaredProperties;
				}
			}
		}
	}

	internal override EdmItemKind GetItemKind()
	{
		return EdmItemKind.ComplexType;
	}

	protected override IEnumerable<EdmMetadataItem> GetChildItems()
	{
		return declaredPropertiesList;
	}
}
