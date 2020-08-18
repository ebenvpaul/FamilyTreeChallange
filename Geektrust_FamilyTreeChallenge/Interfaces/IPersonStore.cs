using Geektrust_FamilyTreeChallenge.DTO;
using Geektrust_FamilyTreeChallenge.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geektrust_FamilyTreeChallenge.Interfaces
{
    public interface IPersonStore
    {
        Person AddPerson(string personName, Gender gender);
        bool ContainsPerson(string personName);
        Person GetPeople(string personName);
        IEnumerable<Person> GetPeople(IEnumerable<string> people);
    }
}
