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

        public static void LoadList()
        {
            listURL.Add(new ItemListView("https://ya.ru",null));
            listURL.Add(new ItemListView("https://mail.ru", null));
            listURL.Add(new ItemListView("folder", new List<ItemListView>()));
            listURL[2].List.Add(new ItemListView("https://google.ru", null));
            listURL[2].List.Add(new ItemListView("https://facebook.com", null));
        }

        private static List<string> listOpenPage = new List<string>();

        public static void AddToListOpenPage(string url)
        {
            listOpenPage.Add(url);
        }

        public static List<string> GetListOpenPages()
        {
            return listOpenPage;
        }

        public static void UpdateListOpenPages(string url, int index)
        {
            listOpenPage[index] = url;
        }

        public static void DeleteOpenPage(int index)
        {
            listOpenPage.RemoveAt(index);
        }
    }
}