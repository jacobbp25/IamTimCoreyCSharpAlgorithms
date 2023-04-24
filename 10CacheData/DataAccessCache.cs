namespace CachingChallenge;

public class DataAccessCache
{
    List<PersonModel>? fullListCache;
    Dictionary<int, PersonModel> byIdCache = new Dictionary<int, PersonModel>();
    Dictionary<string, List<PersonModel>> byLastNameCache = new Dictionary<string, List<PersonModel>>();

    public List<PersonModel>? SimulatedPersonListByLastName(string lastName)
    {
        if (byLastNameCache?.ContainsKey(lastName) ?? false)
        {
            System.Console.WriteLine($"cache for {lastName} used");
        }
        else
        {
            var db = new DataAccess();
            byLastNameCache?.Add(lastName, db.SimulatedPersonListByLastName(lastName));
        }
        return byLastNameCache?[lastName];
    }
    public PersonModel? SimulatedPersonById(int id)
    {
        if (byIdCache?.ContainsKey(id) ?? false)
        {
            System.Console.WriteLine($"cache for {id} used");
        }
        else
        {
            var db = new DataAccess();
            byIdCache.Add(id, db.SimulatedPersonById(id));
        }
        return byIdCache[id];
    }
    public List<PersonModel> SimulatedPersonListLookup()
    {
        if (fullListCache == null)
        {
            var db = new DataAccess();
            fullListCache = db.SimulatedPersonListLookup();
        }

        return fullListCache;
    }

}
