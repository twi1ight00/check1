using System;
using Aspose.Slides;
using ns18;
using ns33;
using ns62;
using ns63;
using ns65;

namespace ns15;

internal class Class1064
{
	internal static void smethod_0(ShapeCollection shapesCollection, Class2639 sourceContainer, Class854 slideDeserializationContext)
	{
		if (sourceContainer is Class2670)
		{
			smethod_1(shapesCollection, (Class2670)sourceContainer, slideDeserializationContext);
			return;
		}
		if (!(sourceContainer is Class2671))
		{
			throw new Exception();
		}
		smethod_2(shapesCollection, (Class2671)sourceContainer, slideDeserializationContext);
	}

	private static void smethod_1(ShapeCollection shapesCollection, Class2670 shapeContainer, Class854 slideDeserializationContext)
	{
		bool flag = false;
		Class2688 documentContainer = slideDeserializationContext.DeserializationContext.DocumentContainer;
		Class2834 shapePrimaryOptions = shapeContainer.ShapePrimaryOptions;
		Enum425 shapeType = shapeContainer.ShapeProp.ShapeType;
		if (shapePrimaryOptions != null)
		{
			flag = shapePrimaryOptions.Properties[Enum426.const_432] is Class2930;
		}
		if (shapeContainer.Pib != 0)
		{
			Class2699 exObjList = documentContainer.ExObjList;
			if (shapeContainer.ClientData != null && shapeContainer.ClientData.ExObjRefAtom != null && exObjList != null)
			{
				uint exObjIdRef = shapeContainer.ClientData.ExObjRefAtom.ExObjIdRef;
				Interface46 @interface = exObjList.method_5(exObjIdRef);
				if (@interface != null && @interface.ExOleObjAtom != null)
				{
					uint persistIdRef = @interface.ExOleObjAtom.PersistIdRef;
					if (slideDeserializationContext.DeserializationContext.PowerPointDocumentStream.method_10(persistIdRef) is Class2771 pptExStg)
					{
						OleObjectFrame oleObjectFrame = (OleObjectFrame)shapesCollection.AddOleObjectFrame(0f, 0f, 0f, 0f, "", (byte[])null);
						Class983.smethod_3(oleObjectFrame);
						Class1044.smethod_13(oleObjectFrame, shapeContainer, @interface, pptExStg, slideDeserializationContext);
						return;
					}
				}
				Class2703 @class = exObjList.method_6(exObjIdRef);
				if (@class != null)
				{
					VideoFrame videoFrame = (VideoFrame)shapesCollection.AddVideoFrame(0f, 0f, 0f, 0f, (string)null);
					Class983.smethod_3(videoFrame);
					Class1040.smethod_17(videoFrame, shapeContainer, @class, slideDeserializationContext);
					return;
				}
				Class2639 class2 = exObjList.method_7(exObjIdRef);
				if (class2 != null)
				{
					Class2704 class3 = class2 as Class2704;
					Class2705 class4 = class2 as Class2705;
					if (class3 != null)
					{
						AudioFrame audioFrame = (AudioFrame)shapesCollection.AddAudioFrameEmbedded(0f, 0f, 0f, 0f, (IAudio)null);
						Class983.smethod_3(audioFrame);
						Class1039.smethod_18(audioFrame, shapeContainer, class3, slideDeserializationContext);
						return;
					}
					if (class4 != null)
					{
						AudioFrame audioFrame2 = (AudioFrame)shapesCollection.AddAudioFrameLinked(0f, 0f, 0f, 0f, "");
						Class983.smethod_3(audioFrame2);
						Class1039.smethod_19(audioFrame2, shapeContainer, class4, slideDeserializationContext);
						return;
					}
				}
				else
				{
					if (exObjList.method_8(exObjIdRef) is Class2698 midiAudio)
					{
						AudioFrame audioFrame3 = (AudioFrame)shapesCollection.AddAudioFrameLinked(0f, 0f, 0f, 0f, "");
						Class983.smethod_3(audioFrame3);
						Class1039.smethod_20(audioFrame3, shapeContainer, midiAudio, slideDeserializationContext);
						return;
					}
					if (exObjList.method_9(exObjIdRef) is Class2691 cdAudio)
					{
						AudioFrame audioFrame4 = (AudioFrame)shapesCollection.AddAudioFrameCD(0f, 0f, 0f, 0f);
						Class983.smethod_3(audioFrame4);
						Class1039.smethod_21(audioFrame4, shapeContainer, cdAudio, slideDeserializationContext);
						return;
					}
				}
			}
			PictureFrame pictureFrame = (PictureFrame)shapesCollection.AddPictureFrame(ShapeType.NotDefined, 0f, 0f, 0f, 0f, null);
			Class983.smethod_3(pictureFrame);
			Class1038.smethod_15(pictureFrame, shapeContainer, slideDeserializationContext);
			return;
		}
		if (shapeType == Enum425.const_75 && flag)
		{
			PictureFrame pictureFrame2 = (PictureFrame)shapesCollection.AddPictureFrame(ShapeType.NotDefined, 0f, 0f, 0f, 0f, null);
			Class983.smethod_3(pictureFrame2);
			Class1038.smethod_15(pictureFrame2, shapeContainer, slideDeserializationContext);
			return;
		}
		switch (shapeType)
		{
		case Enum425.const_20:
		{
			Connector connector2 = (Connector)shapesCollection.AddConnector(ShapeType.Line, 0f, 0f, 0f, 0f, createFromTemplate: false);
			Class983.smethod_3(connector2);
			Class1042.smethod_15(connector2, shapeContainer, slideDeserializationContext);
			break;
		}
		case Enum425.const_0:
		{
			if (shapePrimaryOptions != null && shapePrimaryOptions.Properties.Contains(Enum426.const_62))
			{
				try
				{
					AutoShape autoShape3 = (AutoShape)shapesCollection.AddAutoShape(ShapeType.NotDefined, 0f, 0f, 0f, 0f, createFromTemplate: false);
					Class983.smethod_3(autoShape3);
					Class1041.smethod_15(autoShape3, shapeContainer, slideDeserializationContext);
					break;
				}
				catch (Exception ex2)
				{
					Shape shape2 = new Shape(slideDeserializationContext.DomSlide);
					Class1036.smethod_0(shape2, shapeContainer, slideDeserializationContext);
					shapesCollection.Add(shape2);
					Class1165.smethod_28(ex2);
					break;
				}
			}
			Shape shape3 = new Shape(slideDeserializationContext.DomSlide);
			Class1036.smethod_0(shape3, shapeContainer, slideDeserializationContext);
			shapesCollection.Add(shape3);
			break;
		}
		default:
			if (shapeType >= Enum425.const_32 && shapeType <= Enum425.const_40)
			{
				Connector connector = (Connector)shapesCollection.AddConnector(ShapeType.Line, 0f, 0f, 0f, 0f, createFromTemplate: false);
				Class983.smethod_3(connector);
				Class1042.smethod_15(connector, shapeContainer, slideDeserializationContext);
				break;
			}
			try
			{
				AutoShape autoShape2 = (AutoShape)shapesCollection.AddAutoShape(ShapeType.NotDefined, 0f, 0f, 0f, 0f, createFromTemplate: false);
				Class983.smethod_3(autoShape2);
				Class1041.smethod_15(autoShape2, shapeContainer, slideDeserializationContext);
				break;
			}
			catch (Exception ex)
			{
				Shape shape = new Shape(slideDeserializationContext.DomSlide);
				Class1036.smethod_0(shape, shapeContainer, slideDeserializationContext);
				shapesCollection.Add(shape);
				Class1165.smethod_28(ex);
				break;
			}
		case Enum425.const_1:
		case Enum425.const_3:
		case Enum425.const_75:
		case Enum425.const_202:
		{
			AutoShape autoShape = (AutoShape)shapesCollection.AddAutoShape(ShapeType.NotDefined, 0f, 0f, 0f, 0f, createFromTemplate: false);
			Class983.smethod_3(autoShape);
			Class1041.smethod_15(autoShape, shapeContainer, slideDeserializationContext);
			break;
		}
		}
	}

	private static void smethod_2(ShapeCollection shapesCollection, Class2671 groupShapeContainer, Class854 slideDeserializationContext)
	{
		if (Class1045.smethod_18(groupShapeContainer))
		{
			Table table = new Table(slideDeserializationContext.DomSlide);
			shapesCollection.Add(table);
			Class1045.smethod_16(table, groupShapeContainer, slideDeserializationContext);
		}
		else
		{
			GroupShape domGroupShape = (GroupShape)shapesCollection.AddGroupShape();
			Class1046.smethod_12(domGroupShape, groupShapeContainer, slideDeserializationContext);
		}
	}
}
