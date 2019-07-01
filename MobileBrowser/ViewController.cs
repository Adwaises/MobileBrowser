using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace MobileBrowser
{
    public partial class ViewController : UIViewController
    {
        int index = 0;
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
                    //ListURL.AddToListURL(TextBoxURL.Text);
                    listPointer.Add(new ItemListView(TextBoxURL.Text,null));
                }

                UpdateListView();

                OpenItem("https://" +TextBoxURL.Text, listPointer.Count-1);


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
                listPointer[index].Value = Browser.Request.Url.ToString();


            ButtonCreateFolder.TouchUpInside += (object sender, EventArgs e) => {
                //ListURL.AddToListFolder();
                //listPointer = ListURL.GetList();
                listPointer.Add(new ItemListView("folder",new List<ItemListView>()));
                UpdateListView();
            };

            ButtonReturnOnStart.TouchUpInside += (object sender, EventArgs e) => {
                listPointer = ListURL.GetList();
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
        }


        private void OpenItem(string site, int indexRow)
        {
            if (listPointer[indexRow].List == null)
            {
                index = indexRow;
                var url = new NSUrl(site);
                var request = new NSUrlRequest(url);
                Browser.LoadRequest(request);
            } else
            {
                listPointer = listPointer[indexRow].List;
                UpdateListView();
                index = 0;
            }

        }

    }
}