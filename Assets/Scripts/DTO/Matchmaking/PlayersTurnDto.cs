namespace DTO.Matchmaking
{
    public class PlayersTurnDto
    {
        private bool _firstPlayerReady;
        private bool _secondPlayerReady;

        public bool RoundIsEnd()
        {
            return _firstPlayerReady && _secondPlayerReady;
        }

        public void OnPlayersTurn()
        {
            if (!_firstPlayerReady) _firstPlayerReady = true;
            else _secondPlayerReady = true;
        }

        public void Restart()
        {
            _firstPlayerReady = _secondPlayerReady = false;
        }
    }
}