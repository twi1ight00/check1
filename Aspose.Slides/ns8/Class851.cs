using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using ns18;
using ns224;
using ns24;
using ns56;
using ns7;

namespace ns8;

internal class Class851 : IComparable<Class851>
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	private double double_5;

	private int int_0;

	private int int_1;

	private double double_6;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private Class837 class837_0;

	private Enum133 enum133_0;

	private double double_7;

	private double double_8;

	private double double_9;

	private List<Class851> list_0;

	private SmartArtShape smartArtShape_0;

	private LineArrowheadStyle lineArrowheadStyle_0;

	private LineArrowheadStyle lineArrowheadStyle_1;

	private Dictionary<Enum135, double> dictionary_0;

	public SmartArtShape Shape => smartArtShape_0;

	public double X
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			foreach (Class837 child in class837_0.Children)
			{
				child.ShapeContainer.X = value;
			}
			method_15();
		}
	}

	public double Y
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
			foreach (Class837 child in class837_0.Children)
			{
				child.ShapeContainer.Y = value;
			}
			method_15();
		}
	}

	public double Width
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
			method_15();
		}
	}

	public double Height
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
			method_15();
		}
	}

	public double AvailableHeight
	{
		get
		{
			if (class837_0.Parent == null)
			{
				return class837_0.LayoutNode.Tree.Target.Height;
			}
			if (double_5 == 0.0)
			{
				return double_3;
			}
			return Math.Max(double_3, double_5);
		}
		set
		{
			double_5 = value;
		}
	}

	public double AvailableWidth
	{
		get
		{
			if (class837_0.Parent == null)
			{
				return class837_0.LayoutNode.Tree.Target.Width;
			}
			if (double_4 == 0.0)
			{
				return double_2;
			}
			return Math.Max(double_2, double_4);
		}
		set
		{
			double_4 = value;
		}
	}

	public int ZOrderOffset
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public int OrderIndex
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public bool IsHidden => bool_0;

	public bool HasImagePlaceholder => bool_2;

	public bool HasText
	{
		get
		{
			if (class837_0.ConnectedWith.Count > 0 && Shape != null)
			{
				if (!(Shape.AutoShapeInternal.TextFrame.Text != string.Empty))
				{
					return Shape.AutoShapeInternal.TextFrame.Paragraphs.Count > 1;
				}
				return true;
			}
			return false;
		}
	}

	public Class837 Target => class837_0;

	public bool IsConnection => bool_1;

	public Enum133 AutoTextRotation
	{
		get
		{
			return enum133_0;
		}
		set
		{
			enum133_0 = value;
		}
	}

	public double TextBoxWidth
	{
		get
		{
			if (double_7 != 0.0)
			{
				return double_7;
			}
			return double_2;
		}
	}

	public double TextBoxHeight
	{
		get
		{
			if (double_8 != 0.0)
			{
				return double_8;
			}
			return double_3;
		}
	}

	public LineArrowheadStyle BeginArrowheadStyle
	{
		get
		{
			return lineArrowheadStyle_1;
		}
		set
		{
			lineArrowheadStyle_1 = value;
		}
	}

	public LineArrowheadStyle EndArrowheadStyle
	{
		get
		{
			return lineArrowheadStyle_0;
		}
		set
		{
			lineArrowheadStyle_0 = value;
		}
	}

	public List<Class851> Linked => list_0;

	public Struct50 OffsetToParent
	{
		get
		{
			Class837 @class = (Class837)Target.Parent;
			if (@class != null)
			{
				return new Struct50(double_0 - @class.ShapeContainer.double_0, double_1 - @class.ShapeContainer.double_1);
			}
			return new Struct50(double_0, double_1);
		}
	}

	public Class851(Class837 point)
	{
		class837_0 = point;
		enum133_0 = Enum133.const_0;
		list_0 = new List<Class851>();
		lineArrowheadStyle_1 = LineArrowheadStyle.NotDefined;
		lineArrowheadStyle_0 = LineArrowheadStyle.NotDefined;
		dictionary_0 = new Dictionary<Enum135, double>();
	}

	public void method_0(AutoShape shape)
	{
		if (smartArtShape_0 == null)
		{
			return;
		}
		AutoShape autoShapeInternal = smartArtShape_0.AutoShapeInternal;
		if (shape.TextFrame != null)
		{
			if (autoShapeInternal.TextFrameInternal == null)
			{
				autoShapeInternal.AddTextFrame(string.Empty);
			}
			autoShapeInternal.TextFrameInternal.method_0(shape.TextFrameInternal);
		}
		Class1921 spPrElementData = new Class1921();
		Class954.smethod_5(shape, spPrElementData);
		Class954.smethod_0(autoShapeInternal, spPrElementData);
		autoShapeInternal.PPTXUnsupportedProps.TxXfrm = shape.PPTXUnsupportedProps.TxXfrm;
		autoShapeInternal.RawFrameImpl = shape.RawFrameImpl;
	}

	public void method_1(IBaseSlide slide, Class136 value)
	{
		int_0 = value.ZOrderOffset;
		double_6 = value.Rotation;
		bool_0 = value.IsHidden;
		bool_1 = value.IsConnection;
		bool_2 = value.HasImagePlaceholder;
		if (smartArtShape_0 != null)
		{
			return;
		}
		smartArtShape_0 = new SmartArtShape(slide, this);
		AutoShape autoShapeInternal = smartArtShape_0.AutoShapeInternal;
		autoShapeInternal.PPTXUnsupportedProps.ModelId = class837_0.ModelId;
		if (!value.IsConnection)
		{
			autoShapeInternal.ShapeType = value.ShapeType;
			if (value.AdjustValues != null)
			{
				Class342 template = autoShapeInternal.Geometry.PPTXUnsupportedProps.Template;
				Dictionary<int, bool> dictionary = smethod_1(template.GeomGuides, template.Adjustments.Length);
				Class2144[] adjustValues = value.AdjustValues;
				foreach (Class2144 @class in adjustValues)
				{
					int num = (int)(@class.Idx - 1);
					if (autoShapeInternal.Adjustments.Count > num)
					{
						if (dictionary.ContainsKey(num) && dictionary[num])
						{
							autoShapeInternal.Adjustments[num].AngleValue = (float)((@class.Val < 0.0) ? (360.0 + @class.Val) : @class.Val);
						}
						else
						{
							autoShapeInternal.Adjustments[num].RawValue = (long)(@class.Val * 100000.0);
						}
					}
				}
			}
		}
		method_16(double_6);
	}

	public Struct48 method_2()
	{
		double num = 0.0;
		double num2 = 0.0;
		foreach (Class837 child in class837_0.Children)
		{
			if (num < child.ShapeContainer.Height)
			{
				num = child.ShapeContainer.Height;
			}
			if (num2 < child.ShapeContainer.Width)
			{
				num2 = child.ShapeContainer.Width;
			}
		}
		return new Struct48(num2, num);
	}

	public Struct47[] method_3()
	{
		List<Struct47> list = new List<Struct47>();
		method_19(class837_0.AssociatedWith, class837_0, list);
		return list.ToArray();
	}

	public Struct47[] method_4()
	{
		List<Struct47> list = new List<Struct47>();
		method_20(null, class837_0, list);
		return list.ToArray();
	}

	public void method_5(double diffX, double diffY)
	{
		Struct50 offsetToParent = OffsetToParent;
		method_6(diffX - offsetToParent.Dx, diffY - offsetToParent.Dy);
	}

	public void method_6(double diffX, double diffY)
	{
		if (diffX == 0.0 && diffY == 0.0)
		{
			return;
		}
		double_0 += diffX;
		double_1 += diffY;
		foreach (Class837 child in class837_0.Children)
		{
			child.ShapeContainer.method_6(diffX, diffY);
		}
		method_15();
	}

	public void method_7(double diffX, double diffY)
	{
		if (diffX == 0.0 && diffY == 0.0)
		{
			return;
		}
		foreach (Class851 item in list_0)
		{
			item.method_6(diffX, diffY);
		}
		if (Target.ConnectedWith.Count <= 0)
		{
			return;
		}
		List<Class837> list = new List<Class837>();
		method_17(Target.Root, Target.ConnectedWith[0].ModelId, list);
		foreach (Class837 item2 in list)
		{
			if (item2.ShapeContainer != this && !list_0.Contains(item2.ShapeContainer))
			{
				item2.ShapeContainer.method_6(diffX, diffY);
			}
		}
	}

	public void method_8()
	{
		double num = 0.0;
		double_1 = 0.0;
		double_0 = num;
		method_15();
	}

	public void method_9()
	{
		double num = 0.0;
		double_3 = 0.0;
		double_2 = num;
		method_8();
		list_0.Clear();
		dictionary_0.Clear();
	}

	public void method_10(double angle)
	{
		double_6 = angle;
		double num = smartArtShape_0.AutoShapeInternal.RawFrameImpl.Rotation;
		angle += (double.IsNaN(num) ? 0.0 : num);
		method_11(angle);
	}

	public void method_11(double angle)
	{
		method_16(angle);
		method_15();
	}

	public void method_12()
	{
		Struct47 @struct = method_18();
		double_2 = @struct.Width;
		double_3 = @struct.Height;
		double_0 = @struct.X;
		double_1 = @struct.Y;
		method_15();
	}

	public double method_13(Enum135 key)
	{
		if (!dictionary_0.ContainsKey(key))
		{
			return 0.0;
		}
		return dictionary_0[key];
	}

	public void method_14(Enum135 key, double value)
	{
		if (dictionary_0.ContainsKey(key))
		{
			dictionary_0[key] = value;
		}
		else
		{
			dictionary_0.Add(key, value);
		}
	}

	public int CompareTo(Class851 other)
	{
		int num = ZOrderOffset + OrderIndex;
		int num2 = other.ZOrderOffset + other.OrderIndex;
		if (num == num2)
		{
			if (ZOrderOffset > other.ZOrderOffset)
			{
				return 1;
			}
			if (ZOrderOffset < other.ZOrderOffset)
			{
				return -1;
			}
			if (OrderIndex == other.OrderIndex)
			{
				return 0;
			}
			if (OrderIndex > other.OrderIndex)
			{
				return 1;
			}
			return -1;
		}
		if (num > num2)
		{
			return 1;
		}
		return -1;
	}

	[SpecialName]
	public static Struct47 smethod_0(Class851 container)
	{
		return new Struct47(container.X, container.Y, container.X + container.Width, container.Y + container.Height);
	}

	private void method_15()
	{
		if (smartArtShape_0 == null)
		{
			return;
		}
		AutoShape autoShapeInternal = smartArtShape_0.AutoShapeInternal;
		Class154 rawFrameImpl = autoShapeInternal.RawFrameImpl;
		if (double_6 != 0.0)
		{
			Struct47 bounds;
			Struct48 @struct = Class102.smethod_0(new Struct48(double_2, double_3), double_6, out bounds);
			double num = (double_2 - bounds.Width) / 2.0 - bounds.X;
			double num2 = (double_3 - bounds.Height) / 2.0 - bounds.Y;
			rawFrameImpl.vmethod_0(double_0 + num, double_1 + num2, @struct.Width, @struct.Height);
		}
		else
		{
			rawFrameImpl.vmethod_0(double_0, double_1, double_2, double_3);
		}
		if (class837_0.DataPoint.PropertySet.CustFlipHor != NullableBool.NotDefined)
		{
			rawFrameImpl.FlipH = class837_0.DataPoint.PropertySet.CustFlipHor;
		}
		if (class837_0.DataPoint.PropertySet.CustFlipVert != NullableBool.NotDefined)
		{
			rawFrameImpl.FlipV = class837_0.DataPoint.PropertySet.CustFlipVert;
		}
		if (autoShapeInternal.TextFrame == null || AutoTextRotation == Enum133.const_0)
		{
			return;
		}
		double num3 = ((!double.IsNaN(rawFrameImpl.Rotation)) ? (rawFrameImpl.Rotation % 360f) : 0f);
		if (num3 < 0.0)
		{
			num3 += 360.0;
		}
		if (autoShapeInternal.PPTXUnsupportedProps.TxXfrm == null)
		{
			autoShapeInternal.PPTXUnsupportedProps.TxXfrm = new Class1976();
			autoShapeInternal.PPTXUnsupportedProps.TxXfrm.delegate1585_0();
			autoShapeInternal.PPTXUnsupportedProps.TxXfrm.delegate1576_0();
		}
		Class1976 txXfrm = autoShapeInternal.PPTXUnsupportedProps.TxXfrm;
		RectangleF rectangleF = autoShapeInternal.Geometry.method_0(autoShapeInternal, 0f, 0f, (float)rawFrameImpl.Width, (float)rawFrameImpl.Height);
		Class6002 @class = new Class6002();
		PointF point = new PointF((float)(rawFrameImpl.X + rawFrameImpl.Width / 2.0), (float)(rawFrameImpl.Y + rawFrameImpl.Height / 2.0));
		@class.method_14((float)num3, point);
		double num4 = ((rawFrameImpl.FlipV == NullableBool.True) ? (rawFrameImpl.Height - (double)rectangleF.Height) : 0.0);
		PointF pointF = @class.method_2(new PointF((float)(rawFrameImpl.X + (double)rectangleF.X + (double)(rectangleF.Width / 2f)), (float)(rawFrameImpl.Y + (double)rectangleF.Y + (double)(rectangleF.Height / 2f) + (double)(float)num4)));
		double num5 = rectangleF.Height / 2f;
		double num6 = rectangleF.Width / 2f;
		num3 = double_9 % 360.0;
		float num7 = 0f;
		if (AutoTextRotation == Enum133.const_2)
		{
			num7 = ((num3 > 90.0 && !(num3 >= 270.0)) ? 180 : 0);
		}
		else
		{
			if (num3 > 45.0 && num3 < 135.0)
			{
				num5 = num6;
				num6 = rectangleF.Height / 2f;
				num7 = 270f;
			}
			else if (num3 >= 135.0 && num3 <= 225.0)
			{
				num7 = 180f;
			}
			else if (num3 > 225.0 && num3 < 315.0)
			{
				num5 = num6;
				num6 = rectangleF.Height / 2f;
				num7 = 90f;
			}
			if (rawFrameImpl.FlipV == NullableBool.True && ((num3 >= 0.0 && num3 <= 45.0) || num3 >= 315.0))
			{
				num7 += 180f;
			}
		}
		Struct47 struct2 = new Struct47((double)pointF.X - num6, (double)pointF.Y - num5, (double)pointF.X + num6, (double)pointF.Y + num5);
		txXfrm.Ext.Cx = struct2.Width;
		txXfrm.Ext.Cy = struct2.Height;
		txXfrm.Off.X = struct2.X;
		txXfrm.Off.Y = struct2.Y;
		txXfrm.Rot = num7;
		double_7 = struct2.Width;
		double_8 = struct2.Height;
	}

	private void method_16(double angle)
	{
		if (smartArtShape_0 != null)
		{
			double_9 = angle;
			if (class837_0.DataPoint.PropertySet.CustAng != 0)
			{
				double num = (double)class837_0.DataPoint.PropertySet.CustAng / 60000.0;
				angle = (num + angle) % 360.0;
			}
			bool flag = class837_0.DataPoint.PropertySet.CustFlipHor == NullableBool.True;
			bool flag2 = class837_0.DataPoint.PropertySet.CustFlipVert == NullableBool.True;
			if (flag ^ flag2)
			{
				angle = (360.0 - angle) % 360.0;
			}
			smartArtShape_0.AutoShapeInternal.RawFrameImpl.Rotation = (float)angle;
		}
	}

	private void method_17(Class837 root, string firstConnected, List<Class837> output)
	{
		if (root.ConnectedWith.Count > 0 && root.ConnectedWith[0].ModelId == firstConnected && root.ShapeContainer.IsHidden && root.Algorithm is Class129)
		{
			output.Add(root);
		}
		foreach (Class837 child in root.Children)
		{
			method_17(child, firstConnected, output);
		}
	}

	private Struct47 method_18()
	{
		List<Class837> list = class837_0.method_39();
		if (list.Count == 0)
		{
			return default(Struct47);
		}
		double num = double.MinValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MaxValue;
		bool flag = false;
		foreach (Class837 item in list)
		{
			if (item.ShapeContainer.Width != 0.0 && item.ShapeContainer.Height != 0.0)
			{
				num3 = Math.Min(num3, item.ShapeContainer.X);
				num4 = Math.Min(num4, item.ShapeContainer.Y);
				num = Math.Max(num, item.ShapeContainer.X + item.ShapeContainer.Width);
				num2 = Math.Max(num2, item.ShapeContainer.Y + item.ShapeContainer.Height);
				flag = true;
			}
		}
		if (!flag)
		{
			return default(Struct47);
		}
		return new Struct47(num3, num4, num, num2);
	}

	private void method_19(Class836 dataRoot, Class837 point, List<Struct47> output)
	{
		if (dataRoot != point.AssociatedWith && !dataRoot.Children.Contains(point.AssociatedWith))
		{
			return;
		}
		if (point.method_49())
		{
			output.Add(smethod_0(point.ShapeContainer));
		}
		foreach (Class837 child in point.Children)
		{
			method_19(dataRoot, child, output);
		}
	}

	private void method_20(Class836 dataRoot, Class837 point, List<Struct47> output)
	{
		if (point.method_49())
		{
			if (dataRoot == null)
			{
				output.Add(smethod_0(point.ShapeContainer));
			}
			else if (point.AssociatedWith == dataRoot)
			{
				output.Add(smethod_0(point.ShapeContainer));
			}
		}
		foreach (Class837 child in point.Children)
		{
			method_20(dataRoot, child, output);
		}
	}

	private static Dictionary<int, bool> smethod_1(Class541[] guides, int adjCount)
	{
		Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
		foreach (Class541 @class in guides)
		{
			if (@class.Operation != Enum113.const_11)
			{
				continue;
			}
			int num = (int)(@class.Data2 - 27273042316901L);
			if (num > adjCount)
			{
				num = (int)(-27273042329612L - @class.Data2 - 1L);
				if (guides.Length > num && num > 0)
				{
					num = (int)(guides[num].Data1 - 27273042316901L);
				}
			}
			bool value = @class.Name.ToLower().Contains("ang");
			dictionary.Add(num, value);
		}
		return dictionary;
	}
}
