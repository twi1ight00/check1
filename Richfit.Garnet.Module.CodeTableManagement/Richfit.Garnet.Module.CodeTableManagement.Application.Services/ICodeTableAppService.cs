using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.CodeTableManagement.Application.DTO;

namespace Richfit.Garnet.Module.CodeTableManagement.Application.Services;

/// <summary>
/// 码表接口
/// </summary>
public interface ICodeTableAppService
{
	/// <summary>
	/// 新增码表信息
	/// </summary>
	/// <param name="codeTableAdapterDTO">CodeTableAdapterDTO</param>
	/// <returns></returns>
	CodeTableDTO AddCodeTable(CodeTableAdapterDTO codeTableAdapterDTO);

	/// <summary>
	/// 更新码表信息
	/// </summary>
	/// <param name="codeTableAdapterDTO">码表信息DTO对象</param>
	/// <returns>返回修改后的码表DTO对象</returns>
	void UpdateCodeTable(CodeTableAdapterDTO codeTableAdapterDTO);

	/// <summary>
	/// 删除码表信息
	/// </summary>
	/// <param name="codeTableIds">码表主键ID(形式为用','隔开的字符串)</param>
	void RemoveCodeTable(string codeTableIds);

	/// <summary>
	/// 启用码表信息
	/// </summary>
	/// <param name="codeTableIds">码表主键ID(形式为用','隔开的字符串)</param>
	void EnableCodeTable(string codeTableIds);

	/// <summary>
	/// 禁用码表信息
	/// </summary>
	/// <param name="codeTableIds">码表主键ID(形式为用','隔开的字符串)</param>
	void DisableCodeTable(string codeTableIds);

	/// <summary>
	/// 根据查询条件SQL查找码表信息，分页
	/// </summary>
	/// <returns>返回包含码表信息的QueryResult</returns>
	QueryResult<CodeTableListDTO> QueryCodeTableList();

	/// <summary>
	/// 获得所有可用的码表信息
	/// </summary>
	/// <returns></returns>
	IList<CodeTableDTO> GetAllCodeTable();

	/// <summary>
	/// 根据父节点获取一级子节点
	/// </summary>
	/// <param name="parentId"></param>
	/// <returns></returns>
	IList<CodeTableDTO> GetFirstLevelChild(Guid? parentId);

	/// <summary>
	/// 获得系统固化Code编码的码表信息
	/// </summary>
	/// <returns></returns>
	IList<CodeTableDTO> GetSystemCodeTable();

	/// <summary>
	/// 根据CODE_ID获取码值
	/// </summary>
	/// <returns></returns>
	IList<CodeTableNameDTO> GetCodeTableName(string CodeTableId);
}
