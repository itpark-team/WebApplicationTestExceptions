using Microsoft.AspNetCore.Mvc;
using WebApplicationTestExceptions.Dtos;
using WebApplicationTestExceptions.Entities;
using WebApplicationTestExceptions.Exceptions;
using WebApplicationTestExceptions.Services;

namespace WebApplicationTestExceptions.Controllers;

[ApiController]
[Route("toys/")]
public class ToysController : ControllerBase
{
    private IToysService _toysService;
    private ILogger<ToysController> _logger;

    public ToysController(IToysService toysService, ILogger<ToysController> logger)
    {
        _toysService = toysService;
        _logger = logger;
    }

    [HttpGet("get-all")]
    public List<Toy> GetAll()
    {
        _logger.LogInformation("GetAll Called");
        return _toysService.GetAll();
    }

    [HttpGet("get-by-name/{name}")]
    public Toy GetByName(string name)
    {
        return _toysService.GetByName(name);
    }

    [HttpGet("get-toys-count")]
    public int GetToysCount()
    {
        return _toysService.GetToysCount();
    }

    [HttpPost("add-new-toy")]
    public void AddNewToy(Toy toy)
    {
        _toysService.AddNewToy(toy);
    }

    // [HttpGet("get-by-name/{name}")]
    // public IActionResult GetByName(string name)
    // {
    //     try
    //     {
    //         return Ok(_toysService.GetByName(name));
    //     }
    //     catch (UserException e)
    //     {
    //         ExceptionResponseDto exceptionDto = new ExceptionResponseDto()
    //         {
    //             Code = e.Code,
    //             Title = e.Title,
    //             Message = e.Message
    //         };
    //         return StatusCode(400, exceptionDto);
    //     }
    //     catch (Exception e)
    //     {
    //         ExceptionResponseDto exceptionDto = new ExceptionResponseDto()
    //         {
    //             Code = 501,
    //             Title = "Unhandled message",
    //             Message = e.Message
    //         };
    //         return StatusCode(501, exceptionDto);
    //     }
    // }
}