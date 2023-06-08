using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 基于命名值的配置源
/// </summary>
[ConfigurationSourceMapping(typeof(SettingsConfigurationSource))]
public interface ISettingsConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable, IEnumerable<KeyValuePair<string, object>>, IEnumerable
{
	/// <summary>
	/// 获取或者设置配置文本
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 获取或者设置指定名称的命名值
	/// </summary>
	/// <param name="name">命名值的名称</param>
	/// <returns>命名值</returns>
	object this[string name] { get; set; }

	/// <summary>
	/// 获取命名值的数量
	/// </summary>
	/// <returns>设置数量</returns>
	int GetSettingCount();

	/// <summary>
	/// 获取命名字符串的列表
	/// </summary>
	/// <returns>命名值字典</returns>
	Dictionary<string, string> GetValues();

	/// <summary>
	/// 获取指定名称的命名字符串，如果指定名称的命名字符串不存在则返回null
	/// </summary>
	/// <param name="name">命名字符串的名称</param>
	/// <returns>命名字符串</returns>
	string GetValue(string name);

	/// <summary>
	/// 设置指定名称的命名字符串，如果设置的命名字符串为null，则转换为空字符串
	/// </summary>
	/// <param name="name">命名字符串的名称</param>
	/// <param name="value">设置的命名字符串</param>
	/// <returns>如果设置成功返回true，否则返回false</returns>
	bool SetValue(string name, string value);

	/// <summary>
	/// 添加指定名称的命名字符串，如果设置的命名字符串为null，则转换为空字符值
	/// </summary>
	/// <param name="name">命名字符串的名称</param>
	/// <param name="value">设置的命名字符串</param>
	/// <returns>如果设置成功返回true，否则返回false</returns>
	bool AddValue(string name, string value);

	/// <summary>
	/// 获取命名值的列表
	/// </summary>
	/// <returns>命名值字典</returns>
	Dictionary<string, object> GetSettings();

	/// <summary>
	/// 获取指定名称的命名值，如果指定名称的命名值不存在则返回null
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <returns>命名值</returns>
	object GetSetting(string name);

	/// <summary>
	/// 获取指定名称的命名值，如果指定名称的命名值不存在则返回指定的默认值
	/// </summary>
	/// <typeparam name="T">命名值的类型</typeparam>
	/// <param name="name">命名值名称</param>
	/// <param name="defaultValue">命名值的默认值</param>
	/// <returns>命名值</returns>
	T GetSetting<T>(string name, T defaultValue = default(T));

	/// <summary>
	/// 获取指定名称的命名值，如果指定名称的命名值不存在则返回null
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <param name="converter">命名值的转换器</param>
	/// <returns>命名值</returns>
	object GetSetting(string name, Func<string, object> converter);

	/// <summary>
	/// 获取指定名称的命名值，如果指定名称的命名值不存在则返回null
	/// </summary>
	/// <typeparam name="T">命名值</typeparam>
	/// <param name="name">命名值名称</param>
	/// <param name="converter">命名值的转换器</param>
	/// <param name="defaultValue">命名值的默认值</param>
	/// <returns>命名值</returns>
	T GetSetting<T>(string name, Func<string, T> converter, T defaultValue = default(T));

	/// <summary>
	/// 获取指定名称的命名值的类型
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <returns>命名值的类型</returns>
	Type GetSettingType(string name);

	/// <summary>
	/// 获取指定名称的命名值的类型转换器
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <returns>命名值的类型转换器</returns>
	TypeConverter GetSettingConverter(string name);

	/// <summary>
	/// 设置指定名称的命名值
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <param name="value">设置的命名值</param>
	/// <returns>如果设置成功返回true，否则返回false</returns>
	bool SetSetting(string name, object value);

	/// <summary>
	/// 设置指定名称的命名值
	/// </summary>
	/// <typeparam name="T">命名值类型</typeparam>
	/// <param name="name">命名值名称</param>
	/// <param name="value">设置的命名值</param>
	/// <param name="converter">命名值转换器</param>
	/// <returns>如果设置成功返回true，否则返回false</returns>
	bool SetSetting<T>(string name, T value, Func<T, string> converter = null);

	/// <summary>
	/// 添加指定名称的命名值
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <param name="value">设置的命名值</param>
	/// <param name="type">设置的命名值的类型；如果命名值不为空，则可以省略类型；如果命名值为空，则必须指定命名值类型</param>
	/// <returns>如果设置成功返回true，否则返回false</returns>
	bool AddSetting(string name, object value, Type type = null);

	/// <summary>
	/// 添加指定名称的命名值
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <param name="value">设置的命名值</param>
	/// <param name="converter">设置的命名值的类型转换器，命名值和字符串之间的相互转换</param>
	/// <returns>如果设置成功返回true，否则返回false</returns>
	bool AddSetting(string name, object value, TypeConverter converter);

	/// <summary>
	/// 移除指定名称的命名值
	/// </summary>
	/// <param name="name">命名值的名称</param>
	/// <returns>如果删除成功返回true，否则返回false</returns>
	bool RemoveSetting(string name);

	/// <summary>
	/// 是否包含指定名称的命名值
	/// </summary>
	/// <param name="name">命名值的名称</param>
	/// <returns>如果包含指定名称的命名值返回true，否则返回false</returns>
	bool ContainsSetting(string name);
}
