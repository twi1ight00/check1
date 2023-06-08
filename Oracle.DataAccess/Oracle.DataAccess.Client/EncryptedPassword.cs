using System;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

internal class EncryptedPassword : IDisposable
{
	public IntPtr m_encryptedPwd;

	public int m_encryptedPwdLen;

	public IntPtr m_decryptPwdBuffer;

	public string Password
	{
		get
		{
			string text = null;
			int originalLen = 0;
			OpsCon.Decrypt(out m_decryptPwdBuffer, out originalLen, m_encryptedPwd, m_encryptedPwdLen);
			text = Marshal.PtrToStringAuto(m_decryptPwdBuffer);
			OpsCon.ClearDecryptBuff(ref m_decryptPwdBuffer, originalLen);
			return text;
		}
	}

	public EncryptedPassword(string password)
	{
		OpsCon.Encrypt(out m_encryptedPwd, out m_encryptedPwdLen, password, password.Length);
	}

	public EncryptedPassword(IntPtr encryptedPwd, int encryptedPwdLen)
	{
		m_encryptedPwd = encryptedPwd;
		m_encryptedPwdLen = encryptedPwdLen;
	}

	public void Dispose()
	{
		Marshal.FreeCoTaskMem(m_encryptedPwd);
		m_encryptedPwd = IntPtr.Zero;
		m_encryptedPwdLen = 0;
		Marshal.FreeCoTaskMem(m_decryptPwdBuffer);
		m_decryptPwdBuffer = IntPtr.Zero;
		GC.SuppressFinalize(this);
	}

	~EncryptedPassword()
	{
		Dispose();
	}
}
