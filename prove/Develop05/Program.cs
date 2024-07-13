using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    private string _name;
    private int _points;
    protected bool _isComplete;

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
        _isComplete = false;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPoints()
    {
        return _points;
    }

    public bool IsComplete()
    {
        return _isComplete;
    }

    public abstract void RecordEvent();

    public abstract string GetDetails();
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points)
    {
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override string GetDetails()
    {
        return $"[ {(IsComplete() ? "X" : " ")} ] {GetName()}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals are never marked as complete
    }

    public override string GetDetails()
    {
        return $"[ ] {GetName()} (Eternal)";
    }
}

class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
        }
    }

    public override string GetDetails()
    {
        return $"[ {(IsComplete() ? "X" : " ")} ] {GetName()} (Completed {_currentCount}/{_targetCount} times)";
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }

    public int GetCurrentCount()
    {
        return _currentCount;
    }

    public int GetTargetCount()
    {
        return _targetCount;
    }
}

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _totalPoints;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in _goals)
        {
            if (goal.GetName() == goalName)
            {
                goal.RecordEvent();
                _totalPoints += goal.GetPoints();
                if (goal is ChecklistGoal checklistGoal)
                {
                    if (checklistGoal.IsComplete())
                    {
                        _totalPoints += checklistGoal.GetBonusPoints();
                    }
                }
                break;
            }
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetails());
        }
    }

    public int GetTotalPoints()
    {
        return _totalPoints;
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_totalPoints);
            foreach (var goal in _goals)
            {
                writer.WriteLine($"{goal.GetType().Name}|{goal.GetName()}|{goal.GetPoints()}|{goal.IsComplete()}");
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal.GetCurrentCount()}|{checklistGoal.GetTargetCount()}|{checklistGoal.GetBonusPoints()}");
                }
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename)) return;

        using (StreamReader reader = new StreamReader(filename))
        {
            _totalPoints = int.Parse(reader.ReadLine());
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine().Split('|');
                var goalType = line[0];
                var name = line[1];
                var points = int.Parse(line[2]);
                var isComplete = bool.Parse(line[3]);

                if (goalType == nameof(SimpleGoal))
                {
                    var goal = new SimpleGoal(name, points);
                    if (isComplete) goal.RecordEvent();
                    _goals.Add(goal);
                }
                else if (goalType == nameof(EternalGoal))
                {
                    var goal = new EternalGoal(name, points);
                    _goals.Add(goal);
                }
                else if (goalType == nameof(ChecklistGoal))
                {
                    var currentCount = int.Parse(reader.ReadLine());
                    var targetCount = int.Parse(reader.ReadLine());
                    var bonusPoints = int.Parse(reader.ReadLine());
                    var goal = new ChecklistGoal(name, points, targetCount, bonusPoints);
                    for (int i = 0; i < currentCount; i++) goal.RecordEvent();
                    _goals.Add(goal);
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");

        GoalManager goalManager = new GoalManager();
        
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Display goals");
            Console.WriteLine("4. Display score");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Select the type of goal:");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");
                Console.Write("Choose an option: ");
                string goalType = Console.ReadLine();

                Console.Write("Enter the goal name: ");
                string name = Console.ReadLine();
                Console.Write("Enter the points for this goal: ");
                int points = int.Parse(Console.ReadLine());

                if (goalType == "1")
                {
                    goalManager.AddGoal(new SimpleGoal(name, points));
                }
                else if (goalType == "2")
                {
                    goalManager.AddGoal(new EternalGoal(name, points));
                }
                else if (goalType == "3")
                {
                    Console.Write("Enter the target count: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter the bonus points: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    goalManager.AddGoal(new ChecklistGoal(name, points, targetCount, bonusPoints));
                }
            }
            else if (choice == "2")
            {
                Console.Write("Enter the goal name to record an event: ");
                string goalName = Console.ReadLine();
                goalManager.RecordEvent(goalName);
            }
            else if (choice == "3")
            {
                goalManager.DisplayGoals();
            }
            else if (choice == "4")
            {
                Console.WriteLine($"Total Points: {goalManager.GetTotalPoints()}");
            }
            else if (choice == "5")
            {
                Console.Write("Enter filename to save goals: ");
                string filename = Console.ReadLine();
                goalManager.SaveGoals(filename);
            }
            else if (choice == "6")
            {
                Console.Write("Enter filename to load goals: ");
                string filename = Console.ReadLine();
                goalManager.LoadGoals(filename);
            }
            else if (choice == "7")
            {
                break;
            }
        }
    }
}


//Program to create goals and a menu //