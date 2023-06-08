using System.Collections.Generic;
using System.Drawing.Drawing2D;
using ns11;
using ns16;
using ns18;
using ns224;
using ns26;
using ns4;
using ns56;
using ns8;

namespace Aspose.Slides.SmartArt;

public class SmartArt : GraphicalObject, IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGraphicalObject, ISmartArt
{
	private SmartArtNode smartArtNode_0;

	private Class849 class849_0;

	private Class840 class840_0;

	private Class841 class841_0;

	private bool bool_1;

	public ISmartArtNodeCollection AllNodes
	{
		get
		{
			SmartArtNodeCollection smartArtNodeCollection = new SmartArtNodeCollection(smartArtNode_0);
			smartArtNodeCollection.method_0();
			return smartArtNodeCollection;
		}
	}

	public SmartArtLayoutType Layout => Class1033.smethod_0(LayoutIdInternal);

	public SmartArtQuickStyleType QuickStyle
	{
		get
		{
			return Class1033.smethod_1(QuickStyleIdInternal);
		}
		set
		{
			QuickStyleIdInternal = Class1033.smethod_2(value);
			Class1033 @class = new Class1033();
			@class.method_2(this, value);
			class849_0.method_5();
		}
	}

	public SmartArtColorType ColorStyle
	{
		get
		{
			return Class1033.smethod_3(ColorIdInternal);
		}
		set
		{
			ColorIdInternal = Class1033.smethod_4(value);
			Class1033 @class = new Class1033();
			@class.method_3(this, value);
			class849_0.method_5();
		}
	}

	internal string LayoutIdInternal => PPTXUnsupportedProps.DocNodePtElementData.PrSet.LoTypeId;

	internal new Class290 PPTXUnsupportedProps => (Class290)base.PPTXUnsupportedProps;

	IGraphicalObject ISmartArt.AsIGraphicalObject => this;

	private string QuickStyleIdInternal
	{
		get
		{
			return PPTXUnsupportedProps.DocNodePtElementData.PrSet.QsTypeId;
		}
		set
		{
			PPTXUnsupportedProps.DocNodePtElementData.PrSet.QsTypeId = value;
		}
	}

	private string ColorIdInternal
	{
		get
		{
			return PPTXUnsupportedProps.DocNodePtElementData.PrSet.CsTypeId;
		}
		set
		{
			PPTXUnsupportedProps.DocNodePtElementData.PrSet.CsTypeId = value;
		}
	}

	internal SmartArt(IBaseSlide parent)
		: base(parent, new Class290())
	{
		PPTXUnsupportedProps.ShapesRoot = new GroupShape(parent);
		lineFormat_0 = new LineFormat(this);
	}

	internal SmartArt(IBaseSlide parent, SmartArtLayoutType layoutType)
		: this(parent)
	{
		Class1341 deserializationContext = new Class1341(parent.Presentation);
		Class1033 @class = new Class1033();
		@class.method_0(this, layoutType);
		method_20(deserializationContext);
		@class.method_1(this, layoutType);
		@class.method_2(this, SmartArtQuickStyleType.SimpleFill);
		@class.method_3(this, SmartArtColorType.ColoredFillAccent1);
		method_22(deserializationContext);
	}

