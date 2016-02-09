using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace LayeredApplication.DataLayer.Infrastructure
{
    public class SqlHandler
    {
        private string CONN { get; set; }

        public SqlHandler(string conn)
        {
            CONN = conn;
        }

        private SqlConnection _sqlConnection;
        public SqlConnection Connection
        {
            get
            {
                if (_sqlConnection == null)
                    _sqlConnection = new SqlConnection(CONN);

                return _sqlConnection;
            }
        }

        public bool EnsureOpenConnection()
        {
            try
            {
                var con = Connection;
                if (con.State == System.Data.ConnectionState.Closed || con.State == System.Data.ConnectionState.Broken)
                    con.Open();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable Get(string tableName, params SqlParameter[] parameters)
        {
            try
            {
                if (!EnsureOpenConnection())
                {
                    throw new InvalidExpressionException("could not open database");
                }

                string value = string.Empty;

                string query = String.Format("select * from {0}", tableName);

                SqlCommand cmd = new SqlCommand(query, Connection);

                if (parameters.Any())
                {
                    var parameterList = parameters.Select(x => String.Format("{0}={1}", x.ParameterName.Replace("@", ""), x.ParameterName)).ToList();
                    value = String.Join(" and ", parameterList);
                    query = string.Format("{0} where {1}", query, value);

                    cmd.Parameters.AddRange(parameters);
                }

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataTable tbl = new DataTable();

                adp.Fill(tbl);

                Connection.Close();

                return tbl;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public int Add(string table, List<SqlParameter> parameters)
        {
            try
            {
                if (!EnsureOpenConnection())
                {
                    throw new InvalidExpressionException("could not open database");
                }


                var colList = parameters.Select(x => string.Format("[{0}]", x.ParameterName)).ToList();
                var valueList = parameters.Select(x => string.Format("@{0}", x.ParameterName)).ToList();

                string columns = string.Join(",", colList);
                string values = string.Join(",", valueList);

                string query = string.Format("Insert into {0}({1}) OUTPUT INSERTED.ID values({2})", table, columns, values);

                SqlCommand cmd = new SqlCommand(query, Connection);

                //add parameters
                cmd.Parameters.AddRange(parameters.ToArray());

                int id = (int)cmd.ExecuteScalar();

                Connection.Close();

                return id;
            }
            catch (Exception ex)
            {
                //throw the exception for now
                //TODO:temp-log
                return 0;
            }
        }

        public bool Update(string table, List<SqlParameter> parameters, int id)
        {
            try
            {
                if (!EnsureOpenConnection())
                {
                    throw new InvalidExpressionException("could not open database");
                }


                var colList = parameters.Select(x => string.Format("[{0}]={1}", x.ParameterName, "@" + x.ParameterName)).ToList();

                string columns = string.Join(" , ", colList);

                string query = string.Format("Update {0} SET {1}", table, columns);

                query = string.Format("{0} where id = {1}", query, id);

                SqlCommand cmd = new SqlCommand(query, Connection);

                //add parameters
                cmd.Parameters.AddRange(parameters.ToArray());

                cmd.ExecuteNonQuery();

                Connection.Close();

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Remove(string table, List<SqlParameter> parameters)
        {
            try
            {
                if (!EnsureOpenConnection())
                {
                    throw new InvalidExpressionException("could not open database");
                }

                if (parameters == null || !parameters.Any())//no where condition specifed..return
                {
                    return false;
                }

                var whereCondition = parameters.Select(x => string.Format("{0}=@{1}", x.ParameterName, x.ParameterName)).ToList();

                string values = string.Join(" and ", whereCondition);

                string query = string.Format("Delete From {0} where {1}", table, values);

                SqlCommand cmd = new SqlCommand(query, Connection);

                //add parameters
                cmd.Parameters.AddRange(parameters.ToArray());

                cmd.ExecuteNonQuery();

                Connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                //throw the exception for now
                //TODO:temp-log
                return false;
            }
        }

        public bool RemoveAll(string table)
        {
            try
            {
                if (!EnsureOpenConnection())
                {
                    throw new InvalidExpressionException("could not open database");
                }

                string query = string.Format("Delete From {0}", table);

                SqlCommand cmd = new SqlCommand(query, Connection);

                cmd.ExecuteNonQuery();

                Connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                //throw the exception for now
                //TODO:temp-log
                return false;
            }
        }
    }
}
