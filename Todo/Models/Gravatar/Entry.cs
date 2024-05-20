using System.Collections.Generic;

namespace Todo.Models.Gravatar
{
    public class Entry
    {
        public string DisplayName { get; set; }

    }

    public class GravatarInfo
    {
        public List<Entry> Entry { get; set; }
    }
}