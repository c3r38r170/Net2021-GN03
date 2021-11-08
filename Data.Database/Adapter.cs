using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace Data.Database {

	public class Adapter {
		public SqlConnection sqlConn = Adapter.NewSqlConn();

		protected void OpenConnection() {
			if (sqlConn == null)
				sqlConn = Adapter.NewSqlConn();
			sqlConn.Open();
		}

		protected void CloseConnection() {
			sqlConn.Close();
			sqlConn = null;
		}

		private static SqlConnection NewSqlConn() {
			return new SqlConnection("Data Source=LAPTOP-CHEHT879\\SQLEXPRESS;Initial Catalog=tp2_net;Integrated Security=true;");
		}
	}
}
