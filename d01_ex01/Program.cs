using System;
using System.Collections.Generic;

{
    List<Task> tasks = new List<Task>();
    string command = Console.ReadLine();
    while (command != "q" && command != "quit")
    {
        command = Console.ReadLine();
        if (command == "add")
        {
            Console.WriteLine("Введите заголовок");
            string title = Console.ReadLine();
            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                continue;
            }
            Console.WriteLine("Введите описание");
            string summary = Console.ReadLine();
            Console.WriteLine("Введите срок");
            DateTime duedate = DateTime.Parse(Console.ReadLine()); // parse
            Console.WriteLine("Введите тип");
            string type = Console.ReadLine();
            if (string.IsNullOrEmpty(type) || !Enum.IsDefined(typeof(TaskType), type))
            {
                Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                continue;
            }
            Console.WriteLine("Установите приоритет");
            string priority = Console.ReadLine();
            if (!string.IsNullOrEmpty(priority) && priority != "Low" && priority != "Normal" && priority != "High") // like type
            {
                Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                continue;
            }
            tasks.Add(new Task(title, type, summary, duedate, priority));
        }
        else if (command == "list")
        {
            if (tasks.Count == 0)
                Console.WriteLine("Список задач пока пуст.");
            else
            {
                foreach (var task in tasks)
                    Console.WriteLine(task.ToString());
            }
        }
        else if (command == "done")
        {
            
        }
        else if (command == "wontdo")
        {
            
        }
        else
            Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
    }
}