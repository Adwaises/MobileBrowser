using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace MobileBrowser
{
    public class ItemListView
    {
        public ItemListView(string val, List<ItemListView> itemLists)
        {
            Value = val;
            List = itemLists;
        }

        public string Value { get; set; }
        public List<ItemListView> List { get; set; }

    }
}