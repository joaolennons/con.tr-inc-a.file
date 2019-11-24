using System;
using System.Collections.Generic;
using Write.Pocos;

namespace Write.Seed
{
    public static class Seed
    {
        public static List<Participant> Participants =
            new List<Participant>
            {
                new Participant { Name = "João ¯\\_(ツ)_/¯", Id = Guid.NewGuid() },
                new Participant { Name = "Alice", Id = Guid.NewGuid() },
                new Participant { Name = "Alexandre M.", Id = Guid.NewGuid() },
                new Participant { Name = "Beto", Id = Guid.NewGuid() },
                new Participant { Name = "Diego B.", Id = Guid.NewGuid() },
                new Participant { Name = "Diego P.", Id = Guid.NewGuid() },
                new Participant { Name = "Fernando", Id = Guid.NewGuid() },
                new Participant { Name = "Gabriel", Id = Guid.NewGuid() },
                new Participant { Name = "Leonardo", Id = Guid.NewGuid() },
                new Participant { Name = "Marcus J.", Id = Guid.NewGuid() },
                new Participant { Name = "Michele", Id = Guid.NewGuid() },
                new Participant { Name = "Paulo", Id = Guid.NewGuid() },
                new Participant { Name = "Rafael S.", Id = Guid.NewGuid() },
                new Participant { Name = "Ralf", Id = Guid.NewGuid() },
                new Participant { Name = "Roberta", Id = Guid.NewGuid() },
                new Participant { Name = "Ruan", Id = Guid.NewGuid() },
                new Participant { Name = "Thales", Id = Guid.NewGuid() },
                new Participant { Name = "Wait", Id = Guid.NewGuid() }
            };
    }
}
