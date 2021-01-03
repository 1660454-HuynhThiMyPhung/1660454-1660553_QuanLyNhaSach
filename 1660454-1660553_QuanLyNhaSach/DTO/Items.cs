using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1660454_1660553_QuanLyNhaSach.DTO
{
    class Items
    {
        public Items(string id, string name, int price, string image, string note, string Ma_DM, string NgayTao, Byte[] avatar, int Stock, int Stockmini)
        {
            this.ID = id;
            this.name = name;
            this.price = price;
            this.avatar = avatar;
            this.image = image;
            this.note = note;
            this.Ma_DM = Ma_DM;
            this.NgayTao = NgayTao;
            this.stock = Stock;
            this.stockmini = Stockmini;

        }
        public Items(DataRow row)
        {
            this.ID = row["Ma_SP"].ToString().Trim();
            this.name = row["Ten_SP"].ToString().Trim();
            this.price = (int)row["Price"];
            this.image = row["Image"].ToString().Trim();
            this.avatar = (Byte[])row["avatar"];
            this.note = row["Note"].ToString().Trim();
            this.Ma_DM = row["Ma_DM"].ToString().Trim();
            this.NgayTao = row["NgayTao"].ToString().Trim();
            this.stock = (int)row["stock"];
            this.stockmini = (int)row["stock_mini"];
        }


        private string id;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        private string names;
        public string name
        {
            get { return names; }
            set { names = value; }
        }

        private int prices;
        public int price
        {
            get { return prices; }
            set { prices = value; }
        }

        private string images;
        public string image
        {
            get { return images; }
            set { images = value; }
        }

        private Byte[] avatars;
        public Byte[] avatar
        {
            get { return avatars; }
            set { avatars = value; }
        }


        private string Ma_DMs;
        public string Ma_DM
        {
            get { return Ma_DMs; }
            set { Ma_DMs = value; }
        }
        private int stocks;
        public int stock
        {
            get { return stocks; }
            set { stocks = value; }
        }
        private int stockminis;
        public int stockmini
        {
            get { return stockminis; }
            set { stockminis = value; }
        }
        private string NgayTaos;
        public string NgayTao
        {
            get { return NgayTaos; }
            set { NgayTaos = value; }
        }
        private string notes;
        public string note
        {
            get { return notes; }
            set { notes = value; }
        }
    }
}
