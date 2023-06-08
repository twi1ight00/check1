using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Aspose.Slides.Charts;
using Aspose.Slides.SmartArt;
using ns16;
using ns24;
using ns28;

namespace Aspose.Slides;

public sealed class ShapeCollection : ICollection, IEnumerable, IEnumerable<IShape>, IShapeCollection
{
	internal List<IShape> list_0;

	internal GroupShape groupShape_0;

	private static readonly Dictionary<ShapeType, ShapeType> dictionary_0 = GeometryShape.smethod_2(ShapeType.Line, ShapeType.LineInverse, ShapeType.CurvedArc, ShapeType.LeftBracket, ShapeType.RightBracket, ShapeType.LeftBrace, ShapeType.RightBrace, ShapeType.BracketPair, ShapeType.BracePair, ShapeType.StraightConnector1, ShapeType.BentConnector2, ShapeType.BentConnector3, ShapeType.BentConnector4, ShapeType.BentConnector5, ShapeType.CurvedConnector2, ShapeType.CurvedConnector3, ShapeType.CurvedConnector4, ShapeType.CurvedConnector5);

	public int Count => list_0.Count;

	public IShape this[int index] => list_0[index];

	public IGroupShape ParentGroup => groupShape_0;

	ICollection IShapeCollection.AsICollection => this;

	IEnumerable IShapeCollection.AsIEnumerable => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal ShapeCollection(GroupShape parentGroup)
	{
		groupShape_0 = parentGroup;
		list_0 = new List<IShape>();
	}

	internal void Add(Shape value)
	{
		if (value.Slide != groupShape_0.Slide)
		{
			throw new Exception();
		}
		value.shapeCollection_0 = this;
		list_0.Add(value);
	}

	internal void Insert(int index, Shape value)
	{
		value.shapeCollection_0 = this;
		list_0.Insert(index, value);
	}

	internal Chart method_0(ChartType type, float x, float y, float width, float height, int nIndex, bool initWithSample)
	{
		if (groupShape_0 == null)
		{
			return null;
		}
		Chart chart = new Chart(groupShape_0.Slide, type);
		if (initWithSample)
		{
			Class1032 @class = new Class1032();
			@class.method_0(chart, type);
			chart.Type = type;
		}
		chart.Name = "ChartObject";
		method_15(nIndex, chart, x, y, width, height);
		return chart;
	}

	public IChart AddChart(ChartType type, float x, float y, float width, float height)
	{
		return AddChart(type, x, y, width, height, initWithSample: true);
	}

	public IChart AddChart(ChartType type, float x, float y, float width, float height, bool initWithSample)
	{
		return method_0(type, x, y, width, height, -1, initWithSample);
	}

	public ISmartArt AddSmartArt(float x, float y, float width, float height, SmartArtLayoutType layoutType)
	{
		if (layoutType == SmartArtLayoutType.Custom)
		{
			throw new ArgumentException("Can't create SmartArt with Custom layout type", "layoutType");
		}
		return method_1(x, y, width, height, layoutType, -1);
	}

	internal Aspose.Slides.SmartArt.SmartArt method_1(float x, float y, float width, float height, SmartArtLayoutType layoutType, int nIndex)
	{
		if (groupShape_0 == null)
		{
			return null;
		}
		Aspose.Slides.SmartArt.SmartArt smartArt = new Aspose.Slides.SmartArt.SmartArt(groupShape_0.Slide, layoutType);
		method_15(nIndex, smartArt, x, y, width, height);
		smartArt.Name = "New Diagram";
		return smartArt;
	}

	public IChart InsertChart(ChartType type, float x, float y, float width, float height, int index)
	{
		return InsertChart(type, x, y, width, height, index, initWithSample: true);
	}

	public IChart InsertChart(ChartType type, float x, float y, float width, float height, int index, bool initWithSample)
	{
		return method_0(type, x, y, width, height, index, initWithSample);
	}

	internal OleObjectFrame method_2(float x, float y, float width, float height, string class_name, byte[] obj_data, int nIndex)
	{
		if (groupShape_0 == null)
		{
			return null;
		}
		OleObjectFrame oleObjectFrame = new OleObjectFrame(groupShape_0.Slide);
		oleObjectFrame.Name = "OleObject";
		oleObjectFrame.ShapeLock.AspectRatioLocked = true;
		method_15(nIndex, oleObjectFrame, x, y, width, height);
		oleObjectFrame.ObjectData = obj_data;
		oleObjectFrame.ObjectProgId = class_name;
		return oleObjectFrame;
	}

	internal OleObjectFrame method_3(float x, float y, float width, float height, string className, string path, int nIndex)
	{
		if (groupShape_0 == null)
		{
			return null;
		}
		OleObjectFrame oleObjectFrame = new OleObjectFrame(groupShape_0.Slide);
		oleObjectFrame.Name = "OleObject";
		oleObjectFrame.ShapeLock.AspectRatioLocked = true;
		method_15(nIndex, oleObjectFrame, x, y, width, height);
		oleObjectFrame.LinkPathLong = path;
		oleObjectFrame.ObjectProgId = className;
		return oleObjectFrame;
	}

	public IOleObjectFrame AddOleObjectFrame(float x, float y, float width, float height, string className, byte[] objectData)
	{
		return method_2(x, y, width, height, className, objectData, -1);
	}

	public IOleObjectFrame AddOleObjectFrame(float x, float y, float width, float height, string className, string path)
	{
		return method_3(x, y, width, height, className, path, -1);
	}

	public IOleObjectFrame InsertOleObjectFrame(int index, float x, float y, float width, float height, string className, byte[] objectData)
	{
		return method_2(x, y, width, height, className, objectData, index);
	}

