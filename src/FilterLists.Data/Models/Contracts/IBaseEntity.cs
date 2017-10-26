using System;

namespace FilterLists.Data.Models.Contracts
{
    public interface IBaseEntity
    {
        long Id { get; set; }
        DateTime CreatedDateUtc { get; set; }
        DateTime? ModifiedDateUtc { get; set; }
    }
}