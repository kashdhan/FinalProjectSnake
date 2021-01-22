﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;

namespace FinalProjectSnake
{//Kashish Dhanoa
    //Mr.T
    //January 22 2021
    //
    public partial class Form1 : Form
    {     //global variables
        //snake character 
        int snakeX = 100;
        int snakeY = 100;
        int snakeHeight = 15;
        int snakeWidth = 15;
        int snakeSpeed = 7;

        //wall obstacle lists
        List<int> wallXList = new List<int>();
        List<int> wallYList = new List<int>();
        List<int> wallHeightList = new List<int>();
        List<int> wallWidthList = new List<int>();

        //red -1 life obstacle lists
        List<int> redXList = new List<int>();
        List<int> redYList = new List<int>();
        List<int> redDimensionList = new List<int>();

        //blue -4 points obstacle lists
        List<int> blueXList = new List<int>();
        List<int> blueYList = new List<int>();
        List<int> blueDimensionList = new List<int>();

        //gold +4 points 
        List<int> goldXList = new List<int>();
        List<int> goldYList = new List<int>();
        List<int> goldDimensionList = new List<int>();

        //green +1 point
        List<int> greenXList = new List<int>();
        List<int> greenYList = new List<int>();
        List<int> greenDimensionList = new List<int>();

        //initial snake direction
        string direction = "right";

        //initial game screen state
        string gameState = "waiting";

        //move keys 
        bool leftDown = false;
        bool upDown = false;
        bool rightDown = false;
        bool downDown = false;

        //record score, and lives
        int lives;
        int score = 0;

        //play sound effects
        SoundPlayer player;

        // random generator for small green +1 point dots
        Random randGen = new Random();

        //brushes and pens
        SolidBrush greenBrush = new SolidBrush(Color.LightGreen);
        SolidBrush redBrush = new SolidBrush(Color.OrangeRed);
        SolidBrush blueBrush = new SolidBrush(Color.RoyalBlue);
        SolidBrush goldBrush = new SolidBrush(Color.Gold);
        SolidBrush wallBrush = new SolidBrush(Color.White);
        Pen borderPen = new Pen(Color.White, 5);

        public Form1()
        {
            InitializeComponent();
        }

        public void GameInitialize()
        {
            titleLabel.Text = "";//clear
            subtitleLabel.Text = "";//clear
            scoreLabel.Text = $"score: ";//show score in here 
            smallTitle.Text = "SNAKERUN";//title text
            gameTimer.Enabled = true;
        }
        private void GameDifficulty()
        {
            gameState = "difficulty";
            titleLabel.Text = "SnakeRun";
            subtitleLabel.Text = "Difficulties:\nPress E Key for EASY\nPress N Key for NORMAL\nPress H Key for HARD";
        }

        private void GameEasy()
        {
            GameInitialize();
            lives = 5;
            livesLabel.Text = $"lives: {lives}";
            gameState = "runningEasy";
            snakeSpeed = 6;
           
            //red dot obstacle
            redXList.Add(420);
            redYList.Add(270);
            redDimensionList.Add(25);

            redXList.Add(110);
            redYList.Add(150);
            redDimensionList.Add(17);

            redXList.Add(380);
            redYList.Add(80);
            redDimensionList.Add(21);

            //blue dot obstacle
            blueXList.Add(310);
            blueYList.Add(170);
            blueDimensionList.Add(18);

            //gold dot
            goldXList.Add(50);
            goldYList.Add(145);
            goldDimensionList.Add(21);

            goldXList.Add(480);
            goldYList.Add(260);
            goldDimensionList.Add(17);

            //GREEN OBSTACLE HELP
            /* else if (randValue < 11) //5% change of green ball, (get points)
             {
                 ballXList.Add(randGen.Next(10, this.Width - ballSize * 2));
                 ballYList.Add(10);
                 ballSpeedList.Add(randGen.Next(2, 10));
                 ballColourList.Add("green");
             }*/

            greenXList.Add(310);
            greenYList.Add(210);
            greenDimensionList.Add(17);

        }
        private void GameNormal()
        {
            GameInitialize();
            lives = 3;
            livesLabel.Text = $"lives: {lives}";
            gameState = "runningNormal";

            //  wall obstacle
            wallXList.Add(300);
            wallYList.Add(168);
            wallHeightList.Add(150);
            wallWidthList.Add(20);

            wallXList.Add(17);
            wallYList.Add(150);
            wallHeightList.Add(20);
            wallWidthList.Add(150);

            //red dot obstacle
            redXList.Add(410);
            redYList.Add(80);
            redDimensionList.Add(25);

            redXList.Add(225);
            redYList.Add(150);
            redDimensionList.Add(17);

            //blue dot obstacle 
            blueXList.Add(350);
            blueYList.Add(270);
            blueDimensionList.Add(18);

            //gold dot
            goldXList.Add(110);
            goldYList.Add(270);
            goldDimensionList.Add(17);

            //GREEN OBSTACLE HELP
           
        }

