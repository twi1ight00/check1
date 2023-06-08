using System.Text.RegularExpressions;

namespace AutoMapper;

public class PascalCaseNamingConvention : INamingConvention
{
	private readonly Regex _splittingExpression = new Regex("(\\p{Lu}+(?=$|\\p{Lu}[\\p{Ll}0-9])|\\p{Lu}?[\\p{Ll}0-9]+)");

	public Regex SplittingExpression => _splittingExpression;

	public string SeparatorCharacter => string.Empty;
}
