using System;
using System.Collections.Generic;


List<Task> tasks = new List<Task>();
string command = "42";
while (command != "q" && command != "quit")
{
    command = Console.ReadLine();
    if (command == "add")
        ft_add(tasks);
    else if (command == "list")
    {
        if (tasks.Count == 0)
            Console.WriteLine("Список задач пока пуст.");
        else
        {
            foreach (var task in tasks)
                Console.WriteLine(task.ToString() + "\n");
        }
    }
    else if (command == "done")
        ft_done(tasks);
    else if (command == "wontdo")
        ft_wontdo(tasks);
    else if (command != "q" && command != "quit")
        Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
}

void ft_add(List<Task> tasks)
{
    Console.WriteLine("Введите заголовок");
    string title = Console.ReadLine();
    if (string.IsNullOrEmpty(title))
    {
        Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
        return;
    }
    Console.WriteLine("Введите описание");
    string summary = Console.ReadLine();
    Console.WriteLine("Введите срок");
    string due = Console.ReadLine();
    DateTime tempduedate = DateTime.Now;
    if (!string.IsNullOrEmpty(due) && !DateTime.TryParse(due, out tempduedate))
    {
        Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
        return;
    }
    DateTime? duedate = null;
    if (!string.IsNullOrEmpty(due))
        duedate = tempduedate;
    Console.WriteLine("Введите тип");
    string type = Console.ReadLine();
    if (string.IsNullOrEmpty(type) || !Enum.TryParse<TaskType>(type, out TaskType taskType))
    {
        Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
        return;
    }
    Console.WriteLine("Установите приоритет");
    string priority = Console.ReadLine();
    TaskPriority? taskPriority = null;
    if (!Enum.TryParse<TaskPriority>(priority, out TaskPriority temptaskPriority) && !string.IsNullOrEmpty(priority))
    {
        Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
        return;
    }
    if (!string.IsNullOrEmpty(priority))
        taskPriority = temptaskPriority;
    Task another = new Task(title, taskType, summary, duedate, taskPriority);
    tasks.Add(another);
    Console.WriteLine(another.ToString());
}

void ft_done(List<Task> tasks)
{
    Console.WriteLine("Введите заголовок");
    string task = Console.ReadLine();
    Task todo = tasks.Find(
        delegate(Task task1)
        {
            return task1.Title == task;
        });
    if (todo == null)
        Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
    else
    {
        Return ret = todo.DoneEvent();
        if (ret == Return.AlreadyDone)
            Console.WriteLine($"Ошибка. Задача [{task}] уже выполнена.");
        else if (ret == Return.AlreadyWontDo)
            Console.WriteLine($"Ошибка. Задача [{task}] уже не актуальна.");
        else
            Console.WriteLine($"Задача [{task}] выполнена!");    
    }
}

void ft_wontdo(List<Task> tasks)
{
    Console.WriteLine("Введите заголовок");
    string task = Console.ReadLine();
    Task wontdo = tasks.Find(
        delegate(Task task1)
        {
            return task1.Title == task;
        });
    if (wontdo == null)
        Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
    else
    {
        Return ret = wontdo.WontDoEvent();
        if (ret == Return.AlreadyDone)
            Console.WriteLine($"Ошибка. Задача [{task}] уже выполнена.");
        else if (ret == Return.AlreadyWontDo)
            Console.WriteLine($"Ошибка. Задача [{task}] уже не актуальна.");
        else
            Console.WriteLine($"Задача [{task}] более не актуальна!");    
    }
}