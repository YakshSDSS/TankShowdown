using System;
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

namespace TankShowdown
{
    public partial class TankShowdown : Form
    {
        bool leftPressed = false;
        bool rightPressed = false;
        bool upPressed = false;
        bool downPressed = false;
        bool lPressed = false;
        bool wPressed = false;
        bool aPressed = false;
        bool sPressed = false;
        bool dPressed = false;
        bool rPressed = false;

        int playerSpeed = 6;
        int player1Cooldown = 0;
        int player2Cooldown = 0;
        int map = 1;
        int powerUpTime = 100;
        int p1Lives = 3;
        int p2Lives = 3;
        int borderTime = 5000;

        string player1Direction = "right";
        string player2Direction = "left";
        string powerUp1 = "none";
        string powerUp2 = "none";
        string winner;
        string loser;


        Rectangle player1 = new Rectangle(50, 650, 20, 20);
        Rectangle player2 = new Rectangle(650, 150, 20, 20);
        Rectangle player1Cannon = new Rectangle(70, 655, 10, 10);
        Rectangle player2Cannon = new Rectangle(640, 155, 10, 10);
        Rectangle border = new Rectangle(0, 100, 700, 600);

        List<string> bulletDirection = new List<string>();
        List<int> bulletSpeed = new List<int>();
        List<int> bulletSize = new List<int>();
        List<int> damageTime = new List<int>();
        List<int> speedTime = new List<int>();
        List<Rectangle> bullets = new List<Rectangle>();
        List<Rectangle> maze = new List<Rectangle>();
        List<Rectangle> speedPowerUp = new List<Rectangle>();
        List<Rectangle> damagePowerUp = new List<Rectangle>();

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greyBrush = new SolidBrush(Color.White);
        SolidBrush mazeBrush = new SolidBrush(Color.Green);
        SolidBrush damageBrush = new SolidBrush(Color.Orange);
        SolidBrush speedBrush = new SolidBrush(Color.Yellow);
        Pen borderPen = new Pen(Color.White,2);

        Image redHeart = Properties.Resources.red_heart_removebg_preview;
        Image blueHeart = Properties.Resources.blue_heart_removebg_preview;

        Stopwatch powerUpWatch = new Stopwatch();

        Random randGen = new Random();

        public TankShowdown()
        {

            InitializeComponent();
            titleLabel.Text = "Tank Showdown";
            Refresh();
        }

