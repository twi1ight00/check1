using System.Collections;
using Aspose.Words.Drawing;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class x2f717babec2a8e7f
{
	private const int x38618c26c07ac100 = 0;

	private const int x680f3d7358af161b = 2;

	private const int x8299c87b09aad8ee = -1;

	private const int x42ba8fc4ee099448 = -1;

	private static readonly Hashtable x7660b2bbd0607e4f;

	private static readonly Hashtable x238eae4ac21bd0fb;

	private static readonly Hashtable x7631e7053fead5d7;

	private static readonly Hashtable x700a0c1ac37c805c;

	private static readonly Hashtable xd3151b42e7d14c37;

	private static readonly Hashtable xf057f9c02feec50d;

	private static readonly Hashtable xae1872c5eb9882c8;

	private static readonly Hashtable xb12f6b492f47f35e;

	internal static RelativeHorizontalPosition x06defeda9eeb2545(int xbcea506a33cf9111)
	{
		return (RelativeHorizontalPosition)x682712679dbc585a.xce92de628aa023cf(x7660b2bbd0607e4f, xbcea506a33cf9111, RelativeHorizontalPosition.Column);
	}

	internal static int x2e629e7dee0425f3(RelativeHorizontalPosition xbcea506a33cf9111)
	{
		return (int)x682712679dbc585a.xce92de628aa023cf(x238eae4ac21bd0fb, xbcea506a33cf9111, 0);
	}

	internal static RelativeVerticalPosition x236ab77a519bb64a(int xbcea506a33cf9111)
	{
		return (RelativeVerticalPosition)x682712679dbc585a.xce92de628aa023cf(x7631e7053fead5d7, xbcea506a33cf9111, RelativeVerticalPosition.Paragraph);
	}

	internal static int x0e9e6ad8f0b1a8aa(RelativeVerticalPosition xbcea506a33cf9111)
	{
		return (int)x682712679dbc585a.xce92de628aa023cf(x700a0c1ac37c805c, xbcea506a33cf9111, 2);
	}

	internal static object xd43d4db190ad0d78(int xbcea506a33cf9111)
	{
		return x682712679dbc585a.xadb8a11581ae0f33(xd3151b42e7d14c37, xbcea506a33cf9111);
	}

	internal static int xaaba364645901dfa(HorizontalAlignment xbcea506a33cf9111)
	{
		return (int)x682712679dbc585a.xce92de628aa023cf(xf057f9c02feec50d, xbcea506a33cf9111, -1);
	}

	internal static object xe6b0c89a4a739248(int xbcea506a33cf9111)
	{
		return x682712679dbc585a.xadb8a11581ae0f33(xae1872c5eb9882c8, xbcea506a33cf9111);
	}

	internal static int xc61c9cd360ef06b7(VerticalAlignment xbcea506a33cf9111)
	{
		return (int)x682712679dbc585a.xce92de628aa023cf(xb12f6b492f47f35e, xbcea506a33cf9111, -1);
	}

	private x2f717babec2a8e7f()
	{
	}

	static x2f717babec2a8e7f()
	{
		x7660b2bbd0607e4f = new Hashtable();
		x238eae4ac21bd0fb = new Hashtable();
		x7631e7053fead5d7 = new Hashtable();
		x700a0c1ac37c805c = new Hashtable();
		xd3151b42e7d14c37 = new Hashtable();
		xf057f9c02feec50d = new Hashtable();
		xae1872c5eb9882c8 = new Hashtable();
		xb12f6b492f47f35e = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			0,
			RelativeHorizontalPosition.Column,
			1,
			RelativeHorizontalPosition.Margin,
			2,
			RelativeHorizontalPosition.Page
		}, x7660b2bbd0607e4f, x238eae4ac21bd0fb);
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			0,
			RelativeVerticalPosition.Margin,
			2,
			RelativeVerticalPosition.Paragraph,
			1,
			RelativeVerticalPosition.Page
		}, x7631e7053fead5d7, x700a0c1ac37c805c);
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			-1,
			HorizontalAlignment.None,
			0,
			HorizontalAlignment.Left,
			-4,
			HorizontalAlignment.Center,
			-8,
			HorizontalAlignment.Right,
			-12,
			HorizontalAlignment.Inside,
			-16,
			HorizontalAlignment.Outside
		}, xd3151b42e7d14c37, xf057f9c02feec50d);
		x682712679dbc585a.x70fa1602ceccddee(new object[14]
		{
			-1,
			VerticalAlignment.None,
			0,
			VerticalAlignment.Inline,
			-4,
			VerticalAlignment.Top,
			-8,
			VerticalAlignment.Center,
			-12,
			VerticalAlignment.Bottom,
			-16,
			VerticalAlignment.Inside,
			-20,
			VerticalAlignment.Outside
		}, xae1872c5eb9882c8, xb12f6b492f47f35e);
	}
}
