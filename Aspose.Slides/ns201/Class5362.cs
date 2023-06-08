using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ns171;
using ns173;
using ns174;
using ns175;
using ns176;
using ns179;
using ns181;
using ns183;
using ns184;
using ns185;
using ns187;
using ns195;
using ns200;
using ns205;
using ns218;
using ns224;
using ns234;
using ns235;
using ns271;

namespace ns201;

internal class Class5362 : Class5361
{
	internal class Class6214 : Class6213
	{
		private Color color_0 = Color.Empty;

		private Color color_1 = Color.Empty;

		private Interface181 interface181_0;

		public Interface181 ZIndex
		{
			get
			{
				return interface181_0;
			}
			set
			{
				interface181_0 = value;
			}
		}

		public Color FillColor
		{
			get
			{
				return color_0;
			}
			set
			{
				color_0 = value;
			}
		}

		public Color DrawColor
		{
			get
			{
				return color_1;
			}
			set
			{
				color_1 = value;
			}
		}
	}

	private class Class5365 : IComparer
	{
		public int Compare(object x, object y)
		{
			Class5356 @class = (Class5356)x;
			Class5356 class2 = (Class5356)y;
			RectangleF rectangleF = RectangleF.Intersect(@class.method_1(), class2.method_1());
			if (rectangleF.IsEmpty)
			{
				return 0;
			}
			if (rectangleF == @class.method_1())
			{
				return 1;
			}
			if (rectangleF == class2.method_1())
			{
				return -1;
			}
			return 0;
		}
	}

	internal class Class5366 : IComparer
	{
		public int Compare(object x, object y)
		{
			Class6214 @class = ((Class5367)x).Item as Class6214;
			Class6214 class2 = ((Class5367)y).Item as Class6214;
			int num = ((@class == null || class2 == null) ? ((Class5367)x).Index : ((int)@class.ZIndex.imethod_1()));
			int num2 = ((@class == null || class2 == null) ? ((Class5367)y).Index : ((int)class2.ZIndex.imethod_1()));
			if (num == num2)
			{
				num = ((Class5367)x).Index;
				num2 = ((Class5367)y).Index;
			}
			return num.CompareTo(num2);
		}
	}

	internal class Class5367
	{
		private Class6204 class6204_0;

		private int int_0;

		public int Index => int_0;

		public Class6204 Item => class6204_0;

		internal Class5367(Class6204 item, int index)
		{
			class6204_0 = item;
			int_0 = index;
		}
	}

	internal class Class6184 : Class6176
	{
		private Class6216 class6216_0;

		private Stack stack_0 = new Stack();

		private Stack stack_1 = new Stack();

		private Queue queue_0 = new Queue();

		public Class6216 Page => class6216_0;

		private Class6212 CurrentNewCanvas => (Class6212)stack_1.Peek();

		public override void vmethod_0(Class6216 page)
		{
			class6216_0 = new Class6216(page.Width, page.Height);
		}

		private Class6214 method_0()
		{
			Class6002 @class = new Class6002();
			Interface181 zIndex = Class5359.interface181_1;
			Class6214 class2 = null;
			object[] array = stack_0.ToArray();
			Class6270 class3 = null;
			for (int num = array.Length - 1; num >= 0; num--)
			{
				Class6213 class4 = array[num] as Class6214;
				if (class4 != null && class4.Hyperlink != null)
				{
					class3 = class4.Hyperlink;
				}
				if (class4 != null && ((Class6214)class4).ZIndex.imethod_0() != 9)
				{
					zIndex = ((Class6214)class4).ZIndex;
				}
				else if (class4 == null)
				{
					class4 = array[num] as Class6213;
				}
				if (class4.Clip != null)
				{
					Class6214 class5 = new Class6214();
					if (class4.Clip != null)
					{
						class5.Clip = class4.Clip.Clone();
					}
					if (class4.RenderTransform != null)
					{
						class5.RenderTransform = class4.RenderTransform.Clone();
					}
					if (!@class.IsIdentity)
					{
						Class6214 class6 = new Class6214();
						class6.RenderTransform = @class;
						@class = new Class6002();
						class6.Add(class5);
						class2?.Add(class6);
					}
					else
					{
						class2?.Add(class5);
					}
					class2 = class5;
				}
				else if (class4.RenderTransform != null)
				{
					@class.method_9(class4.RenderTransform.Clone(), MatrixOrder.Prepend);
				}
			}
			if (class2 == null)
			{
				class2 = new Class6214();
				class2.RenderTransform = @class;
			}
			else if (!@class.IsIdentity)
			{
				Class6214 class7 = new Class6214();
				class7.RenderTransform = @class;
				class2.Add(class7);
				class2 = class7;
			}
			class2.ZIndex = zIndex;
			if (class3 != null)
			{
				class2.Hyperlink = class3;
			}
			return class2;
		}

		public override void vmethod_2(Class6213 canvas)
		{
			stack_0.Push(canvas);
			Class6214 @class = method_0();
			stack_1.Push(@class);
			if (@class.Parent != null)
			{
				Interface181 zIndex = @class.ZIndex;
				@class = method_1(@class.Parent);
				@class.ZIndex = zIndex;
			}
			queue_0.Enqueue(@class);
		}

		private Class6214 method_1(Class6204 parent)
		{
			if (parent.Parent == null)
			{
				return (Class6214)parent;
			}
			return method_1(parent.Parent);
		}

		public override void vmethod_3(Class6213 canvas)
		{
			stack_0.Pop();
			stack_1.Pop();
			if (stack_0.Count != 0)
			{
				return;
			}
			while (queue_0.Count != 0)
			{
				Class6214 @class = (Class6214)queue_0.Dequeue();
				if (@class.Count > 0)
				{
					class6216_0.Add(@class);
				}
			}
		}

		public override void vmethod_4(Class6219 glyphs)
		{
			CurrentNewCanvas.Add(glyphs);
		}

		public override void vmethod_6(Class6217 path)
		{
			CurrentNewCanvas.Add(path);
		}

		public override void vmethod_11(Class6220 image)
		{
			CurrentNewCanvas.Add(image);
		}

		public override void vmethod_12(Class6211 bookmark)
		{
			CurrentNewCanvas.Add(bookmark);
		}

		public override void vmethod_13(Class6221 outlineItem)
		{
			CurrentNewCanvas.Add(outlineItem);
		}

		public override void vmethod_14(Class6210 field)
		{
			CurrentNewCanvas.Add(field);
		}

