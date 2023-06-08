using System.Collections.Generic;
using Aspose.Slides;
using ns18;
using ns53;
using ns55;
using ns56;

namespace ns16;

internal class Class1026
{
	private static void smethod_0(IPresentation srcPresentation, IPresentation destPresentation, Enum168 deserializationMode, out Class1184 tempPackage, out Class1346 serializationContext, out Class1341 deserializationContext)
	{
		tempPackage = new Class1184();
		serializationContext = new Class1346(tempPackage, srcPresentation, null);
		serializationContext.Mode = ((srcPresentation == destPresentation) ? Enum167.const_1 : Enum167.const_2);
		deserializationContext = new Class1341(destPresentation);
		deserializationContext.Mode = deserializationMode;
	}

	public static ISlide smethod_1(IPresentation destPresentation, ILayoutSlide destLayout, ISlide sourceSlide)
	{
		if (sourceSlide == null)
		{
			return null;
		}
		smethod_0(sourceSlide.Presentation, destPresentation, Enum168.const_1, out var tempPackage, out var serializationContext, out var deserializationContext);
		Class1342 @class = null;
		serializationContext.SlideToSlidePartPath.Add(sourceSlide, "/ppt/slides/slide" + serializationContext.method_28() + ".xml");
		Class1342 class2 = Class1028.smethod_3(tempPackage, sourceSlide, serializationContext);
		if (sourceSlide.NotesSlide != null && destPresentation.MasterNotesSlideManager.MasterNotesSlide == null)
		{
			@class = Class1028.smethod_2(tempPackage, sourceSlide.Presentation, serializationContext);
		}
		serializationContext.method_0(deserializationContext);
		Slide slide = ((SlideCollection)destPresentation.Slides).method_1();
		Class1196 class3 = new Class1196(class2, deserializationContext);
		class3.method_7(slide);
		slide.BaseSlidePPTXUnsupportedProps.SlideId = ((Presentation)destPresentation).PPTXUnsupportedProps.method_0();
		deserializationContext.SlidePartPathToSlide.Add(class2.PartPath, slide);
		Class1347[] array = class2.Relationships.method_0(Class1246.class1338_0);
		if (array != null && array.Length > 0)
		{
			if (@class != null)
			{
				Class1192 class4 = new Class1192(@class, deserializationContext);
				IMasterNotesSlide masterNotesSlide = ((Presentation)destPresentation).MasterNotesSlideManager.SetDefaultMasterNotesSlide();
				class4.method_7(masterNotesSlide);
				deserializationContext.SlidePartPathToSlide.Add(@class.PartPath, masterNotesSlide);
			}
			Class1193 class5 = new Class1193(array[0].TargetPart, deserializationContext);
			class5.method_7(slide.AddNotesSlide());
		}
		if (serializationContext.Mode == Enum167.const_2)
		{
			smethod_2(slide, sourceSlide);
		}
		slide.method_17(destLayout);
		((SlideCollection)destPresentation.Slides).Add(slide);
		Class1027.smethod_1(tempPackage, destPresentation, deserializationContext);
		Class1027.smethod_3(tempPackage, destPresentation, deserializationContext);
		return slide;
	}

	private static void smethod_2(ISlide slideDest, ISlide sourceSlide)
	{
		IComment[] slideComments = sourceSlide.GetSlideComments(null);
		if (slideComments.Length <= 0)
		{
			return;
		}
		Dictionary<ICommentAuthor, ICommentAuthor> dictionary = new Dictionary<ICommentAuthor, ICommentAuthor>();
		ICommentAuthorCollection commentAuthors = slideDest.Presentation.CommentAuthors;
		foreach (IComment comment in slideComments)
		{
			ICommentAuthor author = comment.Author;
			if (!dictionary.TryGetValue(author, out var value))
			{
				ICommentAuthor[] array = commentAuthors.FindByNameAndInitials(author.Name, author.Initials);
				value = ((array.Length <= 0) ? commentAuthors.AddAuthor(author.Name, author.Initials) : array[array.Length - 1]);
				dictionary[comment.Author] = value;
			}
			value.Comments.AddComment(comment.Text, slideDest, comment.Position, comment.CreatedTime);
		}
	}

