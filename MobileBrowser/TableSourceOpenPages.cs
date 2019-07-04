using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace MobileBrowser
{
    /// <summary>
    /// Класс, загружающий список с сайтами и директориями в TableView
    /// </summary>
    public class TableSourceOpenPages : UITableViewSource
    {
        // делегат и событие клика на элемент списка
        public delegate void MethodContainer(string url, int index);
        public event MethodContainer onClickOpenPage;

        // список открытых страниц
        private List<string> list;

        public TableSourceOpenPages(List<string> list)
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
            cell.TextLabel.Text = list[indexPath.Row];
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
            onClickOpenPage(list[indexPath.Row], indexPath.Row);
        }
    }
}