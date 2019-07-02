using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace MobileBrowser
{
    /// <summary>
    /// Класс, хранящий список с сайтами и директориями и список с открытыми вкладками
    /// </summary>
    public static class ListURL
    {
        // список сайтов и директорий
        private static List<ItemListView> listURL = new List<ItemListView>();

        /// <summary>
        /// Возвращает список сайтов и директорий
        /// </summary>
        /// <returns></returns>
        public static List<ItemListView> GetList()
        {
            return listURL;
        }

        /// <summary>
        /// Генерирует список сайтов и директорий
        /// </summary>
        public static void LoadList()
        {
            listURL.Add(new ItemListView("https://ya.ru/",null));
            listURL.Add(new ItemListView("https://mail.ru/", null));
            listURL.Add(new ItemListView("folder", new List<ItemListView>()));
            listURL[listURL.Count-1].List.Add(new ItemListView("https://google.ru/", null));
            listURL[listURL.Count-1].List.Add(new ItemListView("https://facebook.com/", null));
        }

        // список открытых вкладок
        private static List<string> listOpenPage = new List<string>();

        /// <summary>
        /// Добавляет сайт в список открытых
        /// </summary>
        /// <param name="url"></param>
        public static void AddToListOpenPage(string url)
        {
            listOpenPage.Add(url);
        }

        /// <summary>
        /// Возвращает список открытых сайтов
        /// </summary>
        /// <returns></returns>
        public static List<string> GetListOpenPages()
        {
            return listOpenPage;
        }

        /// <summary>
        /// Обновляет состояние открытой страницы
        /// </summary>
        /// <param name="url"></param>
        /// <param name="index"></param>
        public static void UpdateListOpenPages(string url, int index)
        {
            listOpenPage[index] = url;
        }

        /// <summary>
        /// Удаляет открытую страницу
        /// </summary>
        /// <param name="index"></param>
        public static void DeleteOpenPage(int index)
        {
            listOpenPage.RemoveAt(index);
        }
    }
}