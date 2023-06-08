using System;
using System.Collections.Generic;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Base.Domain;

/// <summary>
/// 实体架构类
/// </summary>
public class EntitySchema
{
	/// <summary>
	/// 实体属性类
	/// </summary>
	public class EntityProperty
	{
		/// <summary>
		/// 实体属性名称
		/// </summary>
		private string propertyName;

		/// <summary>
		/// 实体属性类型
		/// </summary>
		private Type propertyType;

		/// <summary>
		/// 实体属性是否可以为空
		/// </summary>
		private bool nullable;

		/// <summary>
		/// 获取或者设置实体属性名称
		/// </summary>
		public string PropertyName
		{
			get
			{
				return propertyName;
			}
			set
			{
				propertyName = value.GuardNotNullAndEmpty("Property Name");
			}
		}

		/// <summary>
		/// 获取或者设置实体属性类型
		/// </summary>
		public Type PropertyType
		{
			get
			{
				return propertyType;
			}
			set
			{
				propertyType = value.GuardNotNull("Property Type");
			}
		}

		/// <summary>
		/// 获取或者设置实体属性是否可以为空
		/// </summary>
		public bool Nullable
		{
			get
			{
				return nullable;
			}
			set
			{
				nullable = value;
			}
		}

		/// <summary>
		/// 初始化默认的实体属性类
		/// </summary>
		public EntityProperty()
		{
			propertyName = string.Empty;
			PropertyType = typeof(object);
			nullable = true;
		}

		/// <summary>
		/// 初始化实体属性类型
		/// </summary>
		/// <param name="propertyName">实体属性名称</param>
		public EntityProperty(string propertyName)
			: this()
		{
			PropertyName = propertyName;
		}

		/// <summary>
		/// 初始化实体属性类型
		/// </summary>
		/// <param name="propertyName">实体属性名称</param>
		/// <param name="propertyType">实体属性类型</param>
		public EntityProperty(string propertyName, Type propertyType)
			: this()
		{
			PropertyName = propertyName;
			PropertyType = propertyType;
		}

		/// <summary>
		/// 初始化实体属性类型
		/// </summary>
		/// <param name="propertyName">实体属性名称</param>
		/// <param name="propertyType">实体属性类型</param>
		/// <param name="nullable">实体属性是否可以为空</param>
		public EntityProperty(string propertyName, Type propertyType, bool nullable)
			: this()
		{
			PropertyName = propertyName;
			PropertyType = propertyType;
			Nullable = nullable;
		}

		/// <summary>
		/// 获取实体属性的字符串表示。
		/// </summary>
		/// <returns>实体属性的字符串表示</returns>
		/// <remarks>实体属性的名称作为实体属性的字符串表示。</remarks>
		public override string ToString()
		{
			return PropertyName;
		}

		/// <summary>
		/// 实体属性名称字符串到实体属性对象的隐式转换以
		/// </summary>
		/// <param name="propertyName">实体属性姓名</param>
		/// <returns>实体属性对象</returns>
		public static implicit operator EntityProperty(string propertyName)
		{
			return new EntityProperty(propertyName.GuardNotNullAndEmpty("Property Name"));
		}
	}

	/// <summary>
	/// 默认实体架构
	/// </summary>
	private static EntitySchema defaultSchema = new EntitySchema();

	/// <summary>
	/// 实体属性缓存
	/// </summary>
	private Dictionary<string, EntityProperty> properties;

	/// <summary>
	/// 获取默认实体架构
	/// </summary>
	public static EntitySchema Default => defaultSchema;

	/// <summary>
	/// 获取Creator属性
	/// </summary>
	public EntityProperty Creator
	{
		get
		{
			return properties["Creator"];
		}
		set
		{
			properties["Creator"] = value.GuardNotNull("Creator");
		}
	}

	/// <summary>
	/// 获取CreateTime属性
	/// </summary>
	public EntityProperty CreateTime
	{
		get
		{
			return properties["CreateTime"];
		}
		set
		{
			properties["CreateTime"] = value.GuardNotNull("CreateTime");
		}
	}

	/// <summary>
	/// 获取Modifier属性
	/// </summary>
	public EntityProperty Modifier
	{
		get
		{
			return properties["Modifier"];
		}
		set
		{
			properties["Modifier"] = value.GuardNotNull("Modifier");
		}
	}

	/// <summary>
	/// 获取ModifyTime属性
	/// </summary>
	public EntityProperty ModifyTime
	{
		get
		{
			return properties["ModifyTime"];
		}
		set
		{
			properties["ModifyTime"] = value.GuardNotNull("ModifyTime");
		}
	}

	/// <summary>
	/// 获取IsDel属性
	/// </summary>
	public EntityProperty IsDel
	{
		get
		{
			return properties["IsDel"];
		}
		set
		{
			properties["IsDel"] = value.GuardNotNull("IsDel");
		}
	}

	/// <summary>
	/// 默认构造函数
	/// </summary>
	public EntitySchema()
	{
		properties = new Dictionary<string, EntityProperty>();
		properties.Add("Creator", new EntityProperty
		{
			PropertyName = "CREATOR",
			PropertyType = typeof(string)
		});
		properties.Add("CreateTime", new EntityProperty
		{
			PropertyName = "CREATETIME",
			PropertyType = typeof(DateTime)
		});
		properties.Add("Modifier", new EntityProperty
		{
			PropertyName = "MODIFIER",
			PropertyType = typeof(string)
		});
		properties.Add("ModifyTime", new EntityProperty
		{
			PropertyName = "MODIFYTIME",
			PropertyType = typeof(DateTime)
		});
		properties.Add("IsDel", new EntityProperty
		{
			PropertyName = "ISDEL",
			PropertyType = typeof(decimal)
		});
	}
}
