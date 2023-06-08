namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// 将查询条件转化为Sql查询时，参数解析规则定义，应用于查询参数生成
/// </summary>
public class ParameterResolveRule
{
	private int beginIndex = 0;

	private int length = 0;

	private int parameterStartIndex = 0;

	private int[] indexOrder;

	/// <summary>
	/// 查询条件对象列表中的对象不一定全部参与查询sql条件的生成，可以定义范围，该值定义范围的起始索引，默认为0，该值与Length属性搭配使用
	/// </summary>
	public int BeginIndex => beginIndex;

	/// <summary>
	/// 查询条件对象列表中的对象不一定全部参与查询sql条件的生成，可以定义范围，该值定义范围的长度，该值与BeginIndex属性搭配使用
	/// </summary>
	public int Length => length;

	/// <summary>
	/// 对应的参数生成的索引起始值，默认是0，即从p0开始生成
	/// </summary>
	public int ParameterStartIndex => parameterStartIndex;

	/// <summary>
	/// 查询条件列表中的对象不一定全部参与查询sql条件的生成，可以定义范围，该值表示参与生成的索引及其顺序，如[2,5,1]
	/// </summary>
	public int[] IndexOrder => indexOrder;

	/// <summary>
	/// 该属性标识查询条件列表中的对象不参与sql语句中参数的生成
	/// </summary>
	public static ParameterResolveRule Empty => new ParameterResolveRule();

	/// <summary>
	/// 该属性标识查询条件列表中的对象全部参与sql语句中参数的生成，顺序以查询列表中对象的顺序为准
	/// </summary>
	public static ParameterResolveRule Null => null;

	/// <summary>
	/// 初始化
	/// </summary>
	public ParameterResolveRule()
	{
	}

	/// <summary>
	/// 初始化
	/// </summary>
	/// <param name="parameterStartIndex"></param>
	/// <param name="indexOrder"></param>
	public ParameterResolveRule(int parameterStartIndex, int[] indexOrder)
	{
		this.parameterStartIndex = parameterStartIndex;
		this.indexOrder = indexOrder;
	}

	/// <summary>
	/// 初始化
	/// </summary>
	/// <param name="parameterStartIndex"></param>
	/// <param name="beginIndex"></param>
	/// <param name="length"></param>
	public ParameterResolveRule(int parameterStartIndex, int beginIndex, int length)
	{
		this.parameterStartIndex = parameterStartIndex;
		this.beginIndex = beginIndex;
		this.length = length;
	}
}
