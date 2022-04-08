using System;
using TechTalk.SpecFlow;
using Skiing_Library;

namespace SkiiingTests.StepDefinitions
{
    [Binding]
    public class SkiingStepDefinitions
    {
        private readonly ScenarioContext context;

        public SkiingStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }


        [Given(@"a file path (.*)")]
        public void GivenAFilePath(string p0)
        {
            Map map = new Map();
            context.Add("Map", map);
            context.Add("path", p0);
        }

        [When(@"we read it in")]
        public void WhenWeReadItIn()
        {
            context.Get<Map>("Map").ReadTreeMap(context.Get<string>("path"));
        }

        [Then(@"string array is not null")]
        public void ThenStringArrayIsNotNull()
        {
            context.Get<Map>("Map").MapTiles.Should().NotBeNull();
        }

        [Given(@"the skier is at the end of the map of width (.*)")]
        public void GivenTheSkierIsAtTheEndOfTheMap(int p0)
        {
            Map map = new Map();
            map.Width = p0;
            context.Add("MapWithWidth",map);
            context.Add("skierPos", map.Width - 1);
        }

        [When(@"they advance")]
        public void WhenTheyAdvance()
        {
            int newSkierPos = context.Get<int>("skierPos") + context.Get<int>("Slope");
            newSkierPos = context.Get<Map>("MapWithWidth").GetLoopIndex(newSkierPos);
            context.Set(newSkierPos, "skierPos");
        }

        [Then(@"their new position is (.*)")]
        public void ThenTheyLoopBackToTheFront(int newXPos)
        {
            context.Get<int>("skierPos").Should().Be(newXPos);
        }

        [Given(@"a slope of (.*):1")]
        public void GivenASlopeOf(int p0)
        {
            context.Add("Slope", p0);
        }

        [When(@"the skier reaches the bottom")]
        public void WhenTheSkierReachesTheBottom()
        {
            Map mapFinished = new("TreeMap.txt");
            mapFinished.SkiSlope(context.Get<int>("Slope"));
            context.Add("treesHit", mapFinished.collisions);
        }

        [Then(@"they hit (.*) trees")]
        public void ThenTheyHitTrees(int p0)
        {
            context.Get<int>("treesHit").Should().Be(p0);
        }
    }
}
