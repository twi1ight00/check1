using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.Resources;
using System.Text;

namespace System.Data.Entity.ModelConfiguration.Edm.Common;

internal static class DataModelErrorEventArgsExtensions
{
	public static string ToErrorMessage(this IEnumerable<DataModelErrorEventArgs> validationErrors)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(Strings.ValidationHeader);
		stringBuilder.AppendLine();
		foreach (DataModelErrorEventArgs validationError in validationErrors)
		{
			stringBuilder.AppendLine(Strings.ValidationItemFormat(validationError.Item, validationError.PropertyName, validationError.ErrorMessage));
		}
		return stringBuilder.ToString();
	}
}
