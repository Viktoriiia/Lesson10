using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInt = new int[10];
            Random random = new Random();
            for (int i = 0; i < arrayInt.Length; i++)
            {
                arrayInt[i] = random.Next(1000);
                Console.WriteLine("{0}", arrayInt[i]);
            }
                Console.WriteLine("////////////////////////BubbleSort/////////////////////////");
                for(int i=0; i<arrayInt.Length-1; i++ )
                {
                    for(int j=0; j<arrayInt.Length-i-1; j++)
                    {
                        if(arrayInt[j]>arrayInt[j+1])
                        {
                           //swap(arrayInt ,j,j+1);
                           //printArray(arrayInt);
                           int temp = arrayInt[j];
                           arrayInt[j] = arrayInt[j+1];
                           arrayInt[j + 1] = temp;
                    }
                    }
                //printArray(arrayInt);
            }

            printArray(arrayInt);
                
            Console.WriteLine("////////////////////////Sort/////////////////////////");
            for(int i=1; i<arrayInt.Length; i++)
            {
                if(arrayInt[i]<arrayInt[i-1])
                {
                    int temp = arrayInt[i];
                    arrayInt[i] = arrayInt[i - 1];
                    arrayInt[i - 1] = temp;
                    for(int j=i-1;j>0;j--)
                    {
                        if(arrayInt[j]<arrayInt[j-1])
                        {
                            temp = arrayInt[j];
                            arrayInt[j] = arrayInt[j - 1];
                            arrayInt[j - 1] = temp;
                        }
                    }
                }
            }
            printArray(arrayInt);
            Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\Stack\\\\\\\\\\\\\\\\\\\\\\");
            MyStack stack = new MyStack();
            stack.isEmpty();
            stack.isFull();
            //stack.Push(12);
            //stack.Push(11);
            //stack.Peek();
            int k = 0;
            while( k != 10)
                {
                stack.Push(k+1);
                k++;
            }
            stack.Pop(9);//after delete Full takes stackPosition = 10?????
            //stack.Push(12);
            //stack.Push(11);
            //stack.Push(11);
            //stack.Push(10);
            //stack.Push(9);
            //stack.Push(8);
            //stack.Push(7);
            //stack.Push(6);
            //stack.Push(5);
            //stack.Push(4);
            //stack.Push(3);
            //stack.Push(1); // try to add 11-element to stack ??? 
            //stack.PrintStack();
            //stack.Pop();

            MyQuery queue = new MyQuery();
            queue.Enqueue(10);
            queue.Enqueue(1);
            queue.Enqueue(5);
            queue.Dequeue(0);
            Console.ReadKey();
            


     
    }
        static void printArray(int[] arrayInt)
        {
            Console.WriteLine("Sort array:");
            for (int i = 0; i < arrayInt.Length; i++)
            {
                Console.WriteLine(arrayInt[i]);
            }
        }

        static void swap(int[] array, int index1, int index2)
        {
            int temp = index1;
            index1 = index2;
            index2 = temp;
        }
    }


    
    class MyQuery
    {
        private int[] array = new int[10];
        private int tail = 0;

        public bool Enqueue(int addValueToQueue)
        {
            if (tail<array.Length)
            {
                array[tail] = addValueToQueue;
                tail++;
            }
            Console.WriteLine("Tail is:{0}", tail);
            PrintQuery();
            iSFull();
            return true;
        }

        public bool Dequeue(int tail)
        {
            if(tail!=0)
            {
                array[0] = 0; //зануляем элемент
            }
            for (int i= 1; i<array.Length; i++)
            {
                if((array[i]!=0)&&(i<9))
                {
                    array[i - 1] = array[i];
                }
            }
            array[tail] = 0;
            tail--;
            PrintQuery();
            iSFull();
            Console.WriteLine("Tail is:{0}", tail);
            return true;
        }

        public void PrintQuery()
        {
            Console.WriteLine("Queue is:");
            for (int i=0; i<array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public void iSFull()
        {
            if(tail == array.Length)
            {
                Console.WriteLine("Error: Query is Full!!!");
            }
            int persentQueueFull = (tail * 100) / array.Length;
            Console.WriteLine("Query is {0} full", persentQueueFull);
        }

        public void isEmpty()
        {
            if(tail == 0)
            {
                Console.WriteLine("Queue is Empty");
            }
            else
            {
                Console.WriteLine("Queue is Not empty");
            }
        }
    }

    class MyStack
    {
        private int[] array = new int[10];
        private int stackPosition = 0;

        public bool Push(int valueToPush)
        {
            if(stackPosition == array.Length)//якщо переповнення
            {
                Console.WriteLine("Error: Stack is full!!!");
                Console.ReadKey();
                Environment.Exit(1);
            }
            array[stackPosition] = valueToPush; //додаємо елемент
            stackPosition++;
            PrintStack();
            Console.WriteLine("stackPosition={0}", stackPosition);
            isFull();
            return true;
        }

        public bool Pop(int stackPosition)// works not correct
        {
            if (stackPosition > 0)
            {
                Console.WriteLine("stackPosition before delete ={0}", stackPosition);
                //Array.Clear(array, stackPosition, 0);
                array[stackPosition -1] = 0;//?????
                stackPosition--;
                PrintStack();
                Console.WriteLine("stackPosition after delete ={0}", stackPosition);
                isFull();
            }
            else
            {
                Console.WriteLine("Stack is Empty");
                Console.ReadLine();
                Environment.Exit(1);
            }
                return true;
        }

        public void isEmpty()
        {
            if(stackPosition == 0)
            {
                Console.WriteLine("Stack is Empty");
            }
            else
            {
                Console.WriteLine("Stack is not empty");
            }
        }

        public void isFull()
        {
            if(stackPosition == array.Length)
            {
                Console.WriteLine("Stack is Full");
            }
            float FpersentRatioFullSteck = (stackPosition * 100) / array.Length;
            Console.WriteLine("Stack is full on {0}%", FpersentRatioFullSteck);
        }

        public void PrintStack()
        {
            for(int i=0; i<array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            
        }
        public void Peek()
        {
            if (stackPosition == 1)
            {
                Console.WriteLine("The last element: {0}", array[0]);
            }
            else
            {
                Console.WriteLine("111");
            }
        }
    }


}
