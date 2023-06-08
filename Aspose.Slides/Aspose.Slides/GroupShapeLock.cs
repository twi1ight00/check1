using ns4;

namespace Aspose.Slides;

public class GroupShapeLock : BaseShapeLock, IBaseShapeLock, IGroupShapeLock
{
	private static readonly ushort ushort_2 = BaseShapeLock.smethod_0(Enum114.const_0, Enum114.const_12, Enum114.const_1, Enum114.const_2, Enum114.const_3, Enum114.const_4, Enum114.const_5);

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

	public bool UngroupingLocked
	{
		get
		{
			return method_0(Enum114.const_12);
		}
		set
		{
			method_1(Enum114.const_12, value);
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

	public bool RotationLocked
	{
		get
		{
			return method_0(Enum114.const_2);
		}
		set
		{
			method_1(Enum114.const_2, value);
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

	IBaseShapeLock IGroupShapeLock.AsIBaseShapeLock => this;

	internal GroupShapeLock()
		: base(ushort_2)
	{
	}
}
