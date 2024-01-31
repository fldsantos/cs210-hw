class Assignnment {
    protected string _studentName;
    private string _topic;
    public Assignnment(string studentName, string topic) {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary() {
        return $"{_studentName} - {_topic}";
    }
}