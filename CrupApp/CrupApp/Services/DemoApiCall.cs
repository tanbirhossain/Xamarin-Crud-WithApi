//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CrupApp.Services
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            CallWebAPIAsync().Wait();
//        }

//        static async Task CallWebAPIAsync()
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:55587/");
//                client.DefaultRequestHeaders.Accept.Clear();
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                //GET Method
//                HttpResponseMessage response = await client.GetAsync("api/Department/1");
//                if (response.IsSuccessStatusCode)
//                {
//                    Department department = await response.Content.ReadAsAsync<Department>();
//                    Console.WriteLine("Id:{0}\tName:{1}", department.DepartmentId, department.DepartmentName);
//                    Console.WriteLine("No of Employee in Department: {0}", department.Employees.Count);
//                }
//                else
//                {
//                    Console.WriteLine("Internal server Error");
//                }

//                //POST Method
//                var departmentPost = new Department() { DepartmentName = "Test Department" };
//                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/Department", departmentPost);
//                if (responsePost.IsSuccessStatusCode)
//                {
//                    // Get the URI of the created resource.
//                    Uri returnUrl = responsePost.Headers.Location;
//                    Console.WriteLine(returnUrl);
//                }

//                ////PUT Method
//                var departmentPut = new Department() { DepartmentId = 9, DepartmentName = "Updated Department" };
//                HttpResponseMessage responsePut = await client.PutAsJsonAsync("api/Department", departmentPut);
//                if (responsePut.IsSuccessStatusCode)
//                {
//                    Console.WriteLine("Success");
//                }

//                //Delete Method
//                int departmentId = 9;
//                HttpResponseMessage responseDelete = await client.DeleteAsync("api/Department/" + departmentId);
//                if (responseDelete.IsSuccessStatusCode)
//                {
//                    Console.WriteLine("Success");
//                }
//            }
//            Console.Read();
//        }




//    }
//}
