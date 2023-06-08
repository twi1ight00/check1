using System;
using System.Collections;
using System.IO;
using Aspose.Words.Loading;
using x6c95d9cf46ff5f25;
using x7c4557e104065fc9;
using xf9a9481c3f63a419;

namespace x9b5b1a17490bd5f3;

internal class x0cd0eeb5ca95cea9
{
	private readonly IResourceLoadingCallback xe50b02df29e39a57;

	private readonly Hashtable xc7024c8b00ff682e = new Hashtable();

	private readonly Hashtable x50c2d81ea4838596 = new Hashtable();

	internal x0cd0eeb5ca95cea9()
	{
		xe50b02df29e39a57 = null;
	}

	internal x0cd0eeb5ca95cea9(IResourceLoadingCallback resourceLoadingCallback)
	{
		xe50b02df29e39a57 = resourceLoadingCallback;
	}

	internal byte[] x184a537960bc4865(string x50fc2dc03ef1fe05, string x66fab2e81382593c)
	{
		return x5d95f5f98c940295(x50fc2dc03ef1fe05, x66fab2e81382593c, ResourceType.Image);
	}

	internal byte[] x2f708ebc1039d3df(string x50fc2dc03ef1fe05, string x66fab2e81382593c)
	{
		x50c2d81ea4838596.Remove(x66fab2e81382593c);
		return x184a537960bc4865(x50fc2dc03ef1fe05, x66fab2e81382593c);
	}

	internal string xfef1b21403df783d(string x50fc2dc03ef1fe05, string x8d4ce16b2d1964d3)
	{
		return xdd5f8fa06fd44b1f(x5d95f5f98c940295(x50fc2dc03ef1fe05, x8d4ce16b2d1964d3, ResourceType.CssStyleSheet));
	}

	internal void xd1150d5ec6c325df(string x50a18ad2656e7181, byte[] x4a3f0a05c02f235f)
	{
		x50c2d81ea4838596[x50a18ad2656e7181] = x4a3f0a05c02f235f;
	}

	private byte[] x5d95f5f98c940295(string x50fc2dc03ef1fe05, string x66fab2e81382593c, ResourceType x21cbe6ff65dc3fc2)
	{
		string text = x0d4d45882065c63e.x53d54e96515ee37d(x50fc2dc03ef1fe05, x66fab2e81382593c);
		if (xe50b02df29e39a57 == null)
		{
			return x0a762b8688d94527(x66fab2e81382593c, text, x21cbe6ff65dc3fc2);
		}
		ResourceLoadingArgs resourceLoadingArgs = new ResourceLoadingArgs(text, x66fab2e81382593c, x21cbe6ff65dc3fc2);
		return xe50b02df29e39a57.ResourceLoading(resourceLoadingArgs) switch
		{
			ResourceLoadingAction.Default => x0a762b8688d94527(x66fab2e81382593c, resourceLoadingArgs.Uri, x21cbe6ff65dc3fc2), 
			ResourceLoadingAction.Skip => null, 
			ResourceLoadingAction.UserProvided => resourceLoadingArgs.xd378208b5267f7e2(), 
			_ => null, 
		};
	}

	private byte[] x0a762b8688d94527(string x66fab2e81382593c, string x3f738a805dd5808c, ResourceType x21cbe6ff65dc3fc2)
	{
		if (x50c2d81ea4838596.Contains(x66fab2e81382593c))
		{
			return (byte[])x50c2d81ea4838596[x66fab2e81382593c];
		}
		if (xc7024c8b00ff682e.Contains(x3f738a805dd5808c))
		{
			return (byte[])xc7024c8b00ff682e[x3f738a805dd5808c];
		}
		byte[] array = xcfe861b0b1fee17b(x3f738a805dd5808c, x21cbe6ff65dc3fc2);
		xc7024c8b00ff682e[x3f738a805dd5808c] = array;
		return array;
	}

	private static byte[] xcfe861b0b1fee17b(string xbda579af315c6893, ResourceType x21cbe6ff65dc3fc2)
	{
		switch (x21cbe6ff65dc3fc2)
		{
		case ResourceType.CssStyleSheet:
			return x0c8d428d9cb5ca93(xbda579af315c6893);
		case ResourceType.Image:
		{
			byte[] array = x495fdb45f3d92b70.x67ec207e977a9cea(xbda579af315c6893);
			if (array == null && !x0d4d45882065c63e.xc327dd161360e68e(xbda579af315c6893))
			{
				array = x0c8d428d9cb5ca93(xbda579af315c6893);
			}
			if (array == null)
			{
				array = x0d299f323d241756.xcd6c2a9742c9220a();
			}
			return array;
		}
		default:
			return null;
		}
	}

	private static byte[] x0c8d428d9cb5ca93(string xbda579af315c6893)
	{
		try
		{
			using Stream x23cda4cfdf81f2cf = xed747ca236d86aa0.xb93ba02d7ec640e0(xbda579af315c6893);
			return x0d299f323d241756.xa0aed4cd3b3d5d92(x23cda4cfdf81f2cf);
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static string xdd5f8fa06fd44b1f(byte[] x4a3f0a05c02f235f)
	{
		if (x4a3f0a05c02f235f == null)
		{
			return null;
		}
		using Stream stream = new MemoryStream(x4a3f0a05c02f235f);
		using StreamReader streamReader = new StreamReader(stream);
		return streamReader.ReadToEnd();
	}
}
