using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Qlbaihat.Models
{
    public class QlNhacSy
    {
        [Display(Name = "STT")]
        public int IdNS { get; set; }
           
        [Required(ErrorMessage ="Bạn cần nhập tên nhạc sỹ")]
        [Display(Name = "Tên nhạc sỹ")]
        public string TenNhacSy { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tuổi")]
        [Display(Name = "Tuổi")]
        public int Tuoi { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập giới tính")]
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập quê quán")]
        [Display(Name = "Quê quán")]
        public string QueQuan { get; set; }
    }

    class NhacSyList
    {
        DBConnection db;
        public NhacSyList()
        {
            db = new DBConnection();
        }
        //lấy dữ liệu từ csdl

        public List<QlNhacSy> getNhacSy(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "SELECT * from NhacSy";
            }
            else
            {
                sql = "SELECT * from NhacSy where IdNS = " + ID;
            }
            List<QlNhacSy> strList = new List<QlNhacSy>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            con.Open();
            cmd.Fill(dt);

            cmd.Dispose();
            con.Close();

            QlNhacSy strNS;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                strNS = new QlNhacSy();
                strNS.IdNS = Convert.ToInt32(dt.Rows[i]["IdNS"].ToString());
                strNS.TenNhacSy = dt.Rows[i]["TenNhacSy"].ToString();
                strNS.Tuoi = Convert.ToInt32(dt.Rows[i]["Tuoi"].ToString());
                strNS.GioiTinh = dt.Rows[i]["GioiTinh"].ToString(); 
                strNS.QueQuan = dt.Rows[i]["QueQuan"].ToString();

                strList.Add(strNS);
            }

            return strList;
        }
    }
}