using System;

namespace LearningWebAPI.Model
{
    public class CreateUserModel
    {
        public string name { get; set; }
        public string job { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
    }
}
