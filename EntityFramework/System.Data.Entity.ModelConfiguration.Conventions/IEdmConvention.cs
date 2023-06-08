using System.Data.Entity.Edm;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.ModelConfiguration.Conventions;

[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Edm")]
internal interface IEdmConvention<TEdmDataModelItem> : IConvention where TEdmDataModelItem : EdmDataModelItem
{
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "edm")]
	void Apply(TEdmDataModelItem edmDataModelItem, EdmModel model);
}
[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Edm")]
internal interface IEdmConvention : IConvention
{
	void Apply(EdmModel model);
}
