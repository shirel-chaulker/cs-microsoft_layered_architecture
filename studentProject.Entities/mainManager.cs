using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentProject.Entities
{
    public class mainManager
    {
        private mainManager () { }
        private readonly static mainManager _instance = new mainManager ();
        public static mainManager INSTANCE
        {
            get { return _instance; }
        }

        
        public Students students = new Students();

        public void init()
        {
            students.AddStudentHash();

        }

        public void insertTOTbl(string name,string age,string id,string address)
        {
            students.UpdateData(int.Parse(id),int.Parse(age), name,address);
        }

        public string check(string ID)
        {
             return students.checkID(ID);
        }
    }
}
