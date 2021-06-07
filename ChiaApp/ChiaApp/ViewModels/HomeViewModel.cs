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

        FarmingInfo farmingInfo = new FarmingInfo();
        public FarmingInfo FarmingInfo
        {
            get { return farmingInfo; }
            set { SetProperty(ref farmingInfo, value); }
        }


        HttpClient client;
        public HomeViewModel()
        {
            Title = "Your Node Info";

            client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 5);

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
            Error = string.Empty;
            try
            {
                Loading = true;
                Progress = 0.1m;

                string url = "http://192.168.1.142:42222/api/Chia/GetFullNodeStatus";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                FullNodeStatus = await response.Content.ReadAsAsync<FullNodeStatus>();
                Progress = 0.33m;

                url = "http://192.168.1.142:42222/api/Chia/GetWallet";
                response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                WalletInfo = await response.Content.ReadAsAsync<WalletInfo>();
                Progress = 0.66m;

                url = "http://192.168.1.142:42222/api/Chia/GetFarmingInfo";
                response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                FarmingInfo = await response.Content.ReadAsAsync<FarmingInfo>();

                Progress = 1m;
            }
            catch (TimeoutException ex)
            {
                Error = Resources.AppResources.ErrorServerTimeout;
            }
            catch (OperationCanceledException ex)
            {
                Error = Resources.AppResources.ErrorServerTimeout;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            finally
            {
                Loading = false;
            }


        }


    }
}
