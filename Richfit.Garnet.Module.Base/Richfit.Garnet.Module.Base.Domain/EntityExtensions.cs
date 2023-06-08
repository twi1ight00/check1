using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Adapter;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Base.Domain;

/// <summary>
/// <see cref="T:Richfit.Garnet.Module.Base.Domain.Entity">数据实体(POCO)基类</see>扩展方法类
/// </summary>
public static class EntityExtensions
{
	/// <summary>
	/// 将数据实体（POCO）序列转换为数据对象（DTO）序列
	/// </summary>
	/// <typeparam name="TDTO">转换的目标数据对象（DTO）类型</typeparam>
	/// <param name="entities">待转换的数据实体序列</param>
	/// <returns>转换后的数据对象（DTO）列表</returns>
	public static List<TDTO> AdaptAsDTO<TDTO>(this IEnumerable<Entity> entities) where TDTO : DTOBase, new()
	{
		if (entities != null && entities.Any())
		{
			ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
			return adapter.Adapt<List<TDTO>>(entities);
		}
		return new List<TDTO>();
	}
}
