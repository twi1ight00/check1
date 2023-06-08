using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Adapter;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Base.Application.DTO;

/// <summary>
/// DTO对象扩展类，扩展 DTO列表对象
/// </summary>
public static class DTOExtensions
{
	/// <summary>
	/// DTO转化为POCO
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="items"></param>
	/// <returns></returns>
	public static List<TEntity> AdaptAsEntity<TEntity>(this IEnumerable<IDTOBase> items) where TEntity : Entity, new()
	{
		if (items != null && items.Count() > 0)
		{
			ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
			return adapter.Adapt<List<TEntity>>(items);
		}
		return new List<TEntity>();
	}

	/// <summary>
	/// 转化为Json字符串
	/// </summary>
	/// <param name="items"></param>
	/// <returns></returns>
	public static string ToJson(this IEnumerable<IDTOBase> items)
	{
		return items.JsonSerialize();
	}
}
