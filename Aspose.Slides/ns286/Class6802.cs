using System.Collections.Generic;
using ns284;
using ns287;
using ns301;
using ns305;
using ns84;

namespace ns286;

internal class Class6802
{
	private class Class6803
	{
		public class Class6804
		{
			private Class4337 class4337_0;

			private bool bool_0;

			public Class4337 Width
			{
				get
				{
					return class4337_0;
				}
				set
				{
					class4337_0 = value;
				}
			}

			public bool IsSpecified
			{
				get
				{
					return bool_0;
				}
				set
				{
					bool_0 = value;
				}
			}

			public Class6804(Class4337 width, bool isSpecified)
			{
				Width = width;
				IsSpecified = isSpecified;
			}
		}

		private Class6983 class6983_0;

		private Class4337 class4337_0;

		private IList<Class6804> ilist_0;

		public Class6983 TableBody
		{
			get
			{
				foreach (Class6976 childNode in class6983_0.ChildNodes)
				{
					if (childNode is Class6981 @class && @class.TagName == "TBODY")
					{
						return @class as Class7041;
					}
				}
				return class6983_0;
			}
		}

		public Class7037 Caption
		{
			get
			{
				foreach (Class6976 childNode in class6983_0.ChildNodes)
				{
					if (childNode is Class7037 result)
					{
						return result;
					}
				}
				return null;
			}
		}

		public Class6983 TableHeader
		{
			get
			{
				foreach (Class6976 childNode in class6983_0.ChildNodes)
				{
					if (childNode is Class6983 @class && @class.StyleDeclarationInternal.Display.Value == Enum630.const_9)
					{
						return @class;
					}
				}
				return null;
			}
		}

		public Class6983 TableFooter
		{
			get
			{
				foreach (Class6976 childNode in class6983_0.ChildNodes)
				{
					if (childNode is Class6983 @class && @class.StyleDeclarationInternal.Display.Value == Enum630.const_10)
					{
						return @class;
					}
				}
				return null;
			}
		}

		public Class4337 TableWidth => class4337_0;

		public IList<Class6804> ColumnWidths => ilist_0;

		public Class6803(Class6983 table)
		{
			class6983_0 = table;
		}

		public IList<Class6983> method_0(Class6983 row)
		{
			IList<Class6983> list = new List<Class6983>();
			for (Class6983 @class = row.FirstElementChild as Class6983; @class != null; @class = @class.NextElementSibling as Class6983)
			{
				if (@class.StyleDeclarationInternal.Display.Value == Enum630.const_14)
				{
					list.Add(@class);
				}
			}
			return list;
		}

		public IList<Class6983> method_1()
		{
			IList<Class6983> list = new List<Class6983>();
			for (Class6983 @class = TableBody.FirstElementChild as Class6983; @class != null; @class = (Class6983)@class.NextElementSibling)
			{
				if (@class.StyleDeclarationInternal.Display.Value == Enum630.const_11)
				{
					list.Add(@class);
				}
			}
			return list;
		}

		public IList<Class7039> method_2()
		{
			IList<Class7039> list = new List<Class7039>();
			if (TableBody != null)
			{
				Class7075 @class = class6983_0.method_26("COL");
				foreach (Class7039 item in @class)
				{
					list.Add(item);
				}
			}
			return list;
		}

		public IList<Class6983> method_3()
		{
			IList<Class6983> list = new List<Class6983>();
			for (Class6983 @class = TableHeader.FirstElementChild as Class6983; @class != null; @class = @class.NextElementSibling as Class6983)
			{
				if (@class.StyleDeclarationInternal.Display.Value == Enum630.const_11)
				{
					list.Add(@class);
				}
			}
			return list;
		}

		public IList<Class6983> method_4()
		{
			IList<Class6983> list = new List<Class6983>();
			for (Class6983 @class = TableFooter.FirstElementChild as Class6983; @class != null; @class = @class.NextElementSibling as Class6983)
			{
				if (@class.StyleDeclarationInternal.Display.Value == Enum630.const_11)
				{
					list.Add(@class);
				}
			}
			return list;
		}

