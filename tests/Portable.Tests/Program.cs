using System;using System.Collections.Generic;using BarierovNet_wp.Model;using BarierovNet_wp.Helpers;
class Program {static void Main(){var p=new PlaceItem();var events=new List<string>();p.PropertyChanged+=(s,e)=>events.Add(e.PropertyName);
p.Title="A &quot;B&quot;";if(p.Title!="A \"B\""||!events.Contains("Title"))throw new Exception("Title binding was not notified");
p.Title=null;if(p.Title!=null)throw new Exception("Null title changed");
events.Clear();p.Create_date="synthetic";if(!events.Contains("Create_date")||events.Contains("ApprovalDate"))throw new Exception("Wrong date notification");
events.Clear();p.Images=new List<string>{"fixture.jpg"};if(!events.Contains("OutImages")||!events.Contains("MainImage"))throw new Exception("Image bindings not notified");
var c=new LengthToVisibilityConverter();if(!c.Convert(null,null,null,null).Equals(System.Windows.Visibility.Collapsed)||!c.Convert("",null,null,null).Equals(System.Windows.Visibility.Collapsed)||!c.Convert("x",null,null,null).Equals(System.Windows.Visibility.Visible))throw new Exception("Nullable text binding failed");
Console.WriteLine("PASS: title, creation date, derived-image notifications and nullable visibility");}}
