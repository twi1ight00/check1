using System.Data.Entity.Edm.Common;
using System.Data.Entity.Edm.Serialization.Xml.Internal.Csdl;
using System.Data.Entity.Edm.Validation.Internal;
using System.Data.Entity.Resources;
using System.Xml;

namespace System.Data.Entity.Edm.Serialization;

/// <summary>
///     Serializes an <see cref="T:System.Data.Entity.Edm.EdmModel" /> that conforms to the restrictions of a single CSDL schema file to an XML writer. The model to be serialized must contain a single <see cref="T:System.Data.Entity.Edm.EdmNamespace" /> and a single <see cref="T:System.Data.Entity.Edm.EdmEntityContainer" /> .
/// </summary>
internal class CsdlSerializer
{
	private bool _isModelValid = true;

	public event EventHandler<DataModelErrorEventArgs> OnError;

	/// <summary>
	///     Serialize the <see cref="T:System.Data.Entity.Edm.EdmModel" /> to the XmlWriter.
	/// </summary>
	/// <param name="model"> The EdmModel to serialize, mut have only one <see cref="T:System.Data.Entity.Edm.EdmNamespace" /> and one <see cref="T:System.Data.Entity.Edm.EdmEntityContainer" /> </param>
	/// <param name="xmlWriter"> The XmlWriter to serialize to </param>
	public bool Serialize(EdmModel model, XmlWriter xmlWriter)
	{
		if (model.Namespaces.Count != 1 || model.Containers.Count != 1)
		{
			Validator_OnError(this, new DataModelErrorEventArgs
			{
				ErrorMessage = Strings.Serializer_OneNamespaceAndOneContainer,
				ErrorCode = 215
			});
		}
		DataModelValidator dataModelValidator = new DataModelValidator();
		dataModelValidator.OnError += Validator_OnError;
		dataModelValidator.Validate(model, validateSyntax: true);
		if (_isModelValid)
		{
			EdmModelCsdlSerializationVisitor edmModelCsdlSerializationVisitor = new EdmModelCsdlSerializationVisitor(xmlWriter, model.Version);
			edmModelCsdlSerializationVisitor.Visit(model);
		}
		return _isModelValid;
	}

	private void Validator_OnError(object sender, DataModelErrorEventArgs e)
	{
		_isModelValid = false;
		if (this.OnError != null)
		{
			this.OnError(sender, e);
		}
	}
}
