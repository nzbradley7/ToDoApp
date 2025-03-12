using Microsoft.AspNetCore.Mvc;
using ToDo.Contracts;
using ToDo.Application.Services;

namespace ToDo.Api.Controllers
{

    [Route("todo")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public ToDoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPost("add")]
        public IActionResult AddItem(TodoRequest todoRequest)
        {
            var newItem = _todoService.AddTodo(todoRequest.Name).TodoItem;
            return Ok(new TodoResponse(newItem.Id, newItem.Name, newItem.Created, newItem.IsCompleted));
        }

        [HttpPatch("edit")]
        public IActionResult EditItem(TodoRequest todoRequest)
        {
            var amendedItem = _todoService.EditTodo(todoRequest.Id, todoRequest.Name).TodoItem;
            return Ok(new TodoResponse(amendedItem.Id, amendedItem.Name, amendedItem.Created, amendedItem.IsCompleted));
        }

        [HttpPatch("complete")]
        public IActionResult CompleteItem(TodoRequest todoRequest)
        {
            var amendedItem = _todoService.MarkCompleted(todoRequest.Id).TodoItem;
            return Ok(new TodoResponse(amendedItem.Id, amendedItem.Name, amendedItem.Created, amendedItem.IsCompleted));
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            var itemList = new List<TodoResponse>();
            _todoService.GetTodos().TodoItem.ForEach(item => itemList.Add(new TodoResponse(item.Id, item.Name, item.Created, item.IsCompleted)));
            return Ok(itemList);
        }
    }
}
