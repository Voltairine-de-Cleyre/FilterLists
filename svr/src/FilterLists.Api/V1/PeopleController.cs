﻿using System.Linq;
using FilterLists.Api.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilterLists.Api.V1
{
    using static StatusCodes;

    /// <summary>
    ///     Represents a RESTful people service.
    /// </summary>
    [ApiVersion("1.0")]
    [ApiVersion("0.9", Deprecated = true)]
    public class PeopleController : ODataController
    {
        /// <summary>
        ///     Gets a single person.
        /// </summary>
        /// <param name="key">The requested person identifier.</param>
        /// <param name="options">The current OData query options.</param>
        /// <returns>The requested person.</returns>
        /// <response code="200">The person was successfully retrieved.</response>
        /// <response code="404">The person does not exist.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Person), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public IActionResult Get(int key, ODataQueryOptions<Person> options)
        {
            var people = new[]
            {
                new Person
                {
                    Id = key,
                    FirstName = "John",
                    LastName = "Doe"
                }
            };

            var person = options.ApplyTo(people.AsQueryable()).SingleOrDefault();

            if (person == null) return NotFound();

            return Ok(person);
        }
    }
}