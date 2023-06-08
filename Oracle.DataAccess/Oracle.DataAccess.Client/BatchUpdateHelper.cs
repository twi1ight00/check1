using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace Oracle.DataAccess.Client;

internal sealed class BatchUpdateHelper
{
	private OracleCommand m_batchCommand;

	private StringBuilder m_batchCmdTextBuilder;

	private StringBuilder m_tempStringBuilder;

	private ArrayList m_paramArrayArray;

	private Hashtable m_usedParameterNames;

	private static Regex m_parserRegEx;

	private static string m_strDeclareBlock;

	private static string m_strExceptionBlock;

	private static string m_strRowCountBlock;

	private static string m_outParamAssignmentBlock;

	private OracleParameter m_prmRowsModified;

	private OracleParameter m_prmErrCodesArray;

	private OracleParameter m_prmErrMsgArray;

	private OracleParameter m_prmRowsMdArray;

	private int m_lastNumUsed;

	private int m_batchSizeCounter;

	private static string m_plsqlBlockPrefix;

	private static string m_plsqlBlockSuffix;

	private static string m_bindPrmPrefix;

	private static string m_commandSuffix;

	private static string COLON;

	private static int m_bindParameterMarkerGroup;

	internal OracleCommand BatchUpdateCommand => m_batchCommand;

	static BatchUpdateHelper()
	{
		m_plsqlBlockPrefix = "BEGIN\n";
		m_plsqlBlockSuffix = "END;";
		m_bindPrmPrefix = ":C";
		m_commandSuffix = ";\n";
		COLON = ":";
		string pattern = "[\\s]+|(?<string>'([^']|'')*')|(?<comment>(/\\*([^\\*]|\\*[^/])*\\*/)|(--.*))|(?<bindparammarker>:[\\p{Lo}\\p{Lu}\\p{Ll}\\p{Lm}\\p{Nd}\\uff3f_#$]+)|(?<query>select)|(?<identifier>([\\p{Lo}\\p{Lu}\\p{Ll}\\p{Lm}\\p{Nd}\\uff3f_#$]+)|(\"([^\"]|\"\")*\"))|(?<other>.)";
		m_parserRegEx = new Regex(pattern, RegexOptions.ExplicitCapture);
		m_bindParameterMarkerGroup = m_parserRegEx.GroupNumberFromName("bindparammarker");
		m_strDeclareBlock = "DECLARE\n";
		if (OraTrace.m_RevertBUErrHandling == 1)
		{
			m_strDeclareBlock += "cce EXCEPTION;\n";
			m_strDeclareBlock += "PRAGMA EXCEPTION_INIT(cce, -08179);\n";
		}
		m_strDeclareBlock += "TYPE tec IS TABLE OF NUMBER INDEX BY BINARY_INTEGER;\n";
		m_strDeclareBlock += "TYPE trmd IS TABLE OF NUMBER INDEX BY BINARY_INTEGER;\n";
		m_strDeclareBlock += "TYPE tem IS TABLE OF VARCHAR2(256) INDEX BY BINARY_INTEGER;\n";
		m_strDeclareBlock += "rct NUMBER:=0;\n";
		m_strDeclareBlock += "rmd NUMBER:=0;\n";
		m_strDeclareBlock += "aecd tec;\n";
		m_strDeclareBlock += "armd trmd;\n";
		m_strDeclareBlock += "aem  tem;\n";
		if (OraTrace.m_RevertBUErrHandling == 1)
		{
			m_strRowCountBlock = "IF (SQL%ROWCOUNT = 0) THEN\n";
			m_strRowCountBlock += "RAISE cce;\n";
			m_strRowCountBlock += "ELSE\n";
			m_strRowCountBlock += "armd(rct):=SQL%ROWCOUNT;\n";
			m_strRowCountBlock += "rmd:=rmd+SQL%ROWCOUNT;\n";
			m_strRowCountBlock += "END IF;\n";
		}
		else
		{
			m_strRowCountBlock = "armd(rct):=SQL%ROWCOUNT;\n";
			m_strRowCountBlock += "rmd:=rmd+SQL%ROWCOUNT;\n";
			m_strRowCountBlock += "aecd(rct):=0;\n";
		}
		m_strExceptionBlock = "EXCEPTION\n";
		m_strExceptionBlock += "WHEN OTHERS THEN\n";
		m_strExceptionBlock += "armd(rct):=0;\n";
		m_strExceptionBlock += "aecd(rct):=SQLCODE;\n";
		m_strExceptionBlock += "aem(rct):=SQLERRM;\n";
		m_strExceptionBlock += "end;\n";
		m_outParamAssignmentBlock = ":rmd:=rmd;\n";
		m_outParamAssignmentBlock += ":aecd:=aecd;\n";
		m_outParamAssignmentBlock += ":aem:=aem;\n";
		m_outParamAssignmentBlock += ":armd:=armd;\n";
	}

