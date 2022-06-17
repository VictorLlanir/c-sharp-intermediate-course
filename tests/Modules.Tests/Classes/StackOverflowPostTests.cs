using Classes.Module.StackOverflowContext;
using System;
using System.Linq;
using Xunit;

namespace Modules.Tests.Classes
{
    public class StackOverflowPostTests
    {
        [Theory(DisplayName = "Should be instantiated correctly")]
        [InlineData("Hokus", "The magical")]
        [InlineData("Pokus", "Another magical")]
        [InlineData("Abracadabra", "Is a pokemon")]
        public void IsInstantiated(string title, string description)
        {
            var post = new Post(title, description);

            Assert.Equal(title, post.Title);
            Assert.Equal(description, post.Description);
        }

        [Theory(DisplayName = "Should be updated correctly")]
        [InlineData("Hokus", "The magical", "Inverting the magic")]
        [InlineData("Pokus", "Another magical", "The magic has been inverted")]
        public void IsUpdated(string title, string description, string updatedDescription)
        {
            var post = new Post(title, description);

            post.Update(updatedDescription);

            Assert.Equal(updatedDescription, post.Description);
        }

        [Fact(DisplayName = "Should return Title and Created Date when calling ToString method")]
        public void ToStringTitle()
        {
            var post = new Post("Lorem ipsum", "Lorem ipsum dolor sit amet");

            var expected = $"Lorem ipsum at {DateTime.Now.ToString():G}";
            var actual = post.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "Should have 100 votes")]
        public void OneHundredVotes()
        {
            var post = new Post("Lorem ipsum", "Lorem ipsum dolor sit amet");
            var expectedVotes = 100;

            RepeatNthTimes(132, post.UpVote);
            RepeatNthTimes(33, post.DownVote);
            post.UpVote();

            Assert.Equal(expectedVotes, post.Votes);
        }

        [Theory(DisplayName = "Should have N votes")]
        [InlineData(123, -33, 44, 54)]
        [InlineData(12, 1, 3, 4, 0)]
        [InlineData(-33, -42, -23, -102, 23)]
        public void SumAndSubtractVotes(params int[] votes)
        {
            var post = new Post("Lorem ipsum", "Lorem ipsum dolor sit amet");
            var expectedVotes = votes.Sum();

            UpVoteAndDownVote(post, votes);

            Assert.Equal(expectedVotes, post.Votes);
        }

        private void UpVoteAndDownVote(Post post, int[] votes)
        {
            foreach (var vote in votes)
            {
                if (vote < 0)
                    RepeatNthTimes(vote * -1, post.DownVote);
                else
                    RepeatNthTimes(vote, post.UpVote);
            }
        }

        private void RepeatNthTimes(int times, Action repeatFn)
        {
            for (int i = 0; i < times; i++) repeatFn();
        }
    }
}