        private void GameHard()
        {
            GameInitialize();
            lives = 1;
            livesLabel.Text = $"lives: {lives}";
            gameState = "runningHard";
            snakeSpeed = 9;
          
            //3 walls 
            wallXList.Add(170);
            wallYList.Add(168);
            wallHeightList.Add(150);
            wallWidthList.Add(20);

            wallXList.Add(290);
            wallYList.Add(100);
            wallHeightList.Add(150);
            wallWidthList.Add(20);

            wallXList.Add(410);
            wallYList.Add(50);
            wallHeightList.Add(150);
            wallWidthList.Add(20);

            // 3 red dots 
            redXList.Add(350);
            redYList.Add(110);
            redDimensionList.Add(18);

            redXList.Add(90);
            redYList.Add(240);
            redDimensionList.Add(20);

            redXList.Add(440);
            redYList.Add(270);
            redDimensionList.Add(17);

            // two blue dots
            blueXList.Add(60);
            blueYList.Add(75);
            blueDimensionList.Add(17);


            blueXList.Add(350);
            blueYList.Add(270);
            blueDimensionList.Add(18);
            //GREENOBSTACLE HELP

        }

        private void GameLoser()
        {
            //fill in lose code
            player = new SoundPlayer(Properties.Resources.you_lose);
            player.Play();
            gameTimer.Enabled = false;
            titleLabel.Text = "SNAKE RUN";
            subtitleLabel.Text = "YOU LOSE!\nPress ESC to exit.\nPress SPACE to play again.";
            scoreLabel.Text = "";
            livesLabel.Text = "";
            smallTitle.Text = "";
            gameState = "loser";
        }

