using System;
using System.Linq;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions;

public class ProjectionExpression<TSource> : IProjectionExpression
{
	private readonly IQueryable<TSource> _source;

	private readonly IMappingEngine _mappingEngine;

	public ProjectionExpression(IQueryable<TSource> source, IMappingEngine mappingEngine)
	{
		_source = source;
		_mappingEngine = mappingEngine;
	}

	public IQueryable<TResult> To<TResult>()
	{
		Expression<Func<TSource, TResult>> selector = _mappingEngine.CreateMapExpression<TSource, TResult>();
		return _source.Select(selector);
	}
}
