using _1660454_1660553_QuanLyNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1660454_1660553_QuanLyNhaSach.DAO
{
    class CategoryDAO
    {

        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "select * from Danh_Muc";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;
        }

        public Category GetCategoryByID(string id)
        {
            Category category = null;

            string query = "select * from Danh_Muc where Ma_DM LIKE '%" + id + "%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }

            return category;
        }
        public bool UpdateCategory(string id, string name)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE Danh_Muc set Ten_DM = N'" + name + "' where Ma_DM = '" + id + "'");
            return result > 0;
        }
        public bool InsertCategory(string name)
        {
            string id = CategoryDAO.Instance.Getprefix();
            string query = string.Format("INSERT into Danh_Muc values ('" + id + "',N'" + name + "')");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCategory(string id)
        {
            string query = string.Format("Delete Danh_Muc where Ma_DM = '" + id + "'");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool TestDM(string id)
        {
            string querys = "select * from San_Pham where Ma_DM = '" + id + "'";
            DataTable datas = DataProvider.Instance.ExecuteQuery(querys);
            if (datas.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public string Getprefix()
        {
            string query = "select * from Danh_Muc";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string g = "";

            if ((data.Rows.Count <= 0))
            {
                return "DM01";
            }
            else
            {
                int k;
                g = "DM";
                k = Convert.ToInt32(data.Rows[data.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k <= 9)
                {
                    g = g + "0";
                    g = g + k.ToString();
                }
                else
                {
                    g = g + k.ToString();
                }
                return g;
            }
        }
    }
}
