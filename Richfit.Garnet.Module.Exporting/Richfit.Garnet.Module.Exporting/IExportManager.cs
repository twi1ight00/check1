using System;
using System.Collections.Generic;
using System.IO;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Exporting;

/// <summary>
/// 导出管理器接口
/// </summary>
public interface IExportManager : IDisposableObject, IDisposable
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
	/// 获取指定名称的导出器
	/// </summary>
	/// <param name="name">导出器名称</param>
	/// <returns>指定名称的导出器，如果不存在指定名称的导出器，返回null</returns>
	IExporter GetExporter(string name);

	/// <summary>
	/// 获取指定类型的第一个导出器
	/// </summary>
	/// <typeparam name="T">导出器类型</typeparam>
	/// <returns>指定类型的第一个导出器，如果不存在指定类型的导出器，返回null</returns>
	T GetExporter<T>() where T : IExporter;

	/// <summary>
	/// 获取指定类型和名称的导出器
	/// </summary>
	/// <typeparam name="T">导出器类型</typeparam>
	/// <param name="name">导出器名称</param>
	/// <returns>匹配的导出器，如果没有匹配的导出器，返回null</returns>
	T GetExporter<T>(string name) where T : IExporter;

	/// <summary>
	/// 清空全部导出器
	/// </summary>
	void ClearExporters();

	/// <summary>
	/// 通用导出EXCEL
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="dataGridColumn">列表头</param>
	/// <param name="resultDto">导出的数据</param>
	/// <param name="excelName">excel名字</param>
	/// <param name="strFrontTranslates">前端翻译，格式为项和项之间分号分隔，项里面逗号分隔，如IS_MERGE,0,否;IS_MERGE,1,是</param>
	/// <param name="strSqlTranslate">Sql翻译,格式为项和项之间分号分隔，项里面逗号分隔,如ORG_ID,ORG_NAME;CARD_TYPE,CARD_TYPE_NAME</param>
	/// <returns>Stream流</returns>
	Stream ExportCommonExcel<T>(string dataGridColumn, List<T> resultDto, string excelName, string strFrontTranslates = "", string strSqlTranslate = "") where T : DTOBase;
}
