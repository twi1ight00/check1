using System;

namespace Richfit.Garnet.Common.Dynamic;

/// <summary>
/// 数据对象接口
/// </summary>
public interface IDataObject
{
	/// <summary>
	/// 获取或者设置指定索引位置的属性的值
	/// </summary>
	/// <param name="propertyOrdinal">属性索引位置</param>
	/// <returns>指定索引位置的属性的值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	object this[int propertyOrdinal] { get; set; }

	/// <summary>
	/// 获取或者设置指定名称属性的值
	/// </summary>
	/// <param name="propertyName">属性值</param>
	/// <returns>指定名称属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException"><paramref name="propertyName" /> 指定的属性不存在。</exception>
	object this[string propertyName] { get; set; }

	/// <summary>
	/// 检测当前数据对象是否包含指定名称的数据属性
	/// </summary>
	/// <param name="propertyName">数据属性名称</param>
	/// <returns>如果指定的数据属性存在返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">数据属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	bool ContainsProperty(string propertyName);

	/// <summary>
	/// 复制当前数据对象
	/// </summary>
	/// <returns>复制的新的数据对象</returns>
	IDataObject Copy();

	/// <summary>
	/// 获取当前数据对象的默认属性值（检索到的第一个属性）
	/// </summary>
	/// <returns>默认属性的值</returns>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	object Get();

	/// <summary>
	/// 获取当前数据对象的默认属性值（检索到的第一个属性）
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <returns>默认属性的值</returns>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	T Get<T>();

	/// <summary>
	/// 获取当前数据对象的指定索引位置的属性的值
	/// </summary>
	/// <param name="propertyOrdinal">属性的位置索引</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	object Get(int propertyOrdinal);

	/// <summary>
	/// 获取当前数据对象的指定索引位置的属性的值
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="propertyOrdinal">属性的位置索引</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	T Get<T>(int propertyOrdinal);

	/// <summary>
	/// 获取当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <param name="propertyName">属性名称</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的名称的属性不存在。</exception>
	object Get(string propertyName);

	/// <summary>
	/// 获取当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="propertyName">属性名称</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的名称的属性不存在。</exception>
	T Get<T>(string propertyName);

	/// <summary>
	/// 获取当前数据对象包含的属性的数量
	/// </summary>
	/// <returns>当前数据对象包含的属性的数量</returns>
	int GetPropertyCount();

	/// <summary>
	/// 获取当前数据对象的默认属性值（检索到的第一个属性）
	/// </summary>
	/// <returns>默认属性的值</returns>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	object GetValue();

	/// <summary>
	/// 获取当前数据对象的默认属性值（检索到的第一个属性）
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <returns>默认属性的值</returns>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	T GetValue<T>();

	/// <summary>
	/// 获取当前数据对象的指定索引位置的属性的值
	/// </summary>
	/// <param name="propertyOrdinal">属性的位置索引</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	object GetValue(int propertyOrdinal);

	/// <summary>
	/// 获取当前数据对象的指定索引位置的属性的值
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="propertyOrdinal">属性的位置索引</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	T GetValue<T>(int propertyOrdinal);

	/// <summary>
	/// 获取当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <param name="propertyName">属性名称</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的名称的属性不存在。</exception>
	object GetValue(string propertyName);

	/// <summary>
	/// 获取当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="propertyName">属性名称</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的名称的属性不存在。</exception>
	T GetValue<T>(string propertyName);

	/// <summary>
	/// 获取当前数据对象的属性值数组，数组值循序和属性顺序相同
	/// </summary>
	/// <returns>属性值数组，如果当前数据对象不包含任何属性，返回空数组。</returns>
	object[] GetValues();

	/// <summary>
	/// 向当前数据对象的默认属性（第一个属性）中加载数据
	/// </summary>
	/// <param name="value">加载的数据</param>
	void LoadValue(object value);

	/// <summary>
	/// 向当前数据对象的指定索引的属性中加载数据
	/// </summary>
	/// <param name="propertyOrdinal">属性的索引位置</param>
	/// <param name="value">加载的数据</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定的属性索引位置 <paramref name="propertyOrdinal" /> 小于0，或者大于属性的最大索引。</exception>
	void LoadValue(int propertyOrdinal, object value);

	/// <summary>
	/// 向当前数据对象的指定名称的属性中加载数据
	/// </summary>
	/// <param name="propertyName">属性的名称</param>
	/// <param name="value">加载的数据</param>
	/// <exception cref="T:System.MissingMemberException">指定名称的属性不存在。</exception>
	void LoadValue(string propertyName, object value);

	/// <summary>
	/// 向当前数据对象的各个属性中加载数据，属性值数组元素的顺序和当前数据对象属性顺序相同
	/// </summary>
	/// <param name="values">属性值数组</param>
	/// <exception cref="T:System.ArgumentNullException">属性值数组为空。</exception>
	/// <exception cref="T:System.ArgumentException">属性值数组 <paramref name="values" /> 的元素数量不等于数据对象的属性数量。</exception>
	void LoadValues(object[] values);

