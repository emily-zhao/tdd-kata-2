namespace StringCalculator;

public class StringCalculator
{
    private ILogger _logger;
    private IWebService _webService;

    public StringCalculator(ILogger logger, IWebService webService)
    {
        _logger = logger;
        _webService = webService;
    }

    public int Add(string numbers)
    {
        int response = 0;
        if (numbers == "") response = 0;
        else
        {
            response = numbers.Split(',').Select(int.Parse).Sum();
        }
        try
        {
            _logger.Log(response.ToString());
        }
        catch (Exception)
        {

            var message = $"Logger Failed, result is {response}";
            _webService.Notify(message);


        }
        return response;
    }
}

public interface IWebService
{
    void Notify(string message);
}

public interface ILogger
{
    void Log(string message);
}