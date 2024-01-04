using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace Quanlychitieu
{
    class xuly
    {
        string strcon;
        SqlConnection conn;

        public bool Isint(string so)
        {
            foreach (char c in so)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public bool ketnoi()
        {
            try
            {
                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool ktdangnhap(string username, string pass)
        {

            string sql = "select * from Dangnhap where Username='" + username + "' and Pass='" + pass + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                return true;
            }
            else
                return false;

        }

        public string catchuoi(string chuoi)
        {
            string tam = "";
            string str = chuoi;
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 && str[i + 1].ToString() != " ")
                {
                    if (str[i].ToString() == "Ă" || str[i].ToString() == "ă")
                    {
                        tam += "A";
                    }
                    else
                    {
                            tam += str.Substring(0, 1);
                    }
                }
                else
                {
                    if (str[i].ToString() == " " && str[i + 1].ToString() != " ")
                    {
                        tam += str.Substring(i + 1, 1);
                    }
                }
            }
            return tam.ToUpper();
        }

        public bool ktdl(string ma)
        {
            try
            {
                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select MaND from Nguoidung where MaND='" + ma + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        public bool ktdlmatn(string ma)
        {
            try
            {
                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select MaTN from Thunhap where MaTN='" + ma + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        public bool ktdlmachitieu(string ma)
        {
            try
            {
                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select MaTTCT from Thongtinchitieu where MaTTCT='" + ma + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        public bool themnguoidung(string mand, string tk, string ht, string ns, string gt)
        {
            try
            {
                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Nguoidung";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter1.Fill(ds, "Nguoidung");
                DataTable dt = ds.Tables["Nguoidung"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter1);
                DataRow row1 = dt.NewRow();
                row1["MaND"] = mand;
                row1["Username"] = tk;
                row1["Hoten"] = ht;
                row1["Namsinh"] = ns;
                row1["Gioitinh"] = gt;
                dt.Rows.Add(row1);
                int them = adapter1.Update(ds, "Nguoidung");
                if (them > 0)
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool themtk(string tk, string mk, string mknl)
        {

            try
            {
                //string sql = "insert into Dangnhap Values ('"+tk+"','"+mk+"')";
                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                if (mk == mknl)
                {
                    string sql = "select * from Dangnhap";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Dangnhap");
                    DataTable dt = ds.Tables["Dangnhap"];
                    SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                    DataRow row = dt.NewRow();
                    row["Username"] = tk;
                    row["Pass"] = mk;
                    dt.Rows.Add(row);
                    int them = adapter.Update(ds, "Dangnhap");
                    if (them > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool thaydoimk(string tk, string mk, string mknhaplai)
        {
            try
            {
                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                if (mknhaplai == mk)
                {
                    string sql = "select * from Dangnhap";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Dangnhap");
                    DataTable dt = ds.Tables["Dangnhap"];
                    SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        string tam = row["Username"].ToString();
                        if (tam == tk)
                        {
                            // dt.Rows[i].Delete();
                            //DataRow row1 = dt.NewRow();
                            //row1["Username"] = tk;
                            row["Pass"] = mk;
                            //dt.Rows.Add(row1);
                        }
                    }
                    int sua = adapter.Update(ds, "Dangnhap");
                    if (sua > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false; ;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool themndthu(string mandt, string tenndt)
        {
            try
            {
                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                if (mandt != "")
                {
                    string sql = "select * from Noidungthunhap";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Noidungthunhap");
                    DataTable dt = ds.Tables["Noidungthunhap"];
                    SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                    DataRow row = dt.NewRow();
                    row["MaNDTN"] = mandt.ToUpper();
                    row["TenNDTN"] = tenndt;
                    dt.Rows.Add(row);
                    int them = adapter.Update(ds, "Noidungthunhap");
                    if (them > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool themndchi(string mandchi, string tenndchi)
        {
            try
            {

                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                if (mandchi != "")
                {
                    string sql = "select * from Noidungchitieu";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Noidungchitieu");
                    DataTable dt = ds.Tables["Noidungchitieu"];
                    SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                    DataRow row = dt.NewRow();
                    row["MaNDCT"] = mandchi.ToUpper();
                    row["TenNDCT"] = tenndchi;
                    dt.Rows.Add(row);
                    int them = adapter.Update(ds, "Noidungchitieu");
                    if (them > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        public bool themkhoanthu(string mandtn, string matn, string taikhoan, string sotien, string ngay, string ghichu)
        {
            try
            {

                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                string sql1 = "select * from Thunhap";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql1, conn);
                DataSet ds2 = new DataSet();
                adapter2.Fill(ds2, "Thunhap");
                DataTable dt2 = ds2.Tables["Thunhap"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter2);
                DataRow row = dt2.NewRow();
                row["MaTN"] = matn;
                row["MaNDTN"] = mandtn;
                row["MaND"] = taikhoan;
                row["Sotien"] = int.Parse(sotien);
                row["Ngay"] = ngay;
                row["Ghichu"] = ghichu;
                dt2.Rows.Add(row);
                int themtn = adapter2.Update(ds2, "Thunhap");
                if (themtn > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool themkchitieu(string mandchi, string machi, string taikhoan, string sotien, string ngay, string ghichu)
        {
            try
            {

                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                string sql1 = "select * from Thongtinchitieu";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql1, conn);
                DataSet ds2 = new DataSet();
                adapter2.Fill(ds2, "Thongtinchitieu");
                DataTable dt2 = ds2.Tables["Thongtinchitieu"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter2);
                DataRow row = dt2.NewRow();
                row["MaTTCT"] = machi;
                row["MaNDCT"] = mandchi;
                row["MaND"] = taikhoan;
                row["Ngay"] = ngay;
                row["Sotien"] = int.Parse(sotien);
                row["Ghichu"] = ghichu;
                dt2.Rows.Add(row);
                int themtn = adapter2.Update(ds2, "Thongtinchitieu");
                if (themtn > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public string manguoidung(string tk)
        {
            string ma;
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql1 = "select MaND from Nguoidung where Username='" + tk + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader rd1 = cmd1.ExecuteReader();
            if (rd1.Read())
            {

                ma = rd1.GetString(0);
                ma = (string)rd1.GetSqlString(0);
                ma = (string)rd1.GetValue(0);
                ma = (string)rd1["MaND"];
                ma = (string)rd1[0];
                return ma;
            }
            else
            {
                ma = "";
                return ma;
            }
        }

        public bool suakhoanthu(string manguoidung, string mathunhap, string mandthunhap, string sotien, string ngay, string ghichu)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Thunhap where MaND='" + manguoidung + "'and MaNDTN='" + mandthunhap + "' and MaTN='" + mathunhap + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Thunhap");
                DataTable dt = ds.Tables["Thunhap"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string tam = dr["MaTN"].ToString();
                    if (tam == mathunhap)
                    {
                        dr["Sotien"] = int.Parse(sotien);
                        dr["Ngay"] = ngay;
                        dr["Ghichu"] = ghichu;
                    }
                }

                int sua = adapter.Update(ds, "Thunhap");
                if (sua > 0)
                {
                    return true;
                }
                else
                {
                    return false; ;
                }

            }
            catch
            {
                return false;
            }
        }


        public bool suakhoanchi(string manguoidung, string machitieu, string mandchitieu, string sotien, string ngay, string ghichu)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Thongtinchitieu where MaND='" + manguoidung + "'and MaNDCT='" + mandchitieu + "' and MaTTCT='" + machitieu + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Thongtinchitieu");
                DataTable dt = ds.Tables["Thongtinchitieu"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string tam = dr["MaTTCT"].ToString();
                    if (tam == machitieu)
                    {
                        dr["Sotien"] = int.Parse(sotien);
                        dr["Ngay"] = ngay;
                        dr["Ghichu"] = ghichu;
                    }
                }

                int sua = adapter.Update(ds, "Thongtinchitieu");
                if (sua > 0)
                {
                    return true;
                }
                else
                {
                    return false; ;
                }

            }
            catch
            {
                return false;
            }
        }


        public bool xoakhoanthu(string manguoidung, string mathunhap, string mandthunhap)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Thunhap where MaND='" + manguoidung + "'and MaNDTN='" + mandthunhap + "' and MaTN='" + mathunhap + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Thunhap");
                DataTable dt = ds.Tables["Thunhap"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string tam = dr["MaTN"].ToString();
                    if (tam == mathunhap)
                    {
                        dt.Rows[i].Delete();
                    }
                }

                int xoa = adapter.Update(ds, "Thunhap");
                if (xoa > 0)
                {
                    return true;
                }
                else
                {
                    return false; ;
                }

            }
            catch
            {
                return false;
            }
        }


        public bool xoakhoanchi(string manguoidung, string machi, string mandchi)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Thongtinchitieu where MaND='" + manguoidung + "'and MaNDCT='" + mandchi + "' and MaTTCT='" + machi + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Thongtinchitieu");
                DataTable dt = ds.Tables["Thongtinchitieu"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string tam = dr["MaTTCT"].ToString();
                    if (tam == machi)
                    {
                        dt.Rows[i].Delete();
                    }
                }

                int xoa = adapter.Update(ds, "Thongtinchitieu");
                if (xoa > 0)
                {
                    return true;
                }
                else
                {
                    return false; ;
                }

            }
            catch
            {
                return false;
            }
        }


        public bool xoatk(string tk)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Dangnhap where Username='" + tk + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Dangnhap");
                DataTable dt = ds.Tables["Dangnhap"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string tam = dr["Username"].ToString();
                    if (tam == tk)
                    {
                        dt.Rows[i].Delete();
                    }
                }

                int xoa = adapter.Update(ds, "Dangnhap");
                if (xoa > 0)
                {
                    return true;
                }
                else
                {
                    return false; ;
                }

            }
            catch
            {
                return false;
            }
        }

        public bool xoand(string mand)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Nguoidung where MaND='" + mand + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Nguoidung");
                DataTable dt = ds.Tables["Nguoidung"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string tam = dr["MaND"].ToString();
                    if (tam == mand)
                    {
                        dt.Rows[i].Delete();
                    }
                }

                int xoa = adapter.Update(ds, "Nguoidung");
                if (xoa > 0)
                {
                    return true;
                }
                else
                {
                    return false; ;
                }

            }
            catch
            {
                return false;
            }
        }

        public bool xoandthu(string mand)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Noidungthunhap where MaNDTN='" + mand + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Noidungthunhap");
                DataTable dt = ds.Tables["Noidungthunhap"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string tam = dr["MaNDTN"].ToString();
                    if (tam == mand)
                    {
                        dt.Rows[i].Delete();
                    }
                }

                int xoa = adapter.Update(ds, "Noidungthunhap");
                if (xoa > 0)
                {
                    return true;
                }
                else
                {
                    return false; ;
                }

            }
            catch
            {
                return false;
            }
        }

        public bool xoandchi(string mand)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Noidungchitieu where MaNDCT='" + mand + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Noidungchitieu");
                DataTable dt = ds.Tables["Noidungchitieu"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string tam = dr["MaNDCT"].ToString();
                    if (tam == mand)
                    {
                        dt.Rows[i].Delete();
                    }
                }

                int xoa = adapter.Update(ds, "Noidungchitieu");
                if (xoa > 0)
                {
                    return true;
                }
                else
                {
                    return false; ;
                }

            }
            catch
            {
                return false;
            }
        }

        public bool themndlichmau(string MaNDlich, string ngaybd, string ngaykt)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Noidunglich";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Noidunglich");
                DataTable dt = ds.Tables["Noidunglich"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                DataRow row = dt.NewRow();
                row["MaNDLich"] = MaNDlich;
                row["Tenlich"] = "Lịch chi tiêu mẫu";
                row["NgayBD"] = ngaybd;
                row["NgayKT"] = ngaykt;
                dt.Rows.Add(row);
                int them = adapter.Update(ds, "Noidunglich");
                if (them > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool themlichmau(string malich, string mand, string mandlich, string tenkhoanchi, string sotien)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Lichchitieu";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Lichchitieu");
                DataTable dt = ds.Tables["Lichchitieu"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                DataRow row = dt.NewRow();
                row["Malich"] = malich;
                row["MaND"] = mand;
                row["MaNDLich"] = mandlich;
                row["Tenkhoanchi"] = tenkhoanchi;
                row["Sotien"] = sotien;
                dt.Rows.Add(row);
                int them = adapter.Update(ds, "Lichchitieu");
                if (them > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ktmandlich(string ma)
        {
            try
            {
                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Noidunglich where MaNDLich='" + ma + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ktmalichchitieu(string ma)
        {
            try
            {
                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Lichchitieu where Malich='" + ma + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        public bool themnoidunglich(string malich, string tenlich, string ngaybd, string ngaykt)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Noidunglich";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Noidunglich");
                DataTable dt = ds.Tables["Noidunglich"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                DataRow row = dt.NewRow();
                row["MaNDLich"] = malich;
                row["Tenlich"] = tenlich;
                row["NgayBD"] = ngaybd;
                row["NgayKT"] = ngaykt;
                dt.Rows.Add(row);
                int them = adapter.Update(ds, "Noidunglich");
                if (them > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool themlich(string malich, string mand, string mandlich, string tenkhoanchi, string sotien)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Lichchitieu";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Lichchitieu");
                DataTable dt = ds.Tables["Lichchitieu"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                DataRow row = dt.NewRow();
                row["Malich"] = malich;
                row["MaND"] = mand;
                row["MaNDLich"] = mandlich;
                row["Tenkhoanchi"] = tenkhoanchi;
                row["Sotien"] = sotien;
                dt.Rows.Add(row);
                int them = adapter.Update(ds, "Lichchitieu");
                if (them > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ktmalich(string ma)
        {
            try
            {
                strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select Malich from Lichchitieu where Malich='" + ma + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        public bool xoalich(string mandlich)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select * from Noidunglich where MaNDLich='" + mandlich + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Noidunglich");
                DataTable dt = ds.Tables["Noidunglich"];
                SqlCommandBuilder cmbd = new SqlCommandBuilder(adapter);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string tam = dr["MaNDLich"].ToString();
                    if (tam == mandlich)
                    {
                        dt.Rows[i].Delete();
                    }
                }

                int xoa = adapter.Update(ds, "Noidunglich");
                if (xoa > 0)
                {
                    return true;
                }
                else
                {
                    return false; ;
                }

            }
            catch
            {
                return false;
            }
        }
    }
}
