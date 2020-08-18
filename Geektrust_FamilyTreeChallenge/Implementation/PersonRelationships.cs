﻿using Geektrust_FamilyTreeChallenge.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Geektrust_FamilyTreeChallenge.Tests")]
namespace Geektrust_FamilyTreeChallenge.Implementation
{
    internal sealed class PersonRelationships 
    {
        public List<Relationship> Edges { get; private set; }
        public List<Person> Parents { get; private set; }
        public Person Spouse { get; private set; }

        public PersonRelationships()
        {
            Edges = new List<Relationship>();
            Parents = new List<Person>();
        }
        public PersonRelationships(List<Relationship> edges, List<Person> persons)
        {
            Edges = edges;
            Parents = persons;
        }

        public bool CanAddParent(Person parent)
        {
            if (Parents.Count() == 2)
                return false;
            return !Parents.Any(m => m.Gender == parent.Gender);
        }

        public void AddEdge(Relationship edge)
        {
            Edges.Add(edge);
        }

        public void AddParent(Person parent)
        {
            Parents.Add(parent);
        }

        public void AddSpouse(Person spouse)
        {
            Spouse = spouse;
        }
    }
}
