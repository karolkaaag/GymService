using System;
using System.Collections.Generic;
using System.Text;

namespace GymService.Infrastructure.ExtensionMethods
{
    static class StringExtensions
    {
        public static bool Empty(this string value) => string.IsNullOrWhiteSpace(value);
    }
}
