using System.Text.Json;
using AzureSearchQuickstart_v11;
namespace Test_Algorithm
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            var sut = new CharacterIndexing();
            var input = "ABA";


            sut.Compression(input);
            var json = sut.OutText();
            var dict = JsonSerializer.Deserialize<Dictionary<string, List<int>>>(json)!;


            Assert.Equal(3, dict["Text_size"][0]);       
            Assert.Equal(new[] { 0, 2 }, dict["A"]);
            Assert.Equal(new[] { 1 }, dict["B"]);
        }
    }
}