		public void method_5()
		{
			if (!class6983_0.StyleDeclarationInternal.Width.IsAuto)
			{
				class4337_0 = class6983_0.StyleDeclarationInternal.Width.Value;
			}
			method_6();
			Class4337 @class = method_8();
			if (@class.Value != 0f)
			{
				class4337_0 = smethod_0(@class, class4337_0);
			}
		}

		private void method_6()
		{
			IList<Class6804> list = new List<Class6804>();
			foreach (Class7039 item in method_2())
			{
				if (!item.StyleDeclarationInternal.Width.IsAuto)
				{
					list.Add(new Class6804(item.StyleDeclarationInternal.Width.Value, isSpecified: true));
				}
			}
			foreach (Class6983 item2 in method_1())
			{
				IList<Class6983> list2 = method_0(item2);
				for (int i = 0; i < list2.Count; i++)
				{
					Class6983 @class = list2[i];
					Class4337 class2 = null;
					bool flag = false;
					if (@class.StyleDeclarationInternal.Width.IsAuto)
					{
						if (class6983_0.StyleDeclarationInternal.TableLayout != 0 || (i < list.Count && !list[i].IsSpecified))
						{
							class2 = method_7(@class);
							flag = false;
						}
					}
					else
					{
						class2 = @class.StyleDeclarationInternal.Width.Value;
						flag = true;
					}
					if (class2 != null)
					{
						if (i >= list.Count)
						{
							list.Add(new Class6804(class2, flag));
						}
						else
						{
							list[i] = new Class6804(smethod_0(list[i].Width, class2), list[i].IsSpecified || flag);
						}
					}
				}
			}
			ilist_0 = list;
		}

		private static Class4337 smethod_0(Class4337 left, Class4337 right)
		{
			if (left == right)
			{
				return left;
			}
			if (object.ReferenceEquals(left, null))
			{
				return right;
			}
			if (object.ReferenceEquals(right, null))
			{
				return left;
			}
			if (left.Type == right.Type)
			{
				if (left.Value > right.Value)
				{
					return left;
				}
				return right;
			}
			if (left.Type == Enum634.const_1)
			{
				return right;
			}
			if (right.Type == Enum634.const_1)
			{
				return left;
			}
			float num = Class6969.smethod_10(Class6969.smethod_8(left.ToString()));
			float num2 = Class6969.smethod_10(Class6969.smethod_8(right.ToString()));
			if (num > num2)
			{
				return left;
			}
			return right;
		}

		private Class4337 method_7(Class6983 element)
		{
			if (element.ChildNodes != null && element.ChildNodes.Length != 0)
			{
				foreach (Class6976 childNode in element.ChildNodes)
				{
					if (childNode is Class6983 @class)
					{
						if (!@class.StyleDeclarationInternal.Width.IsAuto)
						{
							return @class.StyleDeclarationInternal.Width.Value;
						}
						Class4337 class2 = method_7(@class);
						if (class2 != null)
						{
							return class2;
						}
					}
				}
				return null;
			}
			return null;
		}

		public Class4337 method_8()
		{
			float num = 0f;
			for (int i = 0; i < ColumnWidths.Count; i++)
			{
				Class6804 @class = ColumnWidths[i];
				if (@class != null && @class.Width != null && @class.Width.Type != Enum634.const_1)
				{
					num += Class6969.smethod_10(Class6969.smethod_8(@class.Width.ToString()));
				}
			}
			num = Class6969.smethod_15(num);
			return new Class4337(num, Enum634.const_4);
		}
	}

	private Interface325 interface325_0;

	private Class6889 class6889_0;

	private Class6983 class6983_0;

	private Class6772 class6772_0;

	public Class6802(Class6772 builder, Class6983 table, Interface325 htmlVisitor, Class6889 writer)
	{
		class6983_0 = table;
		interface325_0 = htmlVisitor;
		class6889_0 = writer;
		class6772_0 = builder;
	}

