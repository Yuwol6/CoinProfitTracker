using System.Net.Http;
using System.Text.Json;

Console.WriteLine("Hello, World!");

const string bitCoin = "BTC";
const decimal tradingFee = 0.001m;
string url = $"https://www.coinspot.com.au/pubapi/v2/latest/{bitCoin}";

using var http = new HttpClient();
string jsonText = await http.GetStringAsync(url);

Console.WriteLine(jsonText);

using JsonDocument doc = JsonDocument.Parse(jsonText);
JsonElement root = doc.RootElement;
string status = root.GetProperty("status").ToString();

Console.WriteLine($"Status from JSON: {status}");

JsonElement prices = root.GetProperty("prices");
string ask = prices.GetProperty("ask").ToString();
Console.WriteLine(ask);