        private void TankShowdown_Paint(object sender, PaintEventArgs e)
        {
            if (gameTimer.Enabled == false)
            {
                titleLabel.Text = "Tank Showdown";
                p1Label.Text = "Player 1";
                p2Label.Text = "Player 2";
                p2Control.Text = "Arrows to move, L to shoot";
                p1Control.Text = "W, A, S, D to move, R to shoot";
                startLabel.Text = "Press space to start, ESC to exit";

                p1L1.Visible = false;
                p1L2.Visible = false;
                p1L3.Visible = false;
                p2L1.Visible = false;
                p2L2.Visible = false;
                p2L3.Visible = false;
                p2Cooldown.Visible = false;
                p1Cooldown.Visible = false;
                borderCount.Visible = false;

                infoLabel.Visible = true;
                p1Label.Visible = true;
                p2Label.Visible = true;
                p1Control.Visible = true;
                p2Control.Visible = true;
                startLabel.Visible = true;
                titleLabel.Visible = true;

                logoBox.BackgroundImage = Properties.Resources.Tank_Showdown_transparent_removebg_preview;
            }
            else
            {
                p1L1.Visible = true;
                p1L2.Visible = true;
                p1L3.Visible = true;
                p2L1.Visible = true;
                p2L2.Visible = true;
                p2L3.Visible = true;
                p2Cooldown.Visible = true;
                p1Cooldown.Visible = true;
                borderCount.Visible = true;

                infoLabel.Visible = false;
                p1Label.Visible = false;
                p2Label.Visible = false;
                p1Control.Visible = false;
                p2Control.Visible = false;
                startLabel.Visible = false;
                titleLabel.Visible = false;

                p2Cooldown.Text = $"{player2Cooldown}";
                p1Cooldown.Text = $"{player1Cooldown}";
                borderCount.Text = $"Border closing in... {borderTime}";
                

                logoBox.BackgroundImage = null;

                e.Graphics.FillRectangle(blueBrush, player1);
                e.Graphics.FillRectangle(redBrush, player2);
                e.Graphics.FillRectangle(blueBrush, player1Cannon);
                e.Graphics.FillRectangle(redBrush, player2Cannon);
                e.Graphics.DrawRectangle(borderPen, border);

                for (int i = 0; i < bullets.Count; i++)
                {
                    e.Graphics.FillEllipse(greyBrush, bullets[i]);
                }

                for (int i = 0; i < maze.Count; i++)
                {
                    e.Graphics.FillRectangle(mazeBrush, maze[i]);
                }
                for (int i = 0; i < damagePowerUp.Count; i++)
                {
                    e.Graphics.FillRectangle(damageBrush, damagePowerUp[i]);
                }
                for (int i = 0; i < speedPowerUp.Count; i++)
                {
                    e.Graphics.FillRectangle(speedBrush, speedPowerUp[i]);
                }

                if (p1Lives == 3)
                {
                    p1L1.BackgroundImage = blueHeart;
                    p1L2.BackgroundImage = blueHeart;
                    p1L3.BackgroundImage = blueHeart;
                }
                else if (p1Lives == 2)
                {
                    p1L1.BackgroundImage = blueHeart;
                    p1L2.BackgroundImage = blueHeart;
                    p1L3.BackgroundImage = null;
                }
                else if (p1Lives == 1)
                {
                    p1L1.BackgroundImage = blueHeart;
                    p1L2.BackgroundImage = null;
                    p1L3.BackgroundImage = null;
                }
                else if (p1Lives == 0)
                {
                    p1L1.BackgroundImage = null;
                    p1L2.BackgroundImage = null;
                    p1L3.BackgroundImage = null;
                }

                if (p2Lives == 3)
                {
                    p2L1.BackgroundImage = redHeart;
                    p2L2.BackgroundImage = redHeart;
                    p2L3.BackgroundImage = redHeart;
                }
                else if (p2Lives == 2)
                {
                    p2L1.BackgroundImage = redHeart;
                    p2L2.BackgroundImage = redHeart;
                    p2L3.BackgroundImage = null;
                }
                else if (p2Lives == 1)
                {
                    p2L1.BackgroundImage = redHeart;
                    p2L2.BackgroundImage = null;
                    p2L3.BackgroundImage = null;
                }
                else if (p2Lives == 0)
                {
                    p2L1.BackgroundImage = null;
                    p2L2.BackgroundImage = null;
                    p2L3.BackgroundImage = null;
                }
            }
        }

        private void TankShowdown_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.L:
                    lPressed = true;
                    break;
                case Keys.A:
                    aPressed = true;
                    break;
                case Keys.D:
                    dPressed = true;
                    break;
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.R:
                    rPressed = true;
                    break;
                case Keys.Space:
                    if (gameTimer.Enabled == false)
                    {
                        InitializeGame();
                    }
                    break;
                case Keys.Escape:
                    if (gameTimer.Enabled == false)
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void TankShowdown_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.L:
                    lPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.R:
                    rPressed = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Randomly spawn speedy bullet powerups.
            
            if (powerUpWatch.ElapsedMilliseconds > 5000)
            {
                Rectangle speedBullet = new Rectangle(randGen.Next(20, 680), randGen.Next(120, 680), 20, 20);
                Rectangle damageBullet = new Rectangle(randGen.Next(20, 680), randGen.Next(120, 680), 20, 20);

                for (int i = 0; i < maze.Count; i++)
                {
                    if (speedBullet.IntersectsWith(maze[i]))        //Move powerup so it doesn't sit on the wall.
                    {
                        speedBullet.X = speedBullet.X + 35;
                        speedBullet.Y = speedBullet.Y + 35;
                        
                    }
                    if (damageBullet.IntersectsWith(maze[i])) //Move powerup so it doesn't sit on wall.
                    {
                        damageBullet.X = damageBullet.X + 35;
                        damageBullet.Y = damageBullet.Y + 35;
                    }
                }
                speedPowerUp.Add(speedBullet);
                damagePowerUp.Add(damageBullet);
                speedTime.Add(250);
                damageTime.Add(250);
                powerUpWatch.Restart();
            }

            //Remove powerUps after a certain amount of time.
            for (int i = 0; i < damageTime.Count; i++)
            {
                damageTime[i]--;
                if (damageTime[i] < 0)
                {
                    damageTime.RemoveAt(i);
                    damagePowerUp.RemoveAt(i);
                }
            }
            for (int i = 0; i < speedTime.Count; i++)
            {
                speedTime[i]--;
                if (speedTime[i] < 0)
                {
                    speedTime.RemoveAt(i);
                    speedPowerUp.RemoveAt(i);
                }
            }