	public IOleObjectFrame InsertOleObjectFrame(int index, float x, float y, float width, float height, string className, string path)
	{
		return method_3(x, y, width, height, className, path, index);
	}

	internal VideoFrame method_4(float x, float y, float width, float height, string fname, int nIndex)
	{
		if (groupShape_0 == null)
		{
			return null;
		}
		VideoFrame videoFrame = new VideoFrame(groupShape_0.Slide);
		videoFrame.ShapeType = ShapeType.Rectangle;
		videoFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
		videoFrame.Name = "New picture";
		videoFrame.HyperlinkClick = Hyperlink.Media;
		method_15(nIndex, videoFrame, x, y, width, height);
		videoFrame.LinkPathLong = fname;
		return videoFrame;
	}

	public IVideoFrame AddVideoFrame(float x, float y, float width, float height, string fname)
	{
		return method_4(x, y, width, height, fname, -1);
	}

	internal IVideoFrame method_5(float x, float y, float width, float height, IVideo video, int nIndex)
	{
		if (groupShape_0 == null)
		{
			return null;
		}
		VideoFrame videoFrame = new VideoFrame(groupShape_0.Slide);
		videoFrame.ShapeType = ShapeType.Rectangle;
		videoFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
		videoFrame.Name = "New video";
		videoFrame.HyperlinkClick = Hyperlink.Media;
		method_15(nIndex, videoFrame, x, y, width, height);
		videoFrame.EmbeddedVideo = video;
		return videoFrame;
	}

	public IVideoFrame AddVideoFrame(float x, float y, float width, float height, IVideo video)
	{
		return method_5(x, y, width, height, video, -1);
	}

	public IVideoFrame InsertVideoFrame(int index, float x, float y, float width, float height, string fname)
	{
		VideoFrame videoFrame = method_4(x, y, width, height, fname, index);
		Insert(index, videoFrame);
		return videoFrame;
	}

	internal PictureFrame method_6(ShapeType preset, IPPImage image)
	{
		if (!PictureFrame.dictionary_0.ContainsKey(preset))
		{
			throw new PptxEditException("Incorrect ShapeType value for PictureFrame specified: " + preset);
		}
		PictureFrame pictureFrame = new PictureFrame(groupShape_0.Slide);
		pictureFrame.ShapeType = preset;
		pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
		pictureFrame.Name = "New picture";
		pictureFrame.PictureFormat.Picture.Image = image;
		return pictureFrame;
	}

	internal AudioFrame method_7(float x, float y, float width, float height, int nIndex)
	{
		AudioFrame audioFrame = new AudioFrame(groupShape_0.Slide);
		audioFrame.PPTXUnsupportedProps.AudioFrameType = Enum112.const_3;
		audioFrame.ShapeType = ShapeType.Rectangle;
		audioFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
		audioFrame.Name = "New Audio";
		audioFrame.ShapeLock.RotationLocked = true;
		audioFrame.ShapeLock.AspectRatioLocked = true;
		audioFrame.method_26();
		method_15(nIndex, audioFrame, x, y, width, height);
		return audioFrame;
	}

	public IAudioFrame AddAudioFrameCD(float x, float y, float width, float height)
	{
		return method_7(x, y, width, height, -1);
	}

	public IAudioFrame InsertAudioFrameCD(int index, float x, float y, float width, float height)
	{
		return method_7(x, y, width, height, index);
	}

	internal AudioFrame method_8(float x, float y, float width, float height, string fname, int nIndex)
	{
		if (groupShape_0 == null)
		{
			return null;
		}
		AudioFrame audioFrame = new AudioFrame(groupShape_0.Slide);
		audioFrame.PPTXUnsupportedProps.AudioFrameType = Enum112.const_1;
		audioFrame.ShapeType = ShapeType.Rectangle;
		audioFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
		audioFrame.Name = "New Audio";
		audioFrame.ShapeLock.RotationLocked = true;
		audioFrame.ShapeLock.AspectRatioLocked = true;
		audioFrame.method_26();
		method_15(nIndex, audioFrame, x, y, width, height);
		audioFrame.LinkPathLong = fname;
		return audioFrame;
	}

	public IAudioFrame AddAudioFrameLinked(float x, float y, float width, float height, string fname)
	{
		return method_8(x, y, width, height, fname, -1);
	}

	public IAudioFrame InsertAudioFrameLinked(int index, float x, float y, float width, float height, string fname)
	{
		return method_8(x, y, width, height, fname, index);
	}

	internal AudioFrame method_9(float x, float y, float width, float height, Stream audio_stream, int nIndex)
	{
		if (groupShape_0 == null)
		{
			return null;
		}
		AudioFrame audioFrame = new AudioFrame(groupShape_0.Slide);
		audioFrame.PPTXUnsupportedProps.AudioFrameType = Enum112.const_2;
		audioFrame.ShapeType = ShapeType.Rectangle;
		audioFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
		audioFrame.Name = "New Audio";
		audioFrame.ShapeLock.RotationLocked = true;
		audioFrame.ShapeLock.AspectRatioLocked = true;
		audioFrame.method_26();
		method_15(nIndex, audioFrame, x, y, width, height);
		audioFrame.method_27(audio_stream);
		return audioFrame;
	}

	public IAudioFrame AddAudioFrameEmbedded(float x, float y, float width, float height, Stream audio_stream)
	{
		return method_9(x, y, width, height, audio_stream, -1);
	}

	public IAudioFrame InsertAudioFrameEmbedded(int index, float x, float y, float width, float height, Stream audio_stream)
	{
		return method_9(x, y, width, height, audio_stream, index);
	}

