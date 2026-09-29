/* bool success = Enum.TryParse("InProgress", out TaskStatus1 status);
if (success)
    Console.WriteLine("THE STATUS : " + status);
else
    Console.WriteLine("Didn't work !"); */

Status oldStatus = Status.Todo;
string status = Console.ReadLine();

bool success = Enum.TryParse(status, out Status newStatus);
if (success)
{
    if((oldStatus == Status.Todo && (newStatus == Status.InProgress || newStatus == Status.Cancelled))
    || (oldStatus == Status.InProgress && (newStatus == Status.Completed || newStatus == Status.Cancelled)))
    {
        System.Console.WriteLine("Valid Change !");
    }
    else
        System.Console.WriteLine("Invalid Change !");
}
else
    Console.WriteLine("Error while parsing pls enter a correct spelling");
enum Status
{
    Todo,
    InProgress,
    Completed,
    Cancelled
}
