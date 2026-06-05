namespace CurrencyService
{
    public class OrderService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public OrderService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public bool PlaceOrder(decimal amount, string currency)
        {
            return _paymentProcessor.ProcessPayment(amount, currency);
        }
    }
}