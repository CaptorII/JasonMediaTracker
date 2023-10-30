using System;
using System.Collections.Generic;
using System.Text;

namespace JasonMediaTracker.Models
{
    public class Media
    {
        internal string title;
        internal bool isCompleted = false;
        internal DateTime releaseDate;
        public Media[] uncompleted;
        public Media[] unreleased;
        public Media[] completed;

        public void MarkCompleted()
        {
            isCompleted = true;
        }

        public void MarkUncompleted()
        {
            isCompleted = false;
        }
    }
}
