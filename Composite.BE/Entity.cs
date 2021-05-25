using Composite.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.BE
{
    public abstract class Entity : IEntity
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