	internal BatchUpdateHelper()
	{
		m_batchCommand = new OracleCommand();
		m_paramArrayArray = new ArrayList();
		m_batchCmdTextBuilder = new StringBuilder();
		m_tempStringBuilder = new StringBuilder();
		m_usedParameterNames = new Hashtable();
		m_batchCmdTextBuilder.Append(m_plsqlBlockPrefix);
		m_batchSizeCounter = 0;
		m_lastNumUsed = 0;
		m_prmRowsModified = new OracleParameter();
		m_prmRowsModified.ParameterName = "rmd";
		m_prmRowsModified.DbType = DbType.Int32;
		m_prmRowsModified.Direction = ParameterDirection.Output;
		m_prmErrCodesArray = new OracleParameter();
		m_prmErrCodesArray.ParameterName = "aecd";
		m_prmErrCodesArray.DbType = DbType.Int32;
		m_prmErrCodesArray.Direction = ParameterDirection.Output;
		m_prmErrCodesArray.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
		m_prmErrMsgArray = new OracleParameter();
		m_prmErrMsgArray.ParameterName = "aem";
		m_prmErrMsgArray.DbType = DbType.String;
		m_prmErrMsgArray.Direction = ParameterDirection.Output;
		m_prmErrMsgArray.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
		m_prmRowsMdArray = new OracleParameter();
		m_prmRowsMdArray.ParameterName = "armd";
		m_prmRowsMdArray.DbType = DbType.Int32;
		m_prmRowsMdArray.Direction = ParameterDirection.Output;
		m_prmRowsMdArray.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
	}

	internal void InitializeBUC()
	{
		m_batchCommand.CommandText = null;
		OracleParameterCollection parameters = m_batchCommand.Parameters;
		long num = parameters.Count;
		for (int i = 0; i < num - 4; i++)
		{
			parameters[i].Dispose();
		}
		parameters.Clear();
		m_paramArrayArray.Clear();
		m_usedParameterNames.Clear();
		m_batchSizeCounter = 0;
		m_batchCmdTextBuilder.Remove(0, m_batchCmdTextBuilder.Length);
		m_batchCmdTextBuilder.Append(m_strDeclareBlock);
		m_batchCmdTextBuilder.Append(m_plsqlBlockPrefix);
		m_lastNumUsed = 0;
	}

	internal void FinalizeBUC()
	{
		m_batchCmdTextBuilder.Append(m_outParamAssignmentBlock);
		m_batchCmdTextBuilder.Append(m_plsqlBlockSuffix);
		m_batchCommand.Parameters.Add(m_prmRowsModified);
		m_prmErrCodesArray.Size = m_batchSizeCounter;
		m_batchCommand.Parameters.Add(m_prmErrCodesArray);
		m_prmErrMsgArray.Size = m_batchSizeCounter;
		int[] array = new int[m_batchSizeCounter];
		for (int i = 0; i < m_batchSizeCounter; i++)
		{
			array[i] = 256;
		}
		m_prmErrMsgArray.ArrayBindSize = array;
		m_batchCommand.Parameters.Add(m_prmErrMsgArray);
		m_prmRowsMdArray.Size = m_batchSizeCounter;
		m_batchCommand.Parameters.Add(m_prmRowsMdArray);
		m_batchCommand.CommandText = m_batchCmdTextBuilder.ToString();
	}

