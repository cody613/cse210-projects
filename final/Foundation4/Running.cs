using System;

class Running : Activity
{
    private double _distance;

    public Running(string date, int minutes, double distance) : base(date, minutes, "Running")
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return (double)GetMinutes() / _distance;
    }
}