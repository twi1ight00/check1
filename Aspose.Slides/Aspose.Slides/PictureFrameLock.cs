using ns4;

namespace Aspose.Slides;

public class PictureFrameLock : BaseShapeLock, IBaseShapeLock, IPictureFrameLock
{
	private static readonly ushort ushort_2 = BaseShapeLock.smethod_0(Enum114.const_0, Enum114.const_1, Enum114.const_2, Enum114.const_3, Enum114.const_4, Enum114.const_5, Enum114.const_6, Enum114.const_7, Enum114.const_8, Enum114.const_9, Enum114.const_11);

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

	public bool EditPointsLocked
	{
		get
		{
			return method_0(Enum114.const_6);
		}
		set
		{
			method_1(Enum114.const_6, value);
		}
	}

	public bool AdjustHandlesLocked
	{
		get
		{
			return method_0(Enum114.const_7);
		}
		set
		{
			method_1(Enum114.const_7, value);
		}
	}

	public bool ArrowheadsLocked
	{
		get
		{
			return method_0(Enum114.const_8);
		}
		set
		{
			method_1(Enum114.const_8, value);
		}
	}

	public bool ShapeTypeLocked
	{
		get
		{
			return method_0(Enum114.const_9);
		}
		set
		{
			method_1(Enum114.const_9, value);
		}
	}

	public bool CropLocked
	{
		get
		{
			return method_0(Enum114.const_11);
		}
		set
		{
			method_1(Enum114.const_11, value);
		}
	}

	IBaseShapeLock IPictureFrameLock.AsIBaseShapeLock => this;

	internal PictureFrameLock()
		: base(ushort_2)
	{
	}
}
