namespace ns8;

internal class Class1466
{
	internal static void Write(Class1487 class1487_0, int int_0)
	{
		class1487_0.method_8(" var c_rgszClr=new Array(8);");
		class1487_0.method_8(" c_rgszClr[0]=\"window\";");
		class1487_0.method_8(" c_rgszClr[1]=\"buttonface\";");
		class1487_0.method_8(" c_rgszClr[2]=\"windowframe\";");
		class1487_0.method_8(" c_rgszClr[3]=\"windowtext\";");
		class1487_0.method_8(" c_rgszClr[4]=\"threedlightshadow\";");
		class1487_0.method_8(" c_rgszClr[5]=\"threedhighlight\";");
		class1487_0.method_8(" c_rgszClr[6]=\"threeddarkshadow\";");
		class1487_0.method_8(" c_rgszClr[7]=\"threedshadow\";");
		class1487_0.method_9();
		class1487_0.method_8(" var g_iShCur;");
		class1487_0.method_8(" var g_rglTabX=new Array(c_lTabs);");
		class1487_0.method_9();
		class1487_0.method_8("function fnGetIEVer()");
		class1487_0.method_8("{");
		class1487_0.method_8(" var ua=window.navigator.userAgent");
		class1487_0.method_8(" var msie=ua.indexOf(\"MSIE\")");
		class1487_0.method_8(" if (msie>0 && window.navigator.platform==\"Win32\")");
		class1487_0.method_8("  return parseInt(ua.substring(msie+5,ua.indexOf(\".\", msie)));");
		class1487_0.method_8(" else");
		class1487_0.method_8("  return 0;");
		class1487_0.method_8("}");
		class1487_0.method_9();
		class1487_0.method_8("function fnBuildFrameset()");
		class1487_0.method_8("{");
		class1487_0.method_8(" var szHTML=\"<frameset rows=\\\"*,18\\\" border=0 width=0 frameborder=no framespacing=0>\"+");
		class1487_0.method_8("  \"<frame src=\\\"\"+document.all.item(\"shLink\")[" + int_0 + "].href+\"\\\" name=\\\"frSheet\\\" noresize>\"+");
		class1487_0.method_8("  \"<frameset cols=\\\"54,*\\\" border=0 width=0 frameborder=no framespacing=0>\"+");
		class1487_0.method_8("  \"<frame src=\\\"\\\" name=\\\"frScroll\\\" marginwidth=0 marginheight=0 scrolling=no>\"+");
		class1487_0.method_8("  \"<frame src=\\\"\\\" name=\\\"frTabs\\\" marginwidth=0 marginheight=0 scrolling=no>\"+");
		class1487_0.method_8("  \"</frameset></frameset><plaintext>\";");
		class1487_0.method_9();
		class1487_0.method_8(" with (document) {");
		class1487_0.method_8("  open(\"text/html\",\"replace\");");
		class1487_0.method_8("  write(szHTML);");
		class1487_0.method_8("  close();");
		class1487_0.method_8(" }");
		class1487_0.method_9();
		class1487_0.method_8(" fnBuildTabStrip();");
		class1487_0.method_8("}");
		class1487_0.method_9();
		class1487_0.method_8("function fnBuildTabStrip()");
		class1487_0.method_8("{");
		class1487_0.method_8(" var szHTML=");
		class1487_0.method_8("  \"<html><head><style>.clScroll {font:8pt Courier New;color:\"+c_rgszClr[6]+\";cursor:default;line-height:10pt;}\"+");
		class1487_0.method_8("  \".clScroll2 {font:10pt Arial;color:\"+c_rgszClr[6]+\";cursor:default;line-height:11pt;}</style></head>\"+");
		class1487_0.method_8("  \"<body onclick=\\\"event.returnValue=false;\\\" ondragstart=\\\"event.returnValue=false;\\\" onselectstart=\\\"event.returnValue=false;\\\" bgcolor=\"+c_rgszClr[4]+\" topmargin=0 leftmargin=0><table cellpadding=0 cellspacing=0 width=100%>\"+");
		class1487_0.method_8("  \"<tr><td colspan=6 height=1 bgcolor=\"+c_rgszClr[2]+\"></td></tr>\"+");
		class1487_0.method_8("  \"<tr><td style=\\\"font:1pt\\\">&nbsp;<td>\"+");
		class1487_0.method_8("  \"<td valign=top id=tdScroll class=\\\"clScroll\\\" onclick=\\\"parent.fnFastScrollTabs(0);\\\" onmouseover=\\\"parent.fnMouseOverScroll(0);\\\" onmouseout=\\\"parent.fnMouseOutScroll(0);\\\"><a>&#171;</a></td>\"+");
		class1487_0.method_8("  \"<td valign=top id=tdScroll class=\\\"clScroll2\\\" onclick=\\\"parent.fnScrollTabs(0);\\\" ondblclick=\\\"parent.fnScrollTabs(0);\\\" onmouseover=\\\"parent.fnMouseOverScroll(1);\\\" onmouseout=\\\"parent.fnMouseOutScroll(1);\\\"><a>&lt</a></td>\"+");
		class1487_0.method_8("  \"<td valign=top id=tdScroll class=\\\"clScroll2\\\" onclick=\\\"parent.fnScrollTabs(1);\\\" ondblclick=\\\"parent.fnScrollTabs(1);\\\" onmouseover=\\\"parent.fnMouseOverScroll(2);\\\" onmouseout=\\\"parent.fnMouseOutScroll(2);\\\"><a>&gt</a></td>\"+");
		class1487_0.method_8("  \"<td valign=top id=tdScroll class=\\\"clScroll\\\" onclick=\\\"parent.fnFastScrollTabs(1);\\\" onmouseover=\\\"parent.fnMouseOverScroll(3);\\\" onmouseout=\\\"parent.fnMouseOutScroll(3);\\\"><a>&#187;</a></td>\"+");
		class1487_0.method_8("  \"<td style=\\\"font:1pt\\\">&nbsp;<td></tr></table></body></html>\";");
		class1487_0.method_9();
		class1487_0.method_8(" with (frames['frScroll'].document) {");
		class1487_0.method_8("  open(\"text/html\",\"replace\");");
		class1487_0.method_8("  write(szHTML);");
		class1487_0.method_8("  close();");
		class1487_0.method_8(" }");
		class1487_0.method_9();
		class1487_0.method_8(" szHTML =");
		class1487_0.method_8("  \"<html><head>\"+");
		class1487_0.method_8("  \"<style>A:link,A:visited,A:active {text-decoration:none;\"+\"color:\"+c_rgszClr[3]+\";}\"+");
		class1487_0.method_8("  \".clTab {cursor:hand;background:\"+c_rgszClr[1]+\";font:9pt Arial;padding-left:3px;padding-right:3px;text-align:center;}\"+");
		class1487_0.method_8("  \".clBorder {background:\"+c_rgszClr[2]+\";font:1pt;}\"+");
		class1487_0.method_8("  \"</style></head><body onload=\\\"parent.fnInit();\\\" onselectstart=\\\"event.returnValue=false;\\\" ondragstart=\\\"event.returnValue=false;\\\" bgcolor=\"+c_rgszClr[4]+");
		class1487_0.method_8("  \" topmargin=0 leftmargin=0><table id=tbTabs cellpadding=0 cellspacing=0>\";");
		class1487_0.method_9();
		class1487_0.method_8(" var iCellCount=(c_lTabs+1)*2;");
		class1487_0.method_9();
		class1487_0.method_8(" var i;");
		class1487_0.method_8(" for (i=0;i<iCellCount;i+=2)");
		class1487_0.method_8("  szHTML+=\"<col width=1><col>\";");
		class1487_0.method_9();
		class1487_0.method_8(" var iRow;");
		class1487_0.method_8(" for (iRow=0;iRow<6;iRow++) {");
		class1487_0.method_9();
		class1487_0.method_8("  szHTML+=\"<tr>\";");
		class1487_0.method_9();
		class1487_0.method_8("  if (iRow==5)");
		class1487_0.method_8("   szHTML+=\"<td colspan=\"+iCellCount+\"></td>\";");
		class1487_0.method_8("  else {");
		class1487_0.method_8("   if (iRow==0) {");
		class1487_0.method_8("    for(i=0;i<iCellCount;i++)");
		class1487_0.method_8("     szHTML+=\"<td height=1 class=\\\"clBorder\\\"></td>\";");
		class1487_0.method_8("   } else if (iRow==1) {");
		class1487_0.method_8("    for(i=0;i<c_lTabs;i++) {");
		class1487_0.method_8("     szHTML+=\"<td height=1 nowrap class=\\\"clBorder\\\">&nbsp;</td>\";");
		class1487_0.method_8("     szHTML+=");
		class1487_0.method_8("      \"<td id=tdTab height=1 nowrap class=\\\"clTab\\\" onmouseover=\\\"parent.fnMouseOverTab(\"+i+\");\\\" onmouseout=\\\"parent.fnMouseOutTab(\"+i+\");\\\">\"+");
		class1487_0.method_8("      \"<a href=\\\"\"+document.all.item(\"shLink\")[i].href+\"\\\" target=\\\"frSheet\\\" id=aTab>&nbsp;\"+c_rgszSh[i]+\"&nbsp;</a></td>\";");
		class1487_0.method_8("    }");
		class1487_0.method_8("    szHTML+=\"<td id=tdTab height=1 nowrap class=\\\"clBorder\\\"><a id=aTab>&nbsp;</a></td><td width=100%></td>\";");
		class1487_0.method_8("   } else if (iRow==2) {");
		class1487_0.method_8("    for (i=0;i<c_lTabs;i++)");
		class1487_0.method_8("     szHTML+=\"<td height=1></td><td height=1 class=\\\"clBorder\\\"></td>\";");
		class1487_0.method_8("    szHTML+=\"<td height=1></td><td height=1></td>\";");
		class1487_0.method_8("   } else if (iRow==3) {");
		class1487_0.method_8("    for (i=0;i<iCellCount;i++)");
		class1487_0.method_8("     szHTML+=\"<td height=1></td>\";");
		class1487_0.method_8("   } else if (iRow==4) {");
		class1487_0.method_8("    for (i=0;i<c_lTabs;i++)");
		class1487_0.method_8("     szHTML+=\"<td height=1 width=1></td><td height=1></td>\";");
		class1487_0.method_8("    szHTML+=\"<td height=1 width=1></td><td></td>\";");
		class1487_0.method_8("   }");
		class1487_0.method_8("  }");
		class1487_0.method_8("  szHTML+=\"</tr>\";");
		class1487_0.method_8(" }");
		class1487_0.method_9();
		class1487_0.method_8(" szHTML+=\"</table></body></html>\";");
		class1487_0.method_8(" with (frames['frTabs'].document) {");
		class1487_0.method_8("  open(\"text/html\",\"replace\");");
		class1487_0.method_8("  charset=document.charset;");
		class1487_0.method_8("  write(szHTML);");
		class1487_0.method_8("  close();");
		class1487_0.method_8(" }");
		class1487_0.method_8("}");
		class1487_0.method_9();
		class1487_0.method_8("function fnInit()");
		class1487_0.method_8("{");
		class1487_0.method_8(" g_rglTabX[0]=0;");
		class1487_0.method_8(" var i;");
		class1487_0.method_8(" for (i=1;i<=c_lTabs;i++)");
		class1487_0.method_8("  with (frames['frTabs'].document.all.tbTabs.rows[1].cells[fnTabToCol(i-1)])");
		class1487_0.method_8("   g_rglTabX[i]=offsetLeft+offsetWidth-6;");
		class1487_0.method_8("}");
		class1487_0.method_9();
		class1487_0.method_8("function fnTabToCol(iTab)");
		class1487_0.method_8("{");
		class1487_0.method_8(" return 2*iTab+1;");
		class1487_0.method_8("}");
		class1487_0.method_9();
		class1487_0.method_8("function fnNextTab(fDir)");
		class1487_0.method_8("{");
		class1487_0.method_8(" var iNextTab=-1;");
		class1487_0.method_8(" var i;");
		class1487_0.method_9();
		class1487_0.method_8(" with (frames['frTabs'].document.body) {");
		class1487_0.method_8("  if (fDir==0) {");
		class1487_0.method_8("   if (scrollLeft>0) {");
		class1487_0.method_8("    for (i=0;i<c_lTabs&&g_rglTabX[i]<scrollLeft;i++);");
		class1487_0.method_8("    if (i<c_lTabs)");
		class1487_0.method_8("     iNextTab=i-1;");
		class1487_0.method_8("   }");
		class1487_0.method_8("  } else {");
		class1487_0.method_8("   if (g_rglTabX[c_lTabs]+6>offsetWidth+scrollLeft) {");
		class1487_0.method_8("    for (i=0;i<c_lTabs&&g_rglTabX[i]<=scrollLeft;i++);");
		class1487_0.method_8("    if (i<c_lTabs)");
		class1487_0.method_8("     iNextTab=i;");
		class1487_0.method_8("   }");
		class1487_0.method_8("  }");
		class1487_0.method_8(" }");
		class1487_0.method_8(" return iNextTab;");
		class1487_0.method_8("}");
		class1487_0.method_9();
		class1487_0.method_8("function fnScrollTabs(fDir)");
		class1487_0.method_8("{");
		class1487_0.method_8(" var iNextTab=fnNextTab(fDir);");
		class1487_0.method_9();
		class1487_0.method_8(" if (iNextTab>=0) {");
		class1487_0.method_8("  frames['frTabs'].scroll(g_rglTabX[iNextTab],0);");
		class1487_0.method_8("  return true;");
		class1487_0.method_8(" } else");
		class1487_0.method_8("  return false;");
		class1487_0.method_8("}");
		class1487_0.method_9();
		class1487_0.method_8("function fnFastScrollTabs(fDir)");
		class1487_0.method_8("{");
		class1487_0.method_8(" if (c_lTabs>16)");
		class1487_0.method_8("  frames['frTabs'].scroll(g_rglTabX[fDir?c_lTabs-1:0],0);");
		class1487_0.method_8(" else");
		class1487_0.method_8("  if (fnScrollTabs(fDir)>0) window.setTimeout(\"fnFastScrollTabs(\"+fDir+\");\",5);");
		class1487_0.method_8("}");
		class1487_0.method_9();
		class1487_0.method_8("function fnSetTabProps(iTab,fActive)");
		class1487_0.method_8("{");
		class1487_0.method_8(" var iCol=fnTabToCol(iTab);");
		class1487_0.method_8(" var i;");
		class1487_0.method_9();
		class1487_0.method_8(" if (iTab>=0) {");
		class1487_0.method_8("  with (frames['frTabs'].document.all) {");
		class1487_0.method_8("   with (tbTabs) {");
		class1487_0.method_8("    for (i=0;i<=4;i++) {");
		class1487_0.method_8("     with (rows[i]) {");
		class1487_0.method_8("      if (i==0)");
		class1487_0.method_8("       cells[iCol].style.background=c_rgszClr[fActive?0:2];");
		class1487_0.method_8("      else if (i>0 && i<4) {");
		class1487_0.method_8("       if (fActive) {");
		class1487_0.method_8("        cells[iCol-1].style.background=c_rgszClr[2];");
		class1487_0.method_8("        cells[iCol].style.background=c_rgszClr[0];");
		class1487_0.method_8("        cells[iCol+1].style.background=c_rgszClr[2];");
		class1487_0.method_8("       } else {");
		class1487_0.method_8("        if (i==1) {");
		class1487_0.method_8("         cells[iCol-1].style.background=c_rgszClr[2];");
		class1487_0.method_8("         cells[iCol].style.background=c_rgszClr[1];");
		class1487_0.method_8("         cells[iCol+1].style.background=c_rgszClr[2];");
		class1487_0.method_8("        } else {");
		class1487_0.method_8("         cells[iCol-1].style.background=c_rgszClr[4];");
		class1487_0.method_8("         cells[iCol].style.background=c_rgszClr[(i==2)?2:4];");
		class1487_0.method_8("         cells[iCol+1].style.background=c_rgszClr[4];");
		class1487_0.method_8("        }");
		class1487_0.method_8("       }");
		class1487_0.method_8("      } else");
		class1487_0.method_8("       cells[iCol].style.background=c_rgszClr[fActive?2:4];");
		class1487_0.method_8("     }");
		class1487_0.method_8("    }");
		class1487_0.method_8("   }");
		class1487_0.method_8("   with (aTab[iTab].style) {");
		class1487_0.method_8("    cursor=(fActive?\"default\":\"hand\");");
		class1487_0.method_8("    color=c_rgszClr[3];");
		class1487_0.method_8("   }");
		class1487_0.method_8("  }");
		class1487_0.method_8(" }");
		class1487_0.method_8("}");
		class1487_0.method_9();
		class1487_0.method_8("function fnMouseOverScroll(iCtl)");
		class1487_0.method_8("{");
		class1487_0.method_8(" frames['frScroll'].document.all.tdScroll[iCtl].style.color=c_rgszClr[7];");
		class1487_0.method_8("}");
		class1487_0.method_8("");
		class1487_0.method_8("function fnMouseOutScroll(iCtl)");
		class1487_0.method_8("{");
		class1487_0.method_8(" frames['frScroll'].document.all.tdScroll[iCtl].style.color=c_rgszClr[6];");
		class1487_0.method_8("}");
		class1487_0.method_9();
		class1487_0.method_8("function fnMouseOverTab(iTab)");
		class1487_0.method_8("{");
		class1487_0.method_8(" if (iTab!=g_iShCur) {");
		class1487_0.method_8("  var iCol=fnTabToCol(iTab);");
		class1487_0.method_8("  with (frames['frTabs'].document.all) {");
		class1487_0.method_8("   tdTab[iTab].style.background=c_rgszClr[5];");
		class1487_0.method_8("  }");
		class1487_0.method_8(" }");
		class1487_0.method_8("}");
		class1487_0.method_9();
		class1487_0.method_8("function fnMouseOutTab(iTab)");
		class1487_0.method_8("{");
		class1487_0.method_8(" if (iTab>=0) {");
		class1487_0.method_8("  var elFrom=frames['frTabs'].event.srcElement;");
		class1487_0.method_8("  var elTo=frames['frTabs'].event.toElement;");
		class1487_0.method_9();
		class1487_0.method_8("  if ((!elTo) ||");
		class1487_0.method_8("   (elFrom.tagName==elTo.tagName) ||");
		class1487_0.method_8("   (elTo.tagName==\"A\" && elTo.parentElement!=elFrom) ||");
		class1487_0.method_8("   (elFrom.tagName==\"A\" && elFrom.parentElement!=elTo)) {");
		class1487_0.method_9();
		class1487_0.method_8("   if (iTab!=g_iShCur) {");
		class1487_0.method_8("    with (frames['frTabs'].document.all) {");
		class1487_0.method_8("     tdTab[iTab].style.background=c_rgszClr[1];");
		class1487_0.method_8("    }");
		class1487_0.method_8("   }");
		class1487_0.method_8("  }");
		class1487_0.method_8(" }");
		class1487_0.method_8("}");
		class1487_0.method_9();
		class1487_0.method_8("function fnSetActiveSheet(iSh)");
		class1487_0.method_8("{");
		class1487_0.method_8(" if (iSh!=g_iShCur) {");
		class1487_0.method_8("  fnSetTabProps(g_iShCur,false);");
		class1487_0.method_8("  fnSetTabProps(iSh,true);");
		class1487_0.method_8("  g_iShCur=iSh;");
		class1487_0.method_8(" }");
		class1487_0.method_8("}");
		class1487_0.method_9();
		class1487_0.method_8(" window.g_iIEVer=fnGetIEVer();");
		class1487_0.method_8(" if (window.g_iIEVer>=4)");
		class1487_0.method_8("  fnBuildFrameset();");
		class1487_0.method_8("//-->");
		class1487_0.method_9();
	}
}
