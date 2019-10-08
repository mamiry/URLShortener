
using Moq;
using System;
using System.Collections.Generic;
using URLShortener.Domain.WebUrls;
using Xunit;


namespace URLShortener.UnitTest
{
    public class UnitTestWebUrl
    {
        [Fact]
        public void GetTotalGoalsForSeason_returns_expected_goal_count()
        {
            // ARRANGE 
            var mockTeamStatRepo = new Mock<URLShortener.Domain.Interfaces.IWebUrlRepository>();

            //    // setup a mock stat repo to return some fake data in our target method
            mockTeamStatRepo
             .Setup(mtsr => mtsr.GetAll(It.IsAny<Guid>()))
             .Returns(new List<WebUrl>
        {
                  new WebUrl {Id = Guid.NewGuid(),ClickCount=0,Url="Https://MainUrl.ir/Url1",UrlShort="https://MyUrl.ir/Url1",CreateTime=DateTime.Now , User=null , UserId=Guid.NewGuid()},
                  new WebUrl {Id = Guid.NewGuid(),ClickCount=0,Url="Https://MainUrl.ir/Url2",UrlShort="https://MyUrl.ir/Url2",CreateTime=DateTime.Now , User=null , UserId=Guid.NewGuid()},
                  new WebUrl {Id = Guid.NewGuid(),ClickCount=0,Url="Https://MainUrl.ir/Url3",UrlShort="https://MyUrl.ir/Url3",CreateTime=DateTime.Now , User=null , UserId=Guid.NewGuid()}
         });


            // create our TeamStatCalculator by injecting our mock repository
            //var teamStatCalculator = new TeamStatCalculator(mockTeamStatRepo.Object);

            // ACT - call our method under test
            //var result = GetAll.GetTotalGoalsForSeason(1);

            // ASSERT - we got the result we expected - our fake data has 6 goals...we should get this back from the method
            //Assert.True(result == 6);
        }

    }
}
