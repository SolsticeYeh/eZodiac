using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace eZodiac
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //int count = 0;//计数
        public MainPage()
        {
            this.InitializeComponent();
            //SystemNavigationManager.GetForCurrentView().BackRequested += View_BackRequested;
        }

        //默认展示欢迎页
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                ContentFrame.Navigate(typeof(WelcomePage));
            }
            base.OnNavigatedTo(e);
        }

        //展开与合上汉堡菜单
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mySplit.IsPaneOpen = !mySplit.IsPaneOpen;
        }
        //导航至介绍页
        private void FButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(InformationPage));
            if (mySplit.IsPaneOpen == true)
                mySplit.IsPaneOpen = !mySplit.IsPaneOpen;
            //SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;//按下按钮出现系统返回键
            //count += 1;//按下按钮计数+1
            Home.Visibility = Visibility.Visible;//显示返回主页
        }
        //导航至查询页
        private void SButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(DetailPage));
            if (mySplit.IsPaneOpen == true)
                mySplit.IsPaneOpen = !mySplit.IsPaneOpen;
            //SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;//按下按钮出现系统返回键
            //count += 1;//按下按钮计数+1
            Home.Visibility = Visibility.Visible;//显示返回主页
        }
        //导航至首页
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(WelcomePage));
            if (mySplit.IsPaneOpen == true)
                mySplit.IsPaneOpen = !mySplit.IsPaneOpen;
            Home.Visibility = Visibility.Collapsed;//隐藏返回主页
        }
        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(AboutPage));
            if (mySplit.IsPaneOpen == true)
                mySplit.IsPaneOpen = !mySplit.IsPaneOpen;
            Home.Visibility = Visibility.Visible;//显示返回主页
        }
        /*
        //弃用的返回键功能
        private void View_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (ContentFrame == null)
                return;
            if (ContentFrame.CanGoBack)
                {
                    e.Handled = true;
                    ContentFrame.GoBack();//返回上一个界面
                    count -= 1;//按下返回键后计数-1
                    if (count == 0)//判断是否回到首页
                    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                }
        }
        */
    }
}
