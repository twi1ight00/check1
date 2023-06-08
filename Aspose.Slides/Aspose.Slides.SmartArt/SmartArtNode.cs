using System;
using System.Collections.Generic;
using ns56;
using ns8;

namespace Aspose.Slides.SmartArt;

public class SmartArtNode : ISmartArtNode
{
	private SmartArt smartArt_0;

	private SmartArtNode smartArtNode_0;

	private SmartArtNodeCollection smartArtNodeCollection_0;

	private Class1073 class1073_0;

	private Class1073 class1073_1;

	private Class1073 class1073_2;

	private List<Class837> list_0;

	public ISmartArtNodeCollection ChildNodes => smartArtNodeCollection_0;

	public ISmartArtShapeCollection Shapes
	{
		get
		{
			SmartArtShapeCollection smartArtShapeCollection = new SmartArtShapeCollection();
			foreach (Class837 item in list_0)
			{
				if (item.ShapeContainer.Shape != null && (!item.ShapeContainer.IsHidden || (item.AssociatedWith.Type != Enum337.const_5 && item.AssociatedWith.Type != Enum337.const_6)))
				{
					smartArtShapeCollection.Add(item.ShapeContainer.Shape);
				}
			}
			return smartArtShapeCollection;
		}
	}

	public ITextFrame TextFrame
	{
		get
		{
			return class1073_0.TextBody;
		}
		set
		{
			if (!(value is TextFrame textBody))
			{
				throw new ArgumentException("Value must be instance of class Aspose.Slides.TextFrame");
			}
			class1073_0.TextBody = textBody;
		}
	}

	public bool IsAssistant
	{
		get
		{
			return class1073_0.Type == Enum337.const_2;
		}
		set
		{
			Enum337 @enum = ((!value) ? Enum337.const_1 : Enum337.const_2);
			if (class1073_0.Type != @enum)
			{
				class1073_0.Type = @enum;
				smartArt_0.method_17();
			}
		}
	}

	public int Level
	{
		get
		{
			if (smartArtNode_0 == null)
			{
				return -1;
			}
			return smartArtNode_0.Level + 1;
		}
	}

	public IFillFormat BulletFillFormat
	{
		get
		{
			SmartArtShape smartArtShape = null;
			foreach (Class837 item in list_0)
			{
				if (item.ShapeContainer.HasImagePlaceholder)
				{
					smartArtShape = item.ShapeContainer.Shape;
					break;
				}
			}
			return smartArtShape?.FillFormat;
		}
	}

	public int Position
	{
		get
		{
			if (smartArtNode_0 == null)
			{
				return 0;
			}
			SmartArtNodeCollection smartArtNodeCollection = (SmartArtNodeCollection)smartArtNode_0.ChildNodes;
			return smartArtNodeCollection.method_2(this);
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("Position can not be less than 0");
			}
			if (smartArtNode_0 != null)
			{
				SmartArtNodeCollection smartArtNodeCollection = (SmartArtNodeCollection)smartArtNode_0.ChildNodes;
				if (smartArtNode_0.ChildNodes.Count <= value)
				{
					throw new ArgumentOutOfRangeException("Position can not be equal to or greater than siblings count");
				}
				smartArtNodeCollection.method_3(this, value);
			}
		}
	}

	internal Class1073 ReferencedPoint
	{
		get
		{
			return class1073_0;
		}
		set
		{
			class1073_0 = value;
		}
	}

	internal Class1073 ParentTransition
	{
		get
		{
			return class1073_1;
		}
		set
		{
			class1073_1 = value;
		}
	}

	internal Class1073 SiblingTransition
	{
		get
		{
			return class1073_2;
		}
		set
		{
			class1073_2 = value;
		}
	}

	internal SmartArtNode Parent
	{
		get
		{
			return smartArtNode_0;
		}
		set
		{
			smartArtNode_0 = value;
		}
	}

	internal SmartArt Target => smartArt_0;

	public bool Remove()
	{
		if (smartArtNode_0 != null)
		{
			smartArtNode_0.ChildNodes.RemoveNode(this);
			return true;
		}
		return false;
	}

	internal SmartArtNode(SmartArtNode parent, SmartArt target)
	{
		smartArt_0 = target;
		smartArtNode_0 = parent;
		smartArtNodeCollection_0 = new SmartArtNodeCollection(this);
		list_0 = new List<Class837>();
	}

	internal void method_0(List<Class837> allPoints)
	{
		list_0.Clear();
		foreach (Class837 allPoint in allPoints)
		{
			if (allPoint.ConnectedWith.Count > 0)
			{
				foreach (Class836 item in allPoint.ConnectedWith)
				{
					if (method_1(item.ModelId))
					{
						list_0.Add(allPoint);
						break;
					}
				}
			}
			else if (method_1(allPoint.AssociatedWith.ModelId))
			{
				list_0.Add(allPoint);
			}
		}
		foreach (SmartArtNode item2 in smartArtNodeCollection_0)
		{
			item2.method_0(allPoints);
		}
	}

	private bool method_1(string id)
	{
		if (!(class1073_0.ModelId == id) && (class1073_1 == null || !(class1073_1.ModelId == id)))
		{
			if (class1073_2 != null)
			{
				return class1073_2.ModelId == id;
			}
			return false;
		}
		return true;
	}
}
