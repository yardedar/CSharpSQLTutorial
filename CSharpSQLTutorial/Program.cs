using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using EdDbLibrary;

namespace CSharpSQLTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var majorsCtrl = new MajorsController();
            var major = majorsCtrl.GetByPk(1);
            Console.WriteLine(major);

            var majors = majorsCtrl.GetAll();
            foreach(var maj in majors)
            {
                Console.WriteLine(maj);
            }
        }
        static void x()
        {
            var connStr = "server=localhost\\sqlexpress;database=EdDB;trusted_connection=true;";
            var sqlConn = new SqlConnection(connStr);
            sqlConn.Open();
            if (sqlConn.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connection did not open");
                return;
            }
            Console.WriteLine("Connection opened.");

            var sql = "Select * from Student " +
                " where gpa between 2.5 and 3.5 " +
                " order by sat desc;";
            var cmd = new SqlCommand(sql, sqlConn);
            var reader = cmd.ExecuteReader();
            var students = new List<Student>();
            while (reader.Read())
            {
                var student = new Student();
                student.Id = Convert.ToInt32(reader["Id"]);
                student.FirstName = reader["FirstName"].ToString();
                student.LastName = Convert.ToString(reader["LastName"]);
                student.StateCode = reader["StateCode"].ToString();
                student.SAT = reader["SAT"].Equals(DBNull.Value)
                    ? (int?)null
                    : Convert.ToInt32(reader["SAT"]);
                student.GPA = Convert.ToDecimal(reader["GPA"]);
                student.MajorId = reader["MajorId"].Equals(DBNull.Value)
                    ? (int?)null
                    : Convert.ToInt32(reader["MajorId"]);
                Console.WriteLine(student);
                students.Add(student);
            }
            reader.Close();
            sqlConn.Close();

        }
    }
}
