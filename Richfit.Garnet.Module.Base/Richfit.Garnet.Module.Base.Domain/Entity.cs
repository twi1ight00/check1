using System;
using Richfit.Garnet.Common.Adapter;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Base.Infrastructure.TimeZone;

namespace Richfit.Garnet.Module.Base.Domain;

/// <summary>
/// 数据实体(POCO)基类
/// </summary>
public abstract class Entity
{
	/// <summary>
	/// 获取或者设置是否做过日期时区处理的标识
	/// </summary>
	/// <value>如果当前实体已经进行过时区处理则为true，否则为false</value>
	private bool HasZoneHandled { get; set; }

	/// <summary>
	/// 检测当前实体与指定的目标实体是否发生并发冲突。
	/// </summary>
	/// <param name="targetEntity">与当前实体进行比较的目标实体</param>
	/// <param name="ModifyTimePropertyName">实体修改时间属性的名称。通过对这个属性值的比较来确定两个对象的状态是否一致。</param>
	/// <returns>如果发生更新并发冲突返回true，否则返回false。</returns>
	/// <remarks>
	/// 本方法使用对象上“修改时间”属性来确定当前对象和目标对象是否具有相同的状态，“修改时间”属性名称由参数 <paramref name="ModifyTimePropertyName" /> 指定。
	/// 如果两个对象的“修改时间”匹配（毫秒数相同），则认为两个对象没有并发冲突，状态一致。
	/// </remarks>
	public bool IsUpdateConflict(Entity targetEntity, string ModifyTimePropertyName = "MODIFYTIME")
	{
		if (ConfigurationManager.System.Settings.GetSetting("IsUpdateConflictCheck", defaultValue: false))
		{
			DateTime? thisUpdateTime = this.GetPropertyValue<DateTime?>(ModifyTimePropertyName);
			DateTime? entityUpdateTime = targetEntity.GetPropertyValue<DateTime?>(ModifyTimePropertyName);
			if (thisUpdateTime.IsNotNull() && entityUpdateTime.IsNotNull())
			{
				return (thisUpdateTime.Value - entityUpdateTime.Value).TotalMilliseconds.Abs() > 0.0;
			}
			throw new InvalidOperationException("No modify time.");
		}
		return false;
	}

	/// <summary>
	/// 设置实体新增时状态值
	/// </summary>
	/// <param name="schema">实体架构定义</param>
	public void SetAdditionStatus(EntitySchema schema = null)
	{
		if (schema.IsNull())
		{
			schema = EntitySchema.Default;
		}
		this.SetPropertyValue(schema.CreateTime.PropertyName, TimeZoneHelper.Now, ignoreCase: false, ignoreMissing: true);
		this.SetPropertyValue(schema.ModifyTime.PropertyName, TimeZoneHelper.Now, ignoreCase: false, ignoreMissing: true);
		if (SessionContext.UserInfo != null)
		{
			this.SetPropertyValue(schema.Creator.PropertyName, SessionContext.UserInfo.UserID, ignoreCase: false, ignoreMissing: true);
			this.SetPropertyValue(schema.Modifier.PropertyName, SessionContext.UserInfo.UserID, ignoreCase: false, ignoreMissing: true);
		}
		this.SetPropertyValue(schema.IsDel.PropertyName, 0, ignoreCase: false, ignoreMissing: true);
	}

	/// <summary>
	/// 设置实体更新时的状态值
	/// </summary>
	/// <param name="schema">实体架构定义</param>
	public void SetUpdateStatus(EntitySchema schema = null)
	{
		if (schema.IsNull())
		{
			schema = EntitySchema.Default;
		}
		this.SetPropertyValue(schema.ModifyTime.PropertyName, TimeZoneHelper.Now, ignoreCase: false, ignoreMissing: true);
		if (SessionContext.UserInfo != null)
		{
			this.SetPropertyValue(schema.Modifier.PropertyName, SessionContext.UserInfo.UserID, ignoreCase: false, ignoreMissing: true);
		}
	}

	/// <summary>
	/// 将当前实体转换为指定类型的DTO
	/// </summary>
	/// <typeparam name="TDTO">转换的目标DTO类型</typeparam>
	/// <returns>转换后的DTO对象</returns>
	public TDTO AdaptAsDTO<TDTO>() where TDTO : DTOBase, new()
	{
		ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
		return adapter.Adapt<TDTO>(this);
	}

	/// <summary>
	/// 转换日期数据为UTC时间
	/// </summary>
	internal void DateTimeToUtc()
	{
		if (!HasZoneHandled)
		{
			TimeZoneHelper.LocalTimeToUtc(this);
			HasZoneHandled = true;
		}
	}

	/// <summary>
	/// 转换日期数据为本地时间（指定时区的时间）
	/// </summary>
	internal void DateTimeToLocal()
	{
		if (!HasZoneHandled)
		{
			TimeZoneHelper.UtcTimeToLocal(this);
			HasZoneHandled = true;
		}
	}
}
