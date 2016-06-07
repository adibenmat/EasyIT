using Newtonsoft.Json.Linq;
using PowershellApiv2.Functions;
using PowershellApiv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PowershellRepository.Interface;
using PowershellRepository.PSInstance;
using System.Dynamic;
using Newtonsoft.Json;
using System.Configuration;

namespace PowershellApiv2.Controllers
{
    public class ValuesController : ApiController
    {
        private static string modelFqdn = ConfigurationManager.AppSettings["ModelFqdn"];
        private static string thumbOfModel = ConfigurationManager.AppSettings["thumbOfModel"];

        IPowershellRepository repo = new PSInstanceRepository(modelFqdn);
        

        private static IEnumerable<string> GetBasePropertiesFromFQDN()
        {
            IPowershellItem Instance = Activator.CreateInstance(Type.GetType(ConfigurationManager.AppSettings["ModelFqdn"])) as IPowershellItem;            
            foreach(var item in Instance.GetBasePropertiesDictionary())
            {
                yield return item.Key;
            }            
            
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public JObject Get(int id)
        {
            TestModel model = new TestModel("adi", "ben");
            return JObject.FromObject(model);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        public JObject checkAPI()
        {
            TestModel model = new TestModel("adi", "ben");
            return JObject.FromObject(model);
        }


        [HttpGet]
        public JArray GetPowershellItemList()
        {
            int i = 0;
            JArray array = new JArray();
            var powershellItems = repo.GetPowershellItemsEnumerable();
                foreach(var powershellItem in powershellItems)
                {
                    JObject obj = new JObject();
                obj.Add("id", i.ToString());
                    obj.Add("thumb", @"http://www.ozkoseoglu.com/images/servis_dnm.jpg");
                    foreach(var some in powershellItem.GetBasePropertiesDictionary())
                    {
                        obj.Add(some.Key.ToLower(),some.Value);
                    }
                        //obj.Add(JObject.FromObject(powershellItem.GetBasePropertiesDictionary()));
                    
                    array.Add(obj);
                    i++;           
                }
                return array; 
        }

/*
        //public JArray GetPSItemCommandForAngularTable()
        //{
        //    JArray commandsArray = new JArray();
        //    JObject commandObject = new JObject();
        //    IPowershellItem Instance = Activator.CreateInstance(Type.GetType(ConfigurationManager.AppSettings["ModelFqdn"])) as IPowershellItem;
        //    foreach (var command in Instance.GetCommands())
        //    {
        //        commandObject.Add("icon", "share-arrow");
        //        commandObject.Add("name", command. );
        //    }
  */                             

        public JArray GetPSItemHeadersForAngularTable()
        {
            JArray array = new JArray();
            JObject obj = new JObject();            
            obj.Add("field","thumb");
            obj.Add("name", "");
            obj = new JObject();
            obj.Add("field", "id");
            obj.Add("name", "ID");
            array.Add(obj);
           foreach(var item in GetBasePropertiesFromFQDN())
           {               
               obj = new JObject();
               obj.Add("field", item.ToLower());               
               obj.Add("name", item);               
               array.Add(obj);        
           }
           return array;
        }

        [HttpGet]
        public JObject GetPowershellItemByName(string identifier)
        {                        
            var powershellItem = repo.GetPowershellItem(identifier);
            return JObject.FromObject(powershellItem.GetBasePropertiesDictionary());
        }

        public HttpStatusCode UpdatePSItem(JObject obj)
        {
            return HttpStatusCode.OK;
        }


    }
}