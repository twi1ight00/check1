namespace LumiSoft.Net.AUTH;

public enum SaslAuthTypes
{
	None = 0,
	Plain = 1,
	Login = 2,
	Cram_md5 = 4,
	Digest_md5 = 8,
	All = 15
}