		public override void vmethod_15(Class6207 field)
		{
			CurrentNewCanvas.Add(field);
		}

		public override void vmethod_16(Class6209 field)
		{
			CurrentNewCanvas.Add(field);
		}

		public override void vmethod_17(Class6208 field)
		{
			CurrentNewCanvas.Add(field);
		}

		public override void vmethod_18(Class6206 field)
		{
			CurrentNewCanvas.Add(field);
		}

		public override bool vmethod_19(Class6215 group)
		{
			CurrentNewCanvas.Add(group);
			return true;
		}
	}

	private const int int_6 = 0;

	private const int int_7 = 1;

	private const int int_8 = 3;

	public static string string_0;

	public static string string_1;

	protected double double_0 = 1.0;

	protected int int_9;

	protected int int_10;

	protected ArrayList arrayList_1 = new ArrayList();

	private int int_11;

	protected bool bool_0 = true;

	protected bool bool_1 = true;

	protected bool bool_2;

	private bool bool_3;

	private Class6217 class6217_0;

	private PointF pointF_0 = PointF.Empty;

	private ArrayList arrayList_2 = new ArrayList();

	private bool bool_4 = true;

	private Stream stream_0;

	private Stack stack_0 = new Stack();

	protected Stack stack_1 = new Stack();

	private RectangleF rectangleF_0 = RectangleF.Empty;

	private bool bool_5;

	private Stack stack_2 = new Stack();

	private ArrayList arrayList_3 = new ArrayList();

	private Class5352 class5352_0 = new Class5352();

	private bool bool_6;

	private static double double_1;

	private int[] int_12 = new int[4] { 0, 3, 1, 3 };

	private static double[][] double_2;

	private static double[][] double_3;

	private static double[][] double_4;

	private static double[][] double_5;

	private Class5702 class5702_0;

	private Class6003[][] class6003_0 = new Class6003[4][];

	private Dictionary<Class6204, bool> dictionary_0 = new Dictionary<Class6204, bool>();

	internal Class6214 CurrentCanvas => (Class6214)stack_0.Peek();

	private Class6002 method_28()
	{
		if (stack_0.Count == 0)
		{
			return new Class6002();
		}
		Class6002 @class = ((CurrentCanvas.RenderTransform != null) ? CurrentCanvas.RenderTransform.Clone() : new Class6002());
		for (Class6214 class2 = CurrentCanvas.Parent as Class6214; class2 != null; class2 = class2.Parent as Class6214)
		{
			if (class2.RenderTransform != null)
			{
				@class.method_9(class2.RenderTransform.Clone(), MatrixOrder.Append);
			}
		}
		float num = (float)(arrayList_2.Count - 1) * ((Class6216)arrayList_2[0]).Height;
		if (num > 0f)
		{
			@class.method_9(new Class6002(1f, 0f, 0f, 1f, 0f, num), MatrixOrder.Append);
		}
		return @class;
	}

	protected void method_29(string id, RectangleF rect)
	{
		Class6215 @class = new Class6215();
		@class.Id = id;
		if (@class.Id.Length > 0)
		{
			stack_1.Push(id);
		}
		if (class5738_0.hashtable_1 != null && id.Length > 0)
		{
			class5738_0.hashtable_1[@class.Id] = method_28().method_4(rect);
		}
		@class.Tag = 0;
		if (stack_2.Count > 0)
		{
			((Class6215)stack_2.Peek()).Add(@class);
		}
		stack_2.Push(@class);
	}

	protected Class6215 method_30()
	{
		Class6215 @class = stack_2.Pop() as Class6215;
		if (@class.Id.Length > 0)
		{
			stack_1.Pop();
		}
		if (@class != null && (int)@class.Tag + @class.Count == 0)
		{
			CurrentCanvas.Add(@class);
		}
		return @class;
	}

	private void method_31(Class6214 canvas)
	{
		canvas.ZIndex = interface181_0;
		if (canvas.RenderTransform == null)
		{
			canvas.RenderTransform = new Class6002();
		}
		if (stack_0.Count > 0)
		{
			CurrentCanvas.Add(canvas);
		}
		else
		{
			((Class6216)arrayList_2[int_11]).Add(canvas);
		}
		stack_0.Push(canvas);
	}

	private void method_32()
	{
		stack_0.Pop();
	}

	protected string method_33(Class4942 ip)
	{
		if (ip.method_34(Class5757.int_5))
		{
			return (string)ip.method_33(Class5757.int_5);
		}
		return string.Empty;
	}

	protected override void vmethod_13(Class4962 block)
	{
		string id = method_33(block);
		RectangleF rect = new RectangleF((float)int_0 / 1000f, (float)class5358_0.Value / 1000f, (float)block.method_12() / 1000f, (float)block.vmethod_1() / 1000f);
		Class6002 @class = new Class6002();
		@class.method_8((float)block.method_40() / 1000f, (float)block.method_41() / 1000f);
		@class.method_8(0f, (float)block.method_23() / 1000f);
		RectangleF rect2 = @class.method_4(rect);
		method_29(id, rect2);
		rect2 = method_50(rect2);
		try
		{
			base.vmethod_13(block);
			method_51(block, rect2);
		}
		finally
		{
			method_30();
		}
	}

	public Class5362(Class5738 userAgent, ArrayList apsPages, bool splitPages)
		: base(userAgent)
	{
		if (apsPages != null)
		{
			arrayList_2 = apsPages;
			bool_4 = false;
		}
		bool_5 = splitPages;
		userAgent.method_3(this);
		string text = (string)userAgent.method_21()[string_0];
		if (text != null)
		{
			bool_2 = text.ToLower() == "true";
		}
	}

	public override Class5738 imethod_3()
	{
		return class5738_0;
	}

	public override string imethod_0()
	{
		return string_1;
	}

	public override void imethod_4(Class5730 inFontInfo)
	{
		class5730_0 = inFontInfo;
		Class5457 @class = new Class5457(class5738_0.method_0().method_51().method_1());
		@class.UseHelvetica = class5738_0.UseHelvetica;
		Interface195[] fontCollections = new Interface195[1] { @class };
		class5738_0.method_0().method_51().method_11(method_16(), fontCollections);
	}

	public void method_34(double newScaleFactor)
	{
		double_0 = newScaleFactor;
	}

	public double method_35()
	{
		return double_0;
	}

	public override void imethod_1(Stream outputStream)
	{
		stream_0 = outputStream;
		base.imethod_1(outputStream);
	}

