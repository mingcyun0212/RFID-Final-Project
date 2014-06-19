using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白頁項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234238

namespace BookMenu
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class truemainpage : Page
    {
        public static string[][] xx;
        public StorageFile file;
        public int num;
        public truemainpage()
        {
            this.InitializeComponent();
        }
        public async void conbime(string x)
        {
            try
            {
                string[] inte = x.Split(' ');
                num = inte.Length / 2;
                xx = new string[num][];
                for (var i = 0; i < num; i++)
                {
                    xx[i] = new string[2];
                }
                for (var i = 0; i < xx.Length; i++)
                {
                    for (var s = 0; s < xx[i].Length; s++)
                    {
                        for (var e = 0; e < inte.Length; e++)
                        {
                            var total = i * 2 + s;
                            xx[i][s] = inte[total];
                        }
                    }
                }
                int tes = 0;
                for (var i = 0; i < num; i++)
                {
                    if (xx[i][0] == tt.Text)
                    {
                       
                        var dialog = new MessageDialog("歡迎光臨，"+xx[i][1] , "登入");
                        dialog.Commands.Add(new UICommand("是", YesCommand));
                        dialog.DefaultCommandIndex = 0;
                        await dialog.ShowAsync();
                        tes = 1;
                        break;
                    }

                }
                if (tes == 0)
                {
                    var dialog = new MessageDialog("請輸入正確的卡號", "登入");
                    dialog.Commands.Add(new UICommand("是", YessCommand));
                    dialog.DefaultCommandIndex = 0;
                   await dialog.ShowAsync();

                }
            }
            catch(Exception ex)
            {
                tts.Text = ex.Message;

            }

        }

        private void YessCommand(IUICommand command)
        {
           // throw new NotImplementedException();
        }

       void YesCommand(IUICommand command)
        {
           // throw new NotImplementedException();
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(MainPage));
            }
        }
        
        private async void btt_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder storageFolder = KnownFolders.PicturesLibrary;
            StorageFile storageFile = await storageFolder.GetFileAsync("pwd.txt");
            string textContent = await FileIO.ReadTextAsync(storageFile, Windows.Storage.Streams.UnicodeEncoding.Utf8);
            conbime(textContent);
        }

      

       
    }
}
