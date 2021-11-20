using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

    public class RandomCity
    {  
        class City {
            public string city;
            public string state;
        }

        static City[] cities;
        static System.Random rand = new System.Random(DateTime.Now.Millisecond + DateTime.Now.Second);

        public static string Generate()
        {
            if (RandomCity.cities == null) {
                JsonSerializer serializer = new JsonSerializer();

                using (StreamReader reader = new StreamReader("Assets\\Resources\\usaCities.json"))
                using (JsonReader jreader = new JsonTextReader(reader))
                {
                    cities = serializer.Deserialize<City[]>(jreader);
                }
            }

            City city = RandomCity.cities[rand.Next(RandomCity.cities.Length)];
            return city.city + ", " + city.state;
        }
    }
