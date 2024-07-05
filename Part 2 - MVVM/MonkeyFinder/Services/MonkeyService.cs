using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService
{

    HttpClient client;
    public MonkeyService()
    {
        client = new HttpClient();
    }

    List<Monkey> monkeys = new ();
    public async Task<List<Monkey>> GetMonkeys(){
        if(monkeys.Count == 0){
            var response = await client.GetAsync("https://montemagno.com/monkeys.json");
            if(response.IsSuccessStatusCode){
                monkeys = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            }
        }
        return monkeys;
    }
}
