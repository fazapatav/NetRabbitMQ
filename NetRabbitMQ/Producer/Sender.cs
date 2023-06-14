using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost"
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare("fazQueue", false, false, false, null);

    var message = "Bienvenido faz";
    var body = Encoding.UTF8.GetBytes(message);

    var routingKey = "fazQueue";
    channel.BasicPublish("", routingKey, null, body);
    Console.WriteLine("el mensaje fue enviado {0}",message);
}

Console.WriteLine("Enter para terminar");
Console.ReadLine();