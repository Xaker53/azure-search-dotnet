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
            Name = "TestforGit",
            Gmail = "Git@gmail.com",
            Password = "3cmXyi",
            IndexName = "myIndex",
            ApiKey = "nullll"
        };

        [Fact]
        public async void TestAddDb()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://localhost:7156/api/Create", Jsonconver(this._User));
            TryCatch(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void TestLogin()
        {
            using var httpClient = new HttpClient();
            var LoginUser = new Core.Entities.UserLogin()
            {
                UserGmail = this._User.Gmail,
                Password = this._User.Password,
            };
            
            var response = await httpClient.PostAsync("https://localhost:7156/api/Login", Jsonconver (LoginUser));
            var test = response.Content.ReadAsStringAsync().Result;
            TryCatch(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void TestGetGmailDb()
        {
            //string userGmail = "Un5itTest@gmail.com";
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiJmODZhMjk1ZS02MWZkLTQwZjktYjFhMC1kZTE1OTlmZTIyMTYiLCJleHAiOjE3NjEzNDQwODB9.dk8hzF5_xfVE8ktHQN9Y4FQQTcU9As_dqU2OmfCOG78");
            var response = await httpClient.GetAsync($"https://localhost:7156/api/GetEmail/?email={_User.Gmail}");
            TryCatch(response);

            //var test = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
            var user = JsonConvert.DeserializeObject<UserRequest>(response.Content.ReadAsStringAsync().Result);
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
            var NewUpdate = new UserRequest()
            {
                Gmail = this._User.Gmail,
                Password = "TestUpdateUserDb"

            };
            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://localhost:7156/api/UpdateUser", Jsonconver(NewUpdate));
            TryCatch(response);


            //Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        }

        [Fact]
        public async void TestDeleteUser()
        {
            // var EmailUser = "Un5itTest@gmail.com";
            using var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync($"https://localhost:7156/api/DeleteUser/{_User.Gmail}");
            TryCatch(response);


            //Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        }
    }
}
