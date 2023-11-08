using GoodHabits.HabitsAPI.Dtos;
using GoodHabits.Persistence.Entities;

namespace GoodHabits.HabitsAPI.Interfaces;

public interface IHabitService
{
    Task<Habit> Create(string name, string description);

    Task<Habit> GetById(int id);

    Task<IReadOnlyList<Habit>> GetAll();

    Task DeleteById(int id);

    Task<Habit?> UpdateById(int id, UpdateHabitDto request);
}