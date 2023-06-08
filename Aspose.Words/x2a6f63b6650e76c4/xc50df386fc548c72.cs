using System.Collections;
using System.Reflection;

namespace x2a6f63b6650e76c4;

[DefaultMember("Item")]
internal class xc50df386fc548c72 : IEnumerable
{
	private class x0f7aee3b19b774ac : IEnumerator
	{
		private readonly xc50df386fc548c72 x1059c66c1b229350;

		private int x57d3c0a64c1df452 = -1;

		private x0f7aee3b19b774ac xec27db935666807a;

		private bool xe598fcca85dac4b4 => xec27db935666807a != null;

		private x82e26649b09596bd x804bee3a0da89463 => (x82e26649b09596bd)Current;

		public object Current
		{
			get
			{
				if (!xe598fcca85dac4b4)
				{
					return x1059c66c1b229350.get_xe6d4b1b411ed94b5(x57d3c0a64c1df452);
				}
				return xec27db935666807a.Current;
			}
		}

		internal x0f7aee3b19b774ac(xc50df386fc548c72 constants)
		{
			x1059c66c1b229350 = constants;
		}

		public bool MoveNext()
		{
			if (xe598fcca85dac4b4)
			{
				if (xec27db935666807a.MoveNext())
				{
					return true;
				}
				xec27db935666807a = null;
			}
			while (true)
			{
				x57d3c0a64c1df452++;
				if (x57d3c0a64c1df452 == x1059c66c1b229350.xd44988f225497f3a)
				{
					return false;
				}
				if (x804bee3a0da89463.xca3ee5e02f497e0b != xca3ee5e02f497e0b.x5f0c9f5e81e8b90f)
				{
					break;
				}
				xbddbf0d43615fbd5 xbddbf0d43615fbd6 = (xbddbf0d43615fbd5)x804bee3a0da89463;
				xec27db935666807a = (x0f7aee3b19b774ac)xbddbf0d43615fbd6.xe4a88350013963a1.GetEnumerator();
				if (xec27db935666807a.MoveNext())
				{
					return true;
				}
			}
			xec27db935666807a = null;
			return true;
		}

		public void Reset()
		{
			x57d3c0a64c1df452 = -1;
		}
	}

	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	internal x82e26649b09596bd xe6d4b1b411ed94b5 => (x82e26649b09596bd)x82b70567a5f68f41[xc0c4c459c6ccbd00];

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal void xd6b6ed77479ef68c(x82e26649b09596bd xb4480c8b340110b9)
	{
		x82b70567a5f68f41.Add(xb4480c8b340110b9);
	}

	public IEnumerator GetEnumerator()
	{
		return new x0f7aee3b19b774ac(this);
	}
}
