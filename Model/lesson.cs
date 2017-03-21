using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class lesson
    {
        private string  lessonCode;
        private string lessonName;
        private string lessonTeacher;
        private string lessonTime;
        private string lessonTeam;
        private string lessonAddress;
        private string lessonStartTime;
        private string lessonEndTime;

        public string LessonCode
        {
            set { lessonCode = value; }
            get { return lessonCode; }
        }
        public string LessonName
        {
            set { lessonName = value; }
            get { return lessonName; }
        }
        public string LessonTeacher
        {
            set { lessonTeacher = value; }
            get { return lessonTeacher; }
        }
        public string LessonTime
        {
            set { lessonTime = value; }
            get { return lessonTime; }
        }
        public string LessonTeam
        {
            set { lessonTeam = value; }
            get { return lessonTeam; }
        }
        public string LessonAddress
        {
            set { lessonAddress = value; }
            get { return lessonAddress; }
        }
        public string LessonStartTime
        {
            set { lessonStartTime = value; }
            get { return lessonStartTime; }
        }
        public string LessonEndTime
        {
            set { lessonEndTime = value; }
            get { return lessonEndTime; }
        }
    }
}
