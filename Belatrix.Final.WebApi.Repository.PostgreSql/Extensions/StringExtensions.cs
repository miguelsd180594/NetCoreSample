﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Final.WebApi.Repository.PostgreSql.Extensions
{
    public static class StringExtensions
    {
        public static string ToLowerWithUnderdash(this string val)
        {
            string result = "";
            int loop = 0;
            foreach (char c in val)
            {
                if (char.IsUpper(c))
                {
                    if (loop != 0)
                        result += $"_{char.ToLower(c)}";
                    else
                        result += $"{char.ToLower(c)}";
                }
                else
                {
                    result += c;
                }
                loop++;
            }
            return result;
        }
    }
}
