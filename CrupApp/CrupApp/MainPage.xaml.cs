using CrupApp.Pages;
using CrupApp.Services;
using CrupApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrupApp
{
    public partial class MainPage : ContentPage
    {
        UserService _service = new UserService();
        public MainPage()
        {
            InitializeComponent();
            lstPersons.RefreshCommand = new Command(() =>
             {
                 loadListDataAsync();
                 lstPersons.IsRefreshing = false;
             });
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            loadListDataAsync();
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
             var getModel =  e.Item as UserViewModel;
            
            await Navigation.PushAsync(new pgUserAdd(getModel));
           //await DisplayAlert("item Details", getModel.Name, "OK");
        }

        private async void BtnNew_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pgUserAdd(null));
        }
        
        #region No Need Code
        //private async void BtnAdd_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var user = new UserViewModel();
        //        user.Name = txtName.Text;
        //        user.IsActive = true;
        //        user.Id = Convert.ToInt32(txtPersonId.Text);

        //        var result = await _service.InsertAndUpdateUserAsync(user);
        //        if (result)
        //        {
        //            await DisplayAlert("Success", "Insert Successfully", "OK");
        //            loadListDataAsync();
        //        }
        //        else await DisplayAlert("Filed", "Try Again", "OK");


        //    }
        //    catch (Exception ex)
        //    {

        //        await DisplayAlert("Error", ex.Message, "OK");
        //    }

        //}

        //private async void BtnRead_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new pgUserAdd(null));
        //}

        //private async void BtnUpdate_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var user = new UserViewModel();
        //        user.Name = txtName.Text;
        //        user.IsActive = true;
        //        user.Id = Convert.ToInt32(txtPersonId.Text);

        //        var result = await _service.InsertAndUpdateUserAsync(user);
        //        if (result)
        //        {
        //            await DisplayAlert("Success", "Update Successfully", "OK");
        //            loadListDataAsync();
        //        }
        //        else await DisplayAlert("Filed", "Try Again", "OK");


        //    }
        //    catch (Exception ex)
        //    {

        //        await DisplayAlert("Error", ex.Message, "OK");
        //    }
        //}

        //private async void BtnDelete_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var warning = await DisplayAlert("Warning", "Are you sure?", "Yes", "No");
        //        if (warning)
        //        {
        //            var result = await _service.DeleteUserById(Convert.ToInt32(txtPersonId.Text));
        //            if (result)
        //            {
        //                await DisplayAlert("Success", "Delete Successfully", "OK");
        //                loadListDataAsync();
        //            }
        //            else await DisplayAlert("Filed", "Try Again", "OK");
        //        }




        //    }
        //    catch (Exception ex)
        //    {

        //        await DisplayAlert("Error", ex.Message, "OK");
        //    }
        //}
        #endregion
    }
}
