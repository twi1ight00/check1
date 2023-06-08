using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using ns221;

namespace ns35;

internal interface Interface32
{
	Interface34 GraphicsTools { get; set; }

	Region Clip { get; set; }

	RectangleF ClipBounds { get; }

	float DpiX { get; }

	float DpiY { get; }

	bool IsClipEmpty { get; }

	bool IsVisibleClipEmpty { get; }

	GraphicsUnit PageUnit { get; set; }

	float PageScale { get; set; }

	Point RenderingOrigin { get; set; }

	SmoothingMode SmoothingMode { get; set; }

	TextRenderingHint TextRenderingHint { get; set; }

	Matrix Transform { get; set; }

	RectangleF VisibleClipBounds { get; }

	CompositingQuality CompositingQuality { get; set; }

	int TextContrast { get; set; }

	[Attribute7(true)]
	void imethod_0();

	[Attribute7(true)]
	Bitmap imethod_1();

	void Clear(Color color);

	void imethod_2();

	void Dispose();

	void imethod_3(Pen pen, Rectangle rect, float startAngle, float sweepAngle);

	void imethod_4(Pen pen, RectangleF rect, float startAngle, float sweepAngle);

	void imethod_5(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle);

	void imethod_6(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle);

	void imethod_7(Pen pen, Point pt1, Point pt2, Point pt3, Point pt4);

	void imethod_8(Pen pen, PointF pt1, PointF pt2, PointF pt3, PointF pt4);

	void imethod_9(Pen pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4);

	void imethod_10(Pen pen, Point[] points);

	void imethod_11(Pen pen, PointF[] points);

	void imethod_12(Pen pen, Point[] points);

	void imethod_13(Pen pen, PointF[] points);

	void imethod_14(Pen pen, Point[] points, float tension, FillMode fillmode);

	void imethod_15(Pen pen, PointF[] points, float tension, FillMode fillmode);

	void imethod_16(Pen pen, Point[] points);

	void imethod_17(Pen pen, PointF[] points);

	void imethod_18(Pen pen, Point[] points, float tension);

	void imethod_19(Pen pen, PointF[] points, float tension);

	void imethod_20(Pen pen, PointF[] points, int offset, int numberOfSegments);

	void imethod_21(Pen pen, Point[] points, int offset, int numberOfSegments, float tension);

	void imethod_22(Pen pen, PointF[] points, int offset, int numberOfSegments, float tension);

	void imethod_23(Pen pen, Rectangle rect);

	void imethod_24(Pen pen, RectangleF rect);

	void imethod_25(Pen pen, int x, int y, int width, int height);

	void imethod_26(Pen pen, float x, float y, float width, float height);

	void imethod_27(Image image, Point point);

	void imethod_28(Image image, PointF point);

	void imethod_29(Image image, Rectangle rect);

	void imethod_30(Image image, RectangleF rect);

	void imethod_31(Image image, int x, int y);

	void imethod_32(Image image, float x, float y);

	void imethod_33(Image image, int x, int y, int width, int height);

	void imethod_34(Image image, float x, float y, float width, float height);

	void imethod_35(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit);

	void imethod_36(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit);

	void imethod_37(Image image, Rectangle destRect, Rectangle srcRect, GraphicsUnit srcUnit);

	void imethod_38(Image image, RectangleF destRect, RectangleF srcRect, GraphicsUnit srcUnit);

	void imethod_39(Pen pen, Point pt1, Point pt2);

	void imethod_40(Pen pen, PointF pt1, PointF pt2);

	void imethod_41(Pen pen, int x1, int y1, int x2, int y2);

	void imethod_42(Pen pen, float x1, float y1, float x2, float y2);

	void imethod_43(Pen pen, Point[] points);

	void imethod_44(Pen pen, PointF[] points);

	void imethod_45(Pen pen, GraphicsPath path);

	void imethod_46(Pen pen, Rectangle rect, float startAngle, float sweepAngle);

	void imethod_47(Pen pen, RectangleF rect, float startAngle, float sweepAngle);

	void imethod_48(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle);

	void imethod_49(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle);

	void imethod_50(Pen pen, Point[] points);

	void imethod_51(Pen pen, PointF[] points);

	void imethod_52(Pen pen, Rectangle rect);

	void imethod_53(Pen pen, int x, int y, int width, int height);

	void imethod_54(Pen pen, float x, float y, float width, float height);

	void imethod_55(Pen pen, Rectangle[] rects);

	void imethod_56(Pen pen, RectangleF[] rects);

	void imethod_57(string s, Font font, Brush brush, PointF point);

	void imethod_58(string s, Font font, Brush brush, RectangleF layoutRectangle);

	void imethod_59(string s, Font font, Brush brush, Rectangle layoutRectangle);

	void imethod_60(string s, Font font, Brush brush, PointF point, StringFormat format);

