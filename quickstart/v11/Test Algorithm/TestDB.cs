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
using Core.Entities.MappingProfiles;

namespace Test_Algorithm
{
    public class TestDB
    {
        private HttpClient mClient = new()
        {
            BaseAddress = new Uri("http://127.0.0.1:5191/api/azure")
        };

        private UserRequest _User = new UserRequest()
        {
            Name = "test",
            Gmail = "TestWord@gmail.com",
            Password = "test"
        };

       //private UserRequest _User = new FakerUser().Request();

        private string _JWTToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiJhNmEzNjZhNi05MDY1LTQ5YTUtYmQ5Mi00NjI2OWNiNTc5NWQiLCJleHAiOjE3NjYyNDMyMTl9.t3HhxfpzlW2LNHB3LK_1eoAFLyO2z7xy_6wc3opYZS4";

        [Fact]
        public async Task TestAddDb()
        {
            //UserRequest _User = new FakerUser().Request();
            
            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://localhost:7156/api/Create", Jsonconver(this._User));
            TryCatch(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestLogin()
        {
            using var httpClient = new HttpClient();
            var LoginUser = new Core.Entities.UserLogin()
            {
                UserGmail = this._User.Gmail,
                Password = this._User.Password,
            };
            
            var response = await httpClient.PostAsync("https://localhost:7156/api/Login", Jsonconver (LoginUser));
            _JWTToken = response.Content.ReadAsStringAsync().Result;
            TryCatch(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestGetGmailDb()
        {
            //string userGmail = "Un5itTest@gmail.com";
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{_JWTToken}");
            var response = await httpClient.GetAsync($"https://localhost:7156/api/GetEmail/?email={_User.Gmail}");
            TryCatch(response);

            //var test = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
            var user = JsonConvert.DeserializeObject<UserRequest>(response.Content.ReadAsStringAsync().Result);
            //var testst = user?.UserGmail;


           Assert.True(user.Gmail == _User.Gmail);

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
        public async Task TestUpdateUserDb()
        {
            var NewUpdate = new UserRequest()
            {
                Gmail = this._User.Gmail,
                Password = "0228",
                Name = "AndrewTest",
                OtherGmail = "TestWord@gmail.com"
            };
            _User.Password = NewUpdate.Password;
            _User.Gmail = NewUpdate.OtherGmail;
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{_JWTToken}");
            var response = await httpClient.PostAsync("https://localhost:7156/api/UpdateUser", Jsonconver(NewUpdate));
            TryCatch(response);


            //Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestDeleteUser()
        {
            // var EmailUser = "Un5itTest@gmail.com";
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{_JWTToken}");
            var response = await httpClient.DeleteAsync($"https://localhost:7156/api/DeleteUser/{_User.Gmail}");
            TryCatch(response);


            //Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task FullUserLifecycleTest()
        {
            await TestAddDb();
            await TestLogin();
            await TestGetGmailDb();
            await TestUpdateUserDb();
            await TestLogin();
            await TestDeleteUser();
        }
    }
}
