﻿

public class QueryConstructor {

    public static string filepath = "C:/Users/NotAtAllPostGresPW.txt";
    public static string filecontent = File.ReadAllText(filepath);

    public QueryConstructor() {

    client = new PostgreSQL_Client("university", "postgres", filecontent);
    // retain university database
    // but change username and password
  }
 
  public PostgreSQL_Client client;

  // method definitions

  // dynamicQuery()
  // Get user-defined query, send query to db

  public void dynamicQuery() {
    // defining the query 
    Console.Write("Please type any SQL query: ");
    string? sql = Console.ReadLine();
  
    // printing query string to console
    Console.Write("Query to be executed: ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(sql+ "\n");
    Console.ForegroundColor = ConsoleColor.Black;

    // executing query
    client.query(sql);
  } // end method dynamicQuery() 

  // composedQuery()
  // Get dynamic part from user,
  // then compose dynamic and static part,
  // and send query to db

  virtual public void composedQuery() {
    // defining the query
    string staticSQLbefore = "select * from course where course_id = '";
    Console.Write("Please type id of a course: ");
    string? user_defined = Console.ReadLine();
    string staticSQLafter = "' and dept_name != 'Biology'";
    string sql = staticSQLbefore + user_defined + staticSQLafter;

    // printing query string to console
    Console.Write("Query to be executed: " + staticSQLbefore);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(user_defined);
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine(staticSQLafter+ "\n");

    // executing query
    client.query(sql);
  }

    virtual public void SafeComposedQuery()
    {

        Console.Write("Enter Course ID: ");
        string courseIdInput = Console.ReadLine();

        string sql = "SELECT * FROM safe_course(@course_id);";

        
        if (false) // later add test to check if illegal characters are input
        {
            Console.WriteLine("Illegal characters found in input.");
        }
        else
        {
            try
            {
                var client = new PostgreSQL_Client("university", "postgres", filecontent);
                client.query(sql, "course_id", courseIdInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }



    }
}
