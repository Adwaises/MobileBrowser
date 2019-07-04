using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace MobileBrowser
{
    public partial class ViewController : UIViewController
    {
        // индекс открытой страницы
        int indexOpenPage = 0;

        // указаель на открытую директорию (изначально указывает на корень)
        List<ItemListView> listPointer = null;

        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            // указатель на список (нужен для перехода по директориям)
            listPointer = ListURL.GetList();

            // кнопка открытия страницы
            ButtonAddURL.TouchUpInside += (object sender, EventArgs e) => {
                if (TextBoxURL.Text != "")
                {
                    if (!ListURL.GetList().Select(o => o.Value).Contains("https://" + TextBoxURL.Text + "/"))
                    {
                        listPointer.Add(new ItemListView("https://" + TextBoxURL.Text + "/", null));
                    }

                    OpenItem("https://" + TextBoxURL.Text + "/", listPointer.Count - 1);
                    UpdateListView();
                }
            };

            // кнопка, которая делает иерархию ссылок и директорий видимой
            ButtonMenu.TouchUpInside += (object sender, EventArgs e) => {
                if (TableView.Hidden)
                {
                    TableView.Hidden = false;
                    ButtonCreateFolder.Hidden = false;
                    ButtonReturnOnStart.Hidden = false;
                    ViewForList.Hidden = false;
                } else
                {
                    MakeHiddenMenu();
                }
            };

            // событие, которое обновляет ссылку на открытую страницу после открытия
            Browser.LoadFinished += (object sender, EventArgs e) => {
                if (Browser.Request.Url.ToString() != "about:blank")
                {
                    ListURL.UpdateListOpenPages(Browser.Request.Url.ToString(), indexOpenPage);
                }
            };

            // конпка создания директории
            ButtonCreateFolder.TouchUpInside += (object sender, EventArgs e) => {
                listPointer.Add(new ItemListView("folder",new List<ItemListView>()));
                UpdateListView();
            };

            // кнопка возврата в корень иерархии
            ButtonReturnOnStart.TouchUpInside += (object sender, EventArgs e) => {
                listPointer = ListURL.GetList();
                UpdateListView();
            };

            // кнопка, которая делает видимым список открытых страниц (вкладки)
            ButtonInsets.TouchUpInside += (object sender, EventArgs e) => {
                if (TableViewPages.Hidden)
                {
                    TableViewPages.Hidden = false;
                    ButtonClose.Hidden = false;
                    ViewForOpenPages.Hidden = false;
                }
                else
                {
                    MakeHiddenOpenPages();
                }
            };

            // кнопка, которая закрывает открытую страницу
            ButtonClose.TouchUpInside += (object sender, EventArgs e) => {
                if (ListURL.GetListOpenPages().Count != 0 && indexOpenPage >= 0) {
                    new UIAlertView("Deleted page", ListURL.GetListOpenPages()[indexOpenPage], null, "OK").Show();
                    ListURL.DeleteOpenPage(indexOpenPage);
                }
                UpdateListView();
                OpenPageInBrowser("about:blank");
                indexOpenPage = -1;
            };

            // кнопка, заполняющая список сайтами и директориями
            ButtonLoad.TouchUpInside += (object sender, EventArgs e) => {
                ListURL.LoadList();
                UpdateListView();
            };
        }

        /// <summary>
        /// Метод, скрывающий список с сайтами и директориями и связанные с ним кнопки
        /// </summary>
        private void MakeHiddenMenu()
        {
            TableView.Hidden = true;
            ButtonCreateFolder.Hidden = true;
            ButtonReturnOnStart.Hidden = true;
            ViewForList.Hidden = true;
        }

        /// <summary>
        /// Метод, скрывающий список открытых вкладок и связанные с ним кнопки
        /// </summary>
        private void MakeHiddenOpenPages()
        {
            TableViewPages.Hidden = true;
            ButtonClose.Hidden = true;
            ViewForOpenPages.Hidden = true;
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
        }

        /// <summary>
        /// Метод обновления списков
        /// </summary>
        private void UpdateListView()
        {
            // для превого TableView (с ссылками и директориями)
            TableSource tableSource = new TableSource(listPointer);
            tableSource.onClick += OpenItem;
            TableView.Source = tableSource;

            // для второго TableView (с открытыми вкладками)
            TableSourceOpenPages tableSourceOpenPage = new TableSourceOpenPages(ListURL.GetListOpenPages());
            tableSourceOpenPage.onClickOpenPage += OpenSavedPage;
            TableViewPages.Source = tableSourceOpenPage;
        }

        /// <summary>
        /// Метод, открывающий либо сайт, либо директорию (из первого списка)
        /// </summary>
        /// <param name="site"></param>
        /// <param name="indexRow"></param>
        private void OpenItem(string site, int indexRow)
        {
            new UIAlertView("Open page", site, null, "OK").Show();

            if (listPointer[indexRow].List == null) // если сайт
            {
                OpenPageInBrowser(site);

                // добавление в список открытых страниц, иначе обновляем индекс
                if (!ListURL.GetListOpenPages().Contains(site))
                {
                    ListURL.AddToListOpenPage(site);
                    indexOpenPage = ListURL.GetListOpenPages().Count - 1;
                }
                else
                {
                    indexOpenPage = ListURL.GetListOpenPages().FindIndex(o => o == site);
                }
            } else // если директория
            {
                listPointer = listPointer[indexRow].List;
                UpdateListView();
            }
            MakeHiddenMenu();
        }

        /// <summary>
        /// Метод, открывающий уже открытую ранее вкладку (из второго списка)
        /// </summary>
        /// <param name="site"></param>
        /// <param name="indexRow"></param>
        private void OpenSavedPage(string site, int indexRow)
        {
            new UIAlertView("Open page", site, null, "OK").Show();

            OpenPageInBrowser(site);
            indexOpenPage = indexRow;
            MakeHiddenOpenPages();
        }

        /// <summary>
        /// Открывает страницу в браузере
        /// </summary>
        /// <param name="site"></param>
        private void OpenPageInBrowser(string site)
        {
            Browser.LoadRequest(new NSUrlRequest(new NSUrl(site)));
        }
    }
}