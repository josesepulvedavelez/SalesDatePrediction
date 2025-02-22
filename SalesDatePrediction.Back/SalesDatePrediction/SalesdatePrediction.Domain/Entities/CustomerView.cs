using System;
using System.Collections.Generic;

namespace SalesdatePrediction.Domain.Entities;

public partial class CustomerView
{
    public int Custid { get; set; }

    public string Companyname { get; set; } = null!;

    public DateTime? LastOrderDate { get; set; }

    public DateTime? NextPredictedOrder { get; set; }
}
