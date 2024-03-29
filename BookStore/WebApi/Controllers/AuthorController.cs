using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DbOperations;

namespace WebApi.Controllers;

[Route("[controller]s")]
[ApiController]

public class AuthorController : ControllerBase
{
    private readonly BookStoreDbContext _context;

    private readonly IMapper _mapper;

    public AuthorController(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult GetAuthor()
    {
        GetAuthorQuery query = new GetAuthorQuery(_context, _mapper);
        
        var result = query.Handle();
        
        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult GetAuthorDetail(int id)
    {
        GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
        
        query.AuthorId = id;
        
        GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
        
        validator.ValidateAndThrow(query);
        
        var result = query.Handle();
        
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] CreateAuthorModel author)
    {
        CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
        
        command.Model = author;
        
        CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
        
        validator.ValidateAndThrow(command);
        
        command.Handle();
        
        return Ok();

    }

    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel author)
    {
        UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
        
        command.AuthorId = id;

        command.Model = author;
        
        UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
        
        validator.ValidateAndThrow(command);
        
        command.Model = author;
        
        command.Handle();
        
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
        
        command.AuthorId = id;
        
        DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
        
        validator.ValidateAndThrow(command);
        
        command.Handle();
        
        return Ok();
    }
}