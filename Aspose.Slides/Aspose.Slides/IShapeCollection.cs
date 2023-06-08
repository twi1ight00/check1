using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Aspose.Slides.Charts;
using Aspose.Slides.SmartArt;

namespace Aspose.Slides;

[Guid("20e97d2e-2bf3-4ef4-bc09-63b471dee64f")]
[ComVisible(true)]
public interface IShapeCollection : ICollection, IEnumerable, IEnumerable<IShape>
{
	IShape this[int index] { get; }

	IGroupShape ParentGroup { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	IChart AddChart(ChartType type, float x, float y, float width, float height);

	IChart AddChart(ChartType type, float x, float y, float width, float height, bool initWithSample);

	ISmartArt AddSmartArt(float x, float y, float width, float height, SmartArtLayoutType layoutType);

	IChart InsertChart(ChartType type, float x, float y, float width, float height, int index);

	IChart InsertChart(ChartType type, float x, float y, float width, float height, int index, bool initWithSample);

	IOleObjectFrame AddOleObjectFrame(float x, float y, float width, float height, string className, byte[] objectData);

	IOleObjectFrame AddOleObjectFrame(float x, float y, float width, float height, string className, string path);

	IOleObjectFrame InsertOleObjectFrame(int index, float x, float y, float width, float height, string className, byte[] objectData);

	IOleObjectFrame InsertOleObjectFrame(int index, float x, float y, float width, float height, string className, string path);

	IVideoFrame AddVideoFrame(float x, float y, float width, float height, string fname);

	IVideoFrame AddVideoFrame(float x, float y, float width, float height, IVideo video);

	IVideoFrame InsertVideoFrame(int index, float x, float y, float width, float height, string fname);

	IAudioFrame AddAudioFrameCD(float x, float y, float width, float height);

	IAudioFrame InsertAudioFrameCD(int index, float x, float y, float width, float height);

	IAudioFrame AddAudioFrameLinked(float x, float y, float width, float height, string fname);

	IAudioFrame InsertAudioFrameLinked(int index, float x, float y, float width, float height, string fname);

	IAudioFrame AddAudioFrameEmbedded(float x, float y, float width, float height, Stream audio_stream);

	IAudioFrame AddAudioFrameEmbedded(float x, float y, float width, float height, IAudio audio);

	IAudioFrame InsertAudioFrameEmbedded(int index, float x, float y, float width, float height, Stream audio_stream);

	IAudioFrame InsertAudioFrameEmbedded(int index, float x, float y, float width, float height, IAudio audio);

	int IndexOf(IShape shape);

	IShape[] ToArray();

	IShape[] ToArray(int startIndex, int count);

	void Reorder(int index, IShape shape);

	void Reorder(int index, params IShape[] shapes);

	IAutoShape AddAutoShape(ShapeType shapeType, float x, float y, float width, float height);

	IAutoShape AddAutoShape(ShapeType shapeType, float x, float y, float width, float height, bool createFromTemplate);

	IAutoShape InsertAutoShape(int index, ShapeType shapeType, float x, float y, float width, float height);

	IAutoShape InsertAutoShape(int index, ShapeType shapeType, float x, float y, float width, float height, bool createFromTemplate);

	IGroupShape AddGroupShape();

	IGroupShape InsertGroupShape(int index);

	IConnector AddConnector(ShapeType shapeType, float x, float y, float width, float height);

	IConnector AddConnector(ShapeType shapeType, float x, float y, float width, float height, bool createFromTemplate);

	IConnector InsertConnector(int index, ShapeType shapeType, float x, float y, float width, float height);

	IConnector InsertConnector(int index, ShapeType shapeType, float x, float y, float width, float height, bool createFromTemplate);

	IPictureFrame AddPictureFrame(ShapeType shapeType, float x, float y, float width, float height, IPPImage image);

	IPictureFrame InsertPictureFrame(int index, ShapeType shapeType, float x, float y, float width, float height, IPPImage image);

	ITable AddTable(float x, float y, double[] columnWidths, double[] rowHeights);

	ITable InsertTable(int index, float x, float y, double[] columnWidths, double[] rowHeights);

	void RemoveAt(int index);

	void Remove(IShape shape);

	void Clear();

	IShape AddClone(IShape sourceShape, float x, float y, float width, float height);

	IShape AddClone(IShape sourceShape, float x, float y);

	IShape AddClone(IShape sourceShape);

	IShape InsertClone(int index, IShape sourceShape, float x, float y, float width, float height);

	IShape InsertClone(int index, IShape sourceShape, float x, float y);

	IShape InsertClone(int index, IShape sourceShape);
}
