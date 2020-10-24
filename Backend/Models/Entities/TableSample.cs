using System;

namespace Backend.Models.Entities
{
  // [DataContract(Name = "table_samples")]
  public class TableSample
  {
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}
