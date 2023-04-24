/*
GOAL
Create a PersonModel (FirstName, LastName,
PostalCode). Then create a method called ApplyRules
that prints out one or more statements depending on
the Person passed in:
• If LastName is Corey but FirstName not Tim, print
“Possibly related to Tim Corey”.
• If initials are TC, print “Same initials as Tim Corey”.
• If PostalCode starts with 18, print “In the same
general area as Tim”.
Make sure that the system will print out more than
one statement if more than one check matches.

BONUS
Create a CompanyModel (Name, PostalCode) and,
using the same ApplyRules method, perform the
following checks:
• If Name contains “Corey” but not IAmTimCorey,
print “A company owned by a Corey”.
• If Name is IAmTimCorey, print “Tim’s Company”.
• If PostalCode starts with 08, print “A company in
New Jersey”.
Write the ApplyRules method in such a way so that it
does not need to be modified for every new rule (or
model type).
*/

using CustomRules;

RulesEngine<PersonModel> rulesEngine = new RulesEngine<PersonModel>();

rulesEngine.Rules.Add((x) =>
{
    var output = false;
    if (x is PersonModel person)
    {
        if (person.LastName.ToLower() == "corey" && person.FirstName.ToLower() != "tim")
        {
            output = true;
            System.Console.WriteLine("Possibly related to Tim Corey");
        }
    }
    return output;
});
rulesEngine.Rules.Add((x) =>
{
    var output = false;
    if (x is PersonModel person)
    {
        if (person.LastName.ToLower().StartsWith("c") && person.FirstName.ToLower().StartsWith("t"))
        {
            output = true;
            System.Console.WriteLine("Possibly is Tim Corey");
        }
    }
    return output;
});
rulesEngine.Rules.Add((x) =>
{
    var output = false;
    if (x is PersonModel person)
    {
        if (person.PostalCode.StartsWith("18"))
        {
            output = true;
            System.Console.WriteLine("In the same general area as Tim");
        }
    }
    return output;
});

var people = new List<PersonModel>() {
    new PersonModel() { FirstName = "Tom", LastName = "Conk", PostalCode = "52333" },
    new PersonModel() { FirstName = "Jacob", LastName = "Feuerbach", PostalCode = "52333" },
    new PersonModel() { FirstName = "Tim", LastName = "Corey", PostalCode = "18222" },
    new PersonModel() { FirstName = "Natalie", LastName = "Feuerbach", PostalCode = "18333" },
};

people.ForEach(x =>
{
    System.Console.WriteLine($"Person {x.FirstName} {x.LastName}:");
    System.Console.WriteLine("-----------------");
    rulesEngine.ApplyRules(x);
    System.Console.WriteLine();
});

// RulesEngine<CompanyModel> rulesEngine = new RulesEngine<CompanyModel>();

// rulesEngine.Rules.Add(CompanyRules.CheckForCompanyName);
// rulesEngine.Rules.Add(CompanyRules.CheckForCompanyPostalCode);
// rulesEngine.Rules.Add(CompanyRules.CheckForValueInName);

// var companies = new List<CompanyModel>() {
//     new CompanyModel() {Name = "iamtimcorey", PostalCode = "08555"},
//     new CompanyModel() {Name = "acme", PostalCode = "09555"},
//     new CompanyModel() {Name = "Corey Farms", PostalCode = "08555"},
//     new CompanyModel() {Name = "TimCo", PostalCode = "08142"}
// };

// companies.ForEach(x =>
// {
//     System.Console.WriteLine($"Company {x.Name}:");
//     System.Console.WriteLine("-----------------");
//     rulesEngine.ApplyRules(x);
// });