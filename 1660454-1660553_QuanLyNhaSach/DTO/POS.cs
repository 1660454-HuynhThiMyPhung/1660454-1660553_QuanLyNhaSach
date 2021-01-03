using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1660454_1660553_QuanLyNhaSach.DTO
{
    class POS
    {
        public POS(int id, Byte[] avatar, string id_items, string name, int Quanliti, int price)
        {
            this.ID = id;
            this.avatar = avatar;
            this.id_items = id_items;
            this.name = name;
            this.quanliti = Quanliti;
            this.price = price;
        }

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string id_item;
        public string id_items
        {
            get { return id_item; }
            set { id_item = value; }
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


        private Byte[] avatars;
        public Byte[] avatar
        {
            get { return avatars; }
            set { avatars = value; }
        }
        private int quanliti;
        public int Quanliti
        {
            get { return quanliti; }
            set { quanliti = value; }
        }
    }
}
