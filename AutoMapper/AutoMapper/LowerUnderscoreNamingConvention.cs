using System.Text.RegularExpressions;

namespace AutoMapper;

public class LowerUnderscoreNamingConvention : INamingConvention
{
	private readonly Regex _splittingExpression = new Regex("[\\p{Ll}0-9]+(?=_?)");

	public Regex SplittingExpression => _splittingExpression;

	public string SeparatorCharacter => "_";
}
