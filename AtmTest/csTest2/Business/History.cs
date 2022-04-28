
class History
{
    List<string> log = new List<string>();
    Calender calender = new Calender();

    public void addLog(string massage)
    {
        log.Add(calender.time() + " " + massage + "円");
    }
    public string getLog()
    {
        string result = "";
        foreach (string i in log)
        {
            result += (i + "\n");
        }
        return result;
    }
}