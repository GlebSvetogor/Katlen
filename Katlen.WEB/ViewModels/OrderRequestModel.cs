namespace Katlen.WEB.ViewModels
{
    public class OrderRequestModel
    {
        // Контактная информация
        public ContactInfo Contact { get; set; }

        // Способ доставки
        public DeliveryInfo Delivery { get; set; }

        // Способ оплаты
        public PaymentInfo Payment { get; set; }
    }

    public class ContactInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class DeliveryInfo
    {
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public string PostalCode { get; set; }
    }

    public class PaymentInfo
    {
        public bool BankCard { get; set; }
        public bool CashOnDelivery { get; set; }
    }
}