	public override void imethod_2()
	{
		for (int i = 0; i < arrayList_2.Count; i++)
		{
			Class6184 @class = new Class6184();
			((Class6216)arrayList_2[i]).vmethod_0(@class);
			smethod_1(@class.Page);
			arrayList_2[i] = @class.Page;
		}
		if (bool_5)
		{
			Class6182 class2 = new Class6182(dictionary_0);
			RectangleF marginRect = ((!rectangleF_0.IsEmpty) ? rectangleF_0 : new RectangleF(0f, 0f, ((Class6216)arrayList_2[0]).Width, ((Class6216)arrayList_2[0]).Height));
			class2.method_0(arrayList_2, marginRect);
		}
		if (bool_6)
		{
			Class6181 visitor = new Class6181();
			foreach (Class6216 item in arrayList_2)
			{
				item.vmethod_0(visitor);
			}
		}
		bool_3 = true;
		if (int_11 == 0)
		{
			new Exception53("No page could be rendered");
		}
	}

	public bool method_36()
	{
		return bool_3;
	}

	public int method_37()
	{
		return int_11;
	}

	public void method_38(int c)
	{
		int_11 = c;
	}

	public int method_39()
	{
		return arrayList_1.Count;
	}

	public void method_40()
	{
		arrayList_1.Clear();
		method_38(0);
	}

	public override void imethod_11(Class4974 pageViewport)
	{
		if (rectangleF_0.IsEmpty)
		{
			Class4965 @class = pageViewport.method_32();
			if (@class != null)
			{
				RectangleF rectangleF = @class.method_38().method_40();
				rectangleF_0 = new RectangleF(rectangleF.X / 1000f, rectangleF.Y / 1000f, rectangleF.Width / 1000f, rectangleF.Height / 1000f);
			}
		}
		SizeF sizeF = new SizeF(pageViewport.method_11().Width / 1000f, pageViewport.method_11().Height / 1000f);
		Class6216 class2 = new Class6216(sizeF.Width, sizeF.Height);
		arrayList_2.Add(class2);
		if (arrayList_2.Count == 1)
		{
			Class6215 class3 = new Class6215();
			class3.Tag = 0;
			class3.Id = "root";
			stack_2.Push(class3);
		}
		stack_0.Clear();
		method_31(new Class6214());
		base.imethod_11(pageViewport);
		Class6214 class4 = new Class6214();
		class4.ZIndex = Class5041.smethod_0(Class5042.smethod_0(9, "AUTO"));
		if (arrayList_3.Count > 0)
		{
			bool_6 = true;
			arrayList_3.Sort(new Class5365());
			foreach (Class5356 item in arrayList_3)
			{
				Class5349 class6 = item.method_0();
				if (class6 is Class5351 class7)
				{
					Class6217 class8 = new Class6217(new Class6003(Class5998.class5998_113));
					class8.Hyperlink = new Class6270(item.method_1(), class7.method_6());
					Class6218 class9 = new Class6218();
					class9.method_3(item.method_1());
					class9.IsClosed = true;
					class8.Add(class9);
					class4.Add(class8);
				}
			}
			arrayList_3.Clear();
			if (class4.Count > 0)
			{
				class2.Add(class4);
			}
		}
		int_11++;
	}

	protected void method_41(Class4974 pageViewport)
	{
		arrayList_1.Add(pageViewport);
	}

	public Class4974 method_42(int pageIndex)
	{
		if (pageIndex < 0 || pageIndex >= arrayList_1.Count)
		{
			throw new Exception53("Requested page number is out of range: " + pageIndex + "; only " + arrayList_1.Count + " page(s) available.");
		}
		return (Class4974)arrayList_1[pageIndex];
	}

