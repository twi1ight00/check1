using System;
using System.Collections;
using ns183;
using ns197;

namespace ns192;

internal class Class5622 : Interface225
{
	private abstract class Class5623
	{
		protected Class5151 class5151_0;

		protected bool bool_0;

		private Class5706 class5706_0;

		private Class5706 class5706_1;

		protected Class5622 class5622_0;

		internal Class5623(Class5622 parent)
		{
			class5622_0 = parent;
		}

		internal void method_0(ArrayList row, bool withNormal, bool withLeadingTrailing, bool withRest)
		{
			for (int i = 0; i < row.Count; i++)
			{
				Class5158 parent = class5622_0.class5156_0.method_58(i);
				((Class5630)row[i]).method_12(0, parent, withNormal, withLeadingTrailing, withRest);
			}
			class5622_0.bool_0 = false;
		}

		internal void method_1(ArrayList rowBefore, ArrayList rowAfter)
		{
			for (int i = 0; i < rowAfter.Count; i++)
			{
				Class5630 @class = (Class5630)rowAfter[i];
				if (@class.method_5() == 0)
				{
					Class5630 other = (Class5630)rowBefore[i];
					@class.method_11(other, 0);
				}
			}
		}

		internal void method_2(ArrayList row, bool withNormal, bool withLeadingTrailing, bool withRest)
		{
			for (int i = 0; i < row.Count; i++)
			{
				((Class5630)row[i]).method_12(1, class5151_0, withNormal, withLeadingTrailing, withRest);
			}
		}

		internal void method_3(ArrayList row, bool withNormal, bool withLeadingTrailing, bool withRest)
		{
			for (int i = 0; i < row.Count; i++)
			{
				Class5158 parent = class5622_0.class5156_0.method_58(i);
				((Class5630)row[i]).method_12(1, parent, withNormal, withLeadingTrailing, withRest);
			}
		}

		internal void method_4(ArrayList row)
		{
			for (int i = 0; i < class5622_0.class5156_0.method_59(); i++)
			{
				Class5630 @class = (Class5630)row[i];
				Class5722 competitor = (Class5722)class5622_0.arrayList_3[i];
				@class.method_15(0, competitor, withNormal: false, withLeadingTrailing: true, withRest: true);
			}
		}

		internal void method_5(ArrayList row)
		{
			for (int i = 0; i < class5622_0.class5156_0.method_59(); i++)
			{
				Class5630 @class = (Class5630)row[i];
				Class5722 competitor = (Class5722)class5622_0.arrayList_4[i];
				@class.method_15(1, competitor, withNormal: false, withLeadingTrailing: true, withRest: true);
			}
		}

		internal void method_6(Class5151 part)
		{
			class5151_0 = part;
			bool_0 = true;
			class5706_0 = class5622_0.class5711_0.vmethod_1(class5622_0.class5156_0.class5706_0, class5151_0.class5706_0);
			class5706_1 = class5622_0.class5711_0.vmethod_1(class5622_0.class5156_0.class5706_1, class5151_0.class5706_1);
		}

		internal virtual void vmethod_0(ArrayList row, Class5150 container)
		{
			Class5706 @class = class5706_0;
			Class5706 class2 = class5706_1;
			Class5630 class4;
			if (container is Class5155)
			{
				Class5155 class3 = (Class5155)container;
				Interface208 @interface = new Class5495(row);
				while (@interface.imethod_0())
				{
					class4 = (Class5630)@interface.imethod_1();
					bool flag = class4.method_5() == 0;
					bool flag2 = class4.vmethod_4();
					class4.method_12(0, class3, flag, flag, withRest: true);
					class4.method_12(1, class3, flag2, flag2, withRest: true);
				}
				@class = class5622_0.class5711_0.vmethod_1(@class, class3.class5706_0);
				class2 = class5622_0.class5711_0.vmethod_1(class2, class3.class5706_1);
			}
			if (bool_0)
			{
				for (int i = 0; i < row.Count; i++)
				{
					((Class5630)row[i]).method_12(0, class5151_0, withNormal: true, withLeadingTrailing: true, withRest: true);
				}
				bool_0 = false;
			}
			Interface208 interface2 = new Class5495(row);
			class4 = (Class5630)interface2.imethod_1();
			Interface208 interface3 = new Class5495(class5622_0.class5156_0.method_57());
			Class5158 parent = (Class5158)interface3.imethod_1();
			class4.method_13(2, parent);
			class4.method_14(2, @class);
			while (interface2.imethod_0())
			{
				Class5630 class5 = (Class5630)interface2.imethod_1();
				Class5158 class6 = (Class5158)interface3.imethod_1();
				if (class4.vmethod_3())
				{
					class4.method_13(3, parent);
					class5.method_13(2, class6);
					class4.method_11(class5, 3);
				}
				class4 = class5;
				parent = class6;
			}
			class4.method_13(3, parent);
			class4.method_14(3, class2);
		}

