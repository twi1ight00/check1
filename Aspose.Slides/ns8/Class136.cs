using Aspose.Slides;
using ns56;

namespace ns8;

internal class Class136 : Class116
{
	private bool bool_0;

	private ShapeType shapeType_0;

	public ShapeType ShapeType => shapeType_0;

	public bool IsConnection => bool_0;

	public bool IsHidden => ShapeData.HideGeom;

	public double Rotation => ShapeData.Rot;

	public int ZOrderOffset => ShapeData.ZOrderOff;

	public bool HasImagePlaceholder => ShapeData.BlipPhldr;

	public Class2144[] AdjustValues
	{
		get
		{
			if (ShapeData.AdjLst == null)
			{
				return null;
			}
			return ShapeData.AdjLst.AdjList;
		}
	}

	private Class2188 ShapeData => (Class2188)base.DataNode;

	public Class136(Class2188 diagramNode)
	{
		if (diagramNode.Type == "conn")
		{
			bool_0 = true;
			shapeType_0 = ShapeType.NotDefined;
		}
		else
		{
			shapeType_0 = ((diagramNode.Type == "none") ? ShapeType.NotDefined : Class2555.smethod_0(diagramNode.Type));
		}
	}
}