	void imethod_61(string s, Font font, Brush brush, RectangleF layoutRectangle, StringFormat format);

	void imethod_62(string s, Font font, Brush brush, Rectangle layoutRectangle, StringFormat format);

	void imethod_63(string s, Font font, Brush brush, float x, float y);

	void imethod_64(string s, Font font, Brush brush, float x, float y, StringFormat format);

	void imethod_65(Rectangle rect);

	void imethod_66(Region region);

	void imethod_67(Brush brush, Point[] points);

	void imethod_68(Brush brush, PointF[] points);

	void imethod_69(Brush brush, Point[] points, FillMode fillmode);

	void imethod_70(Brush brush, PointF[] points, FillMode fillmode);

	void imethod_71(Brush brush, Point[] points, FillMode fillmode, float tension);

	void imethod_72(Brush brush, PointF[] points, FillMode fillmode, float tension);

	void imethod_73(Brush brush, Rectangle rect);

	void imethod_74(Brush brush, RectangleF rect);

	void imethod_75(Brush brush, int x, int y, int width, int height);

	void imethod_76(Brush brush, float x, float y, float width, float height);

	void imethod_77(Brush brush, GraphicsPath path);

	void imethod_78(Brush brush, Rectangle rect, float startAngle, float sweepAngle);

	void imethod_79(Brush brush, int x, int y, int width, int height, int startAngle, int sweepAngle);

	void imethod_80(Brush brush, float x, float y, float width, float height, float startAngle, float sweepAngle);

	void imethod_81(Brush brush, Point[] points);

	void imethod_82(Brush brush, PointF[] points);

	void imethod_83(Brush brush, Point[] points, FillMode fillMode);

	void imethod_84(Brush brush, PointF[] points, FillMode fillMode);

	void imethod_85(Brush brush, Rectangle rect);

	void imethod_86(Brush brush, RectangleF rect);

	void imethod_87(Brush brush, int x, int y, int width, int height);

	void imethod_88(Brush brush, float x, float y, float width, float height);

	void imethod_89(Brush brush, Rectangle[] rects);

	void imethod_90(Brush brush, RectangleF[] rects);

	void imethod_91(Brush brush, Region region);

	void Flush();

	void Flush(FlushIntention intention);

	Color imethod_92(Color color);

	void imethod_93(Rectangle rect);

	void imethod_94(RectangleF rect);

	void imethod_95(Region region);

	bool imethod_96(Point point);

	bool imethod_97(PointF point);

	bool imethod_98(Rectangle rect);

	bool imethod_99(RectangleF rect);

	bool imethod_100(int x, int y);

	bool imethod_101(float x, float y);

	bool imethod_102(int x, int y, int width, int height);

	bool imethod_103(float x, float y, float width, float height);

	Region[] imethod_104(string text, Font font, RectangleF layoutRect, StringFormat stringFormat);

	SizeF imethod_105(string text, Font font);

	SizeF imethod_106(string text, Font font, SizeF layoutArea);

	SizeF imethod_107(string text, Font font, int width);

	SizeF imethod_108(string text, Font font, PointF origin, StringFormat stringFormat);

	SizeF imethod_109(string text, Font font, SizeF layoutArea, StringFormat stringFormat);

	SizeF imethod_110(string text, Font font, int width, StringFormat format);

	SizeF imethod_111(string text, Font font, SizeF layoutArea, StringFormat stringFormat, out int charactersFitted, out int linesFilled);

	void imethod_112(Matrix matrix);

	void imethod_113(Matrix matrix, MatrixOrder order);

	void ResetClip();

	void ResetTransform();

	void imethod_114(GraphicsState gstate);

	void imethod_115(float angle);

	void imethod_116(float angle, MatrixOrder order);

	GraphicsState Save();

	void imethod_117(float sx, float sy);

	void imethod_118(float sx, float sy, MatrixOrder order);

	void imethod_119(GraphicsPath path);

	void imethod_120(Interface32 g);

	void imethod_121(Rectangle rect);

	void imethod_122(RectangleF rect);

	void imethod_123(GraphicsPath path, CombineMode combineMode);

	void imethod_124(Interface32 g, CombineMode combineMode);

	void imethod_125(Rectangle rect, CombineMode combineMode);

	void imethod_126(RectangleF rect, CombineMode combineMode);

	void imethod_127(Region region, CombineMode combineMode);

	void imethod_128(CoordinateSpace destSpace, CoordinateSpace srcSpace, Point[] pts);

	void imethod_129(CoordinateSpace destSpace, CoordinateSpace srcSpace, PointF[] pts);

	void imethod_130(int dx, int dy);

	void imethod_131(float dx, float dy);

	void imethod_132(float dx, float dy);

	void imethod_133(float dx, float dy, MatrixOrder order);
}
