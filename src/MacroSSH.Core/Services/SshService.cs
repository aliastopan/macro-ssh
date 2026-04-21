using Renci.SshNet;

namespace MacroSSH.Core.Services;

public sealed class SshService
{
    private const string Host =  "10.14.4.5";
    private const int Port = 21112;
    private const string Username = "amir.hamzah";
    private const string Password = "Ah@2021+";
   

    public async Task<string> LoginSsh()
    {
       return await Task.Run(() => 
       {
            try
            {
                using var client = new SshClient(Host, Port, Username, Password);

                client.Connect();

                if (!client.IsConnected)
                  return "Gagal: Koneksi tidak stabil";

                  var result = $"Berhasil: Login ke {Host} sebagai {Username}";

                  client.Disconnect();

                  return result;
            }
            catch (Exception ex)
           {
               return $"Error: {ex.Message}";
           }
        });
    }
}