// Game implementation for A02 game assignment
// September 2024
// Sarah Keim

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public class Game
{
    Player _player = null;
    Food[] _foods = new Food[12];

    public void Setup()
    {
        _player = new Player();

        Random r = new Random();
        for (int i = _foods.Length - 1; i >= 0; i--)
        {
            _foods[i] = new Food(r.Next(1, 600), r.Next(1, 450), r.Next(0,2));
        }
    }

    public void Update(float dt)
    {
        foreach (Food food in _foods)
        {
            food.Update(dt);
            if (_player.playerShape.IntersectsWith(food.foodShape))
            {
                if (!food.eaten)
                {
                    _player.Grow();
                }
                food.eaten = true; 
            }
        }
    }

    public void Draw(Graphics g, Image frog, Image burger)
    {
        if (Array.FindAll(_foods, food => food.eaten).Length == _foods.Length)
        {
            // Code from Assignment 02 description on course website
            Font font = new Font("Arial", 46);
            SolidBrush fontBrush = new SolidBrush(Color.White);

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            g.DrawString("HE'S ALL FULL!", font, fontBrush,
               (float)(Window.width * 0.5),
               (float)(Window.height * 0.5),
               format);
        }
        else
        {
            // Modified code from Assignment 02 description on course website
            Font font = new Font("Arial", 12);
            SolidBrush fontBrush = new SolidBrush(Color.Black);

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Far;
            format.Alignment = StringAlignment.Far;

            g.DrawString("Hungry Hungry Froggie\nSarah Keim\n2025", font, fontBrush,
               (float)(Window.width * 0.97),
               (float)(Window.height * 0.97),
               format);

            foreach (Food food in _foods)
            {
                food.Draw(g, burger);
            }
            _player.Draw(g, frog);
        }
    }

    public void MouseClick(MouseEventArgs mouse)
    {
        if (mouse.Button == MouseButtons.Left)
        {
            System.Console.WriteLine(mouse.Location.X + ", " + mouse.Location.Y);
        }
    }

    public void KeyDown(KeyEventArgs key)
    {
        if (key.KeyCode == Keys.D || key.KeyCode == Keys.Right)
        {
            _player.x += 8;
        }
        else if (key.KeyCode== Keys.S || key.KeyCode == Keys.Down)
        {
            _player.y += 8;
        }
        else if (key.KeyCode == Keys.A || key.KeyCode == Keys.Left)
        {
            _player.x -= 8;
        }
        else if (key.KeyCode == Keys.W || key.KeyCode == Keys.Up)
        {
            _player.y -= 8;
        }
        _player.playerShape = new Rectangle((int)_player.x, (int)_player.y, _player.size, _player.size);
    }
}
