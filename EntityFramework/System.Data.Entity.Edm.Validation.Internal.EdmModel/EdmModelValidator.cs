namespace System.Data.Entity.Edm.Validation.Internal.EdmModel;

/// <summary>
///     Edm Model Validator
/// </summary>
internal static class EdmModelValidator
{
	/// <summary>
	///     validate the <see cref="T:System.Data.Entity.Edm.EdmModel" /> from the root with the context
	/// </summary>
	/// <param name="validateRoot"> The root to validate from </param>
	/// <param name="context"> The validation context </param>
	internal static void Validate(System.Data.Entity.Edm.EdmModel validateRoot, EdmModelValidationContext context)
	{
		EdmModelRuleSet ruleSet = EdmModelRuleSet.CreateEdmModelRuleSet(context.ValidationContextVersion, context.ValidateSyntax);
		EdmModelValidationVisitor edmModelValidationVisitor = new EdmModelValidationVisitor(context, ruleSet);
		edmModelValidationVisitor.Visit(validateRoot);
	}
}