	internal AudioFrame method_10(float x, float y, float width, float height, IAudio audio, int nIndex)
	{
		if (groupShape_0 == null)
		{
			return null;
		}
		AudioFrame audioFrame = new AudioFrame(groupShape_0.Slide);
		audioFrame.PPTXUnsupportedProps.AudioFrameType = Enum112.const_2;
		audioFrame.ShapeType = ShapeType.Rectangle;
		audioFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
		audioFrame.Name = "New Audio";
		audioFrame.ShapeLock.RotationLocked = true;
		audioFrame.ShapeLock.AspectRatioLocked = true;
		audioFrame.method_26();
		method_15(nIndex, audioFrame, x, y, width, height);
		audioFrame.EmbeddedAudio = audio;
		return audioFrame;
	}

	public IAudioFrame AddAudioFrameEmbedded(float x, float y, float width, float height, IAudio audio)
	{
		return method_10(x, y, width, height, audio, -1);
	}

	public IAudioFrame InsertAudioFrameEmbedded(int index, float x, float y, float width, float height, IAudio audio)
	{
		return method_10(x, y, width, height, audio, index);
	}

	public int IndexOf(IShape shape)
	{
		return list_0.IndexOf(shape);
	}

	public IShape[] ToArray()
	{
		return list_0.ToArray();
	}

