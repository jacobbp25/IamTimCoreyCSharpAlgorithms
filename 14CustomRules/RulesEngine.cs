namespace CustomRules;
public class RulesEngine<T>
{
    public List<Func<T, bool>> Rules { get; set; } = new List<Func<T, bool>>();
    public void ApplyRules(T data)
    {
        foreach (var rule in Rules)
        {
            rule(data);
        }
    }
}