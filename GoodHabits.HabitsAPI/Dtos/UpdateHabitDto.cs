namespace GoodHabits.HabitsAPI.Dtos;

public class UpdateHabitDto
{
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;
}