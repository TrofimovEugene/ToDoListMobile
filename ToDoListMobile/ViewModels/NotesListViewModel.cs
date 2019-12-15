using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using ToDoListMobile.Annotations;
using ToDoListMobile.Views;
using Xamarin.Forms;

namespace ToDoListMobile.ViewModels
{
	public class NotesListViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<NoteViewModel> notes { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand CreateNoteCommand { protected set; get; }
		public ICommand UpdateNoteCommand { protected set; get; }
		public ICommand DeleteNoteCommand { protected set; get; }
		public ICommand SaveNoteCommand { protected set; get; }
		public ICommand BackNoteCommand { protected set; get; }

		NoteViewModel selectedNote;
		DateTime selectedDate;

		public INavigation Navigation { get; set; }

		public NotesListViewModel()
		{
			notes = new ObservableCollection<NoteViewModel>();
			CreateNoteCommand = new Command(CreateNote);
			DeleteNoteCommand = new Command(DeleteNote);
			SaveNoteCommand = new Command(SaveNote);
			BackNoteCommand = new Command(Back);
		}

		public NoteViewModel SelectedNote
		{
			get { return selectedNote; }
			set
			{
				if (selectedNote != value)
				{
					NoteViewModel tempNote = value;
					selectedNote = null;
					OnPropertyChanged("SelectedNote");
					Navigation.PushAsync(new NotePage(tempNote));
				}
			}
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void CreateNote()
		{
			NoteViewModel noteView = new NoteViewModel() {ListViewModel = this};
			Navigation.PushAsync(new NotePage(noteView));
			notes.Add(noteView);
		}

		private void Back()
		{
			Navigation.PopAsync();
		}

		private void SaveNote(object noteObject)
		{
			Back();
		}

		private void DeleteNote(object noteObject)
		{
			NoteViewModel note = noteObject as NoteViewModel;
			if (note != null)
			{
				notes.Remove(note);
			}
			Back();
		}
	}
}
