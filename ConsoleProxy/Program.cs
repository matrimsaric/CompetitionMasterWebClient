// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using UserDomain.ControlModule;
using UserDomain.ControlModule.Interfaces;
using UserDomain.model;
using UserDomain.Model;

// step 1 is to load the collection
string displayLine = System.Environment.NewLine + System.Environment.NewLine + "****************************************** REPLACE **********************************************" + System.Environment.NewLine + System.Environment.NewLine;

Console.Write(displayLine.Replace("REPLACE", "Loading User Collection"));

IUserManager userMaster = new UserManager();
PrimeUserCollection allUsers = await userMaster.GetAllActiveUsers();

foreach(PrimeUser usr in allUsers)
{
    Console.Write(usr.ToString());
}

Console.Write(displayLine.Replace("REPLACE", "Adding a new user"));

PrimeUser dummy = allUsers.CreateItem();
dummy.Name = "Michael Ney";
dummy.Id = Guid.NewGuid();
dummy.Status = UserDomain.Properties.USER_STATUS.SUSPENDED;
dummy.Tag = "REDHEAD";
dummy.Code = "TST0000010";

//allUsers.Add(dummy);

await userMaster.CreateUser(dummy);

allUsers = await userMaster.GetAllActiveUsers();

foreach (PrimeUser usr in allUsers)
{
    Console.Write(usr.ToString());
}

Console.Write(displayLine.Replace("REPLACE", "Update existing user"));

PrimeUser ney = allUsers.Where(x => x.Tag == "REDHEAD").FirstOrDefault();

if(ney != null)
{
    ney.Name = "M.Ney";
    ney.Code = "XXX000001";
}


await userMaster.UpdateUser(ney);

// reloading to check the db but in standard use would add to cached collection unless error occurs
allUsers = await userMaster.GetAllActiveUsers();

foreach (PrimeUser usr in allUsers)
{
    Console.Write(usr.ToString());
}

Console.Write(displayLine.Replace("REPLACE", "Delete existing user"));

await userMaster.DeleteUser(ney);
//await userMaster.ArchiveUser(ney);
// reloading to check the db but in standard use would add to cached collection unless error occurs
allUsers = await userMaster.GetAllActiveUsers();

foreach (PrimeUser usr in allUsers)
{
    Console.Write(usr.ToString());
}

//await userMaster.GenerateTestUsers(); // resets test structure back to defaults



Console.WriteLine("Show Results ");
