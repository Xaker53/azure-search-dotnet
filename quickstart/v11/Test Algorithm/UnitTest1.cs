using System.Text.Json;
using AzureSearchQuickstart_v11.Infrastructure;

namespace Test_Algorithm
{
    public class UnitTest1
    {

        private readonly string input = "ABA"; 
        [Fact]
        public void TestAlgorithmCharacterIndexing()
        {

            var sut = new AzureSearchQuickstart_v11.Services.Compression.CharacterIndexing();

            sut.Compression(input);
            var json = sut.OutText();
            var dict = JsonSerializer.Deserialize<Dictionary<string, List<int>>>(json)!;


            OutAlgorithm(dict);
        }

        [Fact]
        public void TestCallAlgorithm()
        {
            var compressor = CompressionRegistrationDI.Instance.TryGet("CharacterIndexing");
            compressor.Compression(input);
            OutAlgorithm(JsonSerializer.Deserialize<Dictionary<string, List<int>>>(compressor.OutText()));
        }

        public void OutAlgorithm(Dictionary<string, List<int>> dict)
        {
            Assert.Equal(3, dict["Text_size"][0]);
            Assert.Equal(new[] { 0, 2 }, dict["A"]);
            Assert.Equal(new[] { 1 }, dict["B"]);
        }
    }
}