		internal virtual void vmethod_1()
		{
			method_2(class5622_0.arrayList_0, withNormal: true, withLeadingTrailing: true, withRest: true);
		}

		internal abstract void vmethod_2();
	}

	private class Class5624 : Class5623
	{
		public Class5624(Class5622 parent)
			: base(parent)
		{
		}

		internal override void vmethod_0(ArrayList row, Class5150 container)
		{
			base.vmethod_0(row, container);
			if (class5622_0.arrayList_0 != null)
			{
				method_1(class5622_0.arrayList_0, row);
			}
			else
			{
				Interface208 @interface = new Class5495(row);
				while (@interface.imethod_0())
				{
					Class5722 class5722_ = ((Class5630)@interface.imethod_1()).class5722_0;
					class5722_.class5706_1 = class5722_.class5706_0;
					class5722_.class5706_2 = class5722_.class5706_0;
				}
				method_0(row, withNormal: true, withLeadingTrailing: false, withRest: true);
			}
			class5622_0.arrayList_0 = row;
		}

		internal override void vmethod_1()
		{
			base.vmethod_1();
			class5622_0.arrayList_3 = new ArrayList(class5622_0.class5156_0.method_59());
			Interface208 @interface = new Class5495(class5622_0.arrayList_0);
			while (@interface.imethod_0())
			{
				Class5722 class5722_ = ((Class5630)@interface.imethod_1()).class5722_1;
				class5722_.class5706_1 = class5722_.class5706_0;
				class5722_.class5706_2 = class5722_.class5706_0;
				class5622_0.arrayList_3.Add(class5722_);
			}
			class5622_0.arrayList_5 = class5622_0.arrayList_0;
		}

		internal override void vmethod_2()
		{
			throw new InvalidOperationException();
		}
	}

	private class Class5625 : Class5623
	{
		public Class5625(Class5622 parent)
			: base(parent)
		{
		}

		internal override void vmethod_0(ArrayList row, Class5150 container)
		{
			base.vmethod_0(row, container);
			if (class5622_0.arrayList_1 == null)
			{
				class5622_0.arrayList_1 = row;
			}
			else
			{
				method_1(class5622_0.arrayList_2, row);
			}
			class5622_0.arrayList_2 = row;
		}

		internal override void vmethod_1()
		{
			method_2(class5622_0.arrayList_2, withNormal: true, withLeadingTrailing: true, withRest: true);
			class5622_0.arrayList_4 = new ArrayList(class5622_0.class5156_0.method_59());
			Interface208 @interface = new Class5495(class5622_0.arrayList_1);
			while (@interface.imethod_0())
			{
				Class5722 class5722_ = ((Class5630)@interface.imethod_1()).class5722_0;
				class5722_.class5706_1 = class5722_.class5706_0;
				class5722_.class5706_2 = class5722_.class5706_0;
				class5622_0.arrayList_4.Add(class5722_);
			}
		}

		internal override void vmethod_2()
		{
			method_1(class5622_0.arrayList_0, class5622_0.arrayList_1);
			Interface208 @interface = new Class5495(class5622_0.arrayList_2);
			while (@interface.imethod_0())
			{
				Class5722 class5722_ = ((Class5630)@interface.imethod_1()).class5722_1;
				class5722_.class5706_1 = class5722_.class5706_0;
				class5722_.class5706_2 = class5722_.class5706_0;
			}
			method_3(class5622_0.arrayList_2, withNormal: true, withLeadingTrailing: false, withRest: true);
		}
	}

	private class Class5626 : Class5623
	{
		private bool bool_1 = true;

		public Class5626(Class5622 parent)
			: base(parent)
		{
		}

