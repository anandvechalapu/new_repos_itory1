namespace newcom
{
    public class GratuityCalculationModel
    {
        public int Id { get; set; }

        public decimal BasicSalary { get; set; }
        public decimal Increments { get; set; }
        public decimal GratuityAmount { get; set; }
    }
}