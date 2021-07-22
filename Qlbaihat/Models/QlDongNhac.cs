using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Qlbaihat.Models
{
    public class QlDongNhac
    {
        [Display(Name = "STT")]
        public int IdDN { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên dòng nhạc")]
        [Display(Name = "Tên dòng nhạc")]
        public string TenDongNhac { get; set; }

        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
    }

    class DongNhacList
    {
        DBConnection db;
        public DongNhacList()
        {
            db = new DBConnection();
        }
        //lấy dữ liệu từ csdl

        public List<QlDongNhac> getDongNhac(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "SELECT * from DongNhac";
            }
            else
            {
                sql = "SELECT * from DongNhac where IdDN = " + ID;
            }
            List<QlDongNhac> strList = new List<QlDongNhac>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            con.Open();
            cmd.Fill(dt);

            cmd.Dispose();
            con.Close();

            QlDongNhac strNS;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strNS = new QlDongNhac();
                strNS.IdDN = Convert.ToInt32(dt.Rows[i]["IdDN"].ToString());
                strNS.TenDongNhac = dt.Rows[i]["TenDongNhac"].ToString();
                strNS.GhiChu = dt.Rows[i]["GhiChu"].ToString();

                strList.Add(strNS);
            }

            return strList;
        }
    }
}