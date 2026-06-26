// class definition
public abstract class Goal
{
// member variables
    protected string _shortName;
    protected string _description;
    protected int _points;

// constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

// abstract methods
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

// virtual method
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[]";
        return $"{checkbox} {_shortName} ({_description})";
    }
}