using System;
using System.Drawing;
using xf9a9481c3f63a419;

namespace x4f4df92b75ba3b67;

internal class x3b40d431d373c41d
{
	private readonly string x8e67c4bbce3c5791;

	private readonly x966e2af2b1e11692 xee390238125ebf0e;

	private float x1fbc765ed8d7e811;

	private float x933fbdb4e4f6c448;

	private float xc8ff13cb9454e1a9;

	private float xed5d42e5ec2e2a9e;

	private float x51556d800a83de54;

	internal x3b40d431d373c41d(string pageReference, x966e2af2b1e11692 fitType)
	{
		x8e67c4bbce3c5791 = pageReference;
		xee390238125ebf0e = fitType;
	}

	internal void x10f3680c04d77f08(xcd769e39c0788209 xbdfb620b7167944b)
	{
		xdf8e8e6a82ed16d9(xbdfb620b7167944b);
		x2ac4ecac45a9bb32(xbdfb620b7167944b);
	}

	internal static x3b40d431d373c41d x525204da0664c710(string xc5db7bcaac359126, PointF xb9c2cfae130d9256)
	{
		return x56ffee0dbe7d977d(xc5db7bcaac359126, xb9c2cfae130d9256.X, xb9c2cfae130d9256.Y, 0f);
	}

	internal static x3b40d431d373c41d x56ffee0dbe7d977d(string xc5db7bcaac359126, float xa447fc54e41dfe06, float xc941868c59399d3e, float xa0874d232f06d9c7)
	{
		if (xa0874d232f06d9c7 < 0f)
		{
			throw new ArgumentException("ZoomFactor");
		}
		x3b40d431d373c41d x3b40d431d373c41d2 = new x3b40d431d373c41d(xc5db7bcaac359126, x966e2af2b1e11692.xccd14b62af842293);
		x3b40d431d373c41d2.x933fbdb4e4f6c448 = xa447fc54e41dfe06;
		x3b40d431d373c41d2.x51556d800a83de54 = xc941868c59399d3e;
		x3b40d431d373c41d2.x1fbc765ed8d7e811 = xa0874d232f06d9c7;
		return x3b40d431d373c41d2;
	}

	internal static x3b40d431d373c41d x034ef080bf80d482(string xc5db7bcaac359126)
	{
		return new x3b40d431d373c41d(xc5db7bcaac359126, x966e2af2b1e11692.x2d1c6f18bc1def5a);
	}

	internal static x3b40d431d373c41d xe5e522c399985202(string xc5db7bcaac359126, float xc941868c59399d3e)
	{
		x3b40d431d373c41d x3b40d431d373c41d2 = new x3b40d431d373c41d(xc5db7bcaac359126, x966e2af2b1e11692.x71dae20c93ad569a);
		x3b40d431d373c41d2.x51556d800a83de54 = xc941868c59399d3e;
		return x3b40d431d373c41d2;
	}

	internal static x3b40d431d373c41d xa8d6fd3afc5d3c17(string xc5db7bcaac359126, float xa447fc54e41dfe06)
	{
		x3b40d431d373c41d x3b40d431d373c41d2 = new x3b40d431d373c41d(xc5db7bcaac359126, x966e2af2b1e11692.xf3787b3ee688bce2);
		x3b40d431d373c41d2.x933fbdb4e4f6c448 = xa447fc54e41dfe06;
		return x3b40d431d373c41d2;
	}

	internal static x3b40d431d373c41d x7bc2134a8d9d5fd9(string xc5db7bcaac359126, float xa447fc54e41dfe06, float xaf9a0436a70689de, float xfc2074a859a5db8c, float xc941868c59399d3e)
	{
		x3b40d431d373c41d x3b40d431d373c41d2 = new x3b40d431d373c41d(xc5db7bcaac359126, x966e2af2b1e11692.x47ac23b55726e729);
		x3b40d431d373c41d2.x933fbdb4e4f6c448 = xa447fc54e41dfe06;
		x3b40d431d373c41d2.xed5d42e5ec2e2a9e = xfc2074a859a5db8c;
		x3b40d431d373c41d2.xc8ff13cb9454e1a9 = xaf9a0436a70689de;
		x3b40d431d373c41d2.x51556d800a83de54 = xc941868c59399d3e;
		return x3b40d431d373c41d2;
	}

