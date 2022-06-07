using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;

namespace LabManager.Respositories;


class ComputerRepository
{

    private DatabaseConfig databaseConfig;

    public ComputerRepository(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
    }

    public List<Computer> GetAll()
    {
        var computers = new List<Computer>();

        Console.WriteLine("Computer List");
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();
    
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers";
    
    
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var computer = new Computer(
                reader.GetInt32(0),
                reader.GetString(1), 
                reader.GetString(2));

            computers.Add(computer);

        }
        reader.Close();
        connection.Close();

        return computers;

    }
    public Computer Save(Computer computer)
    {
        var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();
    
        var command = connection.CreateCommand();
        command.CommandText = @"INSERT INTO Computers VALUES($id, $ram, $processor);";
        command.Parameters.AddWithValue("$id",computer.Id);
        command.Parameters.AddWithValue("$ram",computer.Ram);
        command.Parameters.AddWithValue("$processor",computer.Processor);
    
        command.ExecuteNonQuery();
        connection.Close();
        return computer;
    }
    public Computer GetById(int id)
                var computer = new Computer(id , "FAKE 1", "FAKE 2");
                var connection = new SqliteConnection(databaseConfig.ConnectionString);
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Computers WHERE $id = $id ;
                command.Parameters.AddWithValue("$id",Id);

                var reader = command.ExecuteReader();
                reader.Read();


                
                    connection.Close();
                    return computers;
}

 public Computer Update(Computer computer)
    {
        var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();
    
        var command = connection.CreateCommand();
        command.CommandText = "UPDATE computers SET ram = $ram , processor = $processor WHERE id = $id";
        command.Parameters.AddWithValue("$id",computer.Id);
        command.Parameters.AddWithValue("$ram",computer.Ram);
        command.Parameters.AddWithValue("$processor",computer.Processor);
    
        command.ExecuteNonQuery();
        connection.Close();
        return computer;
    }
    public bool existsBYID(int id)
    {
         var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(id) FROM Computers WHERE id = $id";
        command.Parameters.AddWithValue("$id", id );

        bool result = Convert.ToBoolean(command.ExecuteScalar());
        return result;
        
        if(result == 1)
        {
            return true;
        }
        else
        {
            return false;
        }

        command.ExecuteScalar();

        return result == 1 ;
    }
    private Computer readerToComputer(SqliteDataReader reader)
    {
        var computer = new Computer{
            var computer = new Computer(
                reader.GetInt32(0),
                reader.GetString(1), 
                reader.GetString(2));
            }
    }