        private void GameWinner()
        {
            //fill in win code
            player = new SoundPlayer(Properties.Resources.you_win);
            player.Play();
            gameTimer.Enabled = false;
            titleLabel.Text = "SNAKE RUN";
            subtitleLabel.Text = "YOU WIN! Press ESC to exit.\nPress SPACE to play again.";
            scoreLabel.Text = "";
            livesLabel.Text = "";
            smallTitle.Text = "";
            gameState = "winner";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "winner" || gameState == "loser")
                    {//if space is selected at these gameStates, send player to the Difficultes
                        GameDifficulty();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "winner" || gameState == "loser")
                    {// if esc is selected at these gameStates, exit the program 
                        Application.Exit();
                    }
                    break;
                case Keys.E:
                    if (gameState == "difficulty")
                    {// if E is clicked, send player to EASY
                        GameEasy();
                    }
                    break;
                case Keys.N:
                    if (gameState == "difficulty")
                    {// if N is clicked, send player to NORMAL
                        GameNormal();
                    }
                    break;
                case Keys.H:
                    if (gameState == "difficulty")
                    {// if H is clicked, send player to HARD
                        GameHard();
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            //direction movements
            if (direction == "right" && snakeX < 525)
            {
                snakeX += snakeSpeed;
            }
            else if (direction == "left" && snakeX > 17)
            {
                snakeX -= snakeSpeed;
            }
            else if (direction == "up" && snakeY > 53)
            {
                snakeY -= snakeSpeed;
            }
            else if (direction == "down" && snakeY < 300)
            {
                snakeY += snakeSpeed;
            }

            //use keys to move snake direction
            if (upDown == true)
            {
                direction = "up";
            }
            if (downDown == true)
            {
                direction = "down";
            }
            if (leftDown == true)
            {
                direction = "left";
            }
            if (rightDown == true)
            {
                direction = "right";
            }

            //lose a life when collision with boundaries, reset snake character position
            if (snakeX >= 525 || snakeX <= 16 || snakeY >= 300 || snakeY <= 53)
            {
                player = new SoundPlayer(Properties.Resources.collision);
                player.Play();
                lives--;
                livesLabel.Text = $"lives: {lives}";
                snakeX = 100;
                snakeY = 100;
                direction = "right";
            }

            //once there are no lives left, you are sent to the lose code
            if (lives <= 0)
            {
                GameLoser();
            }

            //once there are 25 or greater points, you are sent to the win code
            if (score >= 10)
            {
                GameWinner();
            }

            //wall collision with snake check & if collision occurs remove a life
            Rectangle snakeRec = new Rectangle(snakeX, snakeY, snakeWidth, snakeHeight);

            for (int i = 0; i < wallXList.Count(); i++)
            {
                Rectangle wallRec = new Rectangle(wallXList[i], wallYList[i], wallWidthList[i], wallHeightList[i]);
               
                if (snakeRec.IntersectsWith(wallRec))
                {
                    player = new SoundPlayer(Properties.Resources.collision);
                    player.Play();
                    lives--;
                    livesLabel.Text = $"lives: {lives}";
                    snakeX = 100;
                    snakeY = 100;
                    direction = "right";
                }
            }

            // red dot collision with snake check & if collision occurs remove a life
            for (int i = 0; i < redXList.Count(); i++)
            {
                Rectangle redRec = new Rectangle(redXList[i], redYList[i], redDimensionList[i], redDimensionList[i]);

                if (snakeRec.IntersectsWith(redRec))
                {
                    player = new SoundPlayer(Properties.Resources.collision);
                    player.Play();
                    lives--;
                    livesLabel.Text = $"lives: {lives}";
                    snakeX = 100;
                    snakeY = 100;
                    direction = "right";
                }
            }

            //blue dot collision with snake check and if it occurs remove 4 points
            for (int i = 0; i < blueXList.Count(); i++)
            {
                Rectangle blueRec = new Rectangle(blueXList[i], blueYList[i], blueDimensionList[i], blueDimensionList[i]);
                if (snakeRec.IntersectsWith(blueRec))
                {
                    player = new SoundPlayer(Properties.Resources.collision); 
                    player.Play();
                    score = score - 4;
                    scoreLabel.Text = $"score: {score}";
                    snakeX = 100;
                    snakeY = 100;
                    direction = "right";
                }
            }

            //gold dot collision with snake check and if it occurs add 4 points
            for (int i = 0; i < goldXList.Count(); i++)
            {
                Rectangle goldRec = new Rectangle(goldXList[i], goldYList[i], goldDimensionList[i], goldDimensionList[i]);
                if (snakeRec.IntersectsWith(goldRec))
                {
                    player = new SoundPlayer(Properties.Resources.collect);
                    player.Play();
                    score = score + 4;
                    scoreLabel.Text = $"score: {score}";
                    snakeX = 100;
                    snakeY = 100;
                    direction = "right";
                    goldXList.RemoveAt(i);//remove after collection
                    goldYList.RemoveAt(i);
                    goldDimensionList.RemoveAt(i);
                }
            }
            for (int i = 0; i < greenXList.Count(); i++)
            {
                Rectangle greenRec = new Rectangle(greenXList[i], greenYList[i], greenDimensionList[i], greenDimensionList[i]);
                if (snakeRec.IntersectsWith(greenRec))
                {
                    player = new SoundPlayer(Properties.Resources.collect);
                    player.Play();
                    score ++;
                    scoreLabel.Text = $"score: {score}";
                    snakeX = 100;
                    snakeY = 100;
                    direction = "right";
                    greenXList.RemoveAt(i);//remove after collection
                    greenYList.RemoveAt(i);
                    greenDimensionList.RemoveAt(i);
                }
            }


            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //when waiting show text screen
            if (gameState == "waiting")
            {
                titleLabel.Text = "SNAKERUN";
                subtitleLabel.Text = "Press SPACE to Begin.\nPress ESC to Exit.";
            }

            //snake chracter and border drawings in all states
            if (gameState == "runningHard" || gameState == "runningNormal" || gameState == "runningEasy")
            {
                e.Graphics.FillRectangle(greenBrush, snakeX, snakeY, snakeWidth, snakeHeight);
                e.Graphics.DrawRectangle(borderPen, 15, 50, 525, 270);

                //paint walls
                for (int i = 0; i < wallXList.Count(); i++)
                {
                    e.Graphics.FillRectangle(wallBrush, wallXList[i], wallYList[i], wallWidthList[i], wallHeightList[i]);
                }
                //paint red dots
                for (int i = 0; i < redXList.Count(); i++)
                {
                    e.Graphics.FillEllipse(redBrush, redXList[i], redYList[i], redDimensionList[i], redDimensionList[i]);
                }
                //paint blue dots
                for (int i = 0; i < blueXList.Count(); i++)
                {
                    e.Graphics.FillEllipse(blueBrush, blueXList[i], blueYList[i], blueDimensionList[i], blueDimensionList[i]);
                }
                //paint gold dots
                for (int i = 0; i < goldXList.Count(); i++)
                {
                    e.Graphics.FillRectangle(goldBrush, goldXList[i], goldYList[i], goldDimensionList[i], goldDimensionList[i]);
                }
                //paint green dots
                for (int i = 0; i < greenXList.Count(); i++)
                {
                    e.Graphics.FillRectangle(greenBrush, greenXList[i], greenYList[i], greenDimensionList[i], greenDimensionList[i]);
                }
            }
            
        }

    }
}
