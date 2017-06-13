using System;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace Sunplus.Core.Common.IPs.DAL
{
	[EdmEntityType(NamespaceName = "IPDBModel", Name = "IPTable"), DataContract(IsReference = true)]
	[Serializable]
	public class IPTable : EntityObject
	{
		private byte _IPKeyFrom;

		private byte _IpKeyTo;

		private long _IPFrom;

		private long _IPTo;

		private string _CountryShort;

		private string _CountryLong;

		private string _ipRegion;

		private string _ipCity;

		private bool? _IsModified;

		private bool? _IsException;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public byte IPKeyFrom
		{
			get
			{
				return this._IPKeyFrom;
			}
			set
			{
				if (this._IPKeyFrom != value)
				{
					this.ReportPropertyChanging("IPKeyFrom");
					this._IPKeyFrom = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("IPKeyFrom");
				}
			}
		}

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public byte IpKeyTo
		{
			get
			{
				return this._IpKeyTo;
			}
			set
			{
				if (this._IpKeyTo != value)
				{
					this.ReportPropertyChanging("IpKeyTo");
					this._IpKeyTo = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("IpKeyTo");
				}
			}
		}

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

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public string CountryShort
		{
			get
			{
				return this._CountryShort;
			}
			set
			{
				if (this._CountryShort != value)
				{
					this.ReportPropertyChanging("CountryShort");
					this._CountryShort = StructuralObject.SetValidValue(value, false);
					this.ReportPropertyChanged("CountryShort");
				}
			}
		}

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public string CountryLong
		{
			get
			{
				return this._CountryLong;
			}
			set
			{
				if (this._CountryLong != value)
				{
					this.ReportPropertyChanging("CountryLong");
					this._CountryLong = StructuralObject.SetValidValue(value, false);
					this.ReportPropertyChanged("CountryLong");
				}
			}
		}

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public string ipRegion
		{
			get
			{
				return this._ipRegion;
			}
			set
			{
				if (this._ipRegion != value)
				{
					this.ReportPropertyChanging("ipRegion");
					this._ipRegion = StructuralObject.SetValidValue(value, false);
					this.ReportPropertyChanged("ipRegion");
				}
			}
		}

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public string ipCity
		{
			get
			{
				return this._ipCity;
			}
			set
			{
				if (this._ipCity != value)
				{
					this.ReportPropertyChanging("ipCity");
					this._ipCity = StructuralObject.SetValidValue(value, false);
					this.ReportPropertyChanged("ipCity");
				}
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public bool? IsModified
		{
			get
			{
				return this._IsModified;
			}
			set
			{
				this.ReportPropertyChanging("IsModified");
				this._IsModified = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("IsModified");
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public bool? IsException
		{
			get
			{
				return this._IsException;
			}
			set
			{
				this.ReportPropertyChanging("IsException");
				this._IsException = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("IsException");
			}
		}

		public string Region
		{
			get
			{
				return this.ipRegion;
			}
		}

		public string City
		{
			get
			{
				return this.ipCity;
			}
		}

		public string FlagPath
		{
			get;
			set;
		}

		public static IPTable CreateIPTable(byte iPKeyFrom, byte ipKeyTo, long iPFrom, long iPTo, string countryShort, string countryLong, string ipRegion, string ipCity)
		{
			return new IPTable
			{
				IPKeyFrom = iPKeyFrom,
				IpKeyTo = ipKeyTo,
				IPFrom = iPFrom,
				IPTo = iPTo,
				CountryShort = countryShort,
				CountryLong = countryLong,
				ipRegion = ipRegion,
				ipCity = ipCity
			};
		}
	}
}