	internal override void vmethod_4(Class159 canvas, Class169 rc)
	{
		if (base.Hidden)
		{
			return;
		}
		if (base.HLinkClick != null)
		{
			canvas.vmethod_16(base.HLinkClick);
		}
		ShapeFrame shapeFrame = method_4();
		if (!float.IsNaN(shapeFrame.X) && !float.IsNaN(shapeFrame.Y) && !float.IsNaN(shapeFrame.Width) && !float.IsNaN(shapeFrame.Height))
		{
			Class6002 transform = (canvas.Transform = Shape.smethod_0(shapeFrame));
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(shapeFrame.Rectangle);
			Class67 arguments = new Class67(shapeFrame, canvas.Transform, graphicsPath, base.Slide, rc);
			canvas.vmethod_5(graphicsPath, null, new Class63(arguments, fillFormat_0));
			method_19();
			IShapeCollection shapes = PPTXUnsupportedProps.ShapesRoot.Shapes;
			bool flag = PPTXUnsupportedProps.DrawingElementData != null && shapes.Count != 0;
			bool flag2 = false;
			if (!bool_1 && flag)
			{
				flag2 = true;
				ISmartArtNodeCollection allNodes = AllNodes;
				foreach (SmartArtNode item in allNodes)
				{
					if (item.ReferencedPoint.IsTextChanged_OldMode)
					{
						flag2 = false;
						break;
					}
				}
			}
			class849_0.RootShape.Frame = shapeFrame;
			class849_0.RootShape.RawFrameImpl.method_5(0.0, 0.0, shapeFrame.Width, shapeFrame.Height);
			if (!flag2)
			{
				class849_0.method_4();
			}
			class849_0.method_5();
			if (flag)
			{
				foreach (IShape item2 in shapes)
				{
					AutoShape autoShape = item2 as AutoShape;
					Class837 class2 = class849_0.method_3(autoShape.PPTXUnsupportedProps.ModelId);
					if (class2 != null && autoShape != null)
					{
						Class1073 class3 = ((class2.ConnectedWith.Count > 0) ? class2.ConnectedWith[0].DataPoint : class2.DataPoint);
						class3.method_2(autoShape, class2.ShapeContainer.Shape.AutoShapeInternal);
					}
				}
			}
			class849_0.RootShape.vmethod_4(canvas, rc);
			canvas.Transform = transform;
			canvas.vmethod_5(graphicsPath, new Class66(arguments, lineFormat_0), null);
			if (flag)
			{
				class849_0.method_5();
			}
		}
		if (base.HLinkClick != null)
		{
			canvas.vmethod_17();
		}
	}

	internal void method_14(Class1341 deserializationContext)
	{
		method_20(deserializationContext);
		method_22(deserializationContext);
		method_23();
	}

	internal void method_15(Class1346 serializationContext)
	{
		if (PPTXUnsupportedProps.DataModelElementData.Bg == null)
		{
			PPTXUnsupportedProps.DataModelElementData.delegate1291_0();
		}
		Class949.smethod_1(fillFormat_0, PPTXUnsupportedProps.DataModelElementData.Bg.delegate2773_1, serializationContext);
		if (PPTXUnsupportedProps.DataModelElementData.Whole == null)
		{
			PPTXUnsupportedProps.DataModelElementData.delegate1807_0();
		}
		if (PPTXUnsupportedProps.DataModelElementData.Whole.Ln == null)
		{
			PPTXUnsupportedProps.DataModelElementData.Whole.delegate1504_0();
		}
		Class968.smethod_3(lineFormat_0, PPTXUnsupportedProps.DataModelElementData.Whole.Ln);
		method_19();
		foreach (Class1073 item in class841_0)
		{
			item.method_3(serializationContext);
		}
	}

	internal Class1073 method_16(string modelID, string layoutNode)
	{
		return class841_0.method_1(modelID, layoutNode);
	}

	internal void method_17()
	{
		method_18(new Class1341(base.Presentation));
	}

	internal void method_18(Class1341 deserializationContext)
	{
		method_19();
		method_22(deserializationContext);
		bool_1 = true;
	}

	private void method_19()
	{
		SmartArtNodeCollection smartArtNodeCollection = (SmartArtNodeCollection)AllNodes;
		foreach (SmartArtNode item in smartArtNodeCollection)
		{
			foreach (SmartArtShape shape in item.Shapes)
			{
				shape.method_0();
			}
		}
	}

