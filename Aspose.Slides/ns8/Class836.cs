using System;
using System.Diagnostics;
using Aspose.Slides.SmartArt;
using ns56;

namespace ns8;

internal class Class836
{
	private Class836 class836_0;

	private Class838 class838_0;

	private Class1073 class1073_0;

	private Struct50 struct50_0;

	private Struct50 struct50_1;

	private Struct50 struct50_2;

	public Class836 Parent => class836_0;

	public Class1073 DataPoint => class1073_0;

	public Enum337 Type => class1073_0.Type;

	public string Text
	{
		get
		{
			if (class1073_0.TextBody == null)
			{
				return string.Empty;
			}
			return class1073_0.TextBody.TextInternal;
		}
	}

	public string ModelId => class1073_0.ModelId;

	public int Level
	{
		get
		{
			if (class836_0 == null)
			{
				return 0;
			}
			Class836 @class = class836_0;
			int num = 1;
			while (@class.class836_0 != null)
			{
				@class = @class.class836_0;
				num++;
			}
			return num;
		}
	}

	public int Position
	{
		get
		{
			if (class836_0 == null)
			{
				return 1;
			}
			int num = 0;
			while (true)
			{
				if (num < class836_0.Children.Count)
				{
					if (class836_0.Children[num] == this)
					{
						break;
					}
					num++;
					continue;
				}
				throw new InvalidOperationException("Invalid state of node. Node are not attached to parent");
			}
			return num + 1;
		}
	}

	public int PositionSameType
	{
		get
		{
			if (class836_0 == null)
			{
				return 1;
			}
			int num = 0;
			int num2 = 0;
			while (true)
			{
				if (num2 < class836_0.Children.Count)
				{
					Class836 @class = class836_0.Children[num2];
					if (@class.Type == Type)
					{
						num++;
					}
					if (@class == this)
					{
						break;
					}
					num2++;
					continue;
				}
				throw new InvalidOperationException("Invalid state of node. Node are not attached to parent");
			}
			return num;
		}
	}

	public int ReversePositionSameType
	{
		get
		{
			if (class836_0 == null)
			{
				return 1;
			}
			int num = 0;
			int num2 = class836_0.Children.Count - 1;
			while (true)
			{
				if (num2 >= 0)
				{
					Class836 @class = class836_0.Children[num2];
					if (@class.Type == Type)
					{
						num++;
					}
					if (@class == this)
					{
						break;
					}
					num2--;
					continue;
				}
				throw new InvalidOperationException("Invalid state of node. Node are not attached to parent");
			}
			return num;
		}
	}

	public bool IsFirst
	{
		get
		{
			if (class836_0 == null)
			{
				return true;
			}
			if (class836_0.Children.Count == 0)
			{
				return false;
			}
			return class836_0.Children[0] == this;
		}
	}

	public bool IsLast
	{
		get
		{
			if (class836_0 == null)
			{
				return true;
			}
			if (class836_0.Children.Count == 0)
			{
				return false;
			}
			return class836_0.Children[class836_0.Children.Count - 1] == this;
		}
	}

	public Class838 Children
	{
		get
		{
			if (class838_0 == null)
			{
				class838_0 = new Class838();
			}
			return class838_0;
		}
	}

	public Class836 Previous
	{
		get
		{
			if (class836_0 != null)
			{
				for (int i = 0; i < class836_0.Children.Count; i++)
				{
					if (i != 0 && class836_0.Children[i] == this)
					{
						return class836_0.Children[i - 1];
					}
				}
			}
			return null;
		}
	}

	public Class836 Next
	{
		get
		{
			if (class836_0 != null)
			{
				for (int i = 0; i < class836_0.Children.Count; i++)
				{
					if (i != class836_0.Children.Count - 1 && class836_0.Children[i] == this)
					{
						return class836_0.Children[i + 1];
					}
				}
			}
			return null;
		}
	}

	public Struct50 CustomLinearFactor => struct50_1;

