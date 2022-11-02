using ElearnnerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearnnerApi
{
    public class AutoGenerate
    {
        
        public static List<Kindd> GenerateKindTopics()
        {
            var kindTopics = new List<Kindd>();
            kindTopics.Add(new Kindd { Kind = "1-1" });
            kindTopics.Add(new Kindd { Kind = "1-2" });
            return kindTopics;
        }
    }
}
