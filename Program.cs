using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace List_1
{
    internal class Program
    {

        public class MyList<T> : IEnumerable<T>
        {

            private T[] array = Array.Empty<T>();

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    yield return array[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public  void Insert(T value, int index)
            {
                T[] newArray = new T[array.Length + 1];

                newArray[index] = value;

                for(int i = 0; i < index; i++)
                {
                    newArray[i] = array[i]; 
                }

                for (int i = index; i <array.Length; i++)
                {
                    newArray[i + 1] = array[i]; 
                }

                array = newArray;
            }

            public void Add(T value)
            {
                var newArray = new T[array.Length + 1];

                for (int i = 0; i < array.Length; i++)
                {
                    newArray[i] = array[i];
                }

                newArray[array.Length] = value;
                array = newArray;
            }

            public  void AddFirst(T value)
            {
                Insert(value, 0);
            }

            public  void AddLast(T value)
            {
                Insert( value, array.Length);
            }
            public  int MyLength()
            {
                
                return array.Length;
            }
            public void PrintByIndex(int index)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == index)
                    {
                        Console.WriteLine(array[i]);
                    }
                }
                
            }

            public void Remove(int index)
            {
                T[] newArray = new T[array.Length - 1];

                
                for (int i = 0; i < index; i++)
                {
                    newArray[i] = array[i];
                }

                for (int i = index + 1; i < array.Length; i++)
                {
                    newArray[i - 1] = array[i];
                }

                array = newArray;
            }

            public void RemoveFirst()
            {
                Remove(0);
            }

            public void RemoveLast()
            {
                Remove(array.Length - 1);
            }
            

        }
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(4);
            list.Add(5);
            list.Add(8);
            // Додавання елементів
            foreach (int el in list)
            {
                Console.WriteLine(el);
            }

            //Додавання елементу по індексу
            list.Insert(9, 1);
            Console.WriteLine();
            foreach (int el in list)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();

            // Додавання елементу на початок списку
            list.AddFirst(12);
            foreach (int el in list)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();

            //Додавання елементу в кінець списку
            list.AddLast(14);
            foreach (int el in list)
            {
                Console.WriteLine(el);
            }

            Console.WriteLine();
            Console.WriteLine("Довжина списку");
            //дізнатися скільки елементів в списку
            Console.WriteLine(list.MyLength());
            Console.WriteLine();

            //Видаляємо елемент за індексом
            list.Remove(3);
            foreach (int el in list)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();

            //видаляємо перший елемент
            list.RemoveFirst();
            foreach (int el in list)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();

            //видаляємо останній елемент
            list.RemoveLast();
            foreach (int el in list)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();
            Console.WriteLine("Довжина списку");
            //дізнатися скільки елементів в списку
            Console.WriteLine(list.MyLength());
            Console.WriteLine();



        }
    }
}
