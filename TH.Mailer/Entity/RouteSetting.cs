//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
	/// <summary>
	/// ·��ʵ����
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	[Serializable]
	[EntityInfo("·��")]
	public partial class RouteSetting {
		/// <summary>
		/// ·��
		/// </summary>
		public static readonly string _ = "RouteSetting";

		/// <summary>
		/// ·�ɱ��
		/// </summary>
		public static readonly string _RouteID = "RouteID";
		private int? routeID = null;
		/// <summary>
		/// ·�ɱ��
		/// </summary>
		[EntityInfo("·�ɱ��")]
		public new int? RouteID { get { return routeID; } set { routeID = value; } }

		/// <summary>
		/// ·�ɵ�ַ
		/// </summary>
		public static readonly string _RouteIP = "RouteIP";
		private string routeIP = null;
		/// <summary>
		/// ·�ɵ�ַ
		/// </summary>
		[EntityInfo("·�ɵ�ַ")]
		public new string RouteIP { get { return routeIP; } set { routeIP = value; } }

		/// <summary>
		/// ��¼�˺�
		/// </summary>
		public static readonly string _UserName = "UserName";
		private string userName = null;
		/// <summary>
		/// ��¼�˺�
		/// </summary>
		[EntityInfo("��¼�˺�")]
		public new string UserName { get { return userName; } set { userName = value; } }

		/// <summary>
		/// ��¼����
		/// </summary>
		public static readonly string _RPassword = "RPassword";
		private string rPassword = null;
		/// <summary>
		/// ��¼����
		/// </summary>
		[EntityInfo("��¼����")]
		public new string RPassword { get { return rPassword; } set { rPassword = value; } }

		/// <summary>
		/// ���Ӳ���
		/// </summary>
		public static readonly string _RouteConnect = "RouteConnect";
		private string routeConnect = null;
		/// <summary>
		/// ���Ӳ���
		/// </summary>
		[EntityInfo("���Ӳ���")]
		public new string RouteConnect { get { return routeConnect; } set { routeConnect = value; } }

		/// <summary>
		/// �Ͽ����Ӳ���
		/// </summary>
		public static readonly string _RouteDisConnect = "RouteDisConnect";
		private string routeDisConnect = null;
		/// <summary>
		/// �Ͽ����Ӳ���
		/// </summary>
		[EntityInfo("�Ͽ����Ӳ���")]
		public new string RouteDisConnect { get { return routeDisConnect; } set { routeDisConnect = value; } }

		/// <summary>
		/// ����ʽ POST GET
		/// </summary>
		public static readonly string _RouteMethod = "RouteMethod";
		private string routeMethod = null;
		/// <summary>
		/// ����ʽ POST GET
		/// </summary>
		[EntityInfo("����ʽ POST GET")]
		public new string RouteMethod { get { return routeMethod; } set { routeMethod = value; } }
	}
}