	public IShape[] ToArray(int startIndex, int count)
	{
		if (startIndex < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		if (count >= 0 && startIndex + count <= Count)
		{
			Shape[] array = new Shape[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = (Shape)list_0[i + startIndex];
			}
			return array;
		}
		throw new ArgumentOutOfRangeException("count");
	}

	public void Reorder(int index, IShape shape)
	{
		if (index >= 0 && index < Count)
		{
			if (((Shape)shape).shapeCollection_0 != this)
			{
				throw new PptxEditException("Trying to move a shape from other collection.");
			}
			int num = list_0.IndexOf(shape);
			if (num < 0)
			{
				throw new PptxEditException("Trying to move removed shapes.");
			}
			if (index == num)
			{
				return;
			}
			lock (((ICollection)list_0).SyncRoot)
			{
				if (index < num)
				{
					for (int num2 = num; num2 > index; num2--)
					{
						list_0[num2] = list_0[num2 - 1];
					}
				}
				else
				{
					for (int i = num; i < index; i++)
					{
						list_0[i] = list_0[i + 1];
					}
				}
				list_0[index] = shape;
				return;
			}
		}
		throw new PptxEditException("Index must lay within [0..Count-1] range.");
	}

	public void Reorder(int index, params IShape[] shapes)
	{
		if (index >= 0 && index <= Count - shapes.Length)
		{
			if (shapes.Length == 0)
			{
				return;
			}
			Dictionary<IShape, IShape> dictionary = new Dictionary<IShape, IShape>(shapes.Length);
			int num = 0;
			while (true)
			{
				if (num < shapes.Length)
				{
					if (((Shape)shapes[num]).shapeCollection_0 == this)
					{
						if (dictionary.ContainsKey(shapes[num]))
						{
							break;
						}
						dictionary[shapes[num]] = shapes[num];
						num++;
						continue;
					}
					throw new PptxEditException("Trying to move a shape from other presentation.");
				}
				int count = list_0.Count;
				int num2 = 0;
				int[] array = new int[shapes.Length];
				for (int i = 0; i < count; i++)
				{
					if (dictionary.ContainsKey(list_0[i]))
					{
						array[num2++] = i;
					}
				}
				if (num2 < shapes.Length)
				{
					throw new PptxEditException("Trying to move removed slide.");
				}
				lock (((ICollection)list_0).SyncRoot)
				{
					for (int j = 0; j < array.Length - 1; j++)
					{
						int num3 = array[j] - j;
						int num4 = array[j + 1] - j - 2;
						if (num4 >= index)
						{
							num4 = index - 1;
						}
						for (int k = num3; k <= num4; k++)
						{
							list_0[k] = shapes[k + j + 1];
						}
						if (num4 == index - 1)
						{
							break;
						}
					}
					int num5 = index + shapes.Length - 1;
					int num6 = 0;
					int num7 = array.Length - 1;
					while (num6 < array.Length - 1)
					{
						int num8 = array[num7] + num6;
						int num9 = array[num7 - 1] + num6 + 2;
						if (num9 <= num5)
						{
							num9 = num5 + 1;
						}
						for (int num10 = num8; num10 >= num9; num10--)
						{
							list_0[num10] = shapes[num10 - num6 - 1];
						}
						if (num9 == num5 + 1)
						{
							break;
						}
						num6++;
						num7--;
					}
					for (int l = 0; l < shapes.Length; l++)
					{
						list_0[index + l] = shapes[l];
					}
					return;
				}
			}
			throw new PptxEditException("Trying to move the same shape twice. Shape index: " + num);
		}
		throw new PptxEditException("Index must lay within [0..Count - slides.Length] range.");
	}

	internal AutoShape method_11()
	{
		AutoShape autoShape = new AutoShape(groupShape_0.Slide);
		autoShape.Name = "New shape";
		autoShape.ShapeLock.GroupingLocked = true;
		autoShape.AddTextFrame("");
		Add(autoShape);
		return autoShape;
	}

	internal AutoShape method_12(ShapeType preset, bool createFromTemplate)
	{
		AutoShape autoShape = new AutoShape(groupShape_0.Slide);
		if (createFromTemplate)
		{
			autoShape.Name = "New shape";
			autoShape.method_14();
			autoShape.ShapeStyle.LineColor.SchemeColor = SchemeColor.Accent1;
			autoShape.ShapeStyle.FillColor.SchemeColor = SchemeColor.Accent1;
			autoShape.ShapeStyle.EffectColor.SchemeColor = SchemeColor.Accent1;
			autoShape.ShapeStyle.EffectStyleIndex = 0u;
			autoShape.ShapeStyle.FontCollectionIndex = FontCollectionIndex.Minor;
			if (dictionary_0.ContainsKey(preset))
			{
				autoShape.ShapeStyle.LineStyleIndex = 1;
				autoShape.ShapeStyle.FillStyleIndex = 0;
				autoShape.ShapeStyle.FontColor.SchemeColor = SchemeColor.Text1;
			}
			else
			{
				autoShape.ShapeStyle.LineColor.ColorTransform.Add(ColorTransformOperation.Shade, 0.5f);
				autoShape.ShapeStyle.LineStyleIndex = 2;
				autoShape.ShapeStyle.FillStyleIndex = 1;
				autoShape.ShapeStyle.FontColor.SchemeColor = SchemeColor.Light1;
			}
			autoShape.AddTextFrame("");
			((TextFrame)autoShape.TextFrame).textFrameFormat_0.RightToLeftColumns = false;
			autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
			autoShape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
			autoShape.RawFrame = new ShapeFrame(0f, 0f, 100f, 100f, NullableBool.False, NullableBool.False, 0f);
		}
		autoShape.ShapeType = preset;
		return autoShape;
	}

	internal Connector method_13(ShapeType preset, bool createFromTemplate)
	{
		if (!Connector.dictionary_0.ContainsKey(preset))
		{
			throw new PptxEditException("Incorrect ShapeType value for Connector specified: " + preset);
		}
		Connector connector = new Connector(groupShape_0.Slide);
		if (createFromTemplate)
		{
			connector.Name = "New connector";
			connector.method_14();
			connector.ShapeStyle.LineColor.SchemeColor = SchemeColor.Accent1;
			connector.ShapeStyle.FillColor.SchemeColor = SchemeColor.Accent1;
			connector.ShapeStyle.EffectColor.SchemeColor = SchemeColor.Accent1;
			connector.ShapeStyle.EffectStyleIndex = 0u;
			connector.ShapeStyle.FontCollectionIndex = FontCollectionIndex.Minor;
			connector.ShapeStyle.LineStyleIndex = 1;
			connector.ShapeStyle.FillStyleIndex = 0;
			connector.ShapeStyle.FontColor.SchemeColor = SchemeColor.Text1;
			connector.RawFrame = new ShapeFrame(0f, 0f, 100f, 100f, NullableBool.False, NullableBool.False, 0f);
		}
		connector.ShapeType = preset;
		return connector;
	}

	internal Table method_14(int index, float x, float y, double[] columnWidths, double[] rowHeights)
	{
		if (columnWidths == null)
		{
			throw new ArgumentNullException("columnWidths");
		}
		if (rowHeights == null)
		{
			throw new ArgumentNullException("rowHeights");
		}
		if (columnWidths.Length != 0 && rowHeights.Length != 0)
		{
			double num = 0.0;
			double num2 = 0.0;
			int num3 = 0;
			Table table;
			while (true)
			{
				if (num3 < columnWidths.Length)
				{
					if (!(columnWidths[num3] <= 0.0))
					{
						num += columnWidths[num3];
						num3++;
						continue;
					}
					throw new PptxEditException("All column's widths must be greater than zero.");
				}
				int num4 = 0;
				while (true)
				{
					if (num4 < rowHeights.Length)
					{
						if (!(rowHeights[num4] <= 0.0))
						{
							num2 += rowHeights[num4];
							num4++;
							continue;
						}
						throw new PptxEditException("All row's heights must be greater than zero.");
					}
					table = new Table(groupShape_0.Slide);
					table.Name = "New Table";
					table.ShapeLock.GroupingLocked = true;
					table.FirstRow = true;
					table.HorizontalBanding = true;
					ColumnCollection columnCollection = (ColumnCollection)table.Columns;
					RowCollection rowCollection = (RowCollection)table.Rows;
					columnCollection.method_2(480.0);
					columnCollection.method_2(480.0);
					rowCollection.method_2(29.2);
					rowCollection.method_2(29.2);
					Cell cell = table.GetCell(0, 0);
					cell.TextFrame.Text = "";
					method_15(index, table, x, y, (float)num, (float)num2);
					table.method_15(columnWidths, rowHeights);
					table.guid_0 = ((Presentation)groupShape_0.Presentation).TableStyles.PPTXUnsupportedProps.DefaultStyleId;
					if (table.guid_0 != Guid.Empty)
					{
						table.TableStyle = ((Presentation)groupShape_0.Presentation).TableStyles.method_0(table.guid_0);
					}
					break;
				}
				break;
			}
			return table;
		}
		throw new PptxEditException("Table must contain at least one row and one column.");
	}

	public IAutoShape AddAutoShape(ShapeType shapeType, float x, float y, float width, float height)
	{
		return AddAutoShape(shapeType, x, y, width, height, createFromTemplate: true);
	}

	public IAutoShape AddAutoShape(ShapeType shapeType, float x, float y, float width, float height, bool createFromTemplate)
	{
		AutoShape autoShape = method_12(shapeType, createFromTemplate);
		method_15(-1, autoShape, x, y, width, height);
		return autoShape;
	}

	private void method_15(int insertIndex, Shape shape, float x, float y, float width, float height)
	{
		if (float.IsNaN(x))
		{
			throw new ArgumentException("Value of x paramenter must be defined (not a float.NaN).");
		}
		if (float.IsNaN(y))
		{
			throw new ArgumentException("Value of y paramenter must be defined (not a float.NaN).");
		}
		if (float.IsNaN(width))
		{
			throw new ArgumentException("Value of width paramenter must be defined (not a float.NaN).");
		}
		if (float.IsNaN(height))
		{
			throw new ArgumentException("Value of height paramenter must be defined (not a float.NaN).");
		}
		if (insertIndex == -1)
		{
			Add(shape);
		}
		else
		{
			Insert(insertIndex, shape);
		}
		shape.Frame = new ShapeFrame(x, y, width, height, NullableBool.False, NullableBool.False, 0f);
	}

	public IAutoShape InsertAutoShape(int index, ShapeType shapeType, float x, float y, float width, float height)
	{
		return InsertAutoShape(index, shapeType, x, y, width, height, createFromTemplate: true);
	}

	public IAutoShape InsertAutoShape(int index, ShapeType shapeType, float x, float y, float width, float height, bool createFromTemplate)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index must be zero-based.");
		}
		AutoShape autoShape = method_12(shapeType, createFromTemplate);
		method_15(index, autoShape, x, y, width, height);
		return autoShape;
	}

	public IGroupShape AddGroupShape()
	{
		GroupShape groupShape = method_16();
		method_15(-1, groupShape, 0f, 0f, 100f, 100f);
		return groupShape;
	}

	public IGroupShape InsertGroupShape(int index)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index must be zero-based.");
		}
		GroupShape groupShape = method_16();
		method_15(index, groupShape, 0f, 0f, 100f, 100f);
		return groupShape;
	}

	internal GroupShape method_16()
	{
		return new GroupShape(groupShape_0.Slide);
	}

	internal IGraphicalObject method_17()
	{
		return new GraphicalObject(groupShape_0.Slide);
	}

	public IConnector AddConnector(ShapeType shapeType, float x, float y, float width, float height)
	{
		return AddConnector(shapeType, x, y, width, height, createFromTemplate: true);
	}

	public IConnector AddConnector(ShapeType shapeType, float x, float y, float width, float height, bool createFromTemplate)
	{
		Connector connector = method_13(shapeType, createFromTemplate);
		method_15(-1, connector, x, y, width, height);
		return connector;
	}

	public IConnector InsertConnector(int index, ShapeType shapeType, float x, float y, float width, float height)
	{
		return InsertConnector(index, shapeType, x, y, width, height, createFromTemplate: true);
	}

	public IConnector InsertConnector(int index, ShapeType shapeType, float x, float y, float width, float height, bool createFromTemplate)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index must be zero-based.");
		}
		Connector connector = method_13(shapeType, createFromTemplate);
		method_15(index, connector, x, y, width, height);
		return connector;
	}

	public IPictureFrame AddPictureFrame(ShapeType shapeType, float x, float y, float width, float height, IPPImage image)
	{
		PictureFrame pictureFrame = method_6(shapeType, image);
		method_15(-1, pictureFrame, x, y, width, height);
		return pictureFrame;
	}

	public IPictureFrame InsertPictureFrame(int index, ShapeType shapeType, float x, float y, float width, float height, IPPImage image)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index must be zero-based.");
		}
		PictureFrame pictureFrame = method_6(shapeType, image);
		method_15(index, pictureFrame, x, y, width, height);
		return pictureFrame;
	}

	public ITable AddTable(float x, float y, double[] columnWidths, double[] rowHeights)
	{
		return method_14(-1, x, y, columnWidths, rowHeights);
	}

	public ITable InsertTable(int index, float x, float y, double[] columnWidths, double[] rowHeights)
	{
		return method_14(index, x, y, columnWidths, rowHeights);
	}

	public void RemoveAt(int index)
	{
		Shape shape = (Shape)this[index];
		shape.vmethod_8();
		list_0.RemoveAt(index);
	}

	public void Remove(IShape shape)
	{
		int num = list_0.IndexOf(shape);
		if (num >= 0)
		{
			RemoveAt(num);
		}
	}

	public void Clear()
	{
		int count = Count;
		for (int num = count - 1; num >= 0; num--)
		{
			RemoveAt(num);
		}
	}

	IEnumerator<IShape> IEnumerable<IShape>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IShape AddClone(IShape sourceShape, float x, float y, float width, float height)
	{
		if (float.IsNaN(x))
		{
			throw new ArgumentException("Value of x paramenter must be defined (not a float.NaN).");
		}
		if (float.IsNaN(y))
		{
			throw new ArgumentException("Value of y paramenter must be defined (not a float.NaN).");
		}
		if (float.IsNaN(width))
		{
			throw new ArgumentException("Value of width paramenter must be defined (not a float.NaN).");
		}
		if (float.IsNaN(height))
		{
			throw new ArgumentException("Value of height paramenter must be defined (not a float.NaN).");
		}
		ShapeFrame frame = new ShapeFrame(x, y, width, height, NullableBool.False, NullableBool.False, 0f);
		return (Shape)Class1026.smethod_5(this, sourceShape, frame);
	}

	public IShape AddClone(IShape sourceShape, float x, float y)
	{
		if (float.IsNaN(x))
		{
			throw new ArgumentException("Value of x paramenter must be defined (not a float.NaN).");
		}
		if (float.IsNaN(y))
		{
			throw new ArgumentException("Value of y paramenter must be defined (not a float.NaN).");
		}
		IShapeFrame frame = sourceShape.Frame;
		ShapeFrame frame2 = new ShapeFrame(x, y, frame.Width, frame.Height, NullableBool.False, NullableBool.False, 0f);
		return (Shape)Class1026.smethod_5(this, sourceShape, frame2);
	}

	public IShape AddClone(IShape sourceShape)
	{
		return (Shape)Class1026.smethod_5(this, sourceShape, null);
	}

	public IShape InsertClone(int index, IShape sourceShape, float x, float y, float width, float height)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index must be zero-based.");
		}
		IShape shape = AddClone(sourceShape, x, y, width, height);
		list_0.Remove(shape);
		list_0.Insert(index, shape);
		return shape;
	}

	public IShape InsertClone(int index, IShape sourceShape, float x, float y)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index must be zero-based.");
		}
		IShape shape = AddClone(sourceShape, x, y);
		list_0.Remove(shape);
		list_0.Insert(index, shape);
		return shape;
	}

	public IShape InsertClone(int index, IShape sourceShape)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index must be zero-based.");
		}
		IShape shape = AddClone(sourceShape);
		list_0.Remove(shape);
		list_0.Insert(index, shape);
		return shape;
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}

	internal void method_18(Class369 page, Class476 package)
	{
		foreach (XmlNode childNode in page.ChildNodes)
		{
			int num = 0;
			if (childNode is Class430)
			{
				Class430 @class = (Class430)childNode;
				AutoShape autoShape = (AutoShape)AddAutoShape(ShapeType.Rectangle, @class.Transform2D.X, @class.Transform2D.Y, @class.Transform2D.Width, @class.Transform2D.Height, createFromTemplate: true);
				autoShape.vmethod_10(@class.ShapeProperties.PresStyleName, @class.ShapeProperties.TextStyleName, package, @class);
				autoShape.vmethod_10(@class.ShapeProperties.DrawStyleName, @class.ShapeProperties.TextStyleName, package, @class);
			}
			else if (childNode is Class391)
			{
				Class391 class2 = (Class391)childNode;
				AutoShape autoShape2 = (AutoShape)AddAutoShape(ShapeType.Ellipse, class2.Transform2D.X, class2.Transform2D.Y, class2.Transform2D.Width, class2.Transform2D.Height, createFromTemplate: true);
				autoShape2.vmethod_10(class2.ShapeProperties.PresStyleName, class2.ShapeProperties.TextStyleName, package, class2);
				autoShape2.vmethod_10(class2.ShapeProperties.DrawStyleName, class2.ShapeProperties.TextStyleName, package, class2);
			}
			else if (childNode is Class374)
			{
				Class374 class3 = (Class374)childNode;
				AutoShape autoShape3 = (AutoShape)AddAutoShape(ShapeType.Ellipse, class3.Transform2D.X, class3.Transform2D.Y, class3.Transform2D.Width, class3.Transform2D.Height, createFromTemplate: true);
				autoShape3.vmethod_10(class3.ShapeProperties.PresStyleName, class3.ShapeProperties.TextStyleName, package, class3);
				autoShape3.vmethod_10(class3.ShapeProperties.DrawStyleName, class3.ShapeProperties.TextStyleName, package, class3);
			}
			else if (childNode is Class384)
			{
				Class384 class4 = (Class384)childNode;
				if (class4.Name.IndexOf("evaluation") == 0)
				{
					continue;
				}
				Shape shape;
				if (class4.Image != null && package.method_7(class4.Image.Href) != -1)
				{
					shape = (Shape)AddPictureFrame(ShapeType.Rectangle, class4.Transform2D.X, class4.Transform2D.Y, class4.Transform2D.Width, class4.Transform2D.Height, groupShape_0.Presentation.Images[package.method_7(class4.Image.Href)]);
					PictureFrame pictureFrame = (PictureFrame)shape;
					pictureFrame.shapeStyle_0 = null;
					pictureFrame.LineFormat.FillFormat.FillType = FillType.NoFill;
				}
				else
				{
					shape = (Shape)AddAutoShape(ShapeType.Rectangle, class4.Transform2D.X, class4.Transform2D.Y, class4.Transform2D.Width, class4.Transform2D.Height, createFromTemplate: true);
					AutoShape autoShape4 = (AutoShape)shape;
					if (class4.TextBox != null)
					{
						autoShape4.IsTextBox = true;
						if (class4.ShapeProperties.PresStyleName != null)
						{
							((TextFrame)autoShape4.TextFrame).method_11(class4.TextBox, class4.ShapeProperties.PresStyleName, class4.ShapeProperties.TextStyleName);
						}
						if (class4.ShapeProperties.DrawStyleName != null)
						{
							((TextFrame)autoShape4.TextFrame).method_11(class4.TextBox, class4.ShapeProperties.DrawStyleName, class4.ShapeProperties.TextStyleName);
						}
					}
					autoShape4.shapeStyle_0 = null;
				}
				if (class4.PresentationClass != Enum64.const_16)
				{
					Placeholder placeholder = new Placeholder(class4, num);
					shape.method_0(placeholder.Orientation, placeholder.Size, placeholder.Type, placeholder.Index, placeholder.HasCustomPrompt);
					num++;
				}
			}
			else if (childNode is Class402)
			{
				Class402 class5 = (Class402)childNode;
				AutoShape autoShape5 = (AutoShape)AddAutoShape(ShapeType.Line, (float)class5.Line2D.X1, (float)class5.Line2D.Y1, (float)class5.Line2D.X2 - (float)class5.Line2D.X1, (float)class5.Line2D.Y2 - (float)class5.Line2D.Y1, createFromTemplate: true);
				autoShape5.vmethod_10(class5.ShapeProperties.PresStyleName, class5.ShapeProperties.TextStyleName, package, class5);
				autoShape5.vmethod_10(class5.ShapeProperties.DrawStyleName, class5.ShapeProperties.TextStyleName, package, class5);
			}
			else if (childNode is Class419)
			{
				Class419 class6 = (Class419)childNode;
				AutoShape autoShape6 = (AutoShape)AddAutoShape(ShapeType.Custom, class6.Transform2D.X, class6.Transform2D.Y, class6.Transform2D.Width, class6.Transform2D.Height, createFromTemplate: true);
				autoShape6.Geometry.method_4(class6);
				autoShape6.vmethod_10(class6.ShapeProperties.PresStyleName, class6.ShapeProperties.TextStyleName, package, class6);
				autoShape6.vmethod_10(class6.ShapeProperties.DrawStyleName, class6.ShapeProperties.TextStyleName, package, class6);
			}
			else if (childNode is Class421)
			{
				Class421 class7 = (Class421)childNode;
				AutoShape autoShape7 = (AutoShape)AddAutoShape(ShapeType.Custom, class7.Transform2D.X, class7.Transform2D.Y, class7.Transform2D.Width, class7.Transform2D.Height, createFromTemplate: true);
				autoShape7.Geometry.method_3(class7);
				autoShape7.vmethod_10(class7.ShapeProperties.PresStyleName, class7.ShapeProperties.TextStyleName, package, class7);
				autoShape7.vmethod_10(class7.ShapeProperties.DrawStyleName, class7.ShapeProperties.TextStyleName, package, class7);
			}
			else if (childNode is Class382)
			{
				Class382 class8 = (Class382)childNode;
				if (class8.Geometry == null)
				{
					continue;
				}
				AutoShape autoShape8 = null;
				if (class8.Geometry.Type == "ellipse")
				{
					autoShape8 = (AutoShape)AddAutoShape(ShapeType.Ellipse, class8.Transform2D.X, class8.Transform2D.Y, class8.Transform2D.Width, class8.Transform2D.Height, createFromTemplate: true);
				}
				else
				{
					Class483 class9 = new Class483();
					autoShape8 = class9.method_0(class8.Geometry.EnhancedPath, this, class8);
					if (autoShape8 == null)
					{
						autoShape8 = (AutoShape)AddAutoShape(ShapeType.Custom, class8.Transform2D.X, class8.Transform2D.Y, class8.Transform2D.Width, class8.Transform2D.Height, createFromTemplate: true);
						autoShape8.ShapeType = ShapeType.Custom;
						autoShape8.Geometry.method_5(class8);
					}
				}
				autoShape8.vmethod_10(class8.ShapeProperties.PresStyleName, class8.ShapeProperties.TextStyleName, package, class8);
				autoShape8.vmethod_10(class8.ShapeProperties.DrawStyleName, class8.ShapeProperties.TextStyleName, package, class8);
			}
			else if (childNode is Class380)
			{
				Class380 class10 = (Class380)childNode;
				Connector connector = (Connector)AddConnector(class10.DrawType switch
				{
					Enum31.const_0 => ShapeType.BentConnector3, 
					Enum31.const_1 => ShapeType.BentConnector3, 
					Enum31.const_3 => ShapeType.CurvedConnector3, 
					_ => ShapeType.StraightConnector1, 
				}, (float)class10.Line2D.X1, (float)class10.Line2D.Y1, (float)class10.Line2D.X2 - (float)class10.Line2D.X1, (float)class10.Line2D.Y2 - (float)class10.Line2D.Y1, createFromTemplate: true);
				connector.vmethod_10(class10.ShapeProperties.PresStyleName, class10.ShapeProperties.TextStyleName, package, class10);
				connector.vmethod_10(class10.ShapeProperties.DrawStyleName, class10.ShapeProperties.TextStyleName, package, class10);
			}
			else if (childNode is Class395)
			{
				Class395 page2 = (Class395)childNode;
				method_18(page2, package);
			}
		}
	}

	internal void method_19(Class486 trans2D, Shape shape)
	{
		trans2D.X = shape.X;
		trans2D.Y = shape.Y;
		trans2D.Width = shape.Width;
		trans2D.Height = shape.Height;
	}

	internal void method_20(Class369 elemPage, Class476 odpPackage, Class438 AutoStyles)
	{
		string namespaceURI = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Shape shape = (Shape)enumerator.Current;
				if (shape is AutoShape)
				{
					Class437 @class = AutoStyles.method_36("gr" + odpPackage.int_0++);
					@class.Family = Enum84.const_11;
					if ((shape as AutoShape).ShapeType == ShapeType.Rectangle && !(shape as AutoShape).IsTextBox && shape.Placeholder == null)
					{
						Class430 class2 = (Class430)elemPage.method_35("rect", namespaceURI);
						odpPackage.method_10(shape, class2);
						class2.ShapeProperties.DrawStyleName = @class;
						method_19(class2.Transform2D, shape);
						(shape as AutoShape).vmethod_12(@class, odpPackage, class2);
					}
					else if ((shape as AutoShape).ShapeType == ShapeType.Ellipse)
					{
						Class391 class3 = (Class391)elemPage.method_35("ellipse", namespaceURI);
						odpPackage.method_10(shape, class3);
						class3.ShapeProperties.DrawStyleName = @class;
						method_19(class3.Transform2D, shape);
						(shape as AutoShape).vmethod_12(@class, odpPackage, class3);
					}
					else if (((shape as AutoShape).ShapeType != ShapeType.Rectangle || !(shape as AutoShape).IsTextBox) && shape.Placeholder == null && ((shape as AutoShape).ShapeType != ShapeType.NotDefined || !(((TextFrame)(shape as AutoShape).TextFrame).TextInternal != "")))
					{
						if ((shape as AutoShape).ShapeType == ShapeType.Line)
						{
							Class402 class4 = (Class402)elemPage.method_35("line", namespaceURI);
							odpPackage.method_10(shape, class4);
							class4.ShapeProperties.DrawStyleName = @class;
							class4.Line2D.X1 = shape.X;
							class4.Line2D.Y1 = shape.Y;
							class4.Line2D.X2 = shape.X + shape.Width;
							class4.Line2D.Y2 = shape.Y + shape.Height;
							(shape as AutoShape).vmethod_12(@class, odpPackage, class4);
							continue;
						}
						if ((shape as AutoShape).ShapeType == ShapeType.Custom)
						{
							Class382 class5 = (Class382)elemPage.method_35("custom-shape", namespaceURI);
							odpPackage.method_10(shape, class5);
							class5.ShapeProperties.DrawStyleName = @class;
							method_19(class5.Transform2D, shape);
							(shape as AutoShape).vmethod_12(@class, odpPackage, class5);
							(shape as AutoShape).Geometry.method_6(class5);
							@class.GraphicProperties.AutoGrowHeight = false;
							continue;
						}
						Class483 class6 = new Class483();
						Class369 class7 = class6.method_2((shape as AutoShape).ShapeType, elemPage);
						if (class7 != null)
						{
							Class382 class8 = (Class382)elemPage.method_35("custom-shape", namespaceURI);
							odpPackage.method_10(shape, class8);
							class8.ShapeProperties.DrawStyleName = @class;
							method_19(class8.Transform2D, shape);
							(shape as AutoShape).vmethod_12(@class, odpPackage, class8);
							@class.GraphicProperties.AutoGrowHeight = false;
							class8.AppendChild(class7);
						}
					}
					else
					{
						Class384 class9 = (Class384)elemPage.method_35("frame", namespaceURI);
						odpPackage.method_10(shape, class9);
						class9.ShapeProperties.PresStyleName = @class;
						@class.Family = Enum84.const_12;
						method_19(class9.Transform2D, shape);
						@class.method_37();
						Class389 shape2 = (Class389)class9.method_35("text-box", namespaceURI);
						if (((TextFrame)(shape as AutoShape).TextFrame).TextInternal != "")
						{
							((TextFrame)(shape as AutoShape).TextFrame).method_13(odpPackage, shape2, (Class438)@class.ParentNode, @class);
						}
						if (shape.Placeholder != null)
						{
							class9.PresentationClass = ((Placeholder)shape.Placeholder).method_0();
							class9.Placeholder = true;
							@class.GraphicProperties.AutoGrowWidth = false;
							@class.GraphicProperties.AutoGrowHeight = false;
						}
						else
						{
							@class.GraphicProperties.StrokeStyle = Enum83.const_0;
							@class.GraphicProperties.FillProperties.FillStyle = Enum36.const_0;
						}
					}
				}
				else if (shape is Connector)
				{
					Class437 class10 = AutoStyles.method_36("gr" + odpPackage.int_0++);
					class10.Family = Enum84.const_11;
					Connector connector = (Connector)shape;
					Class380 class11 = (Class380)elemPage.method_35("connector", namespaceURI);
					odpPackage.method_10(shape, class11);
					class11.ShapeProperties.DrawStyleName = class10;
					switch (connector.ShapeType)
					{
					case ShapeType.BentConnector2:
					case ShapeType.BentConnector3:
					case ShapeType.BentConnector4:
					case ShapeType.BentConnector5:
						class11.DrawType = Enum31.const_0;
						break;
					case ShapeType.CurvedConnector2:
					case ShapeType.CurvedConnector3:
					case ShapeType.CurvedConnector4:
					case ShapeType.CurvedConnector5:
						class11.DrawType = Enum31.const_3;
						break;
					case ShapeType.Line:
					case ShapeType.StraightConnector1:
						class11.DrawType = Enum31.const_2;
						break;
					}
					if (connector.StartShapeConnectedTo != null)
					{
						class11.StartShape = odpPackage.method_11(connector.StartShapeConnectedTo);
						class11.StartGluePoint = (int)connector.StartShapeConnectionSiteIndex;
					}
					if (connector.EndShapeConnectedTo != null)
					{
						class11.EndShape = odpPackage.method_11(connector.EndShapeConnectedTo);
						class11.EndGluePoint = (int)connector.EndShapeConnectionSiteIndex;
					}
					class11.Line2D.X1 = shape.X;
					class11.Line2D.Y1 = shape.Y;
					class11.Line2D.X2 = shape.X + shape.Width;
					class11.Line2D.Y2 = shape.Y + shape.Height;
					connector.vmethod_12(class10, odpPackage, class11);
				}
				else if (shape is PictureFrame)
				{
					Class437 class12 = AutoStyles.method_36("gr" + odpPackage.int_0++);
					class12.Family = Enum84.const_11;
					Class384 class13 = (Class384)elemPage.method_35("frame", namespaceURI);
					method_19(class13.Transform2D, shape);
					class13.ShapeProperties.DrawStyleName = class12;
					class12.method_37();
					Class386 class14 = (Class386)class13.method_35("image", namespaceURI);
					class14.Href = odpPackage.method_9((shape as PictureFrame).PictureFormat.Picture.Image);
				}
				else if (shape is GroupShape && (shape as GroupShape).Shapes != null)
				{
					Class395 elemPage2 = (Class395)elemPage.method_35("g", namespaceURI);
					((ShapeCollection)(shape as GroupShape).Shapes).method_20(elemPage2, odpPackage, AutoStyles);
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}
}
