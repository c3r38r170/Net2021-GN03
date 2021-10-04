using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace Data.Database {

	public class Adapter {
		const string consKeyDefaultCnnString = "Data Source = LAPTOP - CHEHT879\\SQLEXPRESS;Initial Catalog = tp2_net; Integrated Security = true;";
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
