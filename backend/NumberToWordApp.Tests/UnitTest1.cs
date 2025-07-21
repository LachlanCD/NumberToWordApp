using Moq;
using Microsoft.AspNetCore.Mvc;
using NumberToWordApp.Controllers;
using NumberToWordApp.Services;
using NumberToWordApp.Models;

public class SampleTests
{
    [Fact]
    public void ConvertNumber_ReturnsBadRequest_WhenAmountIsInvalid()
    {
        var mockConverter = new Mock<NumberToWordsConverter>();
        var controller = new ConvertController(mockConverter.Object);
        var invalidRequest = new ConvertRequest { Amount = "not_a_number" };

        var result = controller.ConvertNumber(invalidRequest);

        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(400, badRequestResult.StatusCode);

        var value = Assert.IsType<ConvertResponse>(badRequestResult.Value);
        Assert.Equal("Invalid entry, please enter a number.", value.Result);
    }

    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultOneWithCents()
    {
        var mockConverter = new Mock<INumberToWordsConverter>();
        mockConverter.Setup(c => c.Convert(1.1m)).Returns("One dollar and ten cents.");

        var controller = new ConvertController(mockConverter.Object);
        var request = new ConvertRequest { Amount = "1.1" };

        var result = controller.ConvertNumber(request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ConvertResponse>(okResult.Value);
        Assert.Equal("One dollar and ten cents.", response.Result);
    }

    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultOne()
    {
        var mockConverter = new Mock<INumberToWordsConverter>();
        mockConverter.Setup(c => c.Convert(1m)).Returns("One dollar.");

        var controller = new ConvertController(mockConverter.Object);
        var request = new ConvertRequest { Amount = "1" };

        var result = controller.ConvertNumber(request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ConvertResponse>(okResult.Value);
        Assert.Equal("One dollar.", response.Result);
    }

    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultTeens()
    {
        var mockConverter = new Mock<INumberToWordsConverter>();
        mockConverter.Setup(c => c.Convert(12m)).Returns("Twelve dollars.");

        var controller = new ConvertController(mockConverter.Object);
        var request = new ConvertRequest { Amount = "12" };

        var result = controller.ConvertNumber(request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ConvertResponse>(okResult.Value);
        Assert.Equal("Twelve dollars.", response.Result);
    }

    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultHundred()
    {
        var mockConverter = new Mock<INumberToWordsConverter>();
        mockConverter.Setup(c => c.Convert(123.45m)).Returns("One hundred and twenty-three dollars and forty-five cents.");

        var controller = new ConvertController(mockConverter.Object);
        var request = new ConvertRequest { Amount = "123.45" };

        var result = controller.ConvertNumber(request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ConvertResponse>(okResult.Value);
        Assert.Equal("One hundred and twenty-three dollars and forty-five cents.", response.Result);
    }

    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultThousand()
    {
        var mockConverter = new Mock<INumberToWordsConverter>();
        mockConverter.Setup(c => c.Convert(1230.45m)).Returns("One thousand two hundred and thirty dollars and forty-five cents.");

        var controller = new ConvertController(mockConverter.Object);
        var request = new ConvertRequest { Amount = "1230.45" };

        var result = controller.ConvertNumber(request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ConvertResponse>(okResult.Value);
        Assert.Equal("One thousand two hundred and thirty dollars and forty-five cents.", response.Result);
    }
    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultMillion()
    {
        var mockConverter = new Mock<INumberToWordsConverter>();
        mockConverter.Setup(c => c.Convert(1230000.45m)).Returns("One million two hundred and thirty thousand dollars and forty-five cents.");

        var controller = new ConvertController(mockConverter.Object);
        var request = new ConvertRequest { Amount = "1230000.45" };

        var result = controller.ConvertNumber(request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ConvertResponse>(okResult.Value);
        Assert.Equal("One million two hundred and thirty thousand dollars and forty-five cents.", response.Result);
    }
    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultBillion()
    {
        var mockConverter = new Mock<INumberToWordsConverter>();
        mockConverter.Setup(c => c.Convert(1230000000.45m)).Returns("One billion two hundred and thirty million dollars and forty-five cents.");

        var controller = new ConvertController(mockConverter.Object);
        var request = new ConvertRequest { Amount = "1230000000.45" };

        var result = controller.ConvertNumber(request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ConvertResponse>(okResult.Value);
        Assert.Equal("One billion two hundred and thirty million dollars and forty-five cents.", response.Result);
    }

    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultNegative()
    {
        var mockConverter = new Mock<INumberToWordsConverter>();
        mockConverter.Setup(c => c.Convert(-1.1m)).Returns("Negative one dollars and ten cents.");

        var controller = new ConvertController(mockConverter.Object);
        var request = new ConvertRequest { Amount = "-1.1" };

        var result = controller.ConvertNumber(request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ConvertResponse>(okResult.Value);
        Assert.Equal("Negative one dollars and ten cents.", response.Result);
    }

    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultZero()
    {
        var mockConverter = new Mock<INumberToWordsConverter>();
        mockConverter.Setup(c => c.Convert(0m)).Returns("Zero dollars.");

        var controller = new ConvertController(mockConverter.Object);
        var request = new ConvertRequest { Amount = "0" };

        var result = controller.ConvertNumber(request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ConvertResponse>(okResult.Value);
        Assert.Equal("Zero dollars.", response.Result);
    }


    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultNegativeZero()
    {
        var mockConverter = new Mock<INumberToWordsConverter>();
        mockConverter.Setup(c => c.Convert(-0m)).Returns("Zero dollars.");

        var controller = new ConvertController(mockConverter.Object);
        var request = new ConvertRequest { Amount = "-0" };

        var result = controller.ConvertNumber(request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ConvertResponse>(okResult.Value);
        Assert.Equal("Zero dollars.", response.Result);
    }

    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultZeroWithCents()
    {
      var mockConverter = new Mock<INumberToWordsConverter>();
      mockConverter.Setup(c => c.Convert(0.55m)).Returns("Fifty-five cents.");

      var controller = new ConvertController(mockConverter.Object);
      var request = new ConvertRequest { Amount = "0.55" };

      var result = controller.ConvertNumber(request);

      var okResult = Assert.IsType<OkObjectResult>(result);
      var response = Assert.IsType<ConvertResponse>(okResult.Value);
      Assert.Equal("Fifty-five cents.", response.Result);
    }

    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultNegativeZeroWithCents()
    {
      var mockConverter = new Mock<INumberToWordsConverter>();
      mockConverter.Setup(c => c.Convert(-0.55m)).Returns("Negative fifty-five cents.");

      var controller = new ConvertController(mockConverter.Object);
      var request = new ConvertRequest { Amount = "-0.55" };

      var result = controller.ConvertNumber(request);

      var okResult = Assert.IsType<OkObjectResult>(result);
      var response = Assert.IsType<ConvertResponse>(okResult.Value);
      Assert.Equal("Negative fifty-five cents.", response.Result);
    }

    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultOneCent()
    {
      var mockConverter = new Mock<INumberToWordsConverter>();
      mockConverter.Setup(c => c.Convert(0.01m)).Returns("One cent.");

      var controller = new ConvertController(mockConverter.Object);
      var request = new ConvertRequest { Amount = "0.01" };

      var result = controller.ConvertNumber(request);

      var okResult = Assert.IsType<OkObjectResult>(result);
      var response = Assert.IsType<ConvertResponse>(okResult.Value);
      Assert.Equal("One cent.", response.Result);
    }

    [Fact]
    public void ConvertNumber_ReturnsOk_WithConvertedResultFiveCents()
    {
      var mockConverter = new Mock<INumberToWordsConverter>();
      mockConverter.Setup(c => c.Convert(0.05m)).Returns("Five cents.");

      var controller = new ConvertController(mockConverter.Object);
      var request = new ConvertRequest { Amount = "0.05" };

      var result = controller.ConvertNumber(request);

      var okResult = Assert.IsType<OkObjectResult>(result);
      var response = Assert.IsType<ConvertResponse>(okResult.Value);
      Assert.Equal("Five cents.", response.Result);
    }
}

