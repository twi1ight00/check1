using System.Linq.Expressions;

namespace System.Linq.Dynamic;

/// <summary>
/// DynamicOrdering
/// </summary>
internal class DynamicOrdering
{
	public Expression Selector;

	public bool Ascending;
}
