using System;
using System.Collections.Generic;
using Aspose.Slides;
using ns16;
using ns56;

namespace ns8;

internal class Class135 : Class116
{
	private List<Class837> list_0;

	public override string Name => LayoutNodeData.Name;

	public List<Class837> Points => list_0;

	public string StyleLabel => LayoutNodeData.StyleLbl;

	private Class2171 LayoutNodeData => (Class2171)base.DataNode;

	public Class135(Class849 tree, Class2171 diagramNode)
	{
		list_0 = new List<Class837>();
	}

	public override void vmethod_0(Class837 parent, Class836 context)
	{
		Class837 @class = new Class837(parent, this, context);
		Class120 class2 = method_2<Class120>(context, @class);
		if (class2 == null)
		{
			return;
		}
		bool flag;
		if (flag = class2.HideLastTransition && context.Type == Enum337.const_6 && context.IsLast)
		{
			Class133 class3 = method_3<Class133>();
			if (class3 != null)
			{
				Class846 filter = class3.Filter;
				if ((filter.HideLastTransitions.Count > 0 && !filter.HideLastTransitions[filter.HideLastTransitions.Count - 1]) || (filter.Axis.Count > 0 && filter.Axis[filter.Axis.Count - 1] == Enum117.const_12))
				{
					flag = false;
				}
			}
		}
		if (flag)
		{
			return;
		}
		parent?.Children.Add(@class);
		class2.Points.Add(@class);
		@class.Algorithm = class2;
		Class136 class4 = method_2<Class136>(context, @class);
		if (class4 != null && (class4.ShapeType != ShapeType.NotDefined || class4.IsConnection))
		{
			@class.ShapeContainer.method_1(base.Tree.Target.Slide, class4);
			Class134 class5 = method_2<Class134>(context, @class);
			Class838 class6 = null;
			if (class5 != null)
			{
				class6 = context.method_4(class5.Filter, class2.HideLastTransition);
			}
			else if (class2 is Class129)
			{
				Class2178 class7 = new Class2178();
				class7.Axis = "self";
				class6 = context.method_4(new Class846(class7), class2.HideLastTransition);
			}
			if (class6 != null)
			{
				foreach (Class836 item in class6)
				{
					@class.ConnectedWith.Add(item);
				}
			}
		}
		foreach (Class116 child in base.Children)
		{
			child.vmethod_0(@class, context);
		}
	}

	public Class1073 method_5(Class836 dataNode)
	{
		Class1073 @class = base.Tree.Target.method_16(dataNode.ModelId, Name);
		if (@class == null)
		{
			Class1341 deserializationContext = new Class1341(base.Tree.Target.Presentation);
			Class2179 class2 = new Class2179();
			class2.delegate2236_0();
			class2.delegate1630_0();
			class2.delegate1705_0();
			@class = new Class1073(class2, base.Tree.Target, deserializationContext);
			@class.ModelId = "{" + Guid.NewGuid().ToString().ToUpper() + "}";
			@class.Type = Enum337.const_4;
			@class.PropertySet.PresName = Name;
			@class.PropertySet.PresStyleLbl = LayoutNodeData.StyleLbl;
		}
		@class.PropertySet.PresAssocID = dataNode.ModelId;
		return @class;
	}

	public void method_6()
	{
		Stack<Class135> stack = new Stack<Class135>();
		stack.Push(this);
		smethod_3(this, stack);
		while (stack.Count != 0)
		{
			Class135 @class = stack.Pop();
			foreach (Class837 point in @class.Points)
			{
				point.method_41();
			}
		}
	}

	public string method_7(Enum118 varType, Class837 point)
	{
		string text = Class137.smethod_3(point.DataPoint.PropertySet.PresLayoutVars, varType);
		if (text != null)
		{
			return text;
		}
		Class837 @class = (Class837)point.Parent;
		while (true)
		{
			if (@class != null)
			{
				text = Class137.smethod_3(@class.DataPoint.PropertySet.PresLayoutVars, varType);
				if (text != null)
				{
					break;
				}
				@class = (Class837)@class.Parent;
				continue;
			}
			return method_9(varType);
		}
		return text;
	}

	public List<Class135> method_8()
	{
		List<Class135> list = new List<Class135>();
		smethod_4(this, list);
		return list;
	}

	protected override void vmethod_1()
	{
		if (string.IsNullOrEmpty(LayoutNodeData.MoveWith))
		{
			return;
		}
		foreach (Class837 item in list_0)
		{
			Class837 @class = (Class837)item.Next;
			if (@class == null && item.Parent != null)
			{
				@class = (Class837)item.Parent.Children[0];
			}
			while (@class != null && @class != item)
			{
				if (!(@class.LayoutNode.Name == LayoutNodeData.MoveWith))
				{
					@class = (Class837)@class.Next;
					if (@class == null && item.Parent != null)
					{
						@class = (Class837)item.Parent.Children[0];
					}
					continue;
				}
				if (!item.ShapeContainer.IsHidden)
				{
					item.CustomScale = @class.CustomScale;
				}
				@class.ShapeContainer.Linked.Add(item.ShapeContainer);
				break;
			}
		}
	}

	private string method_9(Enum118 varType)
	{
		if (varType == Enum118.const_0)
		{
			return null;
		}
		Class116 @class = this;
		string text;
		while (true)
		{
			if (@class != null)
			{
				if (@class is Class135 class2)
				{
					Class137 class3 = null;
					foreach (Class116 child in class2.Children)
					{
						class3 = child as Class137;
						if (class3 != null)
						{
							break;
						}
					}
					if (class3 != null)
					{
						text = class3.method_5(varType);
						if (text != null)
						{
							break;
						}
					}
				}
				@class = @class.Parent;
				continue;
			}
			return null;
		}
		return text;
	}

	private static void smethod_3(Class116 root, Stack<Class135> output)
	{
		foreach (Class116 child in root.Children)
		{
			if (child is Class135 item)
			{
				output.Push(item);
			}
		}
		foreach (Class116 child2 in root.Children)
		{
			smethod_3(child2, output);
		}
	}

	private static void smethod_4(Class116 root, List<Class135> output)
	{
		foreach (Class116 child in root.Children)
		{
			if (child is Class135 item)
			{
				output.Add(item);
			}
			smethod_4(child, output);
		}
	}
}
