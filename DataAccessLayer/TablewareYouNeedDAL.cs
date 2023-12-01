using EntityModel;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class TablewareYouNeedDAL
    {
        const string connectionString = @"Server=.;Database=TablewareYouNeed;Trusted_Connection=True;";
        SqlConnection sqlcon;
        SqlParameter param;
        SqlDataReader dr;

        public List<TablewareYouNeedEntity> GetProducts()
        {
            // db call sp
            // db data to c# entity
            // return list c# entity

            TablewareYouNeedEntity entity = null;
            List<TablewareYouNeedEntity> lstEntity = new List<TablewareYouNeedEntity>();

            try
            {
                using (sqlcon = new SqlConnection(connectionString))
                {
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("sp_GetProducts", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    sqlcon.Open();

                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            entity = new TablewareYouNeedEntity();

                            entity.ID = Convert.ToInt32(dr["ID"].ToString());
                            entity.Quentity = Convert.ToInt32(dr["Quentity"].ToString());
                            entity.ProductName = string.IsNullOrEmpty(dr["ProductName"].ToString()) ? "" : (dr["ProductName"].ToString());

                            lstEntity.Add(entity);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                    sqlcon?.Close();
                }
            }

            return lstEntity;
        }
        public void InsertACCustomerService(TablewareYouNeedEntity entity)
        {


            try
            {
                using (sqlcon = new SqlConnection(connectionString))
                {
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("dbo.Insert_ACCustomer", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    param = new SqlParameter("Quentity", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = entity.Quentity;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("ProductName", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = entity.ProductName;
                    cmd.Parameters.Add(param);



                    sqlcon.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                    sqlcon?.Close();
                }
            }
        }
    }
}