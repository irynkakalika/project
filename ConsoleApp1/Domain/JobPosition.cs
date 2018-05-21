namespace ConsoleApp1.Domain
{
    public class JobPosition
    {
        public int id { get; set;  }
        public string name { get; set; }

        public JobPosition(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}