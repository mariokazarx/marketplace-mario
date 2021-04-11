// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Marketplace.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Marketplace.Core.Bl;
    using Marketplace.Core.Model;
    using Marketplace.Core.Filter;
    using Marketplace.Core.Wrapper;
    using Marketplace.Core.Helper;

    /// <summary>
    /// Services for Offers
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class OfferController : ControllerBase
    {
        #region Fields

        private readonly ILogger<OfferController> logger;

        private readonly IOfferBl offerBl;

        private readonly IUriBl uriBl;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="offerBl">The offer business logic.</param>
        public OfferController(ILogger<OfferController> logger, IOfferBl offerBl, IUriBl uriBl)
        {
            this.logger = logger;
            this.offerBl = offerBl;
            this.uriBl = uriBl;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the list of offers.
        /// </summary>
        /// <returns>List of offers</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> Get()
        {
            IEnumerable<Offer> result;

            try
            {
                result = await this.offerBl.GetOffersAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }

        /// <summary>
        /// Gets the list of offers pagination.
        /// </summary>
        /// <returns>List of offers</returns>
        [HttpGet("~/OffersPagination")]
        public async Task<IActionResult> GetPagination([FromQuery] PaginationFilter paginationFilter)
        {
            List<Offer> result;

            try
            {
                result = await this.offerBl.GetPaginationOffersAsync(paginationFilter).ConfigureAwait(false);

                foreach (var offer in result)
                {
                    offer.User.Offers = null;
                    offer.Category.Offers = null;
                }

                var route = Request.Path.Value;
                int totalRecords = await this.offerBl.CountOffers().ConfigureAwait(false);;
                var pagedReponse = PaginationHelper.CreatePagedReponse<Offer>(result, paginationFilter, totalRecords, uriBl, route);
                return this.Ok(pagedReponse);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            
        }

        /// <summary>
        /// Save offer.
        /// </summary>
        /// <returns>new offer</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Offer body)
        {
            Offer result;

            try
            {
                result = await this.offerBl.SaveOffer(body).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }

        #endregion
    }
}