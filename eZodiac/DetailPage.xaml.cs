using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Net;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace eZodiac
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        public DetailPage()
        {
            this.InitializeComponent();
            //自适应布局，以700为界线
            this.SizeChanged += (s, e) =>
            {
                var state = "VisualState000";
                if (e.NewSize.Width > 700)
                {
                    state = "VisualState700";
                }
                VisualStateManager.GoToState(this, state, true);
            };
        }
        private string name;
        private string type;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //处理选择器获取的值
            switch (yours.SelectedIndex)
            {
                case 0: name = "白羊座"; break;
                case 1: name = "金牛座"; break;
                case 2: name = "双子座"; break;
                case 3: name = "巨蟹座"; break;
                case 4: name = "狮子座"; break;
                case 5: name = "处女座"; break;
                case 6: name = "天秤座"; break;
                case 7: name = "天蝎座"; break;
                case 8: name = "射手座"; break;
                case 9: name = "摩羯座"; break;
                case 10: name = "水瓶座"; break;
                case 11: name = "双鱼座"; break;
                default: name = null; break;
            }
            switch (kind.SelectedIndex)
            {
                case 0: type = "today"; break;
                case 1: type = "tomorrow"; break;
                case 2: type = "week"; break;
                case 3: type = "nextweek"; break;
                case 4: type = "month"; break;
                default: type = null; break;
            }
            //判断是否完全选择
            if (name != null && type != null)
                Search_Click();
            else
                aaa.Text = "请选择！";
        }
        //网络请求
        private async void Search_Click()
        {
            //抓取异常
            try
            {
                string content = await PostHttpClient("http://api.avatardata.cn/Constellation/Query");
                //json的反序列化
                JObject jsonobj = JObject.Parse(content);
                string json = jsonobj["error_code"].ToString();
                if (json == "0")
                {
                    string json1 = jsonobj["result1"].ToString();
                    JObject result = JObject.Parse(json1);
                    string datetime, date, color, all, health, love, money, number, QFriend, summary, work, name;
                    //分配json里的信息
                    name = result["name"].ToString();
                    datetime = result["datetime"].ToString();
                    date = result["date"].ToString();
                    color = result["color"].ToString();
                    all = result["all"].ToString();
                    health = result["health"].ToString();
                    love = result["love"].ToString();
                    money = result["money"].ToString();
                    number = result["number"].ToString();
                    QFriend = result["QFriend"].ToString();
                    summary = result["summary"].ToString();
                    work = result["work"].ToString();
                    //对返回的字符串进行格式处理
                    if (all.IndexOf("\r\n") != -1)
                        all = all.Replace("\r\n", string.Empty);
                    if (color.IndexOf("\r\n") != -1)
                        color = color.Replace("\r\n", string.Empty);
                    if (number.IndexOf("\r\n") != -1)
                        number = number.Replace("\r\n", string.Empty);
                    if (QFriend.IndexOf("\r\n") != -1)
                        QFriend = QFriend.Replace("\r\n", string.Empty);
                    if (health.IndexOf("\r\n") != -1)
                        health = health.Replace("\r\n", string.Empty);
                    if (love.IndexOf("\r\n") != -1)
                        love = love.Replace("\r\n", string.Empty);
                    if (money.IndexOf("\r\n") != -1)
                        money = money.Replace("\r\n", string.Empty);
                    if (work.IndexOf("\r\n") != -1)
                        work = work.Replace("\r\n", string.Empty);
                    if (summary.IndexOf("\r\n") != -1)
                        summary = summary.Replace("\r\n", string.Empty);
                    if (health.IndexOf("马子晴") != -1)
                        health = health.Replace("作者：马子晴", string.Empty);
                    if (health.IndexOf("健康：") != -1)
                        health = health.Replace("健康：", string.Empty);
                    if (love.IndexOf("恋情：") != -1)
                        love = love.Replace("恋情：", string.Empty);
                    if (money.IndexOf("财运：") != -1)
                        money = money.Replace("财运：", string.Empty);
                    if (work.IndexOf("工作：") != -1)
                        work = work.Replace("工作：", string.Empty);
                    //根据字符串是否为空判断该块是否显示
                    if (all != "")
                    {
                        All.Visibility = Visibility.Visible;
                        textAll.Text = "总体：" + all;
                    }
                    else
                    {
                        All.Visibility = Visibility.Collapsed;
                        textAll.Text = "";
                    }
                    if (color != "")
                    {
                        Color.Visibility = Visibility.Visible;
                        textColor.Text = "幸运色：" + color;
                    }
                    else
                    {
                        Color.Visibility = Visibility.Collapsed;
                        textColor.Text = "";
                    }
                    if (health != "")
                    {
                        Health.Visibility = Visibility.Visible;
                        textHealth.Text = "健康：" + health;
                    }
                    else
                    {
                        Health.Visibility = Visibility.Collapsed;
                        textHealth.Text = "";
                    }
                    if (love != "")
                    {
                        Love.Visibility = Visibility.Visible;
                        textLove.Text = "恋情：" + love;
                    }
                    else
                    {
                        Love.Visibility = Visibility.Collapsed;
                        textLove.Text = "";
                    }
                    if (money != "")
                    {
                        Money.Visibility = Visibility.Visible;
                        textMoney.Text = "财运：" + money;
                    }
                    else
                    {
                        Money.Visibility = Visibility.Collapsed;
                        textMoney.Text = "";
                    }
                    if (number != "")
                    {
                        Number.Visibility = Visibility.Visible;
                        textNumber.Text = "幸运数：" + number;
                    }
                    else
                    {
                        Number.Visibility = Visibility.Collapsed;
                        textNumber.Text = "";
                    }
                    if (QFriend != "")
                    {
                        Friend.Visibility = Visibility.Visible;
                        textFriend.Text = "贵人星座：" + QFriend;
                    }
                    else
                    {
                        Friend.Visibility = Visibility.Collapsed;
                        textFriend.Text = "";
                    }
                    if (summary != "")
                    {
                        Summary.Visibility = Visibility.Visible;
                        textSummary.Text = "综述：" + summary;
                    }
                    else
                    {
                        Summary.Visibility = Visibility.Collapsed;
                        textSummary.Text = "";
                    }
                    if (work != "")
                    {
                        Work.Visibility = Visibility.Visible;
                        textWork.Text = "工作：" + work;
                    }
                    else
                    {
                        Work.Visibility = Visibility.Collapsed;
                        textWork.Text = "";
                    }
                    aaa.Text = "";
                }
                else
                {
                    aaa.Text = "发生了错误，可能是接口使用次数超过上限。请明天再来哟！";
                }
            }
            //处理异常
            catch
            {
                aaa.Text = "亲，您貌似没联网哟！";
            }
        }
        //异步获取json
        private async Task<string> PostHttpClient(string uri)
        {
            List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
            paramList.Add(new KeyValuePair<string, string>("key", "97e12e338291443d8289af11c33738ef"));
            paramList.Add(new KeyValuePair<string, string>("consName", name));
            paramList.Add(new KeyValuePair<string, string>("type", type));
            string content = "";
            return await Task.Run(() =>
            {
                HttpClient httpClient = new HttpClient();
                System.Net.Http.HttpResponseMessage response;
                response = httpClient.PostAsync(new Uri(uri), new FormUrlEncodedContent(paramList)).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    content = response.Content.ReadAsStringAsync().Result;
                return content;
            });
        }
    }
}
