using System;
using System.Collections.Generic;

namespace ToDoList.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string RequesTaskName { get; set; }
        public bool Complete { get; set; } = false;
        public DateTime CompletedOn { get; set; }

        public void CompleteTask()
        {
            Complete = true;
            CompletedOn = DateTime.Now;
        }
    }

}