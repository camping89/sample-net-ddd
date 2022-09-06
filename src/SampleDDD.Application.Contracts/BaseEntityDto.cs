using System;

namespace SampleDDD.Application.Contracts
{
    public class BaseEntityDto
    {
        /// <summary>
        /// Id of the entity.
        /// </summary>
        public Guid Id { get; set; }
    }
}