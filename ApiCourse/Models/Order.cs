namespace ApiCourse.Models
{
    public class Order
    {
        public string Uuid { get; } = Guid.NewGuid().ToString();
        public string Content { get; set; }
        public double Price { get; set; }

    }
}
