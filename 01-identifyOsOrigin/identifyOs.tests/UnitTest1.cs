using identifyOs.tests.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace identifyOs.tests;


public class UnitTest1
{
    private readonly HttpClient _clientTests;
    public UnitTest1()
    {
        _clientTests = new HttpClient();
        _clientTests.BaseAddress = new Uri("http://localhost:5087/api/");
    }

    [Fact]
    public async Task MyOs()
    {
        var response = await _clientTests.GetAsync("myos");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        Assert.NotNull(content);

        var myOs = JsonConvert.DeserializeObject<MyOsTests>(content);
        Assert.NotNull(myOs);
        Assert.IsType<MyOsTests>(myOs);
    }
}
