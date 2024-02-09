class ChecklistGoal : Goal {
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points) {
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent() {
        _amountCompleted++;
    }

    public override int GetPoints()
    {
        return _amountCompleted==_target?Int32.Parse(_points)+_bonus:Int32.Parse(_points);
    }

    public override bool IsComplete() {
        return _amountCompleted>=_target;
    }

    public override string GetDetailsString(){
        return $"{_shortName} ({_description} -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation(){
        string marked = _amountCompleted>=_target?"X":" ";
        return $"[{marked}] {GetDetailsString()}";
    }

    public override string getSaveFormatData() {
        return $"ChecklistGoal:{_shortName}:{_description}:{_points}:{_amountCompleted}:{_target}:{_bonus}";
    }
}