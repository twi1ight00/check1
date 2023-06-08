using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Internal;

namespace System.Data.Entity.ModelConfiguration.Utilities;

internal static class ValidationContextExtensions
{
	public static void SetDisplayName(this ValidationContext validationContext, InternalMemberEntry property, DisplayAttribute displayAttribute)
	{
		string text = displayAttribute?.Name;
		if (property == null)
		{
			Type objectType = ObjectContextTypeCache.GetObjectType(validationContext.ObjectType);
			validationContext.DisplayName = text ?? objectType.Name;
			validationContext.MemberName = null;
		}
		else
		{
			property.EntryMetadata.DeclaringType.GetProperty(property.Name);
			validationContext.DisplayName = text ?? DbHelpers.GetPropertyPath(property);
			validationContext.MemberName = DbHelpers.GetPropertyPath(property);
		}
	}
}
