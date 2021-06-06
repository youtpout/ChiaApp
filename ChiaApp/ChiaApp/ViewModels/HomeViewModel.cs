using ChiaDto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChiaApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {


        FullNodeStatus fullNodeStatus = new FullNodeStatus();
        public FullNodeStatus FullNodeStatus
        {
            get { return fullNodeStatus; }
            set { SetProperty(ref fullNodeStatus, value); }
        }


        WalletInfo walletInfo = new WalletInfo();
        public WalletInfo WalletInfo
        {
            get { return walletInfo; }
            set { SetProperty(ref walletInfo, value); }
        }

        public HomeViewModel()
        {
            Title = "Home";

            LoadData();

            Device.StartTimer(new TimeSpan(0, 0, 15), () =>
            {
                // do something every 15 seconds
                Device.BeginInvokeOnMainThread(() =>
                {
                    // interact with UI elements
                    LoadData();
                });
                return true; // runs again, or false to stop
            });
        }

        public ICommand OpenWebCommand { get; }

        private async void LoadData()
        {
            HttpClient client = new HttpClient();

            string url = "http://192.168.1.142:42222/api/Chia/GetFullNodeStatus";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.       
            FullNodeStatus = await response.Content.ReadAsAsync<FullNodeStatus>();

            url = "http://192.168.1.142:42222/api/Chia/GetWallet";
            response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            WalletInfo = await response.Content.ReadAsAsync<WalletInfo>();

        }


    }
}
