namespace OneBackComboTrainingWeb
{
    public class TennisGame
    {
        private string _firstPlayer;
        private string _secondPlayer;
        private int _firstPlayerScore;
        private int _secondPlayerScore;
        private Dictionary<int, string> _scoreDictionary = new()
        {
            { 0, "love" },
            { 1, "fifteen" },
            { 2, "thirty" },
            { 3, "forty" },
        };

        public TennisGame(string firstPlayer, string secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
        }
        public string Score()
        {
            if (_firstPlayerScore >= 3 && _secondPlayerScore >= 3)
            {
                if (_firstPlayerScore == _secondPlayerScore)
                    return "deuce";
                if (Math.Abs(_firstPlayerScore - _secondPlayerScore) == 1)
                    return _firstPlayerScore > _secondPlayerScore
                        ? $"{_firstPlayer} adv"
                        : $"{_secondPlayer} adv";
                if (Math.Abs(_firstPlayerScore - _secondPlayerScore) == 2)
                    return _firstPlayerScore > _secondPlayerScore
                        ? $"{_firstPlayer} win"
                        : $"{_secondPlayer} win";
                return "Error";
            }

            if (_firstPlayerScore == _secondPlayerScore)
            {
                return $"{_scoreDictionary[_firstPlayerScore]} all";
            }

            if (_firstPlayerScore == 4)
            {
                return $"{_firstPlayer} win";
            }
            if (_secondPlayerScore == 4)
            {
                return $"{_secondPlayer} win";
            }

            return $"{_scoreDictionary[_firstPlayerScore]} {_scoreDictionary[_secondPlayerScore]}";
        }

        public void AddFirstPlayerScore()
        {
            _firstPlayerScore++;
        }
        public void AddSecondPlayerScore()
        {
            _secondPlayerScore++;
        }
    }
}
