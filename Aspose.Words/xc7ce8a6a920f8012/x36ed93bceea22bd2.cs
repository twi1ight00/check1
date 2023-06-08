using x5794c252ba25e723;

namespace xc7ce8a6a920f8012;

internal class x36ed93bceea22bd2
{
	private short x4f42947183db5ba4;

	private x54366fa5f75a02f7 x06b983e52d670ed8;

	private string xc61ff88f1f98652d;

	private short xd3c04920a4e99e88;

	private bool x6814a1e81559c8c8;

	public short xde89252455da1b3c => x4f42947183db5ba4;

	public x54366fa5f75a02f7 x52dde376accdec7d => x06b983e52d670ed8;

	public short x71e1774af0bcc655 => xd3c04920a4e99e88;

	public string x759aa16c2016a289 => xc61ff88f1f98652d;

	public bool xaa597fddb4061066 => x6814a1e81559c8c8;

	public x36ed93bceea22bd2(short characterId, x54366fa5f75a02f7 renderTransform, short depth, string name)
		: this(characterId, renderTransform, depth, name, isClip: false)
	{
	}

	public x36ed93bceea22bd2(short characterId, x54366fa5f75a02f7 renderTransform, short depth, string name, bool isClip)
	{
		x4f42947183db5ba4 = characterId;
		x06b983e52d670ed8 = renderTransform;
		xd3c04920a4e99e88 = depth;
		xc61ff88f1f98652d = name;
		x6814a1e81559c8c8 = isClip;
	}
}