	public void Write()
	{
		Class6803 @class = new Class6803(class6983_0);
		@class.method_5();
		if (@class.Caption != null && @class.Caption.StyleDeclarationInternal.CaptionSide == Enum608.const_0)
		{
			class6889_0.method_15(@class.Caption);
			@class.Caption.vmethod_5(interface325_0);
			class6889_0.method_7();
		}
		Class6886 class2 = new Class6886(class6772_0);
		class2.TableLayout = ((class6983_0.StyleDeclarationInternal.TableLayout == Enum617.const_1) ? "auto" : "fixed");
		if (!class6983_0.StyleDeclarationInternal.Width.IsAuto)
		{
			class2.Width = class6983_0.StyleDeclarationInternal.Width.ToString();
		}
		class6889_0.method_45(class6983_0, class2);
		if (class6983_0.StyleDeclarationInternal.TableLayout == Enum617.const_0)
		{
			for (int i = 0; i < @class.ColumnWidths.Count; i++)
			{
				Class6803.Class6804 class3 = @class.ColumnWidths[i];
				class2 = new Class6886(class6772_0);
				if (class3 != null && class3.IsSpecified && class3.Width != null)
				{
					class2.ColumnWidth = class3.Width.ToString();
				}
			}
		}
		if (@class.TableHeader != null)
		{
			class6889_0.method_46();
			foreach (Class6983 item in @class.method_3())
			{
				class6889_0.method_48(item);
				IList<Class6983> list = @class.method_0(item);
				if (list.Count == 0)
				{
					class6889_0.method_52().method_7();
				}
				else
				{
					foreach (Class6983 item2 in list)
					{
						if (item2 is Class7038 class4 && class4.TagName == "TH")
						{
							interface325_0.imethod_34(class4);
						}
						else
						{
							interface325_0.imethod_32(item2);
						}
						foreach (Class6976 childNode in item2.ChildNodes)
						{
							if (childNode.NodeType == Enum969.const_0)
							{
								((Class6983)childNode).vmethod_5(interface325_0);
							}
							else if (childNode.NodeType == Enum969.const_2)
							{
								interface325_0.imethod_19((Class6980)childNode);
							}
						}
						interface325_0.imethod_33(item2);
					}
				}
				class6889_0.method_7();
			}
			class6889_0.method_7();
		}
		class6889_0.method_46();
		foreach (Class6983 item3 in @class.method_1())
		{
			class6889_0.method_48(item3);
			IList<Class6983> list2 = @class.method_0(item3);
			if (list2.Count == 0)
			{
				class6889_0.method_52().method_7();
			}
			else
			{
				foreach (Class6983 item4 in list2)
				{
					if (item4.TagName == "TH")
					{
						interface325_0.imethod_34(item4);
					}
					else
					{
						interface325_0.imethod_32(item4);
					}
					foreach (Class6976 childNode2 in item4.ChildNodes)
					{
						if (childNode2.NodeType == Enum969.const_0)
						{
							((Class6983)childNode2).vmethod_5(interface325_0);
						}
						else if (childNode2.NodeType == Enum969.const_2)
						{
							interface325_0.imethod_19((Class6980)childNode2);
						}
					}
					interface325_0.imethod_33(item4);
				}
			}
			class6889_0.method_7();
		}
		class6889_0.method_7();
		if (@class.TableFooter != null)
		{
			class6889_0.method_46();
			foreach (Class6983 item5 in @class.method_4())
			{
				class6889_0.method_48(item5);
				IList<Class6983> list3 = @class.method_0(item5);
				if (list3.Count == 0)
				{
					class6889_0.method_52().method_7();
				}
				else
				{
					foreach (Class6983 item6 in list3)
					{
						if (item6 is Class7038 class5 && class5.TagName == "TH")
						{
							interface325_0.imethod_34(class5);
						}
						else
						{
							interface325_0.imethod_32(item6);
						}
						foreach (Class6976 childNode3 in item6.ChildNodes)
						{
							if (childNode3.NodeType == Enum969.const_0)
							{
								((Class6983)childNode3).vmethod_5(interface325_0);
							}
							else if (childNode3.NodeType == Enum969.const_2)
							{
								interface325_0.imethod_19((Class6980)childNode3);
							}
						}
						interface325_0.imethod_33(item6);
					}
				}
				class6889_0.method_7();
			}
			class6889_0.method_7();
		}
		class6889_0.method_7();
		if (@class.Caption != null && @class.Caption.StyleDeclarationInternal.CaptionSide == Enum608.const_1)
		{
			class6889_0.method_15(@class.Caption);
			@class.Caption.vmethod_5(interface325_0);
			class6889_0.method_7();
		}
	}
}
