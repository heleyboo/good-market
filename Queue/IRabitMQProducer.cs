namespace GoodMarket.Queue;

public interface IRabitMQProducer
{
    public void SendProductMessage < T > (T message);
}