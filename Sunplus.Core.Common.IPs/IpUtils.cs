using Fanex.Caching;
using Sunplus.Core.Common.IPs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sunplus.Core.Common.IPs
{
	public static class IpUtils
	{
		public const string IpPattern = "(?<First>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.(?<Second>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.(?<Third>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.(?<Fourth>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)";

        private const string VNIPListCacheKey = "Alpha.BetLists.Service.IPService.VNIPList";

        public const string IpLinkFormat = "<a class=\"iplink\" href=\"javascript:OpenIPInfo('{0}');\">{0}</a>";

		private static List<IPVN> IPVNList;

		public static bool IsValidIp(string ip)
		{
			if (string.IsNullOrEmpty(ip))
			{
				return false;
			}
			Regex regex = new Regex("(?<First>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.(?<Second>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.(?<Third>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.(?<Fourth>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)");
			return regex.IsMatch(ip, 0);
		}

		public static string FormatIp(string ip)
		{
			return string.Format("<a class=\"iplink\" href=\"javascript:OpenIPInfo('{0}');\">{0}</a>", ip);
		}

		public static List<IPVN> GetAllVnIps()
		{
            var cache = new CacheServiceImpl();

            var vietnamIPs = cache.GetOrSet(
                VNIPListCacheKey,
                () =>
                {
                    List<IPVN> list = cache.Get<List<IPVN>>("Sunplus.Core.Common.IPs.IpVnKey");
                    if (object.ReferenceEquals(list, null))
                    {
                        using (IPEntities iPEntities = new IPEntities(Utility.GetEFConnectionString()))
                        {
                            list = (from s in iPEntities.IPVN
                                    select s).ToList<IPVN>();
                        }
                    }

                    IpUtils.IPVNList = list;

                    return list;
                },
                new CacheItemOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(1)
                });

            return vietnamIPs;
		}

		public static double ConvertIpToNumber(string ip)
		{
			double result = 0.0;
			if (IpUtils.IsValidIp(ip))
			{
				string[] array = ip.Split(new char[]
				{
					'.'
				});
				result = double.Parse(array[0]) * 16777216.0 + double.Parse(array[1]) * 65536.0 + double.Parse(array[2]) * 256.0 + double.Parse(array[3]);
			}
			return result;
		}

		public static bool IsVnIp(string ip)
		{
			if (string.IsNullOrEmpty(ip))
			{
				return false;
			}
			double ipNumber = IpUtils.ConvertIpToNumber(ip);
			List<IPVN> list = IpUtils.IPVNList ?? IpUtils.GetAllVnIps();
			if (list != null)
			{
				return list.Exists((IPVN ipvn) => (double)ipvn.IPFrom <= ipNumber && ipNumber <= (double)ipvn.IPTo);
			}
			return false;
		}

		public static IPTable LocationFromIP(string ip)
		{
			using (IPEntities iPEntities = new IPEntities(Utility.GetEFConnectionString()))
			{
				List<IPTable> list = iPEntities.GetIPInfo_Full(ip).ToList<IPTable>();
				if (list != null && list.Count > 0)
				{
					return list[0];
				}
			}
			return new IPTable();
		}
	}
}
