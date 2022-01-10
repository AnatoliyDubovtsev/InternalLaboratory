namespace Module9.Task3
{
    public abstract class Device
    {
        public string Company { get; set; }
        public string Model { get; set; }

        protected Device(string company, string model)
        {
            Company = company;
            Model = model;
        }
    }
}
