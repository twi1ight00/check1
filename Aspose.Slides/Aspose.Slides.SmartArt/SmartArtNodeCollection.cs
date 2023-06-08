using System;
using System.Collections;
using System.Collections.Generic;
using ns16;
using ns56;
using ns8;

namespace Aspose.Slides.SmartArt;

public class SmartArtNodeCollection : ICollection, IEnumerable, IEnumerable<ISmartArtNode>, ISmartArtNodeCollection
{
	private List<ISmartArtNode> list_0;

	private SmartArtNode smartArtNode_0;

	public ISmartArtNode this[int index] => list_0[index];

	public int Count => list_0.Count;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	ICollection ISmartArtNodeCollection.AsICollection => this;

	IEnumerable ISmartArtNodeCollection.AsIEnumerable => this;

	public ISmartArtNode GetNodeByPosition(int position)
	{
		foreach (ISmartArtNode item in list_0)
		{
			if (item.Position == position)
			{
				return item;
			}
		}
		return null;
	}

	public ISmartArtNode AddNode()
	{
		Class1341 deserializationContext = new Class1341(smartArtNode_0.Target.Presentation);
		SmartArtNode result = method_5(deserializationContext);
		smartArtNode_0.Target.method_18(deserializationContext);
		return result;
	}

	public void RemoveNode(int index)
	{
		if (index < 0 || index > list_0.Count - 1)
		{
			throw new ArgumentOutOfRangeException("Index out of range.");
		}
		ISmartArtNode node = list_0[index];
		RemoveNode(node);
	}

	public void RemoveNode(ISmartArtNode node)
	{
		SmartArtNode smartArtNode = (SmartArtNode)node;
		SmartArtNodeCollection smartArtNodeCollection = (SmartArtNodeCollection)smartArtNode.ChildNodes;
		SmartArtNodeCollection smartArtNodeCollection2 = (SmartArtNodeCollection)smartArtNode.Parent.ChildNodes;
		int index = smartArtNodeCollection2.list_0.IndexOf(smartArtNode);
		smartArtNodeCollection2.list_0.Remove(smartArtNode);
		if (smartArtNodeCollection.Count > 0)
		{
			SmartArtNode smartArtNode2 = (SmartArtNode)smartArtNode.ChildNodes[0];
			smartArtNode2.Parent = smartArtNode.Parent;
			smartArtNodeCollection2.list_0.Insert(index, smartArtNode2);
			int index2 = smartArtNodeCollection.list_0.IndexOf(smartArtNode2);
			smartArtNodeCollection.list_0.RemoveAt(index2);
			SmartArtNodeCollection smartArtNodeCollection3 = (SmartArtNodeCollection)smartArtNode2.ChildNodes;
			foreach (SmartArtNode childNode in smartArtNode.ChildNodes)
			{
				if (childNode != smartArtNode2)
				{
					childNode.Parent = smartArtNode2;
					smartArtNodeCollection3.list_0.Add(childNode);
				}
			}
		}
		smartArtNode_0.Target.method_17();
	}

	public bool RemoveNodeByPosition(int position)
	{
		if (GetNodeByPosition(position) is SmartArtNode smartArtNode)
		{
			smartArtNode.Remove();
			return true;
		}
		return false;
	}

	public ISmartArtNode AddNodeByPosition(int position)
	{
		if (position < 0)
		{
			throw new ArgumentOutOfRangeException("Position can not be less than 0");
		}
		Class1341 deserializationContext = new Class1341(smartArtNode_0.Target.Presentation);
		SmartArtNode smartArtNode = method_5(deserializationContext);
		int num = list_0.IndexOf(smartArtNode);
		if (num != position && position < list_0.Count)
		{
			list_0.RemoveAt(num);
			list_0.Insert(position, smartArtNode);
		}
		smartArtNode_0.Target.method_18(deserializationContext);
		return smartArtNode;
	}

	IEnumerator<ISmartArtNode> IEnumerable<ISmartArtNode>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		list_0.CopyTo((SmartArtNode[])array, index);
	}

	internal SmartArtNodeCollection(SmartArtNode parent)
	{
		list_0 = new List<ISmartArtNode>();
		smartArtNode_0 = parent;
	}

	internal SmartArtNode AddNode(Class1073 referenced, Class1073 parentTransition, Class1073 siblingTransition)
	{
		SmartArtNode smartArtNode = new SmartArtNode(smartArtNode_0, smartArtNode_0.Target);
		smartArtNode.ReferencedPoint = referenced;
		smartArtNode.ParentTransition = parentTransition;
		smartArtNode.SiblingTransition = siblingTransition;
		((SmartArtNodeCollection)smartArtNode_0.ChildNodes).list_0.Add(smartArtNode);
		return smartArtNode;
	}

	internal void method_0()
	{
		list_0.Clear();
		method_1(smartArtNode_0);
	}

	private void method_1(ISmartArtNode parent)
	{
		foreach (ISmartArtNode childNode in parent.ChildNodes)
		{
			list_0.Add(childNode);
			method_1(childNode);
		}
	}

	internal int method_2(ISmartArtNode node)
	{
		return list_0.IndexOf(node);
	}

	internal void method_3(ISmartArtNode node, int position)
	{
		int num = list_0.IndexOf(node);
		if (num != -1 && num != position)
		{
			list_0.RemoveAt(num);
			list_0.Insert(position, node);
		}
		smartArtNode_0.Target.method_17();
	}

	private Class2179 method_4(Enum337 type)
	{
		Class2179 @class = new Class2179();
		@class.ModelId = "{" + Guid.NewGuid().ToString().ToUpper() + "}";
		@class.Type = type;
		if (type == Enum337.const_1 || type == Enum337.const_2)
		{
			@class.delegate2236_0();
		}
		@class.delegate1630_0();
		return @class;
	}

	private SmartArtNode method_5(Class1341 deserializationContext)
	{
		Class1073 referenced = new Class1073(method_4(Enum337.const_1), smartArtNode_0.Target, deserializationContext);
		Class1073 parentTransition = new Class1073(method_4(Enum337.const_5), smartArtNode_0.Target, deserializationContext);
		Class1073 siblingTransition = new Class1073(method_4(Enum337.const_6), smartArtNode_0.Target, deserializationContext);
		return AddNode(referenced, parentTransition, siblingTransition);
	}
}
