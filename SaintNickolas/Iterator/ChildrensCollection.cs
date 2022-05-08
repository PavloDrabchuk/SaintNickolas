using System.Collections.Generic;

namespace SaintNickolas.Iterator
{
    public class ChildrensCollection : IterableCollection
    {
        List<Children> childrens = new();

        public override Iterator createIterator()
        {
            return new ConcreteIterator(this);
        }

        public int count
        {
            get { return childrens.Count; }
        }

        public Children this[int index]
        {
            get { return childrens[index]; }
            set { childrens.Insert(index, value); }
        }

        public void addItem(Children children)
        {
            this.childrens.Add(children);
        }

        public List<Children> getItems()
        {
            return childrens;
        }
    }
}