	public static ILayoutSlide smethod_3(IMasterSlide destMaster, ILayoutSlide sourceSlide)
	{
		if (sourceSlide == null)
		{
			return null;
		}
		Presentation presentation = (Presentation)destMaster.Presentation;
		smethod_0(sourceSlide.Presentation, presentation, Enum168.const_1, out var tempPackage, out var serializationContext, out var deserializationContext);
		Class1342 @class = Class1028.smethod_1(tempPackage, sourceSlide, null, serializationContext);
		serializationContext.method_0(deserializationContext);
		Class1194 class2 = new Class1194(@class, deserializationContext);
		class2.method_7(destMaster, out var layoutSlide);
		((LayoutSlide)layoutSlide).BaseSlidePPTXUnsupportedProps.SlideId = presentation.PPTXUnsupportedProps.method_2();
		deserializationContext.SlidePartPathToSlide.Add(@class.PartPath, layoutSlide);
		GlobalLayoutSlideCollection.smethod_0(layoutSlide);
		Class1027.smethod_1(tempPackage, presentation, deserializationContext);
		Class1027.smethod_3(tempPackage, presentation, deserializationContext);
		return layoutSlide;
	}

	public static IMasterSlide smethod_4(IPresentation destPresentation, IMasterSlide sourceMaster, bool cloneLinkedLayouts)
	{
		if (sourceMaster == null)
		{
			return null;
		}
		smethod_0(sourceMaster.Presentation, destPresentation, Enum168.const_1, out var tempPackage, out var serializationContext, out var deserializationContext);
		Class1342 part = Class1028.smethod_0(tempPackage, sourceMaster, cloneLinkedLayouts, serializationContext);
		serializationContext.method_0(deserializationContext);
		Class1027.smethod_0(tempPackage, deserializationContext);
		IMasterSlide masterSlide = ((MasterSlideCollection)destPresentation.Masters).method_0();
		Class1195 @class = new Class1195(part, deserializationContext);
		@class.method_7(masterSlide);
		((BaseSlide)masterSlide).BaseSlidePPTXUnsupportedProps.SlideId = ((Presentation)destPresentation).PPTXUnsupportedProps.method_2();
		((Presentation)destPresentation).method_3((FontsManager)sourceMaster.Presentation.FontsManager);
		return masterSlide;
	}

	public static IShape smethod_5(IShapeCollection destShapeCollection, IShape sourceShape, ShapeFrame frame)
	{
		if (sourceShape == null)
		{
			return null;
		}
		IPresentation presentation = destShapeCollection.ParentGroup.Presentation;
		BaseSlide baseSlide = (BaseSlide)destShapeCollection.ParentGroup.Slide;
		IPresentation presentation2 = sourceShape.Presentation;
		smethod_0(presentation2, presentation, Enum168.const_2, out var tempPackage, out var serializationContext, out var deserializationContext);
		IBaseSlide slide = sourceShape.Slide;
		serializationContext.SlideToSlidePartPath.Add(slide, "/ppt/slides/slide" + serializationContext.method_28() + ".xml");
		Class1342 @class = tempPackage.method_4(serializationContext.SlideToSlidePartPath[slide], null, new Class1249());
		serializationContext.RelationshipsOfCurrentPartEntry = @class.Relationships;
		Class1031 slideSerializationContext = new Class1031(slide, serializationContext, @class);
		Class1998 class2 = new Class1998();
		Class961.smethod_4(sourceShape, class2, slideSerializationContext, null);
		serializationContext.method_0(deserializationContext);
		Class1030 slideDeserializationContext = new Class1030(deserializationContext, @class);
		deserializationContext.RelationshipsOfCurrentPartEntry = @class.Relationships;
		List<uint> phIdxsBefore = baseSlide.class518_0.method_5();
		IShape shape = Class961.smethod_1(class2.ShapeList[0], destShapeCollection.ParentGroup, slideDeserializationContext);
		Class1027.smethod_3(tempPackage, presentation, deserializationContext);
		smethod_6(shape, sourceShape, frame, phIdxsBefore, root: true);
		return shape;
	}

