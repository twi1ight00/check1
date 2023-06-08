using Aspose.Words;
using Aspose.Words.Fields;

namespace x2182451cabb5c30d;

internal class x192bb7b8a30d64cd
{
	private readonly xe5e546ef5f0503b2 x8cedcaa9a62c6e39;

	internal x4ba0e0b20eeff53c xe1410f585439c7d4 => x8cedcaa9a62c6e39.xe1410f585439c7d4;

	internal x52108cac3d36b123 xffb3238a8fd59aa7 => x8cedcaa9a62c6e39.xa3a0cc3e91617aca.xffb3238a8fd59aa7;

	internal x192bb7b8a30d64cd(xe5e546ef5f0503b2 context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal bool x06b0e25aa6ad68a9(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\sect":
			xe1410f585439c7d4.xfdbe40d109da78d3(x43ca0f73fa00a937: false);
			break;
		case "\\par":
		case "\\\r":
		case "\\\n":
			xe1410f585439c7d4.xa1237507e66611c4();
			break;
		case "\\cell":
		case "\\nestcell":
			xe1410f585439c7d4.x2f8ca1d7ce36e5c9();
			break;
		case "\\row":
		case "\\nestrow":
			x9c1190c4a7a3b8bc();
			break;
		case "\\subdocument":
		{
			string fileName = (string)x8cedcaa9a62c6e39.x0f1b548a1d4927cb[x153c99a852375422.xd6f9e3c5ae6509d7()];
			xe1410f585439c7d4.xb5d34e6ee4c0fad1(new SubDocument(x8cedcaa9a62c6e39.x2c8c6741422a1298, fileName));
			break;
		}
		case "\\chpgn":
			xe1410f585439c7d4.xc35ba23c63a33fd3(FieldType.FieldPage, "PAGE");
			break;
		case "\\chdate":
			xe1410f585439c7d4.xc35ba23c63a33fd3(FieldType.FieldDate, "date");
			break;
		case "\\chdpl":
			xe1410f585439c7d4.xc35ba23c63a33fd3(FieldType.FieldDate, "date \\@ \"dddd, MMMM d, yyyy\"");
			break;
		case "\\chdpa":
			xe1410f585439c7d4.xc35ba23c63a33fd3(FieldType.FieldDate, "date \\@ \"ddd, MMM d, yyyy\"");
			break;
		case "\\chtime":
			xe1410f585439c7d4.xc35ba23c63a33fd3(FieldType.FieldTime, "time");
			break;
		default:
			return false;
		}
		return true;
	}

	private void x9c1190c4a7a3b8bc()
	{
		if (x8cedcaa9a62c6e39.xde27e91a248c4c90.x5fed4f8aefdd1554)
		{
			xe1410f585439c7d4.x48bcfa796334770b();
		}
		else
		{
			xe1410f585439c7d4.xd53d2436fa960ff6();
		}
	}
}
