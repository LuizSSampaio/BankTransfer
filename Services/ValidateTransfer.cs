namespace BankTransfer.Services;

public static class ValidateTransfer
{
    public static async Task<bool> Check()
    {
        var client = new HttpClient();
        try
        {
            var response = await client.PostAsync("https://run.mocky.io/v3/5794d450-d2e2-4412-8131-73d0293ac1cc", null);
            var content = await response.Content.ReadAsStringAsync();
        
            return content.Contains("Autorizado");
        }
        catch
        {
            return false;
        }
    }
}