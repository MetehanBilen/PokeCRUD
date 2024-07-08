using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Sinks.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace z.Fellowship.CrossCuttingConcerns.Serilog.Logger;

public class RabbitMQLogger : LoggerServiceBase
{
    private readonly IConfiguration _configuration;

    public RabbitMQLogger(IConfiguration configuration)
    {
        _configuration = configuration;

       List<string> HostsName = new List<string>();
        HostsName.Add("localhost");

        Logger = new LoggerConfiguration()
            .WriteTo.RabbitMQ((clientConfiguration, sinkConfiguration) =>
            {
                clientConfiguration.Username = "guest";
                clientConfiguration.Password = "guest";
                clientConfiguration.Exchange = "log-Exchange-0807";
                clientConfiguration.ExchangeType = "direct";
                clientConfiguration.DeliveryMode = RabbitMQDeliveryMode.NonDurable;
                clientConfiguration.RouteKey = "PokeLog";
                clientConfiguration.Port = 5672;
                clientConfiguration.Hostnames = HostsName.ToList();
                sinkConfiguration.RestrictedToMinimumLevel = LogEventLevel.Information;
                sinkConfiguration.TextFormatter = new RenderedCompactJsonFormatter();
            })
            .CreateLogger();
    }
}