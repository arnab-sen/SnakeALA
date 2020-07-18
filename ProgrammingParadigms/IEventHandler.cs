namespace ProgrammingParadigms
{
    public interface IEventHandler
    {
        object Sender { get; set; }

        void Subscribe(string eventName, object sender);
    }
}