	internal static x3b40d431d373c41d x7418b464c7bf6cfa(string xc5db7bcaac359126)
	{
		return new x3b40d431d373c41d(xc5db7bcaac359126, x966e2af2b1e11692.x69b912e6d4aa6182);
	}

	internal static x3b40d431d373c41d x0ff78cc043e501ab(string xc5db7bcaac359126, float xc941868c59399d3e)
	{
		x3b40d431d373c41d x3b40d431d373c41d2 = new x3b40d431d373c41d(xc5db7bcaac359126, x966e2af2b1e11692.x2d7b0e2b8b4cd1be);
		x3b40d431d373c41d2.x51556d800a83de54 = xc941868c59399d3e;
		return x3b40d431d373c41d2;
	}

	internal static x3b40d431d373c41d xb80481abceedb8b6(string xc5db7bcaac359126, float xa447fc54e41dfe06)
	{
		x3b40d431d373c41d x3b40d431d373c41d2 = new x3b40d431d373c41d(xc5db7bcaac359126, x966e2af2b1e11692.xd9d623adea60edda);
		x3b40d431d373c41d2.x933fbdb4e4f6c448 = xa447fc54e41dfe06;
		return x3b40d431d373c41d2;
	}

	private void xdf8e8e6a82ed16d9(xcd769e39c0788209 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x6210059f049f0d48("[{0} {1}", x8e67c4bbce3c5791, xb4f4824af7c55e3a.xd915aea585060c45(xee390238125ebf0e));
	}

	private void x2ac4ecac45a9bb32(xcd769e39c0788209 xbdfb620b7167944b)
	{
		string xec7dcb687e97a7d = xca004f56614e2431.xc8ba948e0d631490((int)x933fbdb4e4f6c448);
		string x6ffd1fa6ed = xca004f56614e2431.xc8ba948e0d631490((int)xc8ff13cb9454e1a9);
		string xec7dcb687e97a7d2 = xca004f56614e2431.xc8ba948e0d631490((int)xed5d42e5ec2e2a9e);
		string text = xca004f56614e2431.xc8ba948e0d631490((int)x51556d800a83de54);
		string x774d7397ced = xcd769e39c0788209.x355581fe14891d82(x1fbc765ed8d7e811);
		switch (xee390238125ebf0e)
		{
		case x966e2af2b1e11692.xccd14b62af842293:
			xbdfb620b7167944b.x6210059f049f0d48(" {0} {1} {2}", xec7dcb687e97a7d, text, x774d7397ced);
			break;
		case x966e2af2b1e11692.x71dae20c93ad569a:
		case x966e2af2b1e11692.x2d7b0e2b8b4cd1be:
			xbdfb620b7167944b.x6210059f049f0d48(" {0}", text);
			break;
		case x966e2af2b1e11692.xf3787b3ee688bce2:
		case x966e2af2b1e11692.xd9d623adea60edda:
			xbdfb620b7167944b.x6210059f049f0d48(" {0}", xec7dcb687e97a7d);
			break;
		case x966e2af2b1e11692.x47ac23b55726e729:
			xbdfb620b7167944b.x6210059f049f0d48(" {0} {1}", xec7dcb687e97a7d, x6ffd1fa6ed);
			xbdfb620b7167944b.x6210059f049f0d48("{0} {1}", xec7dcb687e97a7d2, text);
			break;
		default:
			throw new ArgumentOutOfRangeException("FitType");
		case x966e2af2b1e11692.x2d1c6f18bc1def5a:
		case x966e2af2b1e11692.x69b912e6d4aa6182:
			break;
		}
		xbdfb620b7167944b.x6210059f049f0d48("]");
	}
}
