using AutoMapper;
using GoodHabits.HabitsAPI.Dtos;
using GoodHabits.HabitsAPI.Interfaces;
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
}