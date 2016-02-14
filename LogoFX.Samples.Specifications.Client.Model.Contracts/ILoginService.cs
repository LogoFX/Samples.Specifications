using System.Threading.Tasks;

namespace LogoFX.Samples.Specifications.Client.Model.Contracts
{
    /// <summary>
    /// Represents username service
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Logins as custom user asynchronously.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>        
        /// <returns>Task representing username result</returns>
        Task LoginAsync(string username, string password);
    }
}