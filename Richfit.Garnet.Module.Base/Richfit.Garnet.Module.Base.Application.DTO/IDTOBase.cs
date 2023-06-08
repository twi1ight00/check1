using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Base.Application.DTO;

/// <summary>
/// 数据对象（DTO）接口
/// </summary>
public interface IDTOBase
{
	/// <summary>
	/// 标识DTO的状态，参照RecordState枚举定义
	/// </summary>
	RecordState RecordState { get; set; }

	/// <summary>
	/// 对象验证是否通过
	/// </summary>
	/// <returns></returns>
	bool IsValid();

	/// <summary>
	/// 得到验证不可用的消息提示
	/// </summary>
	/// <returns></returns>
	IEnumerable<string> GetInvalidMessages();

	/// <summary>
	/// 对象Json序列化
	/// </summary>
	/// <returns></returns>
	string ToJson();

	/// <summary>
	/// DTO转化为POCO
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <returns></returns>
	TEntity AdaptAsEntity<TEntity>() where TEntity : Entity, new();

	void Encrypt();

	void Decrypt();
}
/// <summary>
/// 数据对象（DTO）泛型接口
/// </summary>
/// <typeparam name="T">数据对象子表类型</typeparam>
public interface IDTOBase<T> : IDTOBase
{
	/// <summary>
	/// 父对象ID
	/// </summary>
	Guid? PARENT_ID { get; set; }

	/// <summary>
	/// 数据对象ID
	/// </summary>
	Guid? ID { get; set; }

	/// <summary>
	/// 是否已扩展
	/// </summary>
	bool expanded { get; set; }

	/// <summary>
	/// 是否为叶级数据对象
	/// </summary>
	bool leaf { get; set; }

	/// <summary>
	/// 数据子表对象
	/// </summary>
	IList<T> children { get; set; }
}
