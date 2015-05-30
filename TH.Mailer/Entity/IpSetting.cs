//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
	/// <summary>
	/// ��ȡIP����ʵ����
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	[Serializable]
	[EntityInfo("��ȡIP����")]
	public partial class IpSetting {
		/// <summary>
		/// ��ȡIP����
		/// </summary>
		public static readonly string _ = "IpSetting";

		/// <summary>
		/// ��ȡIP���ñ��
		/// </summary>
		public static readonly string _IPCID = "IPCID";
		private Int64? iPCID = null;
		/// <summary>
		/// ��ȡIP���ñ��
		/// </summary>
		[EntityInfo("��ȡIP���ñ��")]
		public new Int64? IPCID { get { return iPCID; } set { iPCID = value; } }

		/// <summary>
		/// ��ַ����
		/// </summary>
		public static readonly string _WebName = "WebName";
		private string webName = null;
		/// <summary>
		/// ��ַ����
		/// </summary>
		[EntityInfo("��ַ����")]
		public new string WebName { get { return webName; } set { webName = value; } }

		/// <summary>
		/// ��ȡIP����ַ
		/// </summary>
		public static readonly string _IPUrl = "IPUrl";
		private string iPUrl = null;
		/// <summary>
		/// ��ȡIP����ַ
		/// </summary>
		[EntityInfo("��ȡIP����ַ")]
		public new string IPUrl { get { return iPUrl; } set { iPUrl = value; } }

		/// <summary>
		/// ��ȡIP������
		/// </summary>
		public static readonly string _IPRegex = "IPRegex";
		private string iPRegex = null;
		/// <summary>
		/// ��ȡIP������
		/// </summary>
		[EntityInfo("��ȡIP������")]
		public new string IPRegex { get { return iPRegex; } set { iPRegex = value; } }

		/// <summary>
		/// ʹ�ñ���
		/// </summary>
		public static readonly string _DataEncode = "DataEncode";
		private string dataEncode = null;
		/// <summary>
		/// ʹ�ñ���
		/// </summary>
		[EntityInfo("ʹ�ñ���")]
		public new string DataEncode { get { return dataEncode; } set { dataEncode = value; } }
	}
}



