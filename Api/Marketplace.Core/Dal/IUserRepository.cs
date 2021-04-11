// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Marketplace.Core.Dal
{
    using System.Threading.Tasks;
    using Marketplace.Core.Model;

    /// <summary>
    /// Contract for the User data access
    /// </summary>
    public interface IUserRepository
    {
        #region Methods

        /// <summary>
        /// Gets all users asynchronous.
        /// </summary>
        /// <returns>Array of users</returns>
        Task<User[]> GetAllUsersAsync();

        /// <summary>
        /// save user.
        /// </summary>
        /// <param name="user">user new.</param> 
        /// <returns>new user</returns>
        Task<User> SaveUser(User user);

        /// <summary>
        /// get user by username.
        /// </summary>
        /// <param name="username">user username to return </param> 
        /// <returns>user</returns>
        Task<User> GetUserByUsername(string username);

        #endregion
    }
}