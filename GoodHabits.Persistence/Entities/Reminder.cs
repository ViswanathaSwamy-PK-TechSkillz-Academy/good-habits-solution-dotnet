using Microsoft.EntityFrameworkCore;

using GoodHabits.Persistence.Enums;

namespace GoodHabits.Persistence.Entities;

[Index(nameof(Id))]
public class Reminder
{
    public int Id { get; set; }

    public Frequency Frequency { get; set; }

    public int HabitId { get; set; }

    public virtual Habit Habit { get; set; } = default!;
}
