using System;
using System.Net;
using System.Threading.Tasks;

class webserver
{
    public int port;

    public webserver(int port)
    {
        this.port = port;
        Start("http://localhost:" + port.ToString() + "/");
    }

    private HttpListener listener;

    public void Start(string url)
    {
        listener = new HttpListener();
        listener.Prefixes.Add(url);
        listener.Start();
        Console.WriteLine($"Server started and listening at {url}");

        // Start a new task to handle incoming requests
        Task.Run(() => HandleIncomingRequests());
    }

    private async Task HandleIncomingRequests()
    {
        while (listener.IsListening)
        {
            var context = await listener.GetContextAsync();
            var request = context.Request;
            var response = context.Response;

            // Process the request and generate a response
            string responseString = "<html><body><h1>Hello, World!</h1></body></html>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            response.ContentType = "text/html";

            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }
    }
}
