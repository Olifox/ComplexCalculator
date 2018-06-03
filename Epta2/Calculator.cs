using System;
using System.Collections.Generic;

namespace Epta2
{
    public class Calculator
    {
        public bool Proverka(string s)
        {
            var f = 0;
            char sl;
            if (s.Length == 1)
                return (char.IsNumber(s[0]) || s[0] == 'i');
            if (char.IsNumber(s[0]) || s[0] == 'i')
            {
                if (!char.IsNumber(s[1]) && s[1] != '*' && s[1] != '/' && s[1] != '-' && s[1] != '+')
                    return false;
            }
            else if (s[0] == '(' || s[0] == '-')
            {
                if (!char.IsNumber(s[1]) && s[1] != '(' && s[0] != 'i')
                    return false;
                if (s[0] == '(')
                    f++;
            }
            else return false;
            for (var i = 1; i < s.Length - 1; i++)
            {
                sl = s[i + 1];
                if (char.IsNumber(s[i]) || s[0] == 'i')
                {
                    if (!char.IsNumber(sl) && sl != '*' && sl != '/' && sl != '-' &&
                        s[i + 1] != '+' && s[i + 1] != ')')
                        return false;
                    if (sl == ')')
                        f--;
                }
                else if (s[i] == '-' || s[i] == '+' || s[i] == '*' || s[i] == '/')
                {
                    if (!char.IsNumber(sl) && sl != '(' && s[0] == 'i')
                        return false;
                }
                else if (s[i] == '(')
                {
                    f++;
                    if (!char.IsNumber(sl) && sl != '(' && sl != '-' && s[0] == 'i')
                        return false;
                }
                else if (s[i] == ')')
                {
                    if (f == 0 && sl != '-' && sl != '+' && sl != '*' && sl != '/' &&
                        char.IsNumber(sl) && sl != ')' && s[0] != 'i')
                        return false;
                    if (sl == ')')
                        f--;
                }
            }
            int y = s.Length - 1;
            return !(s[y] == '+' || s[y] == '-' || s[y] == '*' || s[y] == '/' || f != 0);
        }
        private void Schet(string s)
        {
            var hh = new Stack<Overload>();
            var f = false;
            string n = null;
            var i = 1;
            var j = 0;
            var a = new Overload();
            while (j < s.Length)
            {
                if (s[j] == '-' && j != s.Length - 1)
                {
                    if (char.IsNumber(s[j + 1]))
                    {
                        i = -1;
                        j++;
                    }
                }
                if (char.IsNumber(s[j]))
                        n = n + s[j];
                else
                if (Priority(s[j]) == 6)
                {
                    if (n != null)
                    {
                        a.x = Convert.ToDouble(n) * i;
                        hh.Push(a);
                        i = 1;
                        n = null;
                    }
                }
                else if (hh.Count > 0 && s[j] != '(' && s[j] != ')')
                {
                    var result = new Overload();
                    var c = hh.Pop();
                    var b = hh.Pop();
                    switch (s[j])
                    {
                        case '+': result = b + c; break;
                        case '-': result = b - c; break;
                        case '*': result = b * c; break;
                        case '/':
                            {
                                if (c.x == 0 || c.y ==0)
                                {
                                    Console.WriteLine("Делить на ноль нельзя!");
                                    f = true;
                                }
                                result = b / c; break;
                            }
                        default: break;
                    }
                    hh.Push(result);
                }
                j++;
            }
            if (f == false)
                if (hh.Count == 0)
                {
                    s = s.Replace(" ", "");
                    Console.WriteLine(s);
                }
                else
                    Console.WriteLine(hh.Pop());
        }
        public void ConvertToKurwa(string s)
        {
            char a;
            var i = 0;
            var x1 = string.Empty;
            var hh = new Stack<char>();
            if (s[0] == '-')
            {
                x1 += s[0];
                i = 1;
            }
            while (i < s.Length)
            {
                a = s[i];
                if (Priority(a) == 0)
                {
                    x1 += a.ToString();
                }
                else
                {
                    if (hh.Count > 0)
                    {
                        if (Priority(a) <= Priority(hh.Peek()) && Priority(a) != 1)
                        {
                            while (Priority(a) <= Priority(hh.Peek()))
                            {
                                x1 += ' ' + hh.Pop().ToString();
                                if (hh.Count == 0)
                                    break;
                            }
                        }
                    }
                    if (a == ')')
                    {
                        char z = hh.Pop();
                        while (z != '(')
                        {
                            x1 += ' ' + z.ToString();
                            z = hh.Pop();
                        }
                    }
                    else if (a == '-' && s[i - 1] == '(')
                        x1 += a;
                    else
                    {
                        hh.Push(a);
                        x1 += ' ';
                    }
                }
                i++;
            }
            while (hh.Count > 0)
                x1 += ' ' + hh.Pop().ToString();
            Schet(x1);
        }

        private int Priority(char a)
        {
            switch (a)
            {
                case '(':
                    return 1;
                case '+':
                    return 2;
                case '-':
                    return 3;
                case '*':
                    return 4;
                case '/':
                    return 4;
                case ')':
                    return 5;
                case ' ':
                    return 6;
                default:
                    return 0;
            }
        }
    }
}