	private static void smethod_1(Class6216 page)
	{
		if (page == null)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < page.Count; i++)
		{
			arrayList.Add(new Class5367(page[i], i));
		}
		arrayList.Sort(new Class5366());
		page.Clear();
		foreach (Class5367 item in arrayList)
		{
			page.Add(item.Item);
		}
	}

	protected override void vmethod_34()
	{
		method_31(new Class6214());
	}

	protected override void vmethod_35()
	{
		method_32();
	}

	protected override void vmethod_31(Matrix at)
	{
		CurrentCanvas.RenderTransform.method_10(Class6161.smethod_1(at));
	}

	public static Matrix smethod_2(Class5492 sourceMatrix)
	{
		if (sourceMatrix == null)
		{
			throw new NullReferenceException("Matrix must not be null");
		}
		double[] array = sourceMatrix.method_5();
		return new Matrix((float)array[0], (float)array[1], (float)array[2], (float)array[3], (float)array[4] / 1000f, (float)array[5] / 1000f);
	}

	protected override void vmethod_1(Class5492 ctm, RectangleF clippingRect)
	{
		vmethod_34();
		if (!clippingRect.IsEmpty)
		{
			vmethod_39(clippingRect.X / 1000f, clippingRect.Y / 1000f, clippingRect.Width / 1000f, clippingRect.Height / 1000f);
		}
		CurrentCanvas.RenderTransform.method_10(Class6161.smethod_1(smethod_2(ctm)));
	}

	protected override void vmethod_2()
	{
		vmethod_35();
	}

	protected override ArrayList vmethod_33()
	{
		return new ArrayList();
	}

	protected override void vmethod_32(ArrayList breakOutList)
	{
	}

	protected override void vmethod_44(Color col, bool fill)
	{
		if (fill)
		{
			CurrentCanvas.FillColor = col;
		}
		else
		{
			CurrentCanvas.DrawColor = col;
		}
	}

	protected override void vmethod_38()
	{
		if (class6217_0 == null)
		{
			throw new InvalidOperationException("No current path available!");
		}
		CurrentCanvas.Clip = class6217_0;
		class6217_0 = null;
	}

	protected override void vmethod_42()
	{
		if (class6217_0.Count != 0 && ((Class6218)class6217_0[class6217_0.Count - 1]).Count != 0)
		{
			((Class6218)class6217_0[class6217_0.Count - 1]).IsClosed = true;
		}
	}

	protected override void vmethod_40(float x, float y)
	{
		if (class6217_0 == null)
		{
			class6217_0 = new Class6217();
			method_46(class6217_0);
		}
		pointF_0 = new PointF(x, y);
		if (class6217_0.Count != 0 && ((Class6218)class6217_0[class6217_0.Count - 1]).Count != 0)
		{
			Class6218 node = new Class6218();
			method_46(node);
			class6217_0.Add(node);
		}
	}

	protected override void vmethod_41(float x, float y)
	{
		if (class6217_0 == null)
		{
			class6217_0 = new Class6217();
			method_46(class6217_0);
		}
		PointF startPoint = pointF_0;
		pointF_0 = new PointF(x, y);
		if (class6217_0.Count == 0)
		{
			Class6218 node = new Class6218();
			method_46(node);
			class6217_0.Add(new Class6218());
			Class6223 node2 = new Class6223(startPoint, pointF_0);
			method_46(node2);
			((Class6218)class6217_0[class6217_0.Count - 1]).Add(node2);
		}
		else
		{
			Class6218 @class = (Class6218)class6217_0[class6217_0.Count - 1];
			Class6223 class2 = @class[@class.Count - 1] as Class6223;
			class2.Points.Add(pointF_0);
		}
	}

	protected override void vmethod_39(float x, float y, float width, float height)
	{
		Class6218 @class = new Class6218();
		method_46(@class);
		Class6217 class2 = new Class6217();
		method_46(class2);
		@class.method_3(new RectangleF(x, y, width, height));
		@class.IsClosed = true;
		class2.Add(@class);
		CurrentCanvas.Clip = class2;
	}

	protected override void vmethod_43(float x, float y, float width, float height)
	{
		if (CurrentCanvas != null && (CurrentCanvas.FillColor != Color.Empty || CurrentCanvas.DrawColor != Color.Empty))
		{
			Class6217 @class = new Class6217();
			method_46(@class);
			if (CurrentCanvas.DrawColor != Color.Empty)
			{
				@class.Pen = new Class6003(Class6153.smethod_1(CurrentCanvas.DrawColor));
			}
			if (CurrentCanvas.FillColor != Color.Empty)
			{
				@class.Brush = new Class5997(Class6153.smethod_1(CurrentCanvas.FillColor));
			}
			Class6218 class2 = new Class6218();
			method_46(class2);
			class2.method_3(new RectangleF(x, y, width, height));
			class2.IsClosed = true;
			@class.Add(class2);
			@class.FillMode = FillMode.Alternate;
			CurrentCanvas.Add(@class);
		}
	}

	static Class5362()
	{
		string_0 = "transparent-page-background";
		string_1 = "application/X-fop-aps";
		double_1 = 0.5 - 2.0 / 3.0 * (Math.Sqrt(2.0) - 1.0);
		double_2 = new double[4][];
		double_2[0] = new double[4] { 0.0, 0.0, 0.0, 0.5 };
		double_2[1] = new double[12]
		{
			0.0, 0.0, 0.0, double_1, 0.0, double_1, 0.0, 0.0, 0.0, 0.5,
			0.0, 0.0
		};
		double_2[2] = new double[4] { 1.0, -0.5, 0.0, 0.0 };
		double[][] array = double_2;
		double[] array2 = new double[12]
		{
			1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0, 0.0,
			0.0, 0.5
		};
		array2[1] = 0.0 - double_1;
		array2[7] = double_1;
		array[3] = array2;
		double_3 = new double[4][];
		double_3[0] = new double[4] { 1.0, -0.5, 0.0, 0.0 };
		double[][] array3 = double_3;
		double[] array4 = new double[12]
		{
			1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0, 0.0,
			0.0, 0.5
		};
		array4[1] = 0.0 - double_1;
		array4[7] = double_1;
		array3[1] = array4;
		double_3[2] = new double[4] { 1.0, 0.0, 1.0, -0.5 };
		double[][] array5 = double_3;
		double[] array6 = new double[12]
		{
			1.0, 0.0, 1.0, 0.0, 1.0, 0.0, 1.0, 0.0, 1.0, -0.5,
			1.0, 0.0
		};
		array6[3] = 0.0 - double_1;
		array6[5] = 0.0 - double_1;
		array5[3] = array6;
		double_4 = new double[4][];
		double_4[0] = new double[4] { 1.0, 0.0, 1.0, -0.5 };
		double[][] array7 = double_4;
		double[] array8 = new double[12]
		{
			1.0, 0.0, 1.0, 0.0, 1.0, 0.0, 1.0, 0.0, 1.0, -0.5,
			1.0, 0.0
		};
		array8[3] = 0.0 - double_1;
		array8[5] = 0.0 - double_1;
		array7[1] = array8;
		double_4[2] = new double[4] { 0.0, 0.5, 1.0, 0.0 };
		double[][] array9 = double_4;
		double[] array10 = new double[12]
		{
			0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0,
			1.0, -0.5
		};
		array10[1] = double_1;
		array10[7] = 0.0 - double_1;
		array9[3] = array10;
		double_5 = new double[4][];
		double_5[0] = new double[4] { 0.0, 0.5, 1.0, 0.0 };
		double[][] array11 = double_5;
		double[] array12 = new double[12]
		{
			0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0,
			1.0, -0.5
		};
		array12[1] = double_1;
		array12[7] = 0.0 - double_1;
		array11[1] = array12;
		double_5[2] = new double[4] { 0.0, 0.0, 0.0, 0.5 };
		double_5[3] = new double[12]
		{
			0.0, 0.0, 0.0, double_1, 0.0, double_1, 0.0, 0.0, 0.0, 0.5,
			0.0, 0.0
		};
	}

	protected void method_43(double[][] points, int[] types)
	{
	}

	protected override void vmethod_29(Class5705 bpsTop, Class5705 bpsBottom, Class5705 bpsLeft, Class5705 bpsRight)
	{
		if (bpsTop != null && bpsTop.class5702_0 != null)
		{
			class5702_0 = bpsTop.class5702_0;
		}
		else if (bpsBottom != null && bpsBottom.class5702_0 != null)
		{
			class5702_0 = bpsBottom.class5702_0;
		}
		else if (bpsLeft != null && bpsLeft.class5702_0 != null)
		{
			class5702_0 = bpsLeft.class5702_0;
		}
		else if (bpsRight != null && bpsRight.class5702_0 != null)
		{
			class5702_0 = bpsRight.class5702_0;
		}
	}

	private static void smethod_3(Class6217 path, PointF[] points)
	{
		Class6217 @class = new Class6217();
		Class6218 class2 = new Class6218();
		class2.method_1(points);
		class2.IsClosed = true;
		@class.Add(class2);
		path.Clip = @class;
	}

	protected override void vmethod_30(RectangleF rect)
	{
		RectangleF rectangleF = rect;
		if (class5702_0 != null)
		{
			if (class6003_0[0] != null)
			{
				float num = class6003_0[0][0].Width / 2f;
				rect.Y += num;
				rect.Height -= num;
				rectangleF.Y -= num;
				rectangleF.Height += num;
			}
			if (class6003_0[1] != null)
			{
				float num2 = class6003_0[1][0].Width / 2f;
				rect.Width -= num2;
				rectangleF.Width += num2;
			}
			if (class6003_0[2] != null)
			{
				float num3 = class6003_0[2][0].Width / 2f;
				rect.Height -= num3;
				rectangleF.Height += num3;
			}
			if (class6003_0[3] != null)
			{
				float num4 = class6003_0[3][0].Width / 2f;
				rect.X += num4;
				rect.Width -= num4;
				rectangleF.X -= num4;
				rectangleF.Width += num4;
			}
			PointF pointF = new PointF(rect.X + rect.Height / 2f, rect.Y + rect.Height / 2f);
			PointF pointF2 = new PointF(rect.Right - rect.Height / 2f, rect.Y + rect.Height / 2f);
			if (class6003_0[0] != null)
			{
				Class6217 @class = new Class6217(class6003_0[0][0]);
				@class.Add(smethod_4(double_2, int_12, rect, new PointF(class5702_0.float_0, class5702_0.float_1), new PointF(class5702_0.float_2, class5702_0.float_3)));
				smethod_3(@class, new PointF[4]
				{
					pointF,
					new PointF(rectangleF.Left, rectangleF.Top),
					new PointF(rectangleF.Right, rectangleF.Top),
					pointF2
				});
				CurrentCanvas.Add(@class);
			}
			if (class6003_0[1] != null)
			{
				Class6217 class2 = new Class6217(class6003_0[1][0]);
				class2.Add(smethod_4(double_3, int_12, rect, new PointF(class5702_0.float_2, class5702_0.float_3), new PointF(class5702_0.float_4, class5702_0.float_5)));
				smethod_3(class2, new PointF[3]
				{
					pointF2,
					new PointF(rectangleF.Right, rectangleF.Top),
					new PointF(rectangleF.Right, rectangleF.Bottom)
				});
				CurrentCanvas.Add(class2);
			}
			if (class6003_0[2] != null)
			{
				Class6217 class3 = new Class6217(class6003_0[2][0]);
				class3.Add(smethod_4(double_4, int_12, rect, new PointF(class5702_0.float_4, class5702_0.float_5), new PointF(class5702_0.float_6, class5702_0.float_7)));
				smethod_3(class3, new PointF[4]
				{
					pointF2,
					new PointF(rectangleF.Right, rectangleF.Bottom),
					new PointF(rectangleF.Left, rectangleF.Bottom),
					pointF
				});
				CurrentCanvas.Add(class3);
			}
			if (class6003_0[3] != null)
			{
				Class6217 class4 = new Class6217(class6003_0[3][0]);
				class4.Add(smethod_4(double_5, int_12, rect, new PointF(class5702_0.float_6, class5702_0.float_7), new PointF(class5702_0.float_0, class5702_0.float_1)));
				smethod_3(class4, new PointF[3]
				{
					pointF,
					new PointF(rectangleF.Left, rectangleF.Bottom),
					new PointF(rectangleF.Left, rectangleF.Top)
				});
				CurrentCanvas.Add(class4);
			}
			class6003_0 = new Class6003[4][];
			class5702_0 = null;
		}
	}

	private static Class6218 smethod_4(double[][] points, int[] types, RectangleF rect, PointF ellipseStart, PointF ellipseEnd)
	{
		PointF pointF = PointF.Empty;
		Class6218 @class = new Class6218();
		int num = 0;
		for (int i = 0; i <= points.Length; i++)
		{
			float[] array = new float[6];
			if (i == points.Length)
			{
				break;
			}
			int num2 = 0;
			double[] array2 = points[i];
			float num3 = Math.Min(rect.Width, (i <= 1) ? ellipseStart.X : ellipseEnd.X);
			float num4 = Math.Min(rect.Height, (i <= 1) ? ellipseStart.Y : ellipseEnd.Y);
			for (int j = 0; j < array2.Length; j += 4)
			{
				array[num2++] = (float)((double)rect.X + array2[j] * (double)rect.Width + array2[j + 1] * (double)num3);
				array[num2++] = (float)((double)rect.Y + array2[j + 2] * (double)rect.Height + array2[j + 3] * (double)num4);
			}
			switch (types[i])
			{
			case 0:
				pointF = new PointF(array[0], array[1]);
				break;
			case 1:
			{
				PointF pointF3 = new PointF(array[0], array[1]);
				@class.method_2(pointF, pointF3);
				pointF = pointF3;
				break;
			}
			case 3:
			{
				PointF pointF2 = new PointF(array[4], array[5]);
				Class6222 node = new Class6222(pointF, new PointF(array[0], array[1]), new PointF(array[2], array[3]), pointF2);
				pointF = pointF2;
				@class.Add(node);
				num++;
				break;
			}
			}
		}
		return @class;
	}

	protected override void vmethod_46(float x1, float y1, float x2, float y2, bool horz, bool startOrBefore, int style, Color col, int lineIndex)
	{
		Class6003[] array = method_45(RectangleF.FromLTRB(x1, y1, x2, y2), horz, startOrBefore, style, col);
		if (class5702_0 != null)
		{
			class6003_0[lineIndex] = array;
		}
	}

	internal static DashCap smethod_5(LineCap lineCap)
	{
		if (lineCap == LineCap.Round)
		{
			return DashCap.Round;
		}
		return DashCap.Flat;
	}

	private void method_44(Class6217 path, Class6003 pen, PointF start, PointF end)
	{
		path.Pen = pen;
		Class6218 @class = new Class6218();
		method_46(@class);
		@class.method_2(start, end);
		path.Add(@class);
	}

	private static Class6003 smethod_6(Color color, float width, LineCap cap, LineJoin join, float miterlimit, float[] dash)
	{
		Class6003 @class = new Class6003(Class6153.smethod_1(color));
		@class.Width = width;
		LineCap startCap = (@class.EndCap = cap);
		@class.StartCap = startCap;
		@class.LineJoin = join;
		@class.MiterLimit = miterlimit;
		if (dash != null)
		{
			@class.DashPattern = dash;
			@class.DashCap = smethod_5(cap);
		}
		return @class;
	}

	public Class6003[] method_45(RectangleF lineRect, bool horz, bool startOrBefore, int style, Color col)
	{
		float x = lineRect.X;
		float y = lineRect.Y;
		float x2 = x + lineRect.Width;
		float y2 = y + lineRect.Height;
		float width = lineRect.Width;
		float height = lineRect.Height;
		Class6003[] array = new Class6003[0];
		if (!(width < 0f) && height >= 0f)
		{
			Class6217 @class = new Class6217();
			method_46(@class);
			switch ((Enum679)style)
			{
			case Enum679.const_37:
				if (horz)
				{
					float num10 = Math.Abs(2f * height);
					int num11 = (int)(width / num10);
					if (num11 % 2 == 0)
					{
						num11++;
					}
					num10 = width / (float)num11;
					float y5 = y + height / 2f;
					array = new Class6003[1] { smethod_6(col, height, LineCap.Round, LineJoin.Miter, 10f, new float[2] { 0f, 2f }) };
					if (class5702_0 == null)
					{
						method_44(@class, array[0], new PointF(x, y5), new PointF(x2, y5));
					}
				}
				else
				{
					float num12 = Math.Abs(2f * width);
					int num13 = (int)(height / num12);
					if (num13 % 2 == 0)
					{
						num13++;
					}
					num12 = height / (float)num13;
					float x5 = x + width / 2f;
					array = new Class6003[1] { smethod_6(col, width, LineCap.Round, LineJoin.Miter, 10f, new float[2] { 0f, 2f }) };
					if (class5702_0 == null)
					{
						method_44(@class, array[0], new PointF(x5, y), new PointF(x5, y2));
					}
				}
				break;
			case Enum679.const_38:
				if (horz)
				{
					float num14 = height / 3f;
					float num15 = y + num14 / 2f;
					float y6 = num15 + num14 + num14;
					Class6003[] array4 = new Class6003[1] { smethod_6(col, num14, LineCap.Square, LineJoin.Miter, 10f, null) };
					method_44(@class, array4[0], new PointF(x, num15), new PointF(x2, num15));
					method_44(@class, array4[0], new PointF(x, y6), new PointF(x2, y6));
				}
				else
				{
					float num16 = width / 3f;
					float num17 = x + num16 / 2f;
					float x6 = num17 + num16 + num16;
					Class6003[] array5 = new Class6003[1] { smethod_6(col, num16, LineCap.Square, LineJoin.Miter, 10f, null) };
					method_44(@class, array5[0], new PointF(num17, y), new PointF(num17, y2));
					method_44(@class, array5[0], new PointF(x6, y), new PointF(x6, y2));
				}
				break;
			case Enum679.const_32:
				if (horz)
				{
					float num2 = Math.Abs(2f * height);
					int num3 = (int)(width / num2);
					if (num3 % 2 == 0)
					{
						num3++;
					}
					num2 = width / (float)num3;
					float y4 = y + height / 2f;
					array = new Class6003[1] { smethod_6(col, height, LineCap.Flat, LineJoin.Miter, 10f, new float[2] { 3f, 2f }) };
					if (class5702_0 == null)
					{
						method_44(@class, array[0], new PointF(x, y4), new PointF(x2, y4));
					}
				}
				else
				{
					float num4 = Math.Abs(2f * width);
					int num5 = (int)(height / num4);
					if (num5 % 2 == 0)
					{
						num5++;
					}
					num4 = height / (float)num5;
					float x4 = x + width / 2f;
					array = new Class6003[1] { smethod_6(col, width, LineCap.Flat, LineJoin.Miter, 10f, new float[2] { 3f, 2f }) };
					if (class5702_0 == null)
					{
						method_44(@class, array[0], new PointF(x4, y), new PointF(x4, y2));
					}
				}
				break;
			default:
				if (horz)
				{
					float y7 = y + height / 2f;
					array = new Class6003[1] { smethod_6(col, height, LineCap.Square, LineJoin.Miter, 10f, null) };
					if (class5702_0 == null)
					{
						method_44(@class, array[0], new PointF(x, y7), new PointF(x2, y7));
					}
				}
				else
				{
					float x7 = x + width / 2f;
					array = new Class6003[1] { smethod_6(col, width, LineCap.Square, LineJoin.Miter, 10f, null) };
					if (class5702_0 == null)
					{
						method_44(@class, array[0], new PointF(x7, y), new PointF(x7, y2));
					}
				}
				break;
			case Enum679.const_56:
			case Enum679.const_206:
			{
				float num = ((style == 55) ? 0.4f : (-0.4f));
				if (horz)
				{
					Color color = Class5713.smethod_14(col, 0f - num);
					Color color2 = Class5713.smethod_14(col, num);
					float num6 = height / 3f;
					float num7 = y + num6 / 2f;
					Class6003[] array2 = new Class6003[3]
					{
						smethod_6(color, num6, LineCap.Square, LineJoin.Miter, 10f, null),
						smethod_6(col, num6, LineCap.Square, LineJoin.Miter, 10f, null),
						smethod_6(color2, num6, LineCap.Square, LineJoin.Miter, 10f, null)
					};
					method_44(@class, array2[0], new PointF(x, num7), new PointF(x2, num7));
					method_44(@class, array2[1], new PointF(x, num7 + num6), new PointF(x2, num7 + num6));
					method_44(@class, array2[2], new PointF(x, num7 + num6 + num6), new PointF(x2, num7 + num6 + num6));
				}
				else
				{
					Color color3 = Class5713.smethod_14(col, 0f - num);
					Color color4 = Class5713.smethod_14(col, num);
					float num8 = width / 3f;
					float num9 = x + num8 / 2f;
					Class6003[] array3 = new Class6003[3]
					{
						smethod_6(color3, num8, LineCap.Square, LineJoin.Miter, 10f, null),
						smethod_6(col, num8, LineCap.Square, LineJoin.Miter, 10f, null),
						smethod_6(color4, num8, LineCap.Square, LineJoin.Miter, 10f, null)
					};
					method_44(@class, array3[0], new PointF(num9, y), new PointF(num9, y2));
					method_44(@class, array3[1], new PointF(num9 + num8, y), new PointF(num9 + num8, y2));
					method_44(@class, array3[2], new PointF(num9 + num8 + num8, y), new PointF(num9 + num8 + num8, y2));
				}
				break;
			}
			case Enum679.const_68:
			case Enum679.const_188:
			{
				float num = ((style == 101) ? 0.4f : (-0.4f));
				if (horz)
				{
					col = Class5713.smethod_14(col, (float)(startOrBefore ? 1 : (-1)) * num);
					float y3 = y + height / 2f;
					array = new Class6003[1] { smethod_6(col, height, LineCap.Square, LineJoin.Miter, 10f, null) };
					if (class5702_0 == null)
					{
						method_44(@class, array[0], new PointF(x, y3), new PointF(x2, y3));
					}
				}
				else
				{
					col = Class5713.smethod_14(col, (float)(startOrBefore ? 1 : (-1)) * num);
					float x3 = x + width / 2f;
					array = new Class6003[1] { smethod_6(col, width, LineCap.Square, LineJoin.Miter, 10f, null) };
					if (class5702_0 == null)
					{
						method_44(@class, array[0], new PointF(x3, y), new PointF(x3, y2));
					}
				}
				break;
			}
			case Enum679.const_58:
				break;
			}
			CurrentCanvas.Add(@class);
			return array;
		}
		return array;
	}

	protected override void vmethod_19(Class4948 text)
	{
		int num = int_0;
		if (smethod_7(text))
		{
			vmethod_16(text);
			int num2 = int_0 + text.method_21();
			int num3 = class5358_0.Value + text.method_42() + text.method_58();
			Class5729 @class = method_12(text);
			vmethod_34();
			Class6002 class2 = new Class6002();
			class2.method_8((float)num2 / 1000f, (float)num3 / 1000f);
			method_48(text, class2, @class);
			vmethod_35();
			Class4986 fm = (Class4986)class5730_0.method_22()[@class.method_4()];
			int fontsize = text.method_36(Class5757.int_3);
			method_25(fm, fontsize, text, num3, num2);
		}
		int_0 = num + text.method_14();
	}

	private static bool smethod_7(Class4942 area)
	{
		do
		{
			if (area.method_27() == 0)
			{
				area = area.method_28();
				continue;
			}
			return area.method_27() != 57;
		}
		while (area != null);
		return true;
	}

	protected void method_46(Class6204 node)
	{
		if (stack_2.Count > 0 && stack_2.Peek() is Class6215 @class)
		{
			@class.Tag = (int)@class.Tag + 1;
			if (stack_1.Count > 0)
			{
				node.Id = (string)stack_1.Peek();
			}
		}
	}

	protected virtual void vmethod_47(Class5999 font, Color color, PointF pos, string text, Class6002 at)
	{
		Class6219 @class = new Class6219(font, Class6153.smethod_1(color), Class6153.smethod_1(color), pos, text, font.method_4(text), 0f);
		@class.RenderTransform = at;
		CurrentCanvas.Add(@class);
		method_46(@class);
	}

	protected Class5999 method_47(Class5729 font)
	{
		Class5732 @class = font.method_5();
		byte b = 0;
		int num = @class.method_2();
		string text = @class.method_1();
		if (text == "italic")
		{
			b = (byte)(b | 2u);
		}
		if (num >= 700)
		{
			b = (byte)(b | 1u);
		}
		string text2 = font.method_0().imethod_0();
		Class6730 class2 = Class5939.Instance.method_3(text2, text, num);
		if (class2 != null)
		{
			return new Class5999((float)font.method_6() / 1000f, (FontStyle)b, class2);
		}
		switch (text2)
		{
		case "Courier-Bold":
		case "Courier-BoldOblique":
			text2 = "Courier";
			break;
		case "Helvetica-Bold":
		case "Helvetica-BoldOblique":
			text2 = "Helvetica";
			break;
		}
		return Class6652.Instance.method_3(text2, (float)font.method_6() / 1000f, (FontStyle)b, Class5958.smethod_1(text2));
	}

	public void method_48(Class4948 text, Class6002 at, Class5729 font)
	{
		Color color = (Color)text.method_33(Class5757.int_4);
		Class5999 @class = method_47(font);
		decimal num = 0m;
		Interface208 @interface = new Class5495(text.vmethod_9());
		Class4943 class2;
		while (true)
		{
			if (!@interface.imethod_0())
			{
				return;
			}
			class2 = (Class4943)@interface.imethod_1();
			if (class2 is Class4956)
			{
				Class4956 class3 = (Class4956)class2;
				string text2 = class3.method_51();
				int[] array = class3.method_52();
				float num2 = 0f;
				if (array != null || text.method_55() != 0 || text.method_53() != 0)
				{
					int[] array2 = smethod_8(text2, font, text, array);
					float num3 = 0f;
					for (int i = 0; i < array2.Length; i++)
					{
						num3 += (float)array2[i] / 1000f;
					}
				}
				if (font.method_7() == 131)
				{
					float num4 = @class.TrueTypeFont.method_4(@class.TrueTypeFont.CapHeight, @class.SizePoints);
					float num5 = @class.TrueTypeFont.method_4(@class.TrueTypeFont.XHeight, @class.SizePoints);
					double num6 = (double)num;
					for (int j = 0; j < text2.Length; j++)
					{
						char c = text2[j];
						float num7 = font.method_16(c);
						if (char.IsLower(c))
						{
							c = char.ToUpper(c);
							float num8 = font.method_16(c);
							Class6002 class4 = at.Clone();
							class4.method_6(num7 / num8, num5 / num4);
							double num9 = num8 / num7;
							num9 *= num6 * 1000.0;
							num9 = (int)num9;
							num9 /= 1000.0;
							vmethod_47(@class, color, new PointF((float)num9, 0f), new string(c, 1), class4);
						}
						else
						{
							vmethod_47(@class, color, new PointF((float)num6, 0f), new string(c, 1), at);
						}
						num6 += (double)(num7 / 1000f);
					}
				}
				else
				{
					vmethod_47(@class, color, new PointF((float)num, 0f), text2, at);
				}
				float num10 = @class.method_4(text2).Width + num2;
				num10 *= 1000f;
				num10 = (int)num10;
				num10 /= 1000f;
				num += (decimal)num10;
			}
			else
			{
				if (!(class2 is Class4955))
				{
					break;
				}
				Class4955 class5 = (Class4955)class2;
				string text3 = class5.method_51();
				char c2 = text3[0];
				int num11 = (class5.method_52() ? (text.method_53() + 2 * text.method_55()) : 0);
				num += (decimal)((float)(font.method_16(c2) + num11) / 1000f);
			}
		}
		throw new InvalidOperationException("Unsupported child element: " + class2);
	}

	private static int[] smethod_8(string s, Class5729 font, Class4948 text, int[] letterAdjust)
	{
		int length = s.Length;
		int[] array = new int[length];
		for (int i = 0; i < length; i++)
		{
			char c = s[i];
			char c2 = font.method_14(c);
			int num = (Class5710.smethod_5(c2) ? text.method_53() : 0);
			int num2 = font.method_13(c2);
			int num3 = ((letterAdjust != null && i < length - 1) ? letterAdjust[i + 1] : 0);
			int num4 = ((i < length - 1) ? text.method_55() : 0);
			array[i] = num2 + num3 + num4 + num;
		}
		return array;
	}

	protected override void vmethod_18(Class4953 area)
	{
		vmethod_16(area);
		float num = (float)area.method_56() / 1000f;
		float x = (float)(int_0 + area.method_21()) / 1000f;
		float y = ((float)(class5358_0.Value + area.method_42()) + num / 2f) / 1000f;
		float x2 = (float)(int_0 + area.method_21() + area.method_12()) / 1000f;
		Color color = (Color)area.method_33(Class5757.int_4);
		PointF start = new PointF(x, y);
		PointF end = new PointF(x2, y);
		Class6217 @class = new Class6217();
		Class6003 pen = smethod_6(color, num, LineCap.Square, LineJoin.Miter, 10f, null);
		method_44(@class, pen, start, end);
		CurrentCanvas.Add(@class);
		base.vmethod_18(area);
	}

	public override void vmethod_25(Class4968 image, RectangleF pos)
	{
		RectangleF rect = method_50(new RectangleF(((float)int_0 + pos.X) / 1000f, ((float)class5358_0.Value + pos.Y) / 1000f, pos.Width / 1000f, pos.Height / 1000f));
		string text = method_33(image);
		if (text.Length > 0)
		{
			method_29(text, rect);
		}
		try
		{
			string url = image.method_37();
			method_26(url, pos, isBackground: false);
			method_51(image, rect);
		}
		finally
		{
			if (text.Length > 0)
			{
				method_30();
			}
		}
	}

	protected override void vmethod_45(string uri, RectangleF pos, Hashtable foreignAttributes, bool isBackground)
	{
		uri = Class5409.smethod_0(uri);
		Class5253 @class = imethod_3().method_0().method_14();
		Class5741 class2 = null;
		try
		{
			Interface170 session = imethod_3().method_35();
			class2 = @class.method_0(uri, session);
			if (class2 != null)
			{
				Image image = @class.method_1(class2, session);
				MemoryStream memoryStream = new MemoryStream();
				image.Save(memoryStream, image.RawFormat);
				vmethod_34();
				Class6220 class3 = new Class6220(new PointF(((float)int_0 + pos.X) / 1000f, ((float)class5358_0.Value + pos.Y) / 1000f), new SizeF(pos.Width / 1000f, pos.Height / 1000f), memoryStream.ToArray());
				if (isBackground)
				{
					dictionary_0.Add(class3, value: true);
				}
				Class6213 class4 = new Class6213();
				class4.Add(class3);
				CurrentCanvas.Add(class4);
				method_46(class3);
				vmethod_35();
			}
		}
		catch (IOException)
		{
			Console.Out.WriteLine("Error: Image loading");
		}
	}

	protected override Class5467 vmethod_28(int x, int y, int width, int height, Hashtable foreignAttributes)
	{
		return base.vmethod_28(x, y, width, height, foreignAttributes);
	}

	protected override void vmethod_36()
	{
	}

	protected override void vmethod_37()
	{
	}

	public void method_49(bool transparentPageBackground)
	{
		bool_2 = transparentPageBackground;
	}

	public override void vmethod_27(Class4970 fo, RectangleF pos)
	{
		vmethod_37();
		if (fo.class5089_0 is Class5091 @class)
		{
			int num = int_0;
			int value = class5358_0.Value;
			Class6002 class2 = new Class6002();
			class2.method_8((float)num / 1000f, (float)value / 1000f);
			Class6214 class3 = new Class6214();
			class3.RenderTransform = class2;
			class3.ZIndex = interface181_0;
			for (int i = 0; i < @class.class6216_0.Count; i++)
			{
				class3.Add(@class.class6216_0[i]);
			}
			CurrentCanvas.Add(class3);
		}
	}

	protected RectangleF method_50(RectangleF rect)
	{
		Class6213 @class = CurrentCanvas;
		List<Class6002> list = new List<Class6002>();
		do
		{
			if (@class.RenderTransform != null)
			{
				list.Add(@class.RenderTransform);
			}
			@class = @class.Parent as Class6213;
		}
		while (@class != null);
		Class6002 class2 = new Class6002();
		list.Reverse();
		foreach (Class6002 item in list)
		{
			class2.method_10(item);
		}
		return class2.method_4(rect);
	}

	protected void method_51(Class4942 area, RectangleF rect)
	{
		Class5349 @class = null;
		bool flag = false;
		Class5757.Class5759 class2 = (Class5757.Class5759)area.method_33(Class5757.int_0);
		if (class2 != null)
		{
			flag = true;
			string text = class2.method_1();
			string text2 = class2.method_3();
			bool flag2 = text != null && text.Length > 0;
			if (text2 != null)
			{
				_ = text2.Length > 0;
			}
			else
				_ = 0;
			if (flag2)
			{
			}
		}
		if (!flag)
		{
			Class5757.Class5760 class3 = (Class5757.Class5760)area.method_33(Class5757.int_1);
			if (class3 != null)
			{
				string text3 = class3.method_0();
				if (text3 != null && text3.Length > 0)
				{
					flag = true;
					@class = new Class5351(text3, class3.method_1());
					@class = class5352_0.method_2(@class);
				}
			}
		}
		if (flag && @class != null)
		{
			Interface244 structureTreeElement = (Interface244)area.method_33(Class5757.int_30);
			@class.method_2(structureTreeElement);
			Class5356 value = new Class5356(@class, rect);
			arrayList_3.Add(value);
		}
	}

	protected override void vmethod_22(Class4944 ip)
	{
		RectangleF rect = new RectangleF((float)int_0 / 1000f, (float)class5358_0.Value / 1000f + (float)ip.method_42() / 1000f, (float)ip.method_12() / 1000f, (float)ip.vmethod_1() / 1000f);
		rect = method_50(rect);
		base.vmethod_22(ip);
		method_51(ip, rect);
	}
}
