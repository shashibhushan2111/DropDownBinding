using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DropDownBinding.DAL
{
    public class DataAccessLayer
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public DataSet Get_Country()
        {
            SqlCommand cmd = new SqlCommand("Select * From tblCountry",con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
        public DataSet Get_State(string country_id)
        {
            SqlCommand cmd = new SqlCommand("Select * From tblState where CountryID = @catid", con);
            cmd.Parameters.AddWithValue("@catid",country_id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }

        public DataSet Get_City(string state_id)
        {
            SqlCommand cmd = new SqlCommand("Select * From tblCity where StateID = @stateid", con);
            cmd.Parameters.AddWithValue("@stateid", state_id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
    }
}