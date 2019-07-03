using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace MobileBrowser
{
    /// <summary>
    /// Класс, загружающий список с открытыми сайтами в TableView
    /// </summary>
    public class TableSource : UITableViewSource
    {
        public delegate void MethodContainer(string url, int index);
        public event MethodContainer onClick;

        private List<ItemListView> list;

        public TableSource() { }

        public TableSource(List<ItemListView> list)
        {
            this.list = list;
        }

        /// <summary>
        /// Создает ячейку
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        /// <returns></returns>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            string item = list[indexPath.Row].Value;
            cell.TextLabel.Text = item;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return list.Count;
        }

        /// <summary>
        /// Вызывается при нажатии на элемент и генерирует событие
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            string item = list[indexPath.Row].Value;
            onClick(item,indexPath.Row);
        }

    }
}