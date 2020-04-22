using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace snake
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
        public Point()
        {
        }
        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Direction dir)
        {
            if(dir == Direction.RIGHT)
            {
                x += offset;
            }
            else if (dir == Direction.LEFT)
            {
                x -= offset;
            }
            else if (dir == Direction.UP)
            {
                y -= offset;
            }
            else if (dir == Direction.DOWN)
            {
                y += offset;
            }
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
        public void Clear()
        {
            sym = ' ';
            Draw();
        }
        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }
    }
}
