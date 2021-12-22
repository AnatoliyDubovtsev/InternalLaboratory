﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class OperationsWithElements
    {
        public static void SwapElements<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }

        public static string WholeDecNumberToBin(long number)
        {
            StringBuilder stringBuilder = new();
            while (number >= 1)
            {
                if (number == 1)
                {
                    stringBuilder.Append(number);
                    break;
                }

                stringBuilder.Append(number % 2);
                number /= 2;
            }

            return stringBuilder.ToString();
        }

        public static string FloatingPointDecNumberToBin(double number, int count)
        {
            StringBuilder stringBuilder = new();
            while (number != 0.0 && count != 0)
            {
                number *= 2;
                if (number >= 1)
                {
                    stringBuilder.Append(1);
                }
                else
                {
                    stringBuilder.Append(0);
                }                

                while (number >= 1)
                {
                    number -= 1;
                }

                count--;
            }

            return stringBuilder.ToString();
        }
    }
}