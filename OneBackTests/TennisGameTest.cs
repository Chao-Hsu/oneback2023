using FluentAssertions;
using NSubstitute;
using OneBackComboTrainingWeb;

namespace OneBackTests
{
    public class TennisGameTest
    {
        private TennisGame _tennisGame;

        [SetUp]
        public void SetUp()
        {
            _tennisGame = new TennisGame("Eva", "Eric");
        }

        [Test]
        public void love_all()
        {
            ScoreShouldBe("love all");
        }

        [Test]
        public void fifteen_love()
        {
            _tennisGame.AddFirstPlayerScore();
            ScoreShouldBe("fifteen love");
        }

        [Test]
        public void love_fifteen()
        {
            _tennisGame.AddSecondPlayerScore();
            ScoreShouldBe("love fifteen");
        }

        [Test]
        public void fifteen_all()
        {
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            ScoreShouldBe("fifteen all");
        }

        [Test]
        public void thirty_love()
        {
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            ScoreShouldBe("thirty love");
        }

        [Test]
        public void love_thirty()
        {
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            ScoreShouldBe("love thirty");
        }

        [Test]
        public void thirty_all()
        {
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            ScoreShouldBe("thirty all");
        }

        [Test]
        public void thirty_fifteen()
        {
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            ScoreShouldBe("thirty fifteen");
        }

        [Test]
        public void fifteen_thirty()
        {
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            ScoreShouldBe("fifteen thirty");
        }

        [Test]
        public void deuce_when_3_3()
        {
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            ScoreShouldBe("deuce");
        }

        [Test]
        public void deuce_when_4_4()
        {
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            ScoreShouldBe("deuce");
        }

        [Test]
        public void eva_adv_when_4_3()
        {
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            ScoreShouldBe("Eva adv");
        }

        [Test]
        public void eric_adv_when_3_4()
        {
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            ScoreShouldBe("Eric adv");
        }

        [Test]
        public void eric_win_when_3_5()
        {
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            ScoreShouldBe("Eric win");
        }

        [Test]
        public void eva_win_when_5_3()
        {
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            _tennisGame.AddSecondPlayerScore();
            ScoreShouldBe("Eva win");
        }

        [Test]
        public void eva_win_when_4_0()
        {
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            _tennisGame.AddFirstPlayerScore();
            ScoreShouldBe("Eva win");
        }

        private void ScoreShouldBe(string expected)
        {
            var score = _tennisGame.Score();
            score.Should().Be(expected);
        }
    }
}
