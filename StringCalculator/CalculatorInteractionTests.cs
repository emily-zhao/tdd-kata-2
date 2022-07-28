

using Moq;

namespace StringCalculator;

public class CalculatorInteractionTests
{

    

    [Theory]
    [InlineData("1,2", "3")]
    [InlineData("1,2,3,4,5,6,7,8,9", "45")]
    public void ResultIsLogged(string numbers, string loggedMessage)
    {
        // Given
        var mockedLogger = new Mock<ILogger>();
        var calculator = new StringCalculator(mockedLogger.Object, new Mock<IWebService>().Object);
        // When
        calculator.Add(numbers);

        // Then
        // ??? HOW WILL I KNOW IT GOT LOGGED??
        mockedLogger.Verify(m => m.Log(loggedMessage));
    }

    [Fact]
    public void LoggerThrowsWebServiceIsCalled()
    {
        /// Given
        var stubbedLogger = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(stubbedLogger.Object, mockedWebService.Object);
        stubbedLogger.Setup(m => m.Log(It.IsAny<string>()))
            .Throws(new Exception());
        // when
        calculator.Add("1");
        // then
        // ?? 
        mockedWebService.Verify(m => m.Notify("Logger Failed, result is 1"));
    }

    [Fact]
    public void WebServiceNotCalledWithWorkingLogger()
    {
        /// Given
       
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(new Mock<ILogger>().Object, mockedWebService.Object);
     
        // when
        calculator.Add("1");
        // then
        // ?? 
        mockedWebService.Verify(m => m.Notify(It.IsAny<string>()),Times.Never);
    }
}
