using BookMenu.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



// 基本頁面項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234237

namespace BookMenu
{
    /// <summary>
    /// 提供大部分應用程式共通特性的基本頁面。
    /// </summary>
    public sealed partial class PersonalDataSearch : Page
    {
        public static string[][] xx;
        public StorageFile file;
        public int num;
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// 此項可能變更為強類型檢視模型。
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper 是用在每個頁面上協助巡覽及
        /// 處理程序生命週期管理
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public PersonalDataSearch()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// 巡覽期間以傳遞的內容填入頁面。從之前的工作階段
        /// 重新建立頁面時，也會提供儲存的狀態。
        /// </summary>
        /// <param name="sender">
        /// 事件之來源；通常是<see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">提供傳遞出去之巡覽參數之事件資料
        /// <see cref="Frame.Navigate(Type, Object)"/> 初始要求本頁面時及
        /// 這個頁面在先前的工作階段期間保留的狀態字典
        /// 工作階段。第一次瀏覽頁面時，狀態是 null。</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// 在應用程式暫停或從巡覽快取中捨棄頁面時，
        /// 保留與這個頁面關聯的狀態。值必須符合
        /// <see cref="SuspensionManager.SessionState"/> 的序列化需求。
        /// </summary>
        /// <param name="sender">事件之來源；通常是<see cref="NavigationHelper"/></param>
        /// <param name="e">事件資料，此資料提供即將以可序列化狀態填入的空白字典
        ///。</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper 註冊

        /// 本區段中提供的方法只用來允許
        /// NavigationHelper 可回應頁面的巡覽方法。
        /// 
        /// 頁面專屬邏輯應該放在事件處理常式中
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// 和 <see cref="GridCS.Common.NavigationHelper.SaveState"/>。
        /// 巡覽參數可用於 LoadState 方法
        /// 除了先前的工作階段期間保留的頁面狀態。

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        public void backbt_click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
       
        public void conbime(string x)   //5帳號 6密碼 7權限
        {
            string[] inter = x.Split(',');
            num = inter.Length / 8;
            string[][] xx = new string[num][];
            for (var i = 0; i < num; i++)
            {
                xx[i] = new string[8];
            }
            for (var w = 0; w < xx.Length; w++)
            {
                for (var e = 0; e < xx[w].Length; e++)
                {
                    for (var i = 0; i < inter.Length; i++)
                    {
                        var total = w * 8 + e;
                        xx[w][e] = inter[total];
                    }
                }
            }
          //  tt.Text = xx[2][5];
          //  tta.Text = xx[2][6];
           // tts.Text =;
            var boo = false;
            for (var i = 0; i < num; i++)
            {
                if ((tt.Text == xx[i][5]) && (tta.Password == xx[i][6]))
                {
                    for (var ass = 0; ass < 5; ass++)
                    {
                        tts.Text += xx[i][ass]+"\n";
                        boo = true;
                    }
            }
               }
            if(boo==false)
                {
                    tts.Text = "請輸入正確的帳號密碼!!";
                    tt.Text = "";
                    tta.Password = "";
                }
            //  tt1.Text = xx[24][0];
            // return xx[][];
            /*  inter = new string [x.Length][];
 for(var i =0;i<inter.Length;i++)
 {
     inter[i] = new string[4];
 }*/
        }
       public async void Button_Click(object sender, RoutedEventArgs e)
        {
            tts.Text = "";
            /*Windows.Storage.Pickers.FileOpenPicker openPicker = new Windows.Storage.Pickers.FileOpenPicker();
            openPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            openPicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;

            openPicker.FileTypeFilter.Clear();
            openPicker.FileTypeFilter.Add(".txt");
            openPicker.FileTypeFilter.Add(".doc");
            openPicker.FileTypeFilter.Add(".docx");
                       
            file = await openPicker.PickSingleFileAsync();
            try
            {
                string tet = await Windows.Storage.FileIO.ReadTextAsync(file);
            //    tt.Text = file.;
                conbime(tet);

            }
            catch (Exception ex) { tta.Text = ex.Message; }*/
           try
            {
                StorageFolder storageFolder = KnownFolders.PicturesLibrary;
                StorageFile storageFile = await storageFolder.GetFileAsync("personaldata.txt");
                string textContent = await FileIO.ReadTextAsync(storageFile, Windows.Storage.Streams.UnicodeEncoding.Utf8);
              // tts.Text =textContent;
                conbime(textContent);
            }
            catch(Exception ex){
                tt.Text = ex.Message;
            }
        }
    }
}
