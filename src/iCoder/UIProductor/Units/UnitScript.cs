using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UIProductor.Page;

namespace UIProductor.Units
{
	public class UnitScript : BaseUnit
	{
		public UnitScript(ConditionModel model)
			: base(model)
		{
		}

		public string Create(ePageType pageType)
		{
			StringBuilder script = new StringBuilder();

			#region UICombination   ViewEditPage
			if (pageType == ePageType.UICombination)
			{
				script.Append(" <style type=\"text/css\">");
				script.Append("   .lstb{width:100%;}");
				script.Append("   ");
				script.Append("");
				script.Append("  </style>");
			}
			else if (pageType == ePageType.ViewEditPageRepeater)
			{
				script.Append(" <link href=\"../fancyBox/source/jquery.fancybox.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
				script.Append(" <script src=\"../fancyBox/source/jquery.fancybox.js\" type=\"text/javascript\"></script>\r\n");
			}
			#endregion
			#region ViewPage
			else if (pageType == ePageType.ViewPage)
			{
				script.Append(" <link href=\"../fancyBox/source/jquery.fancybox.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
				script.Append(" <script src=\"../fancyBox/source/jquery.fancybox.js\" type=\"text/javascript\"></script>\r\n");
				script.Append("<script type=\"text/javascript\">\r\n");
				script.Append("  function Add" + _model.EntityName + "()\r\n {\r\n");
				script.Append("     $.fancybox({\r\n");
				script.Append("         href:'" + _model.EntityName + "Edit.aspx',\r\n");
				script.Append("         type: 'iframe',\r\n");
				script.Append("          padding: 0,\r\n");
				script.Append("          openSpeed: 150,\r\n");
				script.Append("         autoSize:false,\r\n");
				script.Append("         afterClose:function()\r\n{\r\n");
				script.Append("          $(\"#BtnRpt\").click();\r\n");
				script.Append("         }\r\n");
				script.Append("      })\r\n");
				script.Append("}\r\n");
				script.Append("  function Edit" + _model.EntityName + "(id)\r\n {\r\n");
				script.Append("     $.fancybox({\r\n");
				script.Append("         href:'" + _model.EntityName + "Edit.aspx?id=' + id,\r\n");
				script.Append("         type: 'iframe',\r\n");
				script.Append("          padding: 0,\r\n");
				script.Append("          openSpeed: 150,\r\n");
				script.Append("         autoSize:false,\r\n");
				script.Append("         afterClose:function()\r\n{\r\n");
				script.Append("          $(\"#BtnRpt\").click(); \r\n");
				script.Append("     } })\r\n");
				script.Append("}\r\n");
				script.Append("</script>\r\n");
			}
			#endregion
			#region ApiViewPage
			else if (pageType == ePageType.ApiViewPage)
			{
				script.Append("<script type=\"text/javascript\">\r\n");
				script.Append("  $(function(){ loadData" + _model.EntityName + "();});\r\n");
				script.Append(GetLoadJsTable());
				script.Append("</script>\r\n");
			}

			#endregion
			#region ApiEditPage
			else if (pageType == ePageType.ApiEditPage)
			{
				script.Append("<script type=\"text/javascript\">\r\n");
				script.Append("$(document).ready(function () {\r\n");
				script.Append("\t$(\"#BtnSave\").click(Add());\r\n");
				script.Append("});\r\n");
				script.Append(GetLoadAddPost());

				script.Append("</script>\r\n");
			}
			#endregion
			#region ApiViewEditPage
			else if (pageType == ePageType.ApiViewEditPage)
			{
				script.Append("<script type=\"text/javascript\">\r\n");
				script.Append("  $(function(){ loadData" + _model.EntityName + "();});\r\n");
				script.Append(GetLoadAddPost());
				script.Append(GetLoadJsTable());
				script.Append("</script>\r\n");
			}
			#endregion

			return script.ToString();
		}

		#region Private
		string GetLoadJsTable()
		{
			StringBuilder script = new StringBuilder();
			script.Append("  function Update(id)\r\n");
			script.Append("	{\r\n");
			script.Append("	}\r\n");
			script.Append("  function loadData" + _model.EntityName + "()\r\n");
			script.Append("	{\r\n");
			script.Append("     $('#datalist').dataTable({\r\n");
			script.Append("\t\t\t\"paging\": true,\r\n");
			script.Append("\t\t\t\"lengthChange\": true,\r\n");
			script.Append("\t\t\t\"searching\": false,\r\n");
			script.Append("\t\t\t\"ordering\": false,\r\n");
			script.Append("\t\t\t\"orderCellsTop\": false,\r\n");
			script.Append("\t\t\t\"aaSorting\": [[0, \"\"]], //默认的排序方式，第1列，升序排列  ,\r\n");
			script.Append("\t\t\t\"info\": true,\r\n");
			script.Append("\t\t\t\"autoWidth\": false,\r\n");
			script.Append("\t\t\t\"destroy\": true,\r\n");
			script.Append("\t\t\t\"processing\": true,\r\n");
			script.Append("\t\t\t\"scrollX\": true,   //水平新增滚动轴  \r\n");
			script.Append("\t\t\t\"serverSide\": true,    //true代表后台处理分页，false代表前台处理分页  \r\n");
			script.Append("\t\t\t\"aLengthMenu\": [20, 30, 50, 100],\r\n");
			script.Append("\t\t\t\"deferRender\": true,\r\n");
			script.Append("\t\t\t\"ajax\": {\r\n");
			script.AppendFormat("\t\t\t	url: \"api/api_{0}.ashx?cmdName=query\",\r\n", _model.EntityName);
			script.Append("\t\t\t	type: \"post\",\r\n");
			script.Append("\t\t\t	data: { },//查询参数\r\n");
			script.Append("\t\t\t	dataSrc: function (res) {\r\n");
			script.Append("\t\t\t		if (res.code == 1) {\r\n");
			script.Append("\t\t\t			return res.data;\r\n");
			script.Append("\t\t\t		}\r\n");
			script.Append("\t\t\t	},\r\n");
			script.Append("\t\t\t	//dataSrc相当于success，在datatable里面不能用success方法，会覆盖datatable内部回调方法  \r\n");

			script.Append("\t\t\t},\r\n");
			script.Append("\t\t\t//columnDefs: hiddencol,\r\n");
			script.Append("\t\t\tcolumns: [\r\n");
			//script.Append("\t\t\t	{ data: "FundAccountID" },");
			foreach (DataRow dr in _model.Table.Rows)
			{
				script.Append("\t\t\t	{\r\n");
				script.AppendFormat("\t\t\t	 title: \"{0}\" ,\r\n", _Language.GetValueByKey(dr["name"].ToString()));
				script.Append("\t\t\t	 \"defaultContent\": \"\",\r\n");

				if (dr["type"].ToString() == "datetime" || dr["type"].ToString() == "date")
				{
					script.AppendFormat("\t\t\t	 data: \"{0}\" ,\r\n", dr["name"].ToString());
					script.Append("\t\t\t		\"render\": function (data, type, full, meta) {\r\n");
					script.Append("\t\t\t 	return data.replace(\"T\", \" \");\r\n");
					script.Append("\t\t\t	\t\t\t	}\r\n");
				}
				else
				{
					script.AppendFormat("\t\t\t	 data: \"{0}\",\r\n", dr["name"].ToString());
				}
				script.Append("\t\t\t },\r\n");
			}
			script.Append("\t\t\t {");
			script.Append("\t\t\t  title: \"操作\",\r\n");
			script.Append("\t\t\t	 data: \"" + _model.Table.Rows[0]["name"].ToString() + "\" ,\r\n");
			script.Append("\t\t\t	\"render\": function (data, type, full, meta) {\r\n\t\t return  data = '<button onclick=\"Update(' + data + ')\">修改</button>'}\r\n");
			script.Append("\t\t\t }");
			script.Append("\t\t\t],\r\n");
			script.Append("\t\t\t/*是否开启主题*/\r\n");
			script.Append("\t\t\t\"bJQueryUI\": true,\r\n");
			//script.Append("\t\t\t\'fnDrawCallback': function (table) {");
			//script.Append("\t\t\t	$(".pagination").append("&nbsp; 第 <input type='text' id='changePage' class='input-text' style='width:42px;height:27px'> 页 <a class='btn btn-default shiny' href='javascript:void(0);' id='dataTable-btn' style='text-align:center'>Go</a>");
			//script.Append("\t\t\t\	var oTable = $("#datalist").dataTable();");
			//script.Append("\t\t\t\},");
			script.Append("\t\t\t\"oLanguage\": {    // 语言设置  \r\n");
			script.Append("\t\t\t	\"sLengthMenu\": \"每页显示 _MENU_ 条记录\",\r\n");
			script.Append("\t\t\t\"sZeroRecords\": \"抱歉， 没有找到\",\r\n");
			script.Append("\t\t\t\"sInfo\": \"从 _START_ 到 _END_ /共 _TOTAL_ 条数据\",\r\n");
			script.Append("\t\t\t\"sInfoEmpty\": \"没有数据\",\r\n");
			script.Append("\t\t\t\"sInfoFiltered\": \"(从 _MAX_ 条数据中检索)\",\r\n");
			script.Append("\t\t\t\"sZeroRecords\": \"没有检索到数据\",\r\n");
			script.Append("\t\t\t\"sSearch\": \"检索:\",\r\n");
			script.Append("\t\t\t\"oPaginate\": {\r\n");
			script.Append("\t\t\t\"sFirst\": \"|<\",\r\n");
			script.Append("\t\t\t\"sPrevious\": \"<\",\r\n");
			script.Append("\t\t\t\"sNext\": \">\",\r\n");
			script.Append("\t\t\t\"sLast\": \">|\"}}\r\n");
			script.Append("\t\t})\r\n");
			script.Append("}\r\n");

			return script.ToString();
		}
		/*render方法有四个参数，分别为data、type、row、meta，其中主要是使用data和row来进行操作，data是对应当前cell的值，row是对应当前行中的所有cell的值。
		 * 1. 将第一列显示为checkbox
可以在columns属性中实现，也可以在columnDefs属性中实现。
columns: [{
                "data": "name",
                "orderable": false,
                "width": "2%",
                "render": function(data,type,row,meta){
                    return data = '<input type="checkbox" name="'+data+'">';
                }
            },
		 * columnDefs: [{
                //   指定第四列，从0开始，0表示第一列，1表示第二列……
                "targets": 3,
                "render": function(data, type, row, meta) {
                    return '<input type="checkbox" name="checklist" value="' + row.name + '" />'
                }
            }],
		 * 3. 在最后一列添加操作按钮

这是一个非常常见的需求，在最后一列添加一些增删改查操作的按钮。

{
       "data": "id",
       "orderable": false, // 禁用排序
       "defaultContent": "",
       "width": "10%",
       "render": function (data, type, row, meta) {
           return data = '<button class="btn btn-info btn-sm" data-id=' + data + '><i class="fa fa-pencil"></i>Edit</button>'
                  + '<button class="btn btn-danger btn-sm" data-id=' + data + '><i class="fa fa-trash-o"></i>Delete</button>';

        }
 }
		 * 
		 * 4. 字符太长截取显示

当某一列内容太长时只显示部分，超过用...表示。

columns: [{
        data: "content",
        render: function(data, type, row, meta) {
            //type 的值  dispaly sort filter
            //代表，是显示类型的时候判断值的长度是否超过8，如果是则截取
            //这里只处理了类型是显示的，过滤和排序返回原始数据
            if (type === 'display') {
                if (data.length > 8) {
                    return '<span title="' + data + '">' + data.substr(0, 7) + '...</span>';
                } else {
                    return '<span title="' + data + '>' + data + '</span>';
                }
            }
            return data;
        }
    }]
		 * */

		/* 等价于：
		 $.ajax({
  type: 'POST',
  url: url,
  data: data,
  success: success,
  dataType: dataType
});
		 */
		string GetLoadAddPost()
		{
			StringBuilder script = new StringBuilder();
			script.Append("function Add() {\r\n");
			script.AppendFormat("\t\t $.ajax({\r\n", _model.EntityName);
			script.Append("\t\t  type: 'POST',\r\n");
			script.AppendFormat("\t\t url:\"api/api_{0}.ashx?cmdName=insert\",\r\n", _model.EntityName);
			script.Append("\t\t data:[]\r\n");
			script.Append("\t\t dataType:String,\r\n");
			/*
			 * "xml": 返回 XML 文档，可用 jQuery 处理。
			 * "html": 返回纯文本 HTML 信息；包含的 script 标签会在插入 dom 时执行。
			 * "script": 返回纯文本 JavaScript 代码。不会自动缓存结果。除非设置了 "cache" 参数。注意：在远程请求时(不在同一个域下)，所有 POST 请求都将转为 GET 请求。（因为将使用 DOM 的 script标签来加载）
			 * "json": 返回 JSON 数据 。
			 * "jsonp": JSONP 格式。使用 JSONP 形式调用函数时，如 "myurl?callback=?" jQuery 将自动替换 ? 为正确的函数名，以执行回调函数。
			 * "text": 返回纯文本字符串*/
			script.Append("\t\t{\r\n");
			foreach (DataRow dr in _model.Table.Rows)
			{
				script.AppendFormat("\t\t\t{0}:$(\"#IptEdit{0}\").val(),\r\n", dr["name"].ToString());
			}
			script.Remove(script.Length - 5, 5);
			script.Append("error:function(){},\r\n");
			script.Append("success:function(){}\r\n");
			script.Append("})\r\n");
			return script.ToString();
		}

		string GetLoadAddAjax()
		{
			StringBuilder script = new StringBuilder();
			script.Append("function Add() {\r\n");
			script.AppendFormat("\t\t$.post(\"api/api_{0}.ashx?cmdName=insert\",\r\n", _model.EntityName);
			script.Append("\t\t{\r\n");
			foreach (DataRow dr in _model.Table.Rows)
			{
				script.AppendFormat("\t\t\t{0}:$(\"#IptEdit{0}\").val(),\r\n", dr["name"].ToString());
			}
			script.Remove(script.Length - 5, 5);
			script.Append("\r\n");
			script.Append("},\r\n");
			script.Append("function (data, status) {\r\n");
			script.Append("\t\t$(\"#LblMsg\").html(status);\r\n");
			script.Append("\t},\"\")\r\n");
			script.Append("}\r\n");
			return script.ToString();
		}
		/*
		 * lable 用HTML赋值；
		 * input： value成功了
		 */
		#endregion
	}
}
