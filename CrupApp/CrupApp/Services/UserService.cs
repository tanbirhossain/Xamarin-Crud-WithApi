using CrupApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//using  Xamarin.Essentials;
namespace CrupApp.Services
{
    public class UserService
    {
        string BaseUrl = "http://192.168.0.67:8082/api/";
        string BearerToken = null;

        HttpClient client; 
        public UserService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<List<UserViewModel>> GetUserList()
        {
            try
            {
                    //GET Method
                    HttpResponseMessage response = await client.GetAsync("users/List/");
                    if (response.IsSuccessStatusCode)
                    {
                        List<UserViewModel> userList = await response.Content.ReadAsAsync<List<UserViewModel>>();
                        return userList;
                    }
                    else
                    {
                        return null;
                    }
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
 
        }
        public async Task<bool> DeleteUserById(int Id)
        {
            try
            {
                //GET Method
                HttpResponseMessage response = await client.GetAsync("users/DeleteById/"+ Id);
                if (response.IsSuccessStatusCode)
                {
                    UserViewModel userList = await response.Content.ReadAsAsync<UserViewModel>();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception();
            }

        }
        public async Task<bool> InsertAndUpdateUserAsync(UserViewModel model)
        {
            HttpResponseMessage response;
            if (model.Id>0)
            {
                response = await client.PostAsJsonAsync("users/Update", model);
                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadAsAsync<UserViewModel>();
                    return true;
                }
            }
            else //Insert
            {
                response = await client.PostAsJsonAsync("users/Insert", model);
                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadAsAsync<UserViewModel>();
                    return true;
                }
            }
           
            return false;
        }

    }
}


//var httpClient = new HttpClient();
//httpClient.BaseAddress = Uri // I have changed the Uri variabele, you should extend this class and give it the same base address in the constructor.
//var resp= await httpClient.GetAsync("Machines");
//            if (resp.Result.IsSuccessStatusCode)
//            {
//                var repStr = resp.Result.Content.ReadAsStringAsync();
//machines= JsonConvert.DeserializeObject<List<Machine>>(repStr.Result.ToString());
//            }