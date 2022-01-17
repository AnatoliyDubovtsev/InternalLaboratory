using System;

namespace Module9.Task3
{
    public static class ExampleRun
    {
        public static void Task3Run()
        {
            Laptop laptopAlmaty = new("Laptop", "Model 7");
            Laptop laptopAktau = new("Laptop", "Model 7");
            MobilePhone mobilePhoneAlmaty = new("Mobile phone", "Model 3");
            MobilePhone mobilePhoneAktau = new("Mobile phone", "Model 5");
            Client clientFromAlmaty = new(mobilePhoneAlmaty, laptopAlmaty);
            Client clientFromAktau = new(mobilePhoneAktau, laptopAktau);
            Countdown countdown = new();

            countdown.Subscribe(clientFromAlmaty.MobilePhone.GetMessage);
            countdown.Subscribe(clientFromAlmaty.Laptop.GetMessage);
            countdown.Subscribe(clientFromAktau.MobilePhone.GetMessage);
            countdown.SendMessages(2, "Good morning, colleagues!");

            Console.WriteLine(Environment.NewLine);

            countdown.Unsubscribe(clientFromAlmaty.MobilePhone.GetMessage);
            countdown.SendMessages(3, "Good evening, colleagues!");
        }
    }
}