	public Struct50 CustomNeighborLinearFactor => struct50_2;

	public Struct50 CustomScale
	{
		get
		{
			return struct50_0;
		}
		set
		{
			struct50_0 = value;
		}
	}

	public Class836(Class836 parent, Class1073 point)
	{
		class836_0 = parent;
		class1073_0 = point;
		Class2168 propertySet = class1073_0.PropertySet;
		double num = propertySet.CustScaleX;
		double num2 = propertySet.CustScaleY;
		struct50_0 = new Struct50((num != 0.0) ? (num / 100000.0) : 1.0, (num2 != 0.0) ? (num2 / 100000.0) : 1.0);
		struct50_1 = new Struct50((double)propertySet.CustLinFactX / 100000.0, (double)propertySet.CustLinFactY / 100000.0);
		struct50_2 = new Struct50((double)propertySet.CustLinFactNeighborX / 100000.0, (double)propertySet.CustLinFactNeighborY / 100000.0);
	}

	public Class836(Class836 parent, SmartArtNode point)
		: this(parent, point.ReferencedPoint)
	{
		if (parent != null)
		{
			parent.Children.Add(new Class836(parent, point.ParentTransition));
			parent.Children.Add(this);
		}
		foreach (SmartArtNode childNode in point.ChildNodes)
		{
			new Class836(this, childNode);
		}
		parent?.Children.Add(new Class836(parent, point.SiblingTransition));
	}

	[Conditional("DEBUG")]
	public virtual void Print(string margin)
	{
		Console.WriteLine(margin + $"L:{Level} P:{Position} T:{Type} {Text}");
		foreach (Class836 child in Children)
		{
			_ = child;
		}
	}

	public virtual void vmethod_0(Class840 connections)
	{
		for (int i = 0; i < Children.Count; i++)
		{
			Class836 @class = Children[i];
			if (@class.Type == Enum337.const_1 || @class.Type == Enum337.const_2)
			{
				Class836 class2 = Children[i - 1];
				Class836 class3 = Children[i + 1];
				Class839 class4 = new Class839(Enum330.const_1);
				class4.method_0(class1073_0, connections);
				class4.method_1(@class.class1073_0, connections);
				class4.method_2(class2.class1073_0);
				class4.method_3(class3.class1073_0);
				connections.Add(class4);
				if (@class.Children.Count > 0)
				{
					@class.vmethod_0(connections);
				}
			}
		}
	}

	public void method_0(Class841 points)
	{
		points.Add(class1073_0);
		foreach (Class836 child in Children)
		{
			child.method_0(points);
		}
	}

	public bool method_1(Enum337 pointType, Enum332 elemType)
	{
		switch (elemType)
		{
		case Enum332.const_1:
			return true;
		case Enum332.const_2:
			return pointType == Enum337.const_3;
		case Enum332.const_3:
			if (pointType != Enum337.const_1)
			{
				return pointType == Enum337.const_2;
			}
			return true;
		default:
			return false;
		case Enum332.const_6:
			return pointType == Enum337.const_2;
		case Enum332.const_7:
			return pointType == Enum337.const_1;
		case Enum332.const_8:
			return pointType == Enum337.const_5;
		case Enum332.const_9:
			return pointType == Enum337.const_4;
		case Enum332.const_10:
			return pointType == Enum337.const_6;
		}
	}

	public Class836 method_2()
	{
		if (Type == Enum337.const_3)
		{
			return this;
		}
		if (Type == Enum337.const_5)
		{
			return Parent;
		}
		if (Type == Enum337.const_6)
		{
			return Previous;
		}
		return null;
	}

	public Class836 method_3()
	{
		if (Type == Enum337.const_3)
		{
			return this;
		}
		if (Type == Enum337.const_5)
		{
			return Next;
		}
		if (Type == Enum337.const_6 && class836_0 != null)
		{
			for (int i = 0; i < class836_0.Children.Count; i++)
			{
				if (i != class836_0.Children.Count - 1 && class836_0.Children[i] == this)
				{
					if (class836_0.Children.Count <= i + 2)
					{
						break;
					}
					return class836_0.Children[i + 2];
				}
			}
		}
		return null;
	}