	internal int AddCommand(OracleCommand command)
	{
		if (command == null)
		{
			throw new ArgumentNullException();
		}
		m_batchSizeCounter++;
		OracleParameterCollection parameters = command.Parameters;
		OracleParameter[] array = CloneParameters(parameters);
		m_paramArrayArray.Add(array);
		m_batchCmdTextBuilder.Append(m_plsqlBlockPrefix);
		m_batchCmdTextBuilder.Append("rct:=rct+1;\n");
		if (CommandType.StoredProcedure == command.CommandType)
		{
			ParseStoredProcedure(command, array);
		}
		else
		{
			ParseCommandText(command, array);
		}
		m_batchCmdTextBuilder.Append(m_strRowCountBlock);
		m_batchCmdTextBuilder.Append(m_strExceptionBlock);
		m_batchCommand.Parameters.AddRange(array);
		return m_paramArrayArray.Count - 1;
	}

	internal OracleParameter GetBatchedParameter(int cmdIdentifier, int paramIndex)
	{
		if (m_paramArrayArray.Count >= cmdIdentifier)
		{
			OracleParameter[] array = (OracleParameter[])m_paramArrayArray[cmdIdentifier];
			if (array.Length >= paramIndex)
			{
				return array[paramIndex];
			}
		}
		return null;
	}

	private OracleParameter[] CloneParameters(OracleParameterCollection parameters)
	{
		OracleParameter[] array = new OracleParameter[parameters.Count];
		for (int i = 0; i < parameters.Count; i++)
		{
			array[i] = parameters[i].Clone() as OracleParameter;
		}
		return array;
	}

	private void ParseCommandText(OracleCommand command, OracleParameter[] parameters)
	{
		string commandText = command.CommandText;
		new ArrayList();
		Regex parserRegEx = m_parserRegEx;
		m_usedParameterNames.Clear();
		string text = null;
		m_tempStringBuilder.Remove(0, m_tempStringBuilder.Length);
		m_tempStringBuilder.Append(commandText);
		int num = 0;
		int num2 = 0;
		Match match = parserRegEx.Match(commandText);
		while (Match.Empty != match)
		{
			if (match.Groups[m_bindParameterMarkerGroup].Success)
			{
				string text2 = match.Groups[m_bindParameterMarkerGroup].Value.Substring(1);
				if (command.BindByName)
				{
					num2 = command.Parameters.IndexOf(text2);
					if (0 > num2)
					{
						num2 = command.Parameters.IndexOf(COLON + text2);
						if (0 > num2)
						{
							throw new ArgumentOutOfRangeException();
						}
					}
				}
				if ((text = m_usedParameterNames[text2] as string) == null)
				{
					text = m_bindPrmPrefix + m_lastNumUsed;
					m_lastNumUsed++;
					m_usedParameterNames[text2] = text;
				}
				if (command.BindByName)
				{
					parameters[num2].ParameterName = text;
				}
				m_tempStringBuilder.Remove(num + match.Index, match.Length);
				m_tempStringBuilder.Insert(num + match.Index, text);
				num += text.Length - match.Length;
			}
			match = match.NextMatch();
		}
		m_batchCmdTextBuilder.Append(m_tempStringBuilder.ToString());
		m_batchCmdTextBuilder.Append(m_commandSuffix);
	}

