using System.Linq;

namespace AutoMapper.QueryableExtensions;

/// <summary>
/// Continuation to execute projection
/// </summary>
public interface IProjectionExpression
{
	/// <summary>
	/// Projects the source type to the destination type given the mapping configuration
	/// </summary>
	/// <typeparam name="TResult">Destination type to map to</typeparam>
	/// <returns>Queryable result, use queryable extension methods to project and execute result</returns>
	IQueryable<TResult> To<TResult>();
}
