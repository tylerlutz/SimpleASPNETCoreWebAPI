﻿using System.Collections.Generic;

namespace LearningWebAPI.Model
{
    public class GetUserModel
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total {get; set; }
        public int total_pages { get; set; }
        public IEnumerable<DataModel> data { get; set; }
    }

    public class DataModel
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }
}
