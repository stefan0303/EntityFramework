namespace JSONProcessing
{
    public interface IExecutable<out T>
    {
        T Execute();
    }
}