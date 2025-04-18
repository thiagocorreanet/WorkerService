namespace WorkerService.Worker;

public class ProcessamentoPedidosWorker : BackgroundService
{
    private readonly ILogger<ProcessamentoPedidosWorker> _logger;

    public ProcessamentoPedidosWorker(ILogger<ProcessamentoPedidosWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("ProcessamentoPedidosWorker starting.");
            await Task.Delay(5000, stoppingToken);
        }
        
    }
}

public class ProcessamentoPedidosWorkerV2 : BackgroundService
{
    private readonly ILogger<ProcessamentoPedidosWorker> _logger;

    public ProcessamentoPedidosWorkerV2(ILogger<ProcessamentoPedidosWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        TimeSpan intervalo = TimeSpan.FromSeconds(10);
        using PeriodicTimer timer = new(intervalo);

        while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
        {
            _logger.LogInformation($"Processamento de pedidos - {DateTime.Now.TimeOfDay.ToString()}");
            await Task.Delay(5000, stoppingToken);
        }

    }
}