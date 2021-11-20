using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

    /// <summary>
    /// RandomName class, used to generate a random name.
    /// </summary>
    public class RandomName
    {  
        /// <summary>
        /// Class for holding the lists of names from names.json
        /// </summary>
        class NameList
        {
            public string[] boys { get; set; }
            public string[] girls { get; set; }
            public string[] last { get; set; }

            public NameList()
            {
                boys = new string[] { };
                girls = new string[] { };
                last = new string[] { };
            }
        }

        static System.Random rand = new System.Random(DateTime.Now.Millisecond + DateTime.Now.Second);
        static List<string> Male;
        static List<string> Female;
        static List<string> Last;

        /// <summary>
        /// Returns a new random name
        /// </summary>
        /// <param name="sex">The sex of the person to be named. true for male, false for female</param>
        /// <param name="middle">How many middle names do generate</param>
        /// <param name="isInital">Should the middle names be initials or not?</param>
        /// <returns>The random name as a string</returns>
        public static string Generate(Sex sex, int middle = 0, bool isInital = false)
        {
            if (RandomName.Male == null) {
                NameList l = new NameList();

                JsonSerializer serializer = new JsonSerializer();

                using (StreamReader reader = new StreamReader("Assets\\Resources\\names.json"))
                using (JsonReader jreader = new JsonTextReader(reader))
                {
                    l = serializer.Deserialize<NameList>(jreader);
                }

                RandomName.Male = new List<string>(l.boys);
                RandomName.Female = new List<string>(l.girls);
                RandomName.Last = new List<string>(l.last);
            }

            string first = sex == Sex.Male ? RandomName.Male[rand.Next(RandomName.Male.Count)] : RandomName.Female[rand.Next(RandomName.Female.Count)]; // determines if we should select a name from male or female, and randomly picks
            string last = RandomName.Last[rand.Next(RandomName.Last.Count)]; // gets the last name

            List<string> middles = new List<string>();

            for (int i = 0; i < middle; i++)
            {
                if (isInital)
                {
                    middles.Add("ABCDEFGHIJKLMNOPQRSTUVWXYZ"[rand.Next(0, 25)].ToString() + "."); // randomly selects an uppercase letter to use as the inital and appends a dot
                }
                else
                {
                    middles.Add(sex == Sex.Male ? RandomName.Male[rand.Next(RandomName.Male.Count)] : RandomName.Female[rand.Next(RandomName.Female.Count)]); // randomly selects a name that fits with the sex of the person
                }
            }

            StringBuilder b = new StringBuilder();
            b.Append(first + " "); // put a space after our names;
            foreach (string m in middles)
            {
                b.Append(m + " ");
            }
            b.Append(last);

            return b.ToString();
        }

    }

    public enum Sex
    {
        Male,
        Female
    }
