using System.Collections;
using ns183;

namespace ns192;

internal class Class5629 : Class5627
{
	private interface Interface226
	{
		void imethod_0(Class5627 rowGroupBuilder);
	}

	internal class Class5638 : Interface226
	{
		private Class5157 class5157_0;

		public Class5638(Class5157 cell)
		{
			class5157_0 = cell;
		}

		public void imethod_0(Class5627 rowGroupBuilder)
		{
			rowGroupBuilder.vmethod_0(class5157_0);
		}
	}

	internal class Class5639 : Interface226
	{
		private Class5155 class5155_0;

		public Class5639(Class5155 tableRow)
		{
			class5155_0 = tableRow;
		}

		public void imethod_0(Class5627 rowGroupBuilder)
		{
			rowGroupBuilder.vmethod_1(class5155_0);
		}
	}

	internal class Class5640 : Interface226
	{
		public void imethod_0(Class5627 rowGroupBuilder)
		{
			rowGroupBuilder.vmethod_2();
		}
	}

	internal class Class5641 : Interface226
	{
		private Class5151 class5151_0;

		public Class5641(Class5151 part)
		{
			class5151_0 = part;
		}

		public void imethod_0(Class5627 rowGroupBuilder)
		{
			rowGroupBuilder.vmethod_3(class5151_0);
		}
	}

	internal class Class5642 : Interface226
	{
		private Class5151 class5151_0;

		public Class5642(Class5151 part)
		{
			class5151_0 = part;
		}

		public void imethod_0(Class5627 rowGroupBuilder)
		{
			rowGroupBuilder.vmethod_4(class5151_0);
		}
	}

	internal class Class5643 : Interface226
	{
		public void imethod_0(Class5627 rowGroupBuilder)
		{
			rowGroupBuilder.vmethod_5();
		}
	}

	private ArrayList arrayList_0 = new ArrayList();

	internal Class5629(Class5156 t)
		: base(t)
	{
	}

	internal override void vmethod_0(Class5157 cell)
	{
		arrayList_0.Add(new Class5638(cell));
	}

	internal override void vmethod_1(Class5155 tableRow)
	{
		arrayList_0.Add(new Class5639(tableRow));
	}

	internal override void vmethod_2()
	{
		arrayList_0.Add(new Class5640());
	}

	internal override void vmethod_3(Class5151 part)
	{
		arrayList_0.Add(new Class5641(part));
	}

	internal override void vmethod_4(Class5151 part)
	{
		arrayList_0.Add(new Class5642(part));
	}

	internal override void vmethod_5()
	{
		arrayList_0.Add(new Class5643());
	}

	internal override void vmethod_6()
	{
		Class5627 @class = new Class5628(class5156_0);
		Interface208 @interface = new Class5495(arrayList_0);
		while (@interface.imethod_0())
		{
			((Interface226)@interface.imethod_1()).imethod_0(@class);
		}
		@class.vmethod_6();
	}
}
