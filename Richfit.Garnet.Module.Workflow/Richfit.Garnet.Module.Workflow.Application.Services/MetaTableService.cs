using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Dapper;
using Microsoft.CSharp;
using Microsoft.JScript;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Dapper.Application;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Services;

public class MetaTableService : ServiceBase, IMetaTableService
{
	private string[] defaultCol = new string[13]
	{
		"MODIFIER", "MODIFYTIME", "USER_ID", "USER_NAME", "CREATOR", "CREATETIME", "ORG_ID", "ORG_NAME", "ISDEL", "AddSql",
		"UpdateSql", "FindByInstance", "FindPage"
	};

	/// <summary>
	/// 只读仓储对象
	/// </summary>
	private readonly IRepository<WF_ACTIVITY> activityRepository = null;

	private readonly IRepository<WF_META_TABLE> metaTableRepository = null;

	private readonly IRepository<WF_METADATA> metaDataRepository = null;

	private readonly IRepository<WF_TEMPLATE> templateRepository = null;

	public MetaTableService()
	{
		metaTableRepository = ServiceLocator.Instance.GetService<IRepository<WF_META_TABLE>>();
		activityRepository = ServiceLocator.Instance.GetService<IRepository<WF_ACTIVITY>>();
		metaDataRepository = ServiceLocator.Instance.GetService<IRepository<WF_METADATA>>();
		templateRepository = ServiceLocator.Instance.GetService<IRepository<WF_TEMPLATE>>();
	}

	public void SaveMetaTable(WF_META_TABLEDTO metaTable)
	{
		if (metaTable == null)
		{
			throw new ArgumentException("SaveLevel方法参数不能为空！");
		}
		if (metaTable.IsValid())
		{
			WF_META_TABLE table = metaTable.AdaptAsEntity<WF_META_TABLE>();
			if (metaTable.IsCreate)
			{
				metaTableRepository.AddCommit(table);
				return;
			}
			WF_META_TABLE old = metaTableRepository.Find((WF_META_TABLE a) => a.META_TABLE_ID == metaTable.META_TABLE_ID);
			old.TABLE_NAME = metaTable.TABLE_NAME;
			old.ISDEL = metaTable.ISDEL;
			metaTableRepository.UpdateCommit(old);
			return;
		}
		throw new ValidationException(metaTable.GetInvalidMessages());
	}

	public void SaveMetaData(List<WF_METADATADTO> metaData)
	{
		foreach (WF_METADATADTO dto in metaData)
		{
			SaveMetaData(dto);
		}
	}

	private void SaveMetaData(WF_METADATADTO metaData)
	{
		if (metaData == null)
		{
			throw new ArgumentException("SaveLevel方法参数不能为空！");
		}
		if (string.IsNullOrEmpty(metaData.FIELD_DB_NAME))
		{
			throw new ArgumentException("FIELD_DB_NAME参数不能为空！");
		}
		if (metaData.IsValid())
		{
			WF_METADATA meta = metaData.AdaptAsEntity<WF_METADATA>();
			meta.FIELD_DB_NAME = meta.FIELD_DB_NAME.ToUpper().Trim();
			if (metaData.IsCreate)
			{
				metaDataRepository.AddCommit(meta);
				return;
			}
			WF_METADATA old = metaDataRepository.Find((WF_METADATA a) => a.METADATA_ID == metaData.METADATA_ID);
			old.FIELD_DB_NAME = metaData.FIELD_DB_NAME;
			old.FIELD_NAME = metaData.FIELD_NAME;
			old.DATATYPE = metaData.DATATYPE;
			old.ISDEL = metaData.ISDEL;
			old.DATALENGTH = metaData.DATALENGTH;
			metaDataRepository.UpdateCommit(old);
			return;
		}
		throw new ValidationException(metaData.GetInvalidMessages());
	}

	public bool CreateTable(Guid templateId)
	{
		WF_TEMPLATE template = templateRepository.GetByKey(templateId);
		IList<WF_META_TABLE> query = metaTableRepository.FindAll((WF_META_TABLE a) => a.TEMPLATE_ID == templateId && a.ISDEL == 0m);
		if (query.Any())
		{
			foreach (WF_META_TABLE metaTable in query)
			{
				if (metaTable.WF_METADATA.Any())
				{
					metaTable.WF_METADATA = (from a in metaTable.WF_METADATA
						where a.ISDEL == 0m
						orderby a.SORT
						select a).ToList();
				}
			}
			GenerateCode(template, query, isAcc: false);
			CreateTable(query, isAcc: false);
		}
		return true;
	}

