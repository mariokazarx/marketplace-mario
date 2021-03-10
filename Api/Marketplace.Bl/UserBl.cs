﻿// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Marketplace.Bl
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Core.Bl;
    using Marketplace.Core.Dal;
    using Marketplace.Core.Model;

    /// <summary>
    /// Users' logic 
    /// </summary>
    /// <seealso cref="Marketplace.Core.Bl.IUserBl" />
    public class UserBl : IUserBl
    {
        #region Fields

        private readonly IUserRepository userRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserBl"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public UserBl(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await this.userRepository.GetAllUsersAsync().ConfigureAwait(false);
        }

        #endregion
    }
}