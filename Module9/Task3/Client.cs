namespace Module9.Task3
{
    public class Client
    {
        public Laptop Laptop { get; set; }
        public MobilePhone MobilePhone { get; set; }
        
        public Client(MobilePhone mobilePhone = null, Laptop laptop = null)
        {
            Laptop = laptop;
            MobilePhone = mobilePhone;
        }
    }
}