            //Give players the double damage powerup if they pick it up.
            for (int i = 0; i < damagePowerUp.Count; i++)
            {
                if (player1.IntersectsWith(damagePowerUp[i]))
                {
                    damagePowerUp.RemoveAt(i);
                    damageTime.RemoveAt(i);
                    powerUp1 = "damage";
                    break;
                }

                if (player2.IntersectsWith(damagePowerUp[i]))
                {
                    damagePowerUp.RemoveAt(i);
                    damageTime.RemoveAt(i);
                    powerUp2 = "damage";
                    break;
                }
            }
            //Give players the speedy bullet powerup if they pick it up.
            for (int i = 0; i < speedPowerUp.Count; i++)
            {
                if (player1.IntersectsWith(speedPowerUp[i]))
                {
                    speedPowerUp.RemoveAt(i);
                    speedTime.RemoveAt(i);
                    powerUp1 = "speed";
                    break;
                }

                if (player2.IntersectsWith(speedPowerUp[i]))
                {
                    speedPowerUp.RemoveAt(i);
                    speedTime.RemoveAt(i);
                    powerUp2 = "speed";
                    break;
                }
            }
            


            //MOVE PLAYER 1
            if (wPressed == true && dPressed == false && aPressed == false)
            {
                player1.Y = player1.Y - playerSpeed;
                player1Direction = "up";
                player1Cannon = new Rectangle(player1.X + 5, player1.Y - 10, 10, 10);
            }
            if (aPressed == true && sPressed == false && wPressed == false)
            {
                player1.X = player1.X - playerSpeed;
                player1Direction = "left";
                player1Cannon = new Rectangle(player1.X - 10, player1.Y + 5, 10, 10);
            }
            if (sPressed == true && dPressed == false && aPressed == false)
            {
                player1.Y = player1.Y + playerSpeed;
                player1Direction = "down";
                player1Cannon = new Rectangle(player1.X + 5, player1.Y + 20, 10, 10);
            }
            if (dPressed == true && sPressed == false && wPressed == false)
            {
                player1.X = player1.X + playerSpeed;
                player1Direction = "right";
                player1Cannon = new Rectangle(player1.X + 20, player1.Y + 5, 10, 10);
            }

            //MOVE PLAYER 2
            if (upPressed == true && rightPressed == false && leftPressed == false)
            {
                player2.Y = player2.Y - playerSpeed;
                player2Direction = "up";
                player2Cannon = new Rectangle(player2.X + 5, player2.Y - 10, 10, 10);
            }
            if (leftPressed == true && downPressed == false && upPressed == false)
            {
                player2.X = player2.X - playerSpeed;
                player2Direction = "left";
                player2Cannon = new Rectangle(player2.X - 10, player2.Y + 5, 10, 10);
            }
            if (downPressed == true && rightPressed == false && leftPressed == false)
            {
                player2.Y = player2.Y + playerSpeed;
                player2Direction = "down";
                player2Cannon = new Rectangle(player2.X + 5, player2.Y + 20, 10, 10);
            }
            if (rightPressed == true && downPressed == false && upPressed == false)
            {
                player2.X = player2.X + playerSpeed;
                player2Direction = "right";
                player2Cannon = new Rectangle(player2.X + 20, player2.Y + 5, 10, 10);
            }
            //Make player 1 not able to go outside of boundaries.
            for (int i = 0; i < maze.Count; i++)
            {
                if (player1Cannon.IntersectsWith(maze[i]))
                {
                    if (wPressed == true)
                    {
                        player1.Y = player1.Y + playerSpeed;
                        player1Cannon.Y = player1Cannon.Y + playerSpeed;
                    }
                    if (sPressed == true)
                    {
                        player1.Y = player1.Y - playerSpeed;
                        player1Cannon.Y = player1Cannon.Y - playerSpeed;
                    }
                    if (aPressed == true)
                    {
                        player1.X = player1.X + playerSpeed;
                        player1Cannon.X = player1Cannon.X + playerSpeed;
                    }
                    if (dPressed == true)
                    {
                        player1.X = player1.X - playerSpeed;
                        player1Cannon.X = player1Cannon.X - playerSpeed;
                    }
                }
                //Make player 2 not be able to go outside boundaries.
                if (player2Cannon.IntersectsWith(maze[i]))
                {
                    if (upPressed == true)
                    {
                        player2.Y = player2.Y + playerSpeed;
                        player2Cannon.Y = player2Cannon.Y + playerSpeed;
                    }
                    if (downPressed == true)
                    {
                        player2.Y = player2.Y - playerSpeed;
                        player2Cannon.Y = player2Cannon.Y - playerSpeed;
                    }
                    if (leftPressed == true)
                    {
                        player2.X = player2.X + playerSpeed;
                        player2Cannon.X = player2Cannon.X + playerSpeed;
                    }
                    if (rightPressed == true)
                    {
                        player2.X = player2.X - playerSpeed;
                        player2Cannon.X = player2Cannon.X - playerSpeed;
                    }
                }
            }

