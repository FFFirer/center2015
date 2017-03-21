using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class student
    {
        private string name;
        private string password;
        private string sex;
        private string telephoneNum;
        private string id;
        private string birth;
        private string homeTown;
        private string majorName;
        private string className;
        private string entranceYear;
        private string homeAddress;

        public string Name {
            set { name = value; }
            get { return name; }
        }
        public string Password
        {
            set { password = value; }
            get { return password; }
        }
        public string Sex
        {

            set { sex = value; }
            get { return sex; }
        }
        public string TelephoneNum
        {

            set { telephoneNum = value; }
            get { return telephoneNum; }
        }
        public string ID
        {

            set { id = value; }
            get { return id; }
        }
        public string Birth
        {

            set { birth = value; }
            get { return birth; }
        }
        public string HomeTown
        {

            set { homeTown = value; }
            get { return homeTown; }
        }
        public string MajorName
        {

            set { majorName = value; }
            get { return majorName; }
        }
        public string ClassName
        {

            set { className = value; }
            get { return className; }
        }
        public string EntranceYear
        {

            set { entranceYear = DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Day.ToString(); }
            get { return entranceYear; }
        }
        public string HomeAddress
        {

            set { homeAddress = value; }
            get { return homeAddress; }
        }
    }
}
