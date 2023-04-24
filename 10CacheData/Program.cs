/*

Create In Memory data cache for the SimulatedPersonListLookup() method after the first time you ask for data, you get data from your cache instead of the simulated database

Bonus:

Cache the results of calls to the SimulatedPersonById() and SimulatedPersonListByLastNameCalls().  Do not do the queries yourself on the full list.  Cache each call so that the first time, it hits the database and then after that it hits the cache.

*/
using CachingChallenge;

var db = new DataAccessCache();
//var db = new DataAccess();

var people = db.SimulatedPersonListByLastName("Jones");
people = db.SimulatedPersonListByLastName("Jones");
people = db.SimulatedPersonListByLastName("Storm");
people = db.SimulatedPersonListByLastName("Jones");
people = db.SimulatedPersonListByLastName("Storm");
people = db.SimulatedPersonListByLastName("Jones");

people?.ForEach(x => System.Console.WriteLine($"{x.FirstName} {x.LastName} {x.Id}"));

// var people = db.SimulatedPersonListLookup();
// people = db.SimulatedPersonListLookup();
// people = db.SimulatedPersonListLookup();

// people.ForEach(x => System.Console.WriteLine($"{x.FirstName} {x.LastName} {x.Id}"));

// var person = db.SimulatedPersonById(3);
// person = db.SimulatedPersonById(3);
// person = db.SimulatedPersonById(5);
// person = db.SimulatedPersonById(5);
// person = db.SimulatedPersonById(3);

// System.Console.WriteLine(person);

