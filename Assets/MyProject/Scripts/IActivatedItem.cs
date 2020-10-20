public interface IActivatedItem
{
    bool ReadyForActivation { get; }
    void Activate();
}