	private void ParseStoredProcedure(OracleCommand command, OracleParameter[] paramArray)
	{
		OracleParameter oracleParameter = null;
		int num = 0;
		int num2 = 0;
		string commandText = command.CommandText;
		num = paramArray.Length;
		m_tempStringBuilder.Remove(0, m_tempStringBuilder.Length);
		if (paramArray == null || num == 0)
		{
			m_tempStringBuilder.Append("Begin " + commandText + "(); End;");
		}
		else if (!command.BindByName)
		{
			if ((oracleParameter = GetReturnValueParam(paramArray)) == null)
			{
				m_tempStringBuilder.Append("Begin " + commandText + "(" + m_bindPrmPrefix + m_lastNumUsed++);
				for (num2 = 1; num2 < num; num2++)
				{
					m_tempStringBuilder.Append(", " + m_bindPrmPrefix + m_lastNumUsed++);
				}
				m_tempStringBuilder.Append("); End;");
			}
			else
			{
				if (paramArray[0] == oracleParameter)
				{
					if (num > 1)
					{
						m_tempStringBuilder.Append("Begin :ret" + m_lastNumUsed++);
						m_tempStringBuilder.Append(" := " + commandText + "(" + m_bindPrmPrefix + m_lastNumUsed++);
						num2 = 2;
					}
					else
					{
						m_tempStringBuilder.Append("Begin :ret" + m_lastNumUsed++);
						m_tempStringBuilder.Append(" := " + commandText + "(");
						num2 = 1;
					}
				}
				else
				{
					m_tempStringBuilder.Append("Begin :ret" + m_lastNumUsed++);
					m_tempStringBuilder.Append(" := " + commandText + "(" + m_bindPrmPrefix + m_lastNumUsed++);
					num2 = 1;
				}
				for (; num2 < num; num2++)
				{
					if (paramArray[num2] != oracleParameter)
					{
						m_tempStringBuilder.Append(", " + m_bindPrmPrefix + m_lastNumUsed++);
					}
				}
				m_tempStringBuilder.Append("); End;");
			}
		}
		else if ((oracleParameter = GetReturnValueParam(paramArray)) == null)
		{
			m_tempStringBuilder.Append("Begin " + commandText + "(" + paramArray[0].ParameterName + "=>" + m_bindPrmPrefix + m_lastNumUsed);
			paramArray[0].ParameterName = m_bindPrmPrefix + m_lastNumUsed++;
			for (num2 = 1; num2 < num; num2++)
			{
				m_tempStringBuilder.Append(", " + paramArray[num2].ParameterName + "=>" + m_bindPrmPrefix + m_lastNumUsed);
				paramArray[num2].ParameterName = m_bindPrmPrefix + m_lastNumUsed++;
			}
			m_tempStringBuilder.Append("); End;");
		}
		else
		{
			if (paramArray[0] == oracleParameter)
			{
				if (num > 1)
				{
					m_tempStringBuilder.Append("Begin :ret" + m_lastNumUsed);
					oracleParameter.ParameterName = ":ret" + m_lastNumUsed++;
					m_tempStringBuilder.Append(" := " + commandText + "(" + paramArray[1].ParameterName + "=>" + m_bindPrmPrefix + m_lastNumUsed);
					paramArray[1].ParameterName = m_bindPrmPrefix + m_lastNumUsed++;
					num2 = 2;
				}
				else
				{
					m_tempStringBuilder.Append("Begin :ret" + m_lastNumUsed);
					oracleParameter.ParameterName = ":ret" + m_lastNumUsed++;
					m_tempStringBuilder.Append(" := " + commandText + "(");
					num2 = 1;
				}
			}
			else
			{
				m_tempStringBuilder.Append("Begin :ret" + m_lastNumUsed);
				oracleParameter.ParameterName = ":ret" + m_lastNumUsed++;
				m_tempStringBuilder.Append(" := " + commandText + "(" + paramArray[0].ParameterName + "=>" + m_bindPrmPrefix + m_lastNumUsed);
				paramArray[0].ParameterName = m_bindPrmPrefix + m_lastNumUsed++;
				num2 = 1;
			}
			for (; num2 < num; num2++)
			{
				if (paramArray[num2] != oracleParameter)
				{
					m_tempStringBuilder.Append(", " + paramArray[num2].ParameterName + "=>" + m_bindPrmPrefix + m_lastNumUsed);
					paramArray[num2].ParameterName = m_bindPrmPrefix + m_lastNumUsed++;
				}
			}
			m_tempStringBuilder.Append("); End;");
		}
		m_batchCmdTextBuilder.Append(m_tempStringBuilder.ToString());
	}

	private OracleParameter GetReturnValueParam(OracleParameter[] paramArray)
	{
		int num = paramArray.Length;
		for (int i = 0; i < num; i++)
		{
			if (paramArray[i].Direction == ParameterDirection.ReturnValue)
			{
				return paramArray[i];
			}
		}
		return null;
	}
}
