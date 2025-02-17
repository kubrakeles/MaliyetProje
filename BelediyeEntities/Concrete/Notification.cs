using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BelediyeCore.Entities;
namespace BelediyeEntities
{
public class Notification:IEntity
{
[Key]
public int Id { get; set; } //PrimaryKey
public string title {get;set;}

public string Text { get; set; }
public string email  { get; set; }
public string ? ImagePath{get; set;}

public DateTime CreatedDate { get; set; }
}
}