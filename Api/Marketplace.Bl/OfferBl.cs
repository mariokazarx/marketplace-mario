// <copyright company="ROSEN Swiss AG">
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
    using Marketplace.Core.Filter;
    using Marketplace.Core.Wrapper;

    /// <summary>
    /// Users' logic 
    /// </summary>
    /// <seealso cref="Marketplace.Core.Bl.IOfferBl" />
    public class OfferBl : IOfferBl
    {
        #region Fields

        private readonly IOfferRepository offerRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferBl"/> class.
        /// </summary>
        /// <param name="offerRepository">The offer repository.</param>
        public OfferBl(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<Offer>> GetOffersAsync()
        {
            return await this.offerRepository.GetAllOffersAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<List<Offer>> GetPaginationOffersAsync(PaginationFilter paginationFilter)
        {
            return await this.offerRepository.GetPageOffersAsync(paginationFilter).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Offer> SaveOffer(Offer offer)
        {
            return await this.offerRepository.SaveOffer(offer).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<int> CountOffers()
        {
            return await this.offerRepository.CountOffers().ConfigureAwait(false);
        }

        #endregion
    }
}