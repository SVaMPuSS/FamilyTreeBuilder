using System;
using System.Collections.Generic;
using System.Windows;

namespace FamilyTreeBuilder.Model
{
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public static int Width { get; set; }
        public static int Height { get; set; }
        private Point position;

        public Point Position
        {
            get { return position; }
            set
            {
                position = value;
            }
        }

        public bool CheckClick(Point location) => !(location.X < Position.X && location.Y > Position.Y && Position.X+Width < location.X && Position.Y + Height < location.Y);

        public List<Human> Children { get; set; }
        public List<Human> Parents { get; set; }
        public Human()
        {
            Children = new List<Human>();
            Parents = new List<Human>();
        }

    }
}
