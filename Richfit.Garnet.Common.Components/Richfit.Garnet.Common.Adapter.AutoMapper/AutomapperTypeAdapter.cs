using AutoMapper;

namespace Richfit.Garnet.Common.Adapter.AutoMapper;

/// <summary>
/// Automapper type adapter implementation
/// </summary>
public class AutomapperTypeAdapter : ITypeAdapter
{
	/// <summary>
	/// Adapt a source object to an instance of type 
	/// </summary>
	/// <typeparam name="TSource">Type of source item</typeparam>
	/// <typeparam name="TTarget">Type of target item</typeparam>
	/// <param name="source">Instance to adapt</param>
	/// <returns><paramref name="source" /> mapped to <typeparamref name="TTarget" /></returns>
	public TTarget Adapt<TSource, TTarget>(TSource source) where TSource : class where TTarget : class, new()
	{
		return Mapper.Map<TSource, TTarget>(source);
	}

	/// <summary>
	/// Adapt a source object to an instnace of type 
	/// </summary>
	/// <typeparam name="TTarget">Type of target item</typeparam>
	/// <param name="source">Instance to adapt</param>
	/// <returns><paramref name="source" /> mapped to <typeparamref name="TTarget" /></returns>
	public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
	{
		return Mapper.Map<TTarget>(source);
	}
}
