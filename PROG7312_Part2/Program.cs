namespace PROG7312_Part2
{
    internal class Program
    {
        static Dictionary<string, string> areaCodes = new Dictionary<string, string>();
        static Dictionary<string, string> userAreaCodes = new Dictionary<string, string>();
        static int count = 0;
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            /*  012 - Pretoria
                011 - Johannesburg
                031 - Durban
                014 - Rustenburg
                016 - Vereeniging
                021 - Cape Town
                018 - Potchefstroom
                057 - Welkom
             */
            //Add data
            areaCodes.Add("011","Johannesburg");
            areaCodes.Add("012","Pretoria");
            areaCodes.Add("031","Durban");
            areaCodes.Add("014","Rustenburg");
            areaCodes.Add("016","Vereeniging");
            areaCodes.Add("021","Cape Town");
            areaCodes.Add("057","Welkom");
            areaCodes.Add("018","Potchefstroom");

            //User answers
         
            userAreaCodes.Add("012", "Pretoria");
            userAreaCodes.Add("018", "Potchefstroom");
            userAreaCodes.Add("057", "Welkom");
            userAreaCodes.Add("014", "Rustenburg");
            userAreaCodes.Add("031", "Durban");
            userAreaCodes.Add("021", "Cape Town");
            userAreaCodes.Add("011", "Johannesburg");
            userAreaCodes.Add("016", "Vereeniging");

            //Access data
            Console.WriteLine(areaCodes["057"]);
            Console.WriteLine(areaCodes[key:("018")]);
            Console.WriteLine(areaCodes.ElementAt(2).Value);

            string searchKey = "014";
            if (areaCodes.TryGetValue(searchKey,out string area))
            {
                Console.WriteLine(area);
            }
            else
            {
                Console.WriteLine($"Area code ({searchKey}) not found");
            }

            Console.WriteLine("=======================");

            //update data
            //areaCodes["011"] = "Jozi";
            //areaCodes["043"] = "East London";
            //areaCodes.Remove("021");
            
            areaCodes = areaCodes.OrderBy(r => rnd.Next())
                .ToDictionary(codes => codes.Key, codes => codes.Value);

            Display(areaCodes);
            CheckAnswers();
         
            Console.WriteLine("====================");
            Console.WriteLine(count);
            Console.WriteLine(CheckUserAnswers());


        }
        /// <summary>
        /// Check user answers against the original values
        /// </summary>
        private static void CheckAnswers()
        {
            foreach (KeyValuePair<string, string> codes in areaCodes)
            {
                if (userAreaCodes.TryGetValue(codes.Key, out string value))
                {
                    if (codes.Value.Equals(value))
                    {
                        count++;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static bool CheckUserAnswers()
        {
            var original = areaCodes.OrderBy(code => code.Key).ToList();
            var userAnswers = userAreaCodes.OrderBy(code => code.Key).ToList();

            return original.SequenceEqual(userAnswers);
        }

        /// <summary>
        /// Display items from a Dictionary
        /// </summary>
        /// <param name="areaCodes">Dictionary to display from</param>
        private static void Display(Dictionary<string, string> areaCodes)
        {
            List<int> lsCheck = new();
            Console.WriteLine($"Q\t\tA\n------------------------------");
            while (lsCheck.Count < 7)
            {
                int index = rnd.Next(areaCodes.Count - 1);
                if (!lsCheck.Contains(index))
                {
                    if (lsCheck.Count < 4)
                    {
                        //display on the left
                        Console.Write(areaCodes.ElementAt(index).Key);
                    }
                    //display on the right
                    Console.WriteLine($"\t\t{areaCodes.ElementAt(index).Value}");
                    lsCheck.Add(index);
                }
            }


        
        }
    }
}