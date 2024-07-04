using Cdeem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Cdeem.Core.ValueObject
{
    public class Note : EntityBase
    {
        public Note(string annotation, DateTime createdDate, User user,Skill skill) : base()
        {
            Annotation = annotation;
            CreatedDate = createdDate;
            User = user;
            Skill = skill;
        }

        public string Annotation { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public User User { get; private set; }
        public Skill Skill { get; private set; }
    }
}