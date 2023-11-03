namespace GoodHabits.HabitsAPI.Dtos;

public class CreateHabitDto
{
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;
}