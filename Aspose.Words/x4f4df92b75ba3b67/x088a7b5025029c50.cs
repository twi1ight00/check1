namespace x4f4df92b75ba3b67;

internal class x088a7b5025029c50 : x264ba3b7aca691be
{
	private readonly xe21bbe9dfab6c4dd x64f784fc78cd5254;

	private readonly xbad6feb536166b6b x8ab580eed4dea44a;

	internal int xd44988f225497f3a => x8ab580eed4dea44a.Count;

	public xe21bbe9dfab6c4dd x2107de3fc2a21893 => x64f784fc78cd5254;

	internal x088a7b5025029c50(x4882ae789be6e2ef context)
		: base(context)
	{
		x8ab580eed4dea44a = new xbad6feb536166b6b();
		x64f784fc78cd5254 = new xe21bbe9dfab6c4dd(context);
	}

	internal void x915eab2b9175eade(string x555bd8d30268b276)
	{
		x8ab580eed4dea44a.Add(x555bd8d30268b276);
	}

	internal string xbcf8e06f8b5cefff()
	{
		if (x8ab580eed4dea44a.Count != 0)
		{
			return (string)x8ab580eed4dea44a[0];
		}
		return string.Empty;
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		writer.xa4dc0ad8886e23a2("/Type", "/Pages");
		writer.xa4dc0ad8886e23a2("/Count", x8ab580eed4dea44a.Count);
		writer.x6210059f049f0d48("/Kids");
		x8ab580eed4dea44a.x10f3680c04d77f08(writer);
		writer.x6210059f049f0d48("/Resources");
		writer.xafb7e6f79ed43681();
		x64f784fc78cd5254.x0a2e1f2c2da67e52(writer);
		writer.x693a8d6d020474f2();
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
		x64f784fc78cd5254.x17c56662e4294017(writer);
	}
}
