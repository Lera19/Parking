// TODO: implement struct TransactionInfo.
//       Necessarily implement the Sum property (decimal) - is used in tests.
//       Other implementation details are up to you, they just have to meet the requirements of the homework.
using System;
using System.Collections.Generic;

public struct TransactionInfo
{

    public decimal Sum { get; set; }
    public DateTime Time { get; set; }
    public Vehicle Vehicle { get; set; }
    public List<TransactionInfo> GetList { get; set; }
}