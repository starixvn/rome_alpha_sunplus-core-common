using System;
using System.Data.EntityClient;
using System.Data.Objects;

namespace Sunplus.Core.Common.IPs.DAL
{
	public class IPEntities : ObjectContext
	{
		private ObjectSet<IPTable> _IPTable;

		private ObjectSet<IPVN> _IPVN;

		private ObjectSet<dtproperty> _dtproperties;

		private ObjectSet<IPOffice> _IPOffices;

		public ObjectSet<IPTable> IPTable
		{
			get
			{
				if (this._IPTable == null)
				{
					this._IPTable = base.CreateObjectSet<IPTable>("IPTable");
				}
				return this._IPTable;
			}
		}

		public ObjectSet<IPVN> IPVN
		{
			get
			{
				if (this._IPVN == null)
				{
					this._IPVN = base.CreateObjectSet<IPVN>("IPVN");
				}
				return this._IPVN;
			}
		}

		public ObjectSet<dtproperty> dtproperties
		{
			get
			{
				if (this._dtproperties == null)
				{
					this._dtproperties = base.CreateObjectSet<dtproperty>("dtproperties");
				}
				return this._dtproperties;
			}
		}

		public ObjectSet<IPOffice> IPOffices
		{
			get
			{
				if (this._IPOffices == null)
				{
					this._IPOffices = base.CreateObjectSet<IPOffice>("IPOffices");
				}
				return this._IPOffices;
			}
		}

		public IPEntities() : base("name=IPEntities", "IPEntities")
		{
		}

		public IPEntities(string connectionString) : base(connectionString, "IPEntities")
		{
		}

		public IPEntities(EntityConnection connection) : base(connection, "IPEntities")
		{
		}

		public void AddToIPTable(IPTable iPTable)
		{
			base.AddObject("IPTable", iPTable);
		}

		public void AddToIPVN(IPVN iPVN)
		{
			base.AddObject("IPVN", iPVN);
		}

		public void AddTodtproperties(dtproperty dtproperty)
		{
			base.AddObject("dtproperties", dtproperty);
		}

		public void AddToIPOffices(IPOffice iPOffice)
		{
			base.AddObject("IPOffices", iPOffice);
		}

		public ObjectResult<IPTable> GetIPInfo_Full(string iP)
		{
			ObjectParameter objectParameter;
			if (iP != null)
			{
				objectParameter = new ObjectParameter("IP", iP);
			}
			else
			{
				objectParameter = new ObjectParameter("IP", typeof(string));
			}
			return base.ExecuteFunction<IPTable>("GetIPInfo_Full", new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<IPTable> GetIPInfo_Full(string iP, MergeOption mergeOption)
		{
			ObjectParameter objectParameter;
			if (iP != null)
			{
				objectParameter = new ObjectParameter("IP", iP);
			}
			else
			{
				objectParameter = new ObjectParameter("IP", typeof(string));
			}
			return base.ExecuteFunction<IPTable>("GetIPInfo_Full", mergeOption, new ObjectParameter[]
			{
				objectParameter
			});
		}
	}
}