	private static void smethod_6(IShape newShape, IShape sourceShape, ShapeFrame frame, List<uint> phIdxsBefore, bool root)
	{
		if (newShape.Placeholder != null && phIdxsBefore.Contains(newShape.Placeholder.Index))
		{
			newShape.RemovePlaceholder();
			if (newShape is AutoShape)
			{
				((AutoShape)newShape).PPTXUnsupportedProps.IsTextBox = true;
				((AutoShape)sourceShape).method_31(((AutoShape)newShape).TextFrameInternal);
			}
			if (newShape is GeometryShape)
			{
				((GeometryShape)newShape).PPTXUnsupportedProps.Geometry2DPPTXUnsupportedProps.RawPreset = ShapeType.Rectangle;
			}
			if (newShape is AutoShape)
			{
				((AutoShape)newShape).ShapeLock.GroupingLocked = false;
			}
			else if (newShape is Connector)
			{
				((Connector)newShape).ShapeLock.GroupingLocked = false;
			}
			else if (newShape is GraphicalObject)
			{
				((GraphicalObject)newShape).ShapeLock.GroupingLocked = false;
			}
			else if (newShape is GroupShape)
			{
				((GroupShape)newShape).ShapeLock.GroupingLocked = false;
			}
			else if (newShape is PictureFrame)
			{
				((PictureFrame)newShape).ShapeLock.GroupingLocked = false;
			}
		}
		IShapeFrame rawFrame = sourceShape.RawFrame;
		if (frame == null && newShape.Placeholder != null && float.IsNaN(rawFrame.X) && float.IsNaN(rawFrame.Y) && float.IsNaN(rawFrame.Width) && float.IsNaN(rawFrame.Height))
		{
			((Shape)newShape).ResetFrame();
		}
		else if (root)
		{
			smethod_7(newShape, sourceShape, frame);
		}
		if (sourceShape is IAudioFrame)
		{
			IAudioFrame audioFrame = (IAudioFrame)sourceShape;
			IAudioFrame audioFrame2 = (IAudioFrame)newShape;
			audioFrame2.HideAtShowing = audioFrame.HideAtShowing;
			audioFrame2.PlayLoopMode = audioFrame.PlayLoopMode;
			audioFrame2.Volume = audioFrame.Volume;
			audioFrame2.PlayMode = audioFrame.PlayMode;
		}
		else if (sourceShape is IVideoFrame)
		{
			IVideoFrame videoFrame = (IVideoFrame)sourceShape;
			IVideoFrame videoFrame2 = (IVideoFrame)newShape;
			videoFrame2.HideAtShowing = videoFrame.HideAtShowing;
			videoFrame2.PlayLoopMode = videoFrame.PlayLoopMode;
			videoFrame2.FullScreenMode = videoFrame.FullScreenMode;
			videoFrame2.RewindVideo = videoFrame.RewindVideo;
			videoFrame2.Volume = videoFrame.Volume;
		}
		else if (sourceShape is IGroupShape)
		{
			IGroupShape groupShape = (IGroupShape)sourceShape;
			IGroupShape groupShape2 = (IGroupShape)newShape;
			for (int i = 0; i < groupShape.Shapes.Count; i++)
			{
				smethod_6(groupShape2.Shapes[i], groupShape.Shapes[i], null, phIdxsBefore, root: false);
			}
		}
	}

	private static void smethod_7(IShape newShape, IShape sourceShape, IShapeFrame frame)
	{
		if (frame == null)
		{
			frame = sourceShape.Frame.CloneShapeFrame();
		}
		newShape.Frame = frame;
	}
}