            //Add a bullet if player 1 shoots depending on their powerup.
            if (rPressed == true && player1Cooldown <= 0 && powerUp1 == "none")
            {
                Rectangle bullet = new Rectangle(player1Cannon.X, player1Cannon.Y, 0, 0);
                bullets.Add(bullet);

                DetermineBulletDirection1();
                bulletSize.Add(10);
                bulletSpeed.Add(12);
                player1Cooldown = 100;
                powerUp1 = "none";
            }
            else if (rPressed == true && player1Cooldown <= 0 && powerUp1 == "speed")
            {
                Rectangle bullet = new Rectangle(player1Cannon.X, player1Cannon.Y, 0, 0);
                bullets.Add(bullet);

                DetermineBulletDirection1();
                bulletSize.Add(5);
                bulletSpeed.Add(18);
                player1Cooldown = 100;
                powerUp1 = "none";
            }
            else if (rPressed == true && player1Cooldown <= 0 && powerUp1 == "damage")
            {
                if (player1Direction == "up")
                {
                    Rectangle bullet = new Rectangle(player1Cannon.X, player1Cannon.Y - 5, 0, 0);
                    bullets.Add(bullet);
                }
                else if (player1Direction == "left") 
                {
                    Rectangle bullet = new Rectangle(player1Cannon.X - 5, player1Cannon.Y, 0, 0);
                    bullets.Add(bullet);
                }
                else 
                {
                    Rectangle bullet = new Rectangle(player1Cannon.X, player1Cannon.Y, 0, 0);
                    bullets.Add(bullet);
                }

                DetermineBulletDirection1();
                bulletSize.Add(20);
                bulletSpeed.Add(8);
                player1Cooldown = 100;
                powerUp1 = "none";
            }

            //Add a bullet if player 2 shoots depending on their powerup.
            if (lPressed == true && player2Cooldown <= 0 && powerUp2 == "none")
            {
                Rectangle bullet = new Rectangle(player2Cannon.X, player2Cannon.Y, 0, 0);
                bullets.Add(bullet);

                DetermineBulletDirection2();
                bulletSize.Add(10);
                bulletSpeed.Add(12);
                player2Cooldown = 100;
                powerUp2 = "none";
            }
            else if (lPressed == true && player2Cooldown <= 0 && powerUp2 == "speed")
            {
                Rectangle bullet = new Rectangle(player2Cannon.X, player2Cannon.Y, 0, 0);
                bullets.Add(bullet);

                DetermineBulletDirection2();
                bulletSize.Add(5);
                bulletSpeed.Add(18);
                player2Cooldown = 100;
                powerUp2 = "none";
            }
            else if (lPressed == true && player2Cooldown <= 0 && powerUp2 == "damage")
            {
                if (player2Direction == "up")
                {
                    Rectangle bullet = new Rectangle(player2Cannon.X, player2Cannon.Y - 5, 0, 0);
                    bullets.Add(bullet);
                }
                else if (player2Direction == "left")
                {
                    Rectangle bullet = new Rectangle(player2Cannon.X - 5, player2Cannon.Y, 0, 0);
                    bullets.Add(bullet);
                }
                else
                {
                    Rectangle bullet = new Rectangle(player2Cannon.X, player2Cannon.Y, 0, 0);
                    bullets.Add(bullet);
                }

                

                DetermineBulletDirection2();
                bulletSize.Add(20);
                bulletSpeed.Add(8);
                player2Cooldown = 100;
                powerUp2 = "none";
            }

