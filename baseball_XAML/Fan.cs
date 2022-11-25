using System.Collections.ObjectModel;

namespace baseball_XAML
{
    class Fan
    {
        public ObservableCollection<string> FanSays = new ObservableCollection<string>();
        private int pitchNumber = 0;

        public Fan(Ball ball)
        {
            ball.BallInPlay += new System.EventHandler(ball_BallInPlay);
        }

        void ball_BallInPlay(object sender, BallEventArgs e)
        {
            pitchNumber++;
            if(e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if (ballEventArgs.Distance > 120 && ballEventArgs.aTrajectory > 30)
                    FanSays.Add("Rzut nr " + pitchNumber
                        + ": Home run! Idę po piłkę!");
                else
                    FanSays.Add("Rzut nr " + pitchNumber + " Jeee! Do boju!");
            }
        }
    }
}
