using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace Data.Database {

	public class Adapter {
		const string consKeyDefaultCnnString = "ConnStringLocal";
		public SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString);

		protected void OpenConnection() {
			sqlConn.Open();
		}

		protected void CloseConnection() {
			sqlConn.Close();
			sqlConn = null;
		}
	}
}
