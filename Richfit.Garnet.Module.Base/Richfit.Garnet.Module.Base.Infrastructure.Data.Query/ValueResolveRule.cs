namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// 将查询条件转化为Sql查询时，值解析规则，应用于查询参数值的生成
/// </summary>
public class ValueResolveRule
{
	private int beginIndex = 0;

	private int length = 0;

	private int defaultParameterCount = 0;

	private int[] indexOrder;

	/// <summary>
	/// 查询条件对象列表中的对象不一定全部参与查询参数值的生成，可以定义范围，该值定义范围的起始索引，默认为0，该值与Length属性搭配使用
	/// </summary>
	public int BeginIndex => beginIndex;

	/// <summary>
	/// 查询条件对象列表中的对象不一定全部参与查询参数值的生成，可以定义范围，该值定义范围的长度，该值与BeginIndex属性搭配使用
	/// </summary>
	public int Length => length;

	/// <summary>
	/// Sql语句中必备参数值的参数数量，必备参数必须赋值
	/// </summary>
	public int DefaultParameterCount
	{
		get
		{
			return defaultParameterCount;
		}
		set
		{
			defaultParameterCount = value;
		}
	}

	/// <summary>
	/// 查询条件列表中的对象不一定全部参与查询参数值的生成，可以定义范围，该值表示参与生成的索引及其顺序，如[2,5,1]
	/// </summary>
	public int[] IndexOrder => indexOrder;

	/// <summary>
	/// 该属性标识查询条件列表中的对象不参与sql语句中查询参数值的生成
	/// </summary>
	public static ValueResolveRule Empty => new ValueResolveRule();

	/// <summary>
	/// 该属性标识查询条件列表中的对象全部参与sql语句中查询参数值的生成，顺序以查询列表中对象的顺序为准
	/// </summary>
	public static ValueResolveRule Null => null;

	/// <summary>
	/// 构造值解析规则对象
	/// </summary>
	public ValueResolveRule()
	{
	}

	/// <summary>
	/// 构造值解析规则对象
	/// </summary>
	/// <param name="indexOrder"></param>
	/// <param name="defaultParameterCount"></param>
	public ValueResolveRule(int[] indexOrder, int defaultParameterCount = 0)
	{
		this.indexOrder = indexOrder;
		this.defaultParameterCount = defaultParameterCount;
	}

	/// <summary>
	/// 构造值解析规则对象
	/// </summary>
	/// <param name="beginIndex"></param>
	/// <param name="length"></param>
	/// <param name="defaultParameterCount"></param>
	public ValueResolveRule(int beginIndex, int length, int defaultParameterCount = 0)
	{
		this.beginIndex = beginIndex;
		this.length = length;
		this.defaultParameterCount = defaultParameterCount;
	}
}
