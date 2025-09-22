using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure;
using CodeFirst.Models;
using Core.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;

namespace Test_Algorithm
{
    public class TestDB
    {
        private HttpClient mClient = new()
        {
            BaseAddress = new Uri("http://127.0.0.1:5191/api/azure")
        };
        //[Fact]
        //public void TestValidatorDb()
        //{
        //    var User = new User();
        //    User.UserName = "test";
        //    User.Password = "test";
        //    User.UserGmail = "testf@gmail.com";

        //    UserdbContext dbContext = new UserdbContext();
        //    Validator.ValidateObject(User, new ValidationContext(User), true);
        //    dbContext.Add(User);
        //    dbContext.SaveChanges();
        //}

        [Fact]

        public async void TestAddDb()
        {
            var user = new Core.Models.User
            {
                UserName = "Oleg",
                UserGmail = "test@gmail.com",
                Password = "123",
                IndexName = "myIndex",
                ApiKey = "abc123"
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://localhost:7156/api/Create", Jsonconver(user));
            TryCatch(response);
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);


        }
        [Fact]
        public async void TestGetGmailDb()
        {
            string userGmail = "test@gmail.com";
            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://localhost:7156/api/GetEmail", Jsonconver(userGmail));
            TryCatch(response);

            //var test = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
            var user = JsonConvert.DeserializeObject<Core.Models.User>(response.Content.ReadAsStringAsync().Result);
            //var testst = user?.UserGmail;


           Assert.True(user!=null);

        }



        public StringContent Jsonconver(object ob)
        {
            return new StringContent(JsonConvert.SerializeObject(ob),
               Encoding.UTF8,
               "application/json");
        }

        public async Task <HttpResponseMessage> TryCatch(HttpResponseMessage? response)
        {
            try
            {
                var tt = response.EnsureSuccessStatusCode();
                return tt;
            }
            catch (Exception e)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }


        [Fact]
        public async void TestUpdateUserDb()
        {
            var NewUpdate = new Core.Models.UserDTO
            {
                UserGmail = "test53@gmail.com",
                Password = "OlegPass"

            };
            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://localhost:7156/api/UpdateUser", Jsonconver(NewUpdate));
            TryCatch(response);


            //Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(response.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}
