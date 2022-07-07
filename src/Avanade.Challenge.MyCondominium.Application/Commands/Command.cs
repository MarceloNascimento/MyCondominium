namespace Avanade.Challenge.MyCondominium.Application.Commands
{
    public abstract class Command
    {
        public abstract Task<bool> Execute();
    }
}