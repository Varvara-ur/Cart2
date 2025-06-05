public class Card
{
    public int Key { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"{Key}: {Name}";
    }
}