using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace DAL
{
    public class MasterDAL
    {
        public SqlConnection cn;

        public DataSet ExecutaDataSet(string comando, CommandType type, SqlParameter[] param)
        {
            cn.Open();
            using (TransactionScope tx = new TransactionScope())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = comando;
                    cmd.CommandType = type;
                    if(param != null)
                    {
                        foreach (var p in param)
                        {
                            if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                            {
                                p.Value = DBNull.Value;
                            }
                            cmd.Parameters.Add(p);
                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds);
                    tx.Complete();
                    cn.Close();
                    return ds;
                }
                catch (Exception ex)
                {
                    tx.Dispose();
                    cn.Close();
                    throw;
                }
            }
        }
    }
}
