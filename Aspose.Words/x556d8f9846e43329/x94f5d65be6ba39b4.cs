using System.Collections;
using Aspose.Words.Drawing;
using x6c95d9cf46ff5f25;

namespace x556d8f9846e43329;

internal class x94f5d65be6ba39b4
{
	private static readonly Hashtable x7660b2bbd0607e4f;

	private static readonly Hashtable x238eae4ac21bd0fb;

	private static readonly Hashtable x7631e7053fead5d7;

	private static readonly Hashtable x700a0c1ac37c805c;

	internal static object x1349f6b2c2f5156d(string xbcea506a33cf9111)
	{
		return x682712679dbc585a.xadb8a11581ae0f33(x7660b2bbd0607e4f, xbcea506a33cf9111);
	}

	internal static string xd2b15bd56bbd56f2(RelativeHorizontalPosition xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x238eae4ac21bd0fb, xbcea506a33cf9111, "\\shpbxcolumn");
	}

	internal static object xb223821a507a8658(string xbcea506a33cf9111)
	{
		return x682712679dbc585a.xadb8a11581ae0f33(x7631e7053fead5d7, xbcea506a33cf9111);
	}

	internal static string x81ebc6d588b0838e(RelativeVerticalPosition xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x700a0c1ac37c805c, xbcea506a33cf9111, "\\shpbypara");
	}

	private x94f5d65be6ba39b4()
	{
	}

	static x94f5d65be6ba39b4()
	{
		x7660b2bbd0607e4f = new Hashtable();
		x238eae4ac21bd0fb = new Hashtable();
		x7631e7053fead5d7 = new Hashtable();
		x700a0c1ac37c805c = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"\\shpbxcolumn",
			RelativeHorizontalPosition.Column,
			"\\shpbxmargin",
			RelativeHorizontalPosition.Margin,
			"\\shpbxpage",
			RelativeHorizontalPosition.Page
		}, x7660b2bbd0607e4f, x238eae4ac21bd0fb);
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"\\shpbymargin",
			RelativeVerticalPosition.Margin,
			"\\shpbypara",
			RelativeVerticalPosition.Paragraph,
			"\\shpbypage",
			RelativeVerticalPosition.Page
		}, x7631e7053fead5d7, x700a0c1ac37c805c);
	}
}
