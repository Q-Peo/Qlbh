using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Qlbaihat.Models
{
    public class QlBaiHat_Model
    {
        [Display(Name = "STT")]
        public int IdBH { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên bài hát")]
        [Display(Name = "Tên bài hát")]
        public string TenBaiHat { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên nhạc sỹ")]
        [Display(Name = "Tên nhạc sỹ")]
        public string TenNhacSy { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập dòng nhạc")]
        [Display(Name = "Tên dòng nhạc")]
        public string TenDongNhac { get; set; }

        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
    }

    class BaiHatList
    {
        DBConnection db;
        public BaiHatList()
        {
            db = new DBConnection();
        }
        //lấy dữ liệu từ csdl

        public List<QlBaiHat_Model> getBaiHat(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "select BaiHat.IdBH,TenBaiHat,NhacSy.TenNhacSy,DongNhac.TenDongNhac,BaiHat.GhiChu from BaiHat,NhacSy,DongNhac where BaiHat.IdDN = DongNhac.IdDN and BaiHat.IdNS = NhacSy.IdNS";
            }
            else
            {
                sql = "select BaiHat.IdBH,TenBaiHat,NhacSy.TenNhacSy,DongNhac.TenDongNhac,BaiHat.GhiChu from BaiHat,NhacSy,DongNhac where BaiHat.IdDN = DongNhac.IdDN and BaiHat.IdNS = NhacSy.IdNS and IdBH = " + ID;
            }
            List<QlBaiHat_Model> strList = new List<QlBaiHat_Model>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            con.Open();
            cmd.Fill(dt);

            cmd.Dispose();
            con.Close();

            QlBaiHat_Model strBH;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strBH = new QlBaiHat_Model();
                strBH.IdBH = Convert.ToInt32(dt.Rows[i]["IdBH"].ToString());
                strBH.TenBaiHat = dt.Rows[i]["TenBaiHat"].ToString();
                strBH.TenNhacSy = dt.Rows[i]["TenNhacSy"].ToString();
                strBH.TenDongNhac = dt.Rows[i]["TenDongNhac"].ToString();
                strBH.GhiChu = dt.Rows[i]["GhiChu"].ToString();
  
                strList.Add(strBH);
            }

            return strList;
        }
    }
}