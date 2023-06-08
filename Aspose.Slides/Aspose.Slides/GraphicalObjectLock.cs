using ns4;

namespace Aspose.Slides;

public class GraphicalObjectLock : BaseShapeLock, IBaseShapeLock, IGraphicalObjectLock
{
	private static readonly ushort ushort_2 = BaseShapeLock.smethod_0(Enum114.const_0, Enum114.const_13, Enum114.const_1, Enum114.const_3, Enum114.const_4, Enum114.const_5);

	public bool GroupingLocked
	{
		get
		{
			return method_0(Enum114.const_0);
		}
		set
		{
			method_1(Enum114.const_0, value);
		}
	}

	public bool DrilldownLocked
	{
		get
		{
			return method_0(Enum114.const_13);
		}
		set
		{
			method_1(Enum114.const_13, value);
		}
	}

	public bool SelectLocked
	{
		get
		{
			return method_0(Enum114.const_1);
		}
		set
		{
			method_1(Enum114.const_1, value);
		}
	}

	public bool AspectRatioLocked
	{
		get
		{
			return method_0(Enum114.const_3);
		}
		set
		{
			method_1(Enum114.const_3, value);
		}
	}

	public bool PositionLocked
	{
		get
		{
			return method_0(Enum114.const_4);
		}
		set
		{
			method_1(Enum114.const_4, value);
		}
	}

	public bool SizeLocked
	{
		get
		{
			return method_0(Enum114.const_5);
		}
		set
		{
			method_1(Enum114.const_5, value);
		}
	}

	IBaseShapeLock IGraphicalObjectLock.AsIBaseShapeLock => this;

	internal GraphicalObjectLock()
		: base(ushort_2)
	{
	}
}
