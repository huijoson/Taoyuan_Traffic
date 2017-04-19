﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Taoyuan_Traffic.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Taoyuan_Traffic")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 擴充性方法定義
    partial void OnCreated();
    partial void InsertBusDynamic(BusDynamic instance);
    partial void UpdateBusDynamic(BusDynamic instance);
    partial void DeleteBusDynamic(BusDynamic instance);
    partial void InsertBusRoute(BusRoute instance);
    partial void UpdateBusRoute(BusRoute instance);
    partial void DeleteBusRoute(BusRoute instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["Taoyuan_TrafficConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BusDynamic> BusDynamic
		{
			get
			{
				return this.GetTable<BusDynamic>();
			}
		}
		
		public System.Data.Linq.Table<BusRoute> BusRoute
		{
			get
			{
				return this.GetTable<BusRoute>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BusDynamic")]
	public partial class BusDynamic : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _PlateNumb;
		
		private string _OperatorID;
		
		private string _RouteUID;
		
		private string _RouteID;
		
		private string _SubRouteUID;
		
		private string _SubRouteID;
		
		private System.Nullable<int> _Direction;
		
		private System.Nullable<double> _Speed;
		
		private System.Nullable<double> _Azimuth;
		
		private System.Nullable<int> _DutyStatus;
		
		private System.Nullable<int> _BusStatus;
		
		private System.Nullable<int> _MessageType;
		
		private System.Nullable<System.DateTime> _GPSTime;
		
		private System.Nullable<System.DateTime> _SrcRecTime;
		
		private System.Nullable<System.DateTime> _SrcUpdateTime;
		
		private System.Nullable<System.DateTime> _UpdateTime;
		
		private System.Nullable<double> _PositionLat;
		
		private System.Nullable<double> _PositionLon;
		
		private string _SubRouteName;
		
		private string _RouteName;
		
    #region 擴充性方法定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnPlateNumbChanging(string value);
    partial void OnPlateNumbChanged();
    partial void OnOperatorIDChanging(string value);
    partial void OnOperatorIDChanged();
    partial void OnRouteUIDChanging(string value);
    partial void OnRouteUIDChanged();
    partial void OnRouteIDChanging(string value);
    partial void OnRouteIDChanged();
    partial void OnSubRouteUIDChanging(string value);
    partial void OnSubRouteUIDChanged();
    partial void OnSubRouteIDChanging(string value);
    partial void OnSubRouteIDChanged();
    partial void OnDirectionChanging(System.Nullable<int> value);
    partial void OnDirectionChanged();
    partial void OnSpeedChanging(System.Nullable<double> value);
    partial void OnSpeedChanged();
    partial void OnAzimuthChanging(System.Nullable<double> value);
    partial void OnAzimuthChanged();
    partial void OnDutyStatusChanging(System.Nullable<int> value);
    partial void OnDutyStatusChanged();
    partial void OnBusStatusChanging(System.Nullable<int> value);
    partial void OnBusStatusChanged();
    partial void OnMessageTypeChanging(System.Nullable<int> value);
    partial void OnMessageTypeChanged();
    partial void OnGPSTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnGPSTimeChanged();
    partial void OnSrcRecTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnSrcRecTimeChanged();
    partial void OnSrcUpdateTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnSrcUpdateTimeChanged();
    partial void OnUpdateTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnUpdateTimeChanged();
    partial void OnPositionLatChanging(System.Nullable<double> value);
    partial void OnPositionLatChanged();
    partial void OnPositionLonChanging(System.Nullable<double> value);
    partial void OnPositionLonChanged();
    partial void OnSubRouteNameChanging(string value);
    partial void OnSubRouteNameChanged();
    partial void OnRouteNameChanging(string value);
    partial void OnRouteNameChanged();
    #endregion
		
		public BusDynamic()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlateNumb", DbType="VarChar(20)")]
		public string PlateNumb
		{
			get
			{
				return this._PlateNumb;
			}
			set
			{
				if ((this._PlateNumb != value))
				{
					this.OnPlateNumbChanging(value);
					this.SendPropertyChanging();
					this._PlateNumb = value;
					this.SendPropertyChanged("PlateNumb");
					this.OnPlateNumbChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OperatorID", DbType="VarChar(20)")]
		public string OperatorID
		{
			get
			{
				return this._OperatorID;
			}
			set
			{
				if ((this._OperatorID != value))
				{
					this.OnOperatorIDChanging(value);
					this.SendPropertyChanging();
					this._OperatorID = value;
					this.SendPropertyChanged("OperatorID");
					this.OnOperatorIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RouteUID", DbType="VarChar(20)")]
		public string RouteUID
		{
			get
			{
				return this._RouteUID;
			}
			set
			{
				if ((this._RouteUID != value))
				{
					this.OnRouteUIDChanging(value);
					this.SendPropertyChanging();
					this._RouteUID = value;
					this.SendPropertyChanged("RouteUID");
					this.OnRouteUIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RouteID", DbType="VarChar(20)")]
		public string RouteID
		{
			get
			{
				return this._RouteID;
			}
			set
			{
				if ((this._RouteID != value))
				{
					this.OnRouteIDChanging(value);
					this.SendPropertyChanging();
					this._RouteID = value;
					this.SendPropertyChanged("RouteID");
					this.OnRouteIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubRouteUID", DbType="VarChar(20)")]
		public string SubRouteUID
		{
			get
			{
				return this._SubRouteUID;
			}
			set
			{
				if ((this._SubRouteUID != value))
				{
					this.OnSubRouteUIDChanging(value);
					this.SendPropertyChanging();
					this._SubRouteUID = value;
					this.SendPropertyChanged("SubRouteUID");
					this.OnSubRouteUIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubRouteID", DbType="VarChar(20)")]
		public string SubRouteID
		{
			get
			{
				return this._SubRouteID;
			}
			set
			{
				if ((this._SubRouteID != value))
				{
					this.OnSubRouteIDChanging(value);
					this.SendPropertyChanging();
					this._SubRouteID = value;
					this.SendPropertyChanged("SubRouteID");
					this.OnSubRouteIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Direction", DbType="Int")]
		public System.Nullable<int> Direction
		{
			get
			{
				return this._Direction;
			}
			set
			{
				if ((this._Direction != value))
				{
					this.OnDirectionChanging(value);
					this.SendPropertyChanging();
					this._Direction = value;
					this.SendPropertyChanged("Direction");
					this.OnDirectionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Speed", DbType="Float")]
		public System.Nullable<double> Speed
		{
			get
			{
				return this._Speed;
			}
			set
			{
				if ((this._Speed != value))
				{
					this.OnSpeedChanging(value);
					this.SendPropertyChanging();
					this._Speed = value;
					this.SendPropertyChanged("Speed");
					this.OnSpeedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Azimuth", DbType="Float")]
		public System.Nullable<double> Azimuth
		{
			get
			{
				return this._Azimuth;
			}
			set
			{
				if ((this._Azimuth != value))
				{
					this.OnAzimuthChanging(value);
					this.SendPropertyChanging();
					this._Azimuth = value;
					this.SendPropertyChanged("Azimuth");
					this.OnAzimuthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DutyStatus", DbType="Int")]
		public System.Nullable<int> DutyStatus
		{
			get
			{
				return this._DutyStatus;
			}
			set
			{
				if ((this._DutyStatus != value))
				{
					this.OnDutyStatusChanging(value);
					this.SendPropertyChanging();
					this._DutyStatus = value;
					this.SendPropertyChanged("DutyStatus");
					this.OnDutyStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusStatus", DbType="Int")]
		public System.Nullable<int> BusStatus
		{
			get
			{
				return this._BusStatus;
			}
			set
			{
				if ((this._BusStatus != value))
				{
					this.OnBusStatusChanging(value);
					this.SendPropertyChanging();
					this._BusStatus = value;
					this.SendPropertyChanged("BusStatus");
					this.OnBusStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MessageType", DbType="Int")]
		public System.Nullable<int> MessageType
		{
			get
			{
				return this._MessageType;
			}
			set
			{
				if ((this._MessageType != value))
				{
					this.OnMessageTypeChanging(value);
					this.SendPropertyChanging();
					this._MessageType = value;
					this.SendPropertyChanged("MessageType");
					this.OnMessageTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GPSTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> GPSTime
		{
			get
			{
				return this._GPSTime;
			}
			set
			{
				if ((this._GPSTime != value))
				{
					this.OnGPSTimeChanging(value);
					this.SendPropertyChanging();
					this._GPSTime = value;
					this.SendPropertyChanged("GPSTime");
					this.OnGPSTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SrcRecTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> SrcRecTime
		{
			get
			{
				return this._SrcRecTime;
			}
			set
			{
				if ((this._SrcRecTime != value))
				{
					this.OnSrcRecTimeChanging(value);
					this.SendPropertyChanging();
					this._SrcRecTime = value;
					this.SendPropertyChanged("SrcRecTime");
					this.OnSrcRecTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SrcUpdateTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> SrcUpdateTime
		{
			get
			{
				return this._SrcUpdateTime;
			}
			set
			{
				if ((this._SrcUpdateTime != value))
				{
					this.OnSrcUpdateTimeChanging(value);
					this.SendPropertyChanging();
					this._SrcUpdateTime = value;
					this.SendPropertyChanged("SrcUpdateTime");
					this.OnSrcUpdateTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UpdateTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> UpdateTime
		{
			get
			{
				return this._UpdateTime;
			}
			set
			{
				if ((this._UpdateTime != value))
				{
					this.OnUpdateTimeChanging(value);
					this.SendPropertyChanging();
					this._UpdateTime = value;
					this.SendPropertyChanged("UpdateTime");
					this.OnUpdateTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PositionLat", DbType="Float")]
		public System.Nullable<double> PositionLat
		{
			get
			{
				return this._PositionLat;
			}
			set
			{
				if ((this._PositionLat != value))
				{
					this.OnPositionLatChanging(value);
					this.SendPropertyChanging();
					this._PositionLat = value;
					this.SendPropertyChanged("PositionLat");
					this.OnPositionLatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PositionLon", DbType="Float")]
		public System.Nullable<double> PositionLon
		{
			get
			{
				return this._PositionLon;
			}
			set
			{
				if ((this._PositionLon != value))
				{
					this.OnPositionLonChanging(value);
					this.SendPropertyChanging();
					this._PositionLon = value;
					this.SendPropertyChanged("PositionLon");
					this.OnPositionLonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubRouteName", DbType="VarChar(50)")]
		public string SubRouteName
		{
			get
			{
				return this._SubRouteName;
			}
			set
			{
				if ((this._SubRouteName != value))
				{
					this.OnSubRouteNameChanging(value);
					this.SendPropertyChanging();
					this._SubRouteName = value;
					this.SendPropertyChanged("SubRouteName");
					this.OnSubRouteNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RouteName", DbType="VarChar(50)")]
		public string RouteName
		{
			get
			{
				return this._RouteName;
			}
			set
			{
				if ((this._RouteName != value))
				{
					this.OnRouteNameChanging(value);
					this.SendPropertyChanging();
					this._RouteName = value;
					this.SendPropertyChanged("RouteName");
					this.OnRouteNameChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BusRoute")]
	public partial class BusRoute : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _RouteUID;
		
		private string _RouteID;
		
		private string _OperatorIDs;
		
		private string _AuthorityID;
		
		private string _ProviderID;
		
		private string _GoSubRouteUID;
		
		private string _GoSubRouteID;
		
		private string _GoOperatorIDs;
		
		private string _GoSubRouteName;
		
		private string _GoHeadsign;
		
		private System.Nullable<int> _GoDirection;
		
		private string _BackSubRouteUID;
		
		private string _BackSubRouteID;
		
		private string _BackOperatorIDs;
		
		private string _BackSubRouteName;
		
		private string _BackHeadsign;
		
		private System.Nullable<int> _BackDirection;
		
		private System.Nullable<int> _BusRouteType;
		
		private string _RouteName;
		
		private string _DepartureStopNameZh;
		
		private string _DestinationStopNameZh;
		
		private System.Nullable<System.DateTime> _UpdateDate;
		
		private System.Nullable<System.DateTime> _UpdateTime;
		
    #region 擴充性方法定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnRouteUIDChanging(string value);
    partial void OnRouteUIDChanged();
    partial void OnRouteIDChanging(string value);
    partial void OnRouteIDChanged();
    partial void OnOperatorIDsChanging(string value);
    partial void OnOperatorIDsChanged();
    partial void OnAuthorityIDChanging(string value);
    partial void OnAuthorityIDChanged();
    partial void OnProviderIDChanging(string value);
    partial void OnProviderIDChanged();
    partial void OnGoSubRouteUIDChanging(string value);
    partial void OnGoSubRouteUIDChanged();
    partial void OnGoSubRouteIDChanging(string value);
    partial void OnGoSubRouteIDChanged();
    partial void OnGoOperatorIDsChanging(string value);
    partial void OnGoOperatorIDsChanged();
    partial void OnGoSubRouteNameChanging(string value);
    partial void OnGoSubRouteNameChanged();
    partial void OnGoHeadsignChanging(string value);
    partial void OnGoHeadsignChanged();
    partial void OnGoDirectionChanging(System.Nullable<int> value);
    partial void OnGoDirectionChanged();
    partial void OnBackSubRouteUIDChanging(string value);
    partial void OnBackSubRouteUIDChanged();
    partial void OnBackSubRouteIDChanging(string value);
    partial void OnBackSubRouteIDChanged();
    partial void OnBackOperatorIDsChanging(string value);
    partial void OnBackOperatorIDsChanged();
    partial void OnBackSubRouteNameChanging(string value);
    partial void OnBackSubRouteNameChanged();
    partial void OnBackHeadsignChanging(string value);
    partial void OnBackHeadsignChanged();
    partial void OnBackDirectionChanging(System.Nullable<int> value);
    partial void OnBackDirectionChanged();
    partial void OnBusRouteTypeChanging(System.Nullable<int> value);
    partial void OnBusRouteTypeChanged();
    partial void OnRouteNameChanging(string value);
    partial void OnRouteNameChanged();
    partial void OnDepartureStopNameZhChanging(string value);
    partial void OnDepartureStopNameZhChanged();
    partial void OnDestinationStopNameZhChanging(string value);
    partial void OnDestinationStopNameZhChanged();
    partial void OnUpdateDateChanging(System.Nullable<System.DateTime> value);
    partial void OnUpdateDateChanged();
    partial void OnUpdateTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnUpdateTimeChanged();
    #endregion
		
		public BusRoute()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RouteUID", DbType="NVarChar(30)")]
		public string RouteUID
		{
			get
			{
				return this._RouteUID;
			}
			set
			{
				if ((this._RouteUID != value))
				{
					this.OnRouteUIDChanging(value);
					this.SendPropertyChanging();
					this._RouteUID = value;
					this.SendPropertyChanged("RouteUID");
					this.OnRouteUIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RouteID", DbType="NVarChar(30)")]
		public string RouteID
		{
			get
			{
				return this._RouteID;
			}
			set
			{
				if ((this._RouteID != value))
				{
					this.OnRouteIDChanging(value);
					this.SendPropertyChanging();
					this._RouteID = value;
					this.SendPropertyChanged("RouteID");
					this.OnRouteIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OperatorIDs", DbType="NVarChar(30)")]
		public string OperatorIDs
		{
			get
			{
				return this._OperatorIDs;
			}
			set
			{
				if ((this._OperatorIDs != value))
				{
					this.OnOperatorIDsChanging(value);
					this.SendPropertyChanging();
					this._OperatorIDs = value;
					this.SendPropertyChanged("OperatorIDs");
					this.OnOperatorIDsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuthorityID", DbType="NVarChar(30)")]
		public string AuthorityID
		{
			get
			{
				return this._AuthorityID;
			}
			set
			{
				if ((this._AuthorityID != value))
				{
					this.OnAuthorityIDChanging(value);
					this.SendPropertyChanging();
					this._AuthorityID = value;
					this.SendPropertyChanged("AuthorityID");
					this.OnAuthorityIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProviderID", DbType="NVarChar(30)")]
		public string ProviderID
		{
			get
			{
				return this._ProviderID;
			}
			set
			{
				if ((this._ProviderID != value))
				{
					this.OnProviderIDChanging(value);
					this.SendPropertyChanging();
					this._ProviderID = value;
					this.SendPropertyChanged("ProviderID");
					this.OnProviderIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GoSubRouteUID", DbType="NVarChar(30)")]
		public string GoSubRouteUID
		{
			get
			{
				return this._GoSubRouteUID;
			}
			set
			{
				if ((this._GoSubRouteUID != value))
				{
					this.OnGoSubRouteUIDChanging(value);
					this.SendPropertyChanging();
					this._GoSubRouteUID = value;
					this.SendPropertyChanged("GoSubRouteUID");
					this.OnGoSubRouteUIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GoSubRouteID", DbType="NVarChar(30)")]
		public string GoSubRouteID
		{
			get
			{
				return this._GoSubRouteID;
			}
			set
			{
				if ((this._GoSubRouteID != value))
				{
					this.OnGoSubRouteIDChanging(value);
					this.SendPropertyChanging();
					this._GoSubRouteID = value;
					this.SendPropertyChanged("GoSubRouteID");
					this.OnGoSubRouteIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GoOperatorIDs", DbType="NVarChar(30)")]
		public string GoOperatorIDs
		{
			get
			{
				return this._GoOperatorIDs;
			}
			set
			{
				if ((this._GoOperatorIDs != value))
				{
					this.OnGoOperatorIDsChanging(value);
					this.SendPropertyChanging();
					this._GoOperatorIDs = value;
					this.SendPropertyChanged("GoOperatorIDs");
					this.OnGoOperatorIDsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GoSubRouteName", DbType="NVarChar(30)")]
		public string GoSubRouteName
		{
			get
			{
				return this._GoSubRouteName;
			}
			set
			{
				if ((this._GoSubRouteName != value))
				{
					this.OnGoSubRouteNameChanging(value);
					this.SendPropertyChanging();
					this._GoSubRouteName = value;
					this.SendPropertyChanged("GoSubRouteName");
					this.OnGoSubRouteNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GoHeadsign", DbType="NVarChar(30)")]
		public string GoHeadsign
		{
			get
			{
				return this._GoHeadsign;
			}
			set
			{
				if ((this._GoHeadsign != value))
				{
					this.OnGoHeadsignChanging(value);
					this.SendPropertyChanging();
					this._GoHeadsign = value;
					this.SendPropertyChanged("GoHeadsign");
					this.OnGoHeadsignChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GoDirection", DbType="Int")]
		public System.Nullable<int> GoDirection
		{
			get
			{
				return this._GoDirection;
			}
			set
			{
				if ((this._GoDirection != value))
				{
					this.OnGoDirectionChanging(value);
					this.SendPropertyChanging();
					this._GoDirection = value;
					this.SendPropertyChanged("GoDirection");
					this.OnGoDirectionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BackSubRouteUID", DbType="NVarChar(30)")]
		public string BackSubRouteUID
		{
			get
			{
				return this._BackSubRouteUID;
			}
			set
			{
				if ((this._BackSubRouteUID != value))
				{
					this.OnBackSubRouteUIDChanging(value);
					this.SendPropertyChanging();
					this._BackSubRouteUID = value;
					this.SendPropertyChanged("BackSubRouteUID");
					this.OnBackSubRouteUIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BackSubRouteID", DbType="NVarChar(30)")]
		public string BackSubRouteID
		{
			get
			{
				return this._BackSubRouteID;
			}
			set
			{
				if ((this._BackSubRouteID != value))
				{
					this.OnBackSubRouteIDChanging(value);
					this.SendPropertyChanging();
					this._BackSubRouteID = value;
					this.SendPropertyChanged("BackSubRouteID");
					this.OnBackSubRouteIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BackOperatorIDs", DbType="NVarChar(30)")]
		public string BackOperatorIDs
		{
			get
			{
				return this._BackOperatorIDs;
			}
			set
			{
				if ((this._BackOperatorIDs != value))
				{
					this.OnBackOperatorIDsChanging(value);
					this.SendPropertyChanging();
					this._BackOperatorIDs = value;
					this.SendPropertyChanged("BackOperatorIDs");
					this.OnBackOperatorIDsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BackSubRouteName", DbType="NVarChar(30)")]
		public string BackSubRouteName
		{
			get
			{
				return this._BackSubRouteName;
			}
			set
			{
				if ((this._BackSubRouteName != value))
				{
					this.OnBackSubRouteNameChanging(value);
					this.SendPropertyChanging();
					this._BackSubRouteName = value;
					this.SendPropertyChanged("BackSubRouteName");
					this.OnBackSubRouteNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BackHeadsign", DbType="NVarChar(30)")]
		public string BackHeadsign
		{
			get
			{
				return this._BackHeadsign;
			}
			set
			{
				if ((this._BackHeadsign != value))
				{
					this.OnBackHeadsignChanging(value);
					this.SendPropertyChanging();
					this._BackHeadsign = value;
					this.SendPropertyChanged("BackHeadsign");
					this.OnBackHeadsignChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BackDirection", DbType="Int")]
		public System.Nullable<int> BackDirection
		{
			get
			{
				return this._BackDirection;
			}
			set
			{
				if ((this._BackDirection != value))
				{
					this.OnBackDirectionChanging(value);
					this.SendPropertyChanging();
					this._BackDirection = value;
					this.SendPropertyChanged("BackDirection");
					this.OnBackDirectionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusRouteType", DbType="Int")]
		public System.Nullable<int> BusRouteType
		{
			get
			{
				return this._BusRouteType;
			}
			set
			{
				if ((this._BusRouteType != value))
				{
					this.OnBusRouteTypeChanging(value);
					this.SendPropertyChanging();
					this._BusRouteType = value;
					this.SendPropertyChanged("BusRouteType");
					this.OnBusRouteTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RouteName", DbType="NVarChar(30)")]
		public string RouteName
		{
			get
			{
				return this._RouteName;
			}
			set
			{
				if ((this._RouteName != value))
				{
					this.OnRouteNameChanging(value);
					this.SendPropertyChanging();
					this._RouteName = value;
					this.SendPropertyChanged("RouteName");
					this.OnRouteNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DepartureStopNameZh", DbType="NVarChar(30)")]
		public string DepartureStopNameZh
		{
			get
			{
				return this._DepartureStopNameZh;
			}
			set
			{
				if ((this._DepartureStopNameZh != value))
				{
					this.OnDepartureStopNameZhChanging(value);
					this.SendPropertyChanging();
					this._DepartureStopNameZh = value;
					this.SendPropertyChanged("DepartureStopNameZh");
					this.OnDepartureStopNameZhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DestinationStopNameZh", DbType="NVarChar(30)")]
		public string DestinationStopNameZh
		{
			get
			{
				return this._DestinationStopNameZh;
			}
			set
			{
				if ((this._DestinationStopNameZh != value))
				{
					this.OnDestinationStopNameZhChanging(value);
					this.SendPropertyChanging();
					this._DestinationStopNameZh = value;
					this.SendPropertyChanged("DestinationStopNameZh");
					this.OnDestinationStopNameZhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UpdateDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> UpdateDate
		{
			get
			{
				return this._UpdateDate;
			}
			set
			{
				if ((this._UpdateDate != value))
				{
					this.OnUpdateDateChanging(value);
					this.SendPropertyChanging();
					this._UpdateDate = value;
					this.SendPropertyChanged("UpdateDate");
					this.OnUpdateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UpdateTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> UpdateTime
		{
			get
			{
				return this._UpdateTime;
			}
			set
			{
				if ((this._UpdateTime != value))
				{
					this.OnUpdateTimeChanging(value);
					this.SendPropertyChanging();
					this._UpdateTime = value;
					this.SendPropertyChanged("UpdateTime");
					this.OnUpdateTimeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591