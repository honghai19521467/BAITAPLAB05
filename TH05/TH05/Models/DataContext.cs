
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TH05.Models
{
    public class DataContext
    {
        public string ConnectionString { get; set; }

        public DataContext(string connectionstring)
        {
            ConnectionString = connectionstring;
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        public int taoCanHo(CanHo ch)
        {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO CANHO VALUES (@macanho,@tencanho); ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@macanho", ch.MaCanHo.ToString());
                    cmd.Parameters.AddWithValue("@tencanho", ch.TenCanHo.ToString());
                return (cmd.ExecuteNonQuery());
                    
                }
               
            }
        public List<Fixed> lietke(string solan)
        {
            List<Fixed> list = new List<Fixed>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"select NV.TENNHANVIEN, NV.SODT, LANTHU
                                from NV_BT, NHANVIEN NV
                                where NV_BT.MANHANVIEN = NV.MANHANVIEN
	                            AND LanThu >= @lanthu;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@lanthu", int.Parse(solan));
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Fixed()
                        {
                            TenNhanVien = reader["tennhanvien"].ToString(),
                            SoDT = reader["sodt"]?.ToString(),
                            LanThu = int.Parse(reader["lanthu"].ToString()),
                        });

                    }
                }
            }
            return list;
        }

        public List<NhanVien> layNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from NhanVien;";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanVien()
                        {
                            MaNhanVien = reader["manhanvien"]?.ToString(),
                            TenNhanVien = reader["tennhanvien"]?.ToString(),
                            SoDT = reader["sodt"]?.ToString(),
                            GioiTinh = reader["gioitinh"]?.ToString(),
                        });

                    }
                }
            }
            return list;
        }

        public List<NV_BT> layNVBT(string manv)
        {
            List<NV_BT> list = new List<NV_BT>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from NV_BT where manhanvien = @manhanvien;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@manhanvien", manv);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NV_BT()
                        {
                            MaNhanVien = reader["manhanvien"]?.ToString(),
                            MaThietBi = reader["mathietbi"]?.ToString(),
                            MaCanHo = reader["macanho"]?.ToString(),
                            LanThu = int.Parse(reader["lanthu"]?.ToString()),
                            NgayBaoTri = (DateTime)reader["ngaybaotri"],
                        });

                    }
                }
            }
            return list;
        }

       
        public int xoaNVBT(string MaThietBi, string MaCanHo, string MaNhanVien, int LanThu)
        {

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"delete from NV_BT where manhanvien = @manhanvien 
                                                         and macanho = @macanho
                                                        and mathietbi = @mathietbi
                                                        and lanthu = @lanthu;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("manhanvien", MaNhanVien);
                cmd.Parameters.AddWithValue("macanho", MaNhanVien);
                cmd.Parameters.AddWithValue("mathietbi", MaThietBi);
                cmd.Parameters.AddWithValue("lanthu", LanThu);
                return(cmd.ExecuteNonQuery());
            }
           
        }
        public int capNhatNVBT(NV_BT nv)
        {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                string query = @"UPDATE NV_BT
                                    SET
                                    NGAYBAOTRI = @NGAYBAOTRI
                                    where manhanvien = @manhanvien 
                                                         and macanho = @macanho
                                                        and mathietbi = @mathietbi
                                                        and lanthu = @lanthu;" ;

                    SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("manhanvien", nv.MaNhanVien);
                cmd.Parameters.AddWithValue("macanho", nv.MaCanHo);
                cmd.Parameters.AddWithValue("mathietbi", nv.MaThietBi);
                cmd.Parameters.AddWithValue("lanthu", nv.LanThu);
                cmd.Parameters.AddWithValue("ngaybaotri", nv.NgayBaoTri);
                    return(cmd.ExecuteNonQuery());
                  
                }
            }
        }

    }


