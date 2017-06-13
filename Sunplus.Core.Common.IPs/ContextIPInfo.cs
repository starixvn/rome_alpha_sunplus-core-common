using System;

namespace Sunplus.Core.Common.IPs
{
	public class ContextIPInfo : IContextIPInfo
	{
		public int AdminId
		{
			get;
			set;
		}

		public bool IsAdminCanViewVNIP
		{
			get;
			set;
		}

		public string DefaultNoIPVN
		{
			get;
			set;
		}
	}
}
