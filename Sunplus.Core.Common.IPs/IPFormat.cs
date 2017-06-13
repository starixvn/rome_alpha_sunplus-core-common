using System;
using System.Text.RegularExpressions;

namespace Sunplus.Core.Common.IPs
{
	public class IPFormat
	{
		public string IP
		{
			get;
			set;
		}

		protected virtual IContextIPInfo Context
		{
			get
			{
				return new ContextIPInfo
				{
					AdminId = 0,
					IsAdminCanViewVNIP = true,
					DefaultNoIPVN = string.Empty
				};
			}
		}

		protected virtual string LinkFormat
		{
			get
			{
				return "<a href=\"javascript:OpenIPInfo('{0}');\" class=\"iplink\">{0}</a>";
			}
		}

		protected virtual string LinkNoFormat
		{
			get
			{
				return "<span class='ipnolink'>{0}</span>";
			}
		}

		protected IPFormat()
		{
		}

		public IPFormat(string ip)
		{
			this.IP = ip;
		}

		public string Format()
		{
			if (string.IsNullOrEmpty(this.IP))
			{
				return string.Empty;
			}
			string result = string.Format(this.LinkFormat, this.IP);
			IContextIPInfo context = this.Context;
			bool flag = context.AdminId > 0;
			bool isAdminCanViewVNIP = context.IsAdminCanViewVNIP;
			if (flag)
			{
				bool flag2 = IpUtils.IsVnIp(this.IP);
				if (flag2 && !isAdminCanViewVNIP)
				{
					result = string.Format(this.LinkNoFormat, context.DefaultNoIPVN);
				}
			}
			return result;
		}

		public string FormatAll(string content)
		{
			Regex regex = new Regex("(?<First>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.(?<Second>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.(?<Third>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.(?<Fourth>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)", RegexOptions.Compiled);
			return regex.Replace(content, delegate(Match match)
			{
				this.IP = match.Value;
				return this.Format();
			});
		}
	}
}
