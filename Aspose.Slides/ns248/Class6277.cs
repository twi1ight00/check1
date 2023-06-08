using ns219;
using ns263;

namespace ns248;

internal class Class6277
{
	private Interface266 interface266_0;

	private Interface267 interface267_0;

	private Interface268 interface268_0;

	private Interface316 interface316_0;

	internal Interface267 GeometryBuilder
	{
		get
		{
			if (interface267_0 == null)
			{
				interface267_0 = new Class6275();
			}
			return interface267_0;
		}
		set
		{
			interface267_0 = value;
		}
	}

	public Interface266 FillBuilder
	{
		get
		{
			if (interface266_0 == null)
			{
				interface266_0 = new Class6274();
			}
			return interface266_0;
		}
		set
		{
			interface266_0 = value;
		}
	}

	public Interface316 TransformBuilder
	{
		get
		{
			if (interface316_0 == null)
			{
				interface316_0 = new Class6476();
			}
			return interface316_0;
		}
		set
		{
			interface316_0 = value;
		}
	}

	public Interface268 OutlineBuilder
	{
		get
		{
			if (interface268_0 == null)
			{
				interface268_0 = new Class6278();
			}
			return interface268_0;
		}
		set
		{
			interface268_0 = value;
		}
	}

	public void method_0(Class5945 reader, Class6334 node)
	{
		while (reader.method_0("grpSpPr"))
		{
			switch (reader.LocalName)
			{
			case "xfrm":
				node.method_0(TransformBuilder.imethod_0(reader));
				break;
			case "blipFill":
			case "gradFill":
			case "grpFill":
			case "noFill":
			case "pattFill":
			case "solidFill":
				node.Fill = FillBuilder.imethod_0(reader);
				break;
			default:
				reader.method_2();
				break;
			}
		}
	}

	public void method_1(Class5945 reader, Class6337 shape)
	{
		while (reader.method_0("spPr"))
		{
			switch (reader.LocalName)
			{
			case "custGeom":
				shape.Geometry = GeometryBuilder.imethod_0(reader);
				break;
			case "xfrm":
				shape.method_0(TransformBuilder.imethod_1(reader));
				break;
			case "prstGeom":
				shape.Geometry = GeometryBuilder.imethod_0(reader);
				break;
			case "blipFill":
			case "gradFill":
			case "grpFill":
			case "noFill":
			case "pattFill":
			case "solidFill":
				shape.Fill = FillBuilder.imethod_0(reader);
				break;
			case "ln":
				shape.Outline = OutlineBuilder.imethod_0(reader);
				break;
			default:
				reader.method_2();
				break;
			}
		}
	}
}
