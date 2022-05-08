namespace SaintNickolas.Iterator
{
    public class ConcreteIterator : Iterator
    {
        ChildrensCollection childrensCollection;
        int current = 0;

        public ConcreteIterator(ChildrensCollection collection)
        {
            this.childrensCollection = collection;
        }

        public override object CurrentItem()
        {
            return childrensCollection[current];
        }

        public override object First()
        {
            return childrensCollection[0];
        }

        public override bool IsDone()
        {
            return current >= childrensCollection.count;
        }

        public override object Next()
        {
            object ret = null;
            if (current < childrensCollection.count - 1)
            {
                ret = childrensCollection[++current];
            }

            return ret;
        }
    }
}
