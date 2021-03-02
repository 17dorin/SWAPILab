using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SWAPILab.Models
{
    public class SwapiDAL
    {
        public string GetData(int id, string section)
        {
            string url = $@"https://swapi.dev/api/{section}/{id}/";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();

            return json;
        }

        public Person ConvertToPerson(int id)
        {
            string personData = GetData(id, "people");
            Person p = JsonConvert.DeserializeObject<Person>(personData);

            return p;
        }

        public Planet ConvertToPlanet(int id)
        {
            string planetData = GetData(id, "planets");
            Planet p = JsonConvert.DeserializeObject<Planet>(planetData);

            return p;
        }
    }
}
