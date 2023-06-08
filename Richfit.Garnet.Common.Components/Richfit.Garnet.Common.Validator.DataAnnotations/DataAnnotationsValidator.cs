using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Richfit.Garnet.Common.Validator.DataAnnotations;

/// <summary>
/// Validator based on Data Annotations. 
/// This validator use IValidatableObject interface and
/// ValidationAttribute ( hierachy of this) for
/// perform validation
/// </summary>
public class DataAnnotationsValidator : IValidator
{
	/// <summary>
	/// Get erros if object implement IValidatableObject
	/// </summary>
	/// <typeparam name="TEntity">类型</typeparam>
	/// <param name="item">验证对象</param>
	/// <param name="errors">错误集合</param>
	private void SetValidatableObjectErrors<TEntity>(TEntity item, List<string> errors) where TEntity : class
	{
		if (typeof(IValidatableObject).IsAssignableFrom(typeof(TEntity)))
		{
			ValidationContext validationContext = new ValidationContext(item, null, null);
			IEnumerable<ValidationResult> validationResults = ((IValidatableObject)item).Validate(validationContext);
			errors.AddRange(validationResults.Select((ValidationResult vr) => vr.ErrorMessage));
		}
	}

	/// <summary>
	/// Get errors on ValidationAttribute
	/// </summary>
	/// <typeparam name="TEntity">类型</typeparam>
	/// <param name="item">验证对象</param>
	/// <param name="errors">错误集合</param>
	private void SetValidationAttributeErrors<TEntity>(TEntity item, List<string> errors) where TEntity : class
	{
		IEnumerable<string> result = from PropertyDescriptor property in TypeDescriptor.GetProperties(item)
			from attribute in property.Attributes.OfType<ValidationAttribute>()
			where !attribute.IsValid(property.GetValue(item))
			select attribute.FormatErrorMessage(string.Empty);
		if (result != null && result.Any())
		{
			errors.AddRange(result);
		}
	}

	/// <summary>
	/// Validate the data
	/// </summary>
	/// <typeparam name="TEntity">对象类型</typeparam>
	/// <param name="item">对象</param>
	/// <returns>true，验证通过；false，验证失败</returns>
	public bool IsValid<TEntity>(TEntity item) where TEntity : class
	{
		if (item == null)
		{
			return false;
		}
		List<string> validationErrors = new List<string>();
		SetValidatableObjectErrors(item, validationErrors);
		SetValidationAttributeErrors(item, validationErrors);
		return !validationErrors.Any();
	}

	/// <summary>
	/// 获得验证错误的消息集合
	/// </summary>
	/// <typeparam name="TEntity">类型</typeparam>
	/// <param name="item">对象</param>
	/// <returns></returns>
	public IEnumerable<string> GetInvalidMessages<TEntity>(TEntity item) where TEntity : class
	{
		if (item == null)
		{
			return null;
		}
		List<string> validationErrors = new List<string>();
		SetValidatableObjectErrors(item, validationErrors);
		SetValidationAttributeErrors(item, validationErrors);
		return validationErrors;
	}
}
