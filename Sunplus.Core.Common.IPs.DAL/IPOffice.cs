using System;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace Sunplus.Core.Common.IPs.DAL
{
	[EdmEntityType(NamespaceName = "IPDBModel", Name = "IPOffice"), DataContract(IsReference = true)]
	[Serializable]
	public class IPOffice : EntityObject
	{
		private string _IP;

		private string _Remark;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public string IP
		{
			get
			{
				return this._IP;
			}
			set
			{
				if (this._IP != value)
				{
					this.ReportPropertyChanging("IP");
					this._IP = StructuralObject.SetValidValue(value, false);
					this.ReportPropertyChanged("IP");
				}
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string Remark
		{
			get
			{
				return this._Remark;
			}
			set
			{
				this.ReportPropertyChanging("Remark");
				this._Remark = StructuralObject.SetValidValue(value, true);
				this.ReportPropertyChanged("Remark");
			}
		}

		public static IPOffice CreateIPOffice(string iP)
		{
			return new IPOffice
			{
				IP = iP
			};
		}
	}
}