	private void method_20(Class1341 deserializationContext)
	{
		Class2143 dataModelElementData = PPTXUnsupportedProps.DataModelElementData;
		class841_0 = new Class841(dataModelElementData.PtLst, this, deserializationContext);
		class840_0 = new Class840(dataModelElementData.CxnLst);
		smartArtNode_0 = new SmartArtNode(null, this);
		smartArtNode_0.ReferencedPoint = class841_0.method_0(null, Enum337.const_3);
		PPTXUnsupportedProps.DocNodePtElementData = Class1073.smethod_2(smartArtNode_0.ReferencedPoint);
		method_21(smartArtNode_0, smartArtNode_0.ReferencedPoint);
	}

	private void method_21(SmartArtNode parent, Class1073 parentPoint)
	{
		List<Class839> list = new List<Class839>();
		foreach (Class839 item in class840_0)
		{
			if (item.SourcePointId == parentPoint.ModelId && item.Type == Enum330.const_1)
			{
				list.Add(item);
			}
		}
		list.Sort();
		foreach (Class839 item2 in list)
		{
			Class1073 @class = class841_0.method_0(item2.DestinationPointId, Enum337.const_1);
			if (@class == null)
			{
				@class = class841_0.method_0(item2.DestinationPointId, Enum337.const_2);
			}
			Class1073 parentTransition = class841_0.method_0(item2.ParentTransitionPointId, Enum337.const_5);
			Class1073 siblingTransition = class841_0.method_0(item2.SiblingTransitionPointId, Enum337.const_6);
			SmartArtNode parent2 = ((SmartArtNodeCollection)parent.ChildNodes).AddNode(@class, parentTransition, siblingTransition);
			method_21(parent2, @class);
		}
	}

	private void method_22(Class1341 deserializationContext)
	{
		Class2143 @class = new Class2143();
		@class.delegate2224_0();
		Class841 class2 = new Class841(@class.PtLst, this, deserializationContext);
		Class840 class3 = new Class840(@class.CxnLst);
		Class2168 propertySet = smartArtNode_0.ReferencedPoint.PropertySet;
		Class2168 prSet = PPTXUnsupportedProps.DocNodePtElementData.PrSet;
		propertySet.LoTypeId = prSet.LoTypeId;
		propertySet.LoCatId = prSet.LoCatId;
		propertySet.QsTypeId = prSet.QsTypeId;
		propertySet.QsCatId = prSet.CsCatId;
		propertySet.CsTypeId = prSet.CsTypeId;
		propertySet.CsCatId = prSet.CsCatId;
		propertySet.Phldr = prSet.Phldr;
		Class836 class4 = new Class836(null, smartArtNode_0);
		class4.method_0(class2);
		class4.vmethod_0(class3);
		class849_0 = new Class849(this, PPTXUnsupportedProps.LayoutDefElementData.LayoutNode, class4, deserializationContext);
		class849_0.method_0(class2);
		class849_0.method_1(class3);
		class849_0.method_2(smartArtNode_0);
		PPTXUnsupportedProps.DataModelElementData = @class;
		class840_0 = class3;
		class841_0 = class2;
	}

	private void method_23()
	{
		IShapeCollection shapes = PPTXUnsupportedProps.ShapesRoot.Shapes;
		foreach (IShape item in shapes)
		{
			AutoShape autoShape = item as AutoShape;
			Class837 @class = class849_0.method_3(autoShape.PPTXUnsupportedProps.ModelId);
			if (@class == null || autoShape == null)
			{
				continue;
			}
			@class.ShapeContainer.method_0(autoShape);
			if (bool_1 || autoShape.TextFrame == null)
			{
				continue;
			}
			string text = autoShape.TextFrame.Text.Replace("\r", "").Replace("\n", "");
			string text2 = string.Empty;
			foreach (Class836 item2 in @class.ConnectedWith)
			{
				text2 += item2.Text.Replace("\r", "").Replace("\n", "");
			}
			if (text2 != text)
			{
				bool_1 = true;
			}
		}
	}
}
