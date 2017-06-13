using System;

namespace Sunplus.Core.Common.IPs
{
	public interface IContextIPInfo
	{
		int AdminId
		{
			get;
			set;
		}

		bool IsAdminCanViewVNIP
		{
			get;
			set;
		}

		string DefaultNoIPVN
		{
			get;
			set;
		}
	}
}
