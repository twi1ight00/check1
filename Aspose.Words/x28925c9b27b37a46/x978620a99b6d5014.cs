using System;
using System.ComponentModel;
using Aspose.Words;

namespace x28925c9b27b37a46;

internal class x978620a99b6d5014 : xbe47717e2fd4172a, x11e014059489ae95
{
	private bool x22de36b78e8541fd;

	private bool xc409e05498e052e6;

	private readonly byte[] xe78c5b5312993f9f = new byte[9];

	private readonly NumberStyle[] xb4b32ede63a9ad06 = new NumberStyle[9];

	private readonly int[] xf2935da897dd51a5 = new int[9];

	private string xc05f9976504b9b97 = "";

	internal bool x8c84b6fad60c11f5
	{
		get
		{
			if (!x55e2dcfc986cb10b)
			{
				return x22f16e8bb3c02a0b;
			}
			return true;
		}
	}

	internal bool x22f16e8bb3c02a0b
	{
		get
		{
			if (xc409e05498e052e6)
			{
				NumberStyle[] array = xb4b32ede63a9ad06;
				foreach (NumberStyle numberStyle in array)
				{
					if (numberStyle != NumberStyle.Bullet)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	internal bool x55e2dcfc986cb10b
	{
		get
		{
			return x22de36b78e8541fd;
		}
		set
		{
			x22de36b78e8541fd = value;
		}
	}

	internal bool x713b07324dddc470
	{
		get
		{
			return xc409e05498e052e6;
		}
		set
		{
			xc409e05498e052e6 = value;
		}
	}

	internal byte[] x044891ce086d094b => xe78c5b5312993f9f;

	internal NumberStyle[] x7e30db41abd34a71 => xb4b32ede63a9ad06;

	internal int[] x632f31cdeda76ff9 => xf2935da897dd51a5;

	internal string x5051a4a3b273ffce
	{
		get
		{
			return xc05f9976504b9b97;
		}
		set
		{
			xc05f9976504b9b97 = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool xc8ea2954a6825f32 => false;

	internal x978620a99b6d5014()
		: base("", DateTime.MinValue)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	private x11e014059489ae95 xa9c9dc40c97ccfd0()
	{
		return (x978620a99b6d5014)MemberwiseClone();
	}

	x11e014059489ae95 x11e014059489ae95.xcc4933610939ad04()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa9c9dc40c97ccfd0
		return this.xa9c9dc40c97ccfd0();
	}
}