	/// <summary>
	/// 将当前数据对象映射到新的数据对象
	/// </summary>
	/// <param name="propertyMapping">属性映射方法</param>
	/// <returns>映射生成的新数据对象</returns>
	/// <exception cref="T:System.ArgumentNullException">属性处理方法 <paramref name="propertyMapping" /> 为空。</exception>
	IDataObject Map(Func<DataPropertyInfo, DataPropertyInfo> propertyMapping);

	/// <summary>
	/// 将当前数据对象映射到新的数据对象
	/// </summary>
	/// <param name="propertyMapping">属性映射方法</param>
	/// <returns>映射生成的新数据对象</returns>
	/// <exception cref="T:System.ArgumentNullException">属性映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	IDataObject Map(Func<DataPropertyInfo, DataPropertyInfo[]> propertyMapping);

	/// <summary>
	/// 设置当前数据对象的默认属性的值（检索到的第一个属性）
	/// </summary>
	/// <param name="value">设置的默认属性的值</param>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	void Set(object value);

	/// <summary>
	/// 设置当前数据对象的默认属性的值（检索到的第一个属性）
	/// </summary>
	/// <param name="value">设置的默认属性的值</param>
	/// <param name="conversion">属性值转换方法</param>
	/// <exception cref="T:System.ArgumentNullException">属性值转换方法 <paramref name="conversion" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	void Set(object value, Func<object, object> conversion);

	/// <summary>
	/// 设置当前数据对象的指定索引位置的属性值
	/// </summary>
	/// <param name="propertyOrdinal">属性的索引位置</param>
	/// <param name="value">设置的属性的值</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	void Set(int propertyOrdinal, object value);

	/// <summary>
	/// 设置当前数据对象的指定索引位置的属性值
	/// </summary>
	/// <param name="propertyOrdinal">属性的索引位置</param>
	/// <param name="value">设置的属性的值</param>
	/// <param name="conversion">属性值转换方法</param>
	/// <exception cref="T:System.ArgumentNullException">属性值转换方法 <paramref name="conversion" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	void Set(int propertyOrdinal, object value, Func<object, object> conversion);

	/// <summary>
	/// 设置当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <param name="propertyName">设置的属性名称</param>
	/// <param name="value">设置的属性的值</param>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	void Set(string propertyName, object value);

	/// <summary>
	/// 设置当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <param name="propertyName">设置的属性名称</param>
	/// <param name="value">设置的属性的值</param>
	/// <param name="conversion">属性值转换方法</param>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串；或者属性值转换方法 <paramref name="conversion" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	void Set(string propertyName, object value, Func<object, object> conversion);

	/// <summary>
	/// 设置当前数据对象的默认属性的值（检索到的第一个属性）
	/// </summary>
	/// <param name="value">设置的默认属性的值</param>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	void SetValue(object value);

	/// <summary>
	/// 设置当前数据对象的默认属性的值（检索到的第一个属性）
	/// </summary>
	/// <param name="value">设置的默认属性的值</param>
	/// <param name="conversion">属性值转换方法</param>
	/// <exception cref="T:System.ArgumentNullException">属性值转换方法 <paramref name="conversion" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	void SetValue(object value, Func<object, object> conversion);

	/// <summary>
	/// 设置当前数据对象的指定索引位置的属性值
	/// </summary>
	/// <param name="propertyOrdinal">属性的索引位置</param>
	/// <param name="value">设置的属性的值</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	void SetValue(int propertyOrdinal, object value);

	/// <summary>
	/// 设置当前数据对象的指定索引位置的属性值
	/// </summary>
	/// <param name="propertyOrdinal">属性的索引位置</param>
	/// <param name="value">设置的属性的值</param>
	/// <param name="conversion">属性值转换方法</param>
	/// <exception cref="T:System.ArgumentNullException">属性值转换方法 <paramref name="conversion" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	void SetValue(int propertyOrdinal, object value, Func<object, object> conversion);

	/// <summary>
	/// 设置当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <param name="propertyName">设置的属性名称</param>
	/// <param name="value">设置的属性的值</param>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	void SetValue(string propertyName, object value);

	/// <summary>
	/// 设置当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <param name="propertyName">设置的属性名称</param>
	/// <param name="value">设置的属性的值</param>
	/// <param name="conversion">属性值转换方法</param>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串；或者属性值转换方法 <paramref name="conversion" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	void SetValue(string propertyName, object value, Func<object, object> conversion);

	/// <summary>
	/// 设置当前数据对象的属性值数组，数组值循序和属性顺序相同
	/// </summary>
	/// <returns>属性值数组，如果当前数据对象不包含任何属性，返回空数组。</returns>
	void SetValues(object[] values);
}
