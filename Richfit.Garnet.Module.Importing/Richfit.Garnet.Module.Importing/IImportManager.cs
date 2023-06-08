using System;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Module.Importing;

/// <summary>
/// 导入管理器接口
/// </summary>
public interface IImportManager : IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取管理器名称
	/// </summary>
	string Name { get; }

	/// <summary>
	/// 同步对象
	/// </summary>
	ISyncLocker SyncRoot { get; }

	/// <summary>
	/// 获取指定名称的导入器
	/// </summary>
	/// <param name="name">导入器名称</param>
	/// <returns>指定名称的导入器，如果不存在指定名称的导入器，返回null</returns>
	IImporter GetImporter(string name);

	/// <summary>
	/// 获取指定类型的第一个导入器
	/// </summary>
	/// <typeparam name="T">导入器类型</typeparam>
	/// <returns>指定类型的第一个导入器，如果不存在指定类型的导入器，返回null</returns>
	T GetImporter<T>() where T : IImporter;

	/// <summary>
	/// 获取指定类型和名称的导入器
	/// </summary>
	/// <typeparam name="T">导入器类型</typeparam>
	/// <param name="name">导入器名称</param>
	/// <returns>匹配的导入器，如果没有匹配的导入器，返回null</returns>
	T GetImporter<T>(string name) where T : IImporter;

	/// <summary>
	/// 清空全部导入器
	/// </summary>
	void ClearImporters();
}
