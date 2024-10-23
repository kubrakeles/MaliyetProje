namespace NotificationProject.Models
{
    public class NotificationModel()
    {
public int NotificationID { get; set; } //PrimaryKey
public string title {get;set;}

public string Text { get; set; }
public int userID  { get; set; }

public DateTime CreatedDate { get; set; }
    }
}