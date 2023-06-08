namespace Enyim.Caching.Memcached;

/// <summary>
/// Provides a way for custom initalization of the providers (locators, transcoders, key transformers)
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IProviderFactory<T> : IProvider
{
	T Create();
}
