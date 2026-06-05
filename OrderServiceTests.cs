using Moq;
using Xunit;

namespace CurrencyService.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void PlaceOrder_ShouldVerifyPaymentProcessorInteraction_WithCorrectParameters()
        {
            decimal testAmount = 250.50m;
            string testCurrency = "PLN";

            var mockPaymentProcessor = new Mock<IPaymentProcessor>();

            mockPaymentProcessor
                .Setup(p => p.ProcessPayment(testAmount, testCurrency))
                .Returns(true);

            var orderService = new OrderService(mockPaymentProcessor.Object);

            bool result = orderService.PlaceOrder(testAmount, testCurrency);

            Assert.True(result);

            mockPaymentProcessor.Verify(
                p => p.ProcessPayment(testAmount, testCurrency),
                Times.Once,
                "B³¹d: Metoda ProcessPayment nie zosta³a wywo³ana dok³adnie raz z oczekiwanymi parametrami."
            );
        }
    }
}