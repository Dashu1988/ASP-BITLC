namespace ToDoList.Models;

public class ToDoTask
{
    public DateOnly Today()
    {
        return DateOnly.FromDateTime(DateTime.Now);
    }
    static public List<ToDoTask> AllTasks = new List<ToDoTask>();

    public string title { get; set; }

    public string description { get; set; }
    public DateOnly dueDate { get; set; }
    public bool done { get; set; }

    public static bool operator ==(ToDoTask t1, ToDoTask t2)
    {
        if (t1.title == t2.title &&
            t1.description == t2.description &&
            t1.dueDate == t2.dueDate) return true;
        return false;
    }
    public static bool operator !=(ToDoTask t1, ToDoTask t2)
    {
        return !(t1 == t2);
    }
}