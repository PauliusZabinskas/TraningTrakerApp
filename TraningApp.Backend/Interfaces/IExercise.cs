namespace TraningApp.Backend.Interfaces;

public interface IExercise<T>
{
    Task AddNew(T exercise);
}