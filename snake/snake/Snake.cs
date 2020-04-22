using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace snake
{
    class Snake : Figure
    {

        Direction dir;
        public Snake(Point tail, int lenght, Direction direction)
        {
            dir = direction;
            pList = new List<Point>();
            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point( tail );
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }
        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, dir);
            return nextPoint;

        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                dir = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                dir = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow)
                dir = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow)
                dir = Direction.UP;
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();

            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i<pList.Count -2;i++)
            {
                if (head.IsHit(pList[i])) return true;
            }
            return false;
        }
       
    }
}
