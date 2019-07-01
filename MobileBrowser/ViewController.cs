using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace MobileBrowser
{
    public partial class ViewController : UIViewController
    {
        int indexOpenPage = 0;
        List<ItemListView> listPointer = null;
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            listPointer = ListURL.GetList();

            ButtonAddURL.TouchUpInside += (object sender, EventArgs e) => {
                if (TextBoxURL.Text != "")
                {
                    listPointer.Add(new ItemListView("https://" + TextBoxURL.Text,null));
                    ListURL.AddToListOpenPage("https://" + TextBoxURL.Text);
                }
                UpdateListView();
                OpenItem("https://" + TextBoxURL.Text, listPointer.Count-1);
            };

            ButtonMenu.TouchUpInside += (object sender, EventArgs e) => {
                if (TableView.Hidden)
                {
                    TableView.Hidden = false;
                    ButtonCreateFolder.Hidden = false;
                    ButtonReturnOnStart.Hidden = false;
                } else
                {
                    TableView.Hidden = true;
                    ButtonCreateFolder.Hidden = true;
                    ButtonReturnOnStart.Hidden = true;
                }
            };

            Browser.LoadFinished += (object sender, EventArgs e) =>
                ListURL.UpdateListOpenPages(Browser.Request.Url.ToString(), indexOpenPage);


            ButtonCreateFolder.TouchUpInside += (object sender, EventArgs e) => {
                listPointer.Add(new ItemListView("folder",new List<ItemListView>()));
                UpdateListView();
            };

            ButtonReturnOnStart.TouchUpInside += (object sender, EventArgs e) => {
                listPointer = ListURL.GetList();
                UpdateListView();
            };

        
            ButtonInsets.TouchUpInside += (object sender, EventArgs e) => {
                if (TableViewOpenPage.Hidden)
                {
                    TableViewOpenPage.Hidden = false;
                    ButtonClose.Hidden = false;
                }
                else
                {
                    TableViewOpenPage.Hidden = true;
                    ButtonClose.Hidden = true;
                }
            };

            ButtonClose.TouchUpInside += (object sender, EventArgs e) => {
                if (ListURL.GetListOpenPages().Count != 0) {
                    ListURL.DeleteOpenPage(indexOpenPage);
                }
                UpdateListView();
            
            };

            ButtonLoad.TouchUpInside += (object sender, EventArgs e) => {
                ListURL.LoadList();
                UpdateListView();
            };

        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        private void UpdateListView()
        {
            TableSource tableSource = new TableSource(listPointer);
            tableSource.onClick += OpenItem;
            TableView.Source = tableSource;

            TableSourceOpenPages tableSourceOpenPage = new TableSourceOpenPages(ListURL.GetListOpenPages());
            tableSourceOpenPage.onClickOpenPage += OpenSavedPage;
            TableViewOpenPage.Source = tableSourceOpenPage;
        }


        private void OpenItem(string site, int indexRow)
        {
            if (listPointer[indexRow].List == null)
            {
                var url = new NSUrl(site);
                var request = new NSUrlRequest(url);
                Browser.LoadRequest(request);

                ListURL.AddToListOpenPage(site);
                indexOpenPage = ListURL.GetListOpenPages().Count - 1;
            } else
            {
                listPointer = listPointer[indexRow].List;
                UpdateListView();
            }

        }

        private void OpenSavedPage(string site, int indexRow)
        {
            var url = new NSUrl(site);
            var request = new NSUrlRequest(url);
            Browser.LoadRequest(request);
            indexOpenPage = indexRow;
        }



    }
}