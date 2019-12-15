using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListMobile.Models
{
	public class Note
	{
		public string Header { get; set; }
		public DateTime DateAdded { get; set; }
		public string Text { get; set; }
		public string PriorityText { get; set; }
		public DateTime ReminderDate { get; set; }
	}
}
