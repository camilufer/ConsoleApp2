using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
 
namespace ConsoleApplication_Database
{
    class Program
    {
        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;
        public static void GetStudent()
        {
            int counter = 0;
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BaseDatos.mdf";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Arriendo";
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                counter++;
                Console.WriteLine(reader[0] + "-" + reader[1] + " " + reader[2]);
            }
            con.Close();
            Console.WriteLine("====================================");
            Console.WriteLine("Arriendos :" + counter);
            Console.WriteLine("====================================");
        }

        public static void InsertStudent()
        {
            Console.Write("Primero : ");
            string fname = Console.ReadLine();
            Console.Write("Segundo Name : ");
            string lname = Console.ReadLine();
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BaseDatos.mdf";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Arriendo (FirstName,LastName) VALUES ('" + fname + "','" + lname + "')";
            con.Open();
            int sonuc = cmd.ExecuteNonQuery();
            con.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Insertado");
            }
            else
            {
                Console.WriteLine("No se pudo insertar");
            }
        }

        public static void UpdateStudent()
        {
            Console.Write("ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("First Name : ");
            string fname = Console.ReadLine();
            Console.Write("Last Name : ");
            string lname = Console.ReadLine();
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BaseDatos.mdf";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Arriendo SET FirstName='" + fname + "',LastName='" + lname + "' WHERE Id=" + id;

            con.Open();
            int sonuc = cmd.ExecuteNonQuery();
            con.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Actualizar");
            }
            else
            {
                Console.WriteLine("No se ha podido modificar");
            }
        }

        public static void DeleteStudent()
        {
            Console.Write("Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BaseDatos.mdf";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Arriendo WHERE Id=" + id + "";
            //www.csharp-console-example.com
            con.Open();
            int sonuc = cmd.ExecuteNonQuery();
            con.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Se borro.");
            }
            else
            {
                Console.WriteLine("Borrado");
            }
        }


        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.Lista venta");
                Console.WriteLine("2.Insertar");
                Console.WriteLine("3.Modificar");
                Console.WriteLine("4.Borrar");
                Console.Write("Seleccionar : ");
                string sec = Console.ReadLine();
                if (sec == "1")
                {
                    GetStudent();
                }
                else if (sec == "2")
                {
                    InsertStudent();
                    GetStudent();
                }
                else if (sec == "3")
                {
                    UpdateStudent();
                    GetStudent();
                }
                else if (sec == "4")
                {
                    DeleteStudent();
                    GetStudent();
                }
                Console.Write("Continuar (s/n) : ");
                string onay = Console.ReadLine();
                if (onay != "s")
                {
                    break;
                }
            }
        }
    }
}