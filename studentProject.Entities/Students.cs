using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using studentProject.Model;

namespace studentProject.Entities
{
    public class Students : BaseEntity
    {
        Hashtable StudentsTbl = new Hashtable();
        Student student = new Student();
        public object ReadFromDb(SqlDataReader reader)
        {
            //Clear Hashtable Before Inserting Information From Sql Server
            StudentsTbl.Clear();
            

            while (reader.Read()) // read information from DB and handle this to hashtable
            {
               
                student.Name = reader.GetString(reader.GetOrdinal("Name"));
                student.Age = reader.GetInt32(reader.GetOrdinal("Age"));
                student.Address = reader.GetString(reader.GetOrdinal("Address"));
                student.Id = reader.GetInt32(reader.GetOrdinal("ID"));

                if (!(StudentsTbl[student.Id] is Student))
                {
                    StudentsTbl.Add(student.Id, student);

                }
                
            }
            return StudentsTbl;
        }

        public string checkID(string ID)
        {
            if (StudentsTbl[int.Parse(ID)] is Student)
            {
                Student newStudent= (Student)StudentsTbl[int.Parse(ID)];
                string result = $"{newStudent.Name}, {newStudent.Address},{newStudent.Age}";
                return result;
            }
            return "the student doesnt exsit";
        }

        public Hashtable AddStudentHash()
        {
            Hashtable hashTblStudent;
            try
            {
                hashTblStudent = (Hashtable)Dal.SqlQuery.RunResCommand("select ID,Address,Name,Age from students", ReadFromDb);
                return hashTblStudent;

            }
            catch (Exception Ex)
            {
                return null;
            }

        }

       

        public void UpdateData(int id, int age, string name, string address)
        {
            Dal.SqlQuery.runCommand($"insert into studentDB (ID,Name,Address,Age) values ({id} ,{age}, '{name}', '{address}'");
        }

    }
}
