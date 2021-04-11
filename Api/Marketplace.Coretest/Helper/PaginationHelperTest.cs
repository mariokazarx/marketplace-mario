using Marketplace.Bl;
using Marketplace.Core.Bl;
using Marketplace.Core.Filter;
using Marketplace.Core.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.CoreTest.Helper
{
    [TestClass]
    public class PaginationHelperTest
    {
        [TestMethod]
        public void CreatePagedReponse_WhenOnlyOnePageIsAvailable()
        {
            string baseUrl = "http://site/";
            string route = "/page";
            string expectedPrevPage = null;
            string expectedNextPage = null;
            string expectedFistPage = $"http://site//page?pageNumber=1&pageSize=10";
            string expectedLastPage = $"http://site//page?pageNumber=1&pageSize=10";
            int expectedTotalPage = 1;
            int expectedTotalRecords = 10;
            int size = 10;
            int numPage = 3;


            var userList = new List<FakeModel>();
            PaginationFilter pagFilter = this.getPaginationFilter(numPage, size);
            UriBl uriBl = new UriBl(baseUrl);


            var actual = PaginationHelper.CreatePagedReponse<FakeModel>(
                    userList, pagFilter, expectedTotalRecords, uriBl, route
                );


            Assert.AreEqual(expectedPrevPage, actual.PreviousPage?.ToString());
            Assert.AreEqual(expectedNextPage, actual.NextPage?.ToString());
            Assert.AreEqual(expectedFistPage, actual.FirstPage?.ToString());
            Assert.AreEqual(expectedLastPage, actual.LastPage?.ToString());
            Assert.AreEqual(expectedTotalPage, actual.TotalPages);
            Assert.AreEqual(expectedTotalRecords, actual.TotalRecords);
        }

        [TestMethod]
        public void CreatePagedReponse_WhenIsInFirstPage()
        {
            string baseUrl = "http://site/";
            string route = "/page";
            string expectedPrevPage = null;
            string expectedNextPage = $"http://site//page?pageNumber=2&pageSize=10";
            string expectedFistPage = $"http://site//page?pageNumber=1&pageSize=10";
            string expectedLastPage = $"http://site//page?pageNumber=10&pageSize=10";
            int expectedTotalPage = 10;
            int expectedTotalRecords = 100;
            int size = 10;
            int numPage = 1;


            var userList = new List<FakeModel>();
            PaginationFilter pagFilter = this.getPaginationFilter(numPage, size);
            UriBl uriBl = new UriBl(baseUrl);


            var actual = PaginationHelper.CreatePagedReponse<FakeModel>(
                    userList, pagFilter, expectedTotalRecords, uriBl, route
                );
           

            Assert.AreEqual(expectedPrevPage, actual.PreviousPage?.ToString());
            Assert.AreEqual(expectedNextPage, actual.NextPage?.ToString());
            Assert.AreEqual(expectedFistPage, actual.FirstPage?.ToString());
            Assert.AreEqual(expectedLastPage, actual.LastPage?.ToString());
            Assert.AreEqual(expectedTotalPage, actual.TotalPages);
            Assert.AreEqual(expectedTotalRecords, actual.TotalRecords);
        }

        [TestMethod]
        public void CreatePagedReponse_WhenIsInMiddlePage()
        {
            string baseUrl = "http://site/";
            string route = "/page";
            string expectedPrevPage = $"http://site//page?pageNumber=2&pageSize=10";
            string expectedNextPage = $"http://site//page?pageNumber=4&pageSize=10";
            string expectedFistPage = $"http://site//page?pageNumber=1&pageSize=10";
            string expectedLastPage = $"http://site//page?pageNumber=10&pageSize=10";
            int expectedTotalPage = 10;
            int expectedTotalRecords = 100;
            int numPage = 3;


            var userList = new List<FakeModel>();
            PaginationFilter pagFilter = this.getPaginationFilter(numPage, expectedTotalPage);
            UriBl uriBl = new UriBl(baseUrl);


            var actual = PaginationHelper.CreatePagedReponse<FakeModel>(
                    userList, pagFilter, expectedTotalRecords, uriBl, route
                );


            Assert.AreEqual(expectedPrevPage, actual.PreviousPage?.ToString());
            Assert.AreEqual(expectedNextPage, actual.NextPage?.ToString());
            Assert.AreEqual(expectedFistPage, actual.FirstPage?.ToString());
            Assert.AreEqual(expectedLastPage, actual.LastPage?.ToString());
            Assert.AreEqual(expectedTotalPage, actual.TotalPages);
            Assert.AreEqual(expectedTotalRecords, actual.TotalRecords);
        }

        [TestMethod]
        public void CreatePagedReponse_WhenIsInLastPage()
        {
            string baseUrl = "http://site/";
            string route = "/page";
            string expectedPrevPage = $"http://site//page?pageNumber=9&pageSize=10";
            string expectedNextPage = null;
            string expectedFistPage = $"http://site//page?pageNumber=1&pageSize=10";
            string expectedLastPage = $"http://site//page?pageNumber=10&pageSize=10";
            int expectedTotalPage = 10;
            int expectedTotalRecords = 100;
            int numPage = 10;


            var userList = new List<FakeModel>();
            PaginationFilter pagFilter = this.getPaginationFilter(numPage, expectedTotalPage);
            UriBl uriBl = new UriBl(baseUrl);


            var actual = PaginationHelper.CreatePagedReponse<FakeModel>(
                    userList, pagFilter, expectedTotalRecords, uriBl, route
                );


            Assert.AreEqual(expectedPrevPage, actual.PreviousPage?.ToString());
            Assert.AreEqual(expectedNextPage, actual.NextPage?.ToString());
            Assert.AreEqual(expectedFistPage, actual.FirstPage?.ToString());
            Assert.AreEqual(expectedLastPage, actual.LastPage?.ToString());
            Assert.AreEqual(expectedTotalPage, actual.TotalPages);
            Assert.AreEqual(expectedTotalRecords, actual.TotalRecords);
        }

        // 

        private PaginationFilter getPaginationFilter(int pageNumber, int size) 
        {
            return new PaginationFilter()
            {
                PageNumber = pageNumber,
                PageSize = size
            };
        }
    
    }
}
