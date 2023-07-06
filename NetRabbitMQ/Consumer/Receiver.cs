using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "fazapatav",
    Password = "as123456",
};
Console.WriteLine("iniciando lectura");
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare("fazQueue", false, false, false, null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.Span;
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($"mensaje recibido {message}");

        //para consumir "eliminar" el mensaje
        channel.BasicConsume("fazQueue", true, consumer);
        Console.WriteLine("Presiona enter para salir");
        Console.ReadLine();
    };


}