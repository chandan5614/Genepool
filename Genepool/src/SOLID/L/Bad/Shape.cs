using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.SOLID.L.Bad
{
    public abstract class Shape
    {
        public abstract double Area { get; }
    }

    public class Rectangle : Shape
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }

        public override double Area => Width * Height;
    }

    public class Square : Rectangle
    {
        // Violates LSP by allowing independent setting of Width and Height
        public override double Width
        {
            get => base.Width;
            set => base.Width = base.Height = value;
        }

        public override double Height
        {
            get => base.Height;
            set => base.Height = base.Width = value;
        }
    }
}