	public bool SaveAccountTable(Guid templateId)
	{
		WF_TEMPLATE template = templateRepository.GetByKey(templateId);
		IList<WF_META_TABLE> query = metaTableRepository.FindAll((WF_META_TABLE a) => a.TEMPLATE_ID == templateId && a.ISDEL == 0m);
		if (query.Any())
		{
			foreach (WF_META_TABLE metaTable in query)
			{
				if (metaTable.WF_METADATA.Any())
				{
					metaTable.WF_METADATA = (from a in metaTable.WF_METADATA
						where a.ISDEL == 0m
						orderby a.SORT
						select a).ToList();
				}
			}
			GenerateCode(template, query, isAcc: true);
			CreateTable(query, isAcc: true);
		}
		return true;
	}

	private bool CreateTable(IList<WF_META_TABLE> tableList, bool isAcc)
	{
		string mySql = "";
		try
		{
			SqlHelper.Excute(delegate(IDbConnection conn)
			{
				WF_META_TABLE root = tableList.SingleOrDefault((WF_META_TABLE a) => a.PARENT_TABLE_ID == Guid.Empty);
				IEnumerable<WF_META_TABLE> enumerable = tableList.Where((WF_META_TABLE a) => a.PARENT_TABLE_ID == root.META_TABLE_ID && a.ISDEL == 0m);
				List<string> list = new List<string>();
				foreach (WF_META_TABLE current in enumerable)
				{
					list.AddRange(CreateTable(conn, current, tableList.ToList(), isAcc));
				}
				foreach (string current2 in list)
				{
					try
					{
						mySql = current2;
						conn.Execute(current2);
					}
					catch (Exception)
					{
						throw;
					}
				}
			});
			return true;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private List<string> CreateTable(IDbConnection connection, WF_META_TABLE table, IList<WF_META_TABLE> tableList, bool isAcc)
	{
		string tableName = (isAcc ? "AC_" : "") + table.TABLE_DB_NAME.ToUpper();
		string existTable = $"select count(*)as count from user_tables where table_name = '{tableName}'";
		string existCol = $"select COLUMN_NAME from user_tab_columns where table_name='{tableName}'";
		int haveTable = connection.QuerySingle<int>(existTable);
		List<string> sqlList = new List<string>();
		string sql = $"create table {tableName}( ";
		string fkTemplate = " alter table {0} add constraint {1} foreign key({2}) references {3} ({2})";
		string addcol = "alter table {0} add ({1} {2}) ";
		string command = "comment on column {0}.{1} is '{2}' ";
		List<string> fk = new List<string>();
		List<WF_METADATA> metaList = (from a in table.WF_METADATA
			where a.ISDEL == 0m
			orderby a.SORT
			select a).ToList();
		if (haveTable > 0)
		{
			IDbConnection connect = SqlHelper.CrateOracleConnection();
			IEnumerable<string> colList = connect.Query<string>(existCol);
			foreach (WF_METADATA meta in metaList)
			{
				string colName = meta.FIELD_DB_NAME.Trim().ToUpper();
				IEnumerable<string> cols = colList.Where((string a) => a == colName);
				if (cols != null && cols.Count() > 0)
				{
					connect.Execute(string.Format(command, tableName, colName, meta.FIELD_NAME));
					continue;
				}
				connect.Execute(string.Format(addcol, tableName, colName, getDataType(meta)));
				connect.Execute(string.Format(command, tableName, colName, meta.FIELD_NAME));
			}
			IEnumerable<WF_META_TABLE> query = tableList.Where((WF_META_TABLE a) => a.PARENT_TABLE_ID == table.META_TABLE_ID && a.ISDEL == 0m);
			if (query != null && query.Count() > 0)
			{
				foreach (WF_META_TABLE subTable in query)
				{
					sqlList.AddRange(CreateTable(connection, subTable, tableList, isAcc));
				}
			}
		}
		else
		{
			IList<string> commands = new List<string>();
			foreach (WF_METADATA meta in metaList)
			{
				string colName2 = meta.FIELD_DB_NAME.Trim().ToUpper();
				decimal? mETATYPE = meta.METATYPE;
				sql = ((!(mETATYPE.GetValueOrDefault() == 3m) || !mETATYPE.HasValue) ? (sql + $"{colName2} {getDataType(meta)} ,\r\n") : (sql + $"{colName2} RAW(16) PRIMARY KEY  not null,\r\n"));
				commands.Add(string.Format(command, tableName, colName2, meta.FIELD_NAME));
				mETATYPE = meta.METATYPE;
				if (mETATYPE.GetValueOrDefault() == 2m && mETATYPE.HasValue)
				{
					string fkName = ("FK_" + Guid.NewGuid().ToString().Replace("-", "")).Substring(0, 29);
					WF_META_TABLE parentTable = tableList.SingleOrDefault(delegate(WF_META_TABLE a)
					{
						Guid mETA_TABLE_ID = a.META_TABLE_ID;
						Guid? pARENT_TABLE_ID = table.PARENT_TABLE_ID;
						return mETA_TABLE_ID == pARENT_TABLE_ID;
					});
					string parentTableName = parentTable.TABLE_DB_NAME;
					if (isAcc)
					{
						parentTableName = "AC_" + parentTableName;
					}
					fk.Add(string.Format(fkTemplate, tableName, fkName, meta.FIELD_DB_NAME, parentTableName));
				}
			}
			sql = sql.Remove(sql.Length - 3);
			sql += ")\r\n";
			sqlList.Add(sql);
			foreach (string s in fk)
			{
				sqlList.Add(s);
			}
			foreach (string s in commands)
			{
				sqlList.Add(s);
			}
			IEnumerable<WF_META_TABLE> query = tableList.Where((WF_META_TABLE a) => a.PARENT_TABLE_ID == table.META_TABLE_ID && a.ISDEL == 0m);
			if (query != null && query.Count() > 0)
			{
				foreach (WF_META_TABLE subTable in query)
				{
					sqlList.AddRange(CreateTable(connection, subTable, tableList, isAcc));
				}
			}
		}
		return sqlList;
	}

	private string getDataType(WF_METADATA meta)
	{
		switch (System.Convert.ToInt32(meta.DATATYPE))
		{
		case 0:
		{
			int length = 512;
			if (!string.IsNullOrEmpty(meta.DATALENGTH) && int.TryParse(meta.DATALENGTH, out var realLength))
			{
				length = realLength;
			}
			return (length < 4000) ? $"NVARCHAR2({length})" : "CLOB";
		}
		case 1:
		case 2:
		{
			string result = "NUMBER";
			if (!string.IsNullOrEmpty(meta.DATALENGTH))
			{
				result += $"({meta.DATALENGTH})";
			}
			return result;
		}
		case 3:
			return "DATE";
		case 4:
			return "RAW(16)";
		default:
			return "NVARCHAR2(512)";
		}
	}

	private Type getType(WF_METADATA meta)
	{
		switch (System.Convert.ToInt32(meta.DATATYPE))
		{
		case 0:
			return typeof(string);
		case 1:
		case 2:
			return typeof(decimal?);
		case 3:
			return typeof(DateTime?);
		case 4:
			return typeof(Guid?);
		default:
			return typeof(string);
		}
	}

	private bool GenerateCode(WF_TEMPLATE template, IList<WF_META_TABLE> tableList, bool isAcc)
	{
		string name = template.TEMPLATE_CODE;
		string path = HttpContext.Current.Server.MapPath("/").Replace("webapp\\", $"Richfit.Garnet.Module.Workflow.Form\\Module\\{name}\\DTO");
		WF_META_TABLE root = tableList.SingleOrDefault((WF_META_TABLE a) => a.PARENT_TABLE_ID == Guid.Empty);
		CodeTypeDeclaration rootContainer;
		CodeCompileUnit rootCompileUnit = GenerateClass(name, isAcc ? ("AC_" + name + "DTO") : (name + "DTO"), out rootContainer);
		IEnumerable<WF_META_TABLE> query = tableList.Where((WF_META_TABLE a) => a.PARENT_TABLE_ID == root.META_TABLE_ID);
		foreach (WF_META_TABLE table in query)
		{
			string tableDbName = (isAcc ? "" : "") + table.TABLE_DB_NAME;
			CodeMemberField rootField = addField(tableDbName, table.TABLE_NAME, tableDbName);
			rootContainer.Members.Add(rootField);
			CodeMemberProperty rootPro = addPro(tableDbName, table.TABLE_NAME, tableDbName);
			rootContainer.Members.Add(rootPro);
			CodeCompileUnit code = GenerateCode(name, table, root, isAcc);
			CodeTypeDeclaration codeTypeDeclaration = code.Namespaces[0].Types[0];
			CodeConstructor constructor = (CodeConstructor)codeTypeDeclaration.Members[codeTypeDeclaration.Members.Count - 1];
			IEnumerable<WF_META_TABLE> sub = tableList.Where((WF_META_TABLE a) => a.PARENT_TABLE_ID == table.META_TABLE_ID);
			IList<string[]> priv = new List<string[]>();
			if (sub.Any())
			{
				foreach (WF_META_TABLE t in sub)
				{
					CodeCompileUnit codeCompileUnit = GenerateCode(name, t, table, isAcc);
					GenerateCode(codeCompileUnit, t, path, isAcc);
					CodeTypeDeclaration subDeclaration = codeCompileUnit.Namespaces[0].Types[0];
					CodeTypeReference type = new CodeTypeReference($"IList<{subDeclaration.Name}>");
					CodeMemberField field = new CodeMemberField(type, "_" + subDeclaration.Name.ToLower());
					field.Comments.Add(new CodeCommentStatement(t.TABLE_NAME));
					field.Attributes = MemberAttributes.Private;
					codeTypeDeclaration.Members.Add(field);
					priv.Add(new string[2]
					{
						$"this.{field.Name}",
						$"new List<{subDeclaration.Name}>()"
					});
					CodeMemberProperty mProperty = addPro(subDeclaration.Name, t.TABLE_NAME, $"IList<{subDeclaration.Name}>");
					mProperty.CustomAttributes.Add(new CodeAttributeDeclaration("SubAttribute"));
					codeTypeDeclaration.Members.Add(mProperty);
				}
			}
			if (priv.Count > 0)
			{
				foreach (string[] p in priv)
				{
					CodeAssignStatement codeAssignStatement = new CodeAssignStatement(new CodeVariableReferenceExpression(p[0]), new CodeVariableReferenceExpression(p[1]));
					constructor.Statements.Add(codeAssignStatement);
				}
			}
			GenerateCode(code, table, path, isAcc);
		}
		GenerateCode(rootCompileUnit, root, path, isAcc, (isAcc ? ("AC_" + name + "DTO") : (name + "DTO")) + ".cs");
		return true;
	}

	private void GenerateCode(CodeCompileUnit codeCompileUnit, WF_META_TABLE table, string path, bool isAc, string name = null)
	{
		CodeDomProvider provide = new CSharpCodeProvider();
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		path += "/";
		path += (string.IsNullOrEmpty(name) ? ((isAc ? "AC_" : "") + table.TABLE_DB_NAME + ".cs") : name);
		if (!File.Exists(path))
		{
			File.Create(path).Close();
		}
		using IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(path, append: false), "      ");
		provide.GenerateCodeFromCompileUnit(codeCompileUnit, tw, new CodeGeneratorOptions());
		tw.Close();
	}

	private CodeCompileUnit GenerateClass(string nameSpace, string className, out CodeTypeDeclaration codeTypeDeclaration)
	{
		CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
		CodeNamespace codeNamespace = new CodeNamespace($"Richfit.Garnet.Module.Workflow.Form.Module.{nameSpace}.DTO");
		codeNamespace.Imports.Add(new CodeNamespaceImport("Newtonsoft.Json"));
		codeNamespace.Imports.Add(new CodeNamespaceImport("Richfit.Garnet.Common.Extensions"));
		codeNamespace.Imports.Add(new CodeNamespaceImport("Richfit.Garnet.Module.Base.Application.DTO"));
		codeNamespace.Imports.Add(new CodeNamespaceImport("Richfit.Garnet.Module.Workflow.Form.Core"));
		codeNamespace.Imports.Add(new CodeNamespaceImport("Richfit.Garnet.Module.Workflow.Form.Core.Attribute"));
		codeNamespace.Imports.Add(new CodeNamespaceImport("Richfit.Garnet.Module.Workflow.Application.IServices"));
		codeNamespace.Imports.Add(new CodeNamespaceImport("System"));
		codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
		codeCompileUnit.Namespaces.Add(codeNamespace);
		codeTypeDeclaration = new CodeTypeDeclaration(className);
		codeTypeDeclaration.CustomAttributes.Add(new CodeAttributeDeclaration("Serializable"));
		codeTypeDeclaration.BaseTypes.Add(new CodeTypeReference("DTOExt"));
		codeTypeDeclaration.BaseTypes.Add(new CodeTypeReference("IDTO"));
		codeNamespace.Types.Add(codeTypeDeclaration);
		return codeCompileUnit;
	}

	private CodeCompileUnit GenerateCode(string name, WF_META_TABLE table, WF_META_TABLE parentTable, bool isAcc)
	{
		string tableName = (isAcc ? "AC_" : "") + table.TABLE_DB_NAME;
		string parentTableName = (isAcc ? "AC_" : "") + parentTable.TABLE_DB_NAME;
		tableName = tableName.ToUpper();
		parentTableName = parentTableName.ToUpper();
		CodeTypeDeclaration codeTypeDeclaration;
		CodeCompileUnit codeCompileUnit = GenerateClass(name, tableName, out codeTypeDeclaration);
		string saveSql = $"insert into {tableName} ";
		string updateSql = $"update {tableName} set ";
		string addCol = "";
		string addValue = "";
		foreach (WF_METADATA meta in table.WF_METADATA)
		{
			addCol = addCol + meta.FIELD_DB_NAME + " ,\r\n";
			addValue = addValue + ":" + meta.FIELD_DB_NAME + " ,\r\n";
			if (meta.FIELD_DB_NAME.ToUpper() != tableName + "_ID" && meta.FIELD_DB_NAME.ToUpper() != "INSTANCE_ID")
			{
				updateSql += string.Format("{0}=:{0} \r\n,", meta.FIELD_DB_NAME);
			}
			CodeMemberField field = addField(meta.FIELD_DB_NAME, meta.FIELD_NAME, getType(meta));
			codeTypeDeclaration.Members.Add(field);
			CodeMemberProperty mProperty = addPro(meta.FIELD_DB_NAME, meta.FIELD_NAME, getType(meta));
			decimal? mETATYPE = meta.METATYPE;
			if (mETATYPE.GetValueOrDefault() == 3m && mETATYPE.HasValue)
			{
				mProperty.CustomAttributes.Add(new CodeAttributeDeclaration("PrimaryAttribute"));
			}
			mETATYPE = meta.METATYPE;
			if (mETATYPE.GetValueOrDefault() == 2m && mETATYPE.HasValue)
			{
				mProperty.CustomAttributes.Add(new CodeAttributeDeclaration("ForeignAttribute"));
			}
			mProperty.CustomAttributes.Add(new CodeAttributeDeclaration("ColAttribute"));
			codeTypeDeclaration.Members.Add(mProperty);
		}
		addCol = addCol.Substring(0, addCol.Length - 3);
		addValue = addValue.Substring(0, addValue.Length - 3);
		updateSql = updateSql.Substring(0, updateSql.Length - 1);
		updateSql += " WHERE INSTANCE_ID=:INSTANCE_ID";
		saveSql += $"(\r\n{addCol}) values (\r\n{addValue})";
		CodeMemberField sql = addField("addSql", "插入sql", typeof(string));
		codeTypeDeclaration.Members.Add(sql);
		CodeMemberProperty sqlp = addPro("AddSql", "插入sql", typeof(string));
		sqlp.CustomAttributes.Add(new CodeAttributeDeclaration("JsonIgnore"));
		codeTypeDeclaration.Members.Add(sqlp);
		CodeMemberField sqluf = addField("updateSql", "更新sql", typeof(string));
		codeTypeDeclaration.Members.Add(sqluf);
		CodeMemberProperty sqlup = addPro("UpdateSql", "更新sql", typeof(string));
		sqlup.CustomAttributes.Add(new CodeAttributeDeclaration("JsonIgnore"));
		codeTypeDeclaration.Members.Add(sqlup);
		CodeMemberField findField = addField("findByInstance", "获取数据sql", typeof(string));
		codeTypeDeclaration.Members.Add(findField);
		CodeMemberProperty find = addPro("FindByInstance", "获取数据Sql", typeof(string));
		find.CustomAttributes.Add(new CodeAttributeDeclaration("JsonIgnore"));
		codeTypeDeclaration.Members.Add(find);
		CodeMemberField findPage = addField("findPage", "获取列表数据sql", typeof(string));
		codeTypeDeclaration.Members.Add(findPage);
		CodeMemberProperty page = addPro("FindPage", "获取数据Sql", typeof(string));
		page.CustomAttributes.Add(new CodeAttributeDeclaration("JsonIgnore"));
		codeTypeDeclaration.Members.Add(page);
		CodeMemberMethod memberMethod = new CodeMemberMethod();
		memberMethod.Name = "FindList";
		memberMethod.ReturnType = new CodeTypeReference("System.String");
		memberMethod.Parameters.Add(new CodeParameterDeclarationExpression("System.String", "parm"));
		memberMethod.Statements.Add(new CodeSnippetStatement(string.Format("  {0} dto = parm.JsonDeserialize<{0}>(); ", tableName)));
		memberMethod.Statements.Add(new CodeSnippetStatement($" return base.FindList<{tableName}>(dto);"));
		memberMethod.Attributes = (MemberAttributes)24580;
		codeTypeDeclaration.Members.Add(memberMethod);
		CodeConstructor constructor = new CodeConstructor();
		constructor.Attributes = MemberAttributes.Public;
		codeTypeDeclaration.Members.Add(constructor);
		CodeAssignStatement codeAssignStatement = new CodeAssignStatement(new CodeVariableReferenceExpression("this." + sql.Name), new CodeVariableReferenceExpression($"@\"{saveSql}\""));
		constructor.Statements.Add(codeAssignStatement);
		if (parentTable.PARENT_TABLE_ID == Guid.Empty)
		{
			codeAssignStatement = new CodeAssignStatement(new CodeVariableReferenceExpression("this." + findField.Name), new CodeVariableReferenceExpression($"@\"SELECT * FROM {tableName} WHERE INSTANCE_ID=:INSTANCE_ID\""));
			constructor.Statements.Add(codeAssignStatement);
			codeAssignStatement = new CodeAssignStatement(new CodeVariableReferenceExpression("this." + findPage.Name), new CodeVariableReferenceExpression($"@\"SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME FROM {tableName} T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID \""));
			constructor.Statements.Add(codeAssignStatement);
		}
		else
		{
			codeAssignStatement = new CodeAssignStatement(new CodeVariableReferenceExpression("this." + findField.Name), new CodeVariableReferenceExpression(string.Format("@\"SELECT * FROM {0} WHERE {1}_ID=:{1}_ID\"", tableName, parentTableName)));
			constructor.Statements.Add(codeAssignStatement);
		}
		codeAssignStatement = new CodeAssignStatement(new CodeVariableReferenceExpression("this." + sqluf.Name), new CodeVariableReferenceExpression($"@\"{updateSql}\""));
		constructor.Statements.Add(codeAssignStatement);
		return codeCompileUnit;
	}

	private CodeMemberField addField(string name, string des, string type)
	{
		CodeMemberField field = new CodeMemberField(type, "_" + name.ToLower());
		field.Comments.Add(new CodeCommentStatement(des));
		field.Attributes = MemberAttributes.Private;
		return field;
	}

	private CodeMemberField addField(string name, string des, Type t)
	{
		CodeMemberField field = new CodeMemberField(t, "_" + name.ToLower());
		field.Comments.Add(new CodeCommentStatement(des));
		field.Attributes = MemberAttributes.Private;
		return field;
	}

	private CodeMemberProperty addPro(string name, string des, Type t)
	{
		CodeMemberProperty mProperty = new CodeMemberProperty();
		mProperty.Attributes = (defaultCol.Contains(name) ? ((MemberAttributes)24580) : MemberAttributes.Public);
		mProperty.Type = new CodeTypeReference(t);
		return addPro(mProperty, name, des);
	}

	private CodeMemberProperty addPro(string name, string des, string t)
	{
		CodeMemberProperty mProperty = new CodeMemberProperty();
		mProperty.Type = new CodeTypeReference(t);
		mProperty.Attributes = (defaultCol.Contains(name) ? ((MemberAttributes)24580) : MemberAttributes.Public);
		return addPro(mProperty, name, des);
	}

	private CodeMemberProperty addPro(CodeMemberProperty mProperty, string name, string des)
	{
		string fieldName = "_" + name.ToLower();
		mProperty.Name = name;
		mProperty.HasGet = true;
		mProperty.HasSet = true;
		mProperty.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName)));
		mProperty.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName), new CodePropertySetValueReferenceExpression()));
		mProperty.Comments.Add(new CodeCommentStatement("<summary>", docComment: true));
		mProperty.Comments.Add(new CodeCommentStatement(des, docComment: true));
		mProperty.Comments.Add(new CodeCommentStatement("</summary>", docComment: true));
		return mProperty;
	}

	public IList<WF_META_TABLESIMPLEDTO> GetMainMetaTable()
	{
		return SqlQuery<WF_META_TABLESIMPLEDTO>("GetMainMetaTable", null);
	}

	public IList<WF_METADATADTO> GetColByTableId(WF_METADATADTO metaData)
	{
		return SqlQuery<WF_METADATADTO>("GetColByTableId", metaData);
	}

	public void SaveAccount(SaveAccountParameter saveAccountParameter)
	{
		foreach (WF_METADATADTO item in saveAccountParameter.WF_METADATA)
		{
			WF_METADATA meta = metaDataRepository.GetByKey(item.METADATA_ID);
			meta.STATUS = item.STATUS;
		}
		metaDataRepository.DbContext.Commit();
		WF_META_TABLE metaTable = metaTableRepository.GetByKey(saveAccountParameter.META_TABLE_ID);
		WF_TEMPLATE template = templateRepository.GetByKey(metaTable.TEMPLATE_ID);
		string rootPath = HttpContext.Current.Server.MapPath($"/Packages/WorkflowForm/Views/{template.TEMPLATE_CODE}");
		if (!Directory.Exists(rootPath))
		{
			Directory.CreateDirectory(rootPath);
		}
		string htmlPath = $"{rootPath}/{template.TEMPLATE_CODE.ToLower()}list.html";
		string pageInfo = "<!DOCTYPE html><html xmlns=\"http://www.w3.org/1999/xhtml\"><head>    <meta charset=\"UTF-8\">    <title>内容管理</title>    <script>        var csss = ['/assets/css/bootstrap.min.css',                        '/assets/css/page.css',                          '/assets/css/beyond.min.css',                          '/assets/css/bootstrap-datetimepicker.css',                          '/assets/js/controls/grid/css/richfit.grid.css',                          '/assets/js/controls/tree/css/metroStyle/metroStyle.css'];        var jss = ['/assets/js/jquery-1.10.2.min.js',                    '/assets/js/jquery-1.10.2.plugin.js',                    '/assets/js/bootstrap.min.js',                    '/assets/js/ztree/jquery.ztree.all-3.5.js',                    '/assets/js/treepicker/jquery.treepicker.js',                    '/assets/js/skins.min.js',                    '/assets/js/controls/grid/richfit.grid.js',                    '/assets/js/datetime/bootstrap-datepicker.js',     '/assets/js/richfit/jquery.selectpicker.js',  '/assets/js/controls/msg/msg.js'];        for (m = 0; m < csss.length; m++) {            document.write('<link href=\"' + csss[m] + '?license=' + new Date().getTime() + '\" rel=\"stylesheet\" />');        }        for (n = 0; n < jss.length; n++) {            document.write('<script src=\"' + jss[n] + '?license=' + new Date().getTime() + '\"><' + \"/\" + 'script>');        }    </script></head><body>";
		pageInfo.Replace(",", ",\r\n");
		using FileStream fs = new FileStream(htmlPath, FileMode.Create);
		string dtoName = $"Richfit.Garnet.Module.Workflow.Form\\Module\\{template.TEMPLATE_CODE}\\DTO\\{metaTable.TABLE_DB_NAME}".Replace("\\", ".");
		pageInfo = pageInfo + GlobalObject.unescape(saveAccountParameter.HTML).Replace("$DTONAME$", dtoName).Replace(">", ">\r\n") + "\r\n";
		pageInfo += "</body></html>";
		byte[] data = Encoding.UTF8.GetBytes(pageInfo);
		fs.Write(data, 0, data.Length);
		fs.Flush();
		fs.Close();
	}
}
