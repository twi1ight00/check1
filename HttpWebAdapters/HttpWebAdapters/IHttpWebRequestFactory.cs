using System;

namespace HttpWebAdapters;

public interface IHttpWebRequestFactory
{
	IHttpWebRequest Create(Uri url);
}
