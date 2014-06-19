using BookMenu.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization.DateTimeFormatting;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// 基本頁面項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234237

namespace BookMenu
{
    /// <summary>
    /// 提供大部分應用程式共通特性的基本頁面。
    /// </summary>
    public sealed partial class Lentbook : Page
    {
        public string[][] xx;
        StorageFile storageFile;
        int num, xs, ys;
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


        public Lentbook()
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
        ///。</param>C:\Users\u0124089\documents\visual studio 2013\Projects\BookMenu\BookMenu\Assets\sample.txt
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
        public async void conbime(string x)   //分割AND判斷
        {
            // xs = new int();
            string[] inter = x.Split(' ');
            num = inter.Length / 5;
            xx = new string[num][];
            for (var i = 0; i < num; i++)
            {
                xx[i] = new string[5];
                //  xx[i][4] = "0";
            }
            for (var w = 0; w < xx.Length; w++)
            {
                for (var e = 0; e < xx[w].Length; e++)
                {
                    for (var i = 0; i < inter.Length; i++)
                    {
                        var total = w * 5 + e;
                        xx[w][e] = inter[total];

                    }
                }
            }
            for(var i=0;i<num;i++)
            {
                if(xx[i][1]==tt.Text)
                {
                    if(xx[i][4]=="1")
                    {
                        xx[i][4] = "0";
                        var dialog = new MessageDialog("還書成功", "還書");
                        //   await dialog.ShowAsync();
                        dialog.Commands.Add(new UICommand("是", YesCommand));
                        dialog.DefaultCommandIndex = 0;
                        await dialog.ShowAsync();
                    }
                    else
                    {
                        var dialog = new MessageDialog("此書未被借閱", "還書");
                        //   await dialog.ShowAsync();
                        dialog.Commands.Add(new UICommand("是", YesCommand));
                        dialog.DefaultCommandIndex = 0;
                        await dialog.ShowAsync();
                    }
                }
            }
           

        }
        public string save()
        {
            string savedata = "";
            for (var i = 0; i < xx.Length; i++)
            {
                for (var d = 0; d < xx[i].Length; d++)
                {
                    savedata = savedata + xx[i][d] + " ";
                }

            }
            return savedata;
        }
        void YesCommand(IUICommand command)
        {
         //   throw new NotImplementedException();
        }
        private static StorageFolder roamingFolder = ApplicationData.Current.RoamingFolder;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StorageFolder storageFolder = KnownFolders.PicturesLibrary;
                StorageFile storageFile = await storageFolder.GetFileAsync("aa.txt");
                string textContent = await FileIO.ReadTextAsync(storageFile, Windows.Storage.Streams.UnicodeEncoding.Utf8);
                // tts.Text =textContent;
                conbime(textContent);
                string ss=save();
                await FileIO.WriteTextAsync(storageFile, ss);
            }
            catch (Exception ex)
            {
               tts.Text = ex.Message;
            }
        }

         //讀取檔案不存在則Null 、無法解析 null
        /*     public static async Task<string> LoadFile(string FileName)
             {
                string file_text = "";
     
               try
                {
                  StorageFile sampleFile = await roamingFolder.GetFileAsync(FileName);
                  file_text = await FileIO.ReadTextAsync(sampleFile);
                   return file_text;
                }
              catch(Exception ex)
               {
                  aas.text("GetFileAsync找不到檔案 : "+ex.Message.ToString());
                    return null;
             }
           }
          
           public static async Task CreateFile(string FileName)
           {
          aas.text("創建新檔案:" + FileName);
               DateTimeFormatter formatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");
               StorageFile sampleFile = await roamingFolder.CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);
               await FileIO.WriteTextAsync(sampleFile,"");
            }
    
            //寫入檔案
          public static async Task WriteFile(string FileName, string content)
          {
               aas.text("寫入檔案:" + FileName);
              aas.text("寫入檔案內容:" + content);
            DateTimeFormatter formatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");
               StorageFile sampleFile = await roamingFolder.CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);
              await FileIO.WriteTextAsync(sampleFile, content);
          }*/
        }



       
      
 
        
        
        
        
        
        }

      
    

