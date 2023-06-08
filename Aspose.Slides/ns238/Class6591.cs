using ns224;

namespace ns238;

internal class Class6591
{
	private short short_0;

	private Class6002 class6002_0;

	private string string_0;

	private short short_1;

	private bool bool_0;

	public short CharacterId => short_0;

	public Class6002 RenderTransform => class6002_0;

	public short Depth => short_1;

	public string Name => string_0;

	public bool IsClip => bool_0;

	public Class6591(short characterId, Class6002 renderTransform, short depth, string name)
		: this(characterId, renderTransform, depth, name, isClip: false)
	{
	}

	public Class6591(short characterId, Class6002 renderTransform, short depth, string name, bool isClip)
	{
		short_0 = characterId;
		class6002_0 = renderTransform;
		short_1 = depth;
		string_0 = name;
		bool_0 = isClip;
	}
}