	public Class838 method_4(Class846 filter, bool skipLastTransition)
	{
		return method_5(filter, skipLastTransition, 0, isRecursive: true);
	}

	public Class838 method_5(Class846 filter, bool skipLastTransition, int index, bool isRecursive)
	{
		if (filter.Axis.Count == 0)
		{
			return new Class838();
		}
		Enum332 @enum = ((filter.Types.Count <= 0 || index >= filter.Types.Count) ? Enum332.const_1 : filter.Types[index]);
		if (@enum == Enum332.const_0)
		{
			@enum = Enum332.const_1;
		}
		int num = ((filter.Counts.Count > index) ? filter.Counts[index] : int.MaxValue);
		if (num == 0)
		{
			num = int.MaxValue;
		}
		int start = ((filter.Starts.Count <= index) ? 1 : filter.Starts[index]);
		int step = ((filter.Steps.Count <= index) ? 1 : filter.Steps[index]);
		bool skipLastTransition2 = ((filter.HideLastTransitions.Count <= index) ? skipLastTransition : (filter.HideLastTransitions[index] && skipLastTransition));
		Class838 @class = method_6(filter.Axis[index], @enum, num, start, step, skipLastTransition2);
		if (index + 1 != filter.Axis.Count && isRecursive)
		{
			Class838 class2 = new Class838();
			{
				foreach (Class836 item in @class)
				{
					class2.method_0(item.method_5(filter, skipLastTransition, index + 1, isRecursive));
				}
				return class2;
			}
		}
		return @class;
	}

	private Class838 method_6(Enum117 axisType, Enum332 pointType, int count, int start, int step, bool skipLastTransition)
	{
		Class838 @class = new Class838();
		switch (axisType)
		{
		case Enum117.const_1:
			method_7(@class, pointType);
			break;
		case Enum117.const_2:
			method_8(@class, pointType);
			break;
		case Enum117.const_3:
			method_9(@class, pointType);
			break;
		case Enum117.const_4:
			method_10(@class, pointType, skipLastTransition);
			break;
		case Enum117.const_5:
			method_11(@class, pointType, skipLastTransition);
			break;
		case Enum117.const_6:
			method_12(@class, pointType, skipLastTransition);
			break;
		case Enum117.const_7:
			method_13(@class, pointType, skipLastTransition);
			break;
		case Enum117.const_8:
			method_14(@class, pointType);
			break;
		case Enum117.const_9:
			method_15(@class, pointType, skipLastTransition);
			break;
		case Enum117.const_10:
			method_16(@class, pointType);
			break;
		case Enum117.const_11:
			method_17(@class, pointType);
			break;
		case Enum117.const_12:
			method_18(@class, pointType, skipLastTransition);
			break;
		}
		if (count == 0 && start == 1 && step == 1)
		{
			return @class;
		}
		Class838 class2 = new Class838();
		if (count == int.MaxValue)
		{
			count = @class.Count;
		}
		if (step == 0)
		{
			step = 1;
		}
		if (axisType != Enum117.const_9 && axisType != Enum117.const_10 && step >= 0 && start >= 0)
		{
			if (step <= 0)
			{
				step = 1;
			}
			if (start <= 0)
			{
				start = 1;
			}
			count += start - 1;
			for (int i = start - 1; i < @class.Count && i < count; i += step)
			{
				if (i < @class.Count)
				{
					class2.Add(@class[i]);
				}
			}
		}
		else
		{
			if (step < 0)
			{
				step = -step;
			}
			if (start < 0)
			{
				start = -start;
			}
			int num = 0;
			int num2 = @class.Count - 1 - (start - 1);
			while (num2 >= 0 && num < count)
			{
				if (num2 < @class.Count)
				{
					class2.Add(@class[num2]);
					num++;
				}
				num2 -= step;
			}
		}
		return class2;
	}

