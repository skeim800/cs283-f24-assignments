// Player class for A02 game assignment
// September 2024
// Sarah Keim

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public class Player
{
    public float x;
    public float y;
    public int size;
    public Rectangle playerShape;

    public Player()
    {
        x = 300;
        y = 200;
        size = 65;
        playerShape = new Rectangle(300, 200, size, size);
    }

    public void Update(float dt)
    {
    }

    public void Grow()
    {
        size += 8;
        playerShape = new Rectangle((int)x, (int)y, size, size);
    }

    public void Draw(Graphics g, Image frog)
    {
        Color c = Color.FromArgb(0, 0, 0, 0);
        Brush brush = new SolidBrush(c);
        g.FillRectangle(brush, playerShape);

        g.DrawImage(frog, playerShape);
    }
}