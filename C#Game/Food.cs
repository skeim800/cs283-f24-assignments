// Food class for A02 game assignment
// September 2024
// Sarah Keim

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public class Food
{
    public float x;
    public float y;
    public int direction;
    public bool eaten;
    public Rectangle foodShape;

    public Food(float a, float b, int startDirection)
    {
        x = a;
        y = b;
        direction = startDirection;
        eaten = false;
        foodShape = new Rectangle(((int)a), ((int)b), 60, 60);
    }

    public void Update(float dt)
    {
        if (!eaten)
        {
            Random r = new Random();
            if (direction == 1)
            {
                x += r.Next(1, 30) * dt;
            }
            else
            {
                x -= r.Next(1, 30) * dt;
            }

            if (x > 600)
            {
                direction = 0;
            }
            else if (x < 0)
            {
                direction = 1;
            }
            foodShape = new Rectangle(((int)x), ((int)y), 60, 60);
        }
    }

    public void Draw(Graphics g, Image burger)
    {
        if (!eaten)
        {
            Color c = Color.FromArgb(0, 0, 0, 0);
            Brush brush = new SolidBrush(c);
            g.FillRectangle(brush, foodShape);

            g.DrawImage(burger, foodShape);
        }
        else
        {
            Color c = Color.FromArgb(0, 250, 0, 0);
            Brush brush = new SolidBrush(c);
            g.FillRectangle(brush, foodShape);
        }
    }
}