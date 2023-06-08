using System.Data.Entity.Internal;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Serialization;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Contains methods used to access the Entity Data Model created by Code First in the EDMX form.
///     These methods are typically used for debugging when there is a need to look at the model that
///     Code First creates internally.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Edmx")]
public static class EdmxWriter
{
	/// <summary>
	///     Uses Code First with the given context and writes the resulting Entity Data Model to the given
	///     writer in EDMX form.  This method can only be used with context instances that use Code First
	///     and create the model internally.  The method cannot be used for contexts created using Database
	///     First or Model First, for contexts created using a pre-existing <see cref="T:System.Data.Objects.ObjectContext" />, or
	///     for contexts created using a pre-existing <see cref="T:System.Data.Entity.Infrastructure.DbCompiledModel" />.
	/// </summary>
	/// <param name="context">The context.</param>
	/// <param name="writer">The writer.</param>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Edmx")]
	public static void WriteEdmx(DbContext context, XmlWriter writer)
	{
		RuntimeFailureMethods.Requires(context != null, null, "context != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		InternalContext internalContext = context.InternalContext;
		if (internalContext is EagerInternalContext)
		{
			throw Error.EdmxWriter_EdmxFromObjectContextNotSupported();
		}
		DbCompiledModel codeFirstModel = internalContext.CodeFirstModel;
		if (codeFirstModel == null)
		{
			throw Error.EdmxWriter_EdmxFromModelFirstNotSupported();
		}
		DbModelBuilder dbModelBuilder = codeFirstModel.CachedModelBuilder.Clone();
		WriteEdmx((internalContext.ModelProviderInfo == null) ? dbModelBuilder.Build(internalContext.Connection) : dbModelBuilder.Build(internalContext.ModelProviderInfo), writer);
	}

	/// <summary>
	///     Writes the Entity Data Model represented by the given <see cref="T:System.Data.Entity.Infrastructure.DbModel" /> to the
	///     given writer in EDMX form.
	/// </summary>
	/// <param name="modelaseMapping">An object representing the EDM.</param>
	/// <param name="writer">The writer.</param>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Edmx")]
	public static void WriteEdmx(DbModel model, XmlWriter writer)
	{
		RuntimeFailureMethods.Requires(model != null, null, "model != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		new EdmxSerializer().Serialize(model.DatabaseMapping, 2.0, model.DatabaseMapping.Database.GetProviderInfo(), writer);
	}
}
