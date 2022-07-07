namespace Avanade.Challenge.MyCondominium.Application.Commands
{
    public abstract class ListCommand<T> where T : class
    {
        public abstract Task<T> Execute();
    }

    public abstract class DeleteCommand<T> where T : struct
    {
        public abstract Task<T> Execute(int id);
    }

    public abstract class SaveOrUpdateCommand<T> where T : class
    {
        public abstract Task<T> Execute(T param);
    }
}