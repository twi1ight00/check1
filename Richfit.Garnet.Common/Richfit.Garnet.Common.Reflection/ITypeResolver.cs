using System;

namespace Richfit.Garnet.Common.Reflection;

/// <summary>
/// 类型解析器接口
/// </summary>
public interface ITypeResolver : IDisposable
{
	/// <summary>
	/// 将类型名称或者别名解析为类型对象
	/// </summary>
	/// <param name="name">类型名称或者别名</param>
	/// <returns>解析出的类型对象，如果无法解析返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">类型名称或者别名为空。</exception>
	Type ResolveType(string name);

	/// <summary>
	/// 将类型名称或者别名解析为类型对象
	/// </summary>
	/// <param name="name">类型名称或者别名</param>
	/// <param name="throwError">无法解析类型时是否抛出异常</param>
	/// <returns>解析出的类型对象，或者无法解析时，根据 <paramref name="throwError" /> 的设置返回空或者抛出异常。</returns>
	/// <exception cref="T:System.ArgumentNullException">类型名称或者别名为空。</exception>
	/// <exception cref="T:System.Exception">当 <paramref name="throwError" /> 为true时，无法解析类型名称或者别名。</exception>
	Type ResolveType(string name, bool throwError);

	/// <summary>
	/// 将类型名称或者别名解析为类型对象
	/// </summary>
	/// <param name="name">类型名称或者别名</param>
	/// <param name="throwError">无法解析类型时是否抛出异常</param>
	/// <param name="ignoreCase">解析类型名时是否区分大小写</param>
	/// <returns>解析出的类型对象，或者无法解析时，根据 <paramref name="throwError" /> 的设置返回空或者抛出异常。</returns>
	/// <exception cref="T:System.ArgumentNullException">类型名称或者别名为空。</exception>
	/// <exception cref="T:System.Exception">当 <paramref name="throwError" /> 为true时，无法解析类型名称或者别名。</exception>
	Type ResolveType(string name, bool throwError, bool ignoreCase);
}
