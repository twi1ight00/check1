using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     This <see cref="T:System.Data.Entity.DbModelBuilder" /> convention uses the namespace of the derived
///     <see cref="T:System.Data.Entity.DbContext" /> class as the namespace of the conceptual model built by
///     Code First.
/// </summary>
public class ModelNamespaceConvention : IEdmConvention, IConvention
{
	private readonly string _modelNamespace;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.ModelNamespaceConvention" /> class.
	/// </summary>
	/// <param name="modelNamespace">The model namespace.</param>
	internal ModelNamespaceConvention(string modelNamespace)
	{
		_modelNamespace = modelNamespace;
	}

	/// <summary>
	///     Applies the convention to the given model.
	/// </summary>
	/// <param name="model">The model.</param>
	void IEdmConvention.Apply(EdmModel model)
	{
		model.Namespaces.Single().Name = _modelNamespace;
	}
}
