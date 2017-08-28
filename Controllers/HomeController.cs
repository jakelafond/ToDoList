using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly todolistContext _context;

        public HomeController(todolistContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View(_context.ToDos.ToList());
        }

        public IActionResult Seed()
        {
            var seedToDos = new List<ToDoModel>(){
                new ToDoModel{
                        RequesTaskName = "Wash car",
                    },
                    new ToDoModel{
                        RequesTaskName = "Clean house",
                    },
                    new ToDoModel{
                        RequesTaskName = "Watch videos",
                    },
                    new ToDoModel{
                        RequesTaskName = "Code all the things",
                    }
            };

            seedToDos.ForEach(todo => _context.ToDos.Add(todo));

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult Index(string newToDo)
        {
            var toDo = new ToDoModel
            {
                RequesTaskName = newToDo
            };
            _context.ToDos.Add(toDo);
            _context.SaveChanges();
            return View(_context.ToDos.ToList());
        }

        public IActionResult Complete(int id)
        {
            var toDo = _context.ToDos.FirstOrDefault(i => i.Id == id);
            toDo.CompleteTask();
            _context.SaveChanges();
            return Redirect("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
