using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("8a495bad-ac20-4481-8c43-c53a490533e4")]
[ComVisible(true)]
public interface IShapeFrame : ICloneable
{
	float X { get; }

	float Y { get; }

	float Width { get; }

	float Height { get; }

	float Rotation { get; }

	float CenterX { get; }

	float CenterY { get; }

	NullableBool FlipH { get; }

	NullableBool FlipV { get; }

	[ComVisible(false)]
	RectangleF Rectangle { get; }

	ICloneable AsICloneable { get; }

	IShapeFrame CloneShapeFrame();
}
