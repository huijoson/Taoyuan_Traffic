using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.Alert
{
    public class PublicSub
    {

        public class Author
        {
            public string name { get; set; }
        }

        public class Link
        {
            public string rel { get; set; }
            public string href { get; set; }
        }

        public class Summary
        {
            public string type { get; set; }
            public string text { get; set; }
        }

        public class Category
        {
            public string term { get; set; }
        }
    }
}