using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace System.ComponentModel.DataAnnotations;

/// <summary>
///     Specifies the maximum length of array/string data allowed in a property.
/// </summary>
[SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes", Justification = "We want users to be able to extend this class")]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class MaxLengthAttribute : ValidationAttribute
{
	private const int MaxAllowableLength = -1;

	/// <summary>
	///     Gets the maximum allowable length of the array/string data.
	/// </summary>
	public int Length { get; internal set; }

	private static string DefaultErrorMessageString => EntityRes.GetString("MaxLengthAttribute_ValidationError");

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.MaxLengthAttribute" /> class.
	/// </summary>
	/// <param name="length">
	///     The maximum allowable length of array/string data.
	///     Value must be greater than zero.
	/// </param>
	public MaxLengthAttribute(int length)
		: base(() => DefaultErrorMessageString)
	{
		Length = length;
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.MaxLengthAttribute" /> class.
	///     The maximum allowable length supported by the database will be used.
	/// </summary>
	public MaxLengthAttribute()
		: base(() => DefaultErrorMessageString)
	{
		Length = -1;
	}

	/// <summary>
	///     Determines whether a specified object is valid. (Overrides <see cref="M:System.ComponentModel.DataAnnotations.ValidationAttribute.IsValid(System.Object)" />)
	/// </summary>
	/// <remarks>
	///     This method returns <c>true</c> if the <paramref name="value" /> is null.  
	///     It is assumed the <see cref="T:System.ComponentModel.DataAnnotations.RequiredAttribute" /> is used if the value may not be null.
	/// </remarks>
	/// <param name="value">The object to validate.</param>
	/// <returns><c>true</c> if the value is null or less than or equal to the specified maximum length, otherwise <c>false</c></returns>
	/// <exception cref="T:System.InvalidOperationException">Length is zero or less than negative one.</exception>
	public override bool IsValid(object value)
	{
		EnsureLegalLengths();
		int num = 0;
		if (value == null)
		{
			return true;
		}
		num = ((!(value is string text)) ? ((Array)value).Length : text.Length);
		if (-1 != Length)
		{
			return num <= Length;
		}
		return true;
	}

	/// <summary>
	///     Applies formatting to a specified error message. (Overrides <see cref="M:System.ComponentModel.DataAnnotations.ValidationAttribute.FormatErrorMessage(System.String)" />)
	/// </summary>
	/// <param name="name">The name to include in the formatted string.</param>
	/// <returns>A localized string to describe the maximum acceptable length.</returns>
	public override string FormatErrorMessage(string name)
	{
		return string.Format(CultureInfo.CurrentCulture, base.ErrorMessageString, new object[2] { name, Length });
	}

	/// <summary>
	///     Checks that Length has a legal value.  Throws InvalidOperationException if not.
	/// </summary>
	private void EnsureLegalLengths()
	{
		if (Length == 0 || Length < -1)
		{
			throw Error.MaxLengthAttribute_InvalidMaxLength();
		}
	}
}
