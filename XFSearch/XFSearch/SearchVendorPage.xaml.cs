using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSearch
{    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchVendorPage : ContentPage
    {
        //delegate 타입선언
        public delegate void ReturnVendInfoEventHandler(string vendCd, string vendNm);

        //위에서 만든 delegate 를 사용해서 이벤트 핸들러 생성(외부에서 사용)
        public event ReturnVendInfoEventHandler ReturnVendInfoEvent;

        public SearchVendorPage()
        {
            InitializeComponent();
        }


        //메인화면에서 검색값을 검색 화면으로 가져 올 경우
        public void Init(string vendCd, string vendNm)
        {
            this.VendCD.Text = vendCd;
            this.VendNM.Text = vendNm;
        }


        private async void OKButton_Clicked(object sender, EventArgs e)
        {
            //이전 화면으로 선택된 값을 돌려 준다.
            //컬렉션 리스트에서 해당 row선택하는 방법으로 하면 됩니ㅏㄷ.
            if(ReturnVendInfoEvent != null)
            {
                ReturnVendInfoEvent(this.VendCD.Text, this.VendNM.Text);
            }

            await this.Navigation.PopAsync();
        }

        private async void OKCancel_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
    }
}