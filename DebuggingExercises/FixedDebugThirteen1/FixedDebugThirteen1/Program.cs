﻿// This file contains three classes
// Student class contains Student information
// EventListener contains method that executes
//    when Student completes a course so that Student
//    knows how many credit hours remain until graduation
// Demo class demonstrates the other two classes
using System;
class Student
{
    public event EventHandler NewCredits;
    public int IdNum { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int CreditsCompleted { get; set; }
    public void AddCreditsCompleted(int newCredits)
    {
        CreditsCompleted += newCredits;
        OnNewCredits(EventArgs.Empty);
    }

    public void OnNewCredits(EventArgs e)
    {
        NewCredits(this, e);
    }

}

class EventListener
{
    private Student stu;
    const int CREDITS_TO_GRADUATE = 120;
    const int SOPHOMORE = 30;
    const int JUNIOR = 60;
    const int SENIOR = 90;
    public EventListener(Student student)
    {
        stu = student;
        stu.NewCredits += new EventHandler(NewCreditsAdjusted);//Switched name to NewCreditsAdjusted
    }
    private void NewCreditsAdjusted(object sender, EventArgs e) //Added object sender and switched name to NewCreditsAdjusted
    {
        Console.WriteLine("{0} {1} has completed new credits:", stu.FirstName, stu.LastName);
        if (stu.CreditsCompleted >= CREDITS_TO_GRADUATE)
            Console.WriteLine("Credits = {0}. Qualified for graduation.",
              stu.CreditsCompleted);
        else
        {
            Console.Write("   {0} credits completed; {1} credits to go.",
              stu.CreditsCompleted, CREDITS_TO_GRADUATE - stu.CreditsCompleted);
            Console.Write(" Current status is ");
            if (stu.CreditsCompleted == SENIOR)
                Console.WriteLine("senior.");
            else if (stu.CreditsCompleted == JUNIOR)
                Console.WriteLine("junior.");
            else if (stu.CreditsCompleted == SOPHOMORE)
                Console.WriteLine("sophomore.");
            else Console.WriteLine("freshman.");
        }
    }
}

class DebugThirteen1
{
    static void Main()
    {
        Student oneStu = new Student();
        EventListener listener = new EventListener(oneStu);
        oneStu.IdNum = 2345;
        oneStu.LastName = "Hodges";
        oneStu.FirstName = "Chris";
        oneStu.AddCreditsCompleted(15);
        oneStu.AddCreditsCompleted(15);
        oneStu.AddCreditsCompleted(14);
        oneStu.AddCreditsCompleted(14);
        oneStu.AddCreditsCompleted(17);
        oneStu.AddCreditsCompleted(16);
        oneStu.AddCreditsCompleted(15);
        oneStu.AddCreditsCompleted(18);
    }
}


