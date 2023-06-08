using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using Aspose.Words;

namespace x28925c9b27b37a46;

[DefaultMember("Item")]
internal class x28980d9c5ec3f471 : x11e014059489ae95
{
	private ArrayList x82b70567a5f68f41 = new ArrayList();

	internal int xd44988f225497f3a
	{
		[DebuggerStepThrough]
		get
		{
			return x82b70567a5f68f41.Count;
		}
	}

	internal TextColumn xe6d4b1b411ed94b5
	{
		get
		{
			return (TextColumn)x82b70567a5f68f41[xc0c4c459c6ccbd00];
		}
		set
		{
			x82b70567a5f68f41[xc0c4c459c6ccbd00] = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool xc8ea2954a6825f32 => false;

	internal void x22d10a164c7c096f(int x5593b5699d080072)
	{
		if (xd44988f225497f3a < x5593b5699d080072)
		{
			while (xd44988f225497f3a < x5593b5699d080072)
			{
				xd6b6ed77479ef68c(new TextColumn());
			}
		}
		else
		{
			while (xd44988f225497f3a > x5593b5699d080072)
			{
				x7121e9e177952651(xd44988f225497f3a - 1);
			}
		}
	}

	internal void xd6b6ed77479ef68c(TextColumn xe3e287548b3d01f5)
	{
		x82b70567a5f68f41.Add(xe3e287548b3d01f5);
	}

	internal void x7121e9e177952651(int xc0c4c459c6ccbd00)
	{
		x82b70567a5f68f41.RemoveAt(xc0c4c459c6ccbd00);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	private x11e014059489ae95 xa9c9dc40c97ccfd0()
	{
		x28980d9c5ec3f471 x28980d9c5ec3f472 = (x28980d9c5ec3f471)MemberwiseClone();
		x28980d9c5ec3f472.x82b70567a5f68f41 = new ArrayList();
		foreach (TextColumn item in x82b70567a5f68f41)
		{
			TextColumn value = item.x8b61531c8ea35b85();
			x28980d9c5ec3f472.x82b70567a5f68f41.Add(value);
		}
		return x28980d9c5ec3f472;
	}

	x11e014059489ae95 x11e014059489ae95.xcc4933610939ad04()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa9c9dc40c97ccfd0
		return this.xa9c9dc40c97ccfd0();
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void xe51ac0997b4155d8(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void xbaca00cc79e72acc(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void x466dd296f7338c95(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void xcbdf0bfb4ca95676(params object[] xcd31b50c43a96e21)
	{
	}
}
