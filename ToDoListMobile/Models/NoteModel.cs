using System;

namespace ToDoListMobile.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public DateTime DateAdded { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        //public UserModel User{ get; set; }
    }
}