using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Adapter;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Validator;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Base.Application.DTO;

/// <summary>
/// DTO基类
/// </summary>
[Serializable]
public class DTOBase : IDTOBase
{
	/// <summary>
	/// 分页索引
	/// </summary>
	private int pageIndex = 1;

	/// <summary>
	/// 最大分页数量
	/// </summary>
	private int pageSize = 9999;

	/// <summary>
	/// 排序项目
	/// </summary>
	private string sortBy = string.Empty;

	/// <summary>
	/// 排序顺序
	/// </summary>
	private string sortOrder = string.Empty;

	private DateTime? endDate;

	/// <summary>
	/// 标识DTO的状态，参照RecordState枚举定义
	/// </summary>
	public RecordState RecordState { get; set; }

	/// <summary>
	///
	/// </summary>
	public int StartRow => pageIndex * pageSize + 1;

	/// <summary>
	///
	/// </summary>
	public int EndRow => (pageIndex + 1) * pageSize;

	/// <summary>
	/// 索引页.缺省1
	/// </summary>
	public int PageIndex
	{
		get
		{
			return pageIndex;
		}
		set
		{
			pageIndex = value;
		}
	}

	/// <summary>
	/// 单页记录数.缺省9999
	/// </summary>
	public int PageSize
	{
		get
		{
			return pageSize;
		}
		set
		{
			pageSize = value;
		}
	}

	/// <summary>
	/// 排序属性，对象查询时候必须与POCO对象属性名称相同，SQL查询时候必须与字段名称相同，多个属性逗号分割
	/// </summary>
	public string SortBy
	{
		get
		{
			return sortBy;
		}
		set
		{
			sortBy = value;
		}
	}

	/// <summary>
	/// 对应排序属性的排序顺序，多个逗号分割，只能是asc，desc形式，参考QuerySortOrder常量定义类
	/// </summary>
	public string SortOrder
	{
		get
		{
			return sortOrder;
		}
		set
		{
			sortOrder = value;
		}
	}

	public DateTime? StartDate { get; set; }

	public DateTime? EndDate
	{
		get
		{
			return endDate;
		}
		set
		{
			if (!value.HasValue)
			{
				endDate = value;
			}
			else
			{
				endDate = value.Value.AddDays(1.0);
			}
		}
	}

	public bool IsCreate { get; set; }

	public int SearchType { get; set; }

	/// <summary>
	/// 检测DTO中的数据是否有效
	/// </summary>
	/// <returns></returns>
	public bool IsValid()
	{
		IValidator validator = ValidatorFactory.CreateValidator();
		return validator.IsValid(this);
	}

	/// <summary>
	/// 获取DTO检测异常消息
	/// </summary>
	/// <returns></returns>
	public IEnumerable<string> GetInvalidMessages()
	{
		IValidator validator = ValidatorFactory.CreateValidator();
		return validator.GetInvalidMessages(this);
	}

	/// <summary>
	/// 对象序列化为Json字符串
	/// </summary>
	/// <returns></returns>
	public string ToJson()
	{
		return this.JsonSerialize();
	}

	/// <summary>
	/// DTO转化为POCO
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <returns></returns>
	public TEntity AdaptAsEntity<TEntity>() where TEntity : Entity, new()
	{
		ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
		return adapter.Adapt<TEntity>(this);
	}

	public void Encrypt()
	{
		PropertyInfo[] properties = GetType().GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (!propertyInfo.IsDefined(typeof(EncryptAttribute), inherit: false))
			{
				continue;
			}
			object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(EncryptAttribute), inherit: false);
			EncryptAttribute encryptAttribute = (EncryptAttribute)customAttributes[0];
			if (!encryptAttribute.IsEncrypt || !(propertyInfo.GetSetMethod() != null))
			{
				continue;
			}
			if (propertyInfo.PropertyType.Name == "String")
			{
				string fromValue2 = (string)PropertyInfoExtensions.GetValue(propertyInfo, this);
				if (string.IsNullOrEmpty(fromValue2))
				{
					propertyInfo.SetValue(this, null, null);
				}
				else
				{
					propertyInfo.SetValue(this, fromValue2.EncryptText().Base64Encode(), null);
				}
			}
			else if (propertyInfo.PropertyType.Name == "Decimal")
			{
				decimal fromValue = (decimal)PropertyInfoExtensions.GetValue(propertyInfo, this);
				bool flag = 0 == 0;
				propertyInfo.SetValue(this, fromValue.EncryptDecimal(), null);
			}
		}
	}

	public void Decrypt()
	{
		PropertyInfo[] properties = GetType().GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (!propertyInfo.IsDefined(typeof(EncryptAttribute), inherit: false))
			{
				continue;
			}
			object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(EncryptAttribute), inherit: false);
			EncryptAttribute encryptAttribute = (EncryptAttribute)customAttributes[0];
			if (!encryptAttribute.IsEncrypt || !(propertyInfo.GetSetMethod() != null))
			{
				continue;
			}
			if (propertyInfo.PropertyType.Name == "String")
			{
				string fromValue2 = (string)PropertyInfoExtensions.GetValue(propertyInfo, this);
				if (string.IsNullOrEmpty(fromValue2))
				{
					propertyInfo.SetValue(this, null, null);
				}
				else
				{
					propertyInfo.SetValue(this, fromValue2.Base64Decode().DecryptText(), null);
				}
			}
			else if (propertyInfo.PropertyType.Name == "Decimal")
			{
				decimal fromValue = (decimal)PropertyInfoExtensions.GetValue(propertyInfo, this);
				bool flag = 0 == 0;
				propertyInfo.SetValue(this, fromValue.DecryptDecimal(), null);
			}
		}
	}

	/// <summary>
	/// 把前端传递的Json数据转成相应的DTO
	/// </summary>
	/// <typeparam name="T">DTO</typeparam>
	/// <param name="jsonText">Json数据</param>
	/// <returns></returns>
	public static T DeserializeFromJson<T>(string jsonText) where T : IDTOBase
	{
		return jsonText.JsonDeserialize<T>(new JsonConverter[0]);
	}

	/// <summary>
	/// 把前端传递的Json数据转成相应的DTO列表
	/// </summary>
	/// <typeparam name="T">DTO</typeparam>
	/// <param name="jsonText">Json数据</param>
	/// <returns></returns>
	public static IList<T> DeserializeListFromJson<T>(string jsonText) where T : IDTOBase
	{
		return jsonText.JsonDeserializeToList<T>(new JsonConverter[0]);
	}
}
