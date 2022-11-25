using System;

namespace baseball_XAML
{
    class Ball
    {
        public event EventHandler BallInPlay;
        public void OnBallInPlay(BallEventsArgs e)
        {
            EventHandler ballInPlay = BallInPlay;
            if (ballInPlay != null)
                ballInPlay(this, e);
        }
    }
}
