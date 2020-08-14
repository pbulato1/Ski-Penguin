using System;
using System.IO;
using System.Windows;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace Slalom
{
    public partial class MainWindow : Window
    {
        //declare data
        private static readonly MediaPlayer raceStart = new MediaPlayer();
        private static readonly MediaPlayer turn = new MediaPlayer();
        private static readonly MediaPlayer accuracySound = new MediaPlayer();
        private static readonly MediaPlayer raceEnd = new MediaPlayer();
        public  static readonly MediaPlayer rabbitRun = new MediaPlayer();
        private static readonly MediaPlayer seagullFly = new MediaPlayer();
        private static readonly MediaPlayer scoreCounter = new MediaPlayer();
        private static readonly MediaPlayer countEnd = new MediaPlayer();
        private static readonly MediaPlayer menuMusic = new MediaPlayer();
        private static readonly MediaPlayer buttonSound = new MediaPlayer();
        private static readonly MediaPlayer wind = new MediaPlayer();

        MediaPlayer[] players = new MediaPlayer[11];
        private static String[] mp3Strings = new String[17];

        ImageBrush backgroundSkin, penguinSkin, rightTreeSkin, leftTreeSkin, leftNetSkin, rightNetSkin, redGateSkin, blueGateSkin, first,
        second, skiisSkin, fenceSkin, blueSkin, redSkin, greenSkin, yellowSkin, topTreelineSkin, colorSkiSkin, slalomSkin, giantSlalomSkin, accuracySkin;
        int goodCount, fairCount, perfectCount, randomNum, cleared, rot, misses, totalScore, lowerBound, upperBound, redPosition, bluePosition, temp;
        DispatcherTimer mainTimer, seaGullTimer, rabbitTimer, wildlifeTimer, arrowTimer;
        double turningPower, slidingImpact, verDistance, horDistance, backgroundSpeed, numOfGates, waitTime;
        public static ImageBrush seagullSkin, rabbitSkin ,confettiSkin, trafficLightSkin;
        public static Rectangle seagull, rabbit, confetti, trafficLight1, trafficLight2;
        bool left, right, isSlalom, onColorScreen,onHelpScreen, introIsDone, once, ready, forward;
        public static DispatcherTimer trafficLightTimer, confettiTimer;
        public static int s, r, c, t;     
        Rectangle[] forest;
        Rectangle[] gates;
        Rectangle[] nets;
        Random rand;
      
        public MainWindow()
        {
            InitializeComponent();
            
            //initialize data
            rand = new Random();
            verDistance = 45;
            horDistance = 18;
            backgroundSpeed = 5;
            numOfGates = 50;

            once = true;
            ready = true;
            forward = true;

            players[0] = menuMusic;
            players[1] = buttonSound;
            players[2] = raceStart;
            players[3] = turn;
            players[4] = accuracySound;
            players[5] = seagullFly;
            players[6] = rabbitRun;
            players[7] = raceEnd;
            players[8] = scoreCounter;
            players[9] = countEnd;
            players[10] = wind;

            mp3Strings[0] = "raceStart.mp3";
            mp3Strings[1] = "miss.mp3";
            mp3Strings[2] = "fair.mp3";
            mp3Strings[3] = "good.mp3";
            mp3Strings[4] = "perfect.mp3";
            mp3Strings[5] = "turn.mp3";
            mp3Strings[6] = "raceEnd.mp3";
            mp3Strings[7] = "rabbitRun.mp3";
            mp3Strings[8] = "seagullFly.mp3";
            mp3Strings[9] = "scoreCounter.mp3";
            mp3Strings[10] = "countEnd.mp3";
            mp3Strings[11] = "menuMusic.mp3";
            mp3Strings[12] = "back.mp3";
            mp3Strings[13] = "option.mp3";
            mp3Strings[14] = "setColor.mp3";
            mp3Strings[15] = "setMode.mp3";
            mp3Strings[16] = "wind.mp3";

            saveMusicToDisk();

            raceStart.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "raceStart.mp3")));
            turn.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "turn.mp3")));
            raceEnd.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "raceEnd.mp3")));
            rabbitRun.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "rabbitRun.mp3")));
            seagullFly.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "seagullFly.mp3")));
            scoreCounter.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "scoreCounter.mp3")));
            countEnd.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "countEnd.mp3")));
            menuMusic.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "menuMusic.mp3")));
            buttonSound.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "option.mp3")));
            wind.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "wind.mp3")));

            raceStart.Volume = 0.3;
            rabbitRun.Volume = 1;
            seagullFly.Volume = 1;
            turn.Volume = 0.3;
            wind.Volume = 0.7;

            mainTimer = new DispatcherTimer();
            seaGullTimer = new DispatcherTimer();
            rabbitTimer = new DispatcherTimer();
            wildlifeTimer = new DispatcherTimer();
            arrowTimer = new DispatcherTimer();
            confettiTimer = new DispatcherTimer();
            trafficLightTimer = new DispatcherTimer();

            trafficLightTimer.Interval = TimeSpan.FromMilliseconds(20);
            confettiTimer.Interval = TimeSpan.FromMilliseconds(10);
            rabbitTimer.Interval = TimeSpan.FromMilliseconds(25);
            arrowTimer.Interval = TimeSpan.FromMilliseconds(16);
            seaGullTimer.Interval = TimeSpan.FromMilliseconds(80);

            trafficLightTimer.Tick += Animations.trafficLightAnimation;
            confettiTimer.Tick += Animations.confettiAnimation;
            seaGullTimer.Tick += Animations.seaGullAnimation;
            rabbitTimer.Tick += Animations.rabbitAnimation;
            wildlifeTimer.Tick += startWildlife;
            arrowTimer.Tick += animateArrow;

            forest = new Rectangle[4];
            gates = new Rectangle[2];
            nets = new Rectangle[4];

            forest[0] = leftTree1;
            forest[1] = leftTree2;
            forest[2] = rightTree1;
            forest[3] = rightTree2;

            gates[0] = redGate;
            gates[1] = blueGate;

            nets[0] = leftNet1;
            nets[1] = leftNet2;
            nets[2] = rightNet1;
            nets[3] = rightNet2;

            mainTimer = new DispatcherTimer();

            trafficLightSkin = new ImageBrush();
            topTreelineSkin = new ImageBrush();
            giantSlalomSkin = new ImageBrush();
            backgroundSkin = new ImageBrush();
            rightTreeSkin = new ImageBrush();
            rightNetSkin = new ImageBrush();
            colorSkiSkin = new ImageBrush();
            confettiSkin = new ImageBrush();
            accuracySkin = new ImageBrush();
            leftTreeSkin = new ImageBrush();
            blueGateSkin = new ImageBrush();
            leftNetSkin = new ImageBrush();
            redGateSkin = new ImageBrush();
            penguinSkin = new ImageBrush();
            seagullSkin = new ImageBrush();
            yellowSkin = new ImageBrush();
            rabbitSkin = new ImageBrush();
            slalomSkin = new ImageBrush();
            greenSkin = new ImageBrush();
            skiisSkin = new ImageBrush();
            fenceSkin = new ImageBrush();
            blueSkin = new ImageBrush();
            redSkin = new ImageBrush();
            second = new ImageBrush();
            first = new ImageBrush();

            //resources loading
            skiisSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/blueSkis.png"));
            backgroundSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/mainMenu/background.jpg"));
            leftNetSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/leftNet.jpg"));
            rightNetSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/rightNet.jpg"));
            redGateSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/redGate.png"));
            blueGateSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/blueGate.png"));
            penguinSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/start.png"));
            fenceSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/fence.png"));
            topTreelineSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/topTreeline.png"));
            slalomSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/modeScreen/slalom.png"));
            giantSlalomSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/modeScreen/giantSlalom.png"));
            leftTreeSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/sideTreeline.png"));
            rightTreeSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/sideTreeline.png"));
            blueSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/b.png"));
            redSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/r.png"));
            greenSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/g.png"));
            yellowSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/y.png"));
            colorSkiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/blueSkis.png"));
            trafficLightSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/trafficLight/0.png"));

            background.Fill = backgroundSkin;
            greenImage.Fill = greenSkin;
            blueImage.Fill = blueSkin;
            yellowImage.Fill = yellowSkin;
            redImage.Fill = redSkin;
            slalom.Fill = slalomSkin;
            giantSlalom.Fill = giantSlalomSkin;
            topTreeline.Fill = topTreelineSkin;
            colorSkis.Fill = colorSkiSkin;
            fence.Fill = fenceSkin;
            penguin.Fill = penguinSkin;
            skis.Fill = skiisSkin;
           
            //animation rectangles
            seagull = new Rectangle();
            seagull.Width = 100;
            seagull.Height = 100;
            myCanvas.Children.Add(seagull);
            Canvas.SetTop(seagull, 200);
            Canvas.SetLeft(seagull, 1100);
            rabbit = new Rectangle();
            rabbit.Width = 70;
            rabbit.Height = 60;
            myCanvas.Children.Add(rabbit);
            Canvas.SetTop(rabbit, 350);
            Canvas.SetLeft(rabbit, 860);
            confetti = new Rectangle();
            confetti.Width = 250;
            confetti.Height = 250;
            Canvas.SetTop(confetti, 410);
            Canvas.SetLeft(confetti, 370);
            myCanvas.Children.Add(confetti);
            trafficLight1 = new Rectangle();
            trafficLight2 = new Rectangle();
            trafficLight1.Width = 80;
            trafficLight1.Height = 75;
            trafficLight2.Width = 80;
            trafficLight2.Height = 75;
            Canvas.SetTop(trafficLight1, 80);
            Canvas.SetLeft(trafficLight1, 400);
            Canvas.SetTop(trafficLight2, 80);
            Canvas.SetLeft(trafficLight2, 500);
            myCanvas.Children.Add(trafficLight1);
            myCanvas.Children.Add(trafficLight2);

            trafficLight1.Fill = trafficLightSkin;
            trafficLight2.Fill = trafficLightSkin;

            trafficLight1.Visibility = Visibility.Collapsed;
            trafficLight2.Visibility = Visibility.Collapsed;

             nets[0].Fill = leftNetSkin;
             nets[1].Fill = leftNetSkin;
             nets[2].Fill = rightNetSkin;
             nets[3].Fill = rightNetSkin;

            gates[0].Fill = redGateSkin;
            gates[1].Fill = blueGateSkin;

            forest[0].Fill = leftTreeSkin;
            forest[1].Fill = leftTreeSkin;
            forest[2].Fill = rightTreeSkin;
            forest[3].Fill = rightTreeSkin;
        
            mainTimer.Interval = TimeSpan.FromMilliseconds(1);
            mainTimer.Tick += gameEngine;       
            menuMusic.Play();         
        }

        //store all sounds locally
        public static void saveMusicToDisk()
        {
            for (int i = 0; i < mp3Strings.Length; i++){
                using (FileStream fileStream = File.Create(System.IO.Path.GetTempPath() + mp3Strings[i])){
                    Assembly.GetExecutingAssembly().GetManifestResourceStream("Slalom.sound." + mp3Strings[i]).CopyTo(fileStream);
                }
            }
        }

        //delete all stored sounds
        public static void DeleteMusicFromDisk(){
            for(int i = 0; i < mp3Strings.Length; i++){
                File.Delete(System.IO.Path.Combine(System.IO.Path.GetTempPath(), mp3Strings[i]));
            }
        }

        //draw the orange helping arrow
        private void animateArrow(object sender, EventArgs e)
        {
            if (forward){
                Canvas.SetTop(arrow, Canvas.GetTop(arrow) + 1);
                if (Canvas.GetTop(arrow) == 120) forward = false;
            }
            else{
                Canvas.SetTop(arrow, Canvas.GetTop(arrow) - 1);
                if (Canvas.GetTop(arrow) == 100) forward = true;
            }
        }
     
        //put everything back once game is done
        private void reset()
        {
            mainTimer.Stop();
            whiteBar.Width = 50;
            Canvas.SetLeft(penguinIcon,120);
            Canvas.SetTop(penguinIcon,15);
            Canvas.SetLeft(lodge, 360);
            Canvas.SetTop(lodge, -60);
            Canvas.SetTop(topTreeline, -25);
            Canvas.SetLeft(fence, 80);
            Canvas.SetTop(fence, 100);
            Canvas.SetTop(leftTree1, 65);
            Canvas.SetTop(leftTree2, 755);
            Canvas.SetTop(rightTree1, 65);
            Canvas.SetTop(rightTree2, 755);
            Canvas.SetTop(leftNet1, 105);
            Canvas.SetLeft(leftNet1, 70);
            Canvas.SetTop(leftNet2, 755);
            Canvas.SetLeft(leftNet2, 70);
            Canvas.SetTop(rightNet1, 105);
            Canvas.SetLeft(rightNet1, 880);
            Canvas.SetTop(rightNet2, 755);
            Canvas.SetLeft(rightNet2, 880);
            Canvas.SetTop(skis, 140);
            Canvas.SetLeft(skis, 475);
            Canvas.SetTop(penguin, 70);
            Canvas.SetLeft(penguin, 460);
            Canvas.SetTop(finish, 700);
            Canvas.SetLeft(finish, 370);
            Canvas.SetTop(trafficLight1, 80);
            Canvas.SetLeft(trafficLight1, 400);
            Canvas.SetTop(trafficLight2, 80);
            Canvas.SetLeft(trafficLight2, 500);
            Canvas.SetTop(seagull, 200);
            Canvas.SetLeft(seagull, 1100);
            Canvas.SetTop(rabbit, 350);
            Canvas.SetLeft(rabbit, 860);
            seagull.Visibility = Visibility.Collapsed;
            rabbit.Visibility = Visibility.Collapsed;
            finish.Visibility = Visibility.Collapsed;
            if (rabbitTimer.IsEnabled) rabbitTimer.Stop();
            if (seaGullTimer.IsEnabled) seaGullTimer.Stop();

            if (wildlifeTimer.IsEnabled) wildlifeTimer.Stop();
            if (arrowTimer.IsEnabled) arrowTimer.Stop();
            rabbitRun.Stop();
            seagullFly.Stop();
            trafficLightTimer.Interval = TimeSpan.FromMilliseconds(20);
            penguinSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/start.png"));
            trafficLightSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/animation/trafficLight/0.png"));
            once = true;
            introIsDone = false;
            raceEnd.Stop();
            countEnd.Stop();
            wind.Stop();
            hideGameOverStuff();
            resetCounters();
            backgroundSpeed = 5;
        }

        //reset all used "counting" variables
        private void resetCounters()
        {
            cleared = 0;
            misses = 0;
            perfectCount = 0;
            goodCount = 0;
            fairCount = 0;
            rot = 0;
            s = 0;
            r = 0;
            c = 0;
            temp = 0;
        }

        //method managing animal animations
        private void startWildlife(object send, EventArgs e)
        {
            int r = rand.Next(1, 3);
        
                switch (r)
                {
                    case 1:
                        seaGullTimer.Start();
                        break;
                    case 2:
                        rabbitTimer.Start();
                        break;
                }
                     
            wildlifeTimer.Stop();
            int ra = rand.Next(17, 25);
            wildlifeTimer.Interval = TimeSpan.FromSeconds(ra);
        }

        //intro animation
        private void animateIntro()
        {
            if (!trafficLightTimer.IsEnabled && Canvas.GetTop(lodge) > -310)
            {
                Canvas.SetTop(lodge, Canvas.GetTop(lodge) - 3);
                Canvas.SetTop(fence, Canvas.GetTop(fence) - 3);
                Canvas.SetTop(topTreeline, Canvas.GetTop(topTreeline) - 3);
                Canvas.SetTop(skis, Canvas.GetTop(skis) + 1);
                Canvas.SetTop(leftTree1, Canvas.GetTop(leftTree1) - 3);
                Canvas.SetTop(leftTree2, Canvas.GetTop(leftTree2) - 3);
                Canvas.SetTop(rightTree1, Canvas.GetTop(rightTree1) - 3);
                Canvas.SetTop(rightTree2, Canvas.GetTop(rightTree2) - 3);
                Canvas.SetTop(leftNet1, Canvas.GetTop(leftNet1) - 3);
                Canvas.SetTop(leftNet2, Canvas.GetTop(leftNet2) - 3);
                Canvas.SetTop(rightNet1, Canvas.GetTop(rightNet1) - 3);
                Canvas.SetTop(rightNet2, Canvas.GetTop(rightNet2) - 3);
                Canvas.SetTop(trafficLight1, Canvas.GetTop(trafficLight1) - 3);
                Canvas.SetTop(trafficLight2, Canvas.GetTop(trafficLight2) - 3);
                Canvas.SetLeft(arrow, Canvas.GetLeft(redGate) + 60);
                arrow.Visibility = Visibility.Visible;
                arrowTimer.Start();
            }
            else if (!trafficLightTimer.IsEnabled && once)
            {
                introIsDone = true;
                fence.Visibility = Visibility.Collapsed;
                topTreeline.Visibility = Visibility.Collapsed;
                lodge.Visibility = Visibility.Collapsed;
                trafficLight1.Visibility = Visibility.Collapsed;
                trafficLight2.Visibility = Visibility.Collapsed;
                skis.Visibility = Visibility.Visible;
                if (once){
                    Canvas.SetTop(skis, Canvas.GetTop(skis) + 1);
                    once = false;
                    raceStart.Stop();
                    progress.Visibility = Visibility.Visible;
                    penguinIcon.Visibility = Visibility.Visible;
                    flags.Visibility = Visibility.Visible;
                    whiteBar.Visibility = Visibility.Visible;
                }
            }
        }

        //draw the penguin depending on the skis' rotation
        private void animatePenguin()
        {
            if (!trafficLightTimer.IsEnabled)
            {
                if (!skis.IsVisible) skis.Visibility = Visibility.Visible;
                if (rot > -12 && rot < 12)//straight range
                {
                    turn.Pause();
                    penguinSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/straight.png"));
                    if (verDistance < 45) verDistance += 2; //straighten the penguin in relation to the skis
                    if (horDistance < 18) horDistance++;
                    else if (horDistance > 18) horDistance--;
                }

                if (left && rot < -30){//change image once at rotation <-30
                    penguinSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/left.png"));
                    turn.Play();
                }
                if (left && rot > -30 && rot < 0){
                    horDistance++;
                    verDistance--;
                }

                if (right && rot > 30){//same for the other side
                    penguinSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/right.png"));
                    turn.Play();
                }
                if (right && rot < 30 && rot > 0){
                    horDistance--;
                    verDistance--;
                }

                Canvas.SetTop(penguin, Canvas.GetTop(skis) - verDistance);
                Canvas.SetLeft(penguin, Canvas.GetLeft(skis) - horDistance);

                if (rot < 0) Canvas.SetLeft(skis, Canvas.GetLeft(skis) + 1);//move skis diagonally unless standing straight
                if (rot > 0) Canvas.SetLeft(skis, Canvas.GetLeft(skis) - 1);
            }
        }

        //respawn gates once they reach the top of the screen
        private void regenerateGates()
        {
            for (int i = 0; i < gates.Length; i++)
            {
                if ((isSlalom && Math.Abs(cleared + misses) < numOfGates-1 && Canvas.GetTop(gates[i]) <= waitTime) || (!isSlalom && Math.Abs(cleared + misses) < numOfGates && Canvas.GetTop(gates[i]) <= waitTime))//jedan manje
                {
                    if (i == 0)//red
                    {
                        int r = rand.Next(lowerBound, upperBound);
                        Canvas.SetLeft(redGate, Canvas.GetLeft(blueGate) + r);
                        if (Canvas.GetLeft(blueGate) + r > 650) Canvas.SetLeft(redGate, 600);//fix
                        Canvas.SetTop(gates[i], 650);
                    }

                    else//blue
                    {
                        int r = rand.Next(lowerBound, upperBound);
                        Canvas.SetLeft(blueGate, Canvas.GetLeft(redGate) - r);
                        if (Canvas.GetLeft(redGate) - r < 100) Canvas.SetLeft(blueGate, 150);//fix
                        Canvas.SetTop(gates[i], 650);
                    }
                }
            }
        }

        //draw the skis depending on user control
        private void animateSkis()
        {
            if (Canvas.GetLeft(skis) <= 95) Canvas.SetLeft(skis, 95);
            else if (Canvas.GetLeft(skis) >= 845) Canvas.SetLeft(skis, 845);

            if (right)
            {
                if (rot > 25) Canvas.SetLeft(skis, Canvas.GetLeft(skis) - turningPower);
                else Canvas.SetLeft(skis, Canvas.GetLeft(skis) + slidingImpact);

                if (rot < 50)
                {
                    skis.RenderTransformOrigin = new Point(0.5, 1);
                    RotateTransform rotateTransform = new RotateTransform(rot += (int)2);
                    skis.RenderTransform = rotateTransform;
                }
            }
            else if (left)
            {
                if (rot < -25) Canvas.SetLeft(skis, Canvas.GetLeft(skis) + turningPower);
                else Canvas.SetLeft(skis, Canvas.GetLeft(skis) - slidingImpact);

                if (rot > -50){
                    RotateTransform rotateTransform = new RotateTransform(rot -= (int)2);
                    skis.RenderTransform = rotateTransform;
                }
            }
        }

         //the game's core method that runs every milisecond
        private void gameEngine(object send, EventArgs e)
        {
            if (arrowTimer.IsEnabled) Canvas.SetLeft(arrow, Canvas.GetLeft(redGate) + 60);
            if (Canvas.GetTop(skis) == Canvas.GetTop(finish)){
                raceEnd.Play();
                confettiTimer.Start();
            }
            if (Canvas.GetTop(skis) >= Canvas.GetTop(finish)) gameOver();
            if (Math.Abs(cleared + misses) == numOfGates)
            {
                penguinIcon.Visibility = Visibility.Collapsed;
                progress.Visibility = Visibility.Collapsed;
                flags.Visibility = Visibility.Collapsed;
                whiteBar.Visibility = Visibility.Collapsed;
                Canvas.SetTop(skis, Canvas.GetTop(skis) + 1); //isti
            }
            if (Canvas.GetTop(skis) > 250) animateFinish();

            animateIntro();
            gateCheck();
            manageAnimations();
            animatePenguin();
            animateSkis();
            regenerateGates();        
            if(introIsDone)move();
        }
      
        //check if gate missed/passed + accuracy
        private void gateCheck()
        {
            if(isSlalom)
            {
                if(whiteBar.Width < 740){
                    whiteBar.Width += 0.15;
                    Canvas.SetLeft(penguinIcon, Canvas.GetLeft(penguinIcon) + 0.15);
                }
            }
            else
            {
                if (whiteBar.Width < 740){
                    whiteBar.Width += 0.14;
                    Canvas.SetLeft(penguinIcon, Canvas.GetLeft(penguinIcon) + 0.14);
                }
            }
           
            //red gate
            if (Canvas.GetTop(skis) == Canvas.GetTop(redGate))
            {
                accuracy.Width = 170;
                accuracy.Height = 65;
                accuracySound.Stop();

                if (!accuracy.IsVisible) accuracy.Visibility = Visibility.Visible;
                if (arrow.IsVisible){
                    arrow.Visibility = Visibility.Collapsed;
                    arrowTimer.Stop();
                }
                if (Canvas.GetLeft(skis) < Canvas.GetLeft(redGate) + 60){
                    accuracySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gamePlay/miss.png"));
                    accuracySound.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "miss.mp3")));
                    misses++;
                }
                else
                {
                    double far = Canvas.GetLeft(skis) - Canvas.GetLeft(redGate);
                    if (far < 90){
                        accuracySound.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "perfect.mp3")));
                        accuracy.Width = 230;
                        accuracy.Height = 64;
                        accuracySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gamePlay/perfect.png"));
                        perfectCount++;
                    }
                    else if (far > 90 && far <= 125){
                        accuracySound.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "good.mp3")));
                        accuracySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gamePlay/good.png"));
                        goodCount++;
                    }
                    else{
                        accuracySound.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "fair.mp3")));
                        accuracySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gamePlay/fair.png"));
                        fairCount++;
                    }
                    cleared++;
                    points.Content = cleared.ToString();
                }
                accuracySound.Play();
                accuracy.Fill = accuracySkin;
            }
            //blue gate
            else if (Canvas.GetTop(skis) == Canvas.GetTop(blueGate))
            {
                accuracy.Width = 170;
                accuracy.Height = 65;
                accuracySound.Stop();

                if (Canvas.GetLeft(skis) > Canvas.GetLeft(blueGate) + 30){
                    accuracySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gamePlay/miss.png"));
                    accuracySound.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "miss.mp3")));
                    misses++;
                }
                else
                {
                    double far = Canvas.GetLeft(blueGate) - Canvas.GetLeft(skis);
                    if (far < 0){
                        accuracySound.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "perfect.mp3")));
                        accuracy.Width = 230;
                        accuracy.Height = 64;
                        accuracySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gamePlay/perfect.png"));
                        perfectCount++;
                    }
                    else if (far > 0 && far <= 35){
                        accuracySound.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "good.mp3")));
                        accuracySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gamePlay/good.png"));
                        goodCount++;
                    }
                    else{
                        accuracySound.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "fair.mp3")));
                        accuracySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gamePlay/fair.png"));
                        fairCount++;
                    }
                    cleared++;
                    points.Content = cleared.ToString();
                }
                accuracySound.Play();
                accuracy.Fill = accuracySkin;
            }
        }

        //end of the race method that auto-controls the skis and guides them through the finish
        private void autoSki()
        {
            if (verDistance < 45) verDistance += 2; //straighten the penguin in relation to the skis
            if (horDistance < 18) horDistance++;
            else if (horDistance > 18) horDistance--;

            if (Canvas.GetLeft(skis) < Canvas.GetLeft(finish) + 100)
            {
                left = true;
                rot = -31;
                horDistance++;
                verDistance--;
                Canvas.SetLeft(skis, Canvas.GetLeft(skis) + 2);
            }
            else if (Canvas.GetLeft(skis) > Canvas.GetLeft(finish) + 120)
            {
                right = true;
                rot = 31;
                horDistance--;
                verDistance--;
                Canvas.SetLeft(skis, Canvas.GetLeft(skis) - 2);
            }
            else
            {
                rot = 0;
                left = false;
                right = false;
                RotateTransform rotateTransform = new RotateTransform(0);
                skis.RenderTransform = rotateTransform;
            }
        }

        //draw the race finish animation
        private void animateFinish()
        {
            turn.Stop();
            turningPower = 1.5;
            if (Canvas.GetTop(finish) > 460)
            {
                if (Canvas.GetTop(finish) == 700) finish.Visibility = Visibility.Visible;
                Canvas.SetTop(finish, Canvas.GetTop(finish) - 3);
            }
            Canvas.SetTop(skis, Canvas.GetTop(skis) + 2);
            if (Canvas.GetTop(skis) > 750) confetti.Visibility = Visibility.Collapsed;
            autoSki();
        }

        //method to move the trees,nets and the 2 gates
        private void move()
        {     
            if(Canvas.GetTop(finish) != 460 && Math.Abs(misses + cleared) <= numOfGates)
            {
                if (Math.Abs(misses + cleared) == numOfGates) backgroundSpeed = 3;

                    for (int i = 0; i < nets.Length; i++){
                    if (Canvas.GetTop(nets[i]) <= -680) Canvas.SetTop(nets[i], 650);
                    Canvas.SetTop(nets[i], Canvas.GetTop(nets[i]) - backgroundSpeed);
                }

                for (int i = 0; i < 4; i++){
                    if (Canvas.GetTop(forest[i]) <= -730) Canvas.SetTop(forest[i], 650);
                    Canvas.SetTop(forest[i], Canvas.GetTop(forest[i]) - backgroundSpeed);
                }
            }
                                  
            if (introIsDone){
                for (int i = 0; i < gates.Length; i++){
                   Canvas.SetTop(gates[i], Canvas.GetTop(gates[i]) - backgroundSpeed);
                }
            }                          
        }

        //wildlife animations check
        private void manageAnimations()
        {
             if (Math.Abs(cleared+misses) >= randomNum) if(!wildlifeTimer.IsEnabled)wildlifeTimer.Start();
            if (seaGullTimer.IsEnabled)
            {
                if (Canvas.GetLeft(seagull) < -100)
                {
                    seaGullTimer.Stop();
                    seagullFly.Stop();
                    Canvas.SetLeft(seagull, 1100);
                    wildlifeTimer.Start();
                }
                else{
                    Canvas.SetLeft(seagull, Canvas.GetLeft(seagull) - 2);
                    if (Canvas.GetLeft(seagull) == 900) seagullFly.Play();
                }
            }

            if (rabbitTimer.IsEnabled)
            {
                if (Canvas.GetLeft(rabbit) < 100)
                {
                    rabbitTimer.Stop();
                    rabbitRun.Stop();
                    rabbit.Visibility = Visibility.Collapsed;
                    Canvas.SetLeft(rabbit, 860);
                    wildlifeTimer.Start();
                }
                else Canvas.SetLeft(rabbit, Canvas.GetLeft(rabbit) - 4);
            }        
        }

        //animate game over stuff
        private void gameOver()
        {
            totalScore = (5 * cleared + 2 * perfectCount + goodCount);
            if (temp <= totalScore) temp++;
            totalScoreNum.Visibility = Visibility.Visible;
            confetti.Visibility = Visibility.Visible;
            gatesClearedImage.Visibility = Visibility.Visible;
            accuracy.Visibility = Visibility.Collapsed;
            fairImage.Visibility = Visibility.Visible;
            goodImage.Visibility = Visibility.Visible;
            perfectImage.Visibility = Visibility.Visible;
            points.Visibility = Visibility.Visible;

            fairNum.Text = fairCount.ToString() + " X";
            goodNum.Text = goodCount.ToString() + " X";
            perfectNum.Text = perfectCount.ToString() + " X";

            fairNum.Visibility = Visibility.Visible;
            goodNum.Visibility = Visibility.Visible;
            perfectNum.Visibility = Visibility.Visible;
            totalScoreImage.Visibility = Visibility.Visible;

            if (temp <= totalScore)
            {
                scoreCounter.Play();
                totalScoreNum.Content = temp.ToString();
                if (temp == totalScore)
                {
                    countEnd.Play();
                    scoreCounter.Stop();
                    restartButton.Visibility = Visibility.Visible;
                    menuButton.Visibility = Visibility.Visible;
                }
            }
        }

        //stop all the imers
        private void stopTimers()
        {
            mainTimer.Stop();
            confettiTimer.Stop();
            arrowTimer.Stop();
            trafficLightTimer.Stop();
            wildlifeTimer.Stop();
            seaGullTimer.Stop();
            rabbitTimer.Stop();
        }

        //button, key events, playing button sounds, hiding and showing data
        //------------------------------------------------------------------------------------------------------
        private void myCanvas_KeyUp(object sender, KeyEventArgs e){
            if (e.Key == Key.Left) left = false;
            if (e.Key == Key.Right) right = false;
        }

        private void myCanvas_KeyDown(object sender, KeyEventArgs e){
            if (e.Key == Key.Left) left = true;
            if (e.Key == Key.Right) right = true;
            if (e.Key == Key.Space && penguin.IsVisible && ready)
            {
                buttonSound.Stop();
                trafficLightTimer.Start();
                raceStart.Play();
                pressSpace.Visibility = Visibility.Collapsed;
                spaceButton.Visibility = Visibility.Collapsed;
                randomNum = rand.Next(10, 40);
                mainTimer.Start();
                if(isSlalom){
                    turningPower = 3.8;
                    slidingImpact = 2.2;
                    lowerBound = 70;
                    upperBound = 150;
                    redPosition = 710;
                    bluePosition = 1080;
                    waitTime = -115;
                }
                else{
                    turningPower = 5;
                    slidingImpact = 2.3;
                    lowerBound = 150;
                    upperBound = 280;
                    redPosition = 710;
                    bluePosition = 1150;
                    waitTime = -215;
                }                   
                    int r = rand.Next(150, 650);
                    Canvas.SetLeft(redGate, r);
                    Canvas.SetTop(redGate, redPosition);                    
                    r = rand.Next(lowerBound, upperBound);
                    Canvas.SetLeft(blueGate, Canvas.GetLeft(redGate) - r);
                    if (Canvas.GetLeft(redGate) - r < 100) Canvas.SetLeft(blueGate, 150);//fix
                    Canvas.SetTop(blueGate, bluePosition);
                    ready = false;
            }
        }

        private void hideGameOverStuff()
        {
            restartButton.Visibility = Visibility.Collapsed;
            menuButton.Visibility = Visibility.Collapsed;
            gatesClearedImage.Visibility = Visibility.Collapsed;
            fairImage.Visibility = Visibility.Collapsed;
            goodImage.Visibility = Visibility.Collapsed;
            perfectImage.Visibility = Visibility.Collapsed;
            fairNum.Visibility = Visibility.Collapsed;
            goodNum.Visibility = Visibility.Collapsed;
            perfectNum.Visibility = Visibility.Collapsed;
            totalScoreImage.Visibility = Visibility.Collapsed;
            totalScoreNum.Visibility = Visibility.Collapsed;
            skis.Visibility = Visibility.Collapsed;
            points.Visibility = Visibility.Collapsed;
        }

        private void hideMenuStuff()
        {
            playButton.Visibility = Visibility.Collapsed;
            helpButton.Visibility = Visibility.Collapsed;
            quitButton.Visibility = Visibility.Collapsed;
            background.Width = 800;
            background.Height = 750;
            Canvas.SetLeft(background, 80);         
        }

        private void showGamePlayStuff()
        {
            wind.Play();
            backgroundSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/gameplay/snow.jpg"));
            pressSpace.Visibility = Visibility.Visible;
            spaceButton.Visibility = Visibility.Visible;
            spaceButton.Visibility = Visibility.Visible;
            penguin.Visibility = Visibility.Visible;
            leftTree1.Visibility = Visibility.Visible;
            leftTree2.Visibility = Visibility.Visible;
            rightTree1.Visibility = Visibility.Visible;
            rightTree2.Visibility = Visibility.Visible;
            leftNet1.Visibility = Visibility.Visible;
            leftNet2.Visibility = Visibility.Visible;
            rightNet1.Visibility = Visibility.Visible;
            rightNet2.Visibility = Visibility.Visible;
            redGate.Visibility = Visibility.Visible;
            blueGate.Visibility = Visibility.Visible;
            topTreeline.Visibility = Visibility.Visible;
            fence.Visibility = Visibility.Visible;
            lodge.Visibility = Visibility.Visible;
            trafficLight1.Visibility = Visibility.Visible;
            trafficLight2.Visibility = Visibility.Visible;
            ready = true;
        }

        private void showColorScreenStuff()
        {
            backgroundSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/background.jpg"));
            background.Width = 980;
            background.Height = 750;
            Canvas.SetLeft(background, -10);
            Canvas.SetTop(background, -30);
            redButton.Visibility = Visibility.Visible;
            blueButton.Visibility = Visibility.Visible;
            yellowButton.Visibility = Visibility.Visible;
            greenButton.Visibility = Visibility.Visible;
            RotateTransform rotateTransform = new RotateTransform(90);
            colorSkis.RenderTransform = rotateTransform;
            colorSkis.Visibility = Visibility.Visible;
            penguinBrush.Visibility = Visibility.Visible;
            chooseColor.Visibility = Visibility.Visible;
            backButton.Visibility = Visibility.Visible;
        }

        private void hideColorScreenStuff()
        {
            redButton.Visibility = Visibility.Collapsed;
            blueButton.Visibility = Visibility.Collapsed;
            yellowButton.Visibility = Visibility.Collapsed;
            greenButton.Visibility = Visibility.Collapsed;
            colorSkis.Visibility = Visibility.Collapsed;
            penguinBrush.Visibility = Visibility.Collapsed;
            chooseColor.Visibility = Visibility.Collapsed;
            tick.Visibility = Visibility.Collapsed;
            continueButton.Visibility = Visibility.Collapsed;
        }

        private void hideGameModeScreenStuff()
        {
            tick.Visibility = Visibility.Collapsed;
            slalomButton.Visibility = Visibility.Collapsed;
            giantSlalomButton.Visibility = Visibility.Collapsed;
            slalomText.Visibility = Visibility.Collapsed;
            giantSlalomText.Visibility = Visibility.Collapsed;
            penguinSki.Visibility = Visibility.Collapsed;
            chooseMode.Visibility = Visibility.Collapsed;
            continueButton.Visibility = Visibility.Collapsed;
            Canvas.SetTop(tick, 282);
            tick.Width = 80;
            tick.Height = 80;
        }

        private void showGameModeScreenStuff()
        {
            tick.Visibility = Visibility.Collapsed;
            slalomButton.Visibility = Visibility.Visible;
            giantSlalomButton.Visibility = Visibility.Visible;
            slalomText.Visibility = Visibility.Visible;
            giantSlalomText.Visibility = Visibility.Visible;
            penguinSki.Visibility = Visibility.Visible;
            chooseMode.Visibility = Visibility.Visible;
        }

        private void hideGamePlayStuff()
        {
            lodge.Visibility = Visibility.Collapsed;
            arrow.Visibility = Visibility.Collapsed;
            topTreeline.Visibility = Visibility.Collapsed;
            fence.Visibility = Visibility.Collapsed;
            leftTree1.Visibility = Visibility.Collapsed;
            leftTree2.Visibility = Visibility.Collapsed;
            rightTree1.Visibility = Visibility.Collapsed;
            rightTree2.Visibility = Visibility.Collapsed;
            leftNet1.Visibility = Visibility.Collapsed;
            leftNet2.Visibility = Visibility.Collapsed;
            rightNet1.Visibility = Visibility.Collapsed;
            rightNet2.Visibility = Visibility.Collapsed;
            redGate.Visibility = Visibility.Collapsed;
            blueGate.Visibility = Visibility.Collapsed;
            skis.Visibility = Visibility.Collapsed;
            penguin.Visibility = Visibility.Collapsed;
            points.Visibility = Visibility.Collapsed;
            trafficLight1.Visibility = Visibility.Collapsed;
            trafficLight2.Visibility = Visibility.Collapsed;
        }

        private void showMenuStuff()
        {
            backgroundSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/mainMenu/background.jpg"));
            playButton.Visibility = Visibility.Visible;
            helpButton.Visibility = Visibility.Visible;
            quitButton.Visibility = Visibility.Visible;
            menuMusic.Play();
        }

        private void restart(object sender, RoutedEventArgs e)
        {
            ready = true;
            reset();
            wind.Play();
            pressSpace.Visibility = Visibility.Visible;
            spaceButton.Visibility = Visibility.Visible;
            lodge.Visibility = Visibility.Visible;
            topTreeline.Visibility = Visibility.Visible;
            fence.Visibility = Visibility.Visible;
            trafficLight1.Visibility = Visibility.Visible;
            trafficLight2.Visibility = Visibility.Visible;
            seagull.Visibility = Visibility.Visible;
        }

        private void sl(object sender, RoutedEventArgs e)
        {
            playSetModeSound();
            if (!tick.IsVisible) tick.Visibility = Visibility.Visible;
            if (!continueButton.IsVisible) continueButton.Visibility = Visibility.Visible;
            Canvas.SetLeft(tick, 255);
            Canvas.SetTop(tick, 340);
            isSlalom = true;
        }

        private void gs(object sender, RoutedEventArgs e)
        {
            playSetModeSound();
            if (!tick.IsVisible) tick.Visibility = Visibility.Visible;
            if (!continueButton.IsVisible) continueButton.Visibility = Visibility.Visible;
            Canvas.SetLeft(tick, 535);
            Canvas.SetTop(tick, 340);
            isSlalom = false;
        }

        private void menu(object sender, RoutedEventArgs e)
        {
            reset();
            hideGamePlayStuff();
            showMenuStuff();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            buttonSound.Stop();
            buttonSound.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "back.mp3")));
            buttonSound.Play();

            if(onHelpScreen)
            {
                onHelpScreen = false;
                hideHelpScreenStuff();
            }

            else if (onColorScreen)
            {
                hideColorScreenStuff();
                showMenuStuff();
                backButton.Visibility = Visibility.Collapsed;
                onColorScreen = false;
            }
            else
            {
                hideGameModeScreenStuff();
                showColorScreenStuff();
                onColorScreen = true;
            }
        }

        private void play(object sender, RoutedEventArgs e)
        {
            playOptionSound();
            hideMenuStuff();
            showColorScreenStuff();
            onColorScreen = true;
        }
        private void help(object sender, RoutedEventArgs e){
            playOptionSound();
            showHelpScreenStuff();
                 
        }

        private void showHelpScreenStuff()
        {
            onHelpScreen = true;
            backgroundSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/background.jpg"));
            playButton.Visibility = Visibility.Collapsed;
            helpButton.Visibility = Visibility.Collapsed;
            quitButton.Visibility = Visibility.Collapsed;
            backButton.Visibility = Visibility.Visible;
            helpTitle.Visibility = Visibility.Visible;
            helpControls.Visibility = Visibility.Visible;
            helpRules.Visibility = Visibility.Visible;
            helpGameModes.Visibility = Visibility.Visible;
            helpControlsText.Visibility = Visibility.Visible;
            helpControlsText1.Visibility = Visibility.Visible;
            helpLeft.Visibility = Visibility.Visible;
            helpRight.Visibility = Visibility.Visible;
            helpSpace.Visibility = Visibility.Visible;
            helpRulesText.Visibility = Visibility.Visible;
            helpPts.Visibility = Visibility.Visible;
            helpPerfect.Visibility = Visibility.Visible;
            helpGood.Visibility = Visibility.Visible;
            helpFair.Visibility = Visibility.Visible;
            helpSlalom.Visibility = Visibility.Visible;
            helpSlalomText.Visibility = Visibility.Visible;
            helpGiantSlalom.Visibility = Visibility.Visible;
            helpGiantSlalomText.Visibility = Visibility.Visible;
        }

        private void hideHelpScreenStuff()
        {
            backgroundSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/mainMenu/background.jpg"));
            playButton.Visibility = Visibility.Visible;
            helpButton.Visibility = Visibility.Visible;
            quitButton.Visibility = Visibility.Visible;
            backButton.Visibility = Visibility.Collapsed;
            helpTitle.Visibility = Visibility.Collapsed;
            helpControls.Visibility = Visibility.Collapsed;
            helpRules.Visibility = Visibility.Collapsed;
            helpGameModes.Visibility = Visibility.Collapsed;
            helpControlsText.Visibility = Visibility.Collapsed;
            helpControlsText1.Visibility = Visibility.Collapsed;
            helpLeft.Visibility = Visibility.Collapsed;
            helpRight.Visibility = Visibility.Collapsed;
            helpSpace.Visibility = Visibility.Collapsed;
            helpRulesText.Visibility = Visibility.Collapsed;
            helpPts.Visibility = Visibility.Collapsed;
            helpPerfect.Visibility = Visibility.Collapsed;
            helpGood.Visibility = Visibility.Collapsed;
            helpFair.Visibility = Visibility.Collapsed;
            helpSlalom.Visibility = Visibility.Collapsed;
            helpSlalomText.Visibility = Visibility.Collapsed;
            helpGiantSlalom.Visibility = Visibility.Collapsed;
            helpGiantSlalomText.Visibility = Visibility.Collapsed;
        }

        private void quit(object sender, RoutedEventArgs e){
            Close();
            playOptionSound();
            stopSound();
            stopTimers();
            DeleteMusicFromDisk();
            Application.Current.Shutdown();
        }

        private void proceed(object send, RoutedEventArgs e)
        {
            playOptionSound();
            if (onColorScreen)
            {
                hideColorScreenStuff();
                showGameModeScreenStuff();
                tick.Width = 100;
                tick.Height = 100;
                onColorScreen = false;
            }
            else
            {
                hideGameModeScreenStuff();
                showGamePlayStuff();
                backButton.Visibility = Visibility.Collapsed;
                menuMusic.Stop();
            }
        }
    
        private void red(object sender, RoutedEventArgs e)
        {
            playSetColorSound();
            colorSkiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/redSkis.png"));
            skiisSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/redSkis.png"));
            if (!tick.IsVisible) tick.Visibility = Visibility.Visible;
            if (!continueButton.IsVisible) continueButton.Visibility = Visibility.Visible;
            Canvas.SetLeft(tick, 615);
        }

        private void blue(object sender, RoutedEventArgs e)
        {
            playSetColorSound();
            colorSkiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/blueSkis.png"));
            skiisSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/blueSkis.png"));
            if (!tick.IsVisible) tick.Visibility = Visibility.Visible;
            if (!continueButton.IsVisible) continueButton.Visibility = Visibility.Visible;
            Canvas.SetLeft(tick, 465);
        }

        private void yellow(object sender, RoutedEventArgs e)
        {
            playSetColorSound();
            colorSkiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/yellowSkis.png"));
            skiisSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/yellowSkis.png"));
            if (!tick.IsVisible) tick.Visibility = Visibility.Visible;
            if (!continueButton.IsVisible) continueButton.Visibility = Visibility.Visible;
            Canvas.SetLeft(tick, 315);
        }

        private void green(object sender, RoutedEventArgs e)
        {
            playSetColorSound();
            colorSkiSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/greenSkis.png"));
            skiisSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/colorScreen/greenSkis.png"));
            if (!tick.IsVisible) tick.Visibility = Visibility.Visible;
            if (!continueButton.IsVisible) continueButton.Visibility = Visibility.Visible;
            Canvas.SetLeft(tick, 165);
        }

        private void playSetModeSound()
        {
            buttonSound.Stop();
            buttonSound.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "setMode.mp3")));
            buttonSound.Play();
        }

        private void playOptionSound()
        {
            buttonSound.Stop();
            buttonSound.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "option.mp3")));
            buttonSound.Play();
        }

        private void playSetColorSound()
        {
            buttonSound.Stop();
            buttonSound.Open(new Uri(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "setColor.mp3")));
            buttonSound.Play();
        }

        public void stopSound()
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].Close();
            }
            menuMusic.Stop();
            buttonSound.Stop();
        }
    }
}