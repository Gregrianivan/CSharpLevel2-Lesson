﻿/* 
 * 2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
 * 3. Сделать так, чтобы при столкновениях пули с астероидом они регенерировались в разных концах экрана.
 * 4. Сделать проверку на задание размера экрана в классе Game. Если высота или ширина (Width, Height) 
 * больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().
 * 5. *Создать собственное исключение GameObjectException, которое появляется при попытке создать объект 
 * с неправильными характеристиками (например, отрицательные размеры, слишком большая скорость или позиция).
 * 
 * Сыроватский Иван
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameSyrovatskijIS
{
    class Program
    {
        static void Main(string[] args)
        {
            Form menu = new Form();
            menu.Width = 800;
            menu.Height = 600;


            SplashScreen.Init(menu);
            menu.Show();
            SplashScreen.Draw();

            Button startBtn = new Button
            {
                Text = "Играть",
                Location = new System.Drawing.Point(menu.Width / 2 - 30, menu.Height / 3)

            };
            startBtn.Click += startBtnClick;
            menu.Controls.Add(startBtn);

            Button recordsBtn = new Button
            {
                Text = "Рекорды",
                Location = new System.Drawing.Point(menu.Width / 2 - 30, menu.Height - menu.Height / 2)

            };
            recordsBtn.Click += recordsBtnClick;
            menu.Controls.Add(recordsBtn);

            Button exitBtn = new Button
            {
                Text = "Выход",
                Location = new System.Drawing.Point(menu.Width / 2 - 30, menu.Height - menu.Height / 3)

            };
            exitBtn.Click += exitBtnClick;
            menu.Controls.Add(exitBtn);

            Label autor = new Label
            {
                Text = "Ivan Syrovatskij " + DateTime.Now.Year.ToString(),
                ForeColor = System.Drawing.Color.White,
                BackColor = System.Drawing.Color.Black,
                AutoSize = true,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new System.Drawing.Point(menu.Width / 10, menu.Height - menu.Height / 6)

            };
            menu.Controls.Add(autor);

            Application.Run(menu);


            void exitBtnClick(object sender, EventArgs e)
            {
                menu.Close();
            }

            void recordsBtnClick(object sender, EventArgs e) { }

            void startBtnClick(object sender, EventArgs e)
            {
                Form game = new Form()
                {
                    Width = Screen.PrimaryScreen.Bounds.Width,
                    Height = Screen.PrimaryScreen.Bounds.Height
                };
                //game.Width = 800;
                //game.Height = 600;
                Game.Init(game);
                game.FormClosed += Game_FormClosed;
                game.Show();
                Game.Draw();
            }
        }

        /// <summary>Метод остановки таймера при завершении работы программы</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Game.timer.Stop();
        }
    }

}
