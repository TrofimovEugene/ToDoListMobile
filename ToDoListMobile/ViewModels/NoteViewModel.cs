using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ToDoListMobile.Annotations;
using ToDoListMobile.Models;

namespace ToDoListMobile.ViewModels
{
	public class NoteViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private NotesListViewModel lvm;
		public Note note { get; private set; }

		public NoteViewModel()
		{
			note = new Note();
			note.DateAdded = DateTime.Now;
		}

		public NotesListViewModel ListViewModel
		{
			get { return lvm; }
			set
			{
				if (lvm != value)
				{
					lvm = value;
					OnPropertyChanged("ListViewModel");
				}
			}
		}

		public string Header
		{
			get { return note.Header; }
			set
			{
				if (note.Header != value)
				{
					note.Header = value;
					OnPropertyChanged("Header");
				}
			}
		}

		public string DateAddedToString
		{
			get { return note.DateAdded.ToString(); }
		}

		public DateTime DateAdded
		{
			get { return note.DateAdded; }
			set
			{
				if (note.DateAdded != value)
				{
					note.DateAdded = value;
					OnPropertyChanged("DateAdded");
				}
			}
		}
		public string Text
		{
			get { return note.Text; }
			set
			{
				if (note.Text != value)
				{
					note.Text = value;
					OnPropertyChanged("Text");
				}
			}
		}
		public string PriorityText
		{
			get { return note.PriorityText; }
			set
			{
				if (note.PriorityText != value)
				{
					note.PriorityText = value;
					OnPropertyChanged("PriorityText");
				}
			}
		}

		public string ReminderDateToString
		{
			get { return note.ReminderDate.ToString(); }
		}

		public DateTime ReminderDate
		{
			get { return note.ReminderDate; }
			set
			{
				if (note.ReminderDate != value)
				{
					note.ReminderDate = value;
					OnPropertyChanged("ReminderDate");
				}
			}
		}


		[NotifyPropertyChangedInvocator]
		protected void OnPropertyChanged(string propName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
		}
	}
}
