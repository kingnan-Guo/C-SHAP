namespace 迭代器
{
    class CustomList<T>: IEnumerable, IEnumerator
    {
        private int[] list;

        private int index = -1;
        public CustomList(int[] list)
        {

            // this.list = new int[list.Length];
            // for (int i = 0; i < list.Length; i++)
            // {
            //     this.list[i] = list[i];
            // }


            this.list = new int[] {1, 2, 3};
        }


        // public IEnumerator<T> GetEnumerator()
        // {

        //     return this;
        // }

        public object Current{
            get{
                return list[index];
            }
        }

        // public T Current{
        //     get{
        //         return (T)list[index];
        //     }
        // }

        public bool MoveNext()
        {
            ++index;
            return index < list.Length;
        }

        public void Reset()
        {
            index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            int[] list = {1, 2, 3};
            CustomList<int> customList = new CustomList<int>(list);
            foreach (var item in customList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
