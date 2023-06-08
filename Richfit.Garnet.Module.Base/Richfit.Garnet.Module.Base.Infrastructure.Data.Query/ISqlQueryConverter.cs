using System.Collections.Generic;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// SQL语句查询转换器接口
/// </summary>
public interface ISqlQueryConverter
{
	/// <summary>
	/// 根据查询条件列表获取查询条件SQL表述（参数形式）
	/// </summary>
	/// <param name="items">查询条件对象列表</param>
	/// <param name="parameterStartIndex">对应的参数生成的索引起始值，默认是0，即从p0开始生成</param>
	/// <returns>查询条件的SQL表示</returns>
	string GetWhereSqlClause(IList<QueryItem> items, int parameterStartIndex = 0);

	/// <summary>
	/// 根据查询条件列表获取查询条件sql表述（参数形式）
	/// </summary>
	/// <param name="items">查询条件对象列表</param>
	/// <param name="indexOrder">查询条件对象列表中的对象不一定全部参与查询sql条件的生成，可以定义范围，该值表示参与生成的索引及其顺序，如[2,5,1]</param>
	/// <param name="parameterStartIndex">对应的参数生成的索引起始值，默认是0，即从p0开始生成</param> 
	/// <returns>查询条件的SQL表示</returns>
	/// <example>
	/// " and a= @p1" or " and a = :p1"
	/// </example>
	string GetWhereSqlClause(IList<QueryItem> items, int[] indexOrder, int parameterStartIndex = 0);

	/// <summary>
	/// 根据查询条件列表获取查询条件sql表述（参数形式）
	/// </summary>
	/// <param name="items">查询条件对象列表</param>
	/// <param name="beginIndex">查询条件对象列表中的对象不一定全部参与查询sql条件的生成，可以定义范围，该值定义范围的起始索引，默认为0</param>
	/// <param name="length">查询条件对象列表中的对象不一定全部参与查询sql条件的生成，可以定义范围，该值定义范围的长度</param>  
	/// <param name="parameterStartIndex">对应的参数生成的索引起始值，默认是0，即从p0开始生成</param>
	/// <returns>查询条件的SQL表示</returns>
	/// <example>
	/// " and a= @p1" or " and a = :p1"
	/// </example>
	string GetWhereSqlClause(IList<QueryItem> items, int beginIndex, int length, int parameterStartIndex = 0);

	/// <summary>
	/// 将所有查询条件加入Sql查询语句，替换{0}参数，参数从parameterStartIndex参数值开始，并且支持用户自定义语句替换{1}，{2}等空位
	/// </summary>
	/// <param name="sql"></param>
	/// <param name="condition"></param>
	/// <param name="formatParameters"></param>
	/// <param name="parameterStartIndex">对应的参数生成的索引起始值，默认是0，即从p0开始生成</param>
	/// <returns></returns>
	string GetSql(string sql, QueryCondition condition, string[] formatParameters = null, int parameterStartIndex = 0);

	/// <summary>
	/// 根据sql基本配置和查询条件得到附加查询条件后最终执行的sql语句（参数形式）
	/// </summary>
	/// <param name="sql"></param>
	/// <param name="condition"></param>
	/// <param name="parameterStartIndex">对应的参数生成的索引起始值，默认是0，即从p0开始生成</param>
	/// <param name="indexOrder">查询条件对象列表中的对象不一定全部参与查询sql条件的生成，可以定义范围，该值表示参与生成的索引及其顺序，如[2,5,1]</param>
	/// <param name="formatParameters">自定义的Sql字符串格式化参数</param>
	/// <returns></returns>
	string GetSql(string sql, QueryCondition condition, int[] indexOrder, string[] formatParameters = null, int parameterStartIndex = 0);

	/// <summary>
	/// 根据sql基本配置和查询条件得到附加查询条件后最终执行的sql语句（参数形式）
	/// </summary>
	/// <param name="sql"></param>
	/// <param name="condition"></param>
	/// <param name="beginIndex">查询条件对象列表中的对象不一定全部参与查询sql条件的生成，可以定义范围，该值定义范围的起始索引，默认为0</param>
	/// <param name="length">查询条件对象列表中的对象不一定全部参与查询sql条件的生成，可以定义范围，该值定义范围的长度</param>
	/// <param name="formatParameters">自定义的Sql字符串格式化参数</param>
	/// <param name="parameterStartIndex">对应的参数生成的索引起始值，默认是0，即从p0开始生成</param>
	/// <returns></returns>
	string GetSql(string sql, QueryCondition condition, int beginIndex, int length, string[] formatParameters = null, int parameterStartIndex = 0);

