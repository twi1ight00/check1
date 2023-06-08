using System.Collections.Generic;
using System.IO;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Exporting;

public interface ICommonExportcsService
{
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
