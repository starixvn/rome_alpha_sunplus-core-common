using System;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace Sunplus.Core.Common.IPs.DAL
{
	[EdmEntityType(NamespaceName = "IPDBModel", Name = "IPVN"), DataContract(IsReference = true)]
	[Serializable]
	public class IPVN : EntityObject
	{
		private long _IPFrom;

		private long _IPTo;

		private bool? _IsManual;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public long IPFrom
		{
			get
			{
				return this._IPFrom;
			}
			set
			{
				if (this._IPFrom != value)
				{
					this.ReportPropertyChanging("IPFrom");
					this._IPFrom = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("IPFrom");
				}
			}
		}

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public long IPTo
		{
			get
			{
				return this._IPTo;
			}
			set
			{
				if (this._IPTo != value)
				{
					this.ReportPropertyChanging("IPTo");
					this._IPTo = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("IPTo");
				}
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public bool? IsManual
		{
			get
			{
				return this._IsManual;
			}
			set
			{
				this.ReportPropertyChanging("IsManual");
				this._IsManual = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("IsManual");
			}
		}

		public static IPVN CreateIPVN(long iPFrom, long iPTo)
		{
			return new IPVN
			{
				IPFrom = iPFrom,
				IPTo = iPTo
			};
		}
	}
}
