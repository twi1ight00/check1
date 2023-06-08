using System;

namespace Aspose.Words.Properties;

[Flags]
public enum DocumentSecurity
{
	None = 0,
	PasswordProtected = 1,
	ReadOnlyRecommended = 2,
	ReadOnlyEnforced = 4,
	ReadOnlyExceptAnnotations = 8
}
