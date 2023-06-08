using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;
using ns22;
using ns60;
using ns62;
using ns63;

namespace ns15;

internal class Class1048
{
	internal static void smethod_0(BaseSlide domSlide, List<Class2623> shapesSource, Class854 slideDeserializationContext)
	{
		Class2671 groupShapeContainer = slideDeserializationContext.GroupShapeContainer;
		domSlide.slideShowTransition_0 = new SlideShowTransition(domSlide);
		List<Class2623> records = slideDeserializationContext.DrawingContainer.OfficeArtDg.Records;
		List<Class2951> subFrames = slideDeserializationContext.SubFrames;
		Class262 baseSlidePPTUnsupportedProps = domSlide.BaseSlidePPTUnsupportedProps;
		Class2728 @class = (Class2728)slideDeserializationContext.ProgTags;
		if (@class != null)
		{
			if (@class.PP10SlideBinaryTagExtension != null)
			{
				baseSlidePPTUnsupportedProps.SlideProgTagsContainer_PP10SlideBinaryTagExtension_RgTextMasterStyleAtom = @class.PP10SlideBinaryTagExtension.RgTextMasterStyleAtom;
				baseSlidePPTUnsupportedProps.SlideProgTagsContainer_PP10SlideBinaryTagExtension_LinkedSlideAtom = @class.PP10SlideBinaryTagExtension.LinkedSlideAtom;
				baseSlidePPTUnsupportedProps.SlideProgTagsContainer_PP10SlideBinaryTagExtension_RgLinkedShape10Atom = @class.PP10SlideBinaryTagExtension.RgLinkedShape10Atom;
				baseSlidePPTUnsupportedProps.SlideProgTagsContainer_PP10SlideBinaryTagExtension_SlideFlagsAtom = @class.PP10SlideBinaryTagExtension.SlideFlagsAtom;
				baseSlidePPTUnsupportedProps.SlideProgTagsContainer_PP10SlideBinaryTagExtension_SlideTimeAtom = @class.PP10SlideBinaryTagExtension.SlideTimeAtom;
				baseSlidePPTUnsupportedProps.SlideProgTagsContainer_PP10SlideBinaryTagExtension_HashCodeAtom = @class.PP10SlideBinaryTagExtension.HashCodeAtom;
				baseSlidePPTUnsupportedProps.SlideProgTagsContainer_PP10SlideBinaryTagExtension_BuildListContainer = @class.PP10SlideBinaryTagExtension.BuildListContainer;
				smethod_1(domSlide, @class.PP10SlideBinaryTagExtension.RgComment10Container, slideDeserializationContext.DeserializationContext.DomPresentation);
			}
			if (@class.PP12SlideBinaryTagExtension != null)
			{
				baseSlidePPTUnsupportedProps.SlideProgTagsContainer_PP12SlideBinaryTagExtension_RoundTripHeaderFooterDefaultsAtom = @class.PP12SlideBinaryTagExtension.RoundTripHeaderFooterDefaultsAtom;
			}
		}
		for (uint num = 0u; num < subFrames.Count; num++)
		{
			for (int i = 0; i < shapesSource.Count; i++)
			{
				if (!(shapesSource[i] is Class2670 class2))
				{
					continue;
				}
				Class2642 clientTextBox = class2.ClientTextBox;
				if (clientTextBox != null && clientTextBox.Header.IsContainer && clientTextBox.Header.Length > 0)
				{
					if (clientTextBox.ContentRecords.HaveOutlinedText && clientTextBox.ContentRecords.OutlineTextRef == num)
					{
						Class2951 subTextFrame = subFrames[(int)num];
						slideDeserializationContext.FrameToPlaceholder.Add(class2, new Class852(num, subTextFrame, class2));
					}
				}
				else if (!slideDeserializationContext.FrameToPlaceholder.ContainsKey(class2) && class2.ClientData != null && class2.ClientData.PlaceholderAtom != null)
				{
					slideDeserializationContext.FrameToPlaceholder.Add(class2, new Class852(uint.MaxValue, null, class2));
				}
			}
		}
		domSlide.class518_0 = Class1063.smethod_0(domSlide, slideDeserializationContext);
		domSlide.groupShape_0 = new GroupShape(domSlide);
		Class1046.smethod_14(domSlide.groupShape_0, groupShapeContainer.Records, slideDeserializationContext);
		for (int j = 0; j < records.Count; j++)
		{
			if (records[j] is Class2670 class3)
			{
				Class2835 shapeProp = class3.ShapeProp;
				if (shapeProp != null && shapeProp.FBackground)
				{
					Class1047.smethod_0((Background)domSlide.Background, class3, slideDeserializationContext);
				}
			}
		}
		if (domSlide.Background != null && (slideDeserializationContext.SlideAtom.FMasterBackground || (domSlide.Background.Type == BackgroundType.OwnBackground && domSlide.Background.FillFormat.FillType == FillType.NoFill)))
		{
			domSlide.Background.Type = BackgroundType.NotDefined;
		}
		Class881.smethod_0(domSlide.CustomData, slideDeserializationContext.ProgTags);
		smethod_2(domSlide);
		Class231.smethod_0(domSlide, slideDeserializationContext);
	}

	private static void smethod_1(BaseSlide domSlide, Class2685[] rgComment10Container, Presentation domPresentation)
	{
		if (rgComment10Container == null || rgComment10Container.Length < 1)
		{
			return;
		}
		ISlide slide = (ISlide)domSlide;
		if (slide != null)
		{
			ICommentAuthorCollection commentAuthors = domPresentation.CommentAuthors;
			foreach (Class2685 @class in rgComment10Container)
			{
				ICommentAuthor[] array = commentAuthors.FindByNameAndInitials(@class.Author, @class.Initials);
				ICommentAuthor commentAuthor = ((array.Length <= 0) ? commentAuthors.AddAuthor(@class.Author, @class.Initials) : array[0]);
				PointF position = new PointF((float)@class.CommentAtom.Anchor.X / 12700f, (float)@class.CommentAtom.Anchor.Y / 12700f);
				commentAuthor.Comments.AddComment(@class.Text, (ISlide)domSlide, position, @class.CommentAtom.DateTime);
			}
		}
	}

	internal static void smethod_2(BaseSlide slide)
	{
		SortedList<uint, Shape> sortedList = new SortedList<uint, Shape>();
		List<Shape> list = new List<Shape>();
		sortedList.Add(slide.groupShape_0.ShapeId, slide.groupShape_0);
		smethod_3(slide.groupShape_0.Shapes, sortedList, list);
		uint num = 1u;
		for (int i = 0; i < list.Count; i++)
		{
			for (; sortedList.ContainsKey(num); num++)
			{
			}
			Shape shape = list[i];
			shape.method_10(num++);
			sortedList.Add(shape.ShapeId, shape);
		}
		slide.method_11(sortedList.Keys[sortedList.Count - 1] + 1, check: false);
		slide.class518_0.method_2(slide);
	}

	private static void smethod_3(IShapeCollection shapes, SortedList<uint, Shape> map, List<Shape> nonUniqueIdShapes)
	{
		foreach (Shape shape in shapes)
		{
			if (!map.ContainsKey(shape.ShapeId))
			{
				map.Add(shape.ShapeId, shape);
				map[shape.ShapeId] = shape;
				if (shape is GroupShape)
				{
					smethod_3(((GroupShape)shape).Shapes, map, nonUniqueIdShapes);
				}
				continue;
			}
			nonUniqueIdShapes.Add(shape);
			throw new Exception("Found a shapes with identical IDs!!!");
		}
	}
}
