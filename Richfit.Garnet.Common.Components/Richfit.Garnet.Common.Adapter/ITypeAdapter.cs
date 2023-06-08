namespace Richfit.Garnet.Common.Adapter;

/// <summary>
/// Base contract for map dto to aggregate or aggregate to dto.
/// <remarks>
/// This is a  contract for work with "auto" mappers ( automapper,emitmapper,valueinjecter...)
/// or adhoc mappers
/// </remarks>
/// </summary>
public interface ITypeAdapter
{
	/// <summary>
	/// Adapt a source object to an instance of type 
	/// </summary>
	/// <typeparam name="TSource">Type of source item</typeparam>
	/// <typeparam name="TTarget">Type of target item</typeparam>
	/// <param name="source">Instance to adapt</param>
	/// <returns><paramref name="source" /> mapped to <typeparamref name="TTarget" /></returns>
	TTarget Adapt<TSource, TTarget>(TSource source) where TSource : class where TTarget : class, new();

	/// <summary>
	/// Adapt a source object to an instnace of type 
	/// </summary>
	/// <typeparam name="TTarget">Type of target item</typeparam>
	/// <param name="source">Instance to adapt</param>
	/// <returns><paramref name="source" /> mapped to <typeparamref name="TTarget" /></returns>
	TTarget Adapt<TTarget>(object source) where TTarget : class, new();
}
