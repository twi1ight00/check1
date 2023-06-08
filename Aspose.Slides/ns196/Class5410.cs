using System;
using System.Collections;
using ns171;
using ns173;
using ns183;
using ns189;
using ns190;
using ns191;
using ns192;
using ns197;
using ns198;
using ns199;

namespace ns196;

internal class Class5410 : Interface186
{
	internal class Class5411
	{
		public virtual void vmethod_0(Class5088 node, ArrayList lms)
		{
		}
	}

	internal class Class5412 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			Class5172 @class = (Class5172)node;
			if (@class.imethod_0() > 0)
			{
				lms.Add(new Class5313(@class));
			}
		}
	}

	internal class Class5413 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			if (node is Class5101)
			{
				lms.Add(new Class5316((Class5101)node));
			}
		}
	}

	internal class Class5414 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			lms.Add(new Class5315((Class5097)node));
		}
	}

	public class Class5415 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			if (((Class5095)node).method_52() == 95)
			{
				lms.Add(new Class5282((Class5095)node));
			}
			else
			{
				lms.Add(new Class5298((Class5095)node));
			}
		}
	}

	internal class Class5416 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			lms.Add(new Class5318((Class5124)node));
		}
	}

	internal class Class5417 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			lms.Add(new Class5300((Class5114)node));
		}
	}

	internal class Class5418 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			Class5098 @class = (Class5098)node;
			Class5088.Interface163 @interface = @class.vmethod_15();
			Class5088 class2 = null;
			if (@interface != null)
			{
				class2 = @interface.imethod_12();
			}
			if (class2 is Class5161)
			{
				lms.Add(new Class5286((Class5098)node, (Class5161)class2));
			}
			else if (class2 is Class5106)
			{
				lms.Add(new Class5284((Class5098)node, (Class5106)class2));
			}
			else if (class2 is Class5156)
			{
				lms.Add(new Class5288((Class5098)node, (Class5156)class2));
			}
			else if (class2 is Class5160)
			{
				lms.Add(new Class5290((Class5098)node, (Class5160)class2));
			}
			else if (class2 is Class5159)
			{
				lms.Add(new Class5292((Class5098)node, (Class5159)class2));
			}
			else if (class2 is Class5110)
			{
				lms.Add(new Class5304((Class5098)node, (Class5110)class2));
			}
			else
			{
				lms.Add(new Class5317((Class5098)node));
			}
		}
	}

	internal class Class5419 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			lms.Add(new Class5283((Class5106)node));
		}
	}

	internal class Class5420 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			lms.Add(new Class5310((Class5102)node));
		}
	}

	internal class Class5421 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			Class5165 @class = (Class5165)node;
			if (@class.method_51() != 0)
			{
				lms.Add(new Class5309(@class));
			}
		}
	}

	internal class Class5422 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			Class5110 @class = (Class5110)node;
			if (!string.IsNullOrEmpty(@class.method_57()))
			{
				lms.Add(new Class5303(@class));
			}
		}
	}

	internal class Class5423 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			lms.Add(new Class5285((Class5161)node));
		}
	}

	internal class Class5424 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			lms.Add(new Class5289((Class5160)node));
		}
	}

	internal class Class5425 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			lms.Add(new Class5291((Class5159)node));
		}
	}

	internal class Class5426 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			lms.Add(new Class5305((Class5111)node));
		}
	}

	internal class Class5427 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			lms.Add(new Class5311((Class5119)node));
		}
	}

	internal class Class5428 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			lms.Add(new Class5307((Class5121)node));
		}
	}

	internal class Class5429 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			lms.Add(new Class5308((Class5122)node));
		}
	}

	internal class Class5430 : Class5411
	{
		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			Class5156 node2 = (Class5156)node;
			Class5287 value = new Class5287(node2);
			lms.Add(value);
		}
	}

	internal class Class5431 : Class5411
	{
		private Class5410 class5410_0;

		internal Class5431(Class5410 owner)
		{
			class5410_0 = owner;
		}

		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			Interface208 @interface = (Interface208)node.vmethod_15();
			if (@interface != null)
			{
				while (@interface.imethod_0())
				{
					Class5088 node2 = (Class5088)@interface.imethod_1();
					class5410_0.imethod_0(node2, lms);
				}
			}
		}
	}

	internal class Class5432 : Class5411
	{
		private Class5410 class5410_0;

		internal Class5432(Class5410 owner)
		{
			class5410_0 = owner;
		}

		public override void vmethod_0(Class5088 node, ArrayList lms)
		{
			lms.Add(new Class5312((Class5107)node));
			Interface208 @interface = (Interface208)node.vmethod_15();
			if (@interface != null)
			{
				while (@interface.imethod_0())
				{
					Class5088 node2 = (Class5088)@interface.imethod_1();
					class5410_0.imethod_0(node2, lms);
				}
			}
		}
	}

	private Hashtable hashtable_0 = new Hashtable();

	public Class5410()
	{
		method_0();
	}

	protected void method_0()
	{
		method_1(typeof(Class5172), new Class5412());
		method_1(typeof(Class5096), new Class5411());
		method_1(typeof(Class5101), new Class5413());
		method_1(typeof(Class5100), new Class5414());
		method_1(typeof(Class5124), new Class5416());
		method_1(typeof(Class5095), new Class5415());
		method_1(typeof(Class5114), new Class5417());
		method_1(typeof(Class5098), new Class5418());
		method_1(typeof(Class5106), new Class5419());
		method_1(typeof(Class5102), new Class5420());
		method_1(typeof(Class5105), new Class5431(this));
		method_1(typeof(Class5104), new Class5411());
		method_1(typeof(Class5165), new Class5421());
		method_1(typeof(Class5110), new Class5422());
		method_1(typeof(Class5161), new Class5423());
		method_1(typeof(Class5160), new Class5424());
		method_1(typeof(Class5159), new Class5425());
		method_1(typeof(Class5111), new Class5426());
		method_1(typeof(Class5119), new Class5427());
		method_1(typeof(Class5121), new Class5428());
		method_1(typeof(Class5122), new Class5429());
		method_1(typeof(Class5156), new Class5430());
		method_1(typeof(Class5152), new Class5411());
		method_1(typeof(Class5158), new Class5411());
		method_1(typeof(Class5155), new Class5411());
		method_1(typeof(Class5157), new Class5411());
		method_1(typeof(Class5153), new Class5411());
		method_1(typeof(Class5154), new Class5411());
		method_1(typeof(Class5107), new Class5432(this));
		method_1(typeof(Class5099), new Class5414());
	}

	protected void method_1(Type clazz, Class5411 maker)
	{
		hashtable_0.Add(clazz, maker);
	}

	public void imethod_0(Class5088 node, ArrayList lms)
	{
		((Class5411)hashtable_0[node.GetType()])?.vmethod_0(node, lms);
	}

	public Interface173 imethod_1(Class5088 node)
	{
		ArrayList arrayList = new ArrayList();
		imethod_0(node, arrayList);
		if (arrayList.Count == 0)
		{
			throw new InvalidOperationException(string.Concat("LayoutManager for class ", node.GetType(), " is missing."));
		}
		if (arrayList.Count > 1)
		{
			throw new InvalidOperationException(string.Concat("Duplicate LayoutManagers for class ", node.GetType(), " found, only one may be declared."));
		}
		return (Interface173)arrayList[0];
	}

	public Class5322 imethod_2(Class4872 ath, Class5127 ps)
	{
		return new Class5322(ath, ps);
	}

	public Class5321 imethod_3(Class4872 ath, Class5126 ed)
	{
		return new Class5321(ath, ed);
	}

	public Class5297 imethod_4(Class5322 pslm, Class5128 flow)
	{
		return new Class5297(pslm, flow);
	}

	public Class5323 imethod_5(Class5322 pslm, Class5099 title)
	{
		return new Class5323(pslm, title);
	}

	public Class5295 imethod_6(Class5322 pslm, Class5129 sc, Class5136 reg)
	{
		return new Class5295(pslm, sc, reg);
	}

	public Class5295 imethod_7(Class5322 pslm, Class5129 sc, Class4962 block)
	{
		return new Class5295(pslm, sc, block);
	}
}
