namespace SimpleArchiteture.Data.Interfaces;

public interface IUnitofWork
{
    Task CompleteAsync();

    IRentCarRepository CarRepository { get; }
}