            //Move bullets shot by players in approperiate directions.
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bulletDirection[i] == "up")
                {
                    int move = bullets[i].Y - bulletSpeed[i];
                    bullets[i] = new Rectangle(bullets[i].X, move, bulletSize[i], bulletSize[i]);
                }
                if (bulletDirection[i] == "down")
                {
                    int move = bullets[i].Y + bulletSpeed[i];
                    bullets[i] = new Rectangle(bullets[i].X, move, bulletSize[i], bulletSize[i]);
                }
                if (bulletDirection[i] == "right")
                {
                    int move = bullets[i].X + bulletSpeed[i];
                    bullets[i] = new Rectangle(move, bullets[i].Y, bulletSize[i], bulletSize[i]);
                }
                if (bulletDirection[i] == "left")
                {
                    int move = bullets[i].X - bulletSpeed[i];
                    bullets[i] = new Rectangle(move, bullets[i].Y, bulletSize[i], bulletSize[i]);
                }
            }
            //Remove bullets if they collide with the maze.
            for (int i = 0; i < bullets.Count; i++)
            {
                for (int j = 0; j < maze.Count; j++)
                {
                    if (bullets[i].IntersectsWith(maze[j]))
                    {
                        bullets.RemoveAt(i);
                        bulletDirection.RemoveAt(i);
                        bulletSize.RemoveAt(i);
                        bulletSpeed.RemoveAt(i);
                        break;
                    }
                }
            }

            //Check if players collide with bullets and remove lives and reset their position if they do.
            for (int i = 0; i < bullets.Count; i++)
            {
                if (player1.IntersectsWith(bullets[i]) && bulletSpeed[i] == 12)
                {
                    p1Lives--;
                    player1.X = 50;
                    player1.Y = 650;

                    bullets.RemoveAt(i);
                    bulletDirection.RemoveAt(i);
                    bulletSize.RemoveAt(i);
                    bulletSpeed.RemoveAt(i);
                    player1Cannon.X = 70;
                    player1Cannon.Y = 655;
                    break;
                }
                else if (player1.IntersectsWith(bullets[i]) && bulletSpeed[i] == 18)
                {
                    p1Lives--;
                    player1.X = 50;
                    player1.Y = 650;

                    bullets.RemoveAt(i);
                    bulletDirection.RemoveAt(i);
                    bulletSize.RemoveAt(i);
                    bulletSpeed.RemoveAt(i);
                    player1Cannon.X = 70;
                    player1Cannon.Y = 655;
                    break;
                }
                else if (player1.IntersectsWith(bullets[i]) && bulletSpeed[i] == 8)
                {
                    p1Lives = p1Lives - 2;
                    player1.X = 50;
                    player1.Y = 650;

                    bullets.RemoveAt(i);
                    bulletDirection.RemoveAt(i);
                    bulletSize.RemoveAt(i);
                    bulletSpeed.RemoveAt(i);
                    player1Cannon.X = 70;
                    player1Cannon.Y = 655;
                    break;
                }
                if (player2.IntersectsWith(bullets[i]) && bulletSpeed[i] == 12)
                {
                    p2Lives--;
                    player2.X = 650;
                    player2.Y = 150;

                    bullets.RemoveAt(i);
                    bulletDirection.RemoveAt(i);
                    bulletSize.RemoveAt(i);
                    bulletSpeed.RemoveAt(i);
                    player2Cannon.X = 640;
                    player2Cannon.Y = 155;
                    break;
                }
                else if (player2.IntersectsWith(bullets[i]) && bulletSpeed[i] == 18)
                {
                    p2Lives--;
                    player2.X = 650;
                    player2.Y = 150;

                    bullets.RemoveAt(i);
                    bulletDirection.RemoveAt(i);
                    bulletSize.RemoveAt(i);
                    bulletSpeed.RemoveAt(i);
                    player2Cannon.X = 640;
                    player2Cannon.Y = 155;
                    break;
                }
                else if (player2.IntersectsWith(bullets[i]) && bulletSpeed[i] == 8)
                {
                    p2Lives = p2Lives - 2;
                    player2.X = 650;
                    player2.Y = 150;

                    bullets.RemoveAt(i);
                    bulletDirection.RemoveAt(i);
                    bulletSize.RemoveAt(i);
                    bulletSpeed.RemoveAt(i);
                    player2Cannon.X = 640;
                    player2Cannon.Y = 155;
                    break;
                }
            }

            //End game if a player reaches 0 lives.
            if (p1Lives <= 0)
            {
                gameTimer.Enabled = false;
                winner = "Player 2 wins!";
                loser = "Player 1 loses!";
            }
            else if (p2Lives <= 0)
            {
                gameTimer.Enabled = false;
                winner = "Player 1 wins!";
                loser = "Player 2 loses!";
            }

            //Close the border once it is time.
            if (borderTime > 0)
            {
                borderTime--;
            }
            else if (borderTime == 0)
            {
                border.X++;
                border.Y++;
                border.Width = border.Width - 2;
                border.Height = border.Height - 2;
            }

            //Kill players imediately if they hit the border.
            if (player1.X < border.X || player1.Y < border.Y || player1.X > border.X + border.Width - 20 || player1.Y > border.Y + border.Height - 20)
            {
                p1Lives = 0;
            }
            if (player2.X < border.X || player2.Y < border.Y || player2.X > border.X + border.Width - 20 || player2.Y > border.Y + border.Height - 20)
            {
                p2Lives = 0;
            }

            //Reset cooldown for players.
            if (player1Cooldown > 0)
            {
                player1Cooldown--;
            }
            if (player2Cooldown > 0)
            {
                player2Cooldown--;
            }
            powerUpTime--;


            Refresh();


        }

        public void DrawMap1()
        {
            //Draw the map.
            Rectangle maze1 = new Rectangle(300, 200, 400, 15);
            maze.Add(maze1);
            Rectangle maze2 = new Rectangle(300, 300, 400, 15);
            maze.Add(maze2);
            Rectangle maze3 = new Rectangle(300, 300, 15, 200);
            maze.Add(maze3);
            Rectangle maze4 = new Rectangle(500, 300, 15, 200);
            maze.Add(maze4);
            Rectangle maze5 = new Rectangle(600, 385, 100, 15);
            maze.Add(maze5);
            Rectangle maze6 = new Rectangle(600, 385, 15, 215);
            maze.Add(maze6);
            Rectangle maze7 = new Rectangle(200, 585, 400, 15);
            maze.Add(maze7);
            Rectangle maze8 = new Rectangle(165, 100, 15, 200);
            maze.Add(maze8);
            Rectangle maze9 = new Rectangle(60, 200, 115, 15);
            maze.Add(maze9);
            Rectangle maze10 = new Rectangle(60, 285, 115, 15);
            maze.Add(maze10);
            Rectangle maze11 = new Rectangle(0, 100, 700, 15);
            maze.Add(maze11);
            Rectangle maze12 = new Rectangle(0, 100, 15, 600);
            maze.Add(maze12);
            Rectangle maze13 = new Rectangle(685, 100, 15, 600);
            maze.Add(maze13);
            Rectangle maze14 = new Rectangle(0, 685, 700, 15);
            maze.Add(maze14);
        }
        public void DetermineBulletDirection2()
        {
            //Determine what direction the bullet should be shot for player 1.
            if (player2Direction == "up")
            {
                bulletDirection.Add("up");
            }
            else if (player2Direction == "down")
            {
                bulletDirection.Add("down");
            }
            else if (player2Direction == "right")
            {
                bulletDirection.Add("right");
            }
            else if (player2Direction == "left")
            {
                bulletDirection.Add("left");
            }
        }

        public void InitializeGame()
        {

            p1Lives = 3;
            p2Lives = 3;
            player1Cooldown = 0;
            player2Cooldown = 0;
            borderTime = 5000;
            powerUpTime = 100;

            powerUp1 = "none";
            powerUp2 = "none";
            player1Direction = "right";
            player2Direction = "left";
            winner = "";
            loser = "";

            player1.X = 50;
            player1.Y = 650;
            player2.X = 650;
            player2.Y = 150;
            player1Cannon.X = 70;
            player1Cannon.Y = 655;
            player2Cannon.X = 640;
            player2Cannon.Y = 155;

            Rectangle border = new Rectangle(0, 100, 700, 600);

            bulletSize.Clear();
            bulletSpeed.Clear();
            bullets.Clear();
            damagePowerUp.Clear();
            speedPowerUp.Clear();
            bulletDirection.Clear();
            maze.Clear();
            damageTime.Clear();
            speedTime.Clear();

            DrawMap1();
            powerUpWatch.Start();
            gameTimer.Enabled = true;
        }
        public void DetermineBulletDirection1()
        {
            //Determine what direction the bullet should be shot for player 2.
            if (player1Direction == "up")
            {
                bulletDirection.Add("up");
            }
            else if (player1Direction == "down")
            {
                bulletDirection.Add("down");
            }
            else if (player1Direction == "right")
            {
                bulletDirection.Add("right");
            }
            else if (player1Direction == "left")
            {
                bulletDirection.Add("left");
            }
        }
        public void RemoveBullet()
        {
            
        }

        private void TankShowdown_Load(object sender, EventArgs e)
        {
            titleLabel.Text = "Tank Showdown";
            Refresh();
        }
    }
}

