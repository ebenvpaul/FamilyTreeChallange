using Geektrust_FamilyTreeChallenge.DTO;
using Geektrust_FamilyTreeChallenge.Enums;
using Geektrust_FamilyTreeChallenge.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geektrust_FamilyTreeChallenge.Implementation
{
    public static class BaseRelationships 
    {
        public static IFamilyGraph FamilyGraph = ServiceLocator.GetService<IFamilyGraph>();
        public static IEnumerable<Person> Parents(this IEnumerable<Person> people, Gender? gender = null)
        {
            return people.SelectMany(m => m.Parents());
        }
        public static IEnumerable<Person> Children(this IEnumerable<Person> people, Gender? gender = null)
        {
            return people.SelectMany(m => m.Children(gender));
        }
        public static IEnumerable<Person> Siblings(this IEnumerable<Person> people, Gender? gender = null)
        {
            return people.SelectMany(m => m.Siblings(gender));
        }
        public static IEnumerable<Person> Spouse(this IEnumerable<Person> people)
        {
            return people.SelectMany(m => m.Spouse());
        }

        public static IEnumerable<Person> Parents(this Person person, Gender? gender = null)
        {
            List<Person> result = new List<Person>();
            IPersonRelationships personRelationships = FamilyGraph.Get(person);
            if(personRelationships == null)
            {
                return result;
            }
            IEnumerable<Person> parents = personRelationships.Parents
                .Where(m => gender == null || m.Gender == gender);
            result.AddRange(parents);
            return result;
        }
        public static IEnumerable<Person> Children(this Person person, Gender? gender = null)
        {
            List<Person> result = new List<Person>();
            IPersonRelationships personRelationships = FamilyGraph.Get(person);
            List<Person> children = personRelationships.Edges
                .Where(m => m.RelationshipType == RelationshipType.Parent)
                .Where(m=> gender == null || m.Target.Gender == gender)
                .Select(m => m.Target)
                .ToList();
            result.AddRange(children);
            return result;
        }
        public static IEnumerable<Person> Siblings(this Person person, Gender? gender = null)
        {
            return person.Parents()
                .Children(gender)
                .Distinct()
                .Where(m => !m.Equals(person));
        }
        public static IEnumerable<Person> Spouse(this Person person)
        {
            List<Person> result = new List<Person>();
            IPersonRelationships personRelationships = FamilyGraph.Get(person);
            if (personRelationships.Spouse != null)
            {
                result.Add(personRelationships.Spouse);
            }
            return result;
        }
    }
}
