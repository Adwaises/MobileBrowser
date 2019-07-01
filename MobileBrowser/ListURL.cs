using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace MobileBrowser
{
    public static class ListURL
    {
        private static List<ItemListView> listURL = new List<ItemListView>();

        public static List<ItemListView> GetList()
        {
            return listURL;
        }

        //public static void AddToListURL(string url)
        //{
        //    listURL.Add(new ItemListView(url,null));
        //}

        //public static void AddToListFolder()
        //{
        //    listURL.Add(new ItemListView("folder", new List<ItemListView>()));
        //}

        //public static void ReplaceItem(string url, int index)
        //{
        //    listURL[index].Value = url;
        //}


    }
}