using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Respositories;
using LabManager.Models;


var databaseConfig = new DatabaseConfig();
new DatabaseSetup(databaseConfig);
var computerRepository = new ComputerRepository(databaseConfig);


//Routing
var modelName = args[0];
var modelAction = args [1];


if(modelName == "Computer")
 if(modelAction == "List")
 {
   Console.WriteLine("Computer List");
    foreach(var computer in computerRepository.GetAll())
    {
      Console.WriteLine("{0},{1},{2}", computer.Id,computer.Ram,computer.Processor);
    }
 }
 
  if(modelAction == "New")
  {
      Console.WriteLine("Computer New");
      int id = Convert.ToInt32(args[2]);
      var ram = args [3];
      var processor = args [4];
     
     var computer = new Computer(id, ram, processor);
     computerRepository.Save(computer);
  }
  if(modelAction == "Show")
  {
    var id = Convert.ToInt32(args[2]);

    if(computerRepository.existsById(id));
    {
      var computer = computerRepository.GetById(id);
      Console.WriteLine(
        "{0} , {1} , {2}" , computer.Id, computer.Ram, computer.Processor
      );
    
    }else{
      Console.WriteLine("");
    }
    
    var computer = computerRepository.GetById(id);
     Console.WriteLine("{0},{1},{2}", computer.Id,computer.Ram,computer.Processor){

    
    };
    if(modelAction == "Uptade")
  {
      int id = Convert.ToInt32(args[2]);
      var ram = args [3];
      var processor = args [4];
     
     var computer = new Computer(id, ram, processor);
     computerRepository.Save(computer);
  }
  }