	private void method_7(Class838 collection, Enum332 pointType)
	{
		for (Class836 @class = class836_0; @class != null; @class = class836_0)
		{
			if (method_1(@class.Type, pointType))
			{
				collection.Add(@class);
			}
		}
	}

	private void method_8(Class838 collection, Enum332 pointType)
	{
		if (method_1(Type, pointType))
		{
			collection.Add(this);
			method_7(collection, pointType);
		}
	}

	private void method_9(Class838 collection, Enum332 pointType)
	{
		foreach (Class836 child in Children)
		{
			if (method_1(child.Type, pointType))
			{
				collection.Add(child);
			}
		}
	}

	private void method_10(Class838 collection, Enum332 pointType, bool hideLastTransition)
	{
		for (int i = 0; i < Children.Count; i++)
		{
			Class836 @class = Children[i];
			if (method_19(@class, pointType, i, Children.Count, hideLastTransition))
			{
				collection.Add(@class);
			}
			@class.method_10(collection, pointType, hideLastTransition);
		}
	}

	private void method_11(Class838 collection, Enum332 pointType, bool hideLastTransition)
	{
		if (method_1(Type, pointType))
		{
			collection.Add(this);
		}
		method_10(collection, pointType, hideLastTransition);
	}

	private void method_12(Class838 collection, Enum332 pointType, bool hideLastTransition)
	{
		if (class836_0 == null)
		{
			return;
		}
		bool flag = false;
		foreach (Class836 child in class836_0.Children)
		{
			if (flag)
			{
				child.method_11(collection, pointType, hideLastTransition);
			}
			else if (child == this)
			{
				flag = true;
			}
		}
	}

	private void method_13(Class838 collection, Enum332 pointType, bool hideLastTransition)
	{
		if (class836_0 == null)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < class836_0.Children.Count; i++)
		{
			Class836 @class = class836_0.Children[i];
			if (flag)
			{
				if (method_19(@class, pointType, i, class836_0.Children.Count, hideLastTransition))
				{
					collection.Add(@class);
				}
			}
			else if (@class == this)
			{
				flag = true;
			}
		}
	}

	private void method_14(Class838 collection, Enum332 pointType)
	{
		if (class836_0 != null && method_1(class836_0.Type, pointType))
		{
			collection.Add(class836_0);
		}
	}

	private void method_15(Class838 collection, Enum332 pointType, bool hideLastTransition)
	{
		if (class836_0 == null)
		{
			return;
		}
		foreach (Class836 child in class836_0.Children)
		{
			if (child != this)
			{
				child.method_11(collection, pointType, hideLastTransition);
				continue;
			}
			break;
		}
	}

	private void method_16(Class838 collection, Enum332 pointType)
	{
		if (class836_0 == null)
		{
			return;
		}
		foreach (Class836 child in class836_0.Children)
		{
			if (child != this)
			{
				if (method_1(child.Type, pointType))
				{
					collection.Add(child);
				}
				continue;
			}
			break;
		}
	}

	private void method_17(Class838 collection, Enum332 pointType)
	{
		Class836 @class = this;
		while (@class.class836_0 != null)
		{
			@class = @class.class836_0;
		}
		if (method_1(@class.Type, pointType))
		{
			collection.Add(@class);
		}
	}

	private void method_18(Class838 collection, Enum332 pointType, bool hideLastTransition)
	{
		if (method_1(Type, pointType))
		{
			collection.Add(this);
		}
	}

	private bool method_19(Class836 node, Enum332 elemType, int nodePosition, int siblingsCount, bool hideLastTransition)
	{
		bool flag = nodePosition == siblingsCount - 1 && node.Type == Enum337.const_6;
		if (method_1(node.Type, elemType))
		{
			if (hideLastTransition)
			{
				return !flag;
			}
			return true;
		}
		return false;
	}
}
