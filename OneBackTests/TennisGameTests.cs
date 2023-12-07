using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace OneBackTests
{
    public class TennisGameTests
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

        private void ScoreShouldBe(string expected)
        {
            var score = _tennisGame.Score();
            score.Should().Be(expected);
        }

        [Test]
        public void fifteen_love()
        {
            GivenFirstPlayerScore(1);
            ScoreShouldBe("fifteen love");
        }

        private void GivenFirstPlayerScore(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _tennisGame.AddFirstPlayerScore();
            }
        }

        [Test]
        public void thirty_love()
        {
            GivenFirstPlayerScore(2);
            ScoreShouldBe("thirty love");
        }

        [Test]
        public void forty_love()
        {
            GivenFirstPlayerScore(3);
            ScoreShouldBe("forty love");
        }

        [Test]
        public void love_fifteen()
        {
            GivenSecondPlayerScore(1);
            ScoreShouldBe("love fifteen");
        }

        [Test]
        public void love_thirty()
        {
            GivenSecondPlayerScore(2);
            ScoreShouldBe("love thirty");
        }

        [Test]
        public void love_forty()
        {
            GivenSecondPlayerScore(3);
            ScoreShouldBe("love forty");
        }

        [Test]
        public void fifteen_all()
        {
            GivenFirstPlayerScore(1);
            GivenSecondPlayerScore(1);
            ScoreShouldBe("fifteen all");
        }

        [Test]
        public void thirty_all()
        {
            GivenFirstPlayerScore(2);
            GivenSecondPlayerScore(2);
            ScoreShouldBe("thirty all");
        }

        [Test]
        public void deuce()
        {
            GivenFirstPlayerScore(3);
            GivenSecondPlayerScore(3);
            ScoreShouldBe("deuce");
        }

        [Test]
        public void first_player_adv()
        {
            GivenFirstPlayerScore(4);
            GivenSecondPlayerScore(3);
            ScoreShouldBe("Eva adv");
        }

        [Test]
        public void second_player_adv()
        {
            GivenFirstPlayerScore(3);
            GivenSecondPlayerScore(4);
            ScoreShouldBe("Eric adv");
        }

        [Test]
        public void second_player_win()
        {
            GivenFirstPlayerScore(3);
            GivenSecondPlayerScore(5);
            ScoreShouldBe("Eric win");
        }

        [Test]
        public void first_player_win()
        {
            GivenFirstPlayerScore(4);
            GivenSecondPlayerScore(2);
            ScoreShouldBe("Eva win");
        }

        private void GivenSecondPlayerScore(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _tennisGame.AddSecondPlayerScore();
            }
        }
    }

    public class TennisGame
    {
        private int _firstPlayerScore;

        private Dictionary<int, string> _scoreDictionary = new()
        {
            {0,"love"},
            {1,"fifteen"},
            {2,"thirty"},
            {3,"forty"},
        };

        private int _secondPlayerScore;
        private string _firstPlayerName;
        private string _secondPlayerName;

        public TennisGame(string firstPlayerName, string secondPlayerName)
        {
            _firstPlayerName = firstPlayerName;
            _secondPlayerName = secondPlayerName;
        }

        public string Score()
        {
            if (_firstPlayerScore == _secondPlayerScore)
            {
                if (_firstPlayerScore >= 3)
                    return Deuce();
                return SameScore();
            }

            if (IsAdv())
                return AdvScore();

            if (IsWin())
                return WinScore();

            return LookupScore();
        }

        private bool IsAdv()
        {
            return _firstPlayerScore >= 3 && _secondPlayerScore >= 3 && Math.Abs(_firstPlayerScore - _secondPlayerScore) == 1;
        }

        private bool IsWin()
        {
            return _firstPlayerScore >= 4 || _secondPlayerScore >= 4;
        }

        private string WinScore()
        {
            return $"{AdvPlayer()} win";
        }

        private string AdvScore()
        {
            return $"{AdvPlayer()} adv";
        }

        private string AdvPlayer()
        {
            return _firstPlayerScore > _secondPlayerScore ? _firstPlayerName : _secondPlayerName;
        }

        private static string Deuce()
        {
            return "deuce";
        }

        private string SameScore()
        {
            return $"{_scoreDictionary[_firstPlayerScore]} all";
        }

        private string LookupScore()
        {
            return $"{_scoreDictionary[_firstPlayerScore]} {_scoreDictionary[_secondPlayerScore]}";
        }

        public void AddFirstPlayerScore()
        {
            _firstPlayerScore++;
        }

        public  void AddSecondPlayerScore()
        {
            _secondPlayerScore++;
        }
    }
}
