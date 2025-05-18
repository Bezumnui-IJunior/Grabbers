namespace StateMachines
{
    public interface ITransition
    {
        public bool TryTransit(out State nextState);
    }
}