using System;
using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns216;
using ns217;

namespace ns215;

internal class Class5914
{
	private readonly Interface252 interface252_0;

	private PointF pointF_0 = PointF.Empty;

	private SizeF sizeF_0 = SizeF.Empty;

	public bool IsHidden
	{
		get
		{
			Class5898 @class = ((Class5781)interface252_0).method_5("presence");
			if (@class != null)
			{
				return (XfaEnums.Enum687)@class.Value == XfaEnums.Enum687.const_1;
			}
			return false;
		}
	}

	internal Interface252 NativeObj => interface252_0;

	internal PointF Pos
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = value;
		}
	}

	internal XfaEnums.Enum702 AnchorType
	{
		get
		{
			Interface250 nativeObj = NativeObj;
			if (nativeObj == null)
			{
				throw new ArgumentException();
			}
			return nativeObj.AnchorType;
		}
	}

	internal SizeF Size
	{
		get
		{
			return vmethod_0();
		}
		set
		{
			sizeF_0 = value;
		}
	}

	public Class5914(Interface252 nativeObj)
	{
		interface252_0 = nativeObj;
		Interface250 nativeObj2 = NativeObj;
		if (nativeObj2 == null)
		{
			throw new ArgumentException();
		}
		pointF_0 = new PointF(nativeObj2.X, nativeObj2.Y);
		Interface251 nativeObj3 = NativeObj;
		if (nativeObj3 != null)
		{
			sizeF_0 = nativeObj3.imethod_2();
		}
		else
		{
			sizeF_0 = new SizeF(nativeObj2.W, nativeObj2.H);
		}
	}

	protected virtual SizeF vmethod_0()
	{
		return sizeF_0;
	}

	internal virtual bool vmethod_1()
	{
		return false;
	}

	internal virtual Class5914[] vmethod_2(float height, Class5834 page)
	{
		return new Class5914[2] { this, this };
	}
}