	/// <summary>
	/// 将所有查询条件加入Sql查询记录总数语句，替换{0}参数，并且支持用户自定义语句替换{1}，{2}等空位
	/// </summary>
	/// <param name="sql"></param>
	/// <param name="condition"></param>
	/// <param name="formatParameters">自定义的Sql字符串格式化参数</param>
	/// <param name="parameterStartIndex">对应的参数生成的索引起始值，默认是0，即从p0开始生成</param>
	/// <returns></returns>
	string GetTotalCountSql(string sql, QueryCondition condition, string[] formatParameters = null, int parameterStartIndex = 0);

	/// <summary>
	/// 根据sql基本配置和查询条件得到记录总数的sql语句（参数形式）,用于分页时候查询总记录数的情况
	/// </summary>
	/// <param name="sql"></param>
	/// <param name="condition"></param>
	/// <param name="parameterStartIndex">对应的参数生成的索引起始值，默认是0，即从p0开始生成</param>
	/// <param name="indexOrder">查询条件对象列表中的对象不一定全部参与查询sql条件的生成，可以定义范围，该值表示参与生成的索引及其顺序，如[2,5,1]</param>
	/// <param name="formatParameters">自定义的Sql字符串格式化参数</param>
	/// <returns></returns>
	string GetTotalCountSql(string sql, QueryCondition condition, int[] indexOrder, string[] formatParameters = null, int parameterStartIndex = 0);

	/// <summary>
	/// 根据sql基本配置和查询条件得到记录总数的sql语句（参数形式）,用于分页时候查询总记录数的情况
	/// </summary>
	/// <param name="sql"></param>
	/// <param name="condition"></param>
	/// <param name="beginIndex">查询条件对象列表中的对象不一定全部参与查询sql条件的生成，可以定义范围，该值定义范围的起始索引，默认为0</param>
	/// <param name="length">查询条件对象列表中的对象不一定全部参与查询sql条件的生成，可以定义范围，该值定义范围的长度</param>
	/// <param name="formatParameters">自定义的Sql字符串格式化参数</param>
	/// <param name="parameterStartIndex">对应的参数生成的索引起始值，默认是0，即从p0开始生成</param>
	/// <returns></returns>
	string GetTotalCountSql(string sql, QueryCondition condition, int beginIndex, int length, string[] formatParameters = null, int parameterStartIndex = 0);

	/// <summary>
	/// 根据查询条件列表得到查询条件参数值
	/// </summary>
	/// <param name="items"></param>
	/// <param name="valueStartIndex">生成参数值对应的索引起始值，默认是0，即从查询列表的第一个开始生成</param>
	/// <param name="defaultParameterCount">Sql语句中必备参数值的参数数量，必备参数必须赋值</param>
	/// <returns></returns>
	object[] GetWhereSqlParamValue(IList<QueryItem> items, int valueStartIndex = 0, int defaultParameterCount = 0);

	/// <summary>
	/// 根据查询条件列表得到查询条件参数值
	/// </summary>
	/// <param name="items"></param>
	/// <param name="indexOrder">查询条件对象列表中的对象不一定全部参与参数值的生成，可以定义范围，该值表示参与生成的索引及其顺序，如[2,5,1]</param>
	/// <param name="defaultParameterCount">Sql语句中必备参数值的参数数量，必备参数必须赋值</param>
	/// <returns></returns>
	object[] GetWhereSqlParamValue(IList<QueryItem> items, int[] indexOrder, int defaultParameterCount = 0);

	/// <summary>
	/// 根据查询条件对象得到查询条件参数值
	/// </summary>
	/// <param name="items"></param>
	/// <param name="beginIndex">查询条件对象列表中的对象不一定全部参与查询参数值的生成，可以定义范围，该值定义范围的起始索引，默认为0</param>
	/// <param name="length">查询条件对象列表中的对象不一定全部参与查询参数值的生成，可以定义范围，该值定义范围的长度</param>
	/// <param name="defaultParameterCount">Sql语句中必备参数值的参数数量，必备参数必须赋值</param>
	/// <returns></returns>
	object[] GetWhereSqlParamValue(IList<QueryItem> items, int beginIndex, int length, int defaultParameterCount = 0);
}
