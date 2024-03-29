﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace MobileBrowser
{
    /// <summary>
    /// Элемент списка сайтов и директорий
    /// </summary>
    public class ItemListView
    {
        // свойства
        public string Value { get; set; }
        public List<ItemListView> List { get; set; }

        // конструктор
        public ItemListView(string val, List<ItemListView> itemLists)
        {
            Value = val;
            List = itemLists;
        }
    }
}