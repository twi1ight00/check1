using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     This <see cref="T:System.Data.Entity.DbModelBuilder" /> convention uses the name of the derived
///     <see cref="T:System.Data.Entity.DbContext" /> class as the container for the conceptual model built by
///     Code First.
/// </summary>
public class ModelContainerConvention : IEdmConvention, IConvention
{
	private readonly string _containerName;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.ModelContainerConvention" /> class.
	/// </summary>
	/// <param name="containerName">The model container name.</param>
	internal ModelContainerConvention(string containerName)
	{
		_containerName = containerName;
	}

	/// <summary>
	///     Applies the convention to the given model.
	/// </summary>
	/// <param name="model">The model.</param>
	void IEdmConvention.Apply(EdmModel model)
	{
		model.Containers.Single().Name = _containerName;
	}
}
