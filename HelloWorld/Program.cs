// See https://aka.ms/new-console-template for more information
using AsyncFunction;

Console.WriteLine("Hello, World!");

Asynchronous demo = new Asynchronous();

// Console.WriteLine(demo.CookRice());
// Console.WriteLine(demo.CookMeat());
// Console.WriteLine(demo.CookVeggies());

//Storing our tasks
// Task<string> riceTask = demo.CookRice();
// Task<string> meatTask = demo.CookMeat();
// Task<string> vegTask = demo.CookVeggies();
// Task<string> mainCourseTask = demo.CookMeatThenVeggies();

// List<Task<string>> toDoListToMakeDinner = new List<Task<string>>(){riceTask, mainCourseTask};

// while (toDoListToMakeDinner.Count > 0)
// {
//     //WhenAny() method will run all the tasks inside of a list of tasks at the same time
//     //It will store the first finished task inside of another task reference variable
//     Task<string> finishedTask = Task.WhenAny(toDoListToMakeDinner);

//     //We are displaying the result of that tasks
//     Console.WriteLine(finishedTask.Result);

//     //We proceed to remove in our to do list
//     toDoListToMakeDinner.Remove(finishedTask);
// }

demo.CookRice();