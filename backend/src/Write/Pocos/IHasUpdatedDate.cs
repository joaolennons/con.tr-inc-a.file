using System;

namespace Write.Pocos
{
    public interface IHasUpdatedDate
    {
        DateTime? UpdateDate { get; set; }
    }
}
