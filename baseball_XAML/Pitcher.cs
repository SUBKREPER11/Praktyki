using System;

namespace baseball_XAML
{
    class Pitcher
    {
        public Pitcher(Ball ball)
        {
            ball.BallInPlay += new System.EventHandler(ball_BallInPlay);
        }

        private void ball_BallInPlay(object sender, EventArgs e)
        {
            if(e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance < 29) && (ballEventArgs.Trajectory < 60))
                    CatchBall();
                else
                    CoverFirstBase();
            }
        }

        private void CatchBall()
        {
            throw new NotImplementedException();
        }

        private void CoverFirstBase()
        {
            throw new NotImplementedException();
        }
    }
}
