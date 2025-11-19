using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI_TravelNET9.Domain.Entities;

namespace TUI_TravelNET9.Repositories.Interfaces
{
    /// <summary>
    /// Data-access contract for retrieving Hotel entities.
    /// Implementations encapsulate storage details (DB, API, in-memory, etc.).
    /// </summary>
    public interface IHotelDAO
    {
        /// <summary>
        /// Asynchronously retrieves all hotels filtered by the provided country type.
        /// </summary>
        /// <param name="type">
        /// A CountryType value that the implementation uses to filter results.
        /// </param>
        /// <returns>
        /// A Task that completes with an IEnumerable&lt;Hotel&gt; containing matching
        /// Hotel entities. The Task represents asynchronous operation; the sequence
        /// may be empty but should not be null (prefer returning an empty sequence).
        /// </returns>
        Task<IEnumerable<Hotel>> GetAllVacationsAsync(CountryType type);
    }
}
