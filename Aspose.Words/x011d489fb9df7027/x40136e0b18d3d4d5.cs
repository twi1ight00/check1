using System;
using System.Collections;
using System.Xml;

namespace x011d489fb9df7027;

internal class x40136e0b18d3d4d5 : ArrayList
{
	private readonly XmlElement xf04bec92f7bf4445;

	internal x40136e0b18d3d4d5(XmlElement blipFill)
	{
		xf04bec92f7bf4445 = blipFill;
	}

	public void xe97ce3351aad63f5()
	{
		if (xf04bec92f7bf4445 != null)
		{
			x5645a78cb658cd2d x4a3f0a05c02f235f = x0d19c72f250ee399();
			x52b190e626f65140(x4a3f0a05c02f235f);
		}
	}

	public void xa5f609130a1a7eae()
	{
		if (xf04bec92f7bf4445 != null)
		{
			x5645a78cb658cd2d x4a3f0a05c02f235f = x400d7e7d70bfb599();
			x52b190e626f65140(x4a3f0a05c02f235f);
		}
	}

	public void x234394dd74461915(byte[] x43e181e083db6cdf)
	{
		if (xf04bec92f7bf4445 != null)
		{
			x5645a78cb658cd2d x5645a78cb658cd2d2 = x0d19c72f250ee399();
			if (x5645a78cb658cd2d2 == null)
			{
				XmlAttribute attr = xc05cd10e5ad6311f("embed");
				Add(new x5645a78cb658cd2d(attr, x43e181e083db6cdf, external: false));
			}
			else
			{
				x5645a78cb658cd2d2.xd2f68ee6f47e9dfb = x43e181e083db6cdf;
			}
		}
	}

	public void x82669cb9f7dd9f94(string xe9c763083b68a7ee)
	{
		if (xf04bec92f7bf4445 != null)
		{
			x5645a78cb658cd2d x5645a78cb658cd2d2 = x400d7e7d70bfb599();
			if (x5645a78cb658cd2d2 == null)
			{
				XmlAttribute attr = xc05cd10e5ad6311f("link");
				Add(new x5645a78cb658cd2d(attr, xe9c763083b68a7ee, external: true));
			}
			else
			{
				x5645a78cb658cd2d2.xd2f68ee6f47e9dfb = xe9c763083b68a7ee;
			}
		}
	}

	internal x5645a78cb658cd2d x0d19c72f250ee399()
	{
		if (xf04bec92f7bf4445 == null)
		{
			return null;
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				x5645a78cb658cd2d x5645a78cb658cd2d2 = (x5645a78cb658cd2d)enumerator.Current;
				if (x5645a78cb658cd2d2.xdb0ebfc0d169741e.OwnerElement == xf04bec92f7bf4445 && x5645a78cb658cd2d2.xdedd2a9303f28980)
				{
					return x5645a78cb658cd2d2;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	internal x5645a78cb658cd2d x400d7e7d70bfb599()
	{
		if (xf04bec92f7bf4445 == null)
		{
			return null;
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				x5645a78cb658cd2d x5645a78cb658cd2d2 = (x5645a78cb658cd2d)enumerator.Current;
				if (x5645a78cb658cd2d2.xdb0ebfc0d169741e.OwnerElement == xf04bec92f7bf4445 && x5645a78cb658cd2d2.x98a0056949b5f2bc)
				{
					return x5645a78cb658cd2d2;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	private XmlAttribute xc05cd10e5ad6311f(string xe8dc17d722705970)
	{
		XmlAttribute xmlAttribute = xf04bec92f7bf4445.OwnerDocument.CreateAttribute("r:" + xe8dc17d722705970, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		xmlAttribute.Value = Guid.NewGuid().ToString();
		xf04bec92f7bf4445.SetAttributeNode(xmlAttribute);
		return xmlAttribute;
	}

	private void x52b190e626f65140(x5645a78cb658cd2d x4a3f0a05c02f235f)
	{
		if (x4a3f0a05c02f235f != null)
		{
			Remove(x4a3f0a05c02f235f);
			xf04bec92f7bf4445.RemoveAttributeNode(x4a3f0a05c02f235f.xdb0ebfc0d169741e);
		}
	}
}
