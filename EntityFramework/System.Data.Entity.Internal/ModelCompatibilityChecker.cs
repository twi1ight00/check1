using System.Data.Entity.Resources;
using System.Xml.Linq;

namespace System.Data.Entity.Internal;

internal class ModelCompatibilityChecker
{
	public virtual bool CompatibleWithModel(InternalContext internalContext, ModelHashCalculator modelHashCalculator, bool throwIfNoMetadata)
	{
		if (internalContext.CodeFirstModel == null)
		{
			if (throwIfNoMetadata)
			{
				throw Error.Database_NonCodeFirstCompatibilityCheck();
			}
			return true;
		}
		XDocument xDocument = internalContext.QueryForModel();
		if (xDocument != null)
		{
			return internalContext.ModelMatches(xDocument);
		}
		string text = internalContext.QueryForModelHash();
		if (text == null)
		{
			if (throwIfNoMetadata)
			{
				throw Error.Database_NoDatabaseMetadata();
			}
			return true;
		}
		return string.Equals(text, modelHashCalculator.Calculate(internalContext.CodeFirstModel), StringComparison.Ordinal);
	}
}
