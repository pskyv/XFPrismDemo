using SQLite;
using System;

namespace XFPrismDemo.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Text { get; set; }

        public string SubText
        {
            get
            {
                if (string.IsNullOrEmpty(Text))
                {
                    return "";
                }
                else
                {
                    if (Text.Length > 15)
                    {
                        return Text.Substring(0, 15) + "...";
                    }

                    return Text;
                }
            }
        }

        public string ListHeader
        {
            get { return CreatedAt.ToString("MMMM") + ", " + CreatedAt.Year.ToString(); }
        }
    }
}
