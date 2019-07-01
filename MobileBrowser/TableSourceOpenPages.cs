using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace MobileBrowser
{
    public class TableSourceOpenPages : UITableViewSource
    {
        public delegate void MethodContainer(string url, int index);
        public event MethodContainer onClickOpenPage;

        private List<string> list;

        public TableSourceOpenPages() { }

        public TableSourceOpenPages(List<string> list)
        {
            this.list = list;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            string item = list[indexPath.Row];
            cell.TextLabel.Text = item;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return list.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            string item = list[indexPath.Row];

            onClickOpenPage(item, indexPath.Row);

            //UIAlertView alert = new UIAlertView("Selected Item", item, null, "OK");
            //alert.Show();
        }
    }
}