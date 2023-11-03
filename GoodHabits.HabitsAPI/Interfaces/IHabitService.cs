using GoodHabits.Persistence.Entities;

namespace GoodHabits.HabitsAPI.Interfaces;

public interface IHabitService
{
    Task<Habit> Create(string name, string description);

    Task<Habit> GetById(int id);

    Task<IReadOnlyList<Habit>> GetAll();
}