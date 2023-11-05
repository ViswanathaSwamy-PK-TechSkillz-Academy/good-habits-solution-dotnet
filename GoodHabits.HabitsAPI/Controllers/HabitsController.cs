using AutoMapper;
using GoodHabits.HabitsAPI.Dtos;
using GoodHabits.HabitsAPI.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GoodHabits.HabitsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HabitsController : ControllerBase
{
    private readonly ILogger<HabitsController> _logger;
    private readonly IHabitService _habitService;
    private readonly IMapper _mapper;

    public HabitsController(ILogger<HabitsController> logger, IHabitService habitService, IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _habitService = habitService ?? throw new ArgumentNullException(nameof(habitService));

        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id) =>
      Ok(_mapper.Map<HabitDto>(await _habitService.GetById(id)));

    [HttpGet]
    public async Task<IActionResult> GetAsync() =>
      Ok(_mapper.Map<ICollection<HabitDto>>(await _habitService.GetAll()));

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateHabitDto request) =>
        Ok(await _habitService.Create(request.Name, request.Description));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _habitService.DeleteById(id);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateHabitDto request)
    {
        var habit = await _habitService.UpdateById(id, request);

        return habit is null ? NotFound() : Ok(habit);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] JsonPatchDocument<UpdateHabitDto> patch)
    {
        var habit = await _habitService.GetById(id);

        if (habit is null)
        {
            return NotFound();
        }

        var updateHabitDto = new UpdateHabitDto
        {
            Name = habit.Name,
            Description = habit.Description
        };

        try
        {
            patch.ApplyTo(updateHabitDto, ModelState);

            if (!TryValidateModel(updateHabitDto))
            {
                return ValidationProblem(ModelState);
            }

            await _habitService.UpdateById(id, updateHabitDto);

            return NoContent();
        }
        catch (JsonPatchException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

}