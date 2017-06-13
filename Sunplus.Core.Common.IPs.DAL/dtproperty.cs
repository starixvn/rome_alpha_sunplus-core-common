using System;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace Sunplus.Core.Common.IPs.DAL
{
	[EdmEntityType(NamespaceName = "IPDBModel", Name = "dtproperty"), DataContract(IsReference = true)]
	[Serializable]
	public class dtproperty : EntityObject
	{
		private int _id;

		private int? _objectid;

		private string _property;

		private string _value;

		private string _uvalue;

		private byte[] _lvalue;

		private int _version;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if (this._id != value)
				{
					this.ReportPropertyChanging("id");
					this._id = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("id");
				}
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public int? objectid
		{
			get
			{
				return this._objectid;
			}
			set
			{
				this.ReportPropertyChanging("objectid");
				this._objectid = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("objectid");
			}
		}

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public string property
		{
			get
			{
				return this._property;
			}
			set
			{
				if (this._property != value)
				{
					this.ReportPropertyChanging("property");
					this._property = StructuralObject.SetValidValue(value, false);
					this.ReportPropertyChanged("property");
				}
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string value
		{
			get
			{
				return this._value;
			}
			set
			{
				this.ReportPropertyChanging("value");
				this._value = StructuralObject.SetValidValue(value, true);
				this.ReportPropertyChanged("value");
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string uvalue
		{
			get
			{
				return this._uvalue;
			}
			set
			{
				this.ReportPropertyChanging("uvalue");
				this._uvalue = StructuralObject.SetValidValue(value, true);
				this.ReportPropertyChanged("uvalue");
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public byte[] lvalue
		{
			get
			{
				return StructuralObject.GetValidValue(this._lvalue);
			}
			set
			{
				this.ReportPropertyChanging("lvalue");
				this._lvalue = StructuralObject.SetValidValue(value, true);
				this.ReportPropertyChanged("lvalue");
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public int version
		{
			get
			{
				return this._version;
			}
			set
			{
				this.ReportPropertyChanging("version");
				this._version = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("version");
			}
		}

		public static dtproperty Createdtproperty(int id, string property, int version)
		{
			return new dtproperty
			{
				id = id,
				property = property,
				version = version
			};
		}
	}
}
