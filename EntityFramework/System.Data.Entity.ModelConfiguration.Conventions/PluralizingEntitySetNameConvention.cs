using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Design.PluralizationServices;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Globalization;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to set the entity set name to be a pluralized version of the entity type name.
/// </summary>
public sealed class PluralizingEntitySetNameConvention : IEdmConvention<EdmEntitySet>, IConvention
{
	private static readonly PluralizationService _pluralizationService = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));

	internal PluralizingEntitySetNameConvention()
	{
	}

	void IEdmConvention<EdmEntitySet>.Apply(EdmEntitySet entitySet, EdmModel model)
	{
		if (entitySet.GetConfiguration() == null)
		{
			entitySet.Name = model.GetEntitySets().Except(new EdmEntitySet[1] { entitySet }).UniquifyName(_pluralizationService.Pluralize(entitySet.Name));
		}
	}
}
