using System;

class Program
{
    static void Main(string[] args)
    {
        Job myJob = new Job();
        myJob._jobTitle = "Software Engineer";
        myJob._company = "Google";
        myJob._endYear = 2020;
        myJob._startYear = 2018;

        Job myJob2 = new Job();
        myJob2._jobTitle = "Software Engineer";
        myJob2._company = "Meta";
        myJob2._endYear = 2024;
        myJob2._startYear = 2020;

        Resume myResume = new Resume();
        myResume._name = "Felipe";
        myResume._jobs.Add(myJob);
        myResume._jobs.Add(myJob2);

        myResume.Display();
    }
}