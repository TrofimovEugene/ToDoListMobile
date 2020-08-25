using System;
using Newtonsoft.Json;

namespace ToDoListMobile.Api.Shared
{
    public class NoteModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("header")]
        public string Header { get; set; }
        [JsonProperty("dateAdded")]
        public DateTime DateAdded { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        //public UserModel User{ get; set; }
    }
}