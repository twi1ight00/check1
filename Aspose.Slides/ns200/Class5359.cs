using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using ns173;
using ns175;
using ns176;
using ns181;
using ns184;
using ns187;

namespace ns200;

internal abstract class Class5359 : Interface177
{
	protected Class5738 class5738_0;

	protected Class5358 class5358_0 = new Class5358(0);

	protected int int_0;

	protected int int_1;

	protected Class4974 class4974_0;

	protected Interface181 interface181_0 = Class5041.smethod_0(Class5042.smethod_0(9, "AUTO"));

	protected static Interface181 interface181_1 = Class5041.smethod_0(Class5042.smethod_0(9, "AUTO"));

	protected Class4971 class4971_0;

	public abstract void imethod_4(Class5730 fontInfo);

	public Class5359(Class5738 userAgent)
	{
		class5738_0 = userAgent;
	}

	public virtual Class5738 imethod_3()
	{
		return class5738_0;
	}

	public abstract string imethod_0();

	public virtual void imethod_1(Stream outputStream)
	{
		if (class5738_0 == null)
		{
			throw new InvalidOperationException("FOUserAgent has not been set on Renderer");
		}
	}

	public virtual void imethod_2()
	{
	}

	public bool imethod_5()
	{
		return false;
	}

	public virtual void imethod_6(CultureInfo locale)
	{
	}

	public virtual void imethod_7(Interface157 odi)
	{
	}

	protected Class4974 method_0()
	{
		return class4974_0;
	}

	public void imethod_8(Class4974 page)
	{
	}

	protected string method_1(Class4972 title)
	{
		ArrayList children = title.method_39();
		string text = method_2(children);
		return text.Trim();
	}

	private string method_2(ArrayList children)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < children.Count; i++)
		{
			Class4943 @class = (Class4943)children[i];
			if (@class is Class4948)
			{
				stringBuilder.Append(((Class4948)@class).vmethod_10());
			}
			else if (@class is Class4944)
			{
				stringBuilder.Append(method_2(((Class4944)@class).vmethod_9()));
			}
			else
			{
				stringBuilder.Append(" ");
			}
		}
		return stringBuilder.ToString();
	}

	public void imethod_9(Class4972 seqTitle)
	{
	}

	public virtual void imethod_10(Class4975 pageSequence)
	{
	}

	public virtual void imethod_11(Class4974 page)
	{
		class4974_0 = page;
		try
		{
			Class4973 page2 = page.method_12();
			method_3(page2);
		}
		finally
		{
			class4974_0 = null;
		}
	}

	protected void method_3(Class4973 page)
	{
		Class4971 @class = page.method_11(57);
		if (@class != null)
		{
			vmethod_0(@class);
		}
		@class = page.method_11(61);
		if (@class != null)
		{
			vmethod_0(@class);
		}
		@class = page.method_11(59);
		if (@class != null)
		{
			vmethod_0(@class);
		}
		@class = page.method_11(56);
		if (@class != null)
		{
			vmethod_0(@class);
		}
		@class = page.method_11(58);
		if (@class != null)
		{
			vmethod_0(@class);
		}
	}

	protected virtual void vmethod_0(Class4971 port)
	{
		class5358_0.Value = 0;
		int_0 = 0;
		Class4964 @class = port.method_38();
		vmethod_3(port);
		vmethod_1(@class.method_39(), port.imethod_1());
		if (@class.method_41() == 58)
		{
			class4971_0 = port;
			method_5((Class4965)@class);
			class4971_0 = null;
		}
		else
		{
			method_4(@class);
		}
		vmethod_2();
	}

	protected abstract void vmethod_1(Class5492 ctm, RectangleF clippingRect);

	protected abstract void vmethod_2();

	protected virtual void vmethod_3(Class4971 rv)
	{
	}

	protected void method_4(Class4964 region)
	{
		vmethod_12(null, region.method_40());
	}

	protected void method_5(Class4965 region)
	{
		Class4958 @class = region.method_49();
		if (@class != null)
		{
			vmethod_5(@class);
		}
		Class4959 class2 = region.method_44();
		if (class2 != null)
		{
			vmethod_4(class2);
		}
		Class4966 class3 = region.method_47();
		if (class3 != null)
		{
			vmethod_7(class3);
		}
		Class4960 class4 = region.method_50();
		if (class4 != null)
		{
			vmethod_6(class4);
		}
	}

	protected virtual void vmethod_4(Class4959 bf)
	{
		ArrayList arrayList = bf.method_37();
		if (arrayList != null)
		{
			vmethod_12(null, arrayList);
		}
	}

	protected virtual void vmethod_5(Class4958 bf)
	{
		ArrayList arrayList = bf.method_37();
		if (arrayList != null)
		{
			vmethod_12(null, arrayList);
			Class4962 @class = bf.method_43();
			if (@class != null)
			{
				vmethod_13(@class);
			}
		}
	}

	protected virtual void vmethod_6(Class4960 footnote)
	{
		class5358_0.Value += footnote.method_45();
		ArrayList arrayList = footnote.method_37();
		if (arrayList != null)
		{
			Class4962 @class = footnote.method_43();
			if (@class != null)
			{
				vmethod_13(@class);
			}
			vmethod_12(null, arrayList);
		}
	}

	protected virtual void vmethod_7(Class4966 mr)
	{
		Class4967 @class = null;
		ArrayList arrayList = mr.method_38();
		class5358_0.Save();
		int value = class5358_0.Value;
		int num = int_0;
		for (int i = 0; i < arrayList.Count; i++)
		{
			@class = (Class4967)arrayList[i];
			int num2 = @class.method_18();
			if (num2 < 0)
			{
				num2 = 0;
			}
			if ((num2 & 1) == 1)
			{
				int_0 += @class.method_12();
				int_0 += mr.method_43();
			}
			for (int j = 0; j < @class.method_38(); j++)
			{
				Class4961 class2 = @class.method_41(j);
				if (class2 != null)
				{
					class5358_0.Value = value;
					if ((num2 & 1) == 1)
					{
						int_0 -= class2.method_12();
						int_0 -= mr.method_43();
					}
					vmethod_8(class2);
					if ((num2 & 1) == 0)
					{
						int_0 += class2.method_12();
						int_0 += mr.method_43();
					}
				}
			}
			int_0 = num;
			class5358_0.Value = value + @class.method_40();
			value = class5358_0.Value;
		}
		class5358_0.method_0();
	}

	protected virtual void vmethod_8(Class4961 flow)
	{
		ArrayList arrayList = flow.method_37();
		if (arrayList != null)
		{
			vmethod_12(null, arrayList);
		}
	}

	protected virtual void vmethod_9(Class4962 block)
	{
	}

	protected virtual void vmethod_10(Class4963 bv, ArrayList children)
	{
		if (bv.method_45() == 2)
		{
			int num = int_0;
			class5358_0.Save();
			RectangleF clippingRect = RectangleF.Empty;
			if (bv.imethod_0())
			{
				clippingRect = new RectangleF(num, class5358_0.Value, bv.method_12(), bv.vmethod_1());
			}
			Class5492 ctm = bv.method_50();
			int_0 = 0;
			class5358_0.Value = 0;
			vmethod_1(ctm, clippingRect);
			vmethod_9(bv);
			vmethod_12(bv, children);
			vmethod_2();
			int_0 = num;
			class5358_0.method_0();
		}
		else
		{
			int num2 = int_0;
			class5358_0.Save();
			vmethod_9(bv);
			vmethod_12(bv, children);
			int_0 = num2;
			class5358_0.method_0();
			class5358_0.Value += bv.method_15();
		}
	}

	protected abstract void vmethod_11(Class4962 block);

	protected virtual void vmethod_12(Class4962 parent, ArrayList blocks)
	{
		int num = int_0;
		if (parent != null && parent != null && !parent.method_35(Class5757.int_25))
		{
			class5358_0.Value += parent.method_19();
		}
		_ = class5358_0.Value;
		int num2 = int_0;
		int_1 = int_0;
		for (int i = 0; i < blocks.Count; i++)
		{
			object obj = blocks[i];
			if (obj is Class4962)
			{
				int_0 = num2;
				int_0 += ((Class4962)obj).XOffset;
				int_1 = num2;
				vmethod_13((Class4962)obj);
				int_1 = num2;
			}
			else if (obj is Class4972)
			{
				Class4972 @class = (Class4972)obj;
				if (parent != null)
				{
					int num3 = parent.method_21();
					int num4 = parent.method_22();
					int num5 = parent.method_18();
					if (num5 != -1 && ((uint)num5 & (true ? 1u : 0u)) != 0)
					{
						int_0 += parent.method_48() - num4;
					}
					else
					{
						int_0 += parent.method_47() - num3;
					}
				}
				int_0 += @class.XOffset;
				vmethod_14(@class);
				class5358_0.Value += @class.method_15();
			}
			int_0 = num;
		}
	}

	protected virtual void vmethod_13(Class4962 block)
	{
		Interface181 @interface = (Interface181)block.method_33(Class5757.int_36);
		if (@interface != null)
		{
			interface181_0 = @interface;
		}
		else
		{
			interface181_0 = interface181_1;
		}
		@interface = (Interface181)block.method_33(Class5757.int_39);
		@interface = (Interface181)block.method_33(Class5757.int_40);
		ArrayList arrayList = block.method_37();
		if (block is Class4963)
		{
			if (arrayList != null)
			{
				vmethod_10((Class4963)block, arrayList);
				return;
			}
			if (block.method_27() != 57)
			{
				vmethod_9(block);
			}
			class5358_0.Value += block.method_15();
			return;
		}
		if (block.method_35(Class5757.int_24))
		{
			vmethod_11(block);
			return;
		}
		int num = int_0;
		class5358_0.Save();
		int_0 += block.method_40();
		class5358_0.Value += block.method_41();
		class5358_0.Value += block.method_23();
		vmethod_9(block);
		if (arrayList != null)
		{
			vmethod_12(block, arrayList);
		}
		if (block.method_45() == 2)
		{
			class5358_0.method_0();
			return;
		}
		int_0 = num;
		class5358_0.method_0();
		class5358_0.Value += block.method_15();
	}

	protected virtual void vmethod_14(Class4972 line)
	{
		ArrayList arrayList = line.method_39();
		class5358_0.Save();
		class5358_0.Value += line.method_23();
		int num = line.method_18();
		if (num >= 0)
		{
			if ((num & 1) == 0)
			{
				int_0 += line.method_40();
			}
			else
			{
				int_0 += line.method_41();
				int num2 = smethod_0(line);
				if (num2 > 0)
				{
					int_0 -= num2;
				}
			}
		}
		else
		{
			int_0 += line.method_40();
		}
		int i = 0;
		for (int count = arrayList.Count; i < count; i++)
		{
			Class4943 inlineArea = (Class4943)arrayList[i];
			vmethod_15(inlineArea);
		}
		class5358_0.method_0();
	}

	private static int smethod_0(Class4972 line)
	{
		ArrayList arrayList = line.method_39();
		int num = 0;
		int i = 0;
		for (int count = arrayList.Count; i < count; i++)
		{
			Class4943 @class = (Class4943)arrayList[i];
			num += @class.method_12();
		}
		return num - line.method_12();
	}

	protected virtual void vmethod_15(Class4943 inlineArea)
	{
		if (inlineArea is Class4948)
		{
			vmethod_19((Class4948)inlineArea);
		}
		else if (inlineArea is Class4956)
		{
			vmethod_20((Class4956)inlineArea);
		}
		else if (inlineArea is Class4955)
		{
			vmethod_21((Class4955)inlineArea);
		}
		else if (inlineArea is Class4944)
		{
			vmethod_22((Class4944)inlineArea);
		}
		else if (inlineArea is Class4950)
		{
			vmethod_23((Class4950)inlineArea);
		}
		else if (inlineArea is Class4954)
		{
			vmethod_17((Class4954)inlineArea);
		}
		else if (inlineArea is Class4951)
		{
			vmethod_24((Class4951)inlineArea);
		}
		else if (inlineArea is Class4953)
		{
			vmethod_18((Class4953)inlineArea);
		}
	}

	protected abstract void vmethod_16(Class4943 area);

	protected virtual void vmethod_17(Class4954 space)
	{
		vmethod_16(space);
		int_0 += space.method_14();
	}

	protected virtual void vmethod_18(Class4953 area)
	{
		int_0 += area.method_14();
	}

	protected virtual void vmethod_19(Class4948 text)
	{
		ArrayList arrayList = text.vmethod_9();
		int num = int_0;
		int i = 0;
		for (int count = arrayList.Count; i < count; i++)
		{
			Class4943 inlineArea = (Class4943)arrayList[i];
			vmethod_15(inlineArea);
		}
		int_0 = num + text.method_14();
	}

	protected virtual void vmethod_20(Class4956 word)
	{
		int_0 += word.method_14();
	}

	protected virtual void vmethod_21(Class4955 space)
	{
		int_0 += space.method_14();
	}

	protected virtual void vmethod_22(Class4944 ip)
	{
		int num = ip.method_18();
		ArrayList arrayList = ip.vmethod_9();
		vmethod_16(ip);
		int num2 = int_0;
		class5358_0.Save();
		int num4;
		if (ip is Class4946 && ((uint)num & (true ? 1u : 0u)) != 0)
		{
			int num3 = 0;
			int i = 0;
			for (int count = arrayList.Count; i < count; i++)
			{
				Class4943 @class = (Class4943)arrayList[i];
				num3 += @class.method_14();
			}
			num4 = ip.method_14() - num3;
		}
		else
		{
			num4 = 0;
		}
		if (num != -1 && ((uint)num & (true ? 1u : 0u)) != 0)
		{
			int_0 += ip.method_22();
			if (num4 > 0)
			{
				int_0 += num4;
			}
		}
		else
		{
			int_0 += ip.method_21();
		}
		class5358_0.Value += ip.method_42();
		int j = 0;
		for (int count2 = arrayList.Count; j < count2; j++)
		{
			Class4943 inlineArea = (Class4943)arrayList[j];
			vmethod_15(inlineArea);
		}
		int_0 = num2 + ip.method_14();
		class5358_0.method_0();
	}

	protected virtual void vmethod_23(Class4950 ibp)
	{
		int num = ibp.method_18();
		vmethod_16(ibp);
		if (num != -1 && ((uint)num & (true ? 1u : 0u)) != 0)
		{
			int_0 += ibp.method_22();
		}
		else
		{
			int_0 += ibp.method_21();
		}
		class5358_0.Save();
		class5358_0.Value += ibp.method_42();
		vmethod_13(ibp.method_51());
		class5358_0.method_0();
	}

	protected virtual void vmethod_24(Class4951 viewport)
	{
		Class4942 @class = viewport.method_55();
		class5358_0.Save();
		class5358_0.Value += viewport.method_42();
		RectangleF pos = viewport.method_53();
		if (@class is Class4968)
		{
			vmethod_25((Class4968)@class, pos);
		}
		else if (@class is Class4969)
		{
			vmethod_26((Class4969)@class);
		}
		else if (@class is Class4970)
		{
			vmethod_27((Class4970)@class, pos);
		}
		else if (@class is Class4950)
		{
			vmethod_23((Class4950)@class);
		}
		int_0 += viewport.method_14();
		class5358_0.method_0();
	}

	public virtual void vmethod_25(Class4968 image, RectangleF pos)
	{
	}

	public virtual void vmethod_26(Class4969 cont)
	{
		int num = int_0;
		class5358_0.Save();
		ArrayList blocks = cont.method_38();
		vmethod_12(null, blocks);
		int_0 = num;
		class5358_0.method_0();
	}

	public virtual void vmethod_27(Class4970 fo, RectangleF pos)
	{
	}

	public void method_6(Class5467 ctx, XmlDocument doc, string @namespace)
	{
		throw new NotImplementedException();
	}

	protected Matrix method_7(Matrix at)
	{
		float[] elements = at.Elements;
		elements[4] /= 1000f;
		elements[5] /= 1000f;
		return new Matrix(elements[0], elements[1], elements[2], elements[3], elements[4], elements[5]);
	}

	protected Matrix method_8(Matrix at)
	{
		float[] elements = at.Elements;
		elements[4] = (float)Math.Round(elements[4] * 1000f);
		elements[5] = (float)Math.Round(elements[5] * 1000f);
		return new Matrix(elements[0], elements[1], elements[2], elements[3], elements[4], elements[5]);
	}
}
