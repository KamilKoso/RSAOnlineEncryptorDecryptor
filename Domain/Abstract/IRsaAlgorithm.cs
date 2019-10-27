using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Domain.Abstract
{
   public interface IRsaAlgorithm
    {
        int p { get; set; }
        int q { get; set; }
        int z { get; set; }
        int e { get; set; }
        int d { get; set; }
        int n { get; set; }

        int calculateN();
        int calculateE();
        int calculateZ();
        int calculateD();
        List<int> EncodeMessage(string message, int n, int e);
        string DecodeMessage(List<int> codedList, int n, int d);
    }
}
