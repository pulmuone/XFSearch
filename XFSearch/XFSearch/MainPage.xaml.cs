using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace XFSearch
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SearchVendorButton_Clicked(object sender, EventArgs e)
        {
            SearchVendorPage page = new SearchVendorPage();
            page.Init(this.VendCD.Text, this.VendNM.Text); //메인 화면의 검색 값을 검색화면으로 가져 갈 경우
            page.ReturnVendInfoEvent += Page_ReturnVendInfoEvent;

            await this.Navigation.ShowPopupAsync(page);
        }

        /// <summary>
        /// 검색 화면에서 선택하면 선택된 값이 이곳으로 전달됩니다.
        /// </summary>
        /// <param name="vendCd"></param>
        /// <param name="vendNm"></param>
        private void Page_ReturnVendInfoEvent(string vendCd, string vendNm)
        {
            this.VendCD.Text = vendCd;
            this.VendNM.Text = vendNm;
        }
    }
}