		internal override void vmethod_0(ArrayList row, Class5150 container)
		{
			base.vmethod_0(row, container);
			if (class5622_0.bool_0)
			{
				method_0(row, withNormal: true, withLeadingTrailing: true, withRest: true);
			}
			else
			{
				method_1(class5622_0.arrayList_0, row);
				method_4(row);
			}
			method_5(row);
			class5622_0.arrayList_0 = row;
			if (bool_1)
			{
				bool_1 = false;
				Interface208 @interface = new Class5495(row);
				while (@interface.imethod_0())
				{
					Class5630 @class = (Class5630)@interface.imethod_1();
					@class.class5722_0.class5706_1 = @class.class5722_0.class5706_0;
				}
			}
		}

		internal override void vmethod_2()
		{
			if (class5622_0.class5623_2 != null)
			{
				class5622_0.class5623_2.vmethod_2();
			}
			else
			{
				method_3(class5622_0.arrayList_0, withNormal: true, withLeadingTrailing: false, withRest: false);
			}
			Interface208 @interface = new Class5495(class5622_0.arrayList_0);
			while (@interface.imethod_0())
			{
				Class5630 @class = (Class5630)@interface.imethod_1();
				@class.class5722_1.class5706_1 = @class.class5722_1.class5706_0;
			}
		}
	}

	private Class5156 class5156_0;

	private Class5711 class5711_0;

	private ArrayList arrayList_0;

	private bool bool_0;

	private ArrayList arrayList_1;

	private ArrayList arrayList_2;

	private Class5623 class5623_0;

	private Class5623 class5623_1;

	private Class5623 class5623_2;

	private ArrayList arrayList_3;

	private ArrayList arrayList_4;

	private ArrayList arrayList_5;

	internal Class5622(Class5156 table)
	{
		class5623_1 = new Class5626(this);
		class5156_0 = table;
		class5711_0 = Class5711.smethod_0(table.method_71());
		bool_0 = true;
		int num = 0;
		do
		{
			Class5158 @class = table.method_58(num);
			@class.class5722_0.method_2(table.class5722_0, withNormal: true, withLeadingTrailing: false, withRest: true);
			@class.class5722_0.class5706_1 = @class.class5722_0.class5706_2;
			@class.class5722_1.method_2(table.class5722_1, withNormal: true, withLeadingTrailing: false, withRest: true);
			@class.class5722_1.class5706_1 = @class.class5722_1.class5706_2;
			num += @class.method_58();
		}
		while (num < table.method_59());
	}

	public void imethod_0(ArrayList row, Class5150 container)
	{
		class5623_0.vmethod_0(row, container);
	}

	public void imethod_1(Class5151 part)
	{
		if (part is Class5154)
		{
			class5623_0 = new Class5624(this);
		}
		else
		{
			if (arrayList_3 == null || class5156_0.method_62())
			{
				arrayList_3 = new ArrayList(class5156_0.method_59());
				Interface208 @interface = new Class5495(class5156_0.method_57());
				while (@interface.imethod_0())
				{
					Class5722 class5722_ = ((Class5158)@interface.imethod_1()).class5722_0;
					arrayList_3.Add(class5722_);
				}
			}
			if (part is Class5153)
			{
				class5623_2 = new Class5625(this);
				class5623_0 = class5623_2;
			}
			else
			{
				if (arrayList_4 == null || class5156_0.method_63())
				{
					arrayList_4 = new ArrayList(class5156_0.method_59());
					Interface208 interface2 = new Class5495(class5156_0.method_57());
					while (interface2.imethod_0())
					{
						Class5722 class5722_2 = ((Class5158)interface2.imethod_1()).class5722_1;
						arrayList_4.Add(class5722_2);
					}
				}
				class5623_0 = class5623_1;
			}
		}
		class5623_0.method_6(part);
	}

	public void imethod_2()
	{
		class5623_0.vmethod_1();
	}

	public void imethod_3()
	{
		class5623_0.vmethod_2();
		class5623_0 = null;
		if (arrayList_5 != null)
		{
			Interface208 @interface = new Class5495(arrayList_5);
			while (@interface.imethod_0())
			{
				Class5630 @class = (Class5630)@interface.imethod_1();
				@class.class5722_1.class5706_1 = @class.class5722_1.class5706_0;
			}
		}
		if (arrayList_2 != null)
		{
			Interface208 interface2 = new Class5495(arrayList_2);
			while (interface2.imethod_0())
			{
				Class5630 class2 = (Class5630)interface2.imethod_1();
				class2.class5722_1.class5706_1 = class2.class5722_1.class5706_0;
			}
		}
	}
}
