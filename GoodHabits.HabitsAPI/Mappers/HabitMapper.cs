using AutoMapper;
using global::GoodHabits.HabitsAPI.Dtos;
using global::GoodHabits.Persistence.Entities;

namespace GoodHabits.HabitsAPI.Mappers;

public class HabitMapper : Profile
{
    public HabitMapper()
    {
        CreateMap<Habit, HabitDto>();
    }
}