﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FilterLists.Data.Models.Contracts;
using Newtonsoft.Json;

namespace FilterLists.Data.Models.Implementations
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultValue("CURRENT_TIMESTAMP")]
        [JsonIgnore]
        public DateTime CreatedDateUtc { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonIgnore]
        public DateTime? ModifiedDateUtc { get; set; }
    }
}