using System;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using x5794c252ba25e723;

namespace xde385359626e77eb;

internal class xa4369c8993e5e35e
{
	private bool xd8e9521024322207;

	private double xecd82f6d254802ca;

	internal x66ed6507f98b1be8 x7d880ef92b7e4841(Paragraph x31e6518f5e08db6c)
	{
		x66ed6507f98b1be8 x66ed6507f98b1be9 = new x66ed6507f98b1be8();
		int num = 0;
		foreach (Node childNode in x31e6518f5e08db6c.ChildNodes)
		{
			switch (childNode.NodeType)
			{
			case NodeType.FieldStart:
				num++;
				break;
			case NodeType.FieldSeparator:
				num--;
				break;
			case NodeType.FieldEnd:
			{
				FieldEnd fieldEnd = (FieldEnd)childNode;
				if (!fieldEnd.HasSeparator)
				{
					num--;
				}
				break;
			}
			default:
				if (num == 0)
				{
					x53ed331c1f3b8fda(childNode, x66ed6507f98b1be9);
				}
				break;
			}
			if (xd8e9521024322207)
			{
				xdde8c737fdaad594(x66ed6507f98b1be9);
			}
		}
		ParagraphFormat paragraphFormat = x31e6518f5e08db6c.ParagraphFormat;
		double num2 = paragraphFormat.LeftIndent + paragraphFormat.RightIndent;
		if (paragraphFormat.FirstLineIndent < 0.0)
		{
			num2 -= paragraphFormat.FirstLineIndent;
		}
		x66ed6507f98b1be9.xd6b6ed77479ef68c(num2);
		return x66ed6507f98b1be9;
	}

	private void x53ed331c1f3b8fda(Node xda5bf54deb817e37, x66ed6507f98b1be8 x9b0739496f8b5475)
	{
		switch (xda5bf54deb817e37.NodeType)
		{
		case NodeType.Run:
		{
			Run run = (Run)xda5bf54deb817e37;
			xbd177059d4974325(run, x9b0739496f8b5475);
			x9b0739496f8b5475.x9f4c543928c73298 += xaee1c0588639d742(run.Text, run);
			break;
		}
		case NodeType.GroupShape:
		case NodeType.Shape:
		{
			ShapeBase shapeBase = (ShapeBase)xda5bf54deb817e37;
			if (shapeBase.IsInline)
			{
				x9b0739496f8b5475.xf41d956c067e2b4d = Math.Max(x9b0739496f8b5475.xf41d956c067e2b4d, shapeBase.Width);
				x9b0739496f8b5475.x9f4c543928c73298 += shapeBase.Width;
			}
			break;
		}
		case NodeType.Comment:
		case NodeType.Footnote:
			break;
		}
	}

	private void xbd177059d4974325(Run xb0e5d73738e62f9e, x66ed6507f98b1be8 x30fdecd22136d9de)
	{
		int xd4f974c06ffa392b = 0;
		int num = 0;
		for (int i = 0; i < xb0e5d73738e62f9e.Text.Length; i++)
		{
			char c = xb0e5d73738e62f9e.Text[i];
			if (char.IsWhiteSpace(c) || c == '-')
			{
				if (xd8e9521024322207)
				{
					x078636a93569b1b4(xb0e5d73738e62f9e, xd4f974c06ffa392b, num);
					xdde8c737fdaad594(x30fdecd22136d9de);
					num = 0;
				}
			}
			else
			{
				if (!xd8e9521024322207)
				{
					xd8e9521024322207 = true;
					xd4f974c06ffa392b = i;
				}
				num++;
			}
		}
		if (xd8e9521024322207)
		{
			x078636a93569b1b4(xb0e5d73738e62f9e, xd4f974c06ffa392b, num);
		}
	}

	private void x078636a93569b1b4(Run xb0e5d73738e62f9e, int xd4f974c06ffa392b, int x961016a387451f05)
	{
		string xb41faee6912a = xb0e5d73738e62f9e.Text.Substring(xd4f974c06ffa392b, x961016a387451f05);
		xecd82f6d254802ca += xaee1c0588639d742(xb41faee6912a, xb0e5d73738e62f9e);
	}

	private void xdde8c737fdaad594(x66ed6507f98b1be8 x30fdecd22136d9de)
	{
		x30fdecd22136d9de.xf41d956c067e2b4d = Math.Max(x30fdecd22136d9de.xf41d956c067e2b4d, xecd82f6d254802ca);
		xecd82f6d254802ca = 0.0;
		xd8e9521024322207 = false;
	}

	private static double xaee1c0588639d742(string xb41faee6912a2313, Run xb0e5d73738e62f9e)
	{
		xe39d06eee35dd23d xe39d06eee35dd23d = x5aa0c6c055954ed8(xb0e5d73738e62f9e.Font, xb0e5d73738e62f9e.x357c90b33d6bb8e6());
		return xe39d06eee35dd23d.xee2b4ba51feab3ca(xb41faee6912a2313);
	}

	private static xe39d06eee35dd23d x5aa0c6c055954ed8(Font x26094932cf7a9139, Document x6beba47238e0ade6)
	{
		return x6beba47238e0ade6.FontInfos.x26ee10d60756aeab.x491f5a7224612753(x26094932cf7a9139.Name, (float)x26094932cf7a9139.Size, x26094932cf7a9139.xfa47517dba72fd20);
	}
}
