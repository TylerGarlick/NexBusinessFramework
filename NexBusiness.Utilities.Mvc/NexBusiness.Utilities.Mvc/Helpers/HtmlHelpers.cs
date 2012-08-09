using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

public static class HtmlHelpers
{
	public static IHtmlString LinkToRemoveNestedForm(this HtmlHelper htmlHelper, string linkText, string container, string deleteElement)
	{
		var js = string.Format("javascript:removeNestedForm(this,'{0}','{1}');return false;", container, deleteElement);
		var tb = new TagBuilder("a");
		tb.Attributes.Add("href", "#");
		tb.Attributes.Add("onclick", js);
		tb.InnerHtml = linkText;
		tb.Attributes.Add("data-role", "button");
		var tag = tb.ToString(TagRenderMode.Normal);
		return MvcHtmlString.Create(tag);
	}

	public static IHtmlString LinkToAddNestedForm<TModel>(this HtmlHelper<TModel> htmlHelper, string linkText, string containerElement, string counterElement, string collectionProperty, Type nestedType)
	{
		var ticks = DateTime.UtcNow.Ticks;
		var nestedObject = Activator.CreateInstance(nestedType);
		var partial = htmlHelper.EditorFor(x => nestedObject).ToHtmlString().JsEncode();
		partial = partial.Replace("id=\\\"nestedObject", "id=\\\"" + collectionProperty + "_" + ticks + "_");
		partial = partial.Replace("name=\\\"nestedObject", "name=\\\"" + collectionProperty + "[" + ticks + "]");
		var js = string.Format("javascript:addNestedForm('{0}','{1}','{2}','{3}');return false;", containerElement, counterElement, ticks, partial);
		var tb = new TagBuilder("a");
		tb.Attributes.Add("href", "#");
		tb.Attributes.Add("onclick", js);
		tb.Attributes.Add("data-role", "button");
		tb.Attributes.Add("data-theme","b");
		tb.InnerHtml = linkText;
		//tb.MergeAttributes(attributes);
		var tag = tb.ToString(TagRenderMode.Normal);
		return MvcHtmlString.Create(tag);
	}

	private static string JsEncode(this string s)
	{
		if (string.IsNullOrEmpty(s))
			return "";
		int i;
		int len = s.Length;
		var sb = new StringBuilder(len + 4);
		string t;

		for (i = 0; i < len; i += 1)
		{
			char c = s[i];
			switch (c)
			{
				case '>':
				case '"':
				case '\\':
					sb.Append('\\');
					sb.Append(c);
					break;
				case '\b':
					sb.Append("\\b");
					break;
				case '\t':
					sb.Append("\\t");
					break;
				case '\n':
					//sb.Append("\\n");
					break;
				case '\f':
					sb.Append("\\f");
					break;
				case '\r':
					//sb.Append("\\r");
					break;
				default:
					if (c < ' ')
					{
						//t = "000" + Integer.toHexString(c); 
						string tmp = new string(c, 1);
						t = "000" + int.Parse(tmp, System.Globalization.NumberStyles.HexNumber);
						sb.Append("\\u" + t.Substring(t.Length - 4));
					}
					else
					{
						sb.Append(c);
					}
					break;
			}
		}
		return sb.ToString();
	}
}
