using Enyim.Caching.Memcached;

namespace Enyim.Caching.Configuration;

public class OptionalFactoryElement<TResult> : FactoryElement<TResult> where TResult : class, IProvider
{
	protected override bool IsOptional => true;
}
