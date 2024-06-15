using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory() { HostName = "localhost", UserName = "logUser", Password = "logPwd", VirtualHost = "EnterpriseLog" };

using(var connection = factory.CreateConnection())
using(var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "nova-fila",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
    string message = "Hello World!";
    var body = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(exchange: "",
                         routingKey: "nova-fila",
                         basicProperties: null,
                         body: body);
}