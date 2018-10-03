using Newtonsoft.Json;

namespace iRacing_League_Scoring.Models {
    public class Driver 
    {
        public long Id { get; set;}
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }   

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}