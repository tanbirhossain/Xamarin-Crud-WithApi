using CrupApp.Pages;
using CrupApp.Services;
using CrupApp.SignalR;
using CrupApp.ViewModel;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrupApp
{
    public partial class MainPage : ContentPage
    {
        UserService _service;
        HubConnection connection;

        public MainPage()
        {
            InitializeComponent();
            _service = new UserService();

            lstPersons.RefreshCommand = new Command(() =>
             {
                 loadListDataAsync();
                 lstPersons.IsRefreshing = false;
             });

            #region SignalR
            connection = new HubConnectionBuilder()
               .WithUrl("http://192.168.147.1:8082/chatHub")
               .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
            #endregion

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //await Task.Run(async () => await _signalR.SendMessage("xaminUser", "Hi bro Chill from main"));
            loadListDataAsync();
            

            #region SignalR

            //_hub.On<string, string>("ReceiveMessage", (user, message) => ReciveMessage(user, message));
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Device.BeginInvokeOnMainThread(async () => await ReciveMessage(user, message));

            });
     
            try
            {
                await connection.StartAsync();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
        //Receive method
        public async Task ReciveMessage(string user, string message)
        {
            try
            {
        
                loadListDataAsync();

            }
            catch (Exception ex)
            {

                throw;
            }


            //Debug.WriteLine("SignalR message:", message);
        }
        private async void loadListDataAsync()
        {
            
            //Get All Persons
            var personList = await _service.GetUserList();
            if (personList != null)
            {
                lstPersons.ItemsSource = personList;
            }
        }
        private async void LstPersons_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var getModel = e.Item as UserViewModel;

            await Navigation.PushAsync(new pgUserAdd(getModel));
            //await DisplayAlert("item Details", getModel.Name, "OK");
        }

        private async void BtnNew_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pgUserAdd(null));
        }

        
        
    }
}
