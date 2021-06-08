using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tulpep.NotificationWindow;
using Color = System.Drawing.Color;

namespace Invert
{
    class Equip
    {
        public bool Add(string equip, string cabin)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Ошибка";
            popup.BodyColor = Color.LightGray;
            gr691_invert db = new gr691_invert();
            Equipment equipment = new Equipment();
            try
            {
                var last_id = db.Equipment.Max(f => f.id);
                if (equip == "")
                {
                    popup.ContentText = "Вы не выбрали оборудование";
                    popup.Popup();
                    return false;
                }
                else if (cabin == "")
                {
                    popup.ContentText = "Вы не выбрали кабинет";
                    popup.Popup();
                    return false;
                }
                switch (Convert.ToInt32(equip))
                {
                    case 0:
                        equipment.cabinet = cabin;
                        equipment.indef = "Монитор";
                        equipment.inv_num = cabin + "MN" + (last_id + 1);
                        db.Equipment.Add(equipment);
                        db.SaveChanges();
                        break;
                    case 1:
                        equipment.cabinet = cabin;
                        equipment.indef = "Стол";
                        equipment.inv_num = cabin + "DK" + (last_id + 1);
                        db.Equipment.Add(equipment);
                        db.SaveChanges();
                        break;
                    case 2:
                        equipment.cabinet = cabin;
                        equipment.indef = "Стул";
                        equipment.inv_num = cabin + "CR" + (last_id + 1);
                        db.Equipment.Add(equipment);
                        db.SaveChanges();
                        break;
                    case 3:
                        equipment.cabinet = cabin;
                        equipment.indef = "Компьютер";
                        equipment.inv_num = cabin + "PC" + (last_id + 1);
                        db.Equipment.Add(equipment);
                        db.SaveChanges();
                        break;
                }
            }
            catch
            {
                popup.ContentText = "ОШИБКА";
                popup.Popup();
                return false;
            }
            return true;
        }
        public bool Delete(string id)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Ошибка";
            popup.BodyColor = Color.LightGray;
            gr691_invert db = new gr691_invert();
            try
            {
                int num = Convert.ToInt32(id);
                var d_e = db.Equipment.Where(i => i.id == num).FirstOrDefault();
                if (d_e == null)
                {
                    popup.ContentText = "Вы не выбрали строку";
                    popup.Popup();
                    return false;
                }
                else
                {
                    db.Equipment.Remove(d_e);
                    db.SaveChanges();
                }
            }
            catch
            {
                popup.ContentText = "ОШИБКА";
                popup.Popup();
                return false;
            }
            return true;
        }
        public bool Update(string id, string equip, string cabin)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Ошибка";
            popup.BodyColor = Color.LightGray;
            gr691_invert db = new gr691_invert();
            try
            {
                int num = Convert.ToInt32(id);
                var u_e = db.Equipment.Where(u => u.id == num).FirstOrDefault();
                if (u_e == null)
                {
                    popup.ContentText = "Вы не выбрали строку";
                    popup.Popup();
                    return false;
                }
                else if (equip == "")
                {
                    popup.ContentText = "Вы не выбрали оборудование";
                    popup.Popup();
                    return false;
                }
                else if (cabin == "")
                {
                    popup.ContentText = "Вы не выбрали кабинет";
                    popup.Popup();
                    return false;
                }
                switch (Convert.ToInt32(equip))
                {
                    case 0:
                        u_e.cabinet = cabin;
                        u_e.indef = "Монитор";
                        u_e.inv_num = cabin + "MN" + num;
                        db.SaveChanges();
                        break;
                    case 1:
                        u_e.cabinet = cabin;
                        u_e.indef = "Стол";
                        u_e.inv_num = cabin + "DK" + num;
                        db.SaveChanges();
                        break;
                    case 2:
                        u_e.cabinet = cabin;
                        u_e.indef = "Стул";
                        u_e.inv_num = cabin + "CR" + num;
                        db.SaveChanges();
                        break;
                    case 3:
                        u_e.cabinet = cabin;
                        u_e.indef = "Компьютер";
                        u_e.inv_num = cabin + "PC" + num;
                        db.SaveChanges();
                        break;
                }
                db.SaveChanges();
            }
            catch
            {
                popup.ContentText = "ОШИБКА";
                popup.Popup();
                return false;
            }
            return true;
        